﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CRMEntities1 : DbContext
    {
        public CRMEntities1()
            : base("name=CRMEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Aktivite> Aktivite { get; set; }
        public DbSet<ActiviteAciklamalari> ActiviteAciklamalari { get; set; }
        public DbSet<AktiviteDurumu> AktiviteDurumu { get; set; }
        public DbSet<AktiviteLoglari> AktiviteLoglari { get; set; }
        public DbSet<AktiviteSecenegi> AktiviteSecenegi { get; set; }
        public DbSet<AktiviteTipi> AktiviteTipi { get; set; }
        public DbSet<AltKategoriler> AltKategoriler { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<EnvanterAccessPoint> EnvanterAccessPoint { get; set; }
        public DbSet<EnvanterBilgisayarlar> EnvanterBilgisayarlar { get; set; }
        public DbSet<EnvanterServerler> EnvanterServerler { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<VW_Restaurants> VW_Restaurants { get; set; }
        public DbSet<Restorant_users> Restorant_users { get; set; }
        public DbSet<restorant_activity> restorant_activity { get; set; }
    }
}
