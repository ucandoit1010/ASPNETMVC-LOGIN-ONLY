using System;
using System.Web;
using System.Web.Security;

namespace Test0314.Helper
{
    public class UserHelper
    {
        public static string GetUserAccount()
        {
            FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = identity.Ticket;
            
            return ticket.UserData.Split(',')[1];
        }

        public static string GetUserId()
        {
            FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = identity.Ticket;

            return ticket.UserData.Split(',')[0];
        }

        public static bool IsUserLogin()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

    }
}