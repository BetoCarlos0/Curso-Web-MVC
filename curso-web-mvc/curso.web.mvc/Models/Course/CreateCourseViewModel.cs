using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.Course
{
    public class CreateCourseViewModel
    {
        [Required]
        [StringLength(10), MinLength(3, ErrorMessage = "Login menor que 3 dígitos")]
        [Display(Name="Nome")]
        public string Name { get; set; }

        [StringLength(50), MinLength(3, ErrorMessage = "Descrição menor que 3 dígitos")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
