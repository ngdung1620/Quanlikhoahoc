using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.RequestModels
{
    public class AddCourseInCombinedCourseRequest
    {
        public Guid CombinedCoursesId { get; set; }
        public List<Guid> CoursesId { get; set; }
    }
}