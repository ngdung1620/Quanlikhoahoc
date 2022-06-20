using Microsoft.EntityFrameworkCore.Migrations;

namespace WebKhoaHoc.Migrations
{
    public partial class createTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourse_Course_CoursesId",
                table: "ApplicationUserCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CombinedCourseCourse_CombinedCourse_CombinedCoursesId",
                table: "CombinedCourseCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CombinedCourseCourse_Course_CoursesId",
                table: "CombinedCourseCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CombinedCourse",
                table: "CombinedCourse");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "CombinedCourse",
                newName: "CombinedCourses");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_CourseId",
                table: "Lessons",
                newName: "IX_Lessons_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombinedCourses",
                table: "CombinedCourses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourse_Courses_CoursesId",
                table: "ApplicationUserCourse",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CombinedCourseCourse_CombinedCourses_CombinedCoursesId",
                table: "CombinedCourseCourse",
                column: "CombinedCoursesId",
                principalTable: "CombinedCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CombinedCourseCourse_Courses_CoursesId",
                table: "CombinedCourseCourse",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourse_Courses_CoursesId",
                table: "ApplicationUserCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CombinedCourseCourse_CombinedCourses_CombinedCoursesId",
                table: "CombinedCourseCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_CombinedCourseCourse_Courses_CoursesId",
                table: "CombinedCourseCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CombinedCourses",
                table: "CombinedCourses");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "CombinedCourses",
                newName: "CombinedCourse");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseId",
                table: "Lesson",
                newName: "IX_Lesson_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombinedCourse",
                table: "CombinedCourse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourse_Course_CoursesId",
                table: "ApplicationUserCourse",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CombinedCourseCourse_CombinedCourse_CombinedCoursesId",
                table: "CombinedCourseCourse",
                column: "CombinedCoursesId",
                principalTable: "CombinedCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CombinedCourseCourse_Course_CoursesId",
                table: "CombinedCourseCourse",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
