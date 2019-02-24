using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bildExamNew.Data;
using bildExamNew.DTO;
using bildExamNew.Models;
using bildExamNew.Repository;
using exam.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bildExamNew.Controllers
{
    [Route("api/[controller]")]
    public class DeviceTypeController : Controller
    {
        private readonly IDeviceTypeRepository _repository;
        private readonly IMapper _mapper;

        public DeviceTypeController(IDeviceTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        ///  Action for creating or updating device type 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateDeviceType([FromBody] DeviceTypeDTO deviceType)
        {
            var newDeviceType = _mapper.Map<DeviceTypes>(deviceType);

            if (deviceType.Id != null)
            {
                await _repository.UpdateDeviceType(newDeviceType);
            }
            else
            {
                await _repository.CreateDeviceType(newDeviceType);
            }
            return Ok(newDeviceType);
        }

        /// <summary>
        ///  Action for getting single device type by ID
        /// </summary>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceType(int id)
        {
            var deviceType = await _repository.GetDeviceType(id);
            var deviceTypeForReturn = _mapper.Map<DeviceTypeForReturnDTO>(deviceType);
            return Ok(deviceTypeForReturn);
        }

        /// <summary>
        ///  Action for getting all device types
        /// </summary>

        [HttpGet]

        public async Task<IActionResult> GetDeviceTypes()
        {
            var deviceTypes = await _repository.GetDeviceTypes();
            var deviceTypesForReturn = new List<DeviceTypeForReturnDTO>();

            //getting hierarhical view of type list

            foreach (var type in deviceTypes)
            {
                if (type.ParentTypeId == null)
                {
                    var memberForReturn = _mapper.Map<DeviceTypeForReturnDTO>(type);
                    deviceTypesForReturn.Add(memberForReturn);
                }
            }

            return Ok(deviceTypes);
        }

        /// <summary>
        ///  Action for deleting device type
        /// </summary>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            //if device with this type exist, you can't delete this type
            try
            {
                await _repository.DeleteDeviceType(id);
                return Ok();
            }
            catch
            {
                return BadRequest("Can't delete this type");
            }

        }
        [HttpGet("properties/{devicetypeId}")]
        public async Task<IActionResult> GetProperties(int devicetypeId) {
           var properties =  await _repository.GetDeviceTypeProperties(devicetypeId);
           var propertiesForReturn = _mapper.Map<IEnumerable<DevicePropertyForReturnTypeDTO>>(properties);
            return Ok(propertiesForReturn);
        }
    }
}