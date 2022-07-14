using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;

namespace WebKhoaHoc.Services
{
    public interface IRoleService
    {
        List<RoleResponse> GetAllRole();
        Task<RoleResponse> Create(RoleRequest request);
        Task<RespondAPI<string>> UpdateRoleAdminWithUIPermission(Guid Id, RequestUpdateRoleUI model);
        Task<RoleResponse> EditRole(EditRoleRequest request);
        Task<bool> DeleteRole(Guid id);

        Task<FindClaimByRoleIdResponse> FindClaimByRoleId(FindClaimByRoleIdRequest request);
    }
}