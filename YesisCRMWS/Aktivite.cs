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
    
    public partial class Aktivite
    {
        public int Id { get; set; }
        public Nullable<int> MusteriId { get; set; }
        public Nullable<int> AktiviteTipiId { get; set; }
        public Nullable<int> AktiviteSecenegiId { get; set; }
        public Nullable<int> AktiviteDurumuId { get; set; }
        public Nullable<int> PersonelId { get; set; }
        public string Aciklama { get; set; }
        public Nullable<byte> Oncelik { get; set; }
        public Nullable<byte> Fatura { get; set; }
        public Nullable<byte> MuhasebelestiMi { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Statusu { get; set; }
        public Nullable<int> CreateUser { get; set; }
        public Nullable<int> UpdateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Barkod { get; set; }
        public Nullable<bool> OperasyondaMi { get; set; }
        public Nullable<bool> MailGittiMi { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public string Aciklama4 { get; set; }
        public string Aciklama5 { get; set; }
    }
}
