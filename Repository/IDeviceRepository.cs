using System.Collections.Generic;
using System.Threading.Tasks;
using bildExamNew.Models;
using exam.Helper;

namespace bildExamNew.Repository
{
    public interface IDeviceRepository
    {
        Task CreateDevice(Device device);
        Task CreatePropertyValue (DevicePropertyValues property);
        Task<Device> UpdateDevice(Device device);
        Task<Device> GetDevice(int id);
        Task DeleteDevice(int id);

        Task<IEnumerable<Device>> SearchDevices(PagingAndFilteringDTO search);


    }
}