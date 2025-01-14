﻿using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.User
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Login Obrigatória")]
        [StringLength(10), MinLength(3, ErrorMessage = "Login menor que 3 dígitos")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha Obrigatória")]
        [StringLength(10),  MinLength(6, ErrorMessage = "Senha menor que 3 dígitos")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
