using MySql.Data.MySqlClient;
using OnlineUserInterview.ServicesConfig;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        private static MySqlCommand command;

        private string nama, noTlp, divisi, timeLeft;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "fromRegister", "buttonDisabled();", true);
                if (Session["UserInterview"] != null && Session["UserHP"] != null && Session["UserDivisi"] != null)
                {
                    Response.Redirect("~/UserQuestion.aspx");
                }
            }
        }

        protected void btnRegister_ServerClick(object sender, EventArgs e)
        {
            //nama = inputNama.Value;
            //noTlp = inputNoTlp.Value;
            //divisi = ddlDivisi.SelectedItem.ToString();
            //timeLeft = DateTime.Now.AddMinutes(2).ToString();

            //if (nama != "" && noTlp != "" && divisi != "" && timeLeft != "" && ddlDivisi.SelectedIndex != 0)
            //{
            //    Session["UserInterview"] = nama;
            //    Session["UserHp"] = noTlp;
            //    Session["UserDivisi"] = divisi;
            //    Session["TimeLeft"] = timeLeft;

            //    Response.Redirect("~/UserQuestion.aspx");
            //}
            //else
            //{
            //    PageUtility.GetNotificationInformationMessage(this, "Periksa Kembali", "There is an error, maybe the data is empty.");
            //}
            CreateUser();
        }

        private void CreateUser()
        {
            nama = inputNama.Value;
            noTlp = inputNoTlp.Value;
            divisi = ddlDivisi.SelectedItem.ToString();
            timeLeft = DateTime.Now.AddMinutes(2).ToString();

            if (nama.Length != 0 && noTlp.Length != 0 && divisi.Length != 0 && timeLeft.Length != 0)
            {
                try
                {
                    using (MySqlConnection myConn = DatabaseService.Connection())
                    {
                        long userID = 0;
                        command = new MySqlCommand();
                        command.Connection = myConn;
                        command.CommandText = "spINFINET_AddUserInterview";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 30;
                        command.Parameters.Add(DatabaseService.Parameters("p_FullName", nama.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_PhoneNumber", noTlp.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_Divisi", divisi.ToString()));
                        command.Parameters.Add("p_UserID", MySqlDbType.Int64).Direction = ParameterDirection.Output;

                        if (myConn.State == ConnectionState.Closed)
                        {
                            myConn.Open();
                        }

                        int result = command.ExecuteNonQuery();
                        userID = Convert.ToInt64(command.Parameters["p_UserID"].Value);
                        myConn.Close();

                        if (result >= 0)
                        {
                            Session["UserInterview"] = nama;
                            Session["UserHp"] = noTlp;
                            Session["UserDivisi"] = divisi;
                            Session["TimeLeft"] = timeLeft;
                            Session["UserID"] = userID;

                            Response.Redirect("~/UserQuestion.aspx");
                        }
                    }
                }
                catch (MySqlException myException)
                {
                    if (!Page.IsCallback || !Page.IsPostBack)
                    {
                        InformationMessage(this, "Error Occured", myException.Message);
                    }
                }
                catch (ArgumentException argumentException)
                {
                    if (!Page.IsCallback || !Page.IsPostBack)
                    {
                        InformationMessage(this, "Error Occured", argumentException.Message);
                    }
                }
            }
            else
            {
                InformationMessage(this, "Periksa Kembali", "There is an error, maybe the data is empty.");
                //PageUtility.GetNotificationInformationMessage(this.GetType(), "Periksa Kembali", "There is an error, maybe the data is empty.");
            }
        }

        private void InformationMessage(Page page, string title, string message)
        {
            //swal("Here's the title!", "...and here's the text!");
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("<script type = 'text/javascript'>");
            stringBuilder.Append("swal('");
            stringBuilder.Append(title);
            stringBuilder.Append("',");
            stringBuilder.Append("'" + message + "');");
            stringBuilder.Append("</script>");

            ClientScript.RegisterClientScriptBlock(page.GetType(), "alertMessage", stringBuilder.ToString());
        }
    }
}