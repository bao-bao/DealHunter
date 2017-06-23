﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using DealModeldll;
using SqlOperation;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DealHunter.Controllers
{
    public class DealsController : Controller
    {
        private DealsEntities db = new DealsEntities();

        // GET: all goods
        public ActionResult Index()
        {
            ViewData["IndexTalk"] = IndexTalkdll.IndexTalk.getIndexTalk();
            return View(DealsOp.getGoods(db));
        }

        public ActionResult Search(string keyword, string type, string min, string max)
        {
            try
            {
                return View(DealsOp.searchGoods(db, keyword, type, min, max));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Index(int x, string gid, string min, string max, string des)
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
            try
            {
                DealsOp.makeDeal(db, gid, cid, min, max, des);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Index");
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
                return View(DealsOp.getWant(db, cid));
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
                if (DealsOp.cancelWant(db, cid, gid))
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "1";
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
                
                return View(DealsOp.getSales(db, cid));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Login", "LR");
            }
        }

        [HttpPost]
        public string Sale(string gid, string state)
        {
            return DealsOp.changeSales(db, gid, state);
        }

        public ActionResult Statistics(string gid, string min, string max)
        {
            ViewData["goodid"] = gid;
            //try
            //{
                List<Deal> deals = DealsOp.filter(db,gid, min, max);
                if (deals.Count != 0)
                {
                    ViewData["avgmin"] = DealsOp.getAvgMin(deals);     // 使用Com组件实现
                    ViewData["avgmax"] = DealsOp.getAvgMax(deals);     // 使用Com组件实现
                    ViewData["min"] = DealsOp.getMin(deals);           // 使用win32程序实现
                    ViewData["max"] = DealsOp.getMax(deals);           // 使用win32程序实现
                }
                else
                {
                    ViewData["avgmin"] = 0;
                    ViewData["avgmax"] = 0;
                    ViewData["min"] = 0;
                    ViewData["max"] = 0;
                }
                return View(deals);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //    return RedirectToAction("Login", "LR");
            //}
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
