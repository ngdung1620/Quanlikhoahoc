using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class UserResponse
    {
        public List<ListUserResponse> ListUser { get; set; }
        public int TotalPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}