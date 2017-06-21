using DealHunter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DealHunter.Controllers
{
    public class GoodsController : Controller
    {
        private GoodsEntities db = new GoodsEntities();
        public ActionResult Creategoodsinfo()
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
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("Login", "LR");
            }

        }
        [HttpPost]
        public String Creategoodsinfo(String goodsname, String goodstype, String goodslow, String goodshigh, String goodsdes)
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
                goods newgoods = new goods()
                {
                    gid = "",
                    sid = cid,
                    gname = goodsname,
                    gtype = goodstype,
                    glow = int.Parse(goodslow),
                    ghigh = int.Parse(goodshigh),
                    gdes = goodsdes,
                    gstate = "1",
                    gstarttime = DateTime.Now
                };
                db.goods.Add(newgoods);
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }
    }
}