using curso.web.mvc.Models.Course;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace curso.web.mvc.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var course = new List<ListCourseViewModel>
            {
                new ListCourseViewModel()
                {
                    Name = "Curso A",
                    Description = "Curso de coisas A",
                },

                new ListCourseViewModel()
                {
                    Name = "Curso B",
                    Description = "Curso de outras coisas de B",
                },
            };

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCourseViewModel createCourseViewModel)
        {
            return View();
        }
    }
}
