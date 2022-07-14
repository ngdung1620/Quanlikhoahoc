using System;

namespace WebKhoaHoc.Models.RequestModels
{
    public class EditUserRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}