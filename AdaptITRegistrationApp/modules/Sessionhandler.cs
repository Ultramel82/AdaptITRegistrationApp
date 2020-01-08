using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdaptITRegistrationApp.modules;

namespace AdaptITRegistrationApp
{
    public class Sessionhandler
    {

        public static int LoggedInUserID
        {
            get
            {
                if (HttpContext.Current.Session["LoggedInUserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt16(HttpContext.Current.Session["LoggedInUserID"]);
                }
            }
            set
            {
                HttpContext.Current.Session["LoggedInUserID"] = value;
            }

        }

        public static int ExtRegID {
           get
            {
                if (HttpContext.Current.Session["ExtRegID"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt16( HttpContext.Current.Session["ExtRegID"]);
                }
            }
            set
            {
                HttpContext.Current.Session["ExtRegID"] = value;
            }

        }

        public static string EmailAddress
        {
            get
            {
                if (HttpContext.Current.Session["EmailAddress"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["EmailAddress"]);
                }
            }
            set
            {
                HttpContext.Current.Session["EmailAddress"] = value;
            }

        }

        public static string Firstname
        {
            get
            {
                if (HttpContext.Current.Session["Firstname"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["Firstname"]);
                }
            }
            set
            {
                HttpContext.Current.Session["Firstname"] = value;
            }

        }

        public static string Lastname
        {
            get
            {
                if (HttpContext.Current.Session["Lastname"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["Lastname"]);
                }
            }
            set
            {
                HttpContext.Current.Session["Lastname"] = value;
            }

        }


        public static string InfoMessage
        {
            get
            {
                if (HttpContext.Current.Session["InfoMessage"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["InfoMessage"]);
                }
            }
            set
            {
                HttpContext.Current.Session["InfoMessage"] = value;
            }

        }

        public static registrationDetails RegistrationDetails
        {
            get
            {
                if (HttpContext.Current.Session["RegistrationDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (registrationDetails)HttpContext.Current.Session["RegistrationDetails"];
                }
            }
            set
            {
                HttpContext.Current.Session["RegistrationDetails"] = value;
            }

        }

        public static Int64[] ViewerTypeMoreText
        {
            get
            {
                if (HttpContext.Current.Session["ViewerTypeMoreText"] == null)
                {
                    return null;
                }
                else
                {
                    return (Int64[])HttpContext.Current.Session["ViewerTypeMoreText"];
                }
            }
            set
            {
                HttpContext.Current.Session["ViewerTypeMoreText"] = value;
            }

        }

        public static Int64 PresentationID
        {
            get
            {
                if (HttpContext.Current.Session["PresentationID"] == null)
                {
                    return 0;
                }
                else
                {
                    return (Int64)HttpContext.Current.Session["PresentationID"];
                }
            }
            set
            {
                HttpContext.Current.Session["PresentationID"] = value;
            }

        }

        public static Int64 CompanyID
        {
            get
            {
                if (HttpContext.Current.Session["CompanyID"] == null)
                {
                    return 0;
                }
                else
                {
                    return (Int64)HttpContext.Current.Session["CompanyID"];
                }
            }
            set
            {
                HttpContext.Current.Session["CompanyID"] = value;
            }

        }

        public static string TableName
        {
            get
            {
                if (HttpContext.Current.Session["TableName"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["TableName"]);
                }
            }
            set
            {
                HttpContext.Current.Session["TableName"] = value;
            }

        }

    }
}