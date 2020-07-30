using Horeca.DataAccessLayer.Entities;
using Horeca.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataAccessLayer.Repositories
{
	public class SheduleRepository : IRepository<Shedule>
	{
		private readonly HorecaContext _context;
		public SheduleRepository(HorecaContext context)
		{
			_context = context;
		}

		public async Task<int> CreateAsync(Shedule task)
		{
			await _context.Shedules.AddAsync(task);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> DeleteAsync(int id)
		{
			var task = await GetByIdAsync(id);
			_context.Shedules.Remove(task);
			return await _context.SaveChangesAsync();
		}

		public async Task<List<Shedule>> GetAllAsync()
		{
			return await _context.Shedules.ToListAsync();
		}

		public async Task<Shedule> GetByIdAsync(int id)
		{
			return await _context.Shedules.FirstAsync(x => x.InformationId == id);
		}

		public async Task<int> UpdateAsync(Shedule task)
		{
			_context.Shedules.Update(task);
			return await _context.SaveChangesAsync();
		}
	}
}
