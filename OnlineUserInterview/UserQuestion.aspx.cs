using MySql.Data.MySqlClient;
using OnlineUserInterview.ServicesConfig;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview
{
    public partial class UserQuestion : System.Web.UI.Page
    {
        private string v_answer1TD, v_answer2TD, v_answer3TD, v_answer4TD, v_answer1TGI, v_answer2TGI, v_answer3TGI, v_answer4TGI, v_answer5TGI, v_userID;
        private static MySqlCommand command;
#pragma warning disable CS0169 // The field 'UserQuestion.dataAdapter' is never used
        private static MySqlDataAdapter dataAdapter;
#pragma warning restore CS0169 // The field 'UserQuestion.dataAdapter' is never used

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInterview"] != null && Session["UserHP"] != null && Session["UserDivisi"] != null && Session["TimeLeft"] != null)
                {
                    lblNama.Text = "Full Name : " + Session["UserInterview"].ToString();
                    lblNoTlp.Text = "Phone Number : " + Session["UserHP"].ToString();
                    lblDivisi.Text = "Division : " + Session["UserDivisi"].ToString();
                    hidUserID.Value = Session["UserID"].ToString();

                    //Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                    //SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                    //int timeoutMinutes = (int)section.Timeout.TotalMinutes * 1000 * 60;
                    int totalMinutes = (int)DateTime.Parse(Session["TimeLeft"].ToString()).Subtract(DateTime.Now).TotalMinutes * 1000 * 60;

                    ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + totalMinutes + ");", true);
                    MessageBox(this, "Welcome", "Successful registration.", "success");
                }
                else
                {
                    Response.Redirect("~/RegisterUser.aspx");
                }
            }
        }

        protected void btnSimpanTop_ServerClick(object sender, EventArgs e)
        {
            SaveAnswerQuestion();
        }

        protected void btnSimpanBottom_ServerClick(object sender, EventArgs e)
        {
            SaveAnswerQuestion();
        }

        private void SaveAnswerQuestion()
        {
            v_answer1TD = Answer1TD.Value.ToString();
            v_answer2TD = Answer2TD.Value.ToString();
            v_answer3TD = Answer3TD.Value.ToString();
            v_answer4TD = Answer4TD.Value.ToString();

            v_answer1TGI = Answer1TGI.Value.ToString();
            v_answer2TGI = Answer2TGI.Value.ToString();
            v_answer3TGI = Answer3TGI.Value.ToString();
            v_answer4TGI = Answer4TGI.Value.ToString();
            v_answer5TGI = Answer5TGI.Value.ToString();

            v_userID = hidUserID.Value.ToString();

            try
            {
                if (v_answer1TD.Length != 0 && v_answer2TD.Length != 0 && v_answer3TD.Length != 0 && v_answer4TD.Length != 0 && v_answer1TGI.Length != 0 && v_answer2TGI.Length != 0 && v_answer3TGI.Length != 0 && v_answer4TGI.Length != 0 && v_answer5TGI.Length != 0)
                {
                    using (MySqlConnection conn = DatabaseService.Connection())
                    {
                        command = new MySqlCommand();
                        command.Connection = conn;
                        command.CommandText = "spINFINET_InsertUserAnsware";
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 30;
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersOne", v_answer1TD.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersTwo", v_answer2TD.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersThree", v_answer3TD.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersFourth", v_answer4TD.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersFive", v_answer1TGI.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersSix", v_answer2TGI.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersSeven", v_answer3TGI.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersEight", v_answer4TGI.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_AnswersNine", v_answer5TGI.ToString()));
                        command.Parameters.Add(DatabaseService.Parameters("p_UserInterviewID", v_userID.ToString()));

                        int result = command.ExecuteNonQuery();
                        conn.Close();

                        if (result >= 0)
                        {
                            Session.Clear();
                            Session.RemoveAll();
                            Session.Abandon();
                            Response.AddHeader("pragma", "no-cache");
                            Response.AddHeader("cache-control", "private");
                            Response.CacheControl = "no-cache";

                            Response.Redirect("~/Congratulation.aspx");
                        }
                    }
                }
                else
                {
                    MessageBox(this, "Warning.", "Data cannot be empty.", "warning");
                }
            }
            catch (MySqlException myException)
            {
                if (!Page.IsCallback || !Page.IsPostBack)
                {
                    MessageBox(this, "Error Occured", myException.Message, "warning");
                }
            }
            catch (ArgumentException argumentException)
            {
                if (!Page.IsCallback || !Page.IsPostBack)
                {
                    MessageBox(this, "Error Occured", argumentException.Message, "warning");
                }
            }
            
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public async Task SaveAnswerServiceAsync(ServicesConfig.RequestData.AddUserAnswer addAnswer)
        {
            await ServicesConfig.SqlHelper<object>.ExecuteDataAsync("spINFINET_InsertUserAnsware",
                new
                {
                    p_AnswersOne = addAnswer.AnswersOne.ToString(),
                    p_AnswersTwo = addAnswer.AnswersTwo.ToString(),
                    p_AnswersThree = addAnswer.AnswersThree.ToString(),
                    p_AnswersFourth = addAnswer.AnswersFourth.ToString(),
                    p_AnswersFive = addAnswer.AnswersFive.ToString(),
                    p_AnswersSix = addAnswer.AnswersSix.ToString(),
                    p_AnswersSeven = addAnswer.AnswersSeven.ToString(),
                    p_AnswersEight = addAnswer.AnswersEight.ToString(),
                    p_AnswersNine = addAnswer.AnswersNine.ToString(),
                    p_UserInterviewID = addAnswer.Usr_InterviewID.ToString()
                });

            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.AddHeader("pragma", "no-cache");
            Response.AddHeader("cache-control", "private");
            Response.CacheControl = "no-cache";
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