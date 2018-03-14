// <SnippetSimpleClaimsAuthzMgr>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Claims;

namespace MyClaimsAuthorizationManager
{
    class SimpleClaimsAuthoirzationManager : ClaimsAuthorizationManager
    {
        // <Snippet2>
        public override bool CheckAccess(AuthorizationContext context)
        {
            bool result = false;

            string requestedResource = context.Resource.First<Claim>().Value;
            string requestedAction = context.Action.First<Claim>().Value;
            string userName = context.Principal.Identity.Name;

            //evaluate the user against requested resource and acton
            //and make a decision.
            //return false to deny access or true to grant it.
            result = EvaluateAccessRequest(requestedResource, requestedAction, userName);
            
            return result;
        }
        // </Snippet2>

        private bool EvaluateAccessRequest(string requestedResource, string requestedAction, string userName)
        {
            return true;
        }
    }
}
// </SnippetSimpleClaimsAuthzMgr>
