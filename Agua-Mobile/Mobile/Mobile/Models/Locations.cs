using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Models
{
    class Locations : Ilocations
    {
        public double lon { get; set; }
        public double lan { get; set; }
        public double deep{ get; set; }
        public string area { get; set; }

        public Locations( string lan, string lon, string deep, string area)
        {
            this.lon = double.Parse(lon);
            this.lan = double.Parse(lan);
            this.deep = double.Parse(deep);
            this.area = area;

        }
    }
}
