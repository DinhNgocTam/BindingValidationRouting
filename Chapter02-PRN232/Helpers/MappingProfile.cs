namespace Chapter02_PRN232.Helpers
{
    using AutoMapper;
    using BusinessObjects;
    using DataAccess.Player;
    using DataAccess.PlayerInstrument;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdatePlayerRequest, Player>();

            CreateMap<CreatePlayerRequest, Player>();
            //.ForMember(dest => dest.PlayerInstruments, opt => opt.MapFrom(src => src.PlayerInstruments));


            CreateMap<CreatePlayerInstrumentRequest, PlayerInstrument>();

            CreateMap<Player, GetPlayerResponse>()
                .ForMember(
                    dest => dest.InstrumentSubmittedCount,
                    opt => opt.MapFrom(src => src.PlayerInstruments.Count)
                );

            CreateMap<Player, GetPlayerDetailResponse>();

            CreateMap<PlayerInstrument, GetPlayerInstrumentResponse>();
            //.ForMember(dest => dest.InstrumentTypeName, opt => opt.MapFrom(src => src.InstrumentType.Name))
            //.ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ModelName))
            //.ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level));
        }
    }
}
