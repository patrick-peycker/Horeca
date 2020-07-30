using Horeca.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.PresentationLayer2.Controllers
{
	public class IdentificationController : Controller
	{
		private readonly HttpClient Client = new HttpClient();
		private const string BaseUrl = "https://localhost:5003/api/Identification";

		// GET: IdentificationController
		public async Task<ActionResult> Index()
		{
			try
			{
				var httpResponse = await Client.GetAsync(BaseUrl);

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Identificatons !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<IEnumerable<IdentificationModel>>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: IdentificationController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Identification !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<IdentificationModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: IdentificationController/Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		// POST: IdentificationController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind("Type", "Name", "VatNumber", "EmailAddress", "Description", "IsValidated")] IdentificationModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);
				var httpResponse = await Client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot create this Identification !");
				}

				TempData["Message"] = "This Identification is create successfully !";
				return RedirectToAction("Index");
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: IdentificationController/Edit/5
		[HttpGet]
		public async Task<ActionResult> Edit(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");


				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retrieve this Identification !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<IdentificationModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// POST: IdentificationController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind("Id", "Type", "Name", "VatNumber", "EmailAddress", "Description")] IdentificationModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);

				var httpResponse = await Client.PutAsync($"{BaseUrl}/{task.Id}", new StringContent(content, Encoding.Default, "application/json"));

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot Edit this Identification !");
				}

				TempData["Message"] = "This Identification was update successfully !";

				return RedirectToAction("Index");
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: IdentificationController/Delete/5
		[HttpGet]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Identification");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<IdentificationModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// POST: IdentificationController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete([Bind("Id", "Type", "Name", "VatNumber", "EmailAddress", "Description")] IdentificationModel task)
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

			catch
			{
				return View("NotFound");
			}
		}
	}
}
