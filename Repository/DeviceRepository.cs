using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bildExamNew.Data;
using bildExamNew.Models;
using exam.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bildExamNew.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateDevice(Device device)
        {
            await _context.Devices.AddAsync(device);
            foreach (var value in device.PropertyValues)
            {
                await _context.DevicePropertyValues.AddAsync(value);
            }
            await _context.SaveChangesAsync();
        }

        public async Task CreateProperty(DevicePropertyValues property)
        {
            await _context.DevicePropertyValues.AddAsync(property);

        }

        public async Task DeleteDevice(int id)
        {
            var deleted = await GetDevice(id);
            _context.Devices.Remove(deleted);
            await _context.SaveChangesAsync();

        }

        public async Task<Device> GetDevice(int id)
        {
            var devices = await _context.Devices
            .Where(t => t.PropertyValues.Any(e => e.DeviceId == id) && t.Id == id)
            .Include(t => t.PropertyValues).ThenInclude(d => d.DeviceTypeProperty).ThenInclude(d => d.DeviceType)
            .ToListAsync();
            return devices[0];
        }


        public async Task<IEnumerable<Device>> SearchDevices(PagingAndFilteringDTO search)
        {
            var searchDevices = await _context.Devices
            .Where(p => p.Name.Contains(search.FilterBy) || p.DeviceType.Name.Contains(search.FilterBy) ||
            (p.DeviceType.Name == search.FilterBy && p.PropertyValues.Any(d => d.Value == search.PropertyValue)) ||
            (p.Price > search.GreatherThan) ||
            (p.Price >= search.GreatherThanOrEqual) ||
            (p.Price < search.LessThan) ||
            (p.Price <= search.LessThanOrEqual) ||
            (p.CreatedDate > search.AfterDate) ||
            (p.CreatedDate >= search.AfterOrEqualDate) ||
            (p.CreatedDate < search.BeforeDate) ||
            (p.CreatedDate <= search.BeforeOrEqualDate))
            .Include(p => p.PropertyValues)
            .ThenInclude(p => p.DeviceTypeProperty)
            .Skip((search.PageNumber - 1) * search.DeviceNumberPerPage)
            .Take(search.DeviceNumberPerPage)
            .ToListAsync();
            return searchDevices;
        }


        public async Task<Device> UpdateDevice(Device device)
        {
            _context.Devices.Update(device);
            foreach (var value in device.PropertyValues)
            {
                _context.DevicePropertyValues.Update(value);
            }
            await _context.SaveChangesAsync();
            return device;
        }

    }
}