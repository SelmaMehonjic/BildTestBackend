using System.Collections.Generic;

namespace bildExamNew.Models
{
    public class DeviceTypes
    {
        public DeviceTypes()
        {
            List<DeviceTypes> ChildrenType = new List<DeviceTypes>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentTypeId { get; set; }
        public virtual DeviceTypes ParentType { get; set; }
        public ICollection<DeviceTypeProperties> TypeProperties { get; set; }
        public virtual ICollection<DeviceTypes> ChildrenType { get; set; }




    }
}