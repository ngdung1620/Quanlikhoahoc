using System;
using Microsoft.AspNetCore.Mvc;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;
using WebKhoaHoc.Services;

namespace WebKhoaHoc.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CombinedCourseController: ControllerBase
    {
        private readonly ICombinedCourseService _combinedCourseService;

        public CombinedCourseController(ICombinedCourseService combinedCourseService)
        {
            _combinedCourseService = combinedCourseService;
        }

        [HttpGet("list-combine-course")]
        public IActionResult ListCombineCourse()
        {
            var combinedCourse = _combinedCourseService.ListCombinedCourse();
            return Ok(combinedCourse);
        }

        [HttpPost("create-combined-course")]
        public IActionResult CreateCombinedCourse([FromBody] CombinedCourseRequest request)
        {
            var combinedCourse = _combinedCourseService.CreateCombinedCourse(request);
            return Ok(combinedCourse);
        }

        [HttpDelete("delete-combined-course/{id}")]
        public IActionResult DeleteCombineCourse(Guid id)
        {
            var isDeletecombineCourse = _combinedCourseService.DeleteCombinedCourse(id);
            return Ok(isDeletecombineCourse);
        }
        [HttpPost("edit-combined-course")]
        public IActionResult EditCombinedCourse([FromBody] EditCombinedCourseRequest request)
        {
            var editCombinedCourse = _combinedCourseService.EditCombinedCourse(request);
            return Ok(editCombinedCourse);
        }
    }
}