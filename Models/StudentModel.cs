﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIPT_Institute.Models
{
    public class StudentModel
    {
        public int sId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string Course { get; set; }

    }
}