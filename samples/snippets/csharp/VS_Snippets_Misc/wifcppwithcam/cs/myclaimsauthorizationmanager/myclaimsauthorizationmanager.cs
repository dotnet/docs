using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MyClaimsAuthorizationManager
{
    public class MyClaimsAuthorizationManager: ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            return false;
        }
    }
}
