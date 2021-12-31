using System.Web;
using System.Web.Mvc;

namespace JEMJ_API_WEB_Natural_Age
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
