using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebKhoaHoc.Models.RequestModels
{
    public class RegistrationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }

        public List<string> Roles { get; set; }
    }
}