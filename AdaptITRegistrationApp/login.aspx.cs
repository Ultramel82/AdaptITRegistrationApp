using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdaptITRegistrationApp
{
    public partial class login : System.Web.UI.Page
    {
        controllers.cLogin mLogin = new controllers.cLogin();

        protected void loginCC_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Session.Clear();
            modules.encryption enc = new modules.encryption();



            List<String> UserLogin = mLogin.User_Login(loginCC.UserName, loginCC.Password, Convert.ToInt64(System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyID"]));
            Sessionhandler.LoggedInUserID = Convert.ToInt16(UserLogin[0]);


            if (Sessionhandler.LoggedInUserID == 0)
            {
                loginCC.FailureText = "Incorrect Username or Password";
                e.Authenticated = false;
            }
            else
            {
                e.Authenticated = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
            }

        }
    }
}