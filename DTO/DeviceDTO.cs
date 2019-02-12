using System.Collections.Generic;
using exam.DTO;

namespace bildExamNew.DTO
{
    public class DeviceDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DeviceTypeDTO DeviceType { get; set; }
        public int? DeviceTypeId { get; set; }

        public ICollection<DevicePropertyValueDTO> PropertyValues { get; set; }
    }
}