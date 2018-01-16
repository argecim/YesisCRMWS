using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace YesisCRMWS.Controllers
{
    public class LoginMobileController : ApiController
    {
        //
        // GET: /LoginMobile/

        CRMEntities1 ce = new CRMEntities1();

        public object get(string loginName, string loginPass)
        {
            var res = (from ep in ce.Restorant_users
                       //.Where(x => x.username == loginName && x.password == loginPass)
                       select new
                       {
                           Id = ep.id,
                           customer_name = ep.customer_name,
                           customer_surname = ep.customer_surname                          
                       }).FirstOrDefault();
            return res;
        }

        [System.Web.Http.HttpPost]
        public object get2(string loginName, string loginPass, string SMSCode)
        {
            var res = (from ep in ce.Restorant_users
                       //.Where(x => x.username == loginName && x.userpass == loginPass /*&&  SMS entegrasyonu icin x.smscode== SMSCode*/)
                       select new
                       {
                           Id = ep.id,
                           customer_name = ep.customer_name,
                           customer_surname = ep.customer_surname,
                           username = ep.username,
                           userpass = ep.password,
                           smscode = ep.smscode,
                           balance = ep.last_balance
                       }).FirstOrDefault();
            return res;
        }
    }
}
