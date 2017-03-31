// System.Web.Services.Description.OperationFault
// System.Web.Services.Description.OperationFault.OperationFault

/* The following example demonstrates the usage of the 'OperationFault'
   class and its constructor. The program generates a WSDL file 
   'StockQuoteNew_cs.wsdl' which contains 'Fault' information written 
   out. 
*/

// <Snippet1>
using System;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class MyOperationFaultSample
{
   public static void Main()
   {
      try 
      {
         // Read the 'StockQuote_cs.wsdl' file as input.
         ServiceDescription myServiceDescription = ServiceDescription.
                                               Read("StockQuote_cs.wsdl");
         PortTypeCollection myPortTypeCollection = myServiceDescription.
                                                                PortTypes;
         PortType myPortType = myPortTypeCollection[0];
         OperationCollection myOperationCollection = myPortType.Operations;
         Operation myOperation = myOperationCollection[0];
// <Snippet2>
         OperationFault myOperationFault = new OperationFault();
         myOperationFault.Name = "ErrorString";
         myOperationFault.Message = new XmlQualifiedName
                                          ("s0:GetTradePriceStringFault");
         myOperation.Faults.Add(myOperationFault);
         Console.WriteLine("Added OperationFault with Name: "
                           + myOperationFault.Name);
         myOperationFault = new OperationFault();
         myOperationFault.Name = "ErrorInt";
         myOperationFault.Message = new XmlQualifiedName
                                             ("s0:GetTradePriceIntFault");
         myOperation.Faults.Add(myOperationFault);
// </Snippet2>
         myOperationCollection.Add(myOperation);
         Console.WriteLine("Added Second OperationFault with Name: "
                  +myOperationFault.Name);
         myServiceDescription.Write("StockQuoteNew_cs.wsdl");
         Console.WriteLine("\nThe file 'StockQuoteNew_cs.wsdl' is " +
                           "created successfully.");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}
// </Snippet1>