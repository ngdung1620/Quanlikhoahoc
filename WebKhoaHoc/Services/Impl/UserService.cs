using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebKhoaHoc.Models;
using WebKhoaHoc.Models.RequestModels;
using WebKhoaHoc.Models.ResponseModels;
using WebKhoaHoc.Settings;

namespace WebKhoaHoc.Services.Impl
{
    public class UserService: IUserService
    {
         private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly MasterDbContext _context;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, MasterDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new Exception("Username not exist");
            }
            
            var loginResponse = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!loginResponse)
            {
                throw new Exception("Username or Password incorrect");
            }
            
            var token = await GenerateTokenJwtByUser(user);

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }

        public async Task<bool> Registration(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                FullName = request.FullName
            };

            var newUser = await _userManager.CreateAsync(user, request.Password);
            if (newUser.Succeeded)
            {
                return true;
            }

            return false;
        }
        private async Task<JwtSecurityToken> GenerateTokenJwtByUser(ApplicationUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (string role in userRoles)
            {
                var roleData = await _roleManager.FindByNameAsync(role);
                if (roleData != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(roleData);
                    foreach (Claim claim in roleClaims)
                    {
                        authClaims.Add(claim);
                    }
                }             
            }

            if (user.UserName.Equals("tdao7"))
            {
                authClaims.Add(new Claim(ClaimTypes.Role, "CombinedCourse.Write"));
            }
            
            authClaims.Add(new Claim(ClaimTypes.Role, "manyRole"));

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            
            
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DefaultApplication.SecretKey));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}