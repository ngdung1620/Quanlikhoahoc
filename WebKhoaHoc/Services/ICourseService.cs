using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services
{
    public interface ICourseService
    {
        CreateCourseRespone CreateCourse(CreateCourseRequest request);
        List<ListCourseResponse> ListCourse();
        bool DeleteCourse(Guid id);
        EditCourseResponse EditCourse(EditCourseRequest request);
        Task<GetListLessonWithCourseIdResponse> GetListLessonByCourseId(Guid courseId);
        CourseResponse GetListCourse(CourseRequest request);
    }
}