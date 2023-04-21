using DataService.MediatREvent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    /// <summary>
    /// 改造DbContext类，用于重写SaveChanges
    /// </summary>
    public class BaseDbContext : DbContext
    {
        private IMediator mediator;
        public BaseDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            this.mediator = mediator;
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //1.获取所有实现IDomainEvents接口 且 含有未发布事件的对象
            var domainEntities = this.ChangeTracker.Entries<IDomainEvents>().Where(e=>e.Entity.GetAllDomainEvents().Any());
            //2. 获取所有待发布的消息【剖析selectMany的作用，两次查找】
            var domainEvents = domainEntities.SelectMany(e => e.Entity.GetAllDomainEvents()).ToList();

            //3. 清空所有待发布的消息
            domainEntities.ToList().ForEach(u => u.Entity.ClearAllDomainEvents());
            //4. 发送消息
            foreach (var item in domainEvents)
            {
                await mediator.Publish(item, cancellationToken);
            }

            //操作数据库
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
