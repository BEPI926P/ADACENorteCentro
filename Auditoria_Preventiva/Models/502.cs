using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Models
{
    public class _502
    {
        public string Patente { get; set; }
        public string Pedimento { get; set; }
        public string SeccionAduanera { get; set; }
        public string RfcTransportista { get; set; }
        public string CurpTransportista { get; set; }
        public string NombreTransportista { get; set; }
        public string PaisTransporte { get; set; }
        public string IdentificadorTransporte { get; set; }
        public string FechaPagoReal { get; set; }
        public _502() { }

        public override string ToString()
        {
            return Patente + "," + Pedimento + "," + SeccionAduanera + "," + RfcTransportista + "," + CurpTransportista + "," + NombreTransportista + "," + PaisTransporte + "," + IdentificadorTransporte + "," + FechaPagoReal;
        }
    }
}
