using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class CreateCourseRespone
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public List<CombinedCourse> CombinedCourses { get; set; }
    }
}