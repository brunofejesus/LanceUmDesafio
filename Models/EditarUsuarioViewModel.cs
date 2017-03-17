using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LanceUmDesafio.Models
{
    public class EditarUsuarioViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        public string Foto { get; set; }

        public static AspNetUsers preencherAspNetUsers(ref AspNetUsers user, EditarUsuarioViewModel usuario)
        {
            user.Nome = usuario.Nome;
            user.DataNascimento = usuario.DataNascimento;
            user.Sexo = usuario.Sexo;
            return user;
        }

        public static EditarUsuarioViewModel preencherEditarUsuarioViewModel(ref EditarUsuarioViewModel usuario, AspNetUsers user)
        {
            usuario.Id = user.Id;
            usuario.Nome = user.Nome;
            usuario.DataNascimento = user.DataNascimento;
            usuario.Sexo = user.Sexo;
            usuario.Foto = user.Foto;
            return usuario;
        }
    }
}