using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealModeldll
{
    public class BasicGood
    {
        public string gid { get; set; }
        public string gname { get; set; }
        public int glow { get; set; }
        public int ghigh { get; set; }
        public string gstarttime { get; set; }
    }

    public class Deal
    {
        public string gid { get; set; }
        public string uname { get; set; }
        public int low { get; set; }
        public int high { get; set; }
        public string des { get; set; }
        public string cellphone { get; set; }
        public string mail { get; set; }
    }

    public class ExtendGood
    {
        public string gid { get; set; }
        public string sid { get; set; }
        public string gname { get; set; }
        public int glow { get; set; }
        public int ghigh { get; set; }
        public string gtype { get; set; }
        public string gdes { get; set; }
        public string uname { get; set; }
        public string ugender { get; set; }
        public string uceilphone { get; set; }
        public string umail { get; set; }
        public string uprovince { get; set; }
        public string ucity { get; set; }
        public string udistrict { get; set; }
        public string ustreet { get; set; }
        public string uzipcode { get; set; }
    }

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
}
