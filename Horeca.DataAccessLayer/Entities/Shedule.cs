using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Horeca.DataAccessLayer.Entities
{
	public class Shedule
	{
		[Key]
		[Column("Id")]
		public int SheduleId { get; set; }
		
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
		public Information Information { get; set; }
	}
}
