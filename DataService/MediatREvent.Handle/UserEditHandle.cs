using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.MediatREvent.Handle
{
    /// <summary>
    /// 接受用户修改消息
    /// </summary>
    public class UserEditHandle : INotificationHandler<UserEditedEvent>
    {
        public Task Handle(UserEditedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"接收消息：{notification.Type}由{notification.OldParam}修改为{notification.NewParam}");
            return Task.CompletedTask;
        }
    }
}
