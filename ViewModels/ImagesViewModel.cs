using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using JIPT_Institute.Models;

namespace JIPT_Institute.ViewModels
{
    public class ImagesViewModel
    {
        static InstituteDataDataContext DataContext = new InstituteDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=InstituteDb;User ID=sa;Password=9431353474;Encrypt=False");
        public static ResponseModel SaveImage(GalleryModel fmodel)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                tblImage ct = null;

                if (fmodel.cid == 0)
                {
                    ct = new tblImage();
                    ct.ImgName = fmodel.name;
                    if (fmodel.ImgPath!= null)
                    {
                        ct.ImgPath = LoadImageModel.SaveImage(fmodel.ImgPath);
                    }
                    DataContext.tblImages.InsertOnSubmit(ct);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "Item added successsfully";

                    return resp;
                }
                else
                {
                    ct = (from v in DataContext.tblImages where v.cid == fmodel.cid select v).FirstOrDefault();
                    {
                        ct.ImgName = fmodel.name;

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
            var slist = (from v in DataContext.tblImages
                         select new GalleryModel
                         {
                             cid = (int)v.cid,
                             name = v.ImgName,
                             getImage = v.ImgPath,

                         }).ToList();
            return slist;
        }
    }
}