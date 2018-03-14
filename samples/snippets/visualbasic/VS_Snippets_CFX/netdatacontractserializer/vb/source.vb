Imports System.Security.Permissions
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.CodeDom
Imports System.Reflection
Imports System.IO
Imports System.Xml
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization
Imports System.Xml.Linq

<assembly: CLSCompliant(True)>
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
Namespace Examples.NetDataContractSerializer

'<snippet0>
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
    
    
    '<snippet1>
    Public Shared Sub WriteObject(ByVal fileName As String) 
        Console.WriteLine("Creating a Person object and serializing it.")
        Dim p1 As New Person("Zighetti", "Barbara", 101)
        Dim fs As New FileStream(fileName, FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()

        ser.WriteObject(writer, p1)
        writer.Close()
    
    End Sub     
    '</snippet1>

    '<snippet2>
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
    '</snippet2>
End Class 
'</snippet0>

'<snippet3>
<DataContract()>  _
Public Class GetCurrency
    Implements IExtensibleDataObject
    <DataMemberAttribute()>  _
    Private Country_value As String
    
    Public Property Country() As String 
        Get
            Return Country_value
        End Get
        Set
            Country_value = value
        End Set
    End Property 

    ' Note that this field is not serialized. Instead, it is 
    ' populated after serialization.
    Private Currency_value As String
    
    Public Property Currency() As String 
        Get
            Return Currency_value
        End Get
        Set
            Currency_value = value
        End Set
    End Property
     
    ' Use this method to look up the country/region and set 
    ' the Currency field after deserialization.
    <OnDeserialized()>  _
    Private Sub GetLocalRate(ByVal sc As StreamingContext) 
        If Me.Country = "Japan" Then
            Me.Currency = "Yen"
        End If
    
    End Sub 

    ' Implement the IExensibleDataObject interface to 
    ' retain future version information.
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
'</snippet3>

'<snippet4>
<DataContract(Name := "PurchaseOrder", [Namespace] := "urn:www.Microsoft.com")>  _
Public Class PurchaseOrder
    Implements IExtensibleDataObject
    Private purchaseDate_value As DateTime
    
    
    <DataMember()>  _
    Public Property PurchaseDate() As DateTime 
        Get
            Return purchaseDate_value
        End Get
        Set
            purchaseDate_value = Value
        End Set
    End Property 

    Private extensionData_value As ExtensionDataObject

    Public Property ExtensionData() As ExtensionDataObject _
    Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionData_value
        End Get
        Set
            extensionData_value = value
        End Set
    End Property
End Class 

<DataContract(Name := "PurchaseOrder", [Namespace] := "urn:www.Microsoft.com")>  _
Public Class PurchaseOrderV2
    Implements IExtensibleDataObject
    Private purchaseDate_value As DateTime
    
    <DataMember()>  _
    Public Property PurchaseDate() As DateTime 
        Get
            Return purchaseDate_value
        End Get
        Set
            purchaseDate_value = value
        End Set
    End Property 
    <DataMember()>  _
    Private purchaseOrderId_value As Integer
    
    
    Public Property PurchaseOrderId() As Integer 
        Get
            Return purchaseOrderId_value
        End Get
        Set
            purchaseOrderId_value = value
        End Set
    End Property 
    Private extensionData_value As ExtensionDataObject
    
    
    Public Property ExtensionData() As ExtensionDataObject _
     Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionData_value
        End Get
        Set
            extensionData_value = value
        End Set
    End Property
End Class 

NotInheritable Public Class TestFutureCompatibleTypes
    
    Private Sub New() 
    
    End Sub 'New
     
    Public Shared Sub RunTest() 
        SerializeNewVersion("myTestFile.xml")
        DeserializeAndSerialize("myTestFile.xml")
        DeserializeToNewVersion("myTestFile.xml")
        Console.ReadLine()
    
    End Sub 
    
    Shared Sub SerializeNewVersion(ByVal path As String) 
        Console.WriteLine("Serializing new version of a contract.")
        Dim fs As New FileStream(path, FileMode.Create)
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()
        Dim PO_V2 As New PurchaseOrderV2()
        PO_V2.PurchaseDate = DateTime.Now
        PO_V2.PurchaseOrderId = 1234
        ser.WriteObject(fs, PO_V2)
        fs.Close()
        Console.WriteLine("Order Date: {0}", PO_V2.PurchaseDate.ToLongDateString())
        Console.WriteLine("Order ID:{0}", PO_V2.PurchaseOrderId)
    
    End Sub 
    
    Shared Sub DeserializeAndSerialize(ByVal path As String) 
        Console.WriteLine("Deserializing new version to old version")
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
           XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        
        ' Create the serializer.
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()
        ' Deserialize version 1 of the data.
        Dim PO_V1 As PurchaseOrder = CType(ser.ReadObject(reader, False), PurchaseOrder)
        Console.WriteLine("Order Date:{0}", PO_V1.PurchaseDate.ToLongDateString())
        fs.Close()
        
        Console.WriteLine("Reserialize the object with extension data intact")
        ' First change the order date.
        Dim newDate As DateTime = PO_V1.PurchaseDate.AddDays(10)
        PO_V1.PurchaseDate = newDate
        
        ' Create a new FileStream to write with.
        Dim writer As New FileStream(path, FileMode.Create)
        ' Serialize the object with changed data.
        ser.WriteObject(writer, PO_V1)
        writer.Close()
    
    End Sub 
    
    Shared Sub DeserializeToNewVersion(ByVal path As String) 
        Console.WriteLine("Deserializing to new version, extension data intact")
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
           XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()
        Dim newOrder As PurchaseOrderV2 = CType(ser.ReadObject(reader, False), PurchaseOrderV2)
        Console.WriteLine("Original OrderID: {0}", newOrder.PurchaseOrderId)
        Console.WriteLine("New Order Date: {0}", newOrder.PurchaseDate.ToLongDateString())
        fs.Close()
    
    End Sub 
End Class 
'</snippet4>

'<snippet5>
NotInheritable Public Class ShowWriteStartObject
     
    Public Shared Sub WriteObjectData(ByVal path As String) 
        ' Create the object to serialize.
        Dim p As New Person("Lynn", "Tsoflias", 9876)
        
        ' Create the writer.
        Dim fs As New FileStream(path, FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()        

        ' Use the writer to start a document.
        writer.WriteStartDocument(True)
        
        ' Use the serializer to write the start of the 
        ' object data. Use it again to write the object
        ' data. 
        ser.WriteStartObject(writer, p)
        writer.WriteStartAttribute("MyAttribute")
        writer.WriteString("My Text")
        writer.WriteEndAttribute()

        ser.WriteObjectContent(writer, p)
                
        ' Use the serializer to write the end of the 
        ' object data. Then use the writer to write the end
        ' of the document.
        ser.WriteEndObject(writer)
        writer.WriteEndDocument()
        
        Console.WriteLine("Done")
        
        ' Close and release the writer resources.
        writer.Flush()
        fs.Flush()
        fs.Close()
    
    End Sub 
    '</snippet5>

    '<snippet6>
    Public Shared Sub ReadObjectData(ByVal path As String) 
        ' Create the reader.
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
           XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        
        ' Create the NetDataContractSerializer, specifying the type, 
        ' root, and namespace to use. The root value corresponds
        ' to the DataContract.Name value, and the namespace value
        ' corresponds to the DataContract.Namespace value.
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()
        
        ' Test if the serializer is on the start of the 
        ' object data. If so, read the data and write it 
        ' to the console.
        While reader.Read()
            Select Case reader.NodeType
                Case XmlNodeType.Element
                    
                    If ser.IsStartObject(reader) Then
                        Console.WriteLine("Found the element")
                        Dim p As Person = CType(ser.ReadObject(reader), Person)
                        Console.WriteLine("{0} {1}    id:{2}", p.FirstName, _
                           p.LastName, p.ID)
                    End If
                    Console.WriteLine(reader.Name)
            End Select
        End While
        
        fs.Flush()
        fs.Close()
    
    End Sub     
    '</snippet6>

    '<snippet7>
    Public Shared Sub WriteObjectContentInDocument(ByVal path As String) 
        ' Create the object to serialize.
        Dim p As New Person("Lynn", "Tsoflias", 9876)
        
        ' Create the writer.
        Dim fs As New FileStream(path, FileMode.Create)
        Dim writer As XmlDictionaryWriter = _
           XmlDictionaryWriter.CreateTextWriter(fs)
        
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()
        
        ' Use the writer to start a document.
        writer.WriteStartDocument(True)
        ' Use the writer to write the root element.
        writer.WriteStartElement("Company")
        ' Use the writer to write an element.
        writer.WriteElementString("Name", "Microsoft")
        ' Use the serializer to write the start, content,
        ' and end data.
        ser.WriteStartObject(writer, p)
        ser.WriteObjectContent(writer, p)
        ser.WriteEndObject(writer)
        
        ' Use the writer to write the end element 
        ' and end of the document.
        writer.WriteEndElement()
        writer.WriteEndDocument()
        
        ' Close and release the writer resources.
        writer.Flush()
        fs.Flush()
        fs.Close()
    End Sub 
    
    '</snippet7>
    '<snippet8>
    Public Shared Sub Constructor1() 
        ' Create an instance of the NetDataContractSerializer.
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()
    
    End Sub 
    
    ' Other code not shown.
    '</snippet8>
    '<snippet9>
    Public Shared Sub Constructor2() 
        ' Create an instance of the StreamingContext to hold
        ' context data.
        Dim sc As New StreamingContext()
        ' Create a DatatContractSerializer with the collection.
        Dim ser2 As New System.Runtime.Serialization.NetDataContractSerializer(sc)
    
       ' Other code not shown.
    End Sub 
    '</snippet9>

    '<snippet10>
    Public Shared Sub Constructor3() 
        ' Create an instance of the NetDataContractSerializer
        ' specifying the name and namespace as strings.
        Dim ser As New System.Runtime.Serialization. _
           NetDataContractSerializer("Customer", "http://www.contoso.com")
    
       ' Other code not shown.
    
    End Sub 
    '</snippet10>

    '<snippet11>
    Public Shared Sub Constructor4() 
        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString =d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        ' Create the serializer.
        Dim ser As New System.Runtime.Serialization. _
           NetDataContractSerializer(name_value, ns_value)
   
        ' Other code not shown.
    
    End Sub 
    '</snippet11>

    '<snippet12>
    Public Shared Sub Constructor5() 
        ' Create an instance of the StreamingContext to hold
        ' context data.
        Dim sc As New StreamingContext()
        
        ' Create an instance of a class that implements the 
        ' ISurrogateSelector interface. The implementation code
        ' is not shown here.
        Dim mySurrogateSelector As New MySelector()
        
        Dim ser As New System.Runtime.Serialization. _
        NetDataContractSerializer _
        (sc, _
         65536, _
         True, _
         FormatterAssemblyStyle.Simple, _
         mySurrogateSelector)

        ' Other code not shown.
    End Sub 
    '</snippet12>

    '<snippet13>
    Public Shared Sub Constructor6() 
        ' Create an instance of the StreamingContext to hold
        ' context data.
        Dim sc As New StreamingContext()
        
        ' Create an instance of a class that implements the 
        ' ISurrogateSelector interface. The implementation code
        ' is not shown here.
        Dim mySurrogateSelector As New MySelector()
        
        Dim ser As New System.Runtime.Serialization. _
          NetDataContractSerializer( _
          "Customer", _
          "http://www.contoso.com", _
          sc, _
          65536, _
          True, _
          FormatterAssemblyStyle.Simple, _
          mySurrogateSelector)

        ' Other code not shown.            
    
    End Sub 
    '</snippet13>

    '<snippet14>
    Public Shared Sub Constructor7() 
        ' Create an instance of the StreamingContext to hold
        ' context data.
        Dim sc As New StreamingContext()
        
        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString =d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        ' Create an instance of a class that implements the 
        ' ISurrogateSelector interface. The implementation code
        ' is not shown here.
        Dim mySurrogateSelector As New MySelector()
        
        Dim ser As New System.Runtime.Serialization. _
          NetDataContractSerializer( _
          name_value, _
          ns_value, _
          sc, _
          65536, _
          True, _
          FormatterAssemblyStyle.Simple, _
          mySurrogateSelector)

        ' Other code not shown.    

    End Sub 
        '</snippet14>

        Public Sub CannotSerialize()
            '<snippet15>
            Dim fs As New FileStream("mystuff.xml", FileMode.Create, FileAccess.ReadWrite)
            Dim myElement As New XElement("Parent", New XElement("child1", "form"), _
                New XElement("child2", "base"), _
                New XElement("child3", "formbase") _
                )
            Dim ser As New System.Runtime.Serialization. _
              NetDataContractSerializer()
            ser.WriteObject(fs, myElement)
            '</snippet15>
        End Sub

    End Class


<DataContract()>  _
Public Class Orders
    
    Public Sub New() 
        Me.OrderCollection = New Hashtable()
    
    End Sub 
    <DataMember()>  _
    Friend OrderCollection As Hashtable
End Class 

<DataContract()>  _
Public Class PurchaseOrderV3
    <DataMember()>  _
    Friend PurchaseDate As DateTime
    <DataMember()>  _
    Friend OrderId As Integer
End Class 


Public Class DCSurrogate
    Implements IDataContractSurrogate
    
    Overloads Public Function GetCustomDataToExport(ByVal memberInfo As MemberInfo, ByVal dataContractType As Type) As Object _
       Implements IDataContractSurrogate.GetCustomDataToExport
        Return New Person("Lynne", "Tsofilas", 1)
    
    End Function 
    
    Overloads Public Function GetCustomDataToExport(ByVal clrType As Type, ByVal dataContractType As Type) As Object _
    Implements IDataContractSurrogate.GetCustomDataToExport
        Return New Person("Lynne", "Tsofilas", 1)
    
    End Function 
    
    Public Function GetDataContractType(ByVal type As Type) As Type _
    Implements IDataContractSurrogate.GetDataContractType
        Return GetType(Person)
    
    End Function 
    
    Public Function GetDeserializedObject(ByVal obj As Object, ByVal targetType As Type) As Object _
    Implements IDataContractSurrogate.GetDeserializedObject
        Return New Person("Lynne", "Tsofilas", 1)
    
    End Function 
    
        Public Sub GetKnownCustomDataTypes(ByVal customDataTypes As Collection(Of Type)) _
     Implements IDataContractSurrogate.GetKnownCustomDataTypes
            customDataTypes.Add(GetType(PurchaseOrder))
            customDataTypes.Add(GetType(PurchaseOrderV3))

        End Sub
    
    Public Function GetObjectToSerialize(ByVal obj As Object, ByVal targetType As Type) As Object _
     Implements IDataContractSurrogate.GetObjectToSerialize
        Return New Person("Lynne", "Tsofilas", 1)
    
    End Function 
    
    Public Function GetReferencedTypeOnImport(ByVal typeName As String, ByVal typeNamespace As String, ByVal customData As Object) As Type _
    Implements IDataContractSurrogate.GetReferencedTypeOnImport
        Return GetType(Person)
    
    End Function 
    
    Public Function ProcessImportedType(ByVal typeDeclaration As CodeTypeDeclaration, ByVal compileUnit As CodeCompileUnit) As CodeTypeDeclaration _
    Implements IDataContractSurrogate.ProcessImportedType
        Return New CodeTypeDeclaration()
    
    End Function 
End Class 'DCSurrogate


Friend Class MySelector
    Implements ISurrogateSelector
    
    Public Sub ChainSelector(ByVal selector As ISurrogateSelector) _
     Implements ISurrogateSelector.ChainSelector
    
    End Sub 'ChainSelector
    
    
    Public Function GetNextSelector() As ISurrogateSelector _
      Implements ISurrogateSelector.GetNextSelector
        Return New PersonSurrogateSelector()
    
    End Function 
    
    Public Function GetSurrogate(ByVal type As Type, ByVal context As StreamingContext, ByRef selector As ISurrogateSelector) As ISerializationSurrogate _
      Implements ISurrogateSelector.GetSurrogate
        
            Return New MySerializationSurrogate()
        
     
    End Function 
End Class 

    Friend Class PersonSurrogateSelector
        Implements ISurrogateSelector
        
        Public Sub ChainSelector(ByVal selector As ISurrogateSelector) _
        Implements ISurrogateSelector.ChainSelector
        
        End Sub 
        
        Public Function GetNextSelector() As ISurrogateSelector _
        Implements ISurrogateSelector.GetNextSelector
            Return New PersonSurrogateSelector()
        
        End Function 
        
        Public Function GetSurrogate(ByVal type As Type, ByVal context As StreamingContext, ByRef selector As ISurrogateSelector) As ISerializationSurrogate _
        Implements ISurrogateSelector.GetSurrogate
            selector = New MySelector()
            Return New MySerializationSurrogate()
        
        End Function 
    End Class 
    
    
    Friend Class MySerializationSurrogate
        Implements ISerializationSurrogate
        
        Public Sub GetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, ByVal context As StreamingContext) _
         Implements ISerializationSurrogate.GetObjectData
        
        End Sub 
        
        Public Function SetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, ByVal context As StreamingContext, ByVal selector As ISurrogateSelector) As Object _
         Implements ISerializationSurrogate.SetObjectData
            Return New Object()
        
        End Function 
    End Class 
End Namespace