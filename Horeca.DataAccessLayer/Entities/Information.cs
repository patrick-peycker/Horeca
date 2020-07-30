using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Horeca.DataAccessLayer.Entities
{
	public class Information
	{
		[Key]
		[Column("Id")]
		public int InformationId { get; set; }

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

		public Identification Identifications { get; set; }
		public ICollection<Shedule> Shedules { get; set; }
	}
}
