using System.Collections.Generic;
using System.Threading.Tasks;

namespace Horeca.DataAccessLayer.Interfaces
{
	public interface IRepository<Entity> where Entity : class
	{
		Task<List<Entity>> GetAllAsync();
		Task<Entity> GetByIdAsync(int id);
		Task<int> CreateAsync(Entity task);
		Task<int> UpdateAsync(Entity task);
		Task<int> DeleteAsync(int id);
	}
}
