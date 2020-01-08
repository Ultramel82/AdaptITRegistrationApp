using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AdaptITRegistrationApp
{
    public partial class registration : System.Web.UI.Page
    {
        string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        modules.dataAccess da = new modules.dataAccess();
        controllers.conRegistration reg = new controllers.conRegistration();


        protected string CheckRegistrationStatus(string emailaddress)
        {
            string result = reg.CheckRegistrationStatus(emailaddress, Request.QueryString.Get("pname").ToString());
            return result;
        }

        private void Register_SendEmail()
        {
            try
            {
                   //register the user
                  Response.Redirect(reg.Registration_SendEmail(txtFirstname.Text, txtLastName.Text, txtEmail.Text, txtDesignation.Text, txtCompany.Text, txtContactNumber.Text, System.Configuration.ConfigurationManager.AppSettings["ExternalTableName"].ToString(), Request.QueryString.Get("pname"), Convert.ToInt64(System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyID"])), false);
            }
                catch (Exception ex)
                {
                //Response.Write(ex.Message);
                Sessionhandler.InfoMessage = ex.Message.ToString();
                Response.Redirect("RegistrationError.aspx?err=insertErr", false);
            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString.Count == 0)
                {
                    Response.Redirect("RegistrationError.aspx?err=qryStringError", false);
                    return;
                }

                if (Request.QueryString.Count != 2)
                {
                    if (Request.QueryString.Get("pname").ToString() == "" || Request.QueryString.Get("e").ToString() == "")
                    {
                        Response.Redirect("RegistrationError.aspx?err=qryStringError", false);
                    }


                }
                else
                {
                    try
                    {
                        string emailQryString = Request.QueryString.Get("e");

                        if (CheckRegistrationStatus(emailQryString).Length != 0)
                        {
                            Response.Redirect("RegistrationError.aspx?err=" + main.QryStringValues.alreadyReg, false);
                        }
                       
                        txtEmail.Text = emailQryString.Replace("\"", "");
                        reg.RegistrationDetails_Get(Request.QueryString.Get("pname"), Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["CompanyID"]));

                        if (Sessionhandler.RegistrationDetails == null)
                        {
                            Sessionhandler.InfoMessage = "Presentation not found";
                            Response.Redirect("~/RegistrationError.aspx?err=qryStringError", false);
                        }
                        else { 

                            lblFormHeading.Text = Sessionhandler.RegistrationDetails.PresentationFormHeading;
                            image.Src = Sessionhandler.RegistrationDetails.RegistrationImageName;

                            //lblPresentationHeading.Text = Sessionhandler.RegistrationDetails.PresentationHeading;

                            //if (Sessionhandler.RegistrationDetails.EmailTemplateType == 1) {
                            //    hlAlreadyRegistered.Visible = false;

                            //} else if (Sessionhandler.RegistrationDetails.EmailTemplateType == 2) {
                            //    hlAlreadyRegistered.Visible = true;
                            //    hlAlreadyRegistered.NavigateUrl = Sessionhandler.RegistrationDetails.RegistrationLoginRedirect.ToString();
                            //}
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("RegistrationError.aspx?err=qryStringError", false);
                    }

                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = "";
            if (Request.QueryString.Get("e").ToString() == "")
            {
                email = txtEmail.Text;
            }
            else
            {
                email = Request.QueryString.Get("e").ToString();
            }
            if (CheckRegistrationStatus(email).Length > 0)
            {
                //it means there was an error
                Response.Redirect("RegistrationError.aspx?err=" + main.QryStringValues.alreadyReg, false);
            }
            else
            {
                Register_SendEmail();
            }

        }

        protected void lbtnAlreadyRegistered_Click(object sender, EventArgs e)
        {
            Response.Redirect(Sessionhandler.RegistrationDetails.RegistrationLoginRedirect);
        }
    }
}