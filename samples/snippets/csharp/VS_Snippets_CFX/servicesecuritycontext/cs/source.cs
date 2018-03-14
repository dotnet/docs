using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Microsoft.ServiceModel.Samples
{
    public class Test
    {
        private Test() { }

        static void Main()
        {
            // empty, must for FXCop.
        }
    }


    [ServiceContract(Namespace = "Microsoft.ServiceModel.Samples")]
    interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
    }


    public class Calculator : ICalculator
    {
        //<snippet1>
        // When this method runs, the caller must be an authenticated user 
        // and the ServiceSecurityContext is not a null instance. 
        public double Add(double n1, double n2)
        {
            // Write data from the ServiceSecurityContext to a file using the StreamWriter class.
            using (StreamWriter sw = new StreamWriter(@"c:\ServiceSecurityContextInfo.txt"))
            {
                // Write the primary identity and Windows identity. The primary identity is derived from 
                // the credentials used to authenticate the user. The Windows identity may be a null string.
                sw.WriteLine("PrimaryIdentity: {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
                sw.WriteLine("WindowsIdentity: {0}", ServiceSecurityContext.Current.WindowsIdentity.Name);

                // Write the claimsets in the authorization context. By default, there is only one claimset
                // provided by the system. 
                foreach (ClaimSet claimset in ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)
                {
                    foreach (Claim claim in claimset)
                    {
                        // Write out each claim type, claim value, and the right. There are two
                        // possible values for the right: "identity" and "possessproperty". 
                        sw.WriteLine("Claim Type: {0}, Resource: {1} Right: {2}",
                            claim.ClaimType,
                            claim.Resource.ToString(),
                            claim.Right);
                        sw.WriteLine();
                    }
                }
            }
            return n1 + n2;
        }
        //</snippet1>
    }

    //<snippet2>
    public class MyServiceAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {                
            // Extract the action URI from the OperationContext. Match this against the claims
            // in the AuthorizationContext.
            string action = operationContext.RequestContext.RequestMessage.Headers.Action;
            Console.WriteLine("action: {0}", action);

            // Iterate through the various claimsets in the AuthorizationContext.
            foreach(ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
            {
                // Examine only those claim sets issued by System.
                if (cs.Issuer == ClaimSet.System)
                {
                    // Iterate through claims of type "http://example.org/claims/allowedoperation".
                    foreach (Claim c in cs.FindClaims("http://example.org/claims/allowedoperation", 
                        Rights.PossessProperty))
                    {
                        // Write the Claim resource to the console.
                        Console.WriteLine("resource: {0}", c.Resource.ToString());

                        // If the Claim resource matches the action URI then return true to allow access.
                        if (action == c.Resource.ToString())
                            return true;
                    }
                }
            }

            // If this point is reached, return false to deny access.
             return false;                 
        }
    }
    //</snippet2>
}
