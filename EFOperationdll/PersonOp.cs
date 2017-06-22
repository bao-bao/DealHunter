using DealModeldll;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFOperationdll
{
    public static class PersonOp
    {
        public static String getPwd(DealsEntities db, String loginid)
        {
            try
            {
                return db.user.Where(u => u.uid == loginid).Select(u => u.upwd).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static String addUser(DealsEntities db, user newuser)
        {
            try
            {
                db.user.Add(newuser);
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }

        public static basicinfouser getBasicInfo(DealsEntities db, String searchid)
        {
            try
            {
                return db.user.Where(u => u.uid == searchid).Select(u => new basicinfouser() { uid = u.uid, uname = u.uname, ugender = u.ugender, uage = u.uage, ucareer = u.ucareer, umail = u.umail, utelephone = u.utelephone, uceilphone = u.uceilphone, uprovince = u.uprovince, ucity = u.ucity, udistrict = u.udistrict, ustreet = u.ustreet, uzipcode = u.uzipcode }).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static String updateBasicInfo(DealsEntities db, user modifyuser)
        {
            try
            {
                DbEntityEntry<user> entry = db.Entry<user>(modifyuser);
                entry.State = EntityState.Unchanged;
                entry.Property(t => t.uname).IsModified = true;
                entry.Property(t => t.ugender).IsModified = true;
                entry.Property(t => t.uage).IsModified = true;
                entry.Property(t => t.ucareer).IsModified = true;
                entry.Property(t => t.umail).IsModified = true;
                entry.Property(t => t.utelephone).IsModified = true;
                entry.Property(t => t.uceilphone).IsModified = true;
                entry.Property(t => t.uprovince).IsModified = true;
                entry.Property(t => t.ucity).IsModified = true;
                entry.Property(t => t.udistrict).IsModified = true;
                entry.Property(t => t.ustreet).IsModified = true;
                entry.Property(t => t.uzipcode).IsModified = true;
                db.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "0";
            }
        }

        public static user getAllInfo(DealsEntities db, String searchid)
        {
            try
            {
                return db.user.Where(u => u.uid == searchid).Select(u => u).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static String updatePwd(DealsEntities db, user modifyuser)
        {
            try
            {
                db.user.Attach(modifyuser);
                db.Entry(modifyuser).State = EntityState.Modified;
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
