<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrations.aspx.cs" Inherits="AdaptITRegistrationApp.secure.registrations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../css/forms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center"><img src="../images/logo.png" />
        </div><br />
    <div>
        <asp:LinkButton ID="lbtnLogout" runat="server" CssClass="linkbuttons" OnClick="lbtnLogout_Click">Logout</asp:LinkButton>
    <h1>Registrations</h1>
        <p>
            View Registrations for Presentation:   
            <div style="width: 50%">
                <asp:DropDownList ID="dlCompanyPresentations" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlPresentationCompany_SelectedIndexChanged" CssClass="dropdownlist">
                </asp:DropDownList>
            </div>
        </p>
<p>
    <br /><asp:LinkButton ID="lbtnExportToExcel" CssClass="linkbuttons" runat="server" OnClientClick="window.document.forms[0].target='_blank';" OnClick="lbtnExportToExcel_Click">Export to Excel</asp:LinkButton>
</p>
<p>
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <asp:Label ID="lblNumberOfRegistrations" runat="server"></asp:Label>
</p>
<table style="width: 100%">
        <tr>
            <td style="width: 60%; vertical-align: top;">
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                    <asp:GridView ID="gvRegistrations" runat="server" DataKeyNames="ExtReg_ID" Width="90%" BackColor="White" BorderColor="#6D6E70" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No records to display" ForeColor="Black" GridLines="Vertical" OnRowCommand="gvRegistrations_RowCommand" Font-Size="10px" OnRowDataBound="gvRegistrations_RowDataBound" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="#e8e8ec" />
                    <Columns>                           
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%" Visible="false">
	                        <ItemTemplate>
		                        <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandName="DeleteRegistration" Text="Delete" CssClass="gridbuttons"
                                 OnClientClick="return confirm('Are you sure you want to delete this registration?');" />
	                        </ItemTemplate>

                            <HeaderStyle Width="10%" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:ButtonField HeaderText="Resend" ButtonType="Button" Text="Send Email" CommandName="SendEmail" ControlStyle-CssClass="gridbuttons" >
<ControlStyle CssClass="gridbuttons"></ControlStyle>

                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            </asp:ButtonField>
                        <asp:BoundField DataField="ExtReg_ID" HeaderText="ExtReg_ID" />
                        <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                        <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                        <asp:BoundField DataField="Company" HeaderText="Company" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Designation" HeaderText="Designation" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="ContactNumber" />
                        <asp:TemplateField HeaderText="EmailRegistrationSubject" Visible="false">
                            <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EmailRegistrationSubject") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="lblEmailRegistrationSubject" runat="server" Text='<%# Bind("EmailRegistrationSubject") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmailTemplateDirectory" Visible="false">
                            <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EmailTemplateDirectory") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="lblEmailTemplateDirectory" runat="server" Text='<%# Bind("EmailTemplateDirectory") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmailTemplateName" Visible="false">
                            <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("EmailTemplateName") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="lblEmailTemplateName" runat="server" Text='<%# Bind("EmailTemplateName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#6D6E70" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <%--<EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EmailRegistrationSubject") %>'></asp:TextBox>
                            </EditItemTemplate>--%>
                
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
