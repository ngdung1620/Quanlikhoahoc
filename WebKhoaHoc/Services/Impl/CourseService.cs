using System;
using System.Collections.Generic;
using System.Linq;
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
                Icon = request.Icon,
                IconUrl = request.IconUrl,
                Image = request.Image,
                ImageUrl = request.ImageUrl,
                IsComingSoon = request.IsComingSoon,
                IsPreOrder = request.IsPreOrder,
                IsPro = request.IsPro,
                IsPublished = request.IsPublished,
                IsRegistered = request.IsRegistered,
                IsSelling = request.IsSelling,
                LastCompletedAt = request.LastCompletedAt,
                OldPrice = request.OldPrice,
                PreOldPrice = request.PreOldPrice,
                Price = request.Price,
                PublishedAt = request.PublishedAt,
                RelatedCourses = request.RelatedCourses,
                Slug = request.Slug,
                StudentCount = request.StudentCount,
                Title = request.Title,
                UserProgress = request.UserProgress,
                Video = request.Video,
                VideoType = request.VideoType,
                VideoUrl = request.VideoUrl,
                CombinedCourses = combinedCourses
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return new CreateCourseRespone
            {
                Id = newCourse.Id,
                Description = newCourse.Description,
                Icon = newCourse.Icon,
                IconUrl = newCourse.IconUrl,
                Image = newCourse.Image,
                ImageUrl = newCourse.ImageUrl,
                IsComingSoon = newCourse.IsComingSoon,
                IsPreOrder = newCourse.IsPreOrder,
                IsPro = newCourse.IsPro,
                IsPublished = newCourse.IsPublished,
                IsRegistered = newCourse.IsRegistered,
                IsSelling = newCourse.IsSelling,
                LastCompletedAt = newCourse.LastCompletedAt,
                OldPrice = newCourse.OldPrice,
                PreOldPrice = newCourse.PreOldPrice,
                Price = newCourse.Price,
                PublishedAt = newCourse.PublishedAt,
                RelatedCourses = newCourse.RelatedCourses,
                Slug = newCourse.Slug,
                StudentCount = newCourse.StudentCount,
                Title = newCourse.Title,
                UserProgress = newCourse.UserProgress,
                Video = newCourse.Video,
                VideoType = newCourse.VideoType,
                VideoUrl = newCourse.VideoUrl,
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
                    VideoUrl = course.VideoUrl
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
            var editCourse = _context.Courses.FirstOrDefault(course => course.Id == request.Id);
            if (editCourse == null)
            {
                throw new Exception("Course not exist!");
            }
            editCourse.Description = request.Description;
            editCourse.Title = request.Title;
            editCourse.Video = request.Video;
            _context.SaveChanges();
            return new EditCourseResponse
            {
                Id = editCourse.Id,
                Description = editCourse.Description,
                Title = editCourse.Title,
                Video = editCourse.Video
            };
        }
    }
}