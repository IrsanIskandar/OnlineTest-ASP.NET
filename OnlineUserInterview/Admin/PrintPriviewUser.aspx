<%@ Page Title="Report Interviewer" Async="true" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="PrintPriviewUser.aspx.cs" Inherits="OnlineUserInterview.Admin.PrintPriviewUser" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content3" ContentPlaceHolderID="PrintViewer" runat="server">
    <div class="container">
        <div class="row">
            <div class="col col-md-12 col-sm-12">
                <div class="row justify-content-center">
                    <asp:LinkButton ID="ExportToWord" runat="server" CssClass="btn btn-lg btn-primary" OnClick="ExportToWord_Click">
                    Export To Word Document <i class="fa fa-book"></i>
                    </asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="ExportToExcel" runat="server" CssClass="btn btn-lg btn-success" OnClick="ExportToExcel_Click">
                    Export To Excel <i class="fa fa-exchange"></i>
                    </asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="ExportToPdf" runat="server" CssClass="btn btn-lg btn-danger" OnClick="ExportToPdf_Click">
                    Export To Pdf <i class="fa fa-book"></i>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col col-md-12 col-sm-12">
                <div class="row justify-content-center">
                    <input id="answerID" runat="server" type="hidden" />
                    <CR:CrystalReportViewer ID="ReportViewerUser" runat="server" CssClass="embed-responsive jumbotron-fluid" AutoDataBind="true"
                        ReuseParameterValuesOnRefresh="True" ToolPanelView="None" PrintMode="ActiveX" ViewStateMode="Enabled" HasCrystalLogo="False"
                        HasDrillUpButton="False" HasExportButton="False" HasPrintButton="False" HasSearchButton="False" HasZoomFactorList="False" HasGotoPageButton="False" HasPageNavigationButtons="False" />
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
