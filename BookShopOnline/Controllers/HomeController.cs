using BookShopOnline.Models;
using BookShopOnline.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Controllers
{
    public class HomeController : Controller
    {
        private DB_BookShop _contextDB = new DB_BookShop();
        // GET: Home
        public ActionResult Index()
        {
            //var lstBook = _contextDB.Saches.ToList();
            // c1var lstBook = _contextDB.Saches.Where(x => x.Moi == 1).ToList();
            //c2
            //var lstBook = (from  b in _contextDB.Saches
            //              where b.Moi == 1 
            //             c1 select b).OrderBy(x => x.TenSach).Take(4).ToList();
            //             c2 select new BookModel();
            //{
            //masach = ms.MaSach
            //}
            var lstBook = (from b in _contextDB.Saches
                           join cd in _contextDB.ChuDes on b.MaChuDe equals cd.MaChuDe
                           where b.Moi == 1
                           select new Sach()
                           {
                               MaSach = b.MaSach,
                               TenSach = b.TenSach,
                               //TenChuDe = cd.TenChuDe,
                           }).ToList();

            //var lstBook = (from p in _contextDB.Saches
            //               join cd in _contextDB.ChuDes on p.MaChuDe equals cd.MaChuDe
            //               select new
            //               {
            //                   p.TenSach,
            //                   p.GiaBan,
            //                   cd.TenChuDe
            //               }).Take(10).ToList();


            ViewBag.message = lstBook.Count();
            return View(lstBook);
        }
        public ActionResult GetIndexTopic(int id)
        {
            var lstBook = _contextDB.Saches.Where(x=>x.MaChuDe == id).OrderByDescending(x=>x.GiaBan).ToList();
            if (lstBook == null)
            {
                ViewBag.message = "Không có sách!";
                return View();
            }    
            int sl = lstBook.Count;
            ViewBag.message = "Có sách" + sl.ToString();
            return View(lstBook);
        }
    }
}