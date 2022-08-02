using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<bool> Registration(RegistrationRequest request);
        List<ListUserResponse> GetListUser();
        bool DeleteUser(Guid userId);
        Task<EditUserResponse> EditUser(EditUserRequest request);
        Task<GetUserById> GetUserById(Guid userId);
        UserResponse ListUser(ListUserRequest request);
    }
}