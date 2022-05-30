using System.Web;
using System.Web.Mvc;

namespace NguyenDucHuy_Bigschool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
