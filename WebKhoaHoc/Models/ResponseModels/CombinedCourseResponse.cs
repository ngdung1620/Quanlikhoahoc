using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class CombinedCourseResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Course> Courses { get; set; }
    }
}