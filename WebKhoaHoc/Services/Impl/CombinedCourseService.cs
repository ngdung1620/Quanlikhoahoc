using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebKhoaHoc.Models;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services.Impl
{
    public class CombinedCourseService: ICombinedCourseService
    {
        private readonly MasterDbContext _context;

        public CombinedCourseService(MasterDbContext context)
        {
            _context = context;
        }

        public CombinedCourseResponse CreateCombinedCourse(CombinedCourseRequest request)
        {
            var courses = new List<Course>();
            request.Courses
                .ForEach(course =>
                {
                    var newCourse = _context.Courses.FirstOrDefault(c => c.Id == course);
                    if (newCourse == null)
                    {
                        throw new Exception("Course not exist!!");
                    }

                    courses.Add(newCourse);
                });
            var newCombinedCourse = new CombinedCourse
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Courses = courses
            };
            _context.CombinedCourses.Add(newCombinedCourse);
            _context.SaveChanges();
            
            return new CombinedCourseResponse
            {
                Id = newCombinedCourse.Id,
                Title = newCombinedCourse.Title,
                Courses = newCombinedCourse.Courses
            };
        }

        public List<ListCombinedCourseResponse> ListCombinedCourse()
        {
            var combinedCourse = _context.CombinedCourses
                .Select(combinedCourse => new ListCombinedCourseResponse
                {
                    Id = combinedCourse.Id,
                    Image = combinedCourse.Image,
                    ImageUrl = combinedCourse.ImageUrl,
                    Slug = combinedCourse.Slug,
                    Title = combinedCourse.Title,
                    Courses = combinedCourse.Courses
                }).ToList();
            return combinedCourse;
        }

        public bool DeleteCombinedCourse(Guid id)
        {
            var deleteCombinedCourse =
                _context.CombinedCourses.FirstOrDefault(combinedCourse => combinedCourse.Id == id);
            if (deleteCombinedCourse == null)
            {
                throw new Exception("Combined Course not exist!");
            }
            _context.Remove(deleteCombinedCourse);
            _context.SaveChanges();
            return true;
        }

        public EditCombinedCourseResponse EditCombinedCourse(EditCombinedCourseRequest request)
        {
            var editCombinedCourse =
                _context.CombinedCourses
                    .Include(c => c.Courses)
                    .FirstOrDefault(combinedCourse => combinedCourse.Id == request.Id);
            if (editCombinedCourse == null)
            {
                throw new Exception("Khóa học không tồn tại");
            }
            editCombinedCourse.Title = request.Title;
            editCombinedCourse.Courses.Clear();
            request.Courses.ForEach(courseId =>
            {
                var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
                if (course == null)
                {
                    throw new Exception("Courses not exist!");
                }

                if ( editCombinedCourse.Courses != null)
                {
                    editCombinedCourse.Courses.Add(course);
                }
                else
                { 
                    editCombinedCourse.Courses = new List<Course> { course };
                }
            });
            _context.SaveChanges();
            return new EditCombinedCourseResponse()
            {
                Id = editCombinedCourse.Id,
                Title = editCombinedCourse.Title,
                Courses = editCombinedCourse.Courses
            };
        }

        public bool AddCourse(AddCourseInCombinedCourseRequest request)
        {
            var newCombinedCourse = _context.CombinedCourses
                .Include(c => c.Courses)
                .FirstOrDefault(c => c.Id == request.CombinedCoursesId);
            if (newCombinedCourse == null) throw new Exception("Combined courses not exist");
            request.CoursesId.ForEach(courseId =>
            {
                var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
                if (course == null)
                {
                    throw new Exception("Courses not exist!");
                }

                if (newCombinedCourse.Courses != null)
                {
                    newCombinedCourse.Courses.Add(course);
                }
                else
                {
                    newCombinedCourse.Courses = new List<Course> { course };
                }
            });
            _context.SaveChanges();
            return true;
        }
    }
}