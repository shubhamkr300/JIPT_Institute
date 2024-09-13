using JIPT_Institute.Models;
using JIPT_Institute.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JIPT_Institute.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Carousel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Carousel(GalleryModel gm)
        {
            ResponseModel resp = HomeViewModel.SaveImage(gm);
            if (resp.Status == true)
            {
                ViewData["Message"] = "Image added successfully!";
            }
            else
            {
                ViewData["Message"] = "Image not added";
            }
            return View();
        }

        public ActionResult Images()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Images(GalleryModel gm)
        {
            ResponseModel resp = ImagesViewModel.SaveImage(gm);
            if (resp.Status == true)
            {
                ViewData["Message"] = "Image added successfully!";
            }
            else
            {
                ViewData["Message"] = "Image not added";
            }
            return View();
        }

        public JsonResult getImagesList()
        {
            List<GalleryModel> imgList = GalleryViewModel.getImages();
            return Json(new { data = imgList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Videos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Videos(GalleryModel gm)
        {
            ResponseModel resp = VideosViewModel.SaveVideo(gm);
            if (resp.Status == true)
            {
                ViewData["Message"] = "Image added successfully!";
            }
            else
            {
                ViewData["Message"] = "Image not added";
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

    }
}