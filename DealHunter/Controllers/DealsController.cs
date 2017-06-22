using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DealHunter.Models;

namespace DealHunter.Controllers
{
    public class DealsController : Controller
    {
        private DealsEntities db = new DealsEntities();

            // GET: all goods
            public ActionResult Index()
        {
            List<ExtendGood> goodsinfo = new List<ExtendGood>();
            List<goods> goods = db.goods.Select(u => u).ToList();
            foreach (var good in goods)
            {
                user cuser = (from a in db.user where a.uid == good.sid select a).FirstOrDefault();
                ExtendGood bg = new ExtendGood()
                {
                    gid = good.gid,
                    sid = cuser.uid,
                    gname = good.gname,
                    glow = good.glow,
                    ghigh = good.ghigh,
                    gtype = good.gtype,
                    gdes = good.gdes,
                    uname = cuser.uname,
                    ugender = cuser.ugender,
                    umail = cuser.umail,
                    uceilphone = cuser.uceilphone,
                    uprovince = cuser.uprovince,
                    ucity = cuser.ucity,
                    udistrict = cuser.udistrict,
                    ustreet = cuser.ustreet,
                    uzipcode = cuser.uzipcode
                };
                goodsinfo.Add(bg);
            }
            return View(goodsinfo);
        }

        [HttpPost]
        public string Index(int x, string gid, string min, string max, string des)
        {
            try
            {
                String cid = (String)Session["uid"];
                if (cid == null)
                {
                    return "-1";
                }
                user cuser = db.user.Where(u => u.uid == cid).Select(u => u).FirstOrDefault();
                if (cuser == null)
                {
                    return "-1";
                }
                purchase newpurchase = new purchase()
                {
                    pgid = gid,
                    puid = cid,
                    plow = int.Parse(min),
                    phigh = int.Parse(max),
                    pdes = des,
                    pstate = "1",
                };
                db.purchase.Add(newpurchase);
                db.SaveChanges();
                return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "-1";
            }
        }
       
        public ActionResult Buy()
        {
            try
            {
                String cid = (String)Session["uid"];
                if (cid == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                user cuser = db.user.Where(u => u.uid == cid).Select(u => u).FirstOrDefault();
                if (cuser == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                List<ExtendGood> goods = new List<ExtendGood>();
                List<purchase> purchases = (from a in db.purchase where a.puid == cuser.uid select a).ToList();
                foreach(var purc in purchases)
                {
                    goods good = (from a in db.goods where a.gid == purc.pgid select a).FirstOrDefault();
                    user u = (from a in db.user where a.uid == purc.puid select a).FirstOrDefault();
                    ExtendGood bg = new ExtendGood()
                    {
                        gid = good.gid,
                        sid = u.uid,
                        gname = good.gname,
                        glow = good.glow,
                        ghigh = good.ghigh,
                        gtype = good.gtype,
                        gdes = good.gdes,
                        uname = u.uname,
                        ugender = u.ugender,
                        umail = u.umail,
                        uceilphone = u.uceilphone,
                        uprovince = u.uprovince,
                        ucity = u.ucity,
                        udistrict = u.udistrict,
                        ustreet = u.ustreet,
                        uzipcode = u.uzipcode
                    };
                    goods.Add(bg);
                }
                return View(goods);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Login", "LR");
            }
        }

        [HttpPost]
        public string Buy(string gid)
        {
            try
            {
                String cid = (String)Session["uid"];
                if (cid == null)
                {
                    return "-1";
                }
                user cuser = db.user.Where(u => u.uid == cid).Select(u => u).FirstOrDefault();
                if (cuser == null)
                {
                    return "-1";
                }
                purchase purc = (from a in db.purchase where a.puid == cuser.uid && a.pgid == gid select a).FirstOrDefault();
                db.purchase.Remove(purc);
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }

        public ActionResult Sale()
        {
            try
            {
                String cid = (String)Session["uid"];
                if (cid == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                user cuser = db.user.Where(u => u.uid == cid).Select(u => u).FirstOrDefault();
                if (cuser == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                List<BasicGood> basics = new List<BasicGood>();
                List<goods> goods = (from a in db.goods where a.sid == cuser.uid && a.gstate == "1" select a).ToList();
                foreach(var good in goods)
                {
                    BasicGood bg = new BasicGood()
                    {
                        gid = good.gid,
                        gname = good.gname,
                        glow = good.glow,
                        ghigh = good.ghigh,
                        gstarttime = good.gstarttime.ToString()
                    };
                    basics.Add(bg);
                }
                return View(basics);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Login", "LR");
            }
        }

        public ActionResult Statistics(string gid, string min, string max)
        {
            ViewData["goodid"] = gid;
            try
            {
                string sql = "select * from purchase where 1=1";
                if (min != "")
                {
                    sql += " and phigh > " + min;
                }
                if (max != "")
                {
                    sql += " and plow < " + max;
                }
                Console.WriteLine(sql);
                List<purchase> purcs = db.Database.SqlQuery<purchase>(sql).ToList();
                List<Deal> deals = new List<Deal>();
                foreach (var purc in purcs)
                {
                    user buser = db.user.Where(u => u.uid == purc.puid).Select(u => u).FirstOrDefault();
                    Deal deal = new Deal()
                    {
                        gid = purc.pgid,
                        low = purc.plow,
                        high = purc.phigh,
                        des = purc.pdes,
                        uname = buser.uname,
                        cellphone = buser.uceilphone,
                        mail = buser.umail
                    };
                    deals.Add(deal);
                }
                return View(deals);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Login", "LR");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
