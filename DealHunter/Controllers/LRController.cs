using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealHunter.Models;

namespace DealHunter.Controllers
{
    public class LRController : Controller
    {
        private LREntities db = new LREntities();
        // GET: LR
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public String Login(String loginid, String loginpwd)
        {
            try
            {
                var upwd = db.user.Where(u => u.uid == loginid).Select(u => u.upwd).FirstOrDefault();
                if (upwd == null)
                {
                    return "-1";
                }
                else if (upwd != loginpwd)
                {
                    return "-2";
                }
                else
                {
                    return "1";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return ("0");
            }
               
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public String Register(String registerid, String registerpwd, String registerpincode, String registername, String registermail, String registerceilphone)
        {
            user registeruser = new user();
            registeruser.uid = registerid;
            registeruser.upwd = registerpwd;
            registeruser.upincode = registerpincode;
            registeruser.uname = registername;
            registeruser.umail = registermail;
            registeruser.uceilphone = registerceilphone;

            try
            {
                db.user.Add(registeruser);
                db.SaveChanges();
                return "1";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }

    }
}