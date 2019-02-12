using bildExamNew.DTO;

namespace exam.DTO
{
    public class DevicePropertyValueDTO
    {
        public int? Id { get; set; }
        public DeviceDTO Device { get; set; }
        public int? DeviceId { get; set; }
        public DeviceTypePropertyDTO DeviceTypeProperty { get; set; }
        public int? DeviceTypePropertyId { get; set; }
        public string Value { get; set; }
    }
}