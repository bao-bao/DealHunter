//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DealModeldll
{
    using System;
    using System.Collections.Generic;
    
    public partial class goods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public goods()
        {
            this.purchase = new HashSet<purchase>();
        }
    
        public string gid { get; set; }
        public string sid { get; set; }
        public string gname { get; set; }
        public string gtype { get; set; }
        public int glow { get; set; }
        public int ghigh { get; set; }
        public string gdes { get; set; }
        public string gstate { get; set; }
        public System.DateTime gstarttime { get; set; }
    
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase> purchase { get; set; }
    }
}
