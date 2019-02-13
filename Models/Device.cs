using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bildExamNew.Models
{
    public class Device
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DeviceTypes DeviceType { get; set; }
        public int DeviceTypeId { get; set; }
        public ICollection<DevicePropertyValues> PropertyValues {get; set;}
        public decimal Price { get; set; }

    }
}