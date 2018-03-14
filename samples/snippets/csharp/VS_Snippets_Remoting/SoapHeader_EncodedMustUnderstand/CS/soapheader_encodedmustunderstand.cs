// System.Web.Services.Protocols.SoapHeader.EncodedMustUnderstand

/*
   This program demonstrates the 'EncodedMustUnderstand' property of
   the 'SoapHeader' class. This example calls two webservice methods,
   namely 'WebMethod1' for which the property 'DidUnderstand' is set
   to true and 'WebMethod2' for which the property 'DidUnderstand'
   is set to false. The property 'EncodedMustUnderstand' is set to '1'
   for the client soapheader. The client calls the method 'WebMethod2' 
   whose 'DidUnderstand' property is set to false and hence a 'SoapHeaderException'
   is thrown.
*/

using System;

public class MySoapHeader_EncodedMustUnderstand
{
    public static void Main() 
    {
        try
        {
// <Snippet1>
            // MyHeader class is derived from the SoapHeader class.
            MyHeader customHeader = new MyHeader();
            customHeader.MyValue = "Header value for MyValue";

            // Set the EncodedMustUnderstand property to true.
            customHeader.EncodedMustUnderstand = "1";

            WebService_SoapHeader_EncodedMustUnderstand myWebService = 
                new WebService_SoapHeader_EncodedMustUnderstand();
            myWebService.MyHeaderValue = customHeader;
            string results = myWebService.MyWebMethod1();
            Console.WriteLine(results);
            try
            {
                results = myWebService.MyWebMethod2();
            }
            catch(Exception myException)
            {
                Console.WriteLine("Exception raised in MyWebMethod2.");
                Console.WriteLine("Message: " + myException.Message);
            }
// </Snippet1>
        }
        catch (Exception e) 
        {
            Console.WriteLine("Exception caught!");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }
    }
}
