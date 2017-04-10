
Imports System
Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security.Tokens
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Text



<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>


Public Class Test
    
    '<snippet1>
    Private Sub DataContractBehavior() 
        Dim b As New WSHttpBinding(SecurityMode.Message)
        Dim baseAddress As New Uri("http://localhost:1066/calculator")
        Dim sh As New ServiceHost(GetType(Calculator), baseAddress)
        sh.AddServiceEndpoint(GetType(ICalculator), b, "")
        
        ' Find the ContractDescription of the operation to find.
        Dim cd As ContractDescription = sh.Description.Endpoints(0).Contract
        Dim myOperationDescription As OperationDescription = cd.Operations.Find("Add")
        
        ' Find the serializer behavior.
        Dim serializerBehavior As DataContractSerializerOperationBehavior = _
        myOperationDescription.Behaviors.Find _
        (Of DataContractSerializerOperationBehavior)()
        
        ' If the serializer is not found, create one and add it.
        If serializerBehavior Is Nothing Then
            serializerBehavior = New DataContractSerializerOperationBehavior(myOperationDescription)
            myOperationDescription.Behaviors.Add(serializerBehavior)
        End If
        
        ' Change settings of the behavior.
        serializerBehavior.MaxItemsInObjectGraph = 10000
        serializerBehavior.IgnoreExtensionDataObject = True
        
        sh.Open()
        Console.WriteLine("Listening")
        Console.ReadLine()
    
    End Sub 
    '</snippet1>

    '<snippet2>
    Private Sub PrintDescription(ByVal sh As ServiceHost) 
        ' Declare variables.
        Dim i, j, k, l, c As Integer
        Dim servDesc As ServiceDescription = sh.Description
        Dim opDesc As OperationDescription
        Dim contractDesc As ContractDescription
        Dim methDesc As MessageDescription
        Dim mBodyDesc As MessageBodyDescription
        Dim partDesc As MessagePartDescription
        Dim servBeh As IServiceBehavior
        Dim servEP As ServiceEndpoint
        
        ' Print the behaviors of the service.
        Console.WriteLine("Behaviors:")
        For c = 0 To servDesc.Behaviors.Count-1
            servBeh = servDesc.Behaviors(c)
            Console.WriteLine(vbTab + "{0}", servBeh)
        Next c
        
        ' Print the endpoint descriptions of the service.
        Console.WriteLine("Endpoints")
        For i = 0 To servDesc.Endpoints.Count-1
            ' Print the endpoint names.
            servEP = servDesc.Endpoints(i)
            Console.WriteLine(vbTab + "Name: {0}", servEP.Name)
            contractDesc = servEP.Contract
            
            Console.WriteLine(vbTab + "Operations:")
            For j = 0 To contractDesc.Operations.Count-1
                ' Print operation names.
                opDesc = servEP.Contract.Operations(j)
                Console.WriteLine(vbTab + vbTab + "{0}", opDesc.Name)
                Console.WriteLine(vbTab + vbTab + "Actions:")
                For k = 0 To opDesc.Messages.Count-1
                    ' Print the message action. 
                    methDesc = opDesc.Messages(k)
                    Console.WriteLine(vbTab + vbTab + vbTab + _
                      "Action:{0}", methDesc.Action)
                    
                    ' Check for the existence of a body, then the body description.
                    mBodyDesc = methDesc.Body
                    If mBodyDesc.Parts.Count > 0 Then
                        For l = 0 To methDesc.Body.Parts.Count-1
                            partDesc = methDesc.Body.Parts(l)
                            Console.WriteLine(vbTab + vbTab + _
                            vbTab + vbTab + "{0}", partDesc.Name)
                        Next l
                    End If
                Next k
            Next j
        Next i
    
    End Sub     
    '</snippet2>

    Shared Sub Main() 
        Try
            Dim t As New Test()
            t.DataContractBehavior()
        Catch exc As System.Exception
            Console.WriteLine(exc.Message)
            Console.ReadLine()
        End Try
    
    End Sub 
End Class 

<ServiceContract()>  _
Interface ICalculator
    <OperationContract()>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
    
    <OperationContract()>  _
    Function GetInfo(ByVal request As String) As String 
End Interface 


<MessageContract(ProtectionLevel := _
System.Net.Security.ProtectionLevel.Sign)>  _
Public Class Calculator
    Implements ICalculator
    
    
    Public Function Add(ByVal a As Double, ByVal b As Double) As Double _
    Implements ICalculator.Add
        Return a + b
    
    End Function 'Add
    
    
    
    Public Function GetInfo(ByVal request As String) As String _
    Implements ICalculator.GetInfo
        If request = "Version" Then
            Return "1.0"
        Else
            Return "Calculator 1.0"
        End If
    
    End Function 
End Class 