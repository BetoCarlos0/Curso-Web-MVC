using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.Course
{
    public class CreateCourseViewModel
    {
        [Required(ErrorMessage ="Nome obrigatório")]
        //[StringLength(10), MinLength(3, ErrorMessage = "Login menor que 3 dígitos")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Nome não pode ser menor que 3 ou maior que 40 caracteres")]
        [Display(Name="Nome")]
        public string Name { get; set; }

        [StringLength(40, MinimumLength = 3, ErrorMessage = "Descrição não pode ser menor que 3 ou maior que 40 caracteres")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
