using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LessonController : Controller
    {
        ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        public IActionResult Index()
        {
            return View(_lessonService.GetAll());
        }
    }
}
