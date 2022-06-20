using System;
using System.Collections.Generic;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services
{
    public interface ILessonService
    {
        List<ListLessonResponse> ListLesson();
        CreateLessonResponse CreateLesson(CreateLessonRequest request);
        bool DeleteLesson(Guid id);
        EditLessonResponse EditLesson(EditLessonRequest request);
    }
}