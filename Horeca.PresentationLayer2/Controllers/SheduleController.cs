using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Horeca.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Horeca.PresentationLayer2.Controllers
{
	public class SheduleController : Controller
	{
		private readonly HttpClient Client = new HttpClient();
		private const string BaseUrl = "https://localhost:5003/api/Shedule";

		//GET : SheduleController/Shedule
		[HttpGet]
		public async Task<ActionResult> Index()
		{
			try
			{
				var httpResponse = await Client.GetAsync(BaseUrl);

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Shedule !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<IEnumerable<SheduleModel>>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: SheduleController/Details/5
		[HttpGet]
		public async Task<ActionResult> Details(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Shedule !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<SheduleModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: SheduleController/Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		// POST: SheduleController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind("Type", "Name", "VatNumber", "EmailAddress", "Description")] SheduleModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);
				var httpResponse = await Client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot create this Shedule !");
				}

				TempData["Message"] = "This Shedule is create successfully !";
				return RedirectToAction("Index");
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: SheduleController/Edit/5
		[HttpGet]
		public async Task<ActionResult> Edit(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");


				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retrieve this Shedule !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<SheduleModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// POST: SheduleController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind("Day", "StartAM", "EndAM", "StartPM", "EndPM", "InformationId")] SheduleModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);

				var httpResponse = await Client.PutAsync($"{BaseUrl}/{task.Id}", new StringContent(content, Encoding.Default, "application/json"));

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot Edit this Shedule !");
				}

				TempData["Message"] = "This Shedule was update successfully !";

				return RedirectToAction("Index");
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: SheduleController/Delete/5
		[HttpGet]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Shedule");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<SheduleModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// POST: SheduleController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete([Bind("Id", "Day", "StartAM", "EndAM", "StartPM", "EndPM", "InformationId")] SheduleModel task)
		{
			try
			{
				var httpResponse = await Client.DeleteAsync($"{BaseUrl}/{task.Id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve tasks");
				}

				TempData["Message"] = "This Idendification was delete successfully !";

				return RedirectToAction("Index");
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}
	}
}
