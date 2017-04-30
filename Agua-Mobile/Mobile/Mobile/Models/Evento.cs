using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Models
{
    class Evento : IEvent
    {
       
        public string image { get; set; }

        public void getColor()
        {
            if(result == 2)
            {
                this.image = "ms-appx:///Images/rojo.png";
            }
            else if(result == 1)
            {
                this.image = "ms-appx:///Images/amarillo.png";
            }
            else
            {
                this.image = "ms-appx:///Images/verde.png";
            }
        }
    }
}
