using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld_API.Models
{
    //Base Class for dataAccess where connection and all dataaccess will be done.
    public class DataAccess
    {
        public string dBConnection { get; set; }

        public int Insert(object i)
        {
            var r = 0;
            return r;
        }

        public void Update(object i)
        {

        }
    }
}