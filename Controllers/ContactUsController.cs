using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatriciaEdgarAndDonEdgar.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpGet]
        public ActionResult ContactUs()
        {
            // Setup model before passing in
            Models.contactinfo model = new Models.contactinfo();
            model.sendstatusmessage = string.Empty;
            model.sendstatus = string.Empty;
            return View(model);
        }

        [HttpPost]
        public ActionResult ContactUs(Models.contactinfo contactinfo)
        {

            contactinfo.sendstatusmessage = "Your message was sent successfully";
            contactinfo.sendstatus = "OK";

            try
            {

                if (contactinfo.Email.Trim() != contactinfo.EmailVerify.Trim())
                {
                    throw new Exception("Email address details do not match.  Please re-enter your email address.");
                }

                //send email
                System.Net.Mail.SmtpClient mysmtpClient = new System.Net.Mail.SmtpClient("mail.patriciaedgaranddonedgar.com", 25);
                mysmtpClient.Credentials = new System.Net.NetworkCredential("postmaster@patriciaedgaranddonedgar.com", "lahabana01");
                String mailFrom = "postmaster@patriciaedgaranddonedgar.com";
                String mailTo = "donandpatriciaedgar@bigpond.com"; 
                String mailSubject = contactinfo.subject;
                String mailBody = "You have a message from " + contactinfo.Email.ToString() + " via the website";
                mailBody +=  "\r\n" + "Message: " + contactinfo.message;
                System.Net.Mail.MailMessage myMailMessage = new System.Net.Mail.MailMessage(mailFrom, mailTo, mailSubject, mailBody);
                mysmtpClient.Send(myMailMessage);
                
            }
            catch (Exception ex)
            {
                contactinfo.sendstatusmessage = "Your message was not sent. [" + ex.Message + "]";
                contactinfo.sendstatus = "ERR";
            }

            return View(contactinfo);

        }
        
        //
        // GET: /ContactUs/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ContactUs/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ContactUs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ContactUs/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ContactUs/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ContactUs/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ContactUs/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ContactUs/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
