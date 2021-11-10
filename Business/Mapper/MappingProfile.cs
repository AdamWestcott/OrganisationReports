using AutoMapper;
using DataAccess;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<CarbonDbItemsDTO, CarbonDbItems>();
            CreateMap<CarbonDbItems, CarbonDbItemsDTO>();

            CreateMap<OrganisationDTO, Organisation>();
            CreateMap<Organisation, OrganisationDTO>();

            CreateMap<ProjectsDTO, Projects>();
            CreateMap<Projects, ProjectsDTO>();

            CreateMap<SocialDTO, Social>();
            CreateMap<Social, SocialDTO>();
        }
    }
}
