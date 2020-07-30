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
	public class IdentificationController : ControllerBase
	{
		private readonly IRepository<Identification> _repository;

		public IdentificationController(IRepository<Identification> repository)
		{
			_repository = repository;
		}


		// List - GET: api/<IdentificationController>
		[HttpGet]
		public async Task<IEnumerable<IdentificationModel>> Get()
		{
			var content = await _repository.GetAllAsync();
			return content.Select(x => x.ToModel());
		}

		// Details - GET api/<IdentificationController>/5
		[HttpGet("{id}")]
		public async Task<IdentificationModel> Get(int id)
		{
			var content = await _repository.GetByIdAsync(id);
			return content.ToModel();
		}

		// Create - POST api/<IdentificationController>
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<int> Post([FromBody] string content)
		{
			var value = JsonConvert.DeserializeObject<IdentificationModel>(content);
			return await _repository.CreateAsync(value.ToEntity());
		}

		// Update - PUT api/<IdentificationController>/5
		[HttpPut("{id}")]
		[ValidateAntiForgeryToken]
		public async Task<int> Put([FromBody] string content)
		{
			var value = JsonConvert.DeserializeObject<IdentificationModel>(content);
			return await _repository.UpdateAsync(value.ToEntity());
		}

		// Delete - api/<IdentificationController>/5
		[HttpDelete("{id}")]
		[ValidateAntiForgeryToken]
		public async Task<int> Delete(int id)
		{
			return await _repository.DeleteAsync(id);
		}
	}
}
