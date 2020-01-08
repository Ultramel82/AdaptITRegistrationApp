<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrationv1.aspx.cs" Inherits="ShopriteRegistrationApp.registrationv1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/boilerplate.css">
    <link rel="stylesheet" href="css/index_online.css">
    <meta charset="utf-8">
    <meta name="viewport" content="initial-scale = 1.0,maximum-scale = 1.0">

    <script src="..js/modernizr.min.js"></script>
    <script src="..js/jquery.h5validate.js"></script>



    <style type="text/css">
        :required {
            background: white !important;
        }

        ::-webkit-input-placeholder {
            color: f4f4f4 !important;
            font-style: italic !important;
            padding-left: 5px !important;
        }

        :-moz-placeholder { /* Firefox 18- */
            color: f4f4f4 !important;
            font-style: italic !important;
            padding-left: 5px !important;
        }

        ::-moz-placeholder { /* Firefox 19+ */
            color: f4f4f4 !important;
            font-style: italic !important;
            padding-left: 5px !important;
        }

        :-ms-input-placeholder {
            color: f4f4f4 !important;
            font-style: italic !important;
            padding-left: 5px !important;
        }
    </style>

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
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
            <img id="image" src="images/ShopriteHoldingsLogo.jpg" class="image" />
            <p id="text">
                 <asp:Label ID="lblPresentationHeading" runat="server" Text="" />
            </p>
             <%--<p id="text1">
                for the 6 months<br />
                ended June 2017
            </p>--%>
            <div id="box" class="clearfix">
                <p id="text2">
                    <asp:Label ID="lblFormHeading" runat="server"></asp:Label>
                    <br />
                </p>
            </div>
            <div id="box1" class="clearfix">
                <p id="text3">
                    Please complete all the required fields&#x3a;
                     <br>
                    <asp:Label ID="lblErrors" Text="" runat="server"></asp:Label>
                </p>
                    <label id="formgroup">
                        <p id="text4">
                            <span id="textspan">&#x2a;</span> Title&#x3a;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpTitle" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors" Display="Dynamic" InitialValue=" "></asp:RequiredFieldValidator>
                         </p>
                        <asp:DropDownList ID="drpTitle" runat="server" CssClass="textboxes">
                            <asp:ListItem Value=" " Text="Please choose one:"></asp:ListItem>
                            <asp:ListItem Value="Dr" Text="Dr"></asp:ListItem>
                            <asp:ListItem Value="Prof" Text="Prof"></asp:ListItem>
                            <asp:ListItem Value="Mr" Text="Mr"></asp:ListItem>
                            <asp:ListItem Value="Ms" Text="Ms"></asp:ListItem>
                            <asp:ListItem Value="Mrs" Text="Mrs"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                    </label>
                    <label id="formgroup1">
                        <p id="text5">
                            <span id="textspan1">&#x2a;</span> First Name&#x3a;
                            <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="txtFirstname" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                        </p>
                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="textboxes"></asp:TextBox>
                        &nbsp;
                    </label>
                    <label id="formgroup2"><p id="text6">
                            <span id="textspan2">&#x2a;</span> Last Name&#x3a;
                        <label id="formgroup6">
                            <asp:RequiredFieldValidator ID="rfvFirstname0" runat="server" ControlToValidate="txtLastname" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                    </label>
                        </p>
                          
                            <asp:TextBox ID="txtLastname" runat="server" CssClass="textboxes"></asp:TextBox>
                            &nbsp;</label>
                    <label id="formgroup3"><p id="text7">
                                <span id="textspan3">&#x2a;</span><span id="textspan4"> </span>Email&#x3a;
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="submit" CssClass="valErrors" Display="Dynamic"></asp:RegularExpressionValidator>
                    <label id="formgroup9">
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage=" Required" ValidationGroup="submit" CssClass="valErrors" Display="Dynamic"></asp:RequiredFieldValidator>
                    </label>
                            </p>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="email" ReadOnly="True"></asp:TextBox>
                    </label>
                    <label id="formgroup4">
                        <p id="text8">
                            <span id="textspan5">&#x2a;</span> Mobile&#x3a; <em>[Only numbers allowed]</em>
                    <label id="formgroup7">
                    <label id="formgroup8">
                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors" Display="Dynamic"></asp:RequiredFieldValidator>

                    <label id="formgroup17">
                    <label id="formgroup18">
                    <label id="formgroup19">
                    <label id="formgroup20">
                            <asp:CompareValidator ID="cvOfficeNumber0" runat="server" ControlToValidate="txtMobile" CssClass="valErrors" Display="Dynamic" ErrorMessage="Numbers Only" Operator="DataTypeCheck" Type="Integer" ValidationGroup="submit"></asp:CompareValidator>
                    </label>
                            </label>
                    </label>
                    </label>
                    </label>
                            </label>
                        </p>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="numbers"></asp:TextBox>
                    </label>

                    <label id="formgroup5">
                        <p id="text9">
                            <span id="textspan6">&#x2a;</span> Office Tel&#x3a; <em>[Only numbers allowed]</em>
                    <label id="formgroup10">
                    <label id="formgroup11">
                    <label id="formgroup12">
                            <asp:RequiredFieldValidator ID="rfvMobile0" runat="server" ControlToValidate="txtOfficeNumber" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvOfficeNumber" runat="server" ControlToValidate="txtOfficeNumber" CssClass="valErrors" Display="Dynamic" ErrorMessage="Numbers Only" Operator="DataTypeCheck" Type="Integer" ValidationGroup="submit"></asp:CompareValidator>
                    </label>
                            </label>
                    </label>
                        </p>
                        <asp:TextBox ID="txtOfficeNumber" runat="server" CssClass="numbers"></asp:TextBox>
                    </label>
                    <label id="formgroup4">
                        <p id="text9">
                            <span id="textspan6">&#x2a;</span> Company&#x3a;
                        
                    <label id="formgroup13">
                    <label id="formgroup14">
                    <label id="formgroup15">
                    <label id="formgroup16">
                            <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="txtCompany" ErrorMessage="Required" ValidationGroup="submit" CssClass="valErrors"></asp:RequiredFieldValidator>
                    </label>
                            </label>
                    </label>

                    </label>
                        </p>
                        <asp:TextBox ID="txtCompany" runat="server" CssClass="textboxes"></asp:TextBox>
                    </label>
                    <label id="formgroup5">
                        <p id="text8">
                            Twitter Name&#x3a;
                        </p>
                        <asp:TextBox ID="txtTwitter" runat="server" CssClass="textboxes"></asp:TextBox>
                    </label>

                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="buttons" OnClick="btnSubmit_Click" ValidationGroup="submit" />
                </form>
            </div>
            <div id="box2" class="clearfix">
                <p id="text10">
                    <a href="http://www.shopriteholdings.co.za" target="_blank">www.shopriteholdings.co.za</a>
                </p>
            </div>
        </div>
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
        </div>
    </form>
</body>
</html>
