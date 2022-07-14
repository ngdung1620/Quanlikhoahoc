using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.RequestModels
{
    public class EditCombinedCourseRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Guid> Courses { get; set; }
    }
}