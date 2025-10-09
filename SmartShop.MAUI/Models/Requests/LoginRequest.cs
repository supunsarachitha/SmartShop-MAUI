using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.MAUI.Models.Requests
{
    public class LoginRequest
    { 
        public required string UserName { get; set; } 
        public required string Password { get; set; }
    }
}
