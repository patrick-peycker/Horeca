using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Horeca.BusinessLayer.Models
{
	public class InformationModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[Required]
		[MaxLength(20)]
		public string ZipCode { get; set; }

		[Required]
		[MaxLength(100)]
		public string City { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		[MaxLength(100)]
		public string Street { get; set; }

		[Required]
		[MaxLength(20)]
		public string StreetNumber { get; set; }

		[MaxLength(25)]
		public string PhoneNumber { get; set; }

		[DataType(DataType.Url)]
		public string WebSite { get; set; }

		[DataType(DataType.Url)]
		public string Instagram { get; set; }

		[DataType(DataType.Url)]
		public string Facebook { get; set; }

		[DataType(DataType.Url)]
		public string LinkedIn { get; set; }

		public int IdentificationId { get; set; }
		public ICollection<SheduleModel> Shedules { get; set; }
	}
}