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
            CreateMap<DeviceDTO, Device>();
            CreateMap<DeviceTypePropertyDTO, DeviceTypeProperties>();
            CreateMap<DevicePropertyValueForViewDTO, DevicePropertyValues>();
            CreateMap<DevicePropertyValueDTO, DevicePropertyValues>();

        }
    }
}