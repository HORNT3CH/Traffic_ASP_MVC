using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class DockLotList
    {
        public IEnumerable<DockLot>? DockLots { get; set; }

        public DockLot? TrailerNbr { get; set; }
    }
}
