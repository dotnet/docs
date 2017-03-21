Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml

' You must apply a DataContractAttribute or SerializableAttribute
' to a class to have it serialized by the DataContractSerializer.
<DataContract()>  _
Class Person
    Implements IExtensibleDataObject

    Private LastNameValue As String
     
    ' Apply the DataMemberAttribute to fields (or properties) 
    ' that must be serialized.
    
    <DataMember()>  _
    Public FirstName As String
    
    <DataMember()>  _
    Public Property LastName() As String
        Get
            Return LastNameValue 
        End Get

        Set(ByVal Value As String)
           LastNameValue = Value
        End Set
    End Property

    
    <DataMember(Name:="ID")>  _
    Public IdNumber As Integer
    
    ' Note that you can apply the DataMemberAttribute to 
    ' a private field as well.
    <DataMember()>  _
    Private Secret As String
    
    Public Sub New(ByVal newfName As String, ByVal newLName As String, ByVal newIdNumber As Integer) 
        FirstName = newfName
        LastName = newLName
        IdNumber = newIdNumber
        Secret = newfName + newLName + newIdNumber.ToString()
    
    End Sub 
    
    ' The ExtensionData field holds data from future versions 
    ' of the type.  This enables this type to be compatible with 
    ' future versions. The field is required to implement the 
    ' IExtensibleObjectData interface.
    Private extensionDataValue As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject _
       Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionDataValue
        End Get
        Set
            extensionDataValue = value
        End Set
    End Property
End Class 

Public Class Test
    Public Shared Sub Main(ByVal args() As String) 
        Try
            ReadObject("DataMemberAttributeExample.xml")
            WriteObject("DataMemberAttributeExample.xml")
        Catch exc As Exception
            Console.WriteLine("The serialization operation failed: {0} StackTrace: {1}", _
            exc.Message, exc.StackTrace)
        Finally
            Console.WriteLine("Press <Enter> to exit....")
            Console.ReadLine()
        End Try
    End Sub 
    
    Public Shared Sub ReadObject(ByVal filename As String) 
        ' Create a new instance of the Person class.
        Dim p1 As New Person("Zighetti", "Barbara", 101)
        Dim writer As New FileStream(filename, FileMode.Create)
        Dim ser As New DataContractSerializer(GetType(Person))
        ser.WriteObject(writer, p1)
        writer.Close()
    End Sub 

    Public Shared Sub WriteObject(ByVal filename As String) 
        ' Deserialize an instance of the Person class 
        ' from an XML file.
        Dim fs As New FileStream(filename, FileMode.OpenOrCreate)
        Dim ser As New DataContractSerializer(getTYpe(Person))
        ' Deserialize the data and read it from the instance.
        Dim deserializedPerson As Person = ser.ReadObject(fs)
        fs.Close()
        Console.WriteLine(String.Format("{0} {1}, ID: {2}", _
        deserializedPerson.FirstName, deserializedPerson.LastName, deserializedPerson.IdNumber))
    End Sub 
End Class 