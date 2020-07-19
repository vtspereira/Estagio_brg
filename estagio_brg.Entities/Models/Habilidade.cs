using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace estagio_brg.Entities.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Tipo
    {
        [EnumMember(Value = "HardSkill")]
        HardSkill,
        [EnumMember(Value = "SoftSkill")]
        SoftSkill
    }

    public class Habilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdHabilidade { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Nome não pode ser maior do que 50 caracteres!")]
        public string Nome { get; set; }

        [ValidEnumValue]
        public Tipo Tipo { get; set; }
    }
}
