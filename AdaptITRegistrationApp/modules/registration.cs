using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AdaptITRegistrationApp.modules
{
    public class registration
    {

        public Int64 CompanyID { get; set; }
        public string CompanyName { get; set; }

        string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        modules.dataAccess da = new modules.dataAccess();



        public DataSet RegistrationStatus(string email, string friendlyPresentationName)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                try
                {
                    System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[4];
                    p[0] = new System.Data.SqlClient.SqlParameter("@Email", email);
                    p[1] = new System.Data.SqlClient.SqlParameter("@PresentationFriendlyName", friendlyPresentationName);
                    p[2] = new System.Data.SqlClient.SqlParameter("@CompanyID", Convert.ToInt64(System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyID"]));
                    p[3] = new System.Data.SqlClient.SqlParameter("@TableName", System.Configuration.ConfigurationManager.AppSettings["ExternalTableName"].ToString());

                    System.Data.DataSet ds = da.ExecuteSP("ExternalRegistration_CheckStatus", p);

                    return ds;

                }
                catch (SqlException ex)
                {
                    throw;
                }
                
            }
        }
        
        public DataSet Registration_SendEmail(string Firstname, string Lastname, string Email, string Designation, string Company, string ContactNumber, string TableName, string FriendlyPresentationName, Int64 CompanyID)
        {
            System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[9];          
            p[0] = new System.Data.SqlClient.SqlParameter("@Firstname", Firstname);
            p[1] = new System.Data.SqlClient.SqlParameter("@Lastname", Lastname);
            p[2] = new System.Data.SqlClient.SqlParameter("@Email", Email);
            p[3] = new System.Data.SqlClient.SqlParameter("@Designation", Designation);            
            p[4] = new System.Data.SqlClient.SqlParameter("@Company", Company);
            p[5] = new System.Data.SqlClient.SqlParameter("@ContactNumber", ContactNumber);
            p[6] = new System.Data.SqlClient.SqlParameter("@TableName", System.Configuration.ConfigurationManager.AppSettings["ExternalTableName"].ToString());
            p[7] = new System.Data.SqlClient.SqlParameter("@PresentationFriendlyName", FriendlyPresentationName);
            p[8] = new System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID);


            System.Data.DataSet ds = da.ExecuteSP("ExternalRegistration_Insert_SendEmail_AdaptIT", p);

            return ds;
        }

       

        public DataSet Presentation_PerCompany_GetAll(Int64 CompanyID)
        {
            System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[1];
            p[0] = new System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID);
           
            System.Data.DataSet ds = da.ExecuteSP("ExternalRegistration_Presentation_PerCompany_SelectAll", p);

            return ds;
        }

        public DataSet Registrations_PerPresentation_GetAll(Int64 CompanyID, Int64 PresentationID, string TableName)
        {
            System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[3];
            p[0] = new System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID);
            p[1] = new System.Data.SqlClient.SqlParameter("@PresentationID", PresentationID);
            p[2] = new System.Data.SqlClient.SqlParameter("@TableName", TableName);

            System.Data.DataSet ds = da.ExecuteSP("ExternalRegistration_Registrations_SelectAll", p);

            return ds;
        }


    }
}