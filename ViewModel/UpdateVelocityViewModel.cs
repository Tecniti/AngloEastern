using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.ViewModel
{
    public class UpdateVelocityViewModel
    {
        [Range(0,double.MaxValue,ErrorMessage ="Value shuold be 0 or greater than 0")]
        public double Velocity { get; set; }
        [Required]
        public int ShipID { get; set; }
    }
}
