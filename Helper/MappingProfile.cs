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
            CreateMap<DevicePropertyValues, DevicePropertyValueForReturnDTO>()
                       .ForMember(dest => dest.Name, opt =>
                       {
                           opt.MapFrom(src => src.DeviceTypeProperty.Name);
                       })
                          .ForMember(dest => dest.deviceTypePropertyId, opt =>
                          {
                              opt.MapFrom(src => src.DeviceTypePropertyId);
                          }); ;
            CreateMap<DeviceTypes, DeviceTypeForReturnDTO>()
            .ForMember(dest => dest.ParentTypeName, opt =>
            {
                opt.MapFrom(src => src.ParentType.Name);
            });
        }
    }
}