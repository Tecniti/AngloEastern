using AngloEastern.Model;
using AngloEastern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.Service
{
    public interface IShipService
    {
        void AddShipDetail(AddShipDetailViewModel addShipDetailViewModel);
        IEnumerable<Ship> GetAllShipDetails();
        string UpdateVelocity(UpdateVelocityViewModel updateVelocityViewModel);
        object GetNerestPort(int shipID);
    }
}
