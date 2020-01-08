using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdaptITRegistrationApp.modules;

namespace AdaptITRegistrationApp
{

    public partial class error : System.Web.UI.Page
    {
        controllers.conRegistration reg = new controllers.conRegistration();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblFormHeading.Text = "Error Occurred";
            lblErrorDescription.Text = Sessionhandler.InfoMessage;

        }
    }
}