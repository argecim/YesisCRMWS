using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace YesisCRMWS.Controllers
{
    public class ActivitiesController : ApiController
    {
        CRMEntities1 ce = new CRMEntities1();
        // GET api/values
        public IEnumerable<Object> Get()
        {
            //Select * From VW_AktivitelerListesi where AktiviteDurumu not in  ('Tamamlandı','Çözüm Sağlanamadı','İptal','Teslim Edildi','Teslim Edildi ')   and
            //PersonelId=" + Id + " and Tarih <='" + tarih + "' and  AktiviteDurumu <> 'İptal'

            var ee = (from ep in ce.Aktivite
                      join e in ce.AktiviteDurumu on ep.AktiviteDurumuId equals e.Id
                      join t in ce.AktiviteTipi on ep.AktiviteTipiId equals t.Id
                      join x in ce.Personel on ep.PersonelId equals x.Id
                      join y in ce.AktiviteSecenegi on ep.AktiviteSecenegiId equals y.Id
                      join m in ce.Musteri on ep.MusteriId equals m.Id
                      where (
                      e.Aciklama != "Tamamlandı" && e.Aciklama != "Çözüm Sağlanamadı" && e.Aciklama != "İptal" && e.Aciklama != "İptal" && e.Aciklama != "Teslim Edildi" && e.Aciklama != "Teslim Edildi ")
                      select new
                      {
                          Id = ep.Id,
                          Aciklama = ep.Aciklama,
                          AktiviteDurumu = e.Aciklama,
                          AktiviteTipi = t.Aciklama,
                          AktiviteSecenegi = y.Aciklama,
                          PersonelAdi = x.AdiSoyadi,
                          Musteri = m.SirketAdi,
                          Renk = e.Renk
                      }).ToList().OrderByDescending(o => o.Id);

            /*
            var ee= (from ep in ce.Aktivite
                              join e in ce.AktiviteDurumu on ep.AktiviteDurumuId equals e.Id
                              join t in ce.AktiviteTipi on ep.AktiviteTipiId equals t.Id
                              join x in ce.Personel on ep.PersonelId equals x.Id
                              join y in ce.AktiviteSecenegi on ep.AktiviteSecenegiId equals y.Id
                              join m in ce.Musteri on ep.MusteriId equals m.Id
                              where(ep.AktiviteDurumuId != 8 && ep.AktiviteDurumuId != 9 && ep.AktiviteDurumuId != 13 && ep.AktiviteDurumuId != 15
                && ep.AktiviteDurumuId != 30
                && ep.AktiviteDurumuId != 18 && ep.AktiviteDurumuId != 19 && ep.AktiviteDurumuId != 20 && ep.AktiviteDurumuId != 21 && ep.AktiviteDurumuId != 22
                && ep.AktiviteDurumuId != 23 && ep.AktiviteDurumuId != 24 && ep.AktiviteDurumuId != 25)
                              select new
                              {
                                  Id = ep.Id,
                                  Aciklama = ep.Aciklama,
                                  AktiviteDurumu = e.Aciklama,
                                  AktiviteTipi = t.Aciklama,
                                  AktiviteSecenegi = y.Aciklama,
                                  PersonelAdi = x.AdiSoyadi,
                                  Musteri = m.SirketAdi
                              }).ToList();
            */
            return ee;

        }

        public IEnumerable<Object> Get(int userId)
        {
            var ee = (from ep in ce.restorant_activity
                      where (ep.userid == userId)
                      select new
                      {
                          Id = ep.id,
                          restaurant_name = ep.restaurant_name,
                          process_date = ep.process_date,
                          process_type = ep.process_type,
                          amount = ep.amount,
                          pos_or_mobile = ep.pos_or_mobile
                      }).ToList().OrderByDescending(o => o.Id); ;
            return ee;
        }

        // ekleme 
        public void Post(Aktivite aktivite)
        {
            //ce.Aktivite.Add(aktivite);
            //ce.SaveChanges();
        }

    }
}