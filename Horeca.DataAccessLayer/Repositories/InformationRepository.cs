using Horeca.DataAccessLayer.Entities;
using Horeca.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Horeca.DataAccessLayer.Repositories
{
	public class InformationRepository : IRepository<Information>
	{
		private readonly HorecaContext _context;

		public InformationRepository(HorecaContext context)
		{
			_context = context;
		}

		public async Task<int> CreateAsync(Information task)
		{
			await _context.Informations.AddAsync(task);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> DeleteAsync(int id)
		{
			var task = await GetByIdAsync(id);
			_context.Informations.Remove(task);
			return await _context.SaveChangesAsync();
		}

		public async Task<List<Information>> GetAllAsync()
		{
			return await _context.Informations.ToListAsync();
		}

		public async Task<Information> GetByIdAsync(int id)
		{
			return await _context.Informations.FirstAsync(x => x.InformationId == id);
		}

		public async Task<int> UpdateAsync(Information task)
		{
			_context.Informations.Update(task);
			return await _context.SaveChangesAsync();
		}
	}
}
