using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Models
{
    public class _509
    {
        public string Patente { get; set; }
        public string Pedimento { get; set; }
        public string SeccionAduanera { get; set; }
        public string ClaveContribucion { get; set; }
        public string TasaContribucion { get; set; }
        public string TipoTasa { get; set; }
        public string TipoPedimento { get; set; }
        public string FechaPagoReal { get; set; }
        public _509() { }
    }
}
