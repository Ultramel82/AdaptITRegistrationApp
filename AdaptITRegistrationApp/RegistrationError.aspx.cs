using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdaptITRegistrationApp.modules;

namespace AdaptITRegistrationApp
{

    public partial class RegistrationError : System.Web.UI.Page
    {
        controllers.conRegistration reg = new controllers.conRegistration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sessionhandler.RegistrationDetails == null)
            {
                pnlError.Visible = true;
                lblErrorDescription.Text = Sessionhandler.InfoMessage;
                //if (Request.QueryString.Get("pname") != null && Request.QueryString.Get("pname") != "")
                //{
                //    reg.RegistrationDetails_Get(Request.QueryString.Get("pname"), Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["CompanyID"]));

                //    //lblFormHeading.Text = Sessionhandler.RegistrationDetails.PresentationFormHeading;
                //    //lblPresentationHeading.Text = Sessionhandler.RegistrationDetails.PresentationHeading;

                //}
            }
            else
            {
                string qry = Request.QueryString.Get("err");
                if (qry == main.QryStringValues.alreadyReg.ToString())
                {
                    if (Sessionhandler.RegistrationDetails.EmailTemplateType == 1)
                    {
                        pnlAlreadyRegistered.Visible = true;
                        pnlAlreadyRegistered_EmailAsPassword.Visible = false;
                    }
                    else if (Sessionhandler.RegistrationDetails.EmailTemplateType == 2)
                    {
                        pnlAlreadyRegistered.Visible = false;
                        pnlAlreadyRegistered_EmailAsPassword.Visible = true;
                        hlRegistered_EmailAsPassword.NavigateUrl = Sessionhandler.RegistrationDetails.RegistrationLoginRedirect.ToString();
                    }


                    pnlQueryString.Visible = false;
                    pnlError.Visible = false;
                }
                else
                if (qry == main.QryStringValues.qryStringErr.ToString())
                {
                    pnlAlreadyRegistered.Visible = false;
                    pnlQueryString.Visible = true;
                    pnlError.Visible = false;
                }
                else
                if (qry == main.QryStringValues.insertErr.ToString())
                {
                    pnlAlreadyRegistered.Visible = false;
                    pnlQueryString.Visible = false;
                    pnlError.Visible = true;
                    lblErrorDescription.Text = Sessionhandler.InfoMessage.ToString(); //"A database related error occurred. ";
                }
                else
                {
                    pnlAlreadyRegistered.Visible = false;
                    pnlQueryString.Visible = false;
                    pnlError.Visible = true;
                    lblErrorDescription.Text = "An error occurred. ";
                }
            }
  
            
        }
    }
}