Imports System
Imports System.CodeDom
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.Collections.Generic
Imports System.Reflection
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Security.Permissions


<assembly: CLSCompliant(True)>
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>
'<snippet0>
' You must apply a DataContractAttribute or SerializableAttribute
' to a class to have it serialized by the DataContractSerializer.
<DataContract(Name := "Customer", [Namespace] := "http://www.contoso.com")>  _
Class Person
    Implements IExtensibleDataObject
    <DataMember()>  _
    Public FirstName As String
    <DataMember()>  _
    Public LastName As String
    <DataMember()>  _
    Public ID As Integer
    
    Public Sub New(ByVal newfName As String, ByVal newLName As String, ByVal newID As Integer) 
        FirstName = newfName
        LastName = newLName
        ID = newID
    End Sub 
    
    Private extensionData_Value As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject Implements _
       IExtensibleDataObject.ExtensionData
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
            WriteObject("DataContractSerializerExample.xml")
            ReadObject("DataContractSerializerExample.xml")
        
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
        Dim writer As New FileStream(fileName, FileMode.Create)
        Dim ser As New DataContractSerializer(GetType(Person))
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
        Dim ser As New DataContractSerializer(GetType(Person))
        
        ' Deserialize the data and read it from the instance.
        Dim deserializedPerson As Person = CType(ser.ReadObject(reader, True), Person)
        reader.Close()
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
     
    ' Use this method to look up the country and set 
    ' the Currency field after deserialization.
    <OnDeserialized()>  _
    Private Sub GetLocalRate(ByVal sc As StreamingContext) 
        If Me.Country = "Japan" Then
            Me.Currency = "Yen"
        End If
    End Sub 

    ' Implement IExensibleDataObject interface to 
    ' retain future version information.
    Private extensionData_Value As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject Implements _
       IExtensibleDataObject.ExtensionData
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
            purchaseDate_value = value
        End Set
    End Property 
    Private extensionData_value As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject Implements _
       IExtensibleDataObject.ExtensionData
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
    
    Public Property ExtensionData() As ExtensionDataObject Implements _
        IExtensibleDataObject.ExtensionData
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
    
    End Sub 
     
    Public Shared Sub RunTest() 
        WriteNewVersion("myTestFile.xml")
        WriteObjectAndReadObject("myTestFile.xml")
        ReadToNewVersion("myTestFile.xml")
        Console.ReadLine()
    
    End Sub 
    
    Shared Sub WriteNewVersion(ByVal path As String) 
        Console.WriteLine("Serializing new version of a contract.")
        Dim fs As New FileStream(path, FileMode.Create)
        Dim ser As New DataContractSerializer(GetType(PurchaseOrderV2))
        Dim PO_V2 As New PurchaseOrderV2()
        PO_V2.PurchaseDate = DateTime.Now
        PO_V2.PurchaseOrderId = 1234
        ser.WriteObject(fs, PO_V2)
        fs.Close()
        Console.WriteLine("Order Date: {0}", PO_V2.PurchaseDate.ToLongDateString())
        Console.WriteLine("Order ID:{0}", PO_V2.PurchaseOrderId)
    
    End Sub 
    
    Shared Sub WriteObjectAndReadObject(ByVal path As String) 
        Console.WriteLine("Deserializing new version to old version")
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
           XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        
        ' Create the serializer.
        Dim ser As New DataContractSerializer(GetType(PurchaseOrder))
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
    
    Shared Sub ReadToNewVersion(ByVal path As String) 
        Console.WriteLine("Deserializing to new version, extension data intact")
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
            XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        Dim ser As New DataContractSerializer(GetType(PurchaseOrderV2))
        Dim newOrder As PurchaseOrderV2 = CType(ser.ReadObject(reader, False), PurchaseOrderV2)
        Console.WriteLine("Original OrderID: {0}", newOrder.PurchaseOrderId)
        Console.WriteLine("New Order Date: {0}", newOrder.PurchaseDate.ToLongDateString())
        fs.Close()
    
    End Sub 
End Class 
'</snippet4>

'<snippet5>

