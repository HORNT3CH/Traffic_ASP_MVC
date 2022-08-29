using Traffic_ASP_MVC.Models;

namespace Traffic_ASP_MVC.ViewModels
{
    public class CitiesList
    {
        public IEnumerable<Cities>? Cities { get; set; }

        public Cities? CityName { get; set; }
    }
}
