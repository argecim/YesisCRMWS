using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace YesisCRMWS.Controllers
{
    public class LoginController : ApiController
    {
        //
        // GET: /Login/

        CRMEntities1 ce = new CRMEntities1();

        public object get(string loginName, string loginPass)
        {
            var res = (from ep in ce.Personel
                       select new
                       {
                           Id = ep.Id,
                           AdiSoyadi = ep.AdiSoyadi,
                           KullaniciAdi=ep.KullaniciAdi,
                           Sifresi = ep.Sifresi
                       }).Where(x => x.KullaniciAdi == loginName && x.Sifresi == loginPass).FirstOrDefault();
            return res;
        }

    }
}
