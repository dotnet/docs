' You must apply a DataContractAttribute or SerializableAttribute
' to a class to have it serialized by the NetDataContractSerializer.
<DataContract(Name := "Customer", [Namespace] := "http://www.contoso.com")>  _
Class Person
    Implements IExtensibleDataObject
    <DataMember()>  _
    Public FirstName As String
    <DataMember()>  _
    Public LastName As String
    <DataMember()>  _
    Public ID As Integer
    
    
    Public Sub New(ByVal newfName As String, ByVal newLName As String, _
       ByVal newID As Integer) 
        FirstName = newfName
        LastName = newLName
        ID = newID
    
    End Sub 
    
    Private extensionData_Value As ExtensionDataObject
    
    
    Public Property ExtensionData() As ExtensionDataObject _
     Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionData_Value
        End Get
        Set
            extensionData_Value = value
        End Set
    End Property
End Class 


NotInheritable Public Class Test

    Private Sub New() 
    
    End Sub
     
    Public Shared Sub Main() 
        Try
            WriteObject("NetDataContractSerializerExample.xml")
            ReadObject("NetDataContractSerializerExample.xml")
        
        Catch serExc As SerializationException
            Console.WriteLine("Serialization Failed")
            Console.WriteLine(serExc.Message)
        Catch exc As Exception
            Console.WriteLine("The serialization operation failed: {0} StackTrace: {1}", exc.Message, exc.StackTrace)
        
        Finally
            Console.WriteLine("Press <Enter> to exit....")
            Console.ReadLine()
        End Try
    
    End Sub 
    
    
    Public Shared Sub WriteObject(ByVal fileName As String) 
        Console.WriteLine("Creating a Person object and serializing it.")
        Dim p1 As New Person("Zighetti", "Barbara", 101)
        Dim fs As New FileStream(fileName, FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()

        ser.WriteObject(writer, p1)
        writer.Close()
    
    End Sub     

    Public Shared Sub ReadObject(ByVal fileName As String) 
        Console.WriteLine("Deserializing an instance of the object.")
        Dim fs As New FileStream(fileName, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
           XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()
        
        ' Deserialize the data and read it from the instance.
        Dim deserializedPerson As Person = CType(ser.ReadObject(reader, True), Person)
        fs.Close()
        Console.WriteLine(String.Format("{0} {1}, ID: {2}", deserializedPerson.FirstName, deserializedPerson.LastName, deserializedPerson.ID))
    
    End Sub 
End Class 