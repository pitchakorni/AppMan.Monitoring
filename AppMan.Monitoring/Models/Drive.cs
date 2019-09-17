using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMan.Monitoring.Models
{
    public class Drive
    {
        public string Name { get; set; }
        public long TotalSize { get; set; }
        public long TotalFreeSpace { get; set; }
        public long TotalUsedSpace { get; set; }
    }
}
