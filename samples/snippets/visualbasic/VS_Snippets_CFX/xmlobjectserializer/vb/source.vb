Imports System
Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Text

<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
'<snippet1>    
Public Class Test
    
    Private Sub WriteObjectWithInstance(ByVal xm As XmlObjectSerializer, _
      ByVal graph As Company, ByVal fileName As String) 
        ' Use either the XmlDataContractSerializer or NetDataContractSerializer,
        ' or any other class that inherits from XmlObjectSerializer to write with.
        Console.WriteLine(xm.GetType())
        Dim fs As New FileStream(fileName, FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        xm.WriteObject(writer, graph)
        Console.WriteLine("Done writing {0}", fileName)
    
    End Sub 
    
    
    Private Sub Run() 
        ' Create the object to write to a file.
        Dim graph As New Company()
        graph.Name = "cohowinery.com"
        
        ' Create a DataContractSerializer and a NetDataContractSerializer.
        ' Pass either one to the WriteObjectWithInstance method.
        Dim dcs As New DataContractSerializer(GetType(Company))
        Dim ndcs As New NetDataContractSerializer()
        WriteObjectWithInstance(dcs, graph, "datacontract.xml")
        WriteObjectWithInstance(ndcs, graph, "netDatacontract.xml")
    
    End Sub 
    
    <DataContract()>  _
    Public Class Company
        <DataMember()>  _
        Public Name As String
    End Class 
    
    
    Shared Sub Main() 
        Try
            Console.WriteLine("Starting")
            Dim t As New Test()
            t.Run()
            Console.WriteLine("Done")
            Console.ReadLine()
        
        Catch iExc As InvalidDataContractException
            Console.WriteLine("You have an invalid data contract: ")
            Console.WriteLine(iExc.Message)
            Console.ReadLine()
        
        Catch serExc As SerializationException
            Console.WriteLine("There is a problem with the instance:")
            Console.WriteLine(serExc.Message)
            Console.ReadLine()
        
        Catch qExc As QuotaExceededException
            Console.WriteLine("The quota has been exceeded")
            Console.WriteLine(qExc.Message)
            Console.ReadLine()
        Catch exc As Exception
            Console.WriteLine(exc.Message)
            Console.WriteLine(exc.ToString())
            Console.ReadLine()
        End Try
    
    End Sub 
End Class 
'</snippet1>
