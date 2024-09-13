using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JIPT_Institute.Models
{
    public class GalleryModel
    {
        public int cid { get; set; }

        public string name { get; set; }

        [Required(ErrorMessage = "Please upload file!")]
        [Display(Name = "Upload Image:")]
        public HttpPostedFileBase ImgPath { get; set; }

        public string getImage { get; set; }
    }
}