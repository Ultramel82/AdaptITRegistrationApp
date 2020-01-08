<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationError.aspx.cs" Inherits="AdaptITRegistrationApp.RegistrationError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/boilerplate.css">
	<link rel="stylesheet" href="css/registered_online.css">
<%--    <link rel="stylesheet" href="css/online.css">--%>
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
            <div id="box" class="clearfix">
                <p id="text2">
                    <asp:Label ID="lblFormHeading" runat="server" Text="" />
                </p>
            </div>
            <div id="box1" class="clearfix">
                <ASP:PANEL ID="pnlAlreadyRegistered" runat="server" Visible="false">
                    <p id="text3" style="color:rgb(83, 110, 136);">
                        <span id="textspan" style="color:rgb(83, 110, 136);"><b>This email address has already been registered</b></span>.<br /><br />Please contact us if you have not registered yet, or would like to make a change to your registration.<br />
                    </p>
                </ASP:PANEL>
                <ASP:PANEL ID="pnlAlreadyRegistered_EmailAsPassword" runat="server" Visible="false">
                    <p id="text3" style="color:rgb(83, 110, 136);">
                        <span id="textspan" style="color:rgb(83, 110, 136);"><b>This email address has already been registered.</b></span><br /><br />
                        To view the webcast, please <asp:HyperLink ID="hlRegistered_EmailAsPassword" runat="server" Font-Underline="true" Target="_blank">click here</asp:HyperLink> and enter the registered email address to continue.<br /><br/>
                    </p>
                </ASP:PANEL>
                <ASP:PANEL ID="pnlQueryString" runat="server" Visible="false">
                    <p id="text3">
                        <span id="textspan" style="color:rgb(83, 110, 136);">The registration link you are trying to access is incorrect. Please verify and try again.<br /><br/>
                    </p>
                </ASP:PANEL>
                <ASP:PANEL ID="pnlError" runat="server" Visible="false">
                    <p id="text3">
                        <span id="textspan" style="color:rgb(83, 110, 136);">
                            <asp:Label ID="lblErrorDescription" runat="server"></asp:Label>
                            &nbsp;Please try accessing the registration link again.<br /><br />
                        </span>
                    </p>
                </ASP:PANEL>
            </div>
            <div id="box2" class="clearfix">
            <p id="text4">
            <a href="https://www.adaptit.com" target="_blank">www.adaptit.com</a>
            </p>
        </div>
            <%--<p id="text1">
                for the 6 months<br />
                    ended June 2017
            </p>--%>
            
            <%--<ASP:PANEL ID="pnlAlreadyRegistered" runat="server" Visible="false">
                <p id="text3" style="color:rgb(83, 110, 136);">
                    <span id="textspan" style="color:rgb(83, 110, 136);"><b>This email address has already been registered</b></span>.<br />Please contact us if you have not registered yet, or would like to make a change to your registration.<br />
                </p>
            </ASP:PANEL>
            
                <ASP:PANEL ID="pnlAlreadyRegistered_EmailAsPassword" runat="server" Visible="false">
                    <p id="text3" style="color:rgb(83, 110, 136);">
                        <span id="textspan" style="color:rgb(83, 110, 136);"><b>This email address has already been registered.</b></span><br /><br />
                        To view the webcast, please <asp:HyperLink ID="hlRegistered_EmailAsPassword" runat="server" Font-Underline="true" Target="_blank">click here</asp:HyperLink> and enter the registered email address to continue.<br /><br/>
                    </p>
                </ASP:PANEL>
            
                <ASP:PANEL ID="pnlQueryString" runat="server" Visible="false">
                    <p id="text3">
                        <span id="textspan" style="color:rgb(83, 110, 136);">The registration link you are trying to access is incorrect. Please verify and try again.<br /><br/>
                    </p>
                </ASP:PANEL>
            
             <ASP:PANEL ID="pnlError" runat="server" Visible="false">
                <p id="text3">
                    <span id="textspan" style="color:rgb(83, 110, 136);">
                        <asp:Label ID="lblErrorDescription" runat="server"></asp:Label>
                        &nbsp;Please try accessing the registration link again.<br /><br />
                    </span>
                </p>
            </ASP:PANEL>
                </div>
            <span id="textspan2">
            <br /><br />
                <span style="color:rgb(83, 110, 136);">
                    For technical support queries or assistance, please contact <a href="mailto:info@corpcam.com" style="color:rgb(83, 110, 136)!important; text-decoration: underline;">CorpCam Support</a>.<br /><br />
                    </span>
                </span>--%>
        </div>
    </form>




    <%--<form id="form1" runat="server">
    <div>
        <div id="primaryContainer" class="primaryContainer clearfix">
        <img id="image" src="images/banner_100.png" class="image" />
        <%--<p id="text">
         <asp:Label ID="lblPresentationHeading" runat="server" Text="" />
        </p>--%>

       <%-- <div id="box" class="clearfix">
            <p id="text2">
            <asp:Label ID="lblFormHeading" runat="server" Text="" />
            </p>
        </div>--%>




<%--
        <div id="box1" class="clearfix">
            <ASP:PANEL ID="pnlAlreadyRegistered" runat="server" Visible="false">
                <p id="text3" style="color:rgb(83, 110, 136);">
            <span id="textspan" style="color:rgb(83, 110, 136);"><b>This email address has already been registered</b></span>.<br />Please contact us if you have not registered yet, or would like to make a change to your registration.<br />
           
            </p>
            </ASP:PANEL>
            <ASP:PANEL ID="pnlAlreadyRegistered_EmailAsPassword" runat="server" Visible="false">
                <p id="text3" style="color:rgb(83, 110, 136);">
            <span id="textspan" style="color:rgb(83, 110, 136);"><b>This email address has already been registered.</b></span><br /><br />To view the webcast, please <asp:HyperLink ID="hlRegistered_EmailAsPassword" runat="server" Font-Underline="true" Target="_blank">click here</asp:HyperLink> and enter the registered email address to continue.<br /><br/>
           
            </p>
            </ASP:PANEL>
            <ASP:PANEL ID="pnlQueryString" runat="server" Visible="false">
                <p id="text3">
            <span id="textspan" style="color:rgb(83, 110, 136);">The registration link you are trying to access is incorrect. Please verify and try again.<br /><br/>
           
            </p>
            </ASP:PANEL>
             <ASP:PANEL ID="pnlError" runat="server" Visible="false">
                <p id="text3">
            <span id="textspan" style="color:rgb(83, 110, 136);">
                    <asp:Label ID="lblErrorDescription" runat="server"></asp:Label>
                    &nbsp;Please try accessing the registration link again.<br /><br />
           
            </p>
                 </span>
            </ASP:PANEL>
            <span id="textspan2">
            <br /><br />
                <span style="color:rgb(83, 110, 136);">
                    For technical support queries or assistance, please contact <a href="mailto:info@corpcam.com" style="color:rgb(83, 110, 136)!important; text-decoration: underline;">CorpCam Support</a>.<br /><br />
                    </span>
                </span>
        </div>
           
    </div>
      
    </div>
    </form>--%>
</body>
</html>
