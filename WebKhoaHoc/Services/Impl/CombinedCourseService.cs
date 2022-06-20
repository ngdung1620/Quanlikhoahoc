using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Image = request.Image,
                ImageUrl = request.ImageUrl,
                Slug = request.Slug,
                Title = request.Title,
                Courses = courses
            };
            _context.CombinedCourses.Add(newCombinedCourse);
            _context.SaveChanges();
            
            return new CombinedCourseResponse
            {
                Id = newCombinedCourse.Id,
                Image = newCombinedCourse.Image,
                ImageUrl = newCombinedCourse.ImageUrl,
                Slug = newCombinedCourse.Slug,
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
                _context.CombinedCourses.FirstOrDefault(combinedCourse => combinedCourse.Id == request.Id);
            if (editCombinedCourse == null)
            {
                throw new Exception("Combined Course not exist!");
            }
            editCombinedCourse.Image = request.Image;
            editCombinedCourse.ImageUrl = request.ImageUrl;
            editCombinedCourse.Slug = request.Slug;
            editCombinedCourse.Title = request.Title;
            _context.SaveChanges();
            return new EditCombinedCourseResponse
            {
                Id = editCombinedCourse.Id,
                Image = editCombinedCourse.Image,
                ImageUrl = editCombinedCourse.ImageUrl,
                Slug = editCombinedCourse.Slug,
                Title = editCombinedCourse.Title
            };
        }
    }
}