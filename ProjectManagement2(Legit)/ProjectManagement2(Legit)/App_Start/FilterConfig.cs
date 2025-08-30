using System.Web;
using System.Web.Mvc;

namespace ProjectManagement2_Legit_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
