using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace correspondencia.Entities
{
    public class SP_CONSULTA
    {
        [Key]
        public int CorreoLocalID { get; set; }
        public string Oficio { get; set; }
        public string Expediente { get; set; }
        public string TipoPaqueteDesc { get; set; }
        public int NumeroPaquete { get; set; }
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaNotificacion { get; set; }

    }
}
