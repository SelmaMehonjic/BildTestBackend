using System.Collections.Generic;

namespace bildExamNew.DTO
{
    public class DeviceTypePropertyDTO
    {
                public int? Id { get; set; }
        public string Name { get; set; }

        public ICollection<DevicePropertyValueForViewDTO> PropertiesValue { get; set; }
    }
}