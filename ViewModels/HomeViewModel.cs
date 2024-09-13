using JIPT_Institute.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JIPT_Institute.ViewModels
{
    public class HomeViewModel
    {
        static InstituteDataDataContext DataContext = new InstituteDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=InstituteDb;User ID=sa;Password=9431353474;Encrypt=False");
        public static ResponseModel SaveImage(GalleryModel fmodel)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                tblCarousel ct = null;

                if (fmodel.cid == 0)
                {
                    ct = new tblCarousel();
                    ct.cName = fmodel.name;
                    if (fmodel.ImgPath != null)
                    {
                        ct.imgPath = LoadImageModel.SaveImage(fmodel.ImgPath);
                    }
                    DataContext.tblCarousels.InsertOnSubmit(ct);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "Item added successsfully";

                    return resp;
                }
                else
                {
                    ct = (from v in DataContext.tblCarousels where v.cid == fmodel.cid select v).FirstOrDefault();
                    {
                        ct.cName = fmodel.name;

                        DataContext.SubmitChanges();
                        resp.Status = true;
                        resp.Message = "Item Updated Successfully...";
                        return resp;
                    }
                }

            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
                return resp;
            }
        }
        public static List<GalleryModel> getImages()
        {
            ResponseModel resp = new ResponseModel();

            List<GalleryModel> imgList = new List<GalleryModel>();
            var imgs = DataContext.tblCarousels.ToList();
            try
            {
                if (imgs != null)
                {

                    foreach (var img in imgs)
                    {
                        var GalleryModel = new GalleryModel()
                        {
                            cid = img.cid,
                            name = img.cName,
                            getImage = ("~/user_images/") + Path.GetFileName(img.imgPath)
                        };
                        imgList.Add(GalleryModel);
                    }
                    resp.Status = true;
                    resp.Message = "Item Updated Successfully...";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
            }
            return imgList;
        }
    }
}