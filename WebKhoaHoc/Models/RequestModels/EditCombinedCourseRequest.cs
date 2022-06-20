using System;

namespace WebKhoaHoc.Models.RequestModels
{
    public class EditCombinedCourseRequest
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}