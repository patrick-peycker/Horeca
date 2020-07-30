using Horeca.BusinessLayer.Models;
using Horeca.DataAccessLayer.Entities;

namespace Horeca.BusinessLayer.Extensions
{
	public static class SheduleExtension
	{
		public static SheduleModel ToModel (this Shedule shedule)
		{
			return new SheduleModel
			{
				Id = shedule.SheduleId,
				Day = shedule.Day,
				StartAM = shedule.StartAM,
				EndAM = shedule.EndAM,
				StartPM = shedule.StartPM,
				EndPM = shedule.EndPM,
				InformationId = shedule.InformationId
			};
		}

		public static Shedule ToEntity (this SheduleModel shedule)
		{
			return new Shedule
			{
				SheduleId = shedule.Id,
				Day = shedule.Day,
				StartAM = shedule.StartAM,
				EndAM = shedule.EndAM,
				StartPM = shedule.StartPM,
				EndPM = shedule.EndPM,
				InformationId = shedule.InformationId
			};
		}
	}
}
