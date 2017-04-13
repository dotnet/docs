// System.Web.Services.Description.OperationFaultCollection.Add

/*
 The following example demonstrates the 'Add' method of the
 'OperationFaultCollection' class. Based on 'StockQuote_cs.wsdl', the program generates a WSDL file
 'StockQuoteNew_cs.wsdl' which contains 'Fault' information written out.
*/

using System;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class MyFaultCollectionSample
{
   public static void Main()
   {
      try 
      {
         // Read the 'StockQuote.wsdl' file as input.
         ServiceDescription myServiceDescription = ServiceDescription.
                                               Read("StockQuote_cs.wsdl");
         PortTypeCollection myPortTypeCollection = myServiceDescription.
                                                                PortTypes;
         PortType myPortType = myPortTypeCollection[0];
         OperationCollection myOperationCollection = myPortType.Operations;
         Operation myOperation = myOperationCollection[0];
// <Snippet1>
         OperationFaultCollection myOperationFaultCollection = myOperation.Faults;
         OperationFault myOperationFault = new OperationFault();
         myOperationFault.Name = "ErrorString";
         myOperationFault.Message = new XmlQualifiedName("s0:GetTradePriceStringFault");
         myOperationFaultCollection.Add(myOperationFault);
// </Snippet1>
         Console.WriteLine("Added OperationFault with Name: " +
                           myOperationFault.Name);
         myOperationFault = new OperationFault();
         myOperationFault.Name = "ErrorInt";
         myOperationFault.Message = new XmlQualifiedName
                                             ("s0:GetTradePriceIntFault");
         myOperationFaultCollection.Add(myOperationFault);

         myOperationCollection.Add(myOperation);
         Console.WriteLine("Added Second OperationFault with Name: " +
                           myOperationFault.Name);
         myServiceDescription.Write("StockQuoteNew_cs.wsdl");
         Console.WriteLine("\nThe file 'StockQuoteNew_cs.wsdl' is created" +
                           " successfully.");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}
