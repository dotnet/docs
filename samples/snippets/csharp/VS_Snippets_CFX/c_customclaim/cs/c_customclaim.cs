//<snippet0>
//<snippet1>
using System;
using System.IdentityModel.Claims;
using System.Runtime.Serialization;
//</snippet1>

namespace Samples
{
  //<snippet2>
  [DataContract(Name="MyResource", Namespace="http://example.org/resources")]
  public sealed class MyResourceType
  {
	// private members
	private string text;
	private int number;

	// Constructors
	public MyResourceType()
	{
	}

	public MyResourceType(string text, int number )
	{
	  this.text = text;
	  this.number = number;
	}

	// Public properties
    [DataMember]
	public string Text { get { return this.text; }  set { this.text = value; } }
    [DataMember]
	public int Number { get { return this.number; } set { this.number = value; } }
  }
  //</snippet2>

  class Program
  {
	public static void Main()
	{
	  //<snippet3>
      //<snippet4>
	  // Create claim with custom claim type and primitive resource
	  Claim c1 = new Claim ( "http://example.org/claims/simplecustomclaim", "Driver's License", Rights.PossessProperty);
      // </snippet4>
      //<snippet5>
	  // Create claim with custom claim type and structured resource type
	  Claim c2 = new Claim ( "http://example.org/claims/complexcustomclaim", new MyResourceType ( "Martin", 38 ), Rights.PossessProperty);
	  // </snippet5>
        //</snippet3>

	  // Do something with claims
	}
  }
}
//</snippet0>
