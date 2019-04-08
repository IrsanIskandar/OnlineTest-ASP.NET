using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview.ServicesConfig
{
    public class PageUtility : System.Web.UI.Page
    {
        public static StringBuilder InformationMessage(string title, string message)
        {
            //swal("Here's the title!", "...and here's the text!");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script type = 'text/javascript'>");
            stringBuilder.Append("swal('");
            stringBuilder.Append(title);
            stringBuilder.Append("',");
            stringBuilder.Append("'" + message + "');");
            stringBuilder.Append("</script>");

            return stringBuilder;
        }

        public static StringBuilder MessageBox(string title, string message, string icons)
        {
            //swal("Here's the title!", "...and here's the text!");
            StringBuilder textBuilder = new System.Text.StringBuilder();
            textBuilder.Append("<script type = 'text/javascript'>");
            textBuilder.Append("swal({");
            textBuilder.Append("title:'" + title + "',");
            textBuilder.Append("text:'" + message + "',");
            textBuilder.Append("icon:'" + icons + "',");
            textBuilder.Append("});");
            textBuilder.Append("</script>");

            return textBuilder;
        }

        public static string LimitText(string text, int maxLength)
        {
            if (text.Length <= maxLength)
            {
                return text;
            }

            return text.Substring(0, maxLength) + "....";
        }
    }
}