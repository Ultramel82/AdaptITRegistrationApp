<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationThankYou.aspx.cs" Inherits="AdaptITRegistrationApp.RegistrationThankYou" %>

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

    <div id="primaryContainer" class="primaryContainer clearfix">
        <img id="image" src="images/adaptitBanner_Feb2020_2.jpg" class="image" />
        <div id="box" class="clearfix">
            <p id="text2">
                Thank you
            </p>
        </div>
        <div id="box1" class="clearfix">
            <ASP:PANEL ID="pnlRegistered_EmailAsPassword" runat="server" Visible="false">
                <p id="text3">
                    <span id="textspan">
                        <span style="color:rgb(83, 110, 136);">
                            <asp:Label runat="server" ID="lblThankYouWording" Text="" style="color:rgb(83, 110, 136);"></asp:Label><br /><br />
                        </span>
                    </span>
                </p>
                <p id="text3">
                    <span id="textspan">
                        <span style="color:rgb(83, 110, 136);">
                            <b>Please check your inbox for the webcast access details.</b><br /><br />
                            To view the webcast, please <asp:HyperLink ID="hlEmailAsPassword_Redirect" runat="server" Font-Underline="true" Target="_blank">click here</asp:HyperLink> 
                            and enter your registered email address to continue. 
                        </span>
                    </span>
                </p>
            </ASP:PANEL>
            <ASP:PANEL ID="pnlRegistered_Password" runat="server" Visible="false">
                <p id="text3">
                    <span style="color:rgb(83, 110, 136);">
                        <span id="textspan">
                            Thank you<b><? if($name == ''){echo '[Name Here]';}else {echo $name;} ?></b>, your registration has been confirmed.
                        </span> 
                        Please check your inbox for your login details.<br />
                    </span>
                </p>
            </ASP:PANEL>
        </div>
        <div id="box1" class="clearfix">
            <p id="text3">
                <span style="color:rgb(83, 110, 136);">
                    In order to access the webcast, please make sure you meet the following system requirements&#x3a;<br />
                </span>
                <span id="textspan1">
                    <br /><br />
                    <span style="color:rgb(83, 110, 136);">
                        &#8226; Microsoft Windows PC or Apple Mac or Apple Mobile device or Android Mobile device.<br />
                        &#8226; Google Chrome, Microsoft Edge, FireFox, Internet Explorer or Safari.<br />
                        &#8226; Sound card and speakers or headphones.<br />
                        &#8226; If you are viewing through a corporate/LAN connection, please ensure that your corporate allows for streaming through their firewall.<br />                    
                    </span>
                </span>
                <span id="textspan2">
                    <br /><br />
                    <span style="color:rgb(83, 110, 136);">
                        For technical support queries or assistance, please contact <a href="mailto:info@corpcam.com" style="color:rgb(83, 110, 136)!important; text-decoration: underline;">CorpCam Support</a>.<br /><br />
                        </span>
                </span>
        </div>
        <div id="box2" class="clearfix">
            <p id="text4">
            <a href="https://www.adaptit.com" target="_blank">www.adaptit.com</a>
            </p>
       <%--  <p id="text">
            &nbsp;</p>
        <div id="box" class="clearfix">
            <p id="text2">
                <br />
            </p>
        </div>
        <div id="box1" class="clearfix">
            <ASP:PANEL ID="pnlRegistered_EmailAsPassword" runat="server" Visible="false">
                <p id="formheading_text"><asp:Label runat="server" ID="lblThankYouWording" Text=""></asp:Label></p><br /><br />
                <p id="text3">
                    <span id="textspan"><span style="color:rgb(83, 110, 136);"><b>Please check your inbox for the webcast access details.</b><br />To view the webcast, please <asp:HyperLink ID="hlEmailAsPassword_Redirect" runat="server" Font-Underline="true" Target="_blank">click here</asp:HyperLink> and enter your registered email address to continue. </span>
            </span></p>
            </ASP:PANEL>
            <ASP:PANEL ID="pnlRegistered_Password" runat="server" Visible="false">
            <p id="text3">
                <span style="color:rgb(83, 110, 136);">
                <span id="textspan">Thank you<b><? if($name == ''){echo '[Name Here]';}else {echo $name;} ?></b>, your registration has been confirmed.</span> Please check your inbox for your login details.<br />
                    </span>
            </p>
            </ASP:PANEL>
            <p id="text3">
                <span style="color:rgb(83, 110, 136);">
            In order to access the webcast, please make sure you meet the following system requirements&#x3a;<br />
                </span>
                <span id="textspan1">

                <br /><br />
<span style="color:rgb(83, 110, 136);">
                    &#8226; Microsoft Windows PC or Apple Mac or Apple Mobile device or Android Mobile device.<br />
                    &#8226; Google Chrome, Microsoft Edge, FireFox, Internet Explorer or Safari.<br />
                    &#8226; Sound card and speakers or headphones.<br />
                    &#8226; If you are viewing through a corporate/LAN connection, please ensure that your corporate allows for streaming through their firewall.<br />                    
    </span>
            <span id="textspan2">
            <br /><br />
                <span style="color:rgb(83, 110, 136);">
                    For technical support queries or assistance, please contact <a href="mailto:info@corpcam.com" style="color:rgb(83, 110, 136)!important; text-decoration: underline;">CorpCam Support</a>.<br /><br />
                    </span>
                </span>

        </span>
            </p>       
               
        </div>--%>
           
    </div>
</div>
    </form>
</body>
</html>
