using System;

namespace WebKhoaHoc.Models.RequestModels
{
    public class EditLessonRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
        public Guid CourseId { get; set; }
    }
}