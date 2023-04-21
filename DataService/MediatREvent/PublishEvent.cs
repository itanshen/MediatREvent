using DataService.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.MediatREvent
{
    public record PublishEvent(string Body) : INotification;

    /// <summary>
    /// 用来传递 新增User的领域事件类
    /// </summary>
    /// <param name="Item"></param>
    public record UserAddedEvent(User Item) : INotification;

    /// <summary>
    /// 用来传递 修改User的领域事件类
    /// </summary>
    public record UserEditedEvent(string OldParam, string NewParam, string Type) : INotification;

}
