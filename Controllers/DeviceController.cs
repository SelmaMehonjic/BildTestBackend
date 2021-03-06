using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bildExamNew.DTO;
using bildExamNew.Models;
using bildExamNew.Repository;
using BildTestBackend.DTO;
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

        /// <summary>
        ///  Action for creating or updating device 
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateDevice([FromBody] DeviceForCreatingOrUpdatingDTO device)
        {
            var newDevice = _mapper.Map<Device>(device);

            if (device.Id != null)
            {
                     newDevice.CreatedDate = DateTime.Now.Date;
                await _repository.UpdateDevice(newDevice);
            }
            else
            {
                newDevice.CreatedDate = DateTime.Now.Date;
              await _repository.CreateDevice(newDevice);

            }
            return Ok(newDevice);
        }

        /// <summary>
        ///  Action for getting single device by  ID
        /// </summary>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await _repository.GetDevice(id);
            var deviceForReturn = _mapper.Map<DeviceForReturnSingleDeviceDTO>(device);

            return Ok(deviceForReturn);
        }

        /// <summary>
        ///  Action for searching device by specific name, type, property value, createdDate or price
        /// </summary>

        [HttpGet]

        public async Task<IActionResult> SearcForDevice([FromQuery] PagingAndFilteringDTO search)
        {

            var searchDevices = await _repository.SearchDevices(search);
            var deviceForReturn = _mapper.Map<IEnumerable<DeviceForReturnSingleDeviceDTO>>(searchDevices);
            return Ok(deviceForReturn);
        }

        /// <summary>
        ///  Action deleting device 
        /// </summary>

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDevice(int id)
        {
            await _repository.DeleteDevice(id);
            return Ok();
        }
        [HttpGet("list")]

        public async Task<IActionResult> GetDevices()
        {
            var devices = await _repository.GetDevices();
            var list = _mapper.Map<IEnumerable<DeviceForReturnSingleDeviceDTO>>(devices);

            return Ok(list);
        }
        [HttpGet("values/{id}")]

        public async Task<IActionResult> GetDevices(int id)
        {
            var device = await _repository.GetDeviceProperties(id);
            var deviceForReturn = _mapper.Map<DeviceForReturnPropertiesDTO>(device);

            return Ok(deviceForReturn);
        }
    }
}