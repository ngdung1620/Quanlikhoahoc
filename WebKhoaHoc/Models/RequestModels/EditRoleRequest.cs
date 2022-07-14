using System;

namespace WebKhoaHoc.Models.RequestModels
{
    public class EditRoleRequest
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
    }
}