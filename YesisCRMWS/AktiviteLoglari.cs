//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YesisCRMWS
{
    using System;
    using System.Collections.Generic;
    
    public partial class AktiviteLoglari
    {
        public int Id { get; set; }
        public Nullable<int> AktiviteId { get; set; }
        public string Statusu { get; set; }
        public Nullable<int> PersonelId { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<int> CreateUser { get; set; }
        public Nullable<int> UpdateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
