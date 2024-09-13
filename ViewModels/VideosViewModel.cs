using JIPT_Institute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIPT_Institute.ViewModels
{
    public class VideosViewModel
    {
        static InstituteDataDataContext DataContext = new InstituteDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=InstituteDb;User ID=sa;Password=9431353474;Encrypt=False");
        public static ResponseModel SaveVideo(GalleryModel fmodel)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                tbVideo ct = null;

                if (fmodel.cid == 0)
                {
                    ct = new tbVideo();
                    ct.VdName = fmodel.name;
                    if (fmodel.ImgPath != null)
                    {
                        ct.VdPath = LoadVideoModel.SaveVideo(fmodel.ImgPath);
                    }
                    DataContext.tbVideos.InsertOnSubmit(ct);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "Item added successsfully";

                    return resp;
                }
                else
                {
                    ct = (from v in DataContext.tbVideos where v.vid == fmodel.cid select v).FirstOrDefault();
                    {
                        ct.VdName = fmodel.name;

                        DataContext.SubmitChanges();
                        resp.Status = true;
                        resp.Message = "Food Details Updated Successfully...";
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

        public static List<GalleryModel> GetAllImageList()
        {
            var slist = (from v in DataContext.tbVideos
                         select new GalleryModel
                         {
                             cid = (int)v.vid,
                             name = v.VdName,
                             getImage = v.VdPath,

                         }).ToList();
            return slist;
        }
    }
}
