using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using bildExamNew.DTO;
using bildExamNew.Models;
using exam.DTO;

namespace bildExamNew.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<DeviceTypeDTO, DeviceTypes>();
            CreateMap<DeviceForCreatingOrUpdatingDTO, Device>();
            CreateMap<DeviceTypePropertyForCreatingOrUpdatingDTO, DeviceTypeProperties>();
            CreateMap<DevicePropertyValueForReturnDTO, DevicePropertyValues>();
            CreateMap<DevicePropertyValueForCreatingOrUpdatingDTO, DevicePropertyValues>();

        }
    }
}