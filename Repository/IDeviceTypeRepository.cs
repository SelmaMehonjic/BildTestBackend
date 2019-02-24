using System.Collections.Generic;
using System.Threading.Tasks;
using bildExamNew.Models;

namespace bildExamNew.Repository
{
    public interface IDeviceTypeRepository
    {
        Task CreateDeviceType(DeviceTypes deviceType);
        Task<DeviceTypes> UpdateDeviceType(DeviceTypes deviceType);
        Task<IEnumerable<DeviceTypes>> GetDeviceTypes();
        Task<DeviceTypes> GetDeviceType(int id);
        Task DeleteDeviceType(int id);
        Task<IEnumerable<DeviceTypeProperties>> GetDeviceTypeProperties(int id);
        Task CreateProperty(DeviceTypeProperties property);

    }
}