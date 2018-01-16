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
    
   

    public class CompanyController : ApiController
    {
        CRMEntities1 ce = new CRMEntities1();

       public IEnumerable<object> get()
       {
           var res = (from ep in ce.Musteri
                                      select new
                                      {
                                          Id = ep.Id,
                                          SirketAdi = ep.SirketAdi
                                      }).ToList().OrderBy(o => o.SirketAdi);
            return res;
       }
    }
}
