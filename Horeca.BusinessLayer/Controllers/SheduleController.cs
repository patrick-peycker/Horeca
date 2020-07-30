using Horeca.BusinessLayer.Extensions;
using Horeca.BusinessLayer.Models;
using Horeca.DataAccessLayer.Entities;
using Horeca.DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Horeca.BusinessLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SheduleController : ControllerBase
	{
		private IRepository<Shedule> _repository;

		public SheduleController(IRepository<Shedule> repository)
		{
			_repository = repository;
		}
		// GET: api/<ValuesController>
		[HttpGet]
		public async Task<IEnumerable<SheduleModel>> Get()
		{
			var content = await _repository.GetAllAsync();
			return content.Select(x=>x.ToModel());
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public async Task<SheduleModel> Get(int id)
		{
			var content = await _repository.GetByIdAsync(id);
			return content.ToModel();
		}

		// POST api/<ValuesController>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<int> Post([FromBody] string content)
		{
			var value = JsonConvert.DeserializeObject<SheduleModel>(content);
			return await _repository.CreateAsync(value.ToEntity());
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		[ValidateAntiForgeryToken]
		public async Task<int> Put([FromBody] string content)
		{
			var value = JsonConvert.DeserializeObject<SheduleModel>(content);
			return await _repository.UpdateAsync(value.ToEntity());
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		[ValidateAntiForgeryToken]
		public async Task<int> Delete(int id)
		{
			return await _repository.DeleteAsync(id);
		}
	}
}
