namespace Chapter02_PRN232.Helpers
{
    using AutoMapper;
    using BusinessObjects;
    using DataAccess.Company;
    using DataAccess.Employee;
    using DataAccess.Player;
    using DataAccess.PlayerInstrument;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdatePlayerRequest, Player>();

            CreateMap<CreatePlayerRequest, Player>();

            CreateMap<CreatePlayerInstrumentRequest, PlayerInstrument>();

            CreateMap<Player, GetPlayerResponse>()
                .ForMember(
                    dest => dest.InstrumentSubmittedCount,
                    opt => opt.MapFrom(src => src.PlayerInstruments.Count)
                );

            CreateMap<Player, GetPlayerDetailResponse>();

            CreateMap<PlayerInstrument, GetPlayerInstrumentResponse>();





            //Mapping for Company
            CreateMap<Company, CompanyDto>()
                .ForMember(
                    c => c.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country))
                );

            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<CompanyForCreationDto, Company>();


            //Mapping for Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
        }
    }
}
