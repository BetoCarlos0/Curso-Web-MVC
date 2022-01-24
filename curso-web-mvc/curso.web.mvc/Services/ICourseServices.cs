using curso.web.mvc.Models.Course;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace curso.web.mvc.Services
{
    public interface ICourseServices
    {
        [Post("/api/v1/cursos")]
        [Headers("Authorization: Bearer")]
        Task<CreateCourseViewModelOutput> Register(CreateCourseViewModel createCourseViewModel);

        [Get("/api/v1/cursos")]
        [Headers("Authorization: Bearer")]
        Task<List<ListCourseViewModel>> List();
    }
}
