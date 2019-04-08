<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="OnlineUserInterview.Admin.LoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Admin Login</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../Content/themes/base/jquery-ui.min.css" rel="stylesheet" />
    <style>
        footer {
            background-color: #929292;
            position: fixed;
            bottom: 0px;
            left: 0;
            right: 0;
            height: 35px;
            text-align: center;
            color: #CCC;
        }

            footer p {
                color: #FFFFFF;
                padding: 10.5px;
                margin: 0px;
                line-height: 100%;
            }

        .form-group input[type="checkbox"] {
            display: none;
        }

            .form-group input[type="checkbox"] + .btn-group > label span {
                width: 20px;
            }

                .form-group input[type="checkbox"] + .btn-group > label span:first-child {
                    display: none;
                }

                .form-group input[type="checkbox"] + .btn-group > label span:last-child {
                    display: inline-block;
                }

            .form-group input[type="checkbox"]:checked + .btn-group > label span:first-child {
                display: inline-block;
            }

            .form-group input[type="checkbox"]:checked + .btn-group > label span:last-child {
                display: none;
            }
    </style>

    <%-- Sweet Alert Js --%>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManagerAdmin" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Scripts/jquery-3.3.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/popper.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
                <asp:ScriptReference Path="~/Scripts/jquery-ui-1.12.1.min.js" />
            </Scripts>
        </asp:ScriptManager>
        <div class="container">
            <div class="row justify-content-center">
                <div class="col col-auto">
                    <asp:Image CssClass="img-fluid" ID="imgLogo" runat="server" ImageUrl="~/Image/InfinetworksLogoPSDw900h90.png" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                    <div class="card card-signin my-5">
                        <div class="card-body">
                            <h5 class="card-title text-center">User Sign In</h5>
                            <div class="form-signin" id="fromSignIn">
                                <div class="form-label-group">
                                    <label for="inputEmail">Username</label>
                                    <input type="text" id="inputEmail" runat="server" class="form-control" placeholder="Your Username" required autofocus>
                                </div>

                                <div class="form-label-group">
                                    <label for="inputPassword">Password</label>
                                    <input type="password" id="inputPassword" runat="server" class="form-control" placeholder="Your Password" required>
                                </div>

                                <div class="form-label-group">
                                    <label for="ddlAccess">Access User</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlAccess" runat="server">
                                        <asp:ListItem Selected="True">-- Pilih Untuk Access User --</asp:ListItem>
                                        <asp:ListItem>Admin</asp:ListItem>
                                        <asp:ListItem>User</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <div class="[ form-group ]">
                                    <input type="checkbox" name="succecChkRemember" id="succecChkRemember" runat="server" />
                                    <div class="[ btn-group ]">
                                        <label for="succecChkRemember" class="[ btn btn-success ]">
                                            <span class="[ ui-icon ui-icon-check ]"></span>
                                            <span></span>
                                        </label>
                                        <label for="succecChkRemember" class="[ btn btn-secondary active ]">
                                            Remember Me
                                        </label>
                                    </div>
                                </div>
                                <hr class="my-4">
                                <button id="btnLogin" onserverclick="btnLogin_ServerClick" runat="server" class="btn btn-lg btn-primary btn-block text-uppercase" type="submit">Sign In</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function buttonDisabled() {
            $('#<%= btnLogin.ClientID %>').click(function () {
                $(this).val('Please Wait...');
                $(this).attr('disabled', true);
                setTimeout(function () {
                    $(this).attr('disabled', false);
                    $(this).val('Sign In');
                }, 2000);
            });
        }
    </script>
</body>
</html>

