
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Configuration;

using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;

using System.Security.Principal;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface SayHello
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    // Service class which implements the service contract.
    // Added code to write output to the console window
	[ServiceBehavior(IncludeExceptionDetailInFaults=true)]
	
    public class CalculatorService : SayHello
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
			return result;
        }


        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }


        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

		
        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        // <snippet1>
        public class MyServiceAuthorizationManager : ServiceAuthorizationManager
        {
 
           protected override bool CheckAccessCore(OperationContext operationContext)
            {                
                // Extract the action URI from the OperationContext. Match this against the claims
                // in the AuthorizationContext.
                string action = operationContext.RequestContext.RequestMessage.Headers.Action;
                Console.WriteLine("action: {0}", action);

                // 
                // Iterate through the various claimsets in the authorizationcontext.
                foreach(ClaimSet cs in 
                  operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
                {
                    // Examine only those claim sets issued by System.
                    if (cs.Issuer == ClaimSet.System)
                    {
                        // <snippet2>
                        // Iterate through claims of type "http://example.org/claims/allowedoperation".
                        foreach (Claim c in cs.FindClaims("http://example.org/claims/allowedoperation", 
                             Rights.PossessProperty))
                        {
                            // </snippet2>
                            // Write the claim resource to the console.
                            Console.WriteLine("resource: {0}", c.Resource.ToString());

                            // If the claim resource matches the action URI then return true to allow access
                            if (action == c.Resource.ToString())
                                return true;
                        }
                    }
                }
                
                // If we get here, return false, denying access.
                return false;                 
            }

        }
        // </snippet1>
        public class MyAuthorizationPolicy : IAuthorizationPolicy
        {
            string id;

            public MyAuthorizationPolicy()
            {
                id =  Guid.NewGuid().ToString();
            }

            // 
            public bool Evaluate(EvaluationContext evaluationContext, ref object state)
            {
                bool bRet = false;
                CustomAuthState customstate = null;

                // If state is null, then we've not been called before so we need
                // to set up our custom state
                if (state == null)
                {
                    customstate = new CustomAuthState();
                    state = customstate;
                }
                else
                    customstate = (CustomAuthState)state;

                Console.WriteLine("Inside MyAuthorizationPolicy::Evaluate");

                // If we've not added claims yet...
                if (!customstate.ClaimsAdded)
                {
                    // Create an empty list of Claims.
                    IList<Claim> claims = new List<Claim>();

                    // Iterate through each of the claim sets in the evaluation context.
                    foreach (ClaimSet cs in evaluationContext.ClaimSets)
                        // Look for Name claims in the current claimset.
                        foreach (Claim c in cs.FindClaims(ClaimTypes.Name, 
                                 Rights.PossessProperty))
                            // Get the list of operations the given username is allowed to call.
                            foreach (string s in GetAllowedOpList(c.Resource.ToString()))
                            {
                                // Add claims to the list.
                                claims.Add(new Claim("http://example.org/claims/allowedoperation", 
                                     s, Rights.PossessProperty));
                                Console.WriteLine("Claim added {0}", s);
                            }

                    // Add claims to the evaluation context.
                    evaluationContext.AddClaimSet(this, new DefaultClaimSet(this.Issuer,claims));

                    // Record that we've added claims.
                    customstate.ClaimsAdded = true;

                    // Return true, indicating we do not need to be called again.
                    bRet = true;
                }
                else
                {
                    // Should never get here, but just in case.
                    bRet = true;
                }


                return bRet;
            }
            // 
            // 
            public ClaimSet Issuer
            {
                get { return ClaimSet.System; }
            }

            public string Id
            {
                get { return id; }
            }

            // This method returns a collection of action strings that 
            // indicate the operations the specified username is 
            // allowed to call.
            private IEnumerable<string> GetAllowedOpList(string username)
            {
                IList<string> ret = new List<string>();
            
                if (username == "test1")
                {
                    ret.Add ( "http://Microsoft.ServiceModel.Samples/SayHello/Add");
                    ret.Add ("http://Microsoft.ServiceModel.Samples/SayHello/Multiply");
                    ret.Add("http://Microsoft.ServiceModel.Samples/SayHello/Subtract");
                }
                else if (username == "test2")
                {
                    ret.Add ( "http://Microsoft.ServiceModel.Samples/SayHello/Add");
                    ret.Add ("http://Microsoft.ServiceModel.Samples/SayHello/Subtract");
                }
                return ret;
            }

            // internal class for state
            class CustomAuthState
            {
                bool bClaimsAdded;

                public CustomAuthState()
                {
                    bClaimsAdded = false;
                }

                public bool ClaimsAdded { get { return bClaimsAdded; } 
                                          set {  bClaimsAdded = value; } }
            }
        }

        // 
        public class MyCustomUserNameValidator : UserNamePasswordValidator
        {
            // 
            // This method validates users. It allows in two users, test1 and test2 
            // with passwords 1tset and 2tset respectively.
            // This code is for illustration purposes only and 
            // MUST NOT be used in a production environment becuase it is NOT secure.	
            public override void Validate(string userName, string password)
            {
                if (null == userName || null == password)
                {
                    throw new ArgumentNullException();
                }

                if (!(userName == "test1" && password == "1tset") && !(userName == "test2" && password == "2tset"))
                {
                    throw new SecurityTokenException("Unknown Username or Password");
                }
            }
            // 
        }
        //  
        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get base address from app settings in configuration.
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);
            
            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();
				
                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
				Console.WriteLine("The service is running in the following account: {0}", 
                                WindowsIdentity.GetCurrent().Name);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }
    }
}
