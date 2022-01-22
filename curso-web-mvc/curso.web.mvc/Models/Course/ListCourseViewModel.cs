using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.Course
{
    public class ListCourseViewModel
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name="Descrição")]
        public string Description { get; set; }
    }
}
