using System.Web;
using System.Web.Mvc;

namespace rocket_elevator_ui
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
