using Horeca.DataAccessLayer.Entities;
using Horeca.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Horeca.DataAccessLayer.Repositories
{
	public class IdentificationRepository : IRepository<Identification>
	{
		private readonly HorecaContext _context;

		public IdentificationRepository(HorecaContext context)
		{
			_context = context;
		}

		public async Task<int> DeleteAsync(int id)
		{
			var task = await GetByIdAsync(id);
			_context.Identifications.Remove(task);
			return await _context.SaveChangesAsync();
		}

		public async Task<List<Identification>> GetAllAsync()
		{
			return await _context.Identifications.Include(x => x.Informations).ToListAsync();
		}

		public async Task<Identification> GetByIdAsync(int id)
		{
			return await _context.Identifications.Include(x => x.Informations).FirstAsync(x => x.IdentificationId == id);
		}

		public async Task<int> UpdateAsync(Identification task)
		{
			_context.Identifications.Update(task);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> CreateAsync(Identification task)
		{
			await _context.Identifications.AddAsync(task);
			return await _context.SaveChangesAsync();
		}
	}
}
