using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RunningMVC.Data.Entities;
using RunningMVC.ViewModels;

namespace RunningMVC.Data
{
    public class RunnerMappingProfile : Profile
    {
        public RunnerMappingProfile()
        {
            CreateMap<Runner, RunnerViewModel>()
                .ForMember(r => r.RunnerId, ex => ex.MapFrom(r => r.Id))
                .ReverseMap();
        }
    }
}
