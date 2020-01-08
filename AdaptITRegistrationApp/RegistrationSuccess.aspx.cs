using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdaptITRegistrationApp
{
    public partial class RegistrationSuccess : System.Web.UI.Page
    {
        controllers.conRegistration reg = new controllers.conRegistration();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Text = Sessionhandler.InfoMessage;

            if (!this.IsPostBack) { 
                if (Sessionhandler.RegistrationDetails == null)
                {
                    if (Request.QueryString.Get("pname") != null && Request.QueryString.Get("pname") != "")
                    {
                        reg.RegistrationDetails_Get(Request.QueryString.Get("pname"), Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["CompanyID"]));

                        lblFormHeading.Text = Sessionhandler.RegistrationDetails.PresentationFormHeading;
                        //lblPresentationHeading.Text = Sessionhandler.RegistrationDetails.PresentationHeading;
                    }
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationSubmissions.aspx", false);
        }
    }
}