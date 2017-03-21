Namespace DataContractAttributeExample
    ' Set the Name and Namespace properties to new values.
    <DataContract(Name := "Customer", [Namespace] := "http://www.contoso.com")>  _
    Class Person
        Implements IExtensibleDataObject
        ' To implement the IExtensibleDataObject interface, you must also
        ' implement the ExtensionData property.
        Private extensionDataObjectValue As ExtensionDataObject 
        
        Public Property ExtensionData() As ExtensionDataObject _
          Implements IExtensibleDataObject.ExtensionData
            Get
                Return extensionDataObjectValue
            End Get
            Set
                extensionDataObjectValue = value
            End Set
        End Property
        
        <DataMember(Name := "CustName")>  _
        Friend Name As String
        
        <DataMember(Name := "CustID")>  _
        Friend ID As Integer
        
        
        Public Sub New(ByVal newName As String, ByVal newID As Integer) 
            Name = newName
            ID = newID
        
        End Sub 
    End Class 
    
    
    Class Test
        
        Public Shared Sub Main() 
            Try
                WriteObject("DataContractExample.xml")
                ReadObject("DataContractExample.xml")
                Console.WriteLine("Press Enter to end")
                Console.ReadLine()
            Catch se As SerializationException
                Console.WriteLine("The serialization operation failed. Reason: {0}", _
                   se.Message)
                Console.WriteLine(se.Data)
                Console.ReadLine()
            End Try
        
        End Sub 
        
        
        Public Shared Sub WriteObject(ByVal path As String) 
            ' Create a new instance of the Person class and 
            ' serialize it to an XML file.
            Dim p1 As New Person("Mary", 1)
            ' Create a new instance of a StreamWriter
            ' to read and write the data.
            Dim fs As New FileStream(path, FileMode.Create)
            Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
            Dim ser As New DataContractSerializer(GetType(Person))
            ser.WriteObject(writer, p1)
            Console.WriteLine("Finished writing object.")
            writer.Close()
            fs.Close()
        
        End Sub 
        
        Public Shared Sub ReadObject(ByVal path As String) 
            ' Deserialize an instance of the Person class 
            ' from an XML file. First create an instance of the 
            ' XmlDictionaryReader.
            Dim fs As New FileStream(path, FileMode.OpenOrCreate)
            Dim reader As XmlDictionaryReader = XmlDictionaryReader. _
              CreateTextReader(fs, New XmlDictionaryReaderQuotas())
            
            ' Create the DataContractSerializer instance.
            Dim ser As New DataContractSerializer(GetType(Person))
            
            ' Deserialize the data and read it from the instance.
            Dim newPerson As Person = CType(ser.ReadObject(reader), Person)
            Console.WriteLine("Reading this object:")
            Console.WriteLine(String.Format("{0}, ID: {1}", newPerson.Name, newPerson.ID))
            fs.Close()
        
        End Sub 
    End Class 
End Namespace 