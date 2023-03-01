using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoClubALFA.Models
{
    public class Estatus
    {
        //public int Activo { get; set; }
        //public string ActivoDescripcion { get; set; }
        //public int Inactivo { get; set; }
        //public string InactivoDescripcion { get; set; }

        public bool Activo { get; set; }
        public string ActivoDescripcion { get; set; }
        public bool Inactivo { get; set; }
        public string InactivoDescripcion { get; set; }

        public bool StatusCliente { get; set; }
    }
}