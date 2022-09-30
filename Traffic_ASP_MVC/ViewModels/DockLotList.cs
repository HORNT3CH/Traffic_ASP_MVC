using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class DockLotList
    {
        public IEnumerable<DockLot>? DockLot { get; set; }

        public string? TrailerNbr { get; set; } 
    }
}
