using System.Collections.Generic;
using exam.DTO;

namespace bildExamNew.DTO
{
    public class DeviceForViewDTO
    {
   
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceTypeForViewDTO DeviceType { get; set; }
        public int DeviceTypeId { get; set; }
        public int Price { get; set; }
        // public ICollection<DevicePropertyValueForViewDTO> PropertyValues { get; set; }
        
    }
}