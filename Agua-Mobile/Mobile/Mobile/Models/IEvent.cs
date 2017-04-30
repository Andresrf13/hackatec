using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Models
{
    class IEvent
    {
        public string Nombre { get; set; }
        public double temp { get; set; }
        public double prec { get; set; }
        public double cant { get; set; }
        public int result { get; set; }
    }
}
