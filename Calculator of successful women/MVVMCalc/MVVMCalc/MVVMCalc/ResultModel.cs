using SQLite.Net;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalc
{
    public class ResultModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Position { get; set; }
        public string Name { get; set;}
        public string Age { get; set; }
        public string Kids { get; set; }
        public bool Cats { get; set; }
        public bool Dogs { get; set; }
        public bool Girls { get; set; }
        public bool Boys { get; set; }
        public bool Career { get; set; }
        public bool Family { get; set; }
        public bool Yourself { get; set; }
        public string Answer { get; set; }
    }
}
