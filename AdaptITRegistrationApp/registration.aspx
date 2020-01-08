<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="AdaptITRegistrationApp.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/boilerplate.css">
    <link rel="stylesheet" href="css/online.css">
    <meta charset="utf-8">
    <meta name="viewport" content="initial-scale = 1.0,maximum-scale = 1.0">

    <script src="..js/modernizr.min.js"></script>
    <script src="..js/jquery.h5validate.js"></script>

    <script type="text/javascript">


        function numbersonly(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
                (key == 9) || (key == 13) || (key == 27))
                return true;

                // numbers
            else if ((("0123456789").indexOf(keychar) > -1))
                return true;

                // decimal point jump
            else if (dec && (keychar == ".")) {
                myfield.form.elements[dec].focus();
                return false;
            }
            else
                return false;
        }




    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="primaryContainer" class="primaryContainer clearfix">
            <%--<img id="image" src="images/banner_100.png" class="image" />--%>
            <img id="image" src="" class="image" runat="server" />
                <p id="formheading_text">
                    <asp:Label ID="lblFormHeading" runat="server" Width="30%"></asp:Label>
                    <br /><br />
                </p>
               <div style="background-color: #dedcdf;">
                    <div id="box1" class="clearfix">
                        <p id="forminfo_text">
                            <asp:LinkButton ID="lbtnAlreadyRegistered" runat="server" CssClass="link_buttons" OnClick="lbtnAlreadyRegistered_Click">Already Registered</asp:LinkButton></p>                        
                        <p id="forminfo_text">Please complete all the required fields:</p>
                        <label id="formgroup">
                            <p id="formlabel_text">
                                <span id="required_text">&#x2a;</span>First Name&#x3a;
                                <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="txtFirstname" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                            </p>
                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="textboxes"></asp:TextBox>
                        </label>
                        <label id="formgroup">
                            <p id="formlabel_text">
                                <span id="required_text">&#x2a;</span>Surname&#x3a;
                                <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="txtLastname" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                            </p>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="textboxes"></asp:TextBox>
                        </label>
                        <label id="formgroup">
                            <p id="formlabel_text">
                                <span id="required_text">&#x2a;</span>Company&#x3a;
                                <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="txtCompany" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                            </p>
                            <asp:TextBox ID="txtCompany" runat="server" CssClass="textboxes"></asp:TextBox>
                        </label>
                        <label id="formgroup">
                            <p id="formlabel_text">
                                <span id="required_text">&#x2a;</span>Designation&#x3a;
                                <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                            </p>
                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="textboxes"></asp:TextBox>
                        </label>
                        <label id="formgroup">
                            <p id="formlabel_text">
                                <span id="required_text">&#x2a;</span>Email&#x3a;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="submit" CssClass="valErrors" Display="Dynamic"></asp:RegularExpressionValidator>
                            </p>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textboxes"></asp:TextBox>
                        </label>   
                        <label id="formgroup">
                            <p id="formlabel_text">
                                <span id="required_text">&#x2a;</span>Contact Number&#x3a;
                                <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                            </p>
                            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="textboxes"></asp:TextBox>
                        </label>
                        <div id="formfooter_text"><br />Your data will be processed according to the European GDPR Guidelines</div>
                        <div class="button_wrapper"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="submit" CssClass="buttons" /></div>
                    </div>
                   <%--<img src="images/adaptitfooter.png" id="image_footer" class="image"  />--%>
               </div>
            
            </div>
            
         </form>
    <script type="text/javascript">
        function supports_input_placeholder() {
            var i = document.createElement('input'); return 'placeholder' in i;
        } if (!supports_input_placeholder()) {
            var fields = document.getElementsByTagName('input');
            for (var i = 0; i < fields.length; i++) {
                if (fields[i].hasAttribute('placeholder')) {
                    fields[i].defaultValue = fields[i].getAttribute('placeholder');
                    fields[i].onfocus = function () {
                        if (this.value == this.defaultValue) this.value = '';
                    }
                    fields[i].onblur = function () {
                        if (this.value == '') this.value = this.defaultValue;
                    }
                }
            }
        }
    </script>

</body>
</html>