NotInheritable Public Class ShowWriteStartObject
    
    Private Sub New() 
    
    End Sub 
     
    Public Shared Sub WriteObjectData(ByVal path As String) 
        ' Create the object to serialize.
        Dim p As New Person("Lynn", "Tsoflias", 9876)
        
        ' Create the writer.
        Dim fs As New FileStream(path, FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        
        Dim ser As New DataContractSerializer(GetType(Person))
        
        ' Use the writer to start a document.
        writer.WriteStartDocument(True)
        
        ' Use the serializer to write the start of the 
        ' object data. Use it again to write the object
        ' data. 
        ser.WriteStartObject(writer, p)
        ser.WriteObjectContent(writer, p)
        
        ' Use the writer to add an XML element to the document.
        writer.WriteElementString("Citizen", "true")
        
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
        
        ' Create the DataContractSerializer specifying the type, 
        ' root and namespace to use. The root value corresponds
        ' to the DataContract.Name value, and the namespace value
        ' corresponds to the DataContract.Namespace value.
        Dim ser As New DataContractSerializer(GetType(Person), _
            "Customer", "http://www.contoso.com")
        
        ' Test if the serializer is on the start of the 
        ' object data. If so, read the data and write it 
        ' to the console.
        While reader.Read()
            If ser.IsStartObject(reader) Then
                Console.WriteLine("Found the element")
                Dim p As Person = CType(ser.ReadObject(reader), Person)
                Console.WriteLine("{0} {1}    id:{2}", p.FirstName, p.LastName, p.ID)
            End If
                    
            Console.WriteLine(reader.Name)
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
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        
        Dim ser As New DataContractSerializer(GetType(Person))
        
        ' Use the writer to start a document.
        writer.WriteStartDocument(True)
        ' Use the writer to write the root element.
        writer.WriteStartElement("Company")
        ' Use the writer to write an element.
        writer.WriteElementString("Name", "Microsoft")

        ' Use the serializer to write the start,
        ' content, and end data.
        ser.WriteStartObject(writer, p)
        ser.WriteObjectContent(writer, p)
        ser.WriteEndObject(writer)
        
        ' Use the writer to write the end element and
        ' the end of the document.
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
        ' Create an instance of the DataContractSerializer.
        Dim ser As New DataContractSerializer(GetType(Person))
   
        ' Other code not shown.    
    End Sub 
    '</snippet8>
    
    '<snippet9>
    Public Shared Sub Constructor2() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))
        
        ' Create a DatatContractSerializer with the collection.
        Dim ser2 As New DataContractSerializer(GetType(Orders), knownTypeList)

        ' Other code not shown.
   End Sub 
    '</snippet9>

    '<snippet10>
    Public Shared Sub Constructor3() 
        ' Create an instance of the DataContractSerializer
        ' specifying the type, and name and 
        ' namespace as strings.
        Dim ser As New DataContractSerializer(GetType(Person), _
        "Customer", _
        "http://www.contoso.com")

        ' Other code not shown.
    End Sub 
    '</snippet10>

    '<snippet11>
    Public Shared Sub Constructor4() 
        ' Create an instance of the DataContractSerializer
        ' specifying the type, and name and 
        ' namespace as XmlDictionaryString objects.
        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString = d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        ' Create the serializer.
        Dim ser As New DataContractSerializer(GetType(Person), _
        name_value, _
        ns_value)

        ' Other code not shown.
    End Sub 
    '</snippet11>

    '<snippet12>
    Public Shared Sub Constructor5() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))
        
        Dim ser As New DataContractSerializer(GetType(Person), _
        "Customer", _
        "http://www.contoso.com", _
        knownTypeList)

        ' Other code not shown.

    End Sub 
    '</snippet12>

    '<snippet13>
    Public Shared Sub Constructor6() 
        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))

        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString = d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        Dim ser As New DataContractSerializer(GetType(Person), _
        name_value, _
        ns_value, _
        knownTypeList)
    
        ' Other code not shown.
     End Sub 
    '</snippet13>
 
   '<snippet14>
    Public Shared Sub Constructor7() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))

        ' Create an instance of a class that 
        ' implements the IDataContractSurrogate interface.
        ' The implementation code is not shown here.
        Dim mySurrogate As New DCSurrogate()

        Dim ser As New DataContractSerializer(GetType(Person), _
        knownTypeList, _
        64 * 1064, _
        True, _
        True, _
         mySurrogate)
    
        ' Other code not shown.
    End Sub 
    '</snippet14>

    '<snippet15>
    Public Shared Sub Constructor8() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))

        ' Create an instance of a class that 
        ' implements the IDataContractSurrogate interface.
        ' The implementation code is not shown here.
        Dim mySurrogate As New DCSurrogate()

        Dim ser As New DataContractSerializer(GetType(Person), _
        "Customer", _
        "http://www.contoso.com", _
        knownTypeList, _
        64 * 1064, _
        True, _
        True, _
        mySurrogate)
    
        ' Other code not shown.
    End Sub 
    '</snippet15>

    '<snippet16>
    Public Shared Sub Constructor9() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))
        
        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString = d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        ' Create an instance of a class that 
        ' implements the IDataContractSurrogate interface.
        ' The implementation code is not shown here.
        Dim mySurrogate As New DCSurrogate()
        
        Dim ser As New DataContractSerializer(GetType(Person), _
        name_value, _
        ns_value, _
        knownTypeList, _
        64 * 1064, _
        True, _
        True, _
        mySurrogate)

        ' Other code not shown.    

    End Sub 
    '</snippet16>
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
End Class 'PurchaseOrderV3


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
End Class 