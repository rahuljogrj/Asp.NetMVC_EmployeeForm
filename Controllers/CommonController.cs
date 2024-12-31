using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace WebApplication3.Controllers
{
    public class CommonController : Controller
    {

        public DateTime convertToDate(string dateStr)
        {
            string format = "dd/MM/yyyy"; // Format matching the input string
            CultureInfo provider = CultureInfo.InvariantCulture; // Use invariant culture for consistent parsing

            DateTime parsedDate = DateTime.ParseExact(dateStr, format, provider);
            return parsedDate;

        }


        public static string ConvertToUserDate(DateTime? strdate)
        {
            string ss = "";
            if (strdate != null)
            {
                ss = strdate.Value.ToString("dd/MM/yyyy");
            }
            return ss;
        }


        public SelectListItem GetSelect()
        {
            SelectListItem listitem = new SelectListItem();
            listitem.Text = "---Select---";
            listitem.Value = "";
            listitem.Selected = true;

            return listitem;
        }

    }
}
