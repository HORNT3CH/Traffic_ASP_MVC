using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class CoordinatorList
    {
        public IEnumerable<Coordinators>? Coordinators { get; set; }

        public Coordinators? CoordinatorName { get; set; }
    }
}
