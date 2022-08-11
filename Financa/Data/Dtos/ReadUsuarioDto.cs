﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Financa.Data.Dtos
{
    public class ReadUsuarioDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        [StringLength(11)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [StringLength(25)]
        public string Email { get; set; }
        public DateTime HoraDaConsulta {get; set;}  
    }
}
