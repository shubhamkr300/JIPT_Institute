using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JIPT_Institute.Models;

namespace JIPT_Institute.Models
{
    public class ImgVideoListModel
    {
        public List<GalleryModel> ImgList {  get; set; }
        public List<VideoModel> VdoList { get; set; }

        public List<GalleryModel> carouselList { get; set; }
        public StudentModel Student { get; set; }
    }
}