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
    public class CourseService: ICourseService
    {
        private readonly MasterDbContext _context;
        public static int PageSize { get; set; } = 5;

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
                    Image = course.Image,
                    ImageUrl = course.ImageUrl,
                    Title = course.Title,
                    
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

        public async Task<GetListLessonWithCourseIdResponse> GetListLessonByCourseId(Guid courseId)
        {
            var course = await _context.Courses
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            return new GetListLessonWithCourseIdResponse
            {
                CourseId = course.Id,
                Description = course.Description,
                Title = course.Title,
                Lessons = course.Lessons
            };
        }

      

        public CourseResponse GetListCourse(CourseRequest request)
        {
            var allCourse = _context.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(request.Search))
            {
                allCourse = allCourse.Where(c =>  c.Title.ToLower().Contains(request.Search.ToLower()));
            }
            
            var result = PaginatedList<Course>.Create(allCourse, request.PageIndex, request.PageSize);
            var listCourse = result.Select(c => new ListCourseResponse
            {
                Id = c.Id,
                Description = c.Description,
                Image = c.Image,
                ImageUrl = c.ImageUrl,
                Title = c.Title,
            }).ToList();
            return new CourseResponse
            {
                ListCourse = listCourse,
                TotalPage = result.TotalPage,
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalRecords = allCourse.Count()
            };

        }
    }
}