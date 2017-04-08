// Snippet for System.ServiceModel.EnvelopeVersion
// <Snippet0>

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {

     // MessageVersion
     // <Snippet1>
     EnvelopeVersion envS11 = EnvelopeVersion.Soap11;
     // </Snippet1>
     string nextDestS11 = envS11.NextDestinationActorValue;
     string[] ultDestsS11 = envS11.GetUltimateDestinationActorValues();
     string ultS11 = ultDestsS11[0];
     string toStrS11 = envS11.ToString();

     // <Snippet2>
     EnvelopeVersion envS12 = EnvelopeVersion.Soap12;
     // </Snippet2>

     // <Snippet3>
     EnvelopeVersion envNotSOAP =  EnvelopeVersion.None;
     // </Snippet3>

     // <Snippet4>
     string nextDestS12 = envS12.NextDestinationActorValue;
     // </Snippet4>

     // <Snippet5>
     string[] ultDestsS12 = envS12.GetUltimateDestinationActorValues();
     // </Snippet5>
     
     string ultS12 = ultDestsS12[1];

     // <Snippet6>
     string toStrS12 = envS12.ToString();
     // </Snippet6>
     
     EnvelopeVersion envNone = EnvelopeVersion.None;
     string nextDestNone = envNone.NextDestinationActorValue;
     //The following code throws a System.ArgumentReferenceExeption.
     //The object reference is not set to an instance of an object
     // string[] ultDestsNone = envNone.GetUltimateDestinationActorValues();
     string toStrNone = envNone.ToString();

     //EnvelopeVersions
     Console.WriteLine("EnvelopeVersion.Soap11: {0}", envS11);
     Console.WriteLine("EnvelopeVersion.Soap12: {0}", envS12);
     Console.WriteLine("EnvelopeVersion.None: {0}", envNone);
     Console.WriteLine();

     //NextDestination
     Console.WriteLine("NextDest EnvelopeVersion.Soap11: {0}", nextDestS11);
     Console.WriteLine("NextDest EnvelopeVersion.Soap12: {0}", nextDestS12);
     Console.WriteLine("NextDest EnvelopeVersion.None: {0}", nextDestNone);
     Console.WriteLine();

     //UltimateDestinations
     Console.WriteLine("UltDest EnvelopeVersion.Soap11: {0}", ultS11);
     Console.WriteLine("UltDest EnvelopeVersion.Soap12: {0}", ultS12);
     //Console.WriteLine("UltDest EnvelopeVersion.None: {0}", ultDestsNone);
     Console.WriteLine();

     //ToString
     Console.WriteLine("EnvelopeVersion.Soap11.ToString(): {0}", toStrS11);
     Console.WriteLine("EnvelopeVersion.Soap11.ToString(): {0}", toStrS12);
      Console.WriteLine("EnvelopeVersion.Soap11.ToString(): {0}", toStrNone);
      Console.WriteLine();

        }
    }
}
/*
 * 
 * 
 * 
Output:
EnvelopeVersion.Soap11: Soap11 (http://schemas.xmlsoap.org/soap/envelope/)
EnvelopeVersion.Soap12: Soap12 (http://www.w3.org/2003/05/soap-envelope)
EnvelopeVersion.None: EnvelopeNone (http://schemas.microsoft.com/ws/2005/05/envelope/none)

NextDest EnvelopeVersion.Soap11: http://schemas.xmlsoap.org/soap/actor/next
NextDest EnvelopeVersion.Soap12: http://www.w3.org/2003/05/soap-envelope/role/next
NextDest EnvelopeVersion.None:

UltDest EnvelopeVersion.Soap11:
UltDest EnvelopeVersion.Soap12:

EnvelopeVersion.Soap11.ToString(): Soap11 (http://schemas.xmlsoap.org/soap/envelope/)
EnvelopeVersion.Soap11.ToString(): Soap12 (http://www.w3.org/2003/05/soap-envelope)
EnvelopeVersion.Soap11.ToString(): EnvelopeNone (http://schemas.microsoft.com/ws/2005/05/envelope/none)
*/

// </Snippet0>
