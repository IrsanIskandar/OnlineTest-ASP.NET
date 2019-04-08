using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview
{
    public partial class Congratulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInterview"] != null && Session["UserHP"] != null && Session["UserDivisi"] != null)
                {
                    Response.Redirect("~/UserQuestion.aspx");
                }

                MessageBox(this, "Conratulation", "You Successfully Completed It.", "success");
            }
        }

        private void MessageBox(Page page, string title, string message, string icons)
        {
            //swal("Here's the title!", "...and here's the text!");
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("<script type = 'text/javascript'>");
            stringBuilder.Append("swal({");
            stringBuilder.Append("title:'" + title + "',");
            stringBuilder.Append("text:'" + message + "',");
            stringBuilder.Append("icon:'" + icons + "',");
            stringBuilder.Append("});");
            stringBuilder.Append("</script>");

            ClientScript.RegisterClientScriptBlock(page.GetType(), "alertMessageSuccess", stringBuilder.ToString());
        }
    }
}