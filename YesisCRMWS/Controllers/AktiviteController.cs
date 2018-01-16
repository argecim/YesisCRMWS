using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

using System.Net;
using System.Net.Http;



namespace YesisCRMWS.Controllers
{
    public class AktiviteController : ApiController
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
                      }).ToList().OrderByDescending(o=>o.Id);

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

        public Object Get(int id)
        {

            var ee = (from ep in ce.Aktivite
                      join e in ce.AktiviteDurumu on ep.AktiviteDurumuId equals e.Id
                      join t in ce.AktiviteTipi on ep.AktiviteTipiId equals t.Id
                      join x in ce.Personel on ep.PersonelId equals x.Id
                      join y in ce.AktiviteSecenegi on ep.AktiviteSecenegiId equals y.Id
                      join m in ce.Musteri on ep.MusteriId equals m.Id
                      where (ep.Id==id)
                      select new
                      {
                          Id = ep.Id,
                          Aciklama = ep.Aciklama,
                          AktiviteDurumu = e.Aciklama,
                          AktiviteTipiId = ep.AktiviteTipiId,
                          AktiviteTipi = t.Aciklama,
                          AktiviteSecenegi = y.Aciklama,
                          PersonelAdi = x.AdiSoyadi,
                          Musteri = m.SirketAdi,
                          Renk = e.Renk,
                      }).FirstOrDefault();
            return ee;
        }

        public IEnumerable<Object> Get(int personelId, int id)
        {

            var ee = (from ep in ce.Aktivite
                      join e in ce.AktiviteDurumu on ep.AktiviteDurumuId equals e.Id
                      join t in ce.AktiviteTipi on ep.AktiviteTipiId equals t.Id
                      join x in ce.Personel on ep.PersonelId equals x.Id
                      join y in ce.AktiviteSecenegi on ep.AktiviteSecenegiId equals y.Id
                      join m in ce.Musteri on ep.MusteriId equals m.Id
                      where ( //ep.PersonelId==personelId &&
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

            return ee;
        }

        // ekleme 
         public void Post(Aktivite aktivite)
        {
            ce.Aktivite.Add(aktivite);
            ce.SaveChanges();

        }

        //Güncelleme İşlemi
        //[System.Web.Http.HttpPost]
        public HttpResponseMessage iptal(int? id, int? durumId, int? aktiviteTipiId, string aciklama,string iptal)
         {
             Aktivite item = ce.Aktivite.First(f => f.Id == id);

             AktiviteDurumu ad = ce.AktiviteDurumu.Where(x => x.AktiviteTipiId == aktiviteTipiId && x.Aciklama == "Beklemede").SingleOrDefault<AktiviteDurumu>();
             //item.FirstName = student.FirstName;
             //item.LastName = student.LastName;
             //item.Age = student.Age;
             //item.Gender = student.Gender;
             item.PersonelId = 23;
             item.Aciklama = item.Aciklama + " " + aciklama;
             if (ad != null)
                 item.AktiviteDurumuId = ad.Id;

            ActiviteAciklamalari ac = new ActiviteAciklamalari();
            ac.Aciklama = aciklama;
            ac.AktiviteId = id;
            ac.CreateUser = item.PersonelId;
            ac.PersonelId = item.PersonelId;
            ac.CreateDate = DateTime.Now;
            ac.Tarih = DateTime.Now;
            ce.ActiviteAciklamalari.Add(ac);
            ce.SaveChanges();
            return Request.CreateErrorResponse(HttpStatusCode.OK," durumId:"+ durumId + " id:"+id);
         }


        //Güncelleme İşlemi
        //[System.Web.Http.HttpPost]
        public HttpResponseMessage Beklemede(int? id, int? durumId, int? aktiviteTipiId, string aciklama,string xx)
         {
             Aktivite item = ce.Aktivite.First(f => f.Id == id);

             AktiviteDurumu ad = ce.AktiviteDurumu.Where(x => x.AktiviteTipiId == aktiviteTipiId && x.Aciklama == "Beklemede").SingleOrDefault<AktiviteDurumu>();
             //item.FirstName = student.FirstName;
             //item.LastName = student.LastName;
             //item.Age = student.Age;
             //item.Gender = student.Gender;
             if (ad != null)
                 item.AktiviteDurumuId = ad.Id;

            ActiviteAciklamalari ac = new ActiviteAciklamalari();
            ac.Aciklama = aciklama;
            ac.AktiviteId = id;
            ac.CreateUser = item.PersonelId;
            ac.PersonelId = item.PersonelId;
            ac.CreateDate = DateTime.Now;
            ac.Tarih = DateTime.Now;
            ce.ActiviteAciklamalari.Add(ac);
            ce.SaveChanges();
             return Request.CreateErrorResponse(HttpStatusCode.OK, " durumId:" + durumId + " id:" + id);
         }

        //Güncelleme İşlemi
        //[System.Web.Http.HttpPost]
        public HttpResponseMessage Tamamlandi(int? id, int? durumId, int? aktiviteTipiId, string aciklama, string ss)
         {
             Aktivite item = ce.Aktivite.First(f => f.Id == id);

             AktiviteDurumu ad = ce.AktiviteDurumu.Where(x => x.AktiviteTipiId == aktiviteTipiId && x.Aciklama == "Tamamlandı").SingleOrDefault<AktiviteDurumu>();
             //item.FirstName = student.FirstName;
             //item.LastName = student.LastName;
             //item.Age = student.Age;
             //item.Gender = student.Gender;
             //item.Aciklama = item.Aciklama + " " + aciklama;
             if (ad !=null)
             item.AktiviteDurumuId = ad.Id;
             item.OperasyondaMi = true;
             
             ActiviteAciklamalari ac = new ActiviteAciklamalari();
             ac.Aciklama = aciklama;
             ac.AktiviteId = id;
             ac.CreateUser = item.PersonelId;
             ac.PersonelId = item.PersonelId;
             ac.CreateDate = DateTime.Now;
             ac.Tarih = DateTime.Now;
             ce.ActiviteAciklamalari.Add(ac);
             ce.SaveChanges();
             
             return Request.CreateErrorResponse(HttpStatusCode.OK, " durumId:" + durumId + " id:" + id);
         }

         //Silme İşlemi
         public void Delete(int id)
         {
             Aktivite item = ce.Aktivite.First(f => f.Id == id);
             ce.Aktivite.Remove(item);
             ce.SaveChanges();
         }


    }
}