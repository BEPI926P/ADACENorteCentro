using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Models
{
    public class _501
    {
        public string FileName { get; set; }
        public string Patente { get; set; }
        public string Pedimento { get; set; }
        public string SeccionAduanera { get; set; }
        public string TipoOperacion { get; set; }
        public string ClaveDocumento { get; set; }
        public string SeccionAduaneraEntrada { get; set; }
        public string CurpContribuyente { get; set; }
        public string Rfc { get; set; }
        public string CurpAgenteA { get; set; }
        public string TipoCambio { get; set; }
        public string TotalFletes { get; set; }
        public string TotalSeguros { get; set; }
        public string TotalEmbalajes { get; set; }
        public string TotalIncrementables { get; set; }
        public string TotalDeducibles { get; set; }
        public string PesoBrutoMercancia { get; set; }
        public string MedioTransporteSalida { get; set; }
        public string MedioTransporteArribo { get; set; }
        public string MedioTransporteEntrada_Salida { get; set; }
        public string DestinoMercancia { get; set; }
        public string NombreContribuyente { get; set; }
        public string CalleContribuyente { get; set; }
        public string NumInteriorContribuyente { get; set; }
        public string NumExteriorContribuyente { get; set; }
        public string CPContribuyente { get; set; }
        public string MunicipioContribuyente { get; set; }
        public string EntidadFedContribuyente { get; set; }
        public string PaisContribuyente { get; set; }
        public string TipoPedimento { get; set; }
        public string FechaRecepcionPedimento { get; set; }
        public string FechaPagoReal { get; set; }

        public _501() { }

        public override string ToString()
        {
            return Patente + "," + Pedimento + "," + SeccionAduanera + "," + TipoOperacion + "," + ClaveDocumento + "," + SeccionAduaneraEntrada + "," + CurpContribuyente + "," + Rfc + "," + CurpAgenteA + "," + TipoCambio + "," + TotalFletes + "," + TotalSeguros + "," + TotalEmbalajes + "," + TotalIncrementables + "," + TotalDeducibles + "," + PesoBrutoMercancia + "," + MedioTransporteSalida + "," + MedioTransporteArribo + "," + MedioTransporteEntrada_Salida + "," + DestinoMercancia + "," + NombreContribuyente + "," + CalleContribuyente + "," + NumInteriorContribuyente + "," + NumExteriorContribuyente + "," + CPContribuyente + "," + MunicipioContribuyente + "," + EntidadFedContribuyente + "," + PaisContribuyente + "," + TipoPedimento + "," + FechaRecepcionPedimento + "," + FechaPagoReal;
        }
    }
}
