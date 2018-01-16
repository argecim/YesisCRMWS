using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace YesisCRMWS.Controllers
{
    public class EnvanterController : ApiController
    {
        CRMEntities1 ce = new CRMEntities1();
        // GET api/values
        public IEnumerable<Object> Get()
        {
            return null;
        }

        public Object Get(string id)
        {

            var accessPoint = (from ep in ce.EnvanterAccessPoint
                               join m in ce.Musteri on ep.MusteriId equals m.Id
                               where (ep.Barkod == id)
                               select new
                               {
                                   Id = ep.Id,
                                   Musteri = m.SirketAdi,
                                   MarkaModeli = ep.MarkaModeli,
                                   AccessPointSSID = ep.AccessPointSSID,
                                   AccessPointSifresi = ep.AccessPointSifresi,
                                   AccessPointLocalIP = ep.AccessPointLocalIP,
                                   AccessPointArayuzId = ep.AccessPointArayuzId,
                                   ServerSifresi = "EnvanterAccessPoint",
                                   FirmaIPPort = "",
                                   Kontrol = "accessPoint"
                               }).FirstOrDefault();

            if (accessPoint != null)
                return accessPoint;


            var server = (from ep in ce.EnvanterServerler
                          join m in ce.Musteri on ep.MusteriId equals m.Id
                          where (ep.Barkod == id)
                          select new
                          {
                              Id = ep.Id,
                              Musteri = m.SirketAdi,
                              MarkaModeli = ep.DomainAdi,
                              AccessPointSSID = ep.DomainServerId,
                              AccessPointSifresi = ep.DomainServerSifresi,
                              AccessPointLocalIP = ep.ServerIP,
                              AccessPointArayuzId = ep.DomainServerIp,
                              ServerSifresi = ep.ServerSifresi,
                              FirmaIPPort = ep.FirmaIPPort,
                              Kontrol = "server"
                          }).FirstOrDefault();
            if (server != null)
                return server;

            var Bilgisayarlar = (from ep in ce.EnvanterBilgisayarlar
                                 join m in ce.Musteri on ep.MusteriId equals m.Id
                          where (ep.Barkod == id)
                          select new
                          {
                              Id = ep.Id,
                              Musteri = m.SirketAdi,
                              KullaniciAdi = ep.KullaniciAdi,
                              UrununTuru = ep.UrununTuru,
                              MailAdresi = ep.KullaniciMailAdresi,
                              Kontrol = "Bilgisayarlar"
                          }).FirstOrDefault();
            if (Bilgisayarlar != null)
                return Bilgisayarlar;

            return null;
        }


        // ekleme 
        public void Post(Aktivite aktivite)
        {
        }

        //Silme İşlemi
        public void Delete(int id)
        {
        }

    }
}