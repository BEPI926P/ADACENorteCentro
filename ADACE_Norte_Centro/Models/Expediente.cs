using System;

namespace ADACE_Norte_Centro.Models
{
    public class Expediente
    {
        public string idExpediente { get; set; } //test
        public string  NumeroOrden { get; set;}
        public string TipoRevision {get; set;} 
        public string idContribuyente {get; set;}
        public DateTime  FechadeApertura {get; set;}
        public DateTime FechadeCierre { get; set; }

        public Expediente()
        {
        }
    }
}
