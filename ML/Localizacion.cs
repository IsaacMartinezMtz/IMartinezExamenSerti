using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Localizacion
    {
        public int IdLocalizacion {  get; set; }
        public string Estante { get; set; }
        public string Sala { get; set; }
        public string Librero { get; set; }
        public string Posicion { get; set; }
        public string Localizaciones { get; set; }
        public ML.Libros Libros { get; set; }

    }
}
