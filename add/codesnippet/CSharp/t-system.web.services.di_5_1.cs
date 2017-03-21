using System;
using System.Web.Services.Discovery;
using System.Xml;
using System.Collections;
using System.Runtime.Remoting;
using System.Net;

public class MySample
{
   static void Main()
   {
      string myDiscoFile = "http://localhost/MathService_cs.disco";
      string myUrlKey = "http://localhost/MathService_cs.asmx?wsdl";
      DiscoveryClientProtocol myDiscoveryClientProtocol1 = 
                                            new DiscoveryClientProtocol();
      DiscoveryDocument myDiscoveryDocument = 
                         myDiscoveryClientProtocol1.Discover(myDiscoFile);
      IEnumerator myEnumerator = 
                           myDiscoveryDocument.References.GetEnumerator();
      while ( myEnumerator.MoveNext() )
      {
         ContractReference myContractReference =
                                  (ContractReference)myEnumerator.Current;
         DiscoveryClientProtocol myDiscoveryClientProtocol2 = 
                                       myContractReference.ClientProtocol;
         myDiscoveryClientProtocol2.ResolveAll();
         DiscoveryExceptionDictionary myExceptionDictionary 
                                      = myDiscoveryClientProtocol2.Errors;
         if ( myExceptionDictionary.Contains(myUrlKey) == true )
         {
            Console.WriteLine("'myExceptionDictionary' contains " +
                      " a discovery exception for the key '" + myUrlKey + "'");
         }
         else
         {
            Console.WriteLine("'myExceptionDictionary' does not contain" +
                      " a discovery exception for the key '" + myUrlKey + "'");
         }
         if (myExceptionDictionary.Contains(myUrlKey) == true )
         {
            Console.WriteLine("System generated exceptions.");

            Exception myException = myExceptionDictionary[myUrlKey];
            Console.WriteLine(" Source : " + myException.Source);
            Console.WriteLine(" Exception : " + myException.Message);

            Console.WriteLine();

            // Remove the discovery exception.for the key 'myUrlKey'.
            myExceptionDictionary.Remove(myUrlKey);

            DiscoveryExceptionDictionary myNewExceptionDictionary =
                                       new DiscoveryExceptionDictionary();
            // Add an exception with the custom error message.
            Exception myNewException = 
                 new Exception("The requested service is not available.");
            myNewExceptionDictionary.Add(myUrlKey, myNewException);
            myExceptionDictionary = myNewExceptionDictionary;

            Console.WriteLine("Added exceptions.");

            object[] myArray = new object[myExceptionDictionary.Count];
            myExceptionDictionary.Keys.CopyTo((Array)myArray,0);
            Console.WriteLine(" Keys are :");
            foreach(object myObj in myArray)
            {
               Console.WriteLine(" " + myObj.ToString());
            }

            Console.WriteLine();

            object[] myCollectionArray = new object[myExceptionDictionary.Count];
            myExceptionDictionary.Values.CopyTo((Array)myCollectionArray,0);
            Console.WriteLine(" Values are :");
            foreach(object myObj in myCollectionArray)
            {
               Console.WriteLine(" " + myObj.ToString());
            }
         }
      }
   }
}