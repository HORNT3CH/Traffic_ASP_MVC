using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class CarriersList
    {
        public IEnumerable<Carriers>? Carriers { get; set; }

        public Carriers? CarrierName { get; set; }
    }
}
