Imports System
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Security.Permissions

<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>

'<snippet1>
<DataContract()>  _
Public Enum Position
    <EnumMember(Value:="Emp")> Employee
    <EnumMember(Value:="Mgr")> Manager
    <EnumMember(Value:="Ctr")> Contractor
    NotASerializableEnumeration
    
End Enum 

<DataContract()>  _
Public Class Person
    Implements IExtensibleDataObject
    
    Public Sub New(ByVal firstNameValue As String, _
       ByVal lastNameValue As String) 
        LastName = firstNameValue
        FirstName = lastNameValue
    
    End Sub 
    
    Private extensioDataValue As ExtensionDataObject 
    
    Public Property ExtensionData() As ExtensionDataObject _
       Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensioDataValue
        End Get
        Set
            extensioDataValue = value
        End Set
    End Property 

    <DataMember()>  _
    Friend FirstName As String

    <DataMember()>  _
    Friend LastName As String

    <DataMember()>  _
    Friend Description As Position

End Class 


NotInheritable Public Class Test
    
    Private Sub New() 
    
    End Sub
    
    Shared Sub Main() 
        WriteObject("Enum.xml")
        Console.ReadLine()
    
    End Sub 
    
    
    Shared Sub WriteObject(ByVal path As String) 
        Console.WriteLine("Writing...")
        Dim p As New Person("Denise", "Smith")
        p.Description = Position.Manager
        
        Dim fs As New FileStream(path, FileMode.Create)
        
        Try
            Dim ser As New DataContractSerializer(GetType(Person))
            ser.WriteObject(fs, p)
            Console.WriteLine("Done")
        Catch exc As SerializationException
            Console.WriteLine(exc.Message)
            Console.WriteLine(exc.StackTrace)
        Finally
            fs.Close()
        End Try
    
    End Sub 
End Class 
'</snippet1>

'<snippet3>
 <DataContract> _
Public Enum Shapes
    <EnumMember(Value:="1")> Circle
    <EnumMember(Value:="2")> Square   
End Enum 
'</snippet3>