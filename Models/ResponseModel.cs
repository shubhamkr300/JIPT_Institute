﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIPT_Institute.Models
{
    public class ResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }
    }
}