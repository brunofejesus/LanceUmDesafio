using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LanceUmDesafio.Models
{
    [MetadataType(typeof(DesafioMetadados))]
    public partial class Desafio
    {
    }

    public class DesafioMetadados
    {
        [Required(ErrorMessage ="Este Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "*O {0} deve ter pelo menos {2} caracteres", MinimumLength = 6)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Conteudo { get; set; }
    }
}