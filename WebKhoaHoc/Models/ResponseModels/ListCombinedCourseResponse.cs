using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class ListCombinedCourseResponse
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }

        public List<Course> Courses { get; set; }
    }
}