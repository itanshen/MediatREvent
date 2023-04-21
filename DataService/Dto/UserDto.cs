using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Dto
{
    public class UserDto
    {
        public string NameDto { get; set; }
        public string? Email { get; init; }
        public string? Password { get; set; }
    }
}
