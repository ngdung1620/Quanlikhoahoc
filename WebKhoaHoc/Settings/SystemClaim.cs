using System.Collections.Generic;
using CKLS.Identity.Models;

namespace WebKhoaHoc.Settings
{
    public static class SystemClaim
    {
        public static List<ClaimInfo> claims = new List<ClaimInfo>()
        {
            UIClaims.CourseClaims, 
            UIClaims.CombinedCourseClaims
        };
        
    }

   
}