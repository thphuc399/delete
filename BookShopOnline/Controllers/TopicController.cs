using BookShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic
        private DB_BookShop _contextDB = new DB_BookShop();
        public ActionResult GetTop5TopicPartial()
        {
            var lstTopic = _contextDB.ChuDes.OrderBy(x=>x.TenChuDe).Take(5).ToList();
            return PartialView(lstTopic);
        }
        public ActionResult GetListAll()
        {
            var lstAll = _contextDB.ChuDes.OrderBy(x => x.TenChuDe).ToList();
            ViewBag.message_count=lstAll.Count;
            return View(lstAll);
        }
    }
}