using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatriciaEdgarAndDonEdgar.Models;

namespace PatriciaEdgarAndDonEdgar.Controllers
{
    public class SpeechController : Controller
    {
        public ActionResult ShowSpeech(String speechname)
        {
            Models.iteminfo iInfo = new Models.iteminfo();
            String articlefilename = PatriciaEdgarAndDonEdgar.Common.Utils.removeEverythingbutAlphaNum(speechname).ToLower();

            //get HTML for the article and return
            String blurbfile = Request.PhysicalApplicationPath + "Content\\Speech\\" + articlefilename + ".html";
            String blurb = string.Empty;
            try
            {
                blurb = System.IO.File.ReadAllText(blurbfile, System.Text.Encoding.ASCII);
                PatriciaEdgarAndDonEdgar.Common.Datahandler.logVisit(speechname, Request.ServerVariables["REMOTE_ADDR"].ToString(), null, null, null, null, null);
            }
            catch (Exception ex)
            {
                String errFile = Request.PhysicalApplicationPath + "Content\\error\\errMsg.html";
                blurb = System.IO.File.ReadAllText(errFile, System.Text.Encoding.ASCII);
                blurb = blurb.Replace("@@errmsg@@", ex.Message);
            }

            iInfo.itemname = speechname;
            iInfo.itemblurb = blurb;

            return View("ShowArticle", iInfo);
        }

        // GET: /Speech/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Speech/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Speech/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Speech/Create

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
        // GET: /Speech/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Speech/Edit/5

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
        // GET: /Speech/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Speech/Delete/5

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
