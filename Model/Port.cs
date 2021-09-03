using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.Model
{
    public class Port
    {
        public string PortName { get; set; }
        public GeoCordinate GeoCordinate { get; set; }
        public Port()
        {
            GeoCordinate = new GeoCordinate();
        }
    }
}
