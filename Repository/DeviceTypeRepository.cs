using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bildExamNew.Data;
using bildExamNew.Models;
using Microsoft.EntityFrameworkCore;

namespace bildExamNew.Repository
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly DataContext _context;

        public DeviceTypeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateDeviceType(DeviceTypes deviceType)
        {
            //Create type

            await _context.DeviceTypes.AddAsync(deviceType);

            //Create properties
            foreach (var property in deviceType.TypeProperties)
            {
                await _context.DeviceTypesProperties.AddAsync(property);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDeviceType(int id)
        {
 
                var deleted = await GetDeviceType(id);
                _context.DeviceTypes.Remove(deleted);
                await _context.SaveChangesAsync();
       
        }

        public async Task<DeviceTypes> GetDeviceType(int id)
        {
           var deviceTypes = await  GetDeviceTypes();
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
                foreach (var property in deviceType.TypeProperties)
                {
                    _context.DeviceTypesProperties.Update(property);
                }
            }
            _context.DeviceTypes.Update(deviceType);
            await _context.SaveChangesAsync();
            return deviceType;
        }
    }
}