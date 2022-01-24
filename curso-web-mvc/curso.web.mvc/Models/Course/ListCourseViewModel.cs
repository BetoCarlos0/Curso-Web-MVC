using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.Course
{
    public class ListCourseViewModel
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name="Descrição")]
        public string Descricao { get; set; }
    }
}
