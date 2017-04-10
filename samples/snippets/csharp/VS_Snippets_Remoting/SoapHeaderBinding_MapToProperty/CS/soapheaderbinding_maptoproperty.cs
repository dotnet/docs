// System.Web.Services.Description.SoapHeaderBinding.MapToProperty

/* 
The following example demonstrates the 'MapToProperty' property of class 'SoapHeaderBinding'.
It reads an existing wsdl file and gets 'SoapHeaderBinding' instance from it.
'MapToProperty' property of this instance is checked to see whether this instance 
is mapped to a specific property in proxy class or not.
*/
   using System;
   using System.Web.Services.Description;

   public class MapToPropertySample
   {
      public static void Main()
      {
// <Snippet1>
         // Read from an existing wsdl file.
         ServiceDescription myServiceDescription =
               ServiceDescription.Read("MapToProperty_cs.wsdl");
         // Get the existing binding 
         Binding myBinding=myServiceDescription.Bindings["MyWebServiceSoap"];
         OperationBinding myOperationBinding = 
                        (OperationBinding)myBinding.Operations[0];
         InputBinding myInputBinding = myOperationBinding.Input;
         // Get the 'SoapHeaderBinding' instance from 'myInputBinding'.
         SoapHeaderBinding mySoapHeaderBinding =
                  (SoapHeaderBinding)myInputBinding.Extensions[1];
         if(mySoapHeaderBinding.MapToProperty)
         {
            Console.WriteLine("'SoapHeaderBinding' instance is mapped to a "+
               "specific property in proxy generated class");
         }
         else
         {
             Console.WriteLine("'SoapHeaderBinding' instance is not mapped to "+
                "a specific property in proxy generated class");
         }
// </Snippet1>
   }
}

