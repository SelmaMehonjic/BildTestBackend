using System.Collections.Generic;
using exam.DTO;

namespace bildExamNew.DTO
{
    public class DeviceForReturnSingleDeviceDTO
    {
   
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceTypeForReturnDeviceDTO DeviceType { get; set; }
        public int DeviceTypeId { get; set; }
        public int Price { get; set; }
        
    }
}