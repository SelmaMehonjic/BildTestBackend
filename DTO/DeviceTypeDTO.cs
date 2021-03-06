using System.Collections.Generic;

namespace bildExamNew.DTO
{
    public class DeviceTypeDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ParentTypeId { get; set; }
        public ICollection<DeviceTypePropertyForCreatingOrUpdatingDTO> TypeProperties { get; set; }

    }
}