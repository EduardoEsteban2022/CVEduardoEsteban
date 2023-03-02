using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyectoModelo.Models
{
    public class ClienteModelo
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Los Nombres son requeridos.")]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Los Apellidos son requeridos.")]
        public string apellidos { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "La Fecha de nacimiento es requerido.")]
        public DateTime fecha { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public string fechaString { get; set; }

        [Display(Name = "Sueldo")]
        [Required(ErrorMessage = "El Sueldo es requerido.")]
        public decimal sueldo { get; set; }


    }
}