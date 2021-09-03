using AngloEastern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.ViewModel
{
    public class NearestPortViewModel:Port
    {
        public double Distance { get; set; }
        public double Time { get; set; }
    }
}
