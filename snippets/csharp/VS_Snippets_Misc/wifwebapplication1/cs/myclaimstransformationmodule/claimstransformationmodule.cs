using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Claims;
using System.Security.Principal;



namespace MyClaimsTransformationModule
{
    class ClaimsTransformationModule : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (incomingPrincipal != null && incomingPrincipal.Identity.IsAuthenticated == true)
            {
                //DECIDE ON SOME CRITERIA IF CURRENT USER DESERVES THE ROLE
                //IClaimsIdentity identity = (IClaimsIdentity)incomingPrincipal.Identity;
                ClaimsIdentity identity = incomingPrincipal.Identity as ClaimsIdentity;
                if (null != identity)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }
            }
            return incomingPrincipal;


        }
    }
}
