using System.Collections.Generic;
using CKLS.Identity.Models;

namespace WebKhoaHoc.Settings
{
    public class UIClaims
    {
        public const string CourseRead = "Course.Read";
        public const string CourseWrite = "Course.Write";
        public const string CombinedCourseRead = "CombinedCourse.Read";
        public const string CombinedCourseWrite = "CombinedCourse.Write";

        public static ClaimInfo CourseClaims = new ClaimInfo("Quản lý thông tin khoá học", "CourseManagementClaim", new List<Permission>()
        {
            new Permission("Đọc", CourseRead, 1),
            new Permission("Ghi", CourseWrite, 2)
        });
        public static ClaimInfo CombinedCourseClaims = new ClaimInfo("Quản lý thông tin lột trình học", "CombinedCourseManagementClaim", new List<Permission>()
        {
            new Permission("Đọc", CombinedCourseRead, 1),
            new Permission("Ghi", CombinedCourseWrite, 2)
        });
    }
}