using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview.Admin
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Username"] != null && Session["NamaLengkap"] != null && Session["Password"] != null && Session["Access"] != null && Session["TimeoutSession"] != null)
                {
                    if (Session["Access"].Equals("Admin"))
                    {
                        navbarDropdown.InnerText = Session["NamaLengkap"].ToString();
                    }
                    else if (Session["Access"].Equals("User"))
                    {
                        navbarDropdown.InnerText = Session["NamaLengkap"].ToString();
                        lnkDataUser.Visible = false;
                    }
                }
                else if (Request.Cookies["LoginAdmin"] != null)
                {
                    if (Request.Cookies["LoginAdmin"]["Access"].Equals("Admin"))
                    {
                        navbarDropdown.InnerText = Request.Cookies["LoginAdmin"]["NamaLengkap"].ToString();
                    }
                    else if (Request.Cookies["LoginAdmin"]["Access"].Equals("User"))
                    {
                        navbarDropdown.InnerText = Request.Cookies["LoginAdmin"]["NamaLengkap"].ToString();
                        lnkDataUser.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("~/Admin/LoginAdmin.aspx");
                }
            }
        }

        protected void linkSignout_ServerClick(object sender, EventArgs e)
        {
            string[] allCookiesKey = Request.Cookies.AllKeys;

            if (Session["Username"] != null && Session["NamaLengkap"] != null && Session["Password"] != null && Session["Access"] != null && Session["TimeoutSession"] != null)
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                Response.AddHeader("pragma", "no-cache");
                Response.AddHeader("cache-control", "private");
                Response.CacheControl = "no-cache";
            }
            else if(Response.Cookies["LoginAdmin"] != null)
            {
                foreach (string item in allCookiesKey)
                {
                    Response.Cookies[item].Expires = DateTime.Now.AddDays(-7);
                }
            }

            Response.Redirect("LoginAdmin.aspx", true);           
        }
    }
}