using System.Collections.Generic;
using bildExamNew.DTO;

namespace exam.DTO
{
    public class DeviceForSearchDTO
    {
               public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DevicePropertyValueForViewDTO> PropertyValues { get; set; }
        public int Price { get; set; }

    }
}