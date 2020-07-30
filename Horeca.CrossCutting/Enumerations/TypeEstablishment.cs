using System.ComponentModel.DataAnnotations;

namespace Horeca.CrossCutting.Enumerations
{
	public enum TypeEstablishment
	{
		[Display(Name = "Bar")]
		Bar = 1,
		[Display(Name = "Nightclub")]
		NightClub = 2,
		[Display(Name = "Concert Hall")]
		ConcertHall = 3,
		[Display(Name = "Student Society")]
		StudentSociety = 4
	}
}
