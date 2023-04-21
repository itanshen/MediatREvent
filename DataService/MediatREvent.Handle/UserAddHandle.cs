using DataService.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.MediatREvent.Handle
{
    /// <summary>
    /// 接收用户新增成功的消息
    /// </summary>
    public class UserAddHandle : INotificationHandler<UserAddedEvent>
    {
        public Task Handle(UserAddedEvent notification, CancellationToken cancellationToken)
        {
            // 注：这里Item是 UserAddedEvent(UserInfo Item)中的参数
            Console.WriteLine($"收到消息：用户新增成功，用户为:{notification.Item.Id},{notification.Item.Name}");
            return Task.CompletedTask;
        }
    }
}
