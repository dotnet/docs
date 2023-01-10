//<snippet0>
//<snippet1>
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Security.Permissions;
//</snippet1>
namespace Samples
{
  class Program
  {
	public static void Main()
	{
	  IList<Claim> claims = FindSomeClaims ( ClaimSet.System, ClaimTypes.System, Rights.Identity);
	}

	//<snippet2>
	// The FindSomeClaims method looks in the provided ClaimSet for Claims of the specified type and right.
    // It returns such Claims in a list.
	public static IList<Claim> FindSomeClaims ( ClaimSet cs, string type, string right )
	{
	  // Create an empty list
	  IList<Claim> claims = new List<Claim>();

	  // Call ClaimSet.FindClaims with the specified type and right. Iterate over the result...
	  foreach(Claim c in cs.FindClaims ( type, right ))
		//...adding each claim to the list
		claims.Add ( c );

	  // Return the list
	  return claims;
	}
	//</snippet2>
  }
}
//</snippet0>
