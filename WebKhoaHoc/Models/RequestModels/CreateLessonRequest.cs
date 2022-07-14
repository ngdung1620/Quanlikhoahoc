using System;
using System.ComponentModel.DataAnnotations;

namespace WebKhoaHoc.Models.RequestModels
{
    public class CreateLessonRequest
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
    }
}