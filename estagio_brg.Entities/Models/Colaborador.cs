using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace estagio_brg.Entities.Models
{
    public class Colaborador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdColaborador { get; set; }

        [Required(ErrorMessage = "Cargo é obrigatório")]
        [StringLength(50, ErrorMessage = "Cargo não pode ser maior do que 50 caracteres!")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Departamento é obrigatório")]
        [StringLength(50, ErrorMessage = "Departamento não pode ser maior do que 50 caracteres!")]
        public string Departamento { get; set; }
    }
}
