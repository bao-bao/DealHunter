using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealHunter.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace DealHunter.Controllers
{
    public class LRController : Controller
    {
        public class basicinfouser
        {
            public String uid { set; get; }
            public String uname { set; get; }
            public String ugender { set; get; }
            public int uage { set; get; }
            public String ucareer { set; get; }
            public String umail { set; get; }
            public String utelephone { set; get; }
            public String uceilphone { set; get; }
            public String uprovince { set; get; }
            public String ucity { set; get; }
            public String udistrict { set; get; }
            public String ustreet { set; get; }
            public String uzipcode { set; get; }

            public basicinfouser()
            {
                this.uid = "";
                this.uname = "";
                this.ugender = "";
                this.uage = 0;
                this.ucareer = "";
                this.umail = "";
                this.utelephone = "";
                this.uceilphone = "";
                this.uprovince = "";
                this.ucity = "";
                this.udistrict = "";
                this.ustreet = "";
                this.uzipcode = "";
            }
        }

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
                    Session["uid"] = loginid;
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
            registeruser.ugender = "";
            registeruser.uage = 0;
            registeruser.ucareer = "";
            registeruser.umail = registermail;
            registeruser.utelephone = "";
            registeruser.uceilphone = registerceilphone;
            registeruser.uprovince = "";
            registeruser.ucity = "";
            registeruser.udistrict = "";
            registeruser.ustreet = "";
            registeruser.uzipcode = "";

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

        public ActionResult Basicinfo()
        {
            try
            {
                String basicid = (String)Session["uid"];
                if (basicid == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                basicinfouser buser = db.user.Where(u => u.uid == basicid).Select(u => new basicinfouser() { uid = u.uid, uname = u.uname, ugender = u.ugender, uage = u.uage, ucareer = u.ucareer, umail = u.umail, utelephone = u.utelephone, uceilphone = u.uceilphone, uprovince = u.uprovince, ucity = u.ucity, udistrict = u.udistrict, ustreet = u.ustreet, uzipcode = u.uzipcode }).FirstOrDefault();
                if (buser == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                return View(buser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Login", "LR");
            }

        }
        [HttpPost]
        public String Basicinfo(String registerid, String registerpwd, String registerpincode, String registername, String registermail, String registerceilphone)
        {
            user registeruser = new user();
            registeruser.uid = registerid;
            registeruser.upwd = registerpwd;
            registeruser.upincode = registerpincode;
            registeruser.uname = registername;
            registeruser.ugender = "";
            registeruser.uage = 0;
            registeruser.ucareer = "";
            registeruser.umail = registermail;
            registeruser.utelephone = "";
            registeruser.uceilphone = registerceilphone;
            registeruser.uprovince = "";
            registeruser.ucity = "";
            registeruser.udistrict = "";
            registeruser.ustreet = "";
            registeruser.uzipcode = "";

            try
            {
                db.user.Add(registeruser);
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return "0";
            }
        }

    }
}