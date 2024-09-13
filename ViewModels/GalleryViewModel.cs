using JIPT_Institute.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Web;

namespace JIPT_Institute.ViewModels
{
    public class GalleryViewModel
    {
        static InstituteDataDataContext DataContext = new InstituteDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=InstituteDb;User ID=sa;Password=9431353474;Encrypt=False");

        public static List<GalleryModel> getImages()
        {
            ResponseModel resp = new ResponseModel();

            List<GalleryModel> imgList = new List<GalleryModel>();
            var imgs = DataContext.tblImages.ToList();
            try
            {
                if (imgs != null)
                {

                    foreach (var img in imgs)
                    {
                        var GalleryModel = new GalleryModel()
                        {
                            cid = img.cid,
                            name = img.ImgName,
                            getImage = ("~/user_images/") + Path.GetFileName(img.ImgPath)
                        };
                        imgList.Add(GalleryModel);
                    }
                    resp.Status = true;
                    resp.Message = "Food Details Updated Successfully...";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
            }
            return imgList;
        }

        public static List<VideoModel> getVideos()
        {
            ResponseModel resp = new ResponseModel();

            List<VideoModel> vdoList = new List<VideoModel>();
            var imgs = DataContext.tbVideos.ToList();
            try
            {
                if (imgs != null)
                {

                    foreach (var img in imgs)
                    {
                        var VideoModel = new VideoModel()
                        {
                            vid = img.vid,
                            name = img.VdName,
                            getImage = ("~/user_videos/") + Path.GetFileName(img.VdPath)
                        };
                        vdoList.Add(VideoModel);
                    }
                    resp.Status = true;
                    resp.Message = "Food Details Updated Successfully...";
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
            }
            return vdoList;
        }
    }
}