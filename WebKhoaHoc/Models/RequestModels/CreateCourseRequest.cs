using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebKhoaHoc.Models.RequestModels
{
    public class CreateCourseRequest
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Title { get; set; }
        public List<Guid> CombinedCoursesId { get; set; }
    }
}