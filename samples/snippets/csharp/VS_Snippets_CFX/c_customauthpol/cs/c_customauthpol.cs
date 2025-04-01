//<snippet0>
//<snippet1>
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.ServiceModel;
//</snippet1>

namespace Samples
{
    //<snippet2>
    public class MyServiceAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            // Extract the action URI from the OperationContext. Use this to match against the claims
            // in the AuthorizationContext.
            string action = operationContext.RequestContext.RequestMessage.Headers.Action;

            // Iterate through the various claim sets in the authorization context.
            foreach (ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
            {
                // Only look at claimsets issued by System.
                if (cs.Issuer == ClaimSet.System)
                {
                    // Iterate through claims of type "http://example.org/claims/allowedoperation"
                    foreach (Claim c in cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty))
                    {
                        // If the Claim resource matches the action URI, then return true to allow access.
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

    //<snippet5>
    public class MyAuthorizationPolicy : IAuthorizationPolicy
    {
        string id;

        public MyAuthorizationPolicy()
        {
            id = Guid.NewGuid().ToString();
        }

        //<snippet6>
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            bool bRet = false;
            CustomAuthState customstate = null;

            // If the state is null, then this has not been called before so
            // set up a custom state.
            if (state == null)
            {
                customstate = new CustomAuthState();
                state = customstate;
            }
            else
            {
                customstate = (CustomAuthState)state;
            }

            // If claims have not been added yet...
            if (!customstate.ClaimsAdded)
            {
                // Create an empty list of claims.
                IList<Claim> claims = new List<Claim>();

                // Iterate through each of the claim sets in the evaluation context.
                foreach (ClaimSet cs in evaluationContext.ClaimSets)
                    // Look for Name claims in the current claimset.
                    foreach (Claim c in cs.FindClaims(ClaimTypes.Name, Rights.PossessProperty))
                        // Get the list of operations the given username is allowed to call.
                        foreach (string s in GetAllowedOpList(c.Resource.ToString()))
                        {
                            // Add claims to the list.
                            claims.Add(new Claim("http://example.org/claims/allowedoperation", s, Rights.PossessProperty));
                            Console.WriteLine($"Claim added {s}");
                        }

                // Add claims to the evaluation context.
                evaluationContext.AddClaimSet(this, new DefaultClaimSet(this.Issuer, claims));

                // Record that claims were added.
                customstate.ClaimsAdded = true;

                // Return true, indicating that this method does not need to be called again.
                bRet = true;
            }
            else
            {
                // Should never get here, but just in case, return true.
                bRet = true;
            }

            return bRet;
        }
        //</snippet6>

        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public string Id
        {
            get { return id; }
        }

        // This method returns a collection of action strings that indicate the
        // operations the specified username is allowed to call.
        private IEnumerable<string> GetAllowedOpList(string username)
        {
            IList<string> ret = new List<string>();

            if (username == "test1")
            {
                ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Add");
                ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Multiply");
                ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Subtract");
            }
            else if (username == "test2")
            {
                ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Add");
                ret.Add("http://Microsoft.ServiceModel.Samples/ICalculator/Subtract");
            }
            return ret;
        }

        //<snippet7>
        // Internal class for keeping track of state.
        class CustomAuthState
        {
            bool bClaimsAdded;

            public CustomAuthState()
            {
                bClaimsAdded = false;
            }

            public bool ClaimsAdded
            {
                get { return bClaimsAdded; }
                set { bClaimsAdded = value; }
            }
        }
        //</snippet7>
    }
    //</snippet5>

    // Define a service contract and implement it.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
    }

    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine($"Received Add({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            return result;
        }
    }

    class Program
    {
        public static void Main()
        {
            //<snippet3>
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                //<snippet4>
                // Add a custom authorization manager to the service authorization behavior.
                serviceHost.Authorization.ServiceAuthorizationManager =
                           new MyServiceAuthorizationManager();
                //</snippet4>

                //<snippet8>
                // Add a custom authorization policy to the service authorization behavior.
                List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
                policies.Add(new MyAuthorizationPolicy());
                serviceHost.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
                //</snippet8>
                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHost to shut down the service.
                serviceHost.Close();
            }
            //</snippet3>
        }
    }
}
//</snippet0>
