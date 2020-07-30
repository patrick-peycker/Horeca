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
	public class InformationController : ControllerBase
	{
		private readonly IRepository<Information> _repository;

		public InformationController(IRepository<Information> repository)
		{
			_repository = repository;
		}

		// GET: api/<InformationController>
		[HttpGet]
		public async Task<IEnumerable<InformationModel>> Get()
		{
			var content = await _repository.GetAllAsync();
			return content.Select(x => x.ToModel());
		}

		// GET api/<InformationController>/5
		[HttpGet("{id}")]
		public async Task<InformationModel> Get(int id)
		{
			var content = await _repository.GetByIdAsync(id);
			return content.ToModel();
		}

		// POST api/<InformationController>
		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<int> Post([FromBody] string content)
		{
			var value = JsonConvert.DeserializeObject<InformationModel>(content);
			return await _repository.CreateAsync(value.ToEntity());
		}

		// PUT api/<IdentificationController>/5
		[HttpPut("{id}")]
		[ValidateAntiForgeryToken]

		public async Task<int> Put([FromBody] string content)
		{
			var value = JsonConvert.DeserializeObject<InformationModel>(content);
			return await _repository.UpdateAsync(value.ToEntity());
		}

		// DELETE api/<IdentificationController>/5
		[HttpDelete("{id}")]
		[ValidateAntiForgeryToken]

		public async Task<int> Delete(int id)
		{
			return await _repository.DeleteAsync(id);
		}
	}
}
