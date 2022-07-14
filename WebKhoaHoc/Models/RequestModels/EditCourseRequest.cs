using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.RequestModels
{
    public class EditCourseRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<Guid> CombinedCoursesId { get; set; }
        
    }
}