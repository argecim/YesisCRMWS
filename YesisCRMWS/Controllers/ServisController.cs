using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace YesisCRMWS.Controllers
{
    public class ServisController : ApiController
    {
        //
        // GET: /Servis/

        // ekleme 
        public void Post(Aktivite aktivite)
        {
        }

        //Silme İşlemi
        public void Delete(int id)
        {
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        */


        public void get(string FirmaAdi, string IlgiliKisi, string ServisComment)
        {
            Thread email = new Thread(delegate()
            {
                mailgonder(FirmaAdi, IlgiliKisi, ServisComment);
            });

            email.IsBackground = true;
            email.Start();

        }
        public void mailgonder(string FirmaAdi, string IlgiliKisi, string ServisComment)
        {

            baglanti veri = new baglanti();
            //string gidecekmailler = "operator@operator.com";
            string gidecekmailler = ConfigurationManager.AppSettings["operator_email"].ToString();            

            MailMessage EmailMsg = new MailMessage();

            string smtpadres, gidenmail, mailsifre;
            int mailport;
            DataRow drveri = veri.GetDataRow("Select Mail,Smtp,MailPort,MailSifre From MailAyarlari");

            smtpadres = drveri["Smtp"].ToString();
            gidenmail = drveri["Mail"].ToString();
            mailport = Convert.ToInt32(drveri["MailPort"]);
            mailsifre = drveri["MailSifre"].ToString();

            string mailmesaj = string.Format("<table><tr><td>Firma Adı</td><td>:</td><td>{0}</td></tr><tr><td>İlgili Kişi</td><td>:</td><td>{1}</td></tr><tr><td>Servis Talebi</td><td>:</td><td>{2}</td></tr></table>",FirmaAdi,IlgiliKisi,ServisComment);

            EmailMsg.From = new MailAddress(gidenmail, "YESİS");
            // EmailMsg.To.Add(new MailAddress(gidecekmailler));// yönetim panelden girilen maile mesaj gidecek
            EmailMsg.Subject = "YESİS - Servis Talebi";
            EmailMsg.Body = mailmesaj;
            EmailMsg.IsBodyHtml = true;
            EmailMsg.Priority = MailPriority.Normal;

            SmtpClient MailClient = new SmtpClient(smtpadres);
            MailClient.Credentials = new System.Net.NetworkCredential(gidenmail, mailsifre);

            EmailMsg.To.Add(gidecekmailler);
            try
            {
                MailClient.Send(EmailMsg);
                //Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Mesajınız Gönderildi'); window.location.href ='/iletisim.aspx';</script>");
            }
            catch (Exception ex)
            {

            }


        }

    }
}
