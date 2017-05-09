Imports System.Security.Permissions
Imports System
Imports System.Xml
Imports System.Runtime.Serialization
Imports System.IO


<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>

'<snippet0>
'<snippet1>
' Implement the IExtensibleDataObject interface 
' to store the extra data for future versions.
<DataContract(Name := "Person", [Namespace] := "http://www.cohowinery.com/employees")>  _
Class Person
    Implements IExtensibleDataObject
    ' To implement the IExtensibleDataObject interface,
    ' you must implement the ExtensionData property. The property
    ' holds data from future versions of the class for backward
    ' compatibility.
    Private extensionDataObject_value As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject _
       Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionDataObject_value
        End Get
        Set
            extensionDataObject_value = value
        End Set
    End Property
    <DataMember()>  _
    Public Name As String
End Class 

' The second version of the class adds a new field. The field's 
' data is stored in the ExtensionDataObject field of
' the first version (Person). You must also set the Name property 
' of the DataContractAttribute to match the first version. 
' If necessary, also set the Namespace property so that the 
' name of the contracts is the same.

<DataContract(Name := "Person", [Namespace] := "http://www.cohowinery.com/employees")>  _
Class PersonVersion2
    Implements IExtensibleDataObject

    ' Best practice: add an Order number to new members.
    <DataMember(Order:=2)>  _
    Public ID As Integer
    
    <DataMember()>  _
    Public Name As String
    
    Private extensionDataObject_value As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject _
       Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionDataObject_value
        End Get
        Set
            extensionDataObject_value = value
        End Set
    End Property
End Class 
'</snippet1>

NotInheritable Public Class Program

    ' Private constructor to prevent creation of this class.
    Private Sub New() 
    
    End Sub 
    
    
    Public Shared Sub Main() 
        Try
            WriteVersion2("V2.xml")
            WriteToVersion1("v2.xml")
            ReadVersion2("v2.xml")
        Catch exc As SerializationException
            Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace)
        Finally
            Console.ReadLine()
        End Try
    
    End Sub 
    
    ' Create an instance of the version 2.0 class. It has  
    ' extra data (ID field) that version 1.0 does 
    ' not understand.
    Shared Sub WriteVersion2(ByVal path As String) 
        Console.WriteLine("Creating a version 2 object")
        Dim p2 As New PersonVersion2()
        p2.Name = "Elizabeth"
        p2.ID = 2006
        
        Console.WriteLine("Object data includes an ID")
        Console.WriteLine(vbTab + " Name: {0}", p2.Name)
        Console.WriteLine(vbTab + " ID: {0} " + vbLf, p2.ID)
        ' Create an instance of the DataContractSerializer.
        Dim ser As New DataContractSerializer(GetType(PersonVersion2))
        
        Console.WriteLine("Serializing the v2 object to a file. " + vbLf + vbLf)
        Dim fs As New FileStream(path, FileMode.Create)
        ser.WriteObject(fs, p2)
        fs.Close()
    End Sub 
    
    ' Deserialize version 2 data to a version 1 object.
    Shared Sub WriteToVersion1(ByVal path As String) 
        ' Create the serializer using the version 1 type.
        Dim ser As New DataContractSerializer(GetType(Person))
        
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
            XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        Console.WriteLine("Deserializing v2 data to v1 object. " + vbLf + vbLf)
        
        Dim p1 As Person = CType(ser.ReadObject(reader, False), Person)
        
        Console.WriteLine("V1 data has only a Name field.")
        Console.WriteLine("But the v2 data is stored in the ")
        Console.WriteLine("ExtensionData property. " + vbLf + vbLf)
        Console.WriteLine(vbTab + " Name: {0} " + vbLf, p1.Name)
        
        reader.Close()
        fs.Close()
        
        ' Change data in the object.
        p1.Name = "John"
        Console.WriteLine("Changed the Name value to 'John' ")
        Console.Write("and reserializing the object to version 2 " + vbLf + vbLf)
        ' Reserialize the object.
        fs = New FileStream(path, FileMode.Create)
        ser.WriteObject(fs, p1)
        fs.Close()
    
    End Sub 
    
    ' Deserialize a version 2.0 object. 
    Public Shared Sub ReadVersion2(ByVal path As String) 
        Dim fs As New FileStream(path, FileMode.Open)
        Dim ser As New DataContractSerializer(GetType(PersonVersion2))
        
        Console.WriteLine("Deserializing new data to version 2 " + vbLf + vbLf)
        Dim p2 As PersonVersion2 = CType(ser.ReadObject(fs), PersonVersion2)
        fs.Close()
        
        Console.WriteLine("The data includes the old ID field value. " + vbLf)
        Console.WriteLine(vbTab + " (New) Name: {0}", p2.Name)
        Console.WriteLine(vbTab + " ID: {0} " + vbLf, p2.ID)
    
    End Sub 
End Class 
'</snippet0>
