using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdaptITRegistrationApp.secure
{
    public partial class registrations : System.Web.UI.Page
    {
        controllers.conRegistration reg = new controllers.conRegistration();
        main m = new main();
        protected void Registrations_GetAll()
        {
            try
            {
                reg.Registrations_PerPresentation_SelectAll(gvRegistrations, Convert.ToInt64(System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyID"]), Convert.ToInt64(dlCompanyPresentations.SelectedValue), "ExternalRegistration_FamousBrands");
             
            }
            catch (Exception ex)
            {
                Sessionhandler.InfoMessage = ex.Message;
                Response.Redirect("error.aspx");
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Sessionhandler.CompanyID = Convert.ToInt64(System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyID"]);
                reg.Presentation_PerCompany_GetAll(dlCompanyPresentations, Sessionhandler.CompanyID);
                Registrations_GetAll();
                reg.RegistrationDetails_Secure_Get(Convert.ToInt64(dlCompanyPresentations.SelectedValue), Sessionhandler.CompanyID);
                Sessionhandler.TableName = System.Configuration.ConfigurationManager.AppSettings["ExternalTableName"].ToString();
                Sessionhandler.PresentationID = Convert.ToInt64(dlCompanyPresentations.SelectedValue);               
                reg.Registrations_PerPresentation_SelectAll(gvRegistrations, Sessionhandler.CompanyID, Sessionhandler.PresentationID, Sessionhandler.TableName);
                lblNumberOfRegistrations.Text = "Number of registrations: " + gvRegistrations.Rows.Count.ToString();
            }
        }

        protected void gvRegistrations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SendEmail")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvRegistrations.Rows[index];

                Label lblEmailRegistrationSubject = (Label)row.Cells[11].FindControl("lblEmailRegistrationSubject");
                Label lblEmailTemplateDirectory = (Label)row.Cells[12].FindControl("lblEmailTemplateDirectory");
                Label lblEmailTemplateName = (Label)row.Cells[13].FindControl("lblEmailTemplateName");

                Sessionhandler.ExtRegID = Convert.ToInt16(row.Cells[2].Text);
                Sessionhandler.Firstname = Convert.ToString(row.Cells[4].Text);
                Sessionhandler.Lastname = Convert.ToString(row.Cells[5].Text);
                Sessionhandler.EmailAddress = Convert.ToString(row.Cells[9].Text);

                try
                {
                    lblInfo.ForeColor = System.Drawing.Color.Green;
                    lblInfo.Text = m.EmailTemplate_Merge(Sessionhandler.EmailAddress, Convert.ToString(row.Cells[10].Text), Sessionhandler.Firstname, Sessionhandler.Lastname);
                }

                catch (Exception ex)
                {

                    lblInfo.ForeColor = System.Drawing.Color.Red;
                    lblInfo.Text = ex.Message;
                }
              

            }


                //if (e.CommandName == "DeleteRegistration")
                //{
                //    GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                //    int rowIndex = gvr.RowIndex;

                //    Int64 ResponseID = (Int64)this.gvRegistrations.DataKeys[rowIndex]["ResponseID"];


                //    string[] result = presentation.Registration_PerPresentation_Delete(ResponseID);
                //    if (result[0] == "0")
                //    {
                //        lblInfo.ForeColor = System.Drawing.Color.DarkRed;
                //        lblInfo.Text = result[1].ToString();
                //    }
                //    else
                //    {

                //        lblInfo.ForeColor = System.Drawing.Color.Black;
                //        lblInfo.Text = result[1].ToString();
                //        presentation.Registration_PerPresentation_SelectAll(gvRegistrations, sessionHandler.AdminPresentationID, sessionHandler.AdminRegistrationID);

                //    }
                //}
            }

        

        protected void gvRegistrations_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    e.Row.Cells[2].Visible = false;
            //}
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Cells[2].Visible = false;
            //}
        }

        protected void lbtnExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelExport ex = new ExcelExport();            
            
            Response.Redirect("ExcelExport.aspx");
        }

        protected void dlPresentationCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sessionhandler.PresentationID = Convert.ToInt64(dlCompanyPresentations.SelectedValue);
            reg.RegistrationDetails_Secure_Get(Convert.ToInt64(dlCompanyPresentations.SelectedValue), Sessionhandler.CompanyID);
            reg.Registrations_PerPresentation_SelectAll(gvRegistrations, Sessionhandler.CompanyID, Sessionhandler.PresentationID, Sessionhandler.TableName);
            lblNumberOfRegistrations.Text = "Number of registrations: " + gvRegistrations.Rows.Count.ToString();
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("../login.aspx");

        }
    }
}