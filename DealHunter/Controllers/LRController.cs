using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealModeldll;
using System.Data.Entity.Validation;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace DealHunter.Controllers
{
    public class LRController : Controller
    {
        private DealsEntities db = new DealsEntities();
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
                var upwd = EFOperationdll.PersonOp.getPwd(db, loginid);
                if (upwd == null)
                {
                    return "-1";
                }
                else if (upwd != MD5Encrypt.MD5Encrypt.GetMd5(loginpwd))
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
            registeruser.upwd = MD5Encrypt.MD5Encrypt.GetMd5(registerpwd);
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

            return EFOperationdll.PersonOp.addUser(db, registeruser);
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
                basicinfouser buser = EFOperationdll.PersonOp.getBasicInfo(db, basicid);
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
        public String Basicinfo(String basicid, String basicname, String basicgender, String basicage, String basiccareer, String basicmail, String basictelephone, String basicceilphone, String basicprovince, String basiccity, String basicdistrict, String basicstreet, String basiczipcode)
        {
            try
            {
                user modifyuser = new user()
                {
                    uid = basicid,
                    upwd = "",
                    upincode = "",
                    uname = basicname,
                    ugender = basicgender,
                    uage = int.Parse(basicage),
                    ucareer = basiccareer,
                    umail = basicmail,
                    utelephone = basictelephone,
                    uceilphone = basicceilphone,
                    uprovince = basicprovince,
                    ucity = basiccity,
                    udistrict = basicdistrict,
                    ustreet = basicstreet,
                    uzipcode = basiczipcode
                };

                return EFOperationdll.PersonOp.updateBasicInfo(db, modifyuser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }

        public ActionResult Pwdmanage()
        {
            try
            {
                String basicid = (String)Session["uid"];
                if (basicid == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                basicinfouser buser = EFOperationdll.PersonOp.getBasicInfo(db, basicid);
                if (buser == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Login", "LR");
            }

        }
        [HttpPost]
        public String Pwdmanage(String oldpwd, String newpwd)
        {
            try
            {
                String pwdid = (String)Session["uid"];
                if (pwdid == null)
                {
                    return "-1";
                }
                user puser = EFOperationdll.PersonOp.getAllInfo(db, pwdid);
                if (puser == null)
                {
                    return "-1";
                }
                if (puser.upwd != MD5Encrypt.MD5Encrypt.GetMd5(oldpwd))
                {
                    return "-2";
                }
                puser.upwd = MD5Encrypt.MD5Encrypt.GetMd5(newpwd);

                return EFOperationdll.PersonOp.updatePwd(db, puser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }

        public ActionResult Logout()
        {
            Session["uid"] = null;
            return RedirectToAction("Login", "LR");
        }

    }
}