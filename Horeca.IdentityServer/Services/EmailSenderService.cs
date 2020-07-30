using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Horeca.IdentityServer.Services
{
	public class EmailSenderService : IEmailSender
	{
		private string _userName;
		private string _apiKey;

		public EmailSenderService(string userName, string apiKey)
		{
			_userName = userName;
			_apiKey = apiKey;
		}

		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var client = new SendGridClient(_apiKey);
			var message = new SendGridMessage
			{
				From = new EmailAddress("info@matrix.brussels", _userName),
				Subject = subject,
				HtmlContent = htmlMessage
			};

			message.AddTo(new EmailAddress(email));

			return client.SendEmailAsync(message);
		}
	}
}
