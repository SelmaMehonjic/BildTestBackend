using System.Collections.Generic;
using bildExamNew.DTO;

namespace exam.DTO
{
    public class DeviceTypeForReturnDeviceDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<DeviceTypePropertyForCreatingOrUpdatingDTO> TypeProperties { get; set; }

        public virtual DeviceTypeForReturnDeviceDTO ParentType { get; set; }

    }
}