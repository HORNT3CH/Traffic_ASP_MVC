using System.ComponentModel.DataAnnotations;

namespace Traffic_ASP_MVC.Models
{
    public class Schedule
    {
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ScheduleDate { get; set; }

        public string? TimeSlot { get; set; }

        public string? Status { get; set; }

        public string? Type { get; set; }

        public int NumberCartons { get; set; }

        public int LoadCube { get; set; }

        public string? MbolNbr { get; set; }

        public string? LoadNbr { get; set; }

        public string? LoaderName { get; set; }

        public string? CarrierName { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerCity { get; set; }

        public string? CustomerState { get; set; }

        public string? LoadComments { get; set; }

        public string? LoadScheduler { get; set; }

        public string? Location { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? FinishTime { get; set; }

        public string? TrailerNbr { get; set; }

        public string? StageLocation { get; set; }
    }
}
