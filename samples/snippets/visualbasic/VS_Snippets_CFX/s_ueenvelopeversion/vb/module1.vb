' Snippet for System.ServiceModel.EnvelopeVersion
' <Snippet0>


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Text

Namespace CS
    Module Module1
        Sub Main(ByVal args() As String)

            ' MessageVersion
            ' <Snippet1>
            Dim envS11 As EnvelopeVersion = EnvelopeVersion.Soap11
            ' </Snippet1>
            Dim nextDestS11 As String = envS11.NextDestinationActorValue
            Dim ultDestsS11() As String = envS11.GetUltimateDestinationActorValues()
            Dim ultS11 As String = ultDestsS11(0)
            Dim toStrS11 As String = envS11.ToString()

            ' <Snippet2>
            Dim envS12 As EnvelopeVersion = EnvelopeVersion.Soap12
            ' </Snippet2>

            ' <Snippet3>
            Dim envNotSOAP As EnvelopeVersion = EnvelopeVersion.None
            ' </Snippet3>

            ' <Snippet4>
            Dim nextDestS12 As String = envS12.NextDestinationActorValue
            ' </Snippet4>

            ' <Snippet5>
            Dim ultDestsS12() As String = envS12.GetUltimateDestinationActorValues()
            ' </Snippet5>

            Dim ultS12 As String = ultDestsS12(1)

            ' <Snippet6>
            Dim toStrS12 As String = envS12.ToString()
            ' </Snippet6>

            Dim envNone As EnvelopeVersion = EnvelopeVersion.None
            Dim nextDestNone As String = envNone.NextDestinationActorValue
            'The following code throws a System.ArgumentReferenceExeption.
            'The object reference is not set to an instance of an object
            ' string[] ultDestsNone = envNone.GetUltimateDestinationActorValues();
            Dim toStrNone As String = envNone.ToString()

            'EnvelopeVersions
            Console.WriteLine("EnvelopeVersion.Soap11: {0}", envS11)
            Console.WriteLine("EnvelopeVersion.Soap12: {0}", envS12)
            Console.WriteLine("EnvelopeVersion.None: {0}", envNone)
            Console.WriteLine()

            'NextDestination
            Console.WriteLine("NextDest EnvelopeVersion.Soap11: {0}", nextDestS11)
            Console.WriteLine("NextDest EnvelopeVersion.Soap12: {0}", nextDestS12)
            Console.WriteLine("NextDest EnvelopeVersion.None: {0}", nextDestNone)
            Console.WriteLine()

            'UltimateDestinations
            Console.WriteLine("UltDest EnvelopeVersion.Soap11: {0}", ultS11)
            Console.WriteLine("UltDest EnvelopeVersion.Soap12: {0}", ultS12)
            'Console.WriteLine("UltDest EnvelopeVersion.None: {0}", ultDestsNone);
            Console.WriteLine()

            'ToString
            Console.WriteLine("EnvelopeVersion.Soap11.ToString(): {0}", toStrS11)
            Console.WriteLine("EnvelopeVersion.Soap11.ToString(): {0}", toStrS12)
            Console.WriteLine("EnvelopeVersion.Soap11.ToString(): {0}", toStrNone)
            Console.WriteLine()

        End Sub
    End Module
End Namespace
'
' * 
' * 
' * 
'Output:
'EnvelopeVersion.Soap11: Soap11 (http://schemas.xmlsoap.org/soap/envelope/)
'EnvelopeVersion.Soap12: Soap12 (http://www.w3.org/2003/05/soap-envelope)
'EnvelopeVersion.None: EnvelopeNone (http://schemas.microsoft.com/ws/2005/05/envelope/none)
'
'NextDest EnvelopeVersion.Soap11: http://schemas.xmlsoap.org/soap/actor/next
'NextDest EnvelopeVersion.Soap12: http://www.w3.org/2003/05/soap-envelope/role/next
'NextDest EnvelopeVersion.None:
'
'UltDest EnvelopeVersion.Soap11:
'UltDest EnvelopeVersion.Soap12:
'
'EnvelopeVersion.Soap11.ToString(): Soap11 (http://schemas.xmlsoap.org/soap/envelope/)
'EnvelopeVersion.Soap11.ToString(): Soap12 (http://www.w3.org/2003/05/soap-envelope)
'EnvelopeVersion.Soap11.ToString(): EnvelopeNone (http://schemas.microsoft.com/ws/2005/05/envelope/none)
'

' </Snippet0>
