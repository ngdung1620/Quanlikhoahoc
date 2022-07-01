using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKLS.Identity.Models
{
    public class Permission
    {
        public Permission(string displayName, string name, int type)
        {
            this.DisplayName = displayName;
            this.Name = name;
            this.Type = type;
        }
        public string Name { get; set; }
        public int Type { get; set; }
        public string DisplayName { get; set; }
    }
}
