using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace estagio_brg.Entities.Models
{
    public class Trilha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdTrilha { get; set; }

        [Required(ErrorMessage = "Prazo é obrigatório")]
        public DateTime Prazo { get; set; }

        [ForeignKey(nameof(Colaborador))]
        public Guid IdColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        [ForeignKey(nameof(Habilidade))]
        public Guid Idhabilidade { get; set; }
        public Habilidade Habilidade { get; set; }

    }
}
