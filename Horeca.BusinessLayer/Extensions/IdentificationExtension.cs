using Horeca.BusinessLayer.Models;
using Horeca.DataAccessLayer.Entities;
using System.Linq;

namespace Horeca.BusinessLayer.Extensions
{
	public static class IdentificationExtension
	{
		public static IdentificationModel ToModel (this Identification identification)
		{
			return new IdentificationModel
			{
				Id = identification.IdentificationId,
				Type = identification.Type,
				Name = identification.Name,
				VatNumber = identification.VatNumber,
				EmailAddress = identification.EmailAddress,
				Description = identification.Description,
				Logo = identification.Logo,
				IsValidated = identification.IsValidated,
				Informations = identification.Informations?.Select(i => i.ToModel()).ToList()
			};
		}

		public static Identification ToEntity(this IdentificationModel identification)
		{
			return new Identification
			{
				IdentificationId = identification.Id,
				Type = identification.Type,
				Name = identification.Name,
				VatNumber = identification.VatNumber,
				EmailAddress = identification.EmailAddress,
				Description = identification.Description,
				IsValidated = identification.IsValidated,
				Logo = identification.Logo,
				Informations = identification.Informations?.Select(i => i.ToEntity()).ToList()
			};
		}
	}
}
