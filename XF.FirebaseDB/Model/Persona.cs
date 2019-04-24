using System;
using System.Collections.Generic;
using System.Text;

namespace XF.FirebaseDB.Model
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaModifica { get; set; }
        public bool Estado { get; set; }
    }
}
