using curso.web.mvc.Models.Course;
using curso.web.mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace curso.web.mvc.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;

        public CourseController(ICourseServices iCourseServices)
        {
            _courseServices = iCourseServices;
        }
        public async Task<IActionResult> Index()
        {
            var course = await _courseServices.List();

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseViewModel createCourseViewModel)
        {
            try
            {
                var course = await _courseServices.Register(createCourseViewModel);

                ModelState.AddModelError("", "Curso criado com sucesso!");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
    }
}
