using DealModeldll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFOperationdll
{
    public static class GoodsOp
    {
        public static String addGoods(DealsEntities db, goods newgoods)
        {
            try
            {
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
