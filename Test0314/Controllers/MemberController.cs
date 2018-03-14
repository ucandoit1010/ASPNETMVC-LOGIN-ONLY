using System;
using System.Web.Security;
using System.Web.Mvc;
using BusinessLayer.BLMembers;
using TestModels.MembersModel;
using Test0314.Helper;

namespace Test0314.Controllers
{
    public class MemberController : Controller
    {
        IMemberRepository memberRep;

        public MemberController()
        {
            memberRep = new MembersRepository();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Validate(string account , string password)
        {
            Members member = new Members();
            member.Account = account;
            member.Password = EncryptHelper.GetSHA1(password);

            var chkMember = memberRep.GetMember(member);
            if (chkMember != null)
            {
                string encrypt = LoginUser(chkMember);

                Response.Cookies.Add(new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encrypt));
                return RedirectToAction("Index", "Admin", new { area = "SiteAdmin" });
            }

            TempData["Error"] = "尚未註冊";
            return RedirectToAction("Display", "Home");
        }

        [HttpPost]
        public ActionResult Save(string account , string password)
        {
            Members members = new Members();
            members.Account = account;
            members.Password = EncryptHelper.GetSHA1(password);
            members.MemberId = Guid.NewGuid();
            
            try
            {
                var result = memberRep.IsMemberExists(members);
                if (result)
                {
                    TempData["Error"] = "已存在，請登入";

                    return RedirectToAction("Display", "Home");
                }
                
                if (memberRep.AddMember(members))
                {
                    string encrypt = this.LoginUser(members);
                    
                    Response.Cookies.Add(new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encrypt));

                    return RedirectToAction("Index","Admin",new { area = "SiteAdmin" });
                }

                TempData["Error"] = "註冊發生錯誤";
                return RedirectToAction("Display","Home");
            }
            catch (Exception err)
            {
                throw err;
            }
            
        }

        public ActionResult Register()
        {

            return View();
        }

        private string LoginUser(Members member)
        {
            DateTime now = DateTime.Now;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              "site_cookie",
              now,
              now.AddMinutes(30),
              true,
              string.Format("{0} , {1}", member.MemberId, member.Account),
              FormsAuthentication.FormsCookiePath);

            return FormsAuthentication.Encrypt(ticket);
        }

    }
}