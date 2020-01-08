using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaptITRegistrationApp.modules
{
    public class login
    {

        modules.dataAccess da = new modules.dataAccess();
        modules.encryption enc = new modules.encryption();
        public string[] Login(string Username, byte[] Password, Int64 CompanyID)
        {
            System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[3];
            p[0] = new System.Data.SqlClient.SqlParameter("@Username", Username);
            p[1] = new System.Data.SqlClient.SqlParameter("@Password", Password);
            p[2] = new System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID);

            System.Data.DataSet ds = da.ExecuteSP("ExternalRegistration_User_Login", p);

            return da.DatasetResult(ds);
        }

        public string[] Insert(string Username, byte[] Password)
        {
            System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[2];
            p[0] = new System.Data.SqlClient.SqlParameter("@Username", Username);
            p[1] = new System.Data.SqlClient.SqlParameter("@Password", Password);

            System.Data.DataSet ds = da.ExecuteSP("User_Insert", p);

            return da.DatasetResult(ds);
        }


    }
}