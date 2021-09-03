using AngloEastern.Model;
using AngloEastern.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.Service
{
    public class ShipService : IShipService
    {
        private readonly IMapper _mapper;
        private List<Ship> Ships { get; set; }
        private List<Port> Ports { get; set; }
        private Random _random { get; set; }
        public ShipService(IMapper mapper)
        {
            Ships = new List<Ship>();
            _random = new Random();
            Ports = new List<Port>();
            for (int i = 0; i < _random.Next(10, 100); i++)
            {
                Port port = new Port();
                port.PortName = $"Port_{i}";
                port.GeoCordinate.Latitude = 4 * i;
                port.GeoCordinate.Longitude = 4 * i;
                Ports.Add(port);
            }

            this._mapper = mapper;
        }

        /// <summary>
        /// add ships to the system 
        /// </summary>
        /// <param name="addShipDetailViewModel">ShipName,Longitude,Latitude</param>
        public void AddShipDetail(AddShipDetailViewModel addShipDetailViewModel)
        {
            Ship ship = new Ship();
            ship.ID = Ships.Count() + 1;
            ship.ShipName = addShipDetailViewModel.ShipName;
            ship.GeoCordinate.Longitude = addShipDetailViewModel.Longitude;
            ship.GeoCordinate.Latitude = addShipDetailViewModel.Latitude;
            Ships.Add(ship);
        }

        /// <summary>
        /// Get All ship deails
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ship> GetAllShipDetails()
        {
            return Ships;
        }

        /// <summary>
        ///  update velocity of a ship
        /// </summary>
        /// <param name="updateVelocityViewModel"></param>
        /// <returns></returns>
        public string UpdateVelocity(UpdateVelocityViewModel updateVelocityViewModel)
        {
            var ship = Ships.FirstOrDefault(i => i.ID == updateVelocityViewModel.ShipID);
            if (ship == null)
            {
                return $"Not found any ship with id {updateVelocityViewModel.ShipID}";
            }
            ship.Velocity = updateVelocityViewModel.Velocity;
            return $"Successfully update the velocity for the ship {updateVelocityViewModel.ShipID}";
        }

        /// <summary>
        /// see the closest port to a ship with estimated arrival time to the port together with other details
        /// </summary>
        /// <param name="shipID"></param>
        /// <returns></returns>
        public object GetNerestPort(int shipID)
        {
            NearestPortViewModel nearestPort = null;
            double minDistance = double.MaxValue;
            Ship ship = Ships.FirstOrDefault(i => i.ID == shipID);
            if (ship == null)
                return $"Not found any ship with id {shipID}";
            foreach (var port in Ports)
            {
                var distance = Math.Pow(ship.GeoCordinate.Latitude - port.GeoCordinate.Latitude, 2) 
                    + Math.Pow(ship.GeoCordinate.Longitude - port.GeoCordinate.Longitude, 2);
                if(minDistance>distance)
                {
                    nearestPort = _mapper.Map<NearestPortViewModel>(port);
                    nearestPort.Distance = distance;
                    if(ship.Velocity!=0)
                    nearestPort.Time = Math.Round(distance / ship.Velocity, 2);
                    minDistance = distance;
                }
            }
            return nearestPort;
        }
    }
}
