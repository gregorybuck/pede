using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatriciaEdgarAndDonEdgar.Models;

namespace PatriciaEdgarAndDonEdgar.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        public ActionResult Index(String page)
        {
            String errMsg = string.Empty;
            
            if (page == null) page = "Home";

            try
            {
                PatriciaEdgarAndDonEdgar.Common.Datahandler.logVisit(page, Request.ServerVariables["REMOTE_ADDR"].ToString(), null, null, null, null, null);
            }
            catch
            {
                // could log error:  if page takes too long to load, most likely this
            }
          
            if (page.ToLower() == "home")
            {
                return View();
            }
            else
            {
                Models.iteminfo iInfo = new Models.iteminfo();
                String pagefilename = PatriciaEdgarAndDonEdgar.Common.Utils.removeEverythingbutAlphaNum(page).ToLower();

                //get HTML for the book and return
                String blurbfile = Request.PhysicalApplicationPath + "Content\\Page\\" + pagefilename + ".html";
                String blurb = string.Empty;
                try
                {
                    blurb = System.IO.File.ReadAllText(blurbfile, System.Text.Encoding.ASCII);
                }
                catch (Exception ex)
                {
                    String errFile = Request.PhysicalApplicationPath + "Content\\error\\errMsg.html";
                    blurb = System.IO.File.ReadAllText(errFile, System.Text.Encoding.ASCII);
                    blurb = blurb.Replace("@@errmsg@@", ex.Message);
                }

                iInfo.itemname = page;
                iInfo.itemblurb = blurb;

                return View("ShowItem", iInfo);
            }
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

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
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
