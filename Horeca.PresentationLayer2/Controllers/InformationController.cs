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
	public class InformationController : Controller
	{
		private readonly HttpClient Client = new HttpClient();
		private const string BaseUrl = "https://localhost:5003/api/Information";

		// GET: InformationController
		public async Task<ActionResult> Index()
		{
			try
			{
				var httpResponse = await Client.GetAsync(BaseUrl);

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Informations !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<IEnumerable<InformationModel>>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: InformationController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Information !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<InformationModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: InformationController/Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		// POST: InformationController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind("EmailAddress", "ZipCode", "City", "Country", "Street", "StreetNumber", "PhoneNumber", "WebSite", "Instagram", "Facebook", "LinkedIn", "IdentificationId")] InformationModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);
				var httpResponse = await Client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot create this Information !");
				}

				TempData["Message"] = "This Information is create successfully !";
				return RedirectToAction("Index");
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: InformationController/Edit/5
		[HttpGet]
		public async Task<ActionResult> Edit(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");


				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retrieve this Information !");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<InformationModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// POST: InformationController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind("Id","EmailAddress", "ZipCode", "City", "Country", "Street", "StreetNumber", "PhoneNumber", "WebSite", "Instagram", "Facebook", "LinkedIn", "IdentificationId")] InformationModel task)
		{
			try
			{
				var content = JsonConvert.SerializeObject(task);

				var httpResponse = await Client.PutAsync($"{BaseUrl}/{task.Id}", new StringContent(content, Encoding.Default, "application/json"));

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot Edit this Information !");
				}

				TempData["Message"] = "This Information was update successfully !";

				return RedirectToAction("Index");
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// GET: InformationController/Delete/5
		[HttpGet]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				var httpResponse = await Client.GetAsync($"{BaseUrl}/{id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot retieve this Information");
				}

				var content = await httpResponse.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<InformationModel>(content);

				return View(result);
			}

			catch (Exception ex)
			{
				TempData["Message"] = ex.Message;
				return View("NotFound");
			}
		}

		// POST: InformationController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete([Bind("EmailAddress", "ZipCode", "City", "Country", "Street", "StreetNumber", "PhoneNumber", "WebSite", "Instagram", "Facebook", "LinkedIn", "IdentificationId")] InformationModel task )
		{
			try
			{
				var httpResponse = await Client.DeleteAsync($"{BaseUrl}/{task.Id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					throw new Exception("Cannot delete this Information !");
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
