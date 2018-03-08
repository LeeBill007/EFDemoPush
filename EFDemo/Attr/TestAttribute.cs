using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemo
{
    public class TestAttribute:Attribute
    {
        public string Name { get; set; }

        public TestAttribute(string name)
        {
            this.Name = name;
        }
    }
}