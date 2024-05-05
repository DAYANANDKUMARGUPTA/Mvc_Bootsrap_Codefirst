using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Bootsrap_Codefirst.Models
{
    public class tbluser
    {
        [Key]
        public int uid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int salary { get; set; }
        public int country { get; set; }

        public int state { get; set; }


    }
}