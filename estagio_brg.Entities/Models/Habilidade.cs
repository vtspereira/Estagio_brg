using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace estagio_brg.Entities.Models
{
    public class Habilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdHabilidade { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Nome não pode ser maior do que 50 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório")]
        [StringLength(50, ErrorMessage = "Tipo não pode ser maior do que 50 caracteres!")]
        public string Tipo { get; set; }
    }
}
