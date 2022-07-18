using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public List<string> Claims { get; set; }
    }
}