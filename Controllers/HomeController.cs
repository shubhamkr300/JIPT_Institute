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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<GalleryModel> cList = HomeViewModel.getImages();
            ImgVideoListModel imgmodel = new ImgVideoListModel();
            imgmodel.carouselList = cList;

            if (cList != null)
            {
                return View(imgmodel);

            }
            else
            {
                ViewData["Message"] = "Item not present";
            }
            return View();
        }

        [HttpPost]
        public JsonResult Register(StudentModel student)
        {
            ResponseModel resp = RegisterViewModel.SaveUser(student);
            if (resp.Status == true)
            {
                ViewBag.Message = resp.Message;
                string data = resp.Message;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false, message = resp.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Gallery()
        {
            List<GalleryModel> imglist = GalleryViewModel.getImages();
            List<VideoModel> vdolist = GalleryViewModel.getVideos();

            ImgVideoListModel imgmodel = new ImgVideoListModel();
            imgmodel.ImgList = imglist;
            imgmodel.VdoList = vdolist;
            if (imgmodel !=null)
            {
                return View(imgmodel);

            }
            else
            {
                ViewData["Message"] = "Item not present";
            }
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

    }
}