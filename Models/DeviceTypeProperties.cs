using System.Collections;
using System.Collections.Generic;

namespace bildExamNew.Models
{
    public class DeviceTypeProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceTypes DeviceType { get; set; }
        public int DeviceTypeId { get; set; }

        public ICollection<DevicePropertyValues> PropertiesValue { get; set; }

    }
}