using System;
using System.ComponentModel.DataAnnotations;

namespace WebKhoaHoc.Models.RequestModels
{
    public class CreateLessonRequest
    {
        public string ContinueId { get; set; }
        [Required]
        public Guid CourseId { get; set; }

        public int CourseProgress { get; set; }
        public bool EndOfCourse { get; set; }
        public bool EndOfFree { get; set; }
        public bool HasEndTimeLogging { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsLogged { get; set; }
        public string LastStepId { get; set; }
        
        public Guid LearningLog { get; set; }

        public string NextId { get; set; }
        public int PassPercent { get; set; }
        public Guid TrackStep { get; set; }
        public string UserSolutions { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
    }
}