using System.ComponentModel.DataAnnotations;

namespace Horeca.CrossCutting.Enumerations
{
	public enum Gender
	{
		[Display(Name = "Mal")]
		Mal = 1,

		[Display(Name = "Female")]
		Female = 2,

		[Display(Name = "Non Binary")]
		NonBinary = 3
	}
}
