using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code.id.Test_AXA.Models { 
    public class MasterModel{
        public IList<Data> Datas { get; set; }
    }
    public class Data
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }

    }
}
