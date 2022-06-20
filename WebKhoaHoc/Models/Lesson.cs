using System;

namespace WebKhoaHoc.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        
        public string ContinueId { get; set; }
        
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

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

        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
    }
}