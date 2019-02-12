using System.Collections.Generic;
using exam.DTO;

namespace bildExamNew.DTO
{
    public class DeviceForCreatingOrUpdatingDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? DeviceTypeId { get; set; }

        public ICollection<DevicePropertyValueForCreatingOrUpdatingDTO> PropertyValues { get; set; }
    }
}