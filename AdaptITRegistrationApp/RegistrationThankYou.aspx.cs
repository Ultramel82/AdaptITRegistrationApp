using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdaptITRegistrationApp
{  
    public partial class RegistrationThankYou : System.Web.UI.Page
    {
        controllers.conRegistration reg = new controllers.conRegistration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Sessionhandler.RegistrationDetails == null)
                {
                    if (Request.QueryString.Get("pname") != null && Request.QueryString.Get("pname") != "")
                    {
                        reg.RegistrationDetails_Get(Request.QueryString.Get("pname"), Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["CompanyID"]));
                        
                    }
                }

                //lblFormHeading.Text = Sessionhandler.RegistrationDetails.PresentationFormHeading;
                //lblPresentationHeading.Text = Sessionhandler.RegistrationDetails.PresentationHeading;
                lblThankYouWording.Text = Sessionhandler.RegistrationDetails.ThankYouWording;

                if (Sessionhandler.RegistrationDetails.EmailTemplateType == 1)
                {
                    pnlRegistered_Password.Visible = true;
                    pnlRegistered_EmailAsPassword.Visible = false;

                }
                else if (Sessionhandler.RegistrationDetails.EmailTemplateType == 2)
                {
                    pnlRegistered_Password.Visible = false;
                    pnlRegistered_EmailAsPassword.Visible = true;
                    hlEmailAsPassword_Redirect.NavigateUrl = Sessionhandler.RegistrationDetails.RegistrationLoginRedirect.ToString();
                }

            }
        }
    }
}