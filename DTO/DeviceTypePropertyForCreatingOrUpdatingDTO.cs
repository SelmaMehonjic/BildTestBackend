using System.Collections.Generic;

namespace bildExamNew.DTO
{
    public class DeviceTypePropertyForCreatingOrUpdatingDTO
    {
                public int? Id { get; set; }
        public string Name { get; set; }

        public ICollection<DevicePropertyValueForReturnDTO> PropertiesValue { get; set; }
    }
}