using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje_Kamp.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var sorgu1 = c.Categories.Count().ToString();
            ViewBag.d1 = sorgu1;

            var sorgu2 = c.Headings.Count(x => x.CategoryID == 18);
            ViewBag.d2 = sorgu2;

            var sorgu3 = c.Writers.Count(x => x.WriterName.ToLower().Contains("a"));
            ViewBag.d3 = sorgu3;

            var sorgu4 = (from x in c.Categories orderby x.Headings.Count() descending select x.CategoryName).FirstOrDefault();
            ViewBag.d4 = sorgu4;

            var sorgu5 = Math.Abs(c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false));
            ViewBag.d5 = sorgu5;
            return View();
        }
    }
}