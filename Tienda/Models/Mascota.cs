using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda.Models
{
    public class Mascota
    {

        public String Nombre { get; set; }
        public String Raza { get; set; }
        public String Descripcion { get; set; }
        public String Edad { get; set; }
        public String Precio { get; set; }
        public List<Vacunas> vacuna;
        public String VacunasEX { get; set; }

        public String Nombrep { get; set; }
        public String Apellidop { get; set; }
        public String Direccionp { get; set; }
        public String Telefonop { get; set; }

     
    }
}