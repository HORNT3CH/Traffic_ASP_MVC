using System.ComponentModel.DataAnnotations;

namespace Traffic_ASP_MVC.Models
{
    public class DockLot
    {
        public int ID { get; set; }

        public string? Location { get; set; }

        public string? CarrierName { get; set; }

        public string? Status { get; set; }

        public string? TrailerNbr { get; set; }

        public string? Dimension { get; set; }

        public string? Comments { get; set; }

        public string? LoadNbr { get; set; }

        public string? MbolNbr { get; set; }

        public DateTime TimeStamp { get; set; }

    }

}
