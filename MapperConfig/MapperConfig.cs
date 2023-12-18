using AutoMapper;
using JPW.DTO;
using JPW.Models;

namespace JPW.MapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CompanyDTO, Company>().ReverseMap();
            CreateMap<JobpostingDTO, JobPosting>().ReverseMap();
             CreateMap<ApplyforJobDTO, ApplyforJob>().ReverseMap();
            CreateMap<JobSeekerDTO, JobSeeker>().ReverseMap();
            CreateMap<JobMatchDTO, JobMatch>().ReverseMap();
            CreateMap<MessageDTO, Message>().ReverseMap();
            CreateMap<InterviewDTO,Interview>().ReverseMap();
        }
    }
}