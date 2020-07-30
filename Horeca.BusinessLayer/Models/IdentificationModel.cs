using Horeca.CrossCutting.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Horeca.BusinessLayer.Models
{
	public class IdentificationModel
	{
		[Key]
		public int Id { get; set; }
		
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
		public ICollection<InformationModel> Informations { get; set; }
	}
}
