using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.DTOs
{
    public class Reservas
    {
        public int ID_RESERVA { get; set; }
        public DateTime HORA_RESERVA { get; set; }
        public string NOME_RESERVA { get; set; }
        
        [ForeignKey("Mesas")]
        public int ID_MESA { get; set; }        
        public int QTD_PESSOAS { get; set; }

        public Reservas()
        {
            NOME_RESERVA = "";
            HORA_RESERVA = DateTime.Now;
            Mesas = new Mesas();
        }

        public Mesas Mesas { get; set; }
    }


}
