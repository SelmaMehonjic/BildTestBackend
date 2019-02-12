using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bildExamNew.DTO;
using bildExamNew.Models;
using bildExamNew.Repository;
using exam.DTO;
using exam.Helper;
using Microsoft.AspNetCore.Mvc;

namespace bildExamNew.Controllers
{
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateDevice([FromBody] DeviceDTO device)
        {
            var newDevice = _mapper.Map<Device>(device);

            if (device.Id != null)
            {
                foreach (var value in device.PropertyValues)
                {
                    if (value.Id == null)
                    {
                        var newValue = _mapper.Map<DevicePropertyValues>(value);
                        await _repository.CreateProperty(newValue);
                    }
                }
                await _repository.UpdateDevice(newDevice);
            }
            else
            {
                await _repository.CreateDevice(newDevice);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await _repository.GetDevice(id);
            var deviceForReturn = _mapper.Map<DeviceForViewDTO>(device);

            return Ok(deviceForReturn);
        }
        [HttpGet]

        public async Task<IActionResult> SearcForDevice([FromQuery] PagingAndFilteringDTO search)
        {

            var searchDevices = await _repository.SearchDevices(search);
            var deviceForReturn = _mapper.Map<IEnumerable<DeviceForSearchDTO>>(searchDevices);
            return Ok(deviceForReturn);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDevice(int id)
        {
            await _repository.DeleteDevice(id);
            return Ok();
        }
    }
}