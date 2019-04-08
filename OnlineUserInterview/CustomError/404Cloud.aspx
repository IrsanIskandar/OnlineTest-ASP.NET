<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404Cloud.aspx.cs" Inherits="OnlineUserInterview.CustomError._404Cloud" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="csrf-param" content="authenticity_token">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/styleCloud.css" rel="stylesheet" />
    <title>404-Page Not Found</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="clouds">
            <div class="cloud x1"></div>
            <div class="cloud x1_5"></div>
            <div class="cloud x2"></div>
            <div class="cloud x3"></div>
            <div class="cloud x4"></div>
            <div class="cloud x5"></div>
        </div>
        <div class='c'>
            <div class='_404'>404</div>
            <hr>
            <div class='_1'>THE PAGE</div>
            <div class='_2'>WAS NOT FOUND</div>
            <a class='btn' href="../UserQuestion.aspx">BACK TO HOME</a>
        </div>
    </form>
</body>
</html>
