﻿using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class GetListLessonWithCourseIdResponse
    {
        public Guid CourseId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}