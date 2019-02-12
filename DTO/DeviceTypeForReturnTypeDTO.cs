using System.Collections.Generic;
using bildExamNew.DTO;

namespace exam.DTO
{
    public class DeviceTypeForReturnTypeDTO
    {
          public DeviceTypeForReturnTypeDTO()
        {
            List<DeviceTypeForReturnTypeDTO> ChildrenType = new List<DeviceTypeForReturnTypeDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual DeviceTypeForReturnTypeDTO ParentType { get; set; }
        public ICollection<DevicePropertyValueForReturnTypeDTO> TypeProperties { get; set; }
        public virtual ICollection<DeviceTypeForReturnTypeDTO> ChildrenType { get; set; }


    }
}