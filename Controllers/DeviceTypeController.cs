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
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceType(int id)
        {
            var deviceType = await _repository.GetDeviceType(id);
            var deviceTypeForReturn = _mapper.Map<DeviceTypeForReturnTypeDTO>(deviceType);
            return Ok(deviceTypeForReturn);
        }

        [HttpGet]

        public async Task<IActionResult> GetDeviceTypes()
        {
            var deviceTypes = await _repository.GetDeviceTypes();
            var deviceTypesForView = new List<DeviceTypeForReturnTypeDTO>();
            foreach (var member in deviceTypes)
            {
                if (member.ParentTypeId == null)
                {
                    var memberForReturn = _mapper.Map<DeviceTypeForReturnTypeDTO>(member);
                    deviceTypesForView.Add(memberForReturn);
                }
            }
            return Ok(deviceTypesForView);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            try 
            {
                await _repository.DeleteDeviceType(id);
                return Ok();
            }
            catch
            {
                return BadRequest("Cant delete this type");
            }
            
        }
    }
}