using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bildExamNew.Data;
using bildExamNew.Models;
using BildTestBackend.Repository;
using Microsoft.EntityFrameworkCore;

namespace bildExamNew.Repository
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly DataContext _context;
        private readonly IUnitOfWorkRepository _repository;

        public DeviceTypeRepository(DataContext context, IUnitOfWorkRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task CreateDeviceType(DeviceTypes deviceType)
        {
            //Create type

            await _context.DeviceTypes.AddAsync(deviceType);

            //Create properties

            await _context.DeviceTypesProperties.AddRangeAsync(deviceType.TypeProperties);

            await _repository.SaveChanges();
        }

        public async Task DeleteDeviceType(int id)
        {

            var deleted = await GetDeviceType(id);
            _context.DeviceTypes.Remove(deleted);
            await _repository.SaveChanges();


        }

        public async Task<DeviceTypes> GetDeviceType(int id)
        {
            var deviceTypes = await GetDeviceTypes();
            var deviceType = deviceTypes.FirstOrDefault(t => t.Id == id);
            return deviceType;
        }

        public async Task<IEnumerable<DeviceTypes>> GetDeviceTypes()
        {
            var deviceTypes = await _context.DeviceTypes
            .Include(t => t.TypeProperties)
            .Include(t => t.ParentType)
            .ToListAsync();
            return deviceTypes;
        }

        public async Task<DeviceTypes> UpdateDeviceType(DeviceTypes deviceType)
        {
            //Update type
            if (deviceType.TypeProperties != null)
            {
                //Update properties
                _context.DeviceTypesProperties.UpdateRange(deviceType.TypeProperties);
            }
            _context.DeviceTypes.Update(deviceType);
            await _repository.SaveChanges();
            return deviceType;
        }
    }
}