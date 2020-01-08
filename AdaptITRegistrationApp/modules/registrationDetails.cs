using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AdaptITRegistrationApp.modules
{

    public class registrationDetails
    {
        public string PresentationHeading { get; set; }
        public string PresentationFormHeading { get; set; }
        public string EmailRegistrationSubject { get; set; }
        public string EmailTemplateDirectory { get; set; }
        public string EmailTemplateName { get; set; }
        public Int16 EmailTemplateType { get; set; }    
        public string RegistrationLoginRedirect { get; set; }
        public string ThankYouWording { get; set; }
        public string RegistrationImageName { get; set; }

        public registrationDetails RegistrationDetails_Get(string FriendlyName, Int64 CompanyID)
        {
            try
            {
                dataAccess da = new dataAccess();
                System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[2];

                p[0] = new System.Data.SqlClient.SqlParameter("@PresentationFriendlyName", FriendlyName);
                p[1] = new System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID);

                DataSet ds = da.ExecuteSP("ExternalRegistration_GetDetails", p);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    this.PresentationHeading = ds.Tables[0].Rows[0]["PresentationHeader"].ToString();
                    this.PresentationFormHeading = ds.Tables[0].Rows[0]["PresentationFormHeading"].ToString();
                    this.EmailRegistrationSubject = ds.Tables[0].Rows[0]["EmailRegistrationSubject"].ToString();
                    this.EmailTemplateDirectory = ds.Tables[0].Rows[0]["EmailTemplateDirectory"].ToString();
                    this.EmailTemplateName = ds.Tables[0].Rows[0]["EmailTemplateName"].ToString();
                    this.EmailTemplateType = Convert.ToInt16(ds.Tables[0].Rows[0]["EmailTemplateTypeID"]);
                    this.RegistrationLoginRedirect = ds.Tables[0].Rows[0]["RegistrationLoginRedirect"].ToString();
                    this.ThankYouWording = ds.Tables[0].Rows[0]["ThankYouWording"].ToString();
                    this.RegistrationImageName = ds.Tables[0].Rows[0]["RegistrationImageName"].ToString();

                    return this;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        

        public registrationDetails RegistrationDetails_Secure_Get(Int64 PresentationID, Int64 CompanyID)
        {
            dataAccess da = new dataAccess();
            System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[2];

            p[0] = new System.Data.SqlClient.SqlParameter("@PresentationID", PresentationID);
            p[1] = new System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID);

            DataSet ds = da.ExecuteSP("ExternalRegistration_Secure_GetDetails", p);

            this.PresentationHeading = ds.Tables[0].Rows[0]["PresentationHeader"].ToString();
            this.PresentationFormHeading = ds.Tables[0].Rows[0]["PresentationFormHeading"].ToString();
            this.EmailRegistrationSubject = ds.Tables[0].Rows[0]["EmailRegistrationSubject"].ToString();
            this.EmailTemplateDirectory = ds.Tables[0].Rows[0]["EmailTemplateDirectory"].ToString();
            this.EmailTemplateName = ds.Tables[0].Rows[0]["EmailTemplateName"].ToString();

            return this;
        }
    }
}