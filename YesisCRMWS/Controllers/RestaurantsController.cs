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
    public class RestaurantsController : ApiController
    {
        CRMEntities1 ce = new CRMEntities1();

        public IEnumerable<object> get()
        {
            var res = (from ep in ce.VW_Restaurants
                       select new
                       {
                           ID = ep.ID,
                           Name = ep.Name,
                           latitude = ep.latitude,
                           longitude = ep.longitude,
                           description = ep.description,
                           city = ep.city,
                           country = ep.country,
                           category = ep.category,
                           logourl = ep.logourl,
                           town = ep.town,
                           distance = ep.distance
                       }).ToList().OrderBy(o => o.Name);
            return res;
        }

        public IEnumerable<object> get(string latitude,string longitude)
        {
            var res = (from ep in ce.VW_Restaurants
                       select new
                       {
                           ID = ep.ID,
                           Name = ep.Name,
                           latitude = ep.latitude,
                           longitude = ep.longitude,
                           description = ep.description,
                           city = ep.city,
                           country = ep.country,
                           category = ep.category,
                           logourl = ep.logourl,
                           town = ep.town,
                           distance = ep.distance
                       }).ToList().OrderBy(o => o.Name);
            return res;
        }

        public Object Get(int id)
        {
            var res = (from ep in ce.VW_Restaurants
                       where ep.ID == id
                       select new
                       {
                           ID = ep.ID,
                           Name = ep.Name,
                           latitude = ep.latitude,
                           longitude = ep.longitude,
                           description = ep.description,
                           city = ep.city,
                           country = ep.country,
                           category = ep.category,
                           logourl = ep.logourl,
                           town = ep.town,
                           distance = ep.distance
                       }).FirstOrDefault();

            if (res != null)
                return res;

            return null;
        }


        public IEnumerable<object> GetWithCity(string city, string town)
        {
            var res = (from ep in ce.VW_Restaurants
                       where ep.city == city && (ep.town==town || town==".")
                       select new
                       {
                           ID = ep.ID,
                           Name = ep.Name,
                           latitude = ep.latitude,
                           longitude = ep.longitude,
                           description = ep.description,
                           city = ep.city,
                           country = ep.country,
                           category = ep.category,
                           logourl = ep.logourl,
                           town = ep.town,
                           distance = ep.distance
                       }).ToList().OrderBy(o => o.distance);
           
                return res;
        }

    }
}
