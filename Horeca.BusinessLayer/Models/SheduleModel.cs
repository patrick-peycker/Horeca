using Horeca.DataAccessLayer.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Horeca.BusinessLayer.Models
{
	public class SheduleModel
	{
		[Key]
		public int Id { get; set; }
		
		[EnumDataType(typeof(DayOfWeek))]
		public DayOfWeek Day { get; set; }
		
		[DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime StartAM { get; set; }

		[DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime EndAM { get; set; }

		[DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime StartPM { get; set; }

		[DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
		public DateTime EndPM { get; set; }

		public int InformationId { get; set; }
	}
}