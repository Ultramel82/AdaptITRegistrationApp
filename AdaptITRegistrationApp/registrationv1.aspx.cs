using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ShopriteRegistrationApp
{
    public partial class registrationv1 : System.Web.UI.Page
    {
        string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn_Shoprite"].ConnectionString;
        modules.dataAccess da = new modules.dataAccess();
        controllers.conRegistration reg = new controllers.conRegistration();

        protected string CheckRegistrationStatus()
        {
            string result = reg.CheckRegistrationStatus(Request.QueryString.Get("e").ToString(), Request.QueryString.Get("pname").ToString());
            return result;
        }

        private void Register_SendEmail()
        {
            try
            {
                   //register the user
                  Response.Redirect(reg.Registration_SendEmail(drpTitle.SelectedValue, txtFirstname.Text, txtLastname.Text, txtEmail.Text, txtMobile.Text, txtOfficeNumber.Text, txtTwitter, txtCompany.Text, "ExternalRegistration_Shoprite", Request.QueryString.Get("pname"), Convert.ToInt64(System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyID"])), false);
            }
                catch (Exception ex)
                {
                    
                //Sessionhandler.InfoMessage = ex.Message.ToString();
                //Response.Redirect("RegistrationError.aspx?err=insertErr", false);
            }
        }

        //private void Register()
        //{
        //    //register the user
        //    using (SqlConnection con = new SqlConnection(ConnString))
        //    {
        //        try
        //        {
        //            using (SqlDataAdapter da = new SqlDataAdapter())
        //            {
        //                da.SelectCommand = new SqlCommand("Registration_Insert", con);
        //                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //                da.SelectCommand.Parameters.Add("@Title", System.Data.SqlDbType.VarChar).Value = drpTitle.SelectedValue;
        //                da.SelectCommand.Parameters.Add("@Firstname", System.Data.SqlDbType.VarChar).Value = txtFirstname.Text;
        //                da.SelectCommand.Parameters.Add("@Lastname", System.Data.SqlDbType.VarChar).Value = txtLastname.Text;
        //                da.SelectCommand.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = txtEmail.Text;
        //                da.SelectCommand.Parameters.Add("@MobileNumber", System.Data.SqlDbType.VarChar).Value = txtMobile.Text;
        //                da.SelectCommand.Parameters.Add("@OfficeNumber", System.Data.SqlDbType.VarChar).Value = txtOfficeNumber.Text;
        //                da.SelectCommand.Parameters.Add("@Twitter", System.Data.SqlDbType.VarChar).Value = txtTwitter.Text;
        //                da.SelectCommand.Parameters.Add("@Company", System.Data.SqlDbType.VarChar).Value = txtCompany.Text;
        //                da.SelectCommand.Parameters.Add("@FormID", System.Data.SqlDbType.VarChar).Value = System.Configuration.ConfigurationManager.AppSettings["FormID"];
        //                da.SelectCommand.Parameters.Add("@RegistrationID", System.Data.SqlDbType.VarChar).Value = System.Configuration.ConfigurationManager.AppSettings["RegistrationID"];
        //                da.SelectCommand.Parameters.Add("@PresentationID", System.Data.SqlDbType.VarChar).Value = System.Configuration.ConfigurationManager.AppSettings["PresentationID"];

        //                System.Data.DataSet ds = new System.Data.DataSet();
        //                da.Fill(ds, "tbl_Registration");

        //                System.Data.DataTable dt = ds.Tables["tbl_Registration"];

        //                string s = dt.Rows[0][0].ToString();

        //                if (s != "0")
        //                {
        //                    Response.Redirect("RegistrationThankYou.aspx", false);
                            
        //                }
        //                else
        //                {
        //                    Response.Redirect("RegistrationError.aspx?err=" + main.QryStringValues.insertErr, false);
        //                }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw;
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString.Count == 0)
                {
                    Response.Redirect("RegistrationError.aspx?err=qryStringError", false);

                }
                else
                {
                    try
                    {
                        string emailQryString = Request.QueryString.Get("e");

                        if (CheckRegistrationStatus().Length != 0)
                        {
                            Response.Redirect("RegistrationError.aspx?err=" + main.QryStringValues.alreadyReg, false);
                        }
                       
                        txtEmail.Text = emailQryString.Replace("\"", "");
                        reg.RegistrationDetails_Get(Request.QueryString.Get("pname"), Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["CompanyID"]));

                        lblFormHeading.Text = Sessionhandler.RegistrationDetails.PresentationFormHeading;
                        lblPresentationHeading.Text = Sessionhandler.RegistrationDetails.PresentationHeading;
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
            if (CheckRegistrationStatus().Length > 0)
            {
                //it means there was an error
                Response.Redirect("RegistrationError.aspx?err=" + main.QryStringValues.alreadyReg, false);
            }
            else
            {
                Register_SendEmail();
            }

        }
    }
}