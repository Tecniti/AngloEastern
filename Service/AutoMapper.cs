using AngloEastern.Model;
using AngloEastern.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.Service
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Port, NearestPortViewModel>();
        }
    }
}
