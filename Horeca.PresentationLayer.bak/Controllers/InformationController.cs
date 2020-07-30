using Horeca.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.PresentationLayer.Controllers
{
	public class InformationController : Controller
	{
		private readonly HttpClient Client = new HttpClient();
		private const string BaseUrl = "https:localhost:5003/api/information";

		// Get : api/inforamtion/
		public async Task<ActionResult> Index()
		{
			var httpResponse = await Client.GetAsync(BaseUrl);

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Cannot retieve tasks");
			}

			var content = await httpResponse.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<IEnumerable<InformationModel>>(content);

			return View(result);
		}

		// Get : api/information/details/{id}
		public async Task<ActionResult> Details(int id)
		{
			var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");


			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Cannot retieve tasks");
			}

			var content = await httpResponse.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<InformationModel>(content);

			return View(result);
		}

		// Get : api/inforamtion/create/{id}
		public ActionResult Create()
		{
			return View();
		}

		// Post : api/information/create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(
			[Bind(
				"EmailAddress",
				"ZipCode",
				"City",
				"Country",
				"Street",
				"StreetNumber",
				"PhoneNumber",
				"WebSite",
				"Instagram",
				"Facebook",
				"LinkedIn",
				"IdentificationId")] InformationModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);
				var httpResponse = await Client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// Get : api/information/eidt/{id}
		public async Task<ActionResult> Edit(int id)
		{
			var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");


			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Cannot retieve tasks");
			}

			var content = await httpResponse.Content.ReadAsStringAsync();

			var result = JsonConvert.DeserializeObject<InformationModel>(content);

			return View(result);
		}

		// Post : api/inforamtion/edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(
			[Bind(
				"EmailAddress",
				"ZipCode",
				"City",
				"Country",
				"Street",
				"StreetNumber",
				"PhoneNumber",
				"WebSite",
				"Instagram",
				"Facebook",
				"LinkedIn",
				"IdentificationId")] InformationModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);
				var httpResponse = await Client.PutAsync($"{BaseUrl}/{task.Id}", new StringContent(content, Encoding.Default, "application/json"));

				return RedirectToAction(nameof(Index));
			}

			catch
			{
				return View();
			}
		}

		// GET: api/information/delete/{id}
		public async Task<ActionResult> Delete(int id)
		{
			var httpResponse = await Client.DeleteAsync($"{BaseUrl}/{id}");

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Cannot retieve tasks");
			}

			return View(nameof(Index));
		}
	}
}
