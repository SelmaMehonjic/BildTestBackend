using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bildExamNew.Data;
using bildExamNew.Models;
using BildTestBackend.Repository;
using exam.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bildExamNew.Repository
{
    // Concrete implementacion of IDeviceRepository
    public class DeviceRepository : IDeviceRepository
    {
        //Communication with database initializing _context field
        private readonly DataContext _context;
        private readonly IUnitOfWorkRepository _repository;

        public DeviceRepository(DataContext context, IUnitOfWorkRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task CreateDevice(Device device)
        {
            //Adding new device
            await _context.Devices.AddAsync(device);
            //Adding property value
            await _context.DevicePropertyValues.AddRangeAsync(device.PropertyValues);
            await _repository.SaveChanges();
        }

        public async Task CreatePropertyValue(DevicePropertyValues propertyValue)
        {
            //Adding property value, need this method for adding property value while updating device information
            await _context.DevicePropertyValues.AddAsync(propertyValue);
            await _repository.SaveChanges();
        }

        public async Task DeleteDevice(int id)
        {
            var deleted = await GetDevice(id);
            _context.Devices.Remove(deleted);
            await _repository.SaveChanges();


        }

        public async Task<Device> GetDevice(int id)
        {
            var devices = await _context.Devices
            //Loooking for specific property values then include all necessary data, then choose specific device
            .Where(t => t.PropertyValues.Any(e => e.DeviceId == id))
            .Include(t => t.PropertyValues).ThenInclude(d => d.DeviceTypeProperty).ThenInclude(d => d.DeviceType)
            .FirstOrDefaultAsync(p => p.Id == id);
            return devices;
        }


        public async Task<IEnumerable<Device>> SearchDevices(PagingAndFilteringDTO search)
        {
            var searchDevices = await _context.Devices
            .Where(p => (search.FilterBy == null || p.Name.Contains(search.FilterBy) || p.DeviceType.Name.Contains(search.FilterBy)) &&
            (p.PropertyValues.Any(d => search.PropertyValue == null || d.Value == search.PropertyValue)) &&
            (search.GreatherThan == null || p.Price > search.GreatherThan) &&
            (search.GreatherThanOrEqual == null || p.Price >= search.GreatherThanOrEqual) &&
            (search.LessThan == null || p.Price < search.LessThan) &&
            (search.LessThanOrEqual == null || p.Price <= search.LessThanOrEqual) &&
            (search.AfterDate == null || p.CreatedDate > search.AfterDate) &&
            (search.AfterOrEqualDate == null || p.CreatedDate >= search.AfterOrEqualDate) &&
            (search.BeforeDate == null || p.CreatedDate < search.BeforeDate) &&
            (search.BeforeOrEqualDate == null || p.CreatedDate <= search.BeforeOrEqualDate))
            .Include(p => p.PropertyValues)
            .ThenInclude(p => p.DeviceTypeProperty)
            .Skip((search.PageNumber - 1) * search.DeviceNumberPerPage)
            .Take(search.DeviceNumberPerPage)
            .ToListAsync();
            return searchDevices;
        }


        public async Task<Device> UpdateDevice(Device device)
        {
            //update device
            _context.Devices.Update(device);

            //Update property values
            _context.DevicePropertyValues.UpdateRange(device.PropertyValues);
            await _repository.SaveChanges();
            return device;
        }

    }
}