namespace Traffic_ASP_MVC.Models
{
    public class DockLot
    {
        public int ID { get; set; }

        public string location { get; set; }

        public string carrierName { get; set; }

        public string status { get; set; }

        public string trailerNbr { get; set; }

        public string dimension { get; set; }

        public string comments { get; set; }

        public string loadNbr { get; set; }

        public string mbolNbr { get; set; }

        public DateTime timeStamp { get; set; }
    }

}
