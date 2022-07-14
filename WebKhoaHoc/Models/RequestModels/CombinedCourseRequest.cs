using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.RequestModels
{
    public class CombinedCourseRequest
    {
        public List<Guid> Courses { get; set; }
        public string Title { get; set; }
    }
}