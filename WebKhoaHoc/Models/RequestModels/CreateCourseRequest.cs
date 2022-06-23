using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebKhoaHoc.Models.RequestModels
{
    public class CreateCourseRequest
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public bool IsComingSoon { get; set; }
        public bool IsPreOrder { get; set; }
        public bool IsPro { get; set; }
        public bool IsPublished { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsSelling { get; set; }
        public string LastCompletedAt { get; set; }
        public int OldPrice { get; set; }
        public int  PreOldPrice { get; set; }
        public string Price { get; set; }
        public string PublishedAt { get; set; }
        public string RelatedCourses { get; set; }
        public string Slug { get; set; }
        public int StudentCount { get; set; }
        [Required]
        public string Title { get; set; }
        public int UserProgress { get; set; }
        public string Video { get; set; }
        public string VideoType { get; set; }
        public string VideoUrl { get; set; }
        public List<Guid> CombinedCoursesId { get; set; }
    }
}