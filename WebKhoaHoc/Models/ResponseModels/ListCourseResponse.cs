﻿using System;
using System.Collections.Generic;

namespace WebKhoaHoc.Models.ResponseModels
{
    public class ListCourseResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }

    }
}