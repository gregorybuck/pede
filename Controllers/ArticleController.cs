using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatriciaEdgarAndDonEdgar.Models;

namespace PatriciaEdgarAndDonEdgar.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult ShowArticle(String articlename)
        {

            Models.iteminfo iInfo = new Models.iteminfo();
            String articlefilename = PatriciaEdgarAndDonEdgar.Common.Utils.removeEverythingbutAlphaNum(articlename).ToLower();

            //get HTML for the article and return
            String blurbfile = Request.PhysicalApplicationPath + "Content\\Article\\" + articlefilename + ".html";
            String blurb = string.Empty;
            try
            {
                blurb = System.IO.File.ReadAllText(blurbfile, System.Text.Encoding.ASCII);
                PatriciaEdgarAndDonEdgar.Common.Datahandler.logVisit(articlename, Request.ServerVariables["REMOTE_ADDR"].ToString(), null, null, null, null, null);
            }
            catch (Exception ex)
            {
                String errFile = Request.PhysicalApplicationPath + "Content\\error\\errMsg.html";
                blurb = System.IO.File.ReadAllText(errFile, System.Text.Encoding.ASCII);
                blurb = blurb.Replace("@@errmsg@@", ex.Message);
            }

            iInfo.itemname = articlename;
            iInfo.itemblurb = blurb;

            return View("ShowArticle", iInfo);
        }

        // GET: /Article/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Article/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Article/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Article/Create

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
        // GET: /Article/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Article/Edit/5

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
        // GET: /Article/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Article/Delete/5

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
