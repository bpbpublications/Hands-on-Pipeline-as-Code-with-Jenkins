using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSForm.Models
{
    public class CalculatorModel
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public double Result { get; set; }
        public string Operation { get; set; } = "add";

    }
   
}