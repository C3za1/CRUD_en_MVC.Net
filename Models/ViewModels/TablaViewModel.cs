using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_en_MVC_.Net.Models.ViewModels
{
    public class TablaViewModel
    {
        public int id { get; set; }
        [required]
        [StringLength(50)]
        [Display(Name = "nombre")]
        public string nombre { get; set; }
        [required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "correo electronico")]
        public string correo { get; set; }
        [required]
        [DataType(DataType.Date)]
        [Display(Name = "fecha nacimiento")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nacimiento { get; set; }
    }
}