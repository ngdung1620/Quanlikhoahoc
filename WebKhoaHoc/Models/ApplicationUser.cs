using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebKhoaHoc.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public List<Course> Courses { get; set; }
    }
}