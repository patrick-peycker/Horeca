using AutoMapper;
using Horeca.DataAccessLayer.Entities;
using System.Linq;

namespace Horeca.BusinessLayer.Models
{
	public class AutoMapping : Profile
	{
		private readonly IMapper _mapper;
		public AutoMapping(IMapper mapper)
		{
			_mapper = mapper;

			this.CreateMap<InformationModel, Information>()
				.ForMember(d => d.InformationId, opt => opt.MapFrom(s => s.Id));

			this.CreateMap<Information, InformationModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.InformationId))
				.ForSourceMember(src => src.Identifications, opt => opt.DoNotValidate());

			this.CreateMap<IdentificationModel, Identification>()
				.ForMember(dest => dest.IdentificationId, opt => opt.MapFrom(src => src.Id))
				.ForMember
				(
					dest => dest.Informations,
					opt => opt.MapFrom
					(
						src => src.Informations.Select
						(
							x => new
							{
								x.City,
								x.Country,
								x.Facebook,
								x.Id,
								x.IdentificationId,
								x.Instagram,
								x.LinkedIn,
								x.PhoneNumber,
								x.Street,
								x.StreetNumber,
								x.WebSite,
								x.ZipCode
							}
						).ToList()
					 )
				);

			this.CreateMap<Identification, IdentificationModel>()
				.ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdentificationId))
				.ForMember
				(
					dest => dest.Informations,
					opt => opt.MapFrom
					(
						src => src.Informations.Select
						(
							x => new
							{
								x.City,
								x.Country,
								x.Facebook,
								x.InformationId,
								x.IdentificationId,
								x.Instagram,
								x.LinkedIn,
								x.PhoneNumber,
								x.Street,
								x.StreetNumber,
								x.WebSite,
								x.ZipCode
							}
						).ToList()
					 )
				);

		}
	}
}
