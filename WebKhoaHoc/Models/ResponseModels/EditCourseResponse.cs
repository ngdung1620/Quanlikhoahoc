using System;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class EditCourseResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Video { get; set; }
    }
}