using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using OnlineUserInterview.ServicesConfig;
using OnlineUserInterview.ServicesConfig.ResponseData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineUserInterview.Admin
{
    public partial class AdminContent : System.Web.UI.Page
    {
#pragma warning disable CS0169 // The field 'AdminContent.mySqlCommand' is never used
        private static MySqlCommand mySqlCommand;
#pragma warning restore CS0169 // The field 'AdminContent.mySqlCommand' is never used

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Username"] != null && Session["NamaLengkap"] != null && Session["Password"] != null && Session["Access"] != null && Session["TimeoutSession"] != null)
                {
                    lblUsername.Text = Session["NamaLengkap"].ToString();
                    lblUserAccess.Text = Session["Access"].ToString();
                    TxtSearch.Enabled = false;

                    await PullDataAnswer();
                }
                else if (Request.Cookies["LoginAdmin"] != null)
                {
                    MessageBox(this, "Welcome", "Admin Infinetworks Sign In.", "success");

                    lblUsername.Text = Request.Cookies["LoginAdmin"]["NamaLengkap"];
                    lblUserAccess.Text = Request.Cookies["LoginAdmin"]["Access"];

                    await PullDataAnswer();
                }
                else
                {
                    Response.Redirect("~/Admin/LoginAdmin.aspx");
                }
            }
        }

        protected void grdVWPersonInterview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Jumlah " + grdVWPersonInterview.Rows.Count + " Interviewer";
            }
        }

        protected void linkBtnPrint_Click(object sender, EventArgs e)
        {
            long rowIndex = Convert.ToInt64(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
            GridViewRow gridRow = grdVWPersonInterview.Rows[Convert.ToInt32(rowIndex)];

            long throwIDAnswer = Convert.ToInt32((gridRow.FindControl("lblNomor") as Label).Text);
            if (throwIDAnswer != 0)
            {
                Session["ThrowAdnswerID"] = throwIDAnswer;
            }

            Response.Redirect("../Admin/PrintPriviewUser.aspx");
        }

        protected async void grdVWPersonInterview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVWPersonInterview.PageIndex = e.NewPageIndex;
            await PullDataAnswer();
        }

        protected void btnPrintUser_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("../Admin/PrintPriviewUser.aspx");
        }

        protected async void DrpDivisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            await PullDataInDropDown(DrpDivisi.SelectedItem.ToString());
        }

        protected async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            await PullDataInTextChanged(TxtSearch.Text.ToString());
        }

        private void GetAnswerUser()
        {
            DataSet dataSet = DatabaseService.GetDataSet("spINFINET_GetAllAnswerUser");
            grdVWPersonInterview.DataSource = dataSet;
            grdVWPersonInterview.DataBind();
            grdVWPersonInterview.SelectedIndex = 0;

        }

        private async Task<IEnumerable<GetAnswerInterview>> PullDataInDropDown(string divisi)
        {
            IEnumerable<GetAnswerInterview> result = await SqlHelper<GetAnswerInterview>.GetDataCollectionAsync("spINFINET_GetAnswerByDivisi",
                new
                {
                    p_Divisi = divisi.ToString()
                }) as List<GetAnswerInterview>;

            if (result.Count() != 0)
            {
                grdVWPersonInterview.DataSource = result;
                grdVWPersonInterview.DataBind();

                TxtSearch.Enabled = true;

                return result;
            }
            else
            {
                result = null;
                StringBuilder stringMessage = PageUtility.MessageBox("Error", "Data Not Found.", "error");
                ClientScript.RegisterStartupScript(Page.GetType(), "ErrorMassage", stringMessage.ToString());
                TxtSearch.Enabled = false;

                return result;
            }
        }

        private async Task<IEnumerable<GetAnswerInterview>> PullDataInTextChanged(string text)
        {
            IEnumerable<GetAnswerInterview> result = await SqlHelper<GetAnswerInterview>.GetDataCollectionAsync("spINFINET_GetAnswerByNama",
                new
                {
                    p_NamaLengkap = text.ToString()
                }) as List<GetAnswerInterview>;

            grdVWPersonInterview.DataSource = result;
            grdVWPersonInterview.DataBind();

            return result;
        }

        private async Task<IEnumerable<GetAnswerInterview>> PullDataAnswer()
        {
            IEnumerable<GetAnswerInterview> result = await SqlHelper<GetAnswerInterview>.GetDataCollectionAsync("spINFINET_GetAllAnswerUser") as List<GetAnswerInterview>;

            if (result != null)
            {
                grdVWPersonInterview.DataSource = result;
                grdVWPersonInterview.DataBind();

                return result;
            }
            else
            {
                result = null;

                return result;
            }
        }

        private async Task<IEnumerable<GetAnswerInterview>> GetDetailUser(long rowIndex)
        {
            IEnumerable<GetAnswerInterview> result = await SqlHelper<GetAnswerInterview>.GetDataCollectionAsync("spINFINET_GetAnswersUser",
                new
                {
                    p_AnswersID = rowIndex.ToString()
                }) as List<GetAnswerInterview>;

            foreach (var item in result)
            {
                lblNamaUser.Text = "Nama : " + item.NamaLengkap;
                lblNoHPUser.Text = "Nomor HP : " + item.NomorTelepon;
                lblDivisiUser.Text = "Divisi : " + item.Divisi;
            }


            return result;
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