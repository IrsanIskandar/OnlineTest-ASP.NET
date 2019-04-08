<%@ Page Title="User Interview Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="OnlineUserInterview.RegisterUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HomeRegister" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                <div class="card card-signin my-5">
                    <div class="card-body">
                        <h5 class="card-title text-center">User Register</h5>
                        <div class="form-signin" id="fromRegister">
                            <div class="form-label-group">
                                <label for="inputEmail">Full Name</label>
                                <input type="text" id="inputNama" runat="server" class="form-control" placeholder="User Interview" required autofocus>
                            </div>

                            <div class="form-label-group">
                                <label for="inputPassword">Phone Number</label>
                                <input type="text" id="inputNoTlp" onkeypress="javascript:return isNumber(event);" runat="server" class="form-control" placeholder="08121234xxxx" required>
                            </div>

                            <div class="form-label-group">
                                <label for="inputPassword">Choose Division</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlDivisi" runat="server">
                                    <asp:ListItem Selected="True">-- Pilih Untuk Divisi --</asp:ListItem>
                                    <asp:ListItem>Divisi IT Operations</asp:ListItem>
                                    <asp:ListItem>Divisi Quality Assurance</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <hr class="my-4">
                            <button id="btnRegister" onserverclick="btnRegister_ServerClick" runat="server" class="btn btn-lg btn-primary btn-block text-uppercase" type="submit">Start The Test</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function buttonDisabled() {
            $('.btn').click(function () {
                $(this).val('Please Wait...');
                $(this).attr('disabled', true);
                setTimeout(function () {
                    $(this).attr('disabled', false);
                    $(this).val('Start The Test');
                }, 2000);
            });
        }

        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
