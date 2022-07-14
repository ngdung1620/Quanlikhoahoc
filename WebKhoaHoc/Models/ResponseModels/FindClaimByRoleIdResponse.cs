using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class FindClaimByRoleIdResponse
    {
        public Guid RoleId { get; set; }        
        public string Name { get; set; }
        public List<string> Claims { get; set; }
    }
}