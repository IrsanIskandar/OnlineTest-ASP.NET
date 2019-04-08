<%@ Page Title="Admin Dashboard" Async="true" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="AdminContent.aspx.cs" Inherits="OnlineUserInterview.Admin.AdminContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="card-columns">
                <div class="card bg-primary">
                    <div class="card-body text-center">
                        <asp:Label ID="lblUsername" CssClass="text-white" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="card" style="border: none;">
                    <div class="card-body">
                        &nbsp;
                    </div>
                </div>
                <div class="card bg-primary">
                    <div class="card-body  text-center">
                        <asp:Label ID="lblUserAccess" CssClass="text-white" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col col-md-12 col-sm-12 bg-warning">
                <div class="form-inline" style="margin: 6px;">
                    <label for="inputName" id="lblName">Search Interviewer :&nbsp;</label>
                    <asp:dropdownlist ID="DrpDivisi" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpDivisi_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">-- Pilih Divisi --</asp:ListItem>
                        <asp:ListItem Value="1">Divisi IT Operations</asp:ListItem>
                        <asp:ListItem Value="2">Divisi Quality Assurance</asp:ListItem>
                    </asp:dropdownlist>&nbsp;
                    <asp:textbox runat="server" ID="TxtSearch" AutoPostBack="True" CssClass="form-control" OnTextChanged="TxtSearch_TextChanged"></asp:textbox>&nbsp;
                </div>
            </div>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="col  col-sm-12 col-md-12 col-lg-12">
                <asp:GridView AutoGenerateColumns="False" CssClass="table table-bordered table-responsive table-responsive-lg table-hover" ID="grdVWPersonInterview" runat="server" DataKeyNames="NomorUrut"
                    OnRowDataBound="grdVWPersonInterview_RowDataBound" OnPageIndexChanging="grdVWPersonInterview_PageIndexChanging" ShowFooter="true" AllowPaging="true" PageSize="10" RowStyle-CssClass="GvGrid" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkBtnPrint" CssClass="btn btn-primary" OnClick="linkBtnPrint_Click" runat="server">Pint User <i class="fa fa-print"></i></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nomor">
                            <ItemTemplate>
                                <asp:Label ID="lblNomor" runat="server" Text='<%# Eval("NomorUrut") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="120px" />
                            <ItemStyle Width="120px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nama Lengkap">
                            <ItemTemplate>
                                <asp:Label ID="lblNamaLengkap" runat="server" Text='<%# Eval("NamaLengkap") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="350px" HorizontalAlign="Center" CssClass="thead-dark" />
                            <ItemStyle Width="350px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer One">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer1" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerOne").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="550px" CssClass="thead-dark" HorizontalAlign="Center" />
                            <ItemStyle Width="550px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Two">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer2" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerTwo").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" Width="450px" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Three">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer3" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerThree").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="450px" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Fourh">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer4" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerFourth").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="450px" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Five">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer5" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerFive").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="450px" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Six">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer6" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerSix").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="450px" Wrap="True" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Seven">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer7" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerSeven").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="450px" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Eight">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer8" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerEight").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="450px" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer Nine">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer9" runat="server" Text='<%# OnlineUserInterview.ServicesConfig.PageUtility.LimitText(Eval("AnswerNine").ToString(), 100) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="thead-dark" HorizontalAlign="Center" Width="450px" />
                            <ItemStyle Width="450px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <h3 class="text-danger text-center h3">No Records Found.</h3>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#808080" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <PagerStyle CssClass="GridPager" HorizontalAlign="Right" />
                </asp:GridView>
                <br />
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="text-hide" id="timeuserleft" runat="server"></div>
        </div>
    </div>

    <%-- Modal Popup --%>
    <div class="modal fade" id="pop" tabindex="-1" runat="server" role="dialog" data-backdrop="static" aria-labelledby="titleHeader" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="titleHeader">Interviewer</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="form-horizontal">
                            <div class="box-body">
                                <div class="row justify-content-center">
                                    <div class="col-md-12">
                                        <div class="form-group bg-success text-center text-white">
                                            <label class="control-label">User Detail</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row justify-content-center">
                                    <div class="col col-md-6">
                                        <div class="form-group bg-primary text-center">
                                            <asp:Label ID="lblNamaUser" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col col-md-6">
                                        <div class="form-group bg-primary text-center">
                                            <asp:Label ID="lblNoHPUser" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row justify-content-center">
                                    <div class="col col-md-12">
                                        <div class="form-group bg-secondary text-center text-white">
                                            <asp:Label ID="lblDivisiUser" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                    <button type="button" id="btnPrintUser" runat="server" onserverclick="btnPrintUser_ServerClick" class="btn btn-success">Print <i class="fa fa-print"></i></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <script type="text/javascript">
        function SesssionUserExperied(timeout) {
            var second = timeout / 1000;
            var minutes = $('#timeuserleft').timeTo({
                seconds: second
            });

            document.getElementsByName('timeuserleft').innerHTML = minutes;

            setTimeout(function () {
                window.location = "LoginAdmin.aspx";
            }, timeout);
        };
    </script>

    <script type="text/javascript">
        function modalPrint() {
            $('[id*=pop]').modal('show');
        };
    </script>
</asp:Content>
