Imports System.Collections.ObjectModel
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.Collections.Generic

'<snippet0>
Class Program

    Public Shared Sub Main(ByVal args() As String)

        SerializeWithSurrogate("surrogateEmployee.xml")
        DeserializeSurrogate("surrogateEmployee.xml")
        ' Create an XmlSchemaSet to hold schemas from the
        ' schema exporter. 
        'Dim schemas As New XmlSchemaSet
        'ExportSchemas("surrogateEmployee.xml", schemas)
        ' Pass the schemas to the importer.
        'ImportSchemas(schemas)

    End Sub


    Shared Function CreateSurrogateSerializer() As DataContractSerializer
        ' Create an instance of the DataContractSerializer. The 
        ' constructor demands a knownTypes and surrogate. 
        ' Create a Generic List for the knownTypes. 
        Dim knownTypes As List(Of Type) = New List(Of Type)()
        Dim surrogate As New LegacyPersonTypeSurrogate()
        Dim surrogateSerializer As New  _
        DataContractSerializer(GetType(Employee), _
           knownTypes, Integer.MaxValue, False, True, surrogate)
        Return surrogateSerializer
    End Function

    Shared Sub SerializeWithSurrogate(ByVal filename As String)
        ' Create and populate an Employee instance.
        Dim emp As New Employee()
        emp.date_hired = New DateTime(1999, 10, 14)
        emp.salary = 33000

        ' Note that the Person class is a legacy XmlSerializable class
        ' without a DataContract.
        emp.person = New Person()
        emp.person.first_name = "Mike"
        emp.person.last_name = "Ray"
        emp.person.age = 44

        ' Create a new writer. Then serialize with the 
        ' surrogate serializer.
        Dim fs As New FileStream(filename, FileMode.Create)
        Dim surrogateSerializer As DataContractSerializer = CreateSurrogateSerializer()
        Try
            surrogateSerializer.WriteObject(fs, emp)
            Console.WriteLine("Serialization succeeded. ")
            fs.Close()
        Catch exc As SerializationException

            Console.WriteLine(exc.Message)
        End Try
    End Sub

    Shared Sub DeserializeSurrogate(ByVal filename As String)

        ' Create a new reader object.
        Dim fs2 As New FileStream(filename, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
            XmlDictionaryReader.CreateTextReader(fs2, New XmlDictionaryReaderQuotas())

        Console.WriteLine("Trying to deserialize with surrogate.")
        Try
            Dim surrogateSerializer As DataContractSerializer = CreateSurrogateSerializer()
            Dim newemp As Employee = CType _
                (surrogateSerializer.ReadObject(reader, False), Employee)

            reader.Close()
            fs2.Close()

            Console.WriteLine("Deserialization succeeded. " + vbLf + vbLf)
            Console.WriteLine("Deserialized Person data: " + vbLf + vbTab + _
                " {0} {1}", newemp.person.first_name, newemp.person.last_name)
            Console.WriteLine(vbTab + " Age: {0} " + vbLf, newemp.person.age)
            Console.WriteLine(vbTab & "Date Hired: {0}", newemp.date_hired.ToShortDateString())
            Console.WriteLine(vbTab & "Salary: {0}", newemp.salary)
            Console.WriteLine("Press Enter to end or continue")
            Console.ReadLine()
        Catch serEx As SerializationException
            Console.WriteLine(serEx.Message)
            Console.WriteLine(serEx.StackTrace)
        End Try
    End Sub

    Shared Sub ExportSchemas(ByVal filename As String, ByRef Schemas As XmlSchemaSet)
        Console.WriteLine("Now doing schema export.")
        ' The following code demonstrates schema export with a surrogate.
        ' The surrogate indicates how to export the non-DataContract Person type.
        ' Without the surrogate, schema export would fail.
        Dim xsdexp As New XsdDataContractExporter()
        xsdexp.Options = New ExportOptions()
        xsdexp.Options.DataContractSurrogate = New LegacyPersonTypeSurrogate()
        xsdexp.Export(GetType(Employee))

        ' Write out the exported schema to a file.
        Dim fs3 As New FileStream("sample.xsd", FileMode.Create)
        Try
            Dim sch As XmlSchema
            For Each sch In xsdexp.Schemas.Schemas()
                sch.Write(fs3)
            Next sch
            Schemas = xsdexp.Schemas
        Catch serEx As SerializationException
            Console.WriteLine("Message: {0}", serEx.Message)
            Console.WriteLine("Inner Text: {0}", serEx.InnerException)

        Finally
            fs3.Dispose()
        End Try
    End Sub

    Shared Sub ImportSchemas(ByVal schemas As XmlSchemaSet)
        Console.WriteLine("Now doing schema import.")
        ' The following code demonstrates schema import with 
        ' a surrogate. The surrogate is used to indicate that 
        ' the Person class already exists and that there is no 
        ' need to generate a new class when importing the
        ' PersonSurrogated data contract. If the surrogate 
        ' was not used, schema import would generate a 
        ' PersonSurrogated class, and the person field 
        ' of Employee would be imported as 
        ' PersonSurrogated and not Person.
        Dim xsdimp As New XsdDataContractImporter()
        xsdimp.Options = New ImportOptions()
        xsdimp.Options.DataContractSurrogate = New LegacyPersonTypeSurrogate()
        xsdimp.Import(schemas)

        ' Write out the imported schema to a C-Sharp file.
        ' The code contains data contract types.
        Dim fs4 As FileStream = New FileStream("sample.cs", FileMode.Create)
        Try
            Dim tw As New StreamWriter(fs4)
            Dim cdp As New Microsoft.CSharp.CSharpCodeProvider()
            cdp.GenerateCodeFromCompileUnit(xsdimp.CodeCompileUnit, tw, Nothing)
            tw.Flush()
        Finally
            fs4.Dispose()
        End Try

        Console.WriteLine(vbLf + " To see the results of schema export and import,")
        Console.WriteLine(" see SAMPLE.XSD and SAMPLE.CS." + vbLf)

        Console.WriteLine(" Press ENTER to terminate the sample." + vbLf)
        Console.ReadLine()
    End Sub


End Class


' This is the Employee (outer) type used in the sample.

<DataContract()> Class Employee
    <DataMember()> _
    Public date_hired As DateTime

    <DataMember()> _
    Public salary As [Decimal]

    <DataMember()> _
    Public person As Person
End Class


' This is the Person (inner) type used in the sample.
' Note that it is a legacy XmlSerializable type and not a DataContract type.

Public Class Person
    <XmlElement("FirstName")> _
    Public first_name As String

    <XmlElement("LastName")> _
    Public last_name As String

    <XmlAttribute("Age")> _
    Public age As Integer


    Public Sub New()

    End Sub
End Class

' This is the surrogated version of the Person type
' that will be used for its serialization/deserialization.

<DataContract()> Class PersonSurrogated

    ' xmlData will store the XML returned for a Person instance 
    ' by the XmlSerializer.
    <DataMember()> _
    Public xmlData As String

End Class

' This is the surrogate that substitutes PersonSurrogated for Person.
Class LegacyPersonTypeSurrogate
    Implements IDataContractSurrogate

    '<snippet1>
    Public Function GetDataContractType(ByVal type As Type) As Type _
       Implements IDataContractSurrogate.GetDataContractType
        Console.WriteLine("GetDataContractType invoked")
        Console.WriteLine(vbTab & "type name: {0}", type.Name)
        ' "Person" will be serialized as "PersonSurrogated"
        ' This method is called during serialization,
        ' deserialization, and schema export.
        If GetType(Person).IsAssignableFrom(type) Then
            Console.WriteLine(vbTab & "returning PersonSurrogated")
            Return GetType(PersonSurrogated)
        End If
        Return type

    End Function
    '</snippet1>

    '<snippet2>
    Public Function GetObjectToSerialize(ByVal obj As Object, _
        ByVal targetType As Type) As Object _
        Implements IDataContractSurrogate.GetObjectToSerialize
        Console.WriteLine("GetObjectToSerialize Invoked")
        Console.WriteLine(vbTab & "type name: {0}", obj.ToString)
        Console.WriteLine(vbTab & "target type: {0}", targetType.Name)
        ' This method is called on serialization.
        ' If Person is not being serialized...
        If TypeOf obj Is Person Then
            Console.WriteLine(vbTab & "returning PersonSurrogated")
            ' ... use the XmlSerializer to perform the actual serialization.
            Dim ps As New PersonSurrogated()
            Dim xs As New XmlSerializer(GetType(Person))
            Dim sw As New StringWriter()
            xs.Serialize(sw, CType(obj, Person))
            ps.xmlData = sw.ToString()
            Return ps
        End If
        Return obj

    End Function
    '</snippet2>

    '<snippet3>
    Public Function GetDeserializedObject(ByVal obj As Object, _
        ByVal targetType As Type) As Object Implements _
        IDataContractSurrogate.GetDeserializedObject
        Console.WriteLine("GetDeserializedObject invoked")
        ' This method is called on deserialization.
        ' If PersonSurrogated is being deserialized...
        If TypeOf obj Is PersonSurrogated Then
            Console.WriteLine(vbTab & "returning PersonSurrogated")
            '... use the XmlSerializer to do the actual deserialization.
            Dim ps As PersonSurrogated = CType(obj, PersonSurrogated)
            Dim xs As New XmlSerializer(GetType(Person))
            Return CType(xs.Deserialize(New StringReader(ps.xmlData)), Person)
        End If
        Return obj

    End Function
    '</snippet3>

    '<snippet4>
    Public Function GetReferencedTypeOnImport(ByVal typeName As String, _
        ByVal typeNamespace As String, ByVal customData As Object) As Type _
        Implements IDataContractSurrogate.GetReferencedTypeOnImport
        Console.WriteLine("GetReferencedTypeOnImport invoked")
        ' This method is called on schema import.
        ' If a PersonSurrogated data contract is 
        ' in the specified namespace, do not create a new type for it 
        ' because there is already an existing type, "Person".
        Console.WriteLine(vbTab & "Type Name: {0}", typeName)

        'If typeNamespace.Equals("http://schemas.datacontract.org/2004/07/DCSurrogateSample") Then
        If typeName.Equals("PersonSurrogated") Then
            Console.WriteLine("Returning Person")
            Return GetType(Person)
        End If
        'End If
        Return Nothing

    End Function
    '</snippet4>

    Public Function ProcessImportedType(ByVal typeDeclaration _
        As System.CodeDom.CodeTypeDeclaration, _
        ByVal compileUnit As System.CodeDom.CodeCompileUnit) _
        As System.CodeDom.CodeTypeDeclaration _
        Implements IDataContractSurrogate.ProcessImportedType
        'Console.WriteLine("ProcessImportedType invoked")
        ' Not used in this sample.
        ' You could use this method to construct an entirely new CLR 
        ' type when a certain type is imported, or modify a 
        ' generated type in some way.
        Return typeDeclaration
    End Function


    Public Overloads Function GetCustomDataToExport _
        (ByVal clrType As Type, ByVal dataContractType As Type) As Object _
        Implements IDataContractSurrogate.GetCustomDataToExport
        ' Console.WriteLine("GetCustomDataToExport invoked")
        ' Not used in this sample
        Return Nothing
    End Function


    Public Overloads Function GetCustomDataToExport _
       (ByVal memberInfo As System.Reflection.MemberInfo, _
       ByVal dataContractType As Type) As Object _
        Implements IDataContractSurrogate.GetCustomDataToExport
        ' Console.WriteLine("GetCustomDataToExport invoked")
        ' Not used in this sample
        Return Nothing

    End Function


    Public Sub GetKnownCustomDataTypes(ByVal customDataTypes As Collection(Of Type)) _
 Implements IDataContractSurrogate.GetKnownCustomDataTypes
        Console.WriteLine("GetKnownCustomDataTypes invoked")
        ' Not used in this sample

    End Sub
End Class
'</snippet0>
