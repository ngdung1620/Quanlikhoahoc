using AutoMapper;
using WebKhoaHoc.Models;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleResponse, ApplicationRole>();
            CreateMap<ApplicationRole, RoleResponse>();
        }
    }

}