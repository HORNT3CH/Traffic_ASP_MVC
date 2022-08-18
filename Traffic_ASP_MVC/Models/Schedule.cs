using System.ComponentModel.DataAnnotations;

namespace Traffic_ASP_MVC.Models
{
    public class Schedule
    {
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime scheduleDate { get; set; }

        public string timeSlot { get; set; }

        public int status { get; set; }

        public string type { get; set; }

        public int numberCartons { get; set; }

        public int loadCube { get; set; }

        public string mbolNbr { get; set; }

        public string loadNbr { get; set; }

        public string? loaderName { get; set; }

        public string carrierName { get; set; }

        public string customerName { get; set; }

        public string customerCity { get; set; }

        public string customerState { get; set; }

        public string loadComments { get; set; }

        public string loadScheduler { get; set; }
    }
}
