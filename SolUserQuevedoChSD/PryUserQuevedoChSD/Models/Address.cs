using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryUserQuevedoChSD.Models
{
    public class Address
    {

        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public Geo geo { get; set; }
    }
}