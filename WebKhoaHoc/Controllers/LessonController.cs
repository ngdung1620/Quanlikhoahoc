using System;
using Microsoft.AspNetCore.Mvc;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Services;

namespace WebKhoaHoc.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("list-lesson")]
        public IActionResult ListLesson()
        {
            var lessons = _lessonService.ListLesson();
            return Ok(lessons);
        }

        [HttpPost("Create-lesson")]
        public IActionResult CreateLesson([FromBody] CreateLessonRequest request)
        {
            var lesson = _lessonService.CreateLesson(request);
            return Ok(lesson);
        }

        [HttpDelete("delete-lesson/{id}")]
        public IActionResult DeleteLesson(Guid id)
        {
            var isDeleteLesson = _lessonService.DeleteLesson(id);
            return Ok(isDeleteLesson);
        }

        [HttpPost("edit-lesson")]
        public IActionResult EditLesson([FromBody] EditLessonRequest request)
        {
            var editLesson = _lessonService.EditLesson(request);
            return Ok(editLesson);
        }
       
    }
}