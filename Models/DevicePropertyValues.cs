namespace bildExamNew.Models
{
    public class DevicePropertyValues
    {
        public int Id { get; set; }
        public Device Device { get; set; }
        public int DeviceId { get; set; }
        public DeviceTypeProperties DeviceTypeProperty { get; set; }
        public int DeviceTypePropertyId { get; set; }
        public string Value { get; set; }
    }
}