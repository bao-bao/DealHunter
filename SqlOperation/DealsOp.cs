﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealModeldll;
using System.Data.Entity;

namespace SqlOperation
{
    public class DealsOp
    {
        public static List<ExtendGood> getGoods(DealsEntities db)
        {
            List<ExtendGood> goodsinfo = new List<ExtendGood>();
            try
            {
                List<goods> goods = db.goods.Where(u => u.gstate == "1").Select(u => u).ToList();
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return goodsinfo;
        }

        public static List<ExtendGood> searchGoods(DealsEntities db, string keyword, string type, string min, string max)
        {
            List<ExtendGood> goodsinfo = new List<ExtendGood>();
            try
            {
                string sql = "select * from goods where gstate = '1'";
                if (keyword != "")
                {
                    sql += " and (gname like '%" + keyword + "%' or gdes like '%" +
                    keyword + "%')";
                }
                if (type != "2")
                {
                    sql += " and gtype = '" + type + "'";
                }
                if (min != "")
                {
                    sql += " and ghigh >= " + min;
                }
                if (max != "")
                {
                    sql += " and glow <= " + max;
                }
                List<goods> goods = db.Database.SqlQuery<goods>(sql).ToList();
                foreach (var good in goods)
                {
                    user us = (from a in db.user where a.uid == good.sid select a).FirstOrDefault();
                    ExtendGood bg = new ExtendGood()
                    {
                        gid = good.gid,
                        sid = us.uid,
                        gname = good.gname,
                        glow = good.glow,
                        ghigh = good.ghigh,
                        gtype = good.gtype,
                        gdes = good.gdes,
                        uname = us.uname,
                        ugender = us.ugender,
                        umail = us.umail,
                        uceilphone = us.uceilphone,
                        uprovince = us.uprovince,
                        ucity = us.ucity,
                        udistrict = us.udistrict,
                        ustreet = us.ustreet,
                        uzipcode = us.uzipcode
                    };
                    goodsinfo.Add(bg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return goodsinfo;
        }

        public static bool makeDeal(DealsEntities db, string gid, string cid, string min, string max, string des)
        {
            try
            {
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
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public static List<ExtendGood> getWant(DealsEntities db, string uid)
        {
            List<ExtendGood> goods = new List<ExtendGood>();
            try
            {
                List<purchase> purchases = (from a in db.purchase where a.puid == uid select a).ToList();
                foreach (var purc in purchases)
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return goods;
        }

        public static bool cancelWant(DealsEntities db, string uid, string gid)
        {
            try
            {
                purchase purc = (from a in db.purchase where a.puid == uid && a.pgid == gid select a).FirstOrDefault();
                db.purchase.Remove(purc);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public static List<BasicGood> getSales(DealsEntities db, string uid)
        {
            List<BasicGood> basics = new List<BasicGood>();
            try
            {
                List<goods> goods = (from a in db.goods where a.sid == uid select a).ToList();
                foreach (var good in goods)
                {
                    BasicGood bg = new BasicGood()
                    {
                        gid = good.gid,
                        gname = good.gname,
                        glow = good.glow,
                        ghigh = good.ghigh,
                        gstarttime = good.gstarttime.ToString(),
                        gstate = good.gstate
                    };
                    basics.Add(bg);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return basics;
        }

        public static string changeSales(DealsEntities db, string gid, string state)
        {
            try
            {
                goods good = (from a in db.goods where a.gid == gid select a).FirstOrDefault();
                good.gstate = state == "1" ? "2" : "1";
                db.goods.Attach(good);
                db.Entry(good).State = EntityState.Modified;
                db.SaveChanges();
                return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "-1";
            }
        }

        public static List<Deal> statistics(DealsEntities db, string min, string max)
        {
            List<Deal> deals = new List<Deal>();
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
                List<purchase> purcs = db.Database.SqlQuery<purchase>(sql).ToList();
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
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return deals;
        }
    }
}
