using System.Collections.Generic;
using bildExamNew.DTO;

namespace exam.DTO
{
    public class DeviceTypeForReturnDTO
    {
          public DeviceTypeForReturnDTO()
        {
            List<DeviceTypeForReturnDTO> ChildrenType = new List<DeviceTypeForReturnDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentTypeId {get; set;}
        public string ParentTypeName { get; set; }
        public virtual DeviceTypeForReturnDTO ParentType { get; set; }
        public ICollection<DevicePropertyForReturnTypeDTO> TypeProperties { get; set; }
        public virtual ICollection<DeviceTypeForReturnDTO> ChildrenType { get; set; }


    }
}