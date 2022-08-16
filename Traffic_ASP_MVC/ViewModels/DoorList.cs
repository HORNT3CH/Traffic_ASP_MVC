using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class DoorList
    {
        public IEnumerable<Doors> Doors { get; set; }
        public Doors location { get; set; }
    }
}
