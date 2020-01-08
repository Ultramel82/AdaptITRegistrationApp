using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdaptITRegistrationApp.modules;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

namespace AdaptITRegistrationApp.controllers
{
    public class conRegistration
    {
        modules.registration reg = new modules.registration();
        modules.registrationDetails regDetails = new modules.registrationDetails();
        Int64[] ViewerTypeMoreText;

        public string CheckRegistrationStatus(string email, string friendlyPresentationName)
        {

            DataSet ds = reg.RegistrationStatus(email, friendlyPresentationName);
            string err = "";

            if (ds.Tables.Count > 0)
            {
               
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    err = "Already Registered";
                    //Response.Redirect("RegistrationError.aspx?err=" + main.QryStringValues.alreadyReg, false);
                }
                else
                {
                    err = "";
                }
                
            }

            return err;
        }

        public void RegistrationDetails_Get(string PresentationFriendlyName, Int64 CompanyID)
        {
            Sessionhandler.RegistrationDetails = regDetails.RegistrationDetails_Get(PresentationFriendlyName, CompanyID);

        }

        public void RegistrationDetails_Secure_Get(Int64 PresentationID, Int64 CompanyID)
        {
            Sessionhandler.RegistrationDetails = regDetails.RegistrationDetails_Secure_Get(PresentationID, CompanyID);

        }

        public string Registration_SendEmail(string Firstname, string Lastname, string Email, string Designation, string Company, string ContactNumber, string TableName, string FriendlyPresentationName, Int64 CompanyID)
        {
            DataSet ds = new DataSet();
            ds = reg.Registration_SendEmail(Firstname, Lastname, Email, Designation, Company, ContactNumber, TableName, FriendlyPresentationName, CompanyID);
         
            string page = "";
            if (ds.Tables[0].Rows[0][0].ToString() != "0")
            {
                main m = new main();
                Sessionhandler.InfoMessage = m.EmailTemplate_Merge_AutoSend(Email, ds.Tables[0].Rows[0][1].ToString(), Firstname, Lastname);

                if (Sessionhandler.RegistrationDetails.EmailTemplateType == 1)
                {
                    page = "RegistrationThankYou.aspx";                    
                }
                else if (Sessionhandler.RegistrationDetails.EmailTemplateType == 2)
                {
                    //page = Sessionhandler.RegistrationDetails.RegistrationLoginRedirect.ToString(); THIS WAS SPECIFIC FOR SHOPRITE
                    page = "RegistrationThankYou.aspx";
                }
                
            }
            else
            {
                //Response.Redirect("RegistrationError.aspx?err=" + main.QryStringValues.insertErr, false);
                page = "RegistrationError.aspx?err=" + main.QryStringValues.insertErr;
            }
            return page;
        }


        public void Presentation_PerCompany_GetAll(DropDownList dl, Int64 CompanyID)
        {
            try
            {
                dl.DataSource = reg.Presentation_PerCompany_GetAll(CompanyID);
                dl.DataTextField = "PresentationName";
                dl.DataValueField = "PresentationID";
                dl.DataBind();
            }
            catch (Exception ex)
            {

                Sessionhandler.InfoMessage = ex.Message;
            }

           
            
        }

        public void Registrations_PerPresentation_SelectAll(GridView gv, Int64 CompanyID, Int64 PresentationID, string TableName)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reg.Registrations_PerPresentation_GetAll(CompanyID, PresentationID, TableName);

                if (ds.Tables.Count != 0)
                {
                    gv.DataSource = ds;
                    gv.DataBind();
                }
            }
            catch (Exception ex)
            {
                Sessionhandler.InfoMessage = ex.Message;
                
            }
           
        }

       



    }
}