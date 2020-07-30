using Horeca.CrossCutting.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Horeca.DataAccessLayer.Entities
{
	public class Identification
	{
		[Key]
		[Column("Id")]
		public int IdentificationId { get; set; }

		[Required]
		[EnumDataType(typeof(TypeEstablishment))]
		public TypeEstablishment Type { get; set; }
	
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
		
		[Required]
		[MaxLength(12)]
		public string VatNumber { get; set; }
		
		[Required]
		[MaxLength(255)]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[MaxLength(2000)]
		public string Description { get; set; }

		public bool IsValidated { get; set; }
		
		[MaxLength(1000000)]
		public byte[] Logo { get; set; }

		public ICollection<Information> Informations { get; set; }
	}
}
