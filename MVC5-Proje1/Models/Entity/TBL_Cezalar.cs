//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5_Proje1.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Cezalar
    {
        public int Cezaid { get; set; }
        public Nullable<int> uye { get; set; }
        public Nullable<System.DateTime> Baslangıc { get; set; }
        public Nullable<System.DateTime> bitis { get; set; }
        public Nullable<decimal> para { get; set; }
        public Nullable<int> hareket { get; set; }
    
        public virtual TBL_Uye TBL_Uye { get; set; }
        public virtual TBL_Hareket TBL_Hareket { get; set; }
    }
}
