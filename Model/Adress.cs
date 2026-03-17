using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Adress
    {
        public string Provice {get;set; }
        public string City {get;set; }
        public string County{get;set; }
        public string Road{get;set; }
        public string Number{get;set; }
        public override string ToString()
        {
            return $"{Provice}{City}{County}{Road}{Number}\n";
        }
    }
}
