using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADACE_Norte_Centro.Consola.Models
{
    public class Expediente
    {
        public string idExpediente { get; set; }
        public string NumeroOrden { get; set; }
        public string TipoRevision { get; set; }
        public string idContribuyente { get; set; }
        public DateTime FechadeApertura { get; set; }
        public DateTime FechadeCierre { get; set; }

        public Expediente()
        {
        }
    }
}
