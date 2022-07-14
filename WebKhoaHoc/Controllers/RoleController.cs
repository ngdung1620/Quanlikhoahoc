using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Services;
using WebKhoaHoc.Settings;

namespace WebKhoaHoc.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoleController: ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get-role")]
        public IActionResult GetRole()
        {
            return Ok(_roleService.GetAllRole());
        }
        
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(RoleRequest request)
        {
            return Ok(await _roleService.Create(request));
        }

        [HttpPost("add-claim/{id}")]
        public async Task<IActionResult> AddClaim(Guid id, [FromBody] RequestUpdateRoleUI request)
        {
            return Ok(await _roleService.UpdateRoleAdminWithUIPermission(id, request));
        }


        [HttpGet("all-claim")]
        public IActionResult GetAllClaimI()
        {
            return Ok(SystemClaim.claims);
        }
        [HttpPost("edit-role")]
        public async Task<IActionResult> EditRole([FromBody] EditRoleRequest request)
        {
            return Ok(await _roleService.EditRole(request));
        }

        [HttpDelete("delete-role/{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            return Ok(await _roleService.DeleteRole(id));
        }

        [HttpPost("FindClaimByRoleId")]
        public async Task<IActionResult> FindClaimByRoleId([FromBody] FindClaimByRoleIdRequest request)
        {
            return Ok(await _roleService.FindClaimByRoleId(request));
        }
    }
}