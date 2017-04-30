using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Models
{
    public interface Ilocations
    {
        double lon { get; set; }
        double lan { get; set; }
        double deep{ get; set; }
        string area { get; set; }

    }
}
