using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebKhoaHoc.Models;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;
using WebKhoaHoc.Settings;

namespace WebKhoaHoc.Services.Impl
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MasterDbContext _context;
        private readonly IMapper _mapper;


        public RoleService(RoleManager<ApplicationRole> roleManager, IMapper mapper, MasterDbContext context)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;
        }

        public List<RoleResponse> GetAllRole()
        {
            return _mapper.Map<List<RoleResponse>>(_context.Roles.ToList());
        }

        public async Task<RoleResponse> Create(RoleRequest request)
        {
            var newRole = new ApplicationRole
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            await _roleManager.CreateAsync(newRole);
            await _context.SaveChangesAsync();
            return _mapper.Map<RoleResponse>(newRole);
        }

        public async Task<RespondAPI<string>> UpdateRoleAdminWithUIPermission(Guid Id, RequestUpdateRoleUI model)
        {
            ApplicationRole hasRole = await _roleManager.FindByIdAsync(Id.ToString());

            if (null == hasRole)
                return new RespondAPI<string>()
                    { Result = ResultRespond.NotFound, Code = "01", Message = "Không tìm thấy thông tin nhóm quyền" };


            IdentityResult roleResult = await _roleManager.UpdateAsync(hasRole);
            if (roleResult.Succeeded)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(hasRole);

                foreach (Claim claim in roleClaims)
                {
                    await _roleManager.RemoveClaimAsync(hasRole, claim);
                }

                foreach (string permission in model.ListPermission)
                {
                    await _roleManager.AddClaimAsync(hasRole, new Claim(ClaimTypes.Role, permission));
                }

                return new RespondAPI<string>()
                    { Result = ResultRespond.Succeeded, Message = "Cập nhật nhóm quyền thành công" };
            }

            return new RespondAPI<string>()
                { Result = ResultRespond.Failed, Code = "03", Message = "Không thể cập nhật nhóm quyền" };
        }
    }
}