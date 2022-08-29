using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class StatesList
    {
        public IEnumerable<States>? States { get; set; }

        public States? StateName { get; set; }
    }
}
