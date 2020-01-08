<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdaptITRegistrationApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            font-family: 'Open Sans', Tahoma, Geneva, sans-serif;
            font-weight: 300;
            background: #fff !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div id="header">
                <div id="header_inner_wrapper">
                    <div id="header_wrapper">
                        <img src="images/adaptitlogo.png" />
                    </div>
                </div>
            </div>

            <div id="header_bottom"></div>

                <div id="content_inner_wrapper">
                    <div id="content">
                        <div id="columns">

                            <div id="formdiv">

                                <asp:Login ID="loginCC" runat="server" Width="100%" OnAuthenticate="loginCC_Authenticate" DestinationPageUrl="~/secure/registrations.aspx">
                                    <LayoutTemplate>
                                        <h2>LOGIN</h2>
                                        <label for="firstname">Username</label><asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="logStudent">*</asp:RequiredFieldValidator>
                                        <br />
                                        <asp:TextBox ID="Username" runat="server" class="textbox" placeholder="Your Username.."></asp:TextBox><br />


                                        <label for="lastname">Password </label>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="logStudent">*</asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Your Password.." class="textbox"></asp:TextBox>
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="logStudent" CssClass="submit" />
                                        <br />

                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </LayoutTemplate>
                                </asp:Login>

                            </div>
                            
                        </div>
                         
                    </div>
                   
                </div>
            <div align="center"></div>
            </div>

    </form>
</body>
</html>