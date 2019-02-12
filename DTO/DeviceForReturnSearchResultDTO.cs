using System.Collections.Generic;
using bildExamNew.DTO;

namespace exam.DTO
{
    public class DeviceForReturnSearchResultDTO
    {
               public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DevicePropertyValueForReturnDTO> PropertyValues { get; set; }
        public int Price { get; set; }

    }
}