using System;
using System.Collections.Generic;
using System.Linq;
using WebKhoaHoc.Models;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services.Impl
{
    public class LessonService: ILessonService
    {
        private readonly MasterDbContext _context;

        public LessonService(MasterDbContext context)
        {
            _context = context;
        }

        public List<ListLessonResponse> ListLesson()
        {
            var lessons = _context.Lessons.Select(lesson => new ListLessonResponse
            {
                Id = lesson.Id,
                CourseId = lesson.CourseId,
                Title = lesson.Title,
                Description = lesson.Description,
                Video = lesson.Video
            }).ToList();
            return lessons;
        }

        public CreateLessonResponse CreateLesson(CreateLessonRequest request)
        {
            var course = _context.Courses.FirstOrDefault(course => course.Id == request.CourseId);
            if (course == null)
            {
                throw new Exception("Course not found");
            }
            var newLesson = new Lesson
            {
                CourseId = request.CourseId,
                Title = request.Title,
                Description = request.Description,
                Video = request.Video
            };
            _context.Lessons.Add(newLesson);
            _context.SaveChanges();
            return new CreateLessonResponse
            {
                Id = newLesson.Id,
                CourseId = newLesson.CourseId,
                Title = newLesson.Title,
                Description = newLesson.Description,
                Video = newLesson.Video
            };
        }

        public bool DeleteLesson(Guid id)
        {
            var deleteLesson = _context.Lessons.FirstOrDefault(lesson => lesson.Id == id);
            if (deleteLesson == null)
            {
                throw new Exception("Lesson not exist!!");
            }
            _context.Remove(deleteLesson);
            _context.SaveChanges();
            return true;
        }

        public EditLessonResponse EditLesson(EditLessonRequest request)
        {
            var editLesson = _context.Lessons.FirstOrDefault(lesson => lesson.Id == request.Id);
            if (editLesson == null)
            {
                throw new Exception("Lesson not exist!!");
            }
            editLesson.Description = request.Description;
            editLesson.Video = request.Video;
            editLesson.Title = request.Title;
            editLesson.CourseId = request.CourseId;
            _context.SaveChanges();
            return new EditLessonResponse
            {
                Title = editLesson.Title,
                Description = editLesson.Description,
                Video = editLesson.Video
            };
        }
    }
}