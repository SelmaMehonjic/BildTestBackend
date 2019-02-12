using System.Collections.Generic;
using bildExamNew.DTO;

namespace exam.DTO
{
    public class DeviceTypeForViewDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<DeviceTypePropertyDTO> TypeProperties { get; set; }

        public virtual DeviceTypeForViewDTO ParentType { get; set; }

    }
}