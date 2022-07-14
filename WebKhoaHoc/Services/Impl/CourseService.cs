using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebKhoaHoc.Models;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services.Impl
{
    public class CourseService: ICourseService
    {
        private readonly MasterDbContext _context;

        public CourseService(MasterDbContext context)
        {
            _context = context;
        }

        public CreateCourseRespone CreateCourse(CreateCourseRequest request)
        {
            var combinedCourses = new List<CombinedCourse>();
            request.CombinedCoursesId.ForEach(combinedCourse =>
            {
                var newCombinedCourse = _context.CombinedCourses.FirstOrDefault(c => c.Id == combinedCourse);
                if (newCombinedCourse == null)
                {
                    throw new Exception("CombinedCourses not exist!");
                }

                combinedCourses.Add(newCombinedCourse);
            });
            var newCourse = new Course
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Slug = request.Slug,
                Title = request.Title,
                CombinedCourses = combinedCourses
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return new CreateCourseRespone
            {
                Id = newCourse.Id,
                Description = newCourse.Description,
                ImageUrl = newCourse.ImageUrl,
            };

        }

        public List<ListCourseResponse> ListCourse()
        {
            var course = _context.Courses
                .Select(course => new ListCourseResponse
                {
                    Id = course.Id,
                    Description = course.Description,
                    Icon = course.Icon,
                    IconUrl = course.IconUrl,
                    Image = course.Image,
                    ImageUrl = course.ImageUrl,
                    IsComingSoon = course.IsComingSoon,
                    IsPreOrder = course.IsPreOrder,
                    IsPro = course.IsPro,
                    IsPublished = course.IsPublished,
                    IsRegistered = course.IsRegistered,
                    IsSelling = course.IsSelling,
                    LastCompletedAt = course.LastCompletedAt,
                    OldPrice = course.OldPrice,
                    PreOldPrice = course. PreOldPrice,
                    Price = course.Price,
                    PublishedAt = course.PublishedAt,
                    RelatedCourses = course.RelatedCourses,
                    Slug = course.Slug,
                    StudentCount = course.StudentCount,
                    Title = course.Title,
                    UserProgress = course.UserProgress,
                    Video = course.Video,
                    VideoType = course.VideoType,
                    VideoUrl = course.VideoUrl,
                    Lessons = course.Lessons,
                    CombinedCourses = course.CombinedCourses
                }).ToList();
            
            return course;
        }

        public bool DeleteCourse(Guid id)
        {
            var deleteCourse = _context.Courses.FirstOrDefault(course => course.Id == id);
            if (deleteCourse == null)
            {
                throw new Exception("Course not exist!");
            }

            _context.Remove(deleteCourse);
            _context.SaveChanges();
            return true;
        }

        public EditCourseResponse EditCourse(EditCourseRequest request)
        {
            var editCourse = _context.Courses
                .Include(cb => cb.CombinedCourses)
                .FirstOrDefault(course => course.Id == request.Id);
            if (editCourse == null)
            {
                throw new Exception("Course not exist!");
            }
            editCourse.CombinedCourses.Clear();
            editCourse.Description = request.Description;
            editCourse.Title = request.Title;
            editCourse.ImageUrl = request.ImageUrl;
            request.CombinedCoursesId.ForEach(combinedCourseId =>
            {
                var combinedCourse = _context.CombinedCourses.FirstOrDefault(cb => cb.Id == combinedCourseId);
                if (combinedCourse == null)
                {
                    throw new Exception("Nhóm khóa học không tồn tại");
                }
                if ( editCourse.CombinedCourses!= null)
                {
                    editCourse.CombinedCourses.Add(combinedCourse);
                }
                else
                { 
                    editCourse.CombinedCourses = new List<CombinedCourse> { combinedCourse};
                }
            });
            _context.SaveChanges();
            return new EditCourseResponse
            {
                Id = editCourse.Id,
                Description = editCourse.Description,
                Title = editCourse.Title
            };
        }
    }
}