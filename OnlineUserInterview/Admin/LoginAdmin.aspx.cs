using MySql.Data.MySqlClient;
using OnlineUserInterview.ServicesConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview.Admin
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        private static MySqlCommand command;
        private static MySqlDataAdapter dataAdapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Username"] != null && Session["NamaLengkap"] != null && Session["Password"] != null && Session["Access"] != null && Session["TimeoutSession"] != null)
                {
                    succecChkRemember.Checked = false;
                    inputEmail.Value = Session["Username"].ToString();
                    inputEmail.Value = Session["Password"].ToString();
                    ddlAccess.SelectedItem.Text = Session["Access"].ToString();

                    Response.Redirect("~/Admin/AdminContent.aspx");
                }
                else if (Request.Cookies["LoginAdmin"] != null)
                {
                    succecChkRemember.Checked = true;
                    inputEmail.Value = Request.Cookies["LoginAdmin"]["Username"].ToString();
                    inputEmail.Value = Request.Cookies["LoginAdmin"]["Password"].ToString();
                    ddlAccess.SelectedItem.Text = Request.Cookies["LoginAdmin"]["Access"].ToString();

                    Response.Redirect("~/Admin/AdminContent.aspx");
                }
            }
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string username, password, access;

            username = inputEmail.Value.Trim();
            password = inputPassword.Value.Trim();
            access = ddlAccess.SelectedItem.Text.Trim();

            if (username != "" && password != "" && ddlAccess.SelectedIndex != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "fromRegister", "buttonDisabled();", true);
                LoginValidation("spINFINET_GetLoginAdminInfinet");
            }
        }

        private void LoginValidation(string spName)
        {
            string username, fullName, password, access;

            username = inputEmail.Value.Trim();
            password = inputPassword.Value.Trim();
            access = ddlAccess.SelectedItem.Text.Trim();

            try
            {
                using(MySqlConnection conn = DatabaseService.Connection())
                {
                    command = new MySqlCommand();
                    command.Connection = conn;
                    command.CommandText = spName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 30;
                    command.Parameters.Add("p_Username", MySqlDbType.VarChar).Value = username;
                    command.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = password;
                    command.Parameters.Add("p_AccessUser", MySqlDbType.VarChar).Value = access;

                    DataTable dataTable = new DataTable();
                    dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dataTable);
                    //conn.Open();

                    if (dataTable.Rows.Count > 0)
                    {
                        fullName = dataTable.Rows[0]["FullName"].ToString();

                        if (succecChkRemember.Checked == true)
                        {
                            Response.Cookies["LoginAdmin"]["Username"] = username;
                            Response.Cookies["LoginAdmin"]["NamaLengkap"] = fullName;
                            Response.Cookies["LoginAdmin"]["Password"] = password;
                            Response.Cookies["LoginAdmin"]["Access"] = access;

                            Response.Cookies["LoginAdmin"].Expires = DateTime.Now.AddDays(7d);
                        }
                        else
                        {
                            Session["Username"] = username;
                            Session["NamaLengkap"] = fullName;
                            Session["Password"] = password;
                            Session["Access"] = access;
                            Session["TimeoutSession"] = DateTime.Now.AddHours(6).ToString();
                        }

                        conn.Close();
                        Response.Redirect("~/Admin/AdminContent.aspx");
                    }
                    else
                    {
                        System.Text.StringBuilder stringBuilder = PageUtility.MessageBox("Warning!", "Login Failed.\\n\\nPlease ReCheck your Username, Password or Access User.", "warning");
                        ClientScript.RegisterStartupScript(Page.GetType(), "alertMessageError", stringBuilder.ToString());
                    }
                }
            }
            catch (MySqlException myExcep)
            {
                System.Text.StringBuilder stringBuilder = PageUtility.MessageBox("Error", myExcep.Message, "error");
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessageError", stringBuilder.ToString());
            }
            catch (Exception Ex)
            {
                System.Text.StringBuilder stringBuilder = PageUtility.MessageBox("Error", Ex.Message, "error");
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessageError", stringBuilder.ToString());
            }
        }
    }
}