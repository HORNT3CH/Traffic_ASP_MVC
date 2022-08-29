using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class CustomersList
    {
        public IEnumerable<Customers>? Customers { get; set; }

        public Customers? CustomerName { get; set; }
    }
}
