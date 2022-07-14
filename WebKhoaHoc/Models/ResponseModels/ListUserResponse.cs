using System;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class ListUserResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}