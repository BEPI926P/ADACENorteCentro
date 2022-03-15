using System;

namespace ADACE_Norte_Centro.Consola.Models
{
    public class Contriubuyente { 

        public string idContribuyente { get; set; }
        public string NombredeContribuyente {get; set;}
        public string RFC { get; set; }
        public string GiroContribuyente { get; set; }
        public string DomicilioFiscal { get; set; }
        public string DomicilioParaOiryRecibirNotificaciones { get; set; }
        public Contriubuyente()
        {
        }
    }
}
