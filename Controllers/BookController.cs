using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatriciaEdgarAndDonEdgar.Models;

namespace PatriciaEdgarAndDonEdgar.Controllers
{
    public class BookController : Controller
    {
        // GET: /Book/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowBook(String bookname)
        {
            Models.iteminfo iInfo = new Models.iteminfo();
            String bookfilename = PatriciaEdgarAndDonEdgar.Common.Utils.removeEverythingbutAlphaNum(bookname).ToLower();

            //get HTML for the book and return
            String blurbfile = Request.PhysicalApplicationPath + "Content\\Book\\" + bookfilename + ".html";
            String blurb = string.Empty;
            try
            {
                blurb = System.IO.File.ReadAllText(blurbfile, System.Text.Encoding.ASCII);
                PatriciaEdgarAndDonEdgar.Common.Datahandler.logVisit(bookname, Request.ServerVariables["REMOTE_ADDR"].ToString(), null, null, null, null, null);
            }
            catch (Exception ex)
            {
                String errFile = Request.PhysicalApplicationPath + "Content\\error\\errMsg.html";
                blurb = System.IO.File.ReadAllText(errFile, System.Text.Encoding.ASCII);
                blurb = blurb.Replace("@@errmsg@@", ex.Message);
            }

            iInfo.itemname = bookname;
            iInfo.itemblurb = blurb;

            return View("ShowItem", iInfo);
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

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
        // GET: /Book/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Book/Edit/5

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
        // GET: /Book/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Book/Delete/5

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
