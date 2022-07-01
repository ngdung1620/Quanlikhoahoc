using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKLS.Identity.Models
{
    public class ClaimInfo
    {
        public ClaimInfo(string displayName, string name, List<Permission> permissions)
        {
            this.DisplayName = displayName;
            this.Name = name;
            this.Permissions = permissions;
        }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
