using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using OnlineUserInterview.ServicesConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview.Admin
{
    public partial class PrintPriviewUser : System.Web.UI.Page
    {
        private static MySqlCommand mySqlCommand;
        private static MySqlDataAdapter dataAdapter;

        private static ReportDocument document;
        private static readonly TableLogOnInfos tableLogOnInfos = new TableLogOnInfos();
        private static readonly ConnectionInfo connectionInfo = new ConnectionInfo();
        private static string IDAnswer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Username"] != null && Session["NamaLengkap"] != null && Session["Password"] != null && Session["Access"] != null)
                {
                    if (Session["ThrowAdnswerID"] != null)
                    {
                        IDAnswer = Session["ThrowAdnswerID"].ToString();
                        answerID.Value = IDAnswer.ToString();

                        if (IDAnswer == Session["ThrowAdnswerID"].ToString())
                        {
                            LoadReportDocument(Convert.ToInt64(answerID.Value));
                        }
                    }
                    else
                    {
                        answerID.Value = "0";
                    }
                }
                else if (Request.Cookies["LoginAdmin"] != null)
                {
                    if (Session["ThrowAdnswerID"] != null)
                    {
                        IDAnswer = Session["ThrowAdnswerID"].ToString();
                        answerID.Value = IDAnswer.ToString();

                        LoadReportDocument(Convert.ToInt64(answerID.Value));
                    }
                    else
                    {
                        answerID.Value = "0";
                    }
                }
                else
                {
                    Response.Redirect("~/Admin/LoginAdmin.aspx");
                }
            }
        }

        protected void ExportToWord_Click(object sender, EventArgs e)
        {
            try
            {
                document.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "PersonAnswerDetails");
            }
            catch (Exception Ex)
            {
                System.Text.StringBuilder stringBuilder = PageUtility.MessageBox("Error", Ex.Message, "error");
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessageError", stringBuilder.ToString());
            }
        }

        protected void ExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                document.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, true, "PersonAnswerDetails");
            }
            catch (Exception Ex)
            {
                System.Text.StringBuilder stringBuilder = PageUtility.MessageBox("Error", Ex.Message, "error");
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessageError", stringBuilder.ToString());
            }
        }

        protected void ExportToPdf_Click(object sender, EventArgs e)
        {
            try
            {
                document.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "PersonAnswerDetails");
            }
            catch (Exception Ex)
            {
                System.Text.StringBuilder stringBuilder = PageUtility.MessageBox("Error", Ex.Message, "error");
                ClientScript.RegisterStartupScript(Page.GetType(), "alertMessageError", stringBuilder.ToString());
            }
        }

        private async Task GetDatAnswerAsync(long getAnswerID)
        {
            document = new ReportDocument();
            document.Load(Server.MapPath("../Admin/Report/ReportUser.rpt"));
            document.SetParameterValue("p_NoUrut", getAnswerID);
            document.SetDataSource(await GetInteviewerDetailAsync(getAnswerID));
            ReportViewerUser.ReportSource = document;
            ReportViewerUser.DataBind();
        }

        private async Task<List<ServicesConfig.ResponseData.GetAnswerInterview>> GetInteviewerDetailAsync(long answerID)
        {
            List<ServicesConfig.ResponseData.GetAnswerInterview> answerList = new List<ServicesConfig.ResponseData.GetAnswerInterview>();
            try
            {
                using (MySqlConnection conn = ServicesConfig.DatabaseService.Connection())
                {
                    ServicesConfig.ResponseData.GetAnswerInterview getAnswerInterview;

                    mySqlCommand = new MySqlCommand();
                    mySqlCommand.Connection = conn;
                    mySqlCommand.CommandText = "spINFINET_GetAnswersUser";
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    mySqlCommand.CommandTimeout = 30;
                    mySqlCommand.Parameters.Add("p_AnswersID", MySqlDbType.Int64).Value = answerID.ToString();

                    var mySqlDataReader = (MySqlDataReader)await mySqlCommand.ExecuteReaderAsync();

                    while (await mySqlDataReader.ReadAsync())
                    {
                        getAnswerInterview = new ServicesConfig.ResponseData.GetAnswerInterview();

                        if (mySqlDataReader["NamaLengkap"] != DBNull.Value)
                        {
                            getAnswerInterview.NamaLengkap = mySqlDataReader["NamaLengkap"].ToString();
                        }
                        if (mySqlDataReader["NomorTelepon"] != DBNull.Value)
                        {
                            getAnswerInterview.NomorTelepon = mySqlDataReader["NomorTelepon"].ToString();
                        }
                        if (mySqlDataReader["Divisi"] != DBNull.Value)
                        {
                            getAnswerInterview.Divisi = mySqlDataReader["Divisi"].ToString();
                        }
                        if (mySqlDataReader["AnswersOne"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerOne = mySqlDataReader["AnswersOne"].ToString();
                        }
                        if (mySqlDataReader["AnswersTwo"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerTwo = mySqlDataReader["AnswersTwo"].ToString();
                        }
                        if (mySqlDataReader["AnswersThree"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerThree = mySqlDataReader["AnswersThree"].ToString();
                        }
                        if (mySqlDataReader["AnswersFourth"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerFourth = mySqlDataReader["AnswersFourth"].ToString();
                        }
                        if (mySqlDataReader["AnswersFive"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerFive = mySqlDataReader["AnswersFive"].ToString();
                        }
                        if (mySqlDataReader["AnswersSix"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerSix = mySqlDataReader["AnswersSix"].ToString();
                        }
                        if (mySqlDataReader["AnswersSeven"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerSeven = mySqlDataReader["AnswersSeven"].ToString();
                        }
                        if (mySqlDataReader["AnswersEight"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerEight = mySqlDataReader["AnswersEight"].ToString();
                        }
                        if (mySqlDataReader["AnswersNine"] != DBNull.Value)
                        {
                            getAnswerInterview.AnswerNine = mySqlDataReader["AnswersNine"].ToString();
                        }

                        answerList.Add(getAnswerInterview);
                    }
                }                
            }
            catch (MySqlException myEx)
            {
                Response.Write(myEx.Message);
            }
            catch (Exception Ex)
            {
                Response.Write(Ex.Message);
            }

            return answerList.ToList();
        }

        private void LoadReportDocument(long answerID)
        {
            try
            {
                ParameterFields paramfields = new ParameterFields(); //collection of parameters
                ParameterField paramfield = new ParameterField(); //your parameter
                ParameterDiscreteValue dsvalue = new ParameterDiscreteValue(); // holder of your the value for the parameter
                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                document = new ReportDocument();

                using (MySqlConnection conn = ServicesConfig.DatabaseService.Connection())
                {
                    mySqlCommand = new MySqlCommand();
                    mySqlCommand.Connection = conn;
                    mySqlCommand.CommandText = "spINFINET_GetAnswersUser";
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    mySqlCommand.CommandTimeout = 60;
                    mySqlCommand.Parameters.AddWithValue("p_AnswersID", answerID);

                    dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = mySqlCommand;
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "spINFINET_GetAnswersUser");

                    paramfield.Name = "p_NomorUrut";
                    dsvalue.Value = Convert.ToInt64(Session["ThrowAdnswerID"].ToString());
                    paramfield.CurrentValues.Add(dsvalue);
                    paramfield.HasCurrentValue = true;
                    paramfields.Add(paramfield);

                    document.Load(Server.MapPath("../Admin/Report/ReportViewerUser.rpt"));
                    document.SetDataSource(dataSet);
                    ReportViewerUser.ParameterFieldInfo.Add(paramfield);
                    ReportViewerUser.EnableParameterPrompt = false;
                    ReportViewerUser.EnableDatabaseLogonPrompt = false;

                    connectionInfo.ServerName = "127.0.0.1";
                    connectionInfo.DatabaseName = "opsonlinetest";
                    connectionInfo.UserID = "infinet";
                    connectionInfo.Password = "p4c0mn3t";
                    Tables tables = (Tables)document.Database.Tables;

                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
                    {
                        tableLogOnInfo = table.LogOnInfo;
                        tableLogOnInfo.ConnectionInfo = connectionInfo;
                        table.ApplyLogOnInfo(tableLogOnInfo);
                    }

                    ReportViewerUser.ReportSource = document;
                    ReportViewerUser.DataBind();
                    document.VerifyDatabase();
                    Session["ReportDocument"] = document;
                    document.Refresh();

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (MySqlException myEx)
            {
                System.Text.StringBuilder stringBuilder = PageUtility.MessageBox("Error", myEx.Message, "error");
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