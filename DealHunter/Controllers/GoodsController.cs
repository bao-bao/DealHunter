using DealModeldll;
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
        private DealsEntities db = new DealsEntities();
        public ActionResult Creategoodsinfo()
        {
            try
            {
                String cid = (String)Session["uid"];
                if (cid == null)
                {
                    return RedirectToAction("Login", "LR");
                }
                user cuser = EFOperationdll.PersonOp.getAllInfo(db, cid);
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
                user cuser = EFOperationdll.PersonOp.getAllInfo(db, cid);
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
                return EFOperationdll.GoodsOp.addGoods(db, newgoods);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }
    }
}