 ' OptionalReliableSession Class
Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Globalization
Imports System.Net
Imports System.Net.Security
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Security
Imports System.Text
Imports System.Xml

Class MyService

    Shared Sub Main()
        Dim m As New MyService()
        m.Run()

    End Sub

    '<snippet0>
    Private Sub Run()
        '<snippet1>
        Dim b As New WSHttpBinding()
        b.Name = "HttpOrderedReliableSessionBinding"

        ' Get a reference to the OptionalreliableSession object of the 
        ' binding and set its properties to new values.
        Dim myReliableSession As OptionalReliableSession = b.ReliableSession
        myReliableSession.Enabled = True ' The default is false.
        myReliableSession.Ordered = False ' The default is true. 
        myReliableSession.InactivityTimeout = New TimeSpan(0, 15, 0)
        ' The default is 10 minutes.
        '</snippet1> 
        ' Create a URI for the service's base address.
        Dim baseAddress As New Uri("http://localhost:8008/Calculator")

        ' Create a service host.
        Dim sh As New ServiceHost(GetType(Calculator), baseAddress)

        ' Optional: Print out the binding information. 
        PrintBindingInfo(b)
        ' Create a URI for an endpoint, then add a service endpoint using the
        ' binding with the latered OptionalReliableSession settings.
        sh.AddServiceEndpoint(GetType(ICalculator), b, "ReliableCalculator")
        sh.Open()

        Console.WriteLine("Listening...")
        Console.ReadLine()
        sh.Close()
    End Sub

    Private Sub PrintBindingInfo(ByVal b As WSHttpBinding)
        Console.WriteLine(b.Name)
        Console.WriteLine("Enabled: {0}", b.ReliableSession.Enabled)
        Console.WriteLine("Ordered: {0}", b.ReliableSession.Ordered)
        Console.WriteLine("Inactivity in Minutes: {0}", b.ReliableSession.InactivityTimeout.TotalMinutes)

    End Sub
    '</snippet0>
End Class




<ServiceContract()>  _
Interface ICalculator
    <OperationContract()>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
End Interface 'ICalculator


Public Class Calculator
    Implements ICalculator
    
    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return a + b
    
    End Function 'Add
End Class 'Calculator
