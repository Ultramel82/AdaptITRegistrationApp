using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaptITRegistrationApp.controllers
{
    public class cLogin
    {
        public int UserID { get; set; }
        public Boolean Authenticated { get; set; }

        modules.login login = new modules.login();
        public string User_Insert(string username, string password)
        {
            modules.encryption enc = new modules.encryption();
            byte[] ePassword;
            ePassword = enc.Encrypt(password);


            string[] qArr = login.Insert(username, ePassword);
            if (qArr[0] == "0")
            {
                //ErrorNumber of 0 -- insert successful
                return qArr[1];
            }
            else
            {
                return "Error occurred: " + qArr[1];
            }
        }

        public List<string> User_Login(string username, string password, Int64 companyID)
        {
            modules.encryption enc = new modules.encryption();
            byte[] ePassword;
            ePassword = enc.Encrypt(password);


            string[] qArr = login.Login(username, ePassword, companyID);

            List<String> uArr = new List<string>();
            uArr.Add(qArr[0]);
            uArr.Add(qArr[1]);
            if (qArr[0] == "0")
            {
                uArr.Add("false"); //if the userID is 0, it means there is no such user
            }
            else
            {
                uArr.Add("true"); //if the userID is > 0, it means user was authenticated
            }

            return uArr;
        }


    }
}