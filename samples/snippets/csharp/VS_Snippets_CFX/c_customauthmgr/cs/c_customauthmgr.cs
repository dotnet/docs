//<snippet0>
//<snippet1>
using System;
using System.IdentityModel.Claims;
using System.ServiceModel;
//</snippet1>

namespace Samples
{
  //<snippet2>
  //<snippet5>
  public class MyServiceAuthorizationManager : ServiceAuthorizationManager
  {
      //</snippet5>
      //<snippet6>
	protected override bool CheckAccessCore(OperationContext operationContext)
	{
	  // Extract the action URI from the OperationContext. Match this against the claims
	  // in the AuthorizationContext.
	  string action = operationContext.RequestContext.RequestMessage.Headers.Action;
	
	  // Iterate through the various claim sets in the AuthorizationContext.
	  foreach(ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
	  {
		// Examine only those claim sets issued by System.
		if (cs.Issuer == ClaimSet.System)
		{
		  // Iterate through claims of type "http://www.contoso.com/claims/allowedoperation".
            foreach (Claim c in cs.FindClaims("http://www.contoso.com/claims/allowedoperation", Rights.PossessProperty))
		  {
			// If the Claim resource matches the action URI then return true to allow access.
			if (action == c.Resource.ToString())
			  return true;
		  }
		}
	  }
	
	  // If this point is reached, return false to deny access.
	  return false;
	}
    //</snippet6>
  }
  //</snippet2>

  // Define a service contract.
  [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
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
		// Open the ServiceHost to create listeners and start listening for messages.
		serviceHost.Open();
		
		// The service can now be accessed.
		Console.WriteLine("The service is ready.");
		Console.WriteLine("Press <ENTER> to terminate service.");
		Console.WriteLine();
		Console.ReadLine();
		
		// Close the ServiceHost to shutdown the service.
		serviceHost.Close();
	  }
	  //</snippet3>
	}
  }
}
//</snippet0>
