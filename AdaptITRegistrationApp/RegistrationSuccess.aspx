<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationSuccess.aspx.cs" Inherits="AdaptITRegistrationApp.RegistrationSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/boilerplate.css">
	<link rel="stylesheet" href="css/registered_online.css">
	<meta charset="utf-8">
	<meta name="viewport" content="initial-scale = 1.0,maximum-scale = 1.0">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="primaryContainer" class="primaryContainer clearfix">
           <img id="image" src="images/adaptitBanner_Feb2020_2.jpg" class="image" />
        <p id="text">
         <asp:Label ID="lblPresentationHeading" runat="server" Text="" />
        </p>
        <%--<p id="text1">
            for the 6 months<br />
                ended June 2017
        </p>--%>
        <div id="box" class="clearfix">
            <p id="text2">
                <asp:Label ID="lblFormHeading" runat="server" Text="" />
            </p>
        </div>
        <div id="box1" class="clearfix">
            <asp:Label ID="lblInfo" runat="server" Text="" />
            
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back to List" />
            
        </div>
        <div id="box2" class="clearfix">
            <p id="text4">
            <a href="https://www.adaptit.com" target="_blank">www.adaptit.com</a>
            </p>
        </div>
    </div>
    </div>
    </form>
</body>
</html>