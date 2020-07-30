using Horeca.BusinessLayer.Models;
using Horeca.DataAccessLayer.Entities;
using System.Linq;

namespace Horeca.BusinessLayer.Extensions
{
	public static class InformationExtension
	{
		public static InformationModel ToModel (this Information information)
		{
			return new InformationModel
			{
				Id = information.InformationId,
				EmailAddress = information.EmailAddress,
				ZipCode = information.ZipCode,
				City = information.City,
				Country = information.Country,
				Street = information.Street,
				StreetNumber = information.StreetNumber,
				PhoneNumber = information.PhoneNumber,
				WebSite = information.WebSite,
				Instagram = information.Instagram,
				Facebook = information.Facebook,
				LinkedIn = information.LinkedIn,
				Shedules = information.Shedules?.Select(x => x.ToModel()).ToList(),
				IdentificationId = information.IdentificationId
			};
		}

		public static Information ToEntity(this InformationModel information)
		{
			return new Information
			{
				InformationId = information.Id,
				ZipCode = information.ZipCode,
				City = information.City,
				Country = information.Country,
				Street = information.Street,
				StreetNumber = information.StreetNumber,
				PhoneNumber = information.PhoneNumber,
				WebSite = information.WebSite,
				Instagram = information.Instagram,
				Facebook = information.Facebook,
				LinkedIn = information.LinkedIn,
				Shedules = information.Shedules?.Select(x=>x.ToEntity()).ToList(),
				IdentificationId = information.IdentificationId
			};
		}
	}
}
