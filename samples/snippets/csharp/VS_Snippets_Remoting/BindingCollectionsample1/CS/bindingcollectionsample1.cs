// System.Web.Services.Description.BindingCollection;System.Web.Services.Description.BindingCollection.Item[Int32];
// System.Web.Services.Description.BindingCollection.Item[String];System.Web.Services.Description.BindingCollection.CopyTo

/* The program reads a wsdl document "MathService.wsdl" and instantiates a ServiceDescription instance 
   from the WSDL document.A BindingCollection instance is then retrieved from this ServiceDescription instance 
   and it's members are demonstrated. 
 */
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyClass
{
  public static void Main()
   {
	   Binding myBinding;
      ServiceDescription myServiceDescription = ServiceDescription.Read("MathService_input.wsdl");
      Console.WriteLine("Total Number of bindings :" + myServiceDescription.Bindings.Count);
// <Snippet1>	  
      for(int i=0; i < myServiceDescription.Bindings.Count; ++i)
	   {	
	      Console.WriteLine("\nBinding " + i ); 
		   // Get Binding at index i.
         myBinding = myServiceDescription.Bindings[i];
		   Console.WriteLine("\t Name : " + myBinding.Name);
		   Console.WriteLine("\t Type : " + myBinding.Type);
     }
// </Snippet1>
// <Snippet2>
     Binding[] myBindings = new Binding[myServiceDescription.Bindings.Count];
     // Copy BindingCollection to an Array.
     myServiceDescription.Bindings.CopyTo(myBindings,0);
     Console.WriteLine("\n\n Displaying array copied from BindingCollection");
     for(int i=0;i < myServiceDescription.Bindings.Count; ++i)
     {
        Console.WriteLine("\nBinding " + i ); 
        Console.WriteLine("\t Name : " + myBindings[i].Name);
        Console.WriteLine("\t Type : " + myBindings[i].Type);
     }
// </Snippet2>
// <Snippet3>    
     // Get Binding Name = "MathServiceSoap".
     myBinding = myServiceDescription.Bindings["MathServiceHttpGet"];
     if (myBinding != null)
     {
        Console.WriteLine("\n\nName : " + myBinding.Name);
        Console.WriteLine("Type : " + myBinding.Type);
     }
// </Snippet3>
     myServiceDescription = null;
     myBinding = null;
   }
}