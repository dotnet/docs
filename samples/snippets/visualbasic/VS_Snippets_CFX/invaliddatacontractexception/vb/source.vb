Imports System
Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.Data

<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
'<snippet1>    
Public Class Test
    
    Shared Sub Main() 
        Try
            Dim t As New Test()
            t.Run()
        
        ' Catch the InvalidDataContractException here.
        Catch iExc As InvalidDataContractException
            Console.WriteLine("You have an invalid data contract: ")
            Console.WriteLine(iExc.Message)
            Console.ReadLine()
        
        Catch exc As Exception
            Console.WriteLine(exc.Message)
            Console.WriteLine(exc.ToString())
            Console.ReadLine()
        End Try
    
    End Sub 
    
    Private Sub Run() 
        ' Create a new WSHttpBinding and set the security mode to Message;
        Dim b As New WSHttpBinding(SecurityMode.Message)
        
        ' Create a ServiceHost instance, and add a metadata endpoint.
        Dim baseUri As New Uri("http://localhost:1008/")
        Dim sh As New ServiceHost(GetType(Calculator), baseUri)
        
        ' Optional. Add a metadata endpoint. The method is defined below.
        AddMetadataEndpoint(sh)
        
        ' Add an endpoint using the binding, and open the service.
        sh.AddServiceEndpoint(GetType(ICalculator), b, "myCalculator")
        sh.Open()
        
        Console.WriteLine("Listening...")
        Console.ReadLine()
    
    End Sub 
    
    Private Sub AddMetadataEndpoint(ByRef sh As ServiceHost) 
        Dim mex As New Uri("http://localhost:1001/metadata/")
        Dim sm As New ServiceMetadataBehavior()
        sm.HttpGetEnabled = True
        sm.HttpGetUrl = mex
        sh.Description.Behaviors.Add(sm)
    
    End Sub 
End Class 

' This class will cause an InvalidDataContractException to be thrown because
' neither the DataContractAttribute nor DataMemberAttribute has been applied to it.

Public Class ExtraData
    Public RandomData As System.Collections.Generic.List(Of String)
End Class 

<ServiceContract(ProtectionLevel := System.Net.Security.ProtectionLevel.EncryptAndSign)>  _
Interface ICalculator
    <OperationContract()>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
    
    <OperationContract()>  _
    Function MoreData() As ExtraData 
End Interface 

Public Class Calculator
    Implements ICalculator
    
    Public Function Add(ByVal a As Double, ByVal b As Double) As Double _
    Implements ICalculator.Add
        Return a + b
    End Function 
        
    Public Function MoreData() As ExtraData Implements ICalculator.MoreData
        Dim ex As New ExtraData()
        ex.RandomData.Add("Hello")
        ex.RandomData.Add("World")
        Return ex
    End Function 
End Class 
'</snippet1>