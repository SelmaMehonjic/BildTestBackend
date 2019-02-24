using bildExamNew.DTO;

namespace exam.DTO
{
    public class DevicePropertyValueForCreatingOrUpdatingDTO
    {
        public int? Id { get; set; }
public string name { get; set; }
        public int? DeviceTypePropertyId { get; set; }
        public int? DeviceId { get; set; }
        public string Value { get; set; }

  
    }
}