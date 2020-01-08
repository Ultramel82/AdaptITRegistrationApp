using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaptITRegistrationApp.modules
{
    public class dataAccess
    {
        string connString = "";
        private void CheckConnectionString(Boolean Forced = false)
        {
            if (!Forced)
            {
                if (connString.Length == 0)
                {
                    connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                }
            }
            else
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }

        public string[] DatasetResult(System.Data.DataSet ds)
        {
            String[] arr = new string[2];
            arr[0] = ds.Tables[0].Rows[0]["ErrorID"].ToString();
            arr[1] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            //arr[2] = ds.Tables[0].Rows[0]["ErrorID"].ToString();

            return arr;
        }


        public System.Data.DataSet ExecuteSP(string spname, System.Data.SqlClient.SqlParameter[] p)
        {
            CheckConnectionString();
            System.Data.SqlClient.SqlConnection Con = new System.Data.SqlClient.SqlConnection(connString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(spname, Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (System.Data.SqlClient.SqlParameter param in p)
            {
                cmd.Parameters.Add(param);
            }

            System.Data.SqlClient.SqlParameter pp = new System.Data.SqlClient.SqlParameter();
            pp.ParameterName = "@UserID";
            pp.Value = Sessionhandler.LoggedInUserID;
            pp.SqlDbType = System.Data.SqlDbType.Int;

            cmd.Parameters.Add(pp);

            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataSet tempDS = new System.Data.DataSet();
            ad.Fill(tempDS);

            cmd.Parameters.Clear();

            return tempDS;
        }


        public System.Data.DataSet ExecuteSP(string spname)
        {
            CheckConnectionString();
            System.Data.SqlClient.SqlConnection Con = new System.Data.SqlClient.SqlConnection(connString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(spname, Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataSet tempDS = new System.Data.DataSet();

            //System.Data.SqlClient.SqlParameter pp = new System.Data.SqlClient.SqlParameter();
            //pp.ParameterName = "@UserID";
            //pp.Value = sessionHandler.LoggedInUserID;
            //pp.SqlDbType = System.Data.SqlDbType.Int;
            //cmd.Parameters.Add(pp);

            ad.Fill(tempDS);

            return tempDS;

        }

        public System.Data.SqlClient.SqlCommand ExecuteSp(string spname, System.Data.SqlClient.SqlParameter[] p, ref System.Data.DataSet DataSet)
        {
            CheckConnectionString();
            System.Data.SqlClient.SqlConnection Con = new System.Data.SqlClient.SqlConnection(connString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(spname, Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //System.Data.SqlClient.SqlParameter param = default(System.Data.SqlClient.SqlParameter);
            foreach (System.Data.SqlClient.SqlParameter param in p)
            {
                cmd.Parameters.Add(param);
            }

            //System.Data.SqlClient.SqlParameter pp = new System.Data.SqlClient.SqlParameter();
            //pp.ParameterName = "@UserID";
            //pp.Value = sessionHandler.LoggedInUserID;
            //pp.SqlDbType = System.Data.SqlDbType.Int;

            //cmd.Parameters.Add(pp);

            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);

            ad.Fill(DataSet);

            return cmd;
        }

    }
}