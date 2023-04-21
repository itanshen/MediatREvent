using DataService.MediatREvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entity
{
    public partial class User
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string? Email { get; set; }
        private string? Password { get; set; }
        public DateTime CreatedTime { get; private set; }

        private string? remark;
        public string? Remark
        {
            get
            {
                return this.remark;
            }
        }
        public int Tag { get; set; }

    }

    public partial class User : BaseEntity
    {
        private User()
        {

        }

        public User(string name)
        {
            this.Name = name;
            this.CreatedTime = DateTime.Now;
            AddDomainEvent(new UserAddedEvent(this));
        }

        public void ChangeName(string name)
        {
            this.Name = name;
            AddDomainEventIfNoExist(new UserEditedEvent(this.Name,name, "name"));
        }

        public void ChangePassword(string password)
        {
            AddDomainEventIfNoExist(new UserEditedEvent(this.Password, password, "password"));
            this.Password = Zack.Commons.HashHelper.ComputeMd5Hash(password);
        }
    }
}
