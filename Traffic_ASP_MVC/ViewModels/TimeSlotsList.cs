using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class TimeSlotsList
    {
        public IEnumerable<TimeSlots>? TimeSlots { get; set; }

        public TimeSlots? TimeSlotName { get; set; }
    }
}
