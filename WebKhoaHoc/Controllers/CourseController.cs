using System;
using Microsoft.AspNetCore.Mvc;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Services;

namespace WebKhoaHoc.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("list-course")]
        public IActionResult ListCourse()
        {
            var listCourse = _courseService.ListCourse();
            return Ok(listCourse);
        }
        [HttpPost("create-course")]
        public IActionResult CreateCourse([FromBody] CreateCourseRequest request)
        {
            var newCourse = _courseService.CreateCourse(request);
            return Ok(newCourse);
        }

        [HttpDelete("delete-course/{id}")]
        public IActionResult DeleteCourse([FromRoute] Guid id)
        {
            var isDeleted = _courseService.DeleteCourse(id);
            return Ok(isDeleted);
        }

        [HttpPost("edit-course")]
        public IActionResult EditCourse([FromBody] EditCourseRequest request)
        {
            var editCourse = _courseService.EditCourse(request);
            return Ok(editCourse);
        }
    }
}