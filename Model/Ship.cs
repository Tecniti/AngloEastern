using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.Model
{
    public class Ship
    {
        public int ID { get; set; }
        public string ShipName { get; set; }
        public GeoCordinate GeoCordinate { get; set; }
        public double Velocity { get; set; }
        public Ship()
        {
            GeoCordinate = new GeoCordinate();
            Velocity = 0;

        }
    }
}
