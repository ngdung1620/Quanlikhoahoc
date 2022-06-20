using System;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class ListLessonResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
    }
}