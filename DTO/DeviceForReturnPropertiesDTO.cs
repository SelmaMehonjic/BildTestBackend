using System.Collections.Generic;
using bildExamNew.DTO;
using exam.DTO;

namespace BildTestBackend.DTO
{
    public class DeviceForReturnPropertiesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceTypeForReturnDeviceDTO DeviceType { get; set; }
        public int DeviceTypeId { get; set; }
        public ICollection<DevicePropertyValueForReturnDTO> PropertyValues { get; set; }
        public int Price { get; set; }

    }
}