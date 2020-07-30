using Horeca.CrossCutting.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Horeca.IdentityServer.Models
{
	public class User : IdentityUser
	{
		[MaxLength(50)]
		[RegularExpression("^[a-zA-Z]$")]
		[PersonalData]
		public string LastName { get; set; }
	
		[MaxLength(50)]
		[RegularExpression("^[a-zA-Z]$")]
		[PersonalData]
		public string FirstName { get; set; }
	
		[MaxLength(25)]
		[PersonalData]
		public string MobileNumber { get; set; }
		
		[EnumDataType(typeof(Gender))]
		[PersonalData]
		public Gender Gender{ get; set; }
		
		[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
		[PersonalData]
		public DateTime DateOfBirth { get; set; }
		
		[PersonalData]
		public bool Professional { get; set; }
	}
}
