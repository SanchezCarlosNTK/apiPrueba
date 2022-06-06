using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filesApi.Models
{
    public class AdminArch
    {
        public int uid { get; set; }
        public string nombreArchivo { get; set; }
        public int size { get; set; }
        public Status status { get; set; }

    }
    public class Status
    {
       public Load upload { get; set; }
       public Load download { get; set; }

    }
    public class Load
    {
       public string user { get; set; }
       public string tmp { get; set; }

    }
}