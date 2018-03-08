using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model
{
    public class ErrorModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ErrorMsg { get; set; }
    }
}