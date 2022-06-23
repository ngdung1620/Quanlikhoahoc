using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services
{
    public interface ICombinedCourseService
    {
        CombinedCourseResponse CreateCombinedCourse(CombinedCourseRequest request);
        List<ListCombinedCourseResponse> ListCombinedCourse();
        bool DeleteCombinedCourse(Guid id);
        EditCombinedCourseResponse EditCombinedCourse(EditCombinedCourseRequest request);
        bool AddCourse(AddCourseInCombinedCourseRequest request);
    }
}