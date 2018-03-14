' <snippet1>
Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Test
    Public Shared Sub Main()
        ' Create a new TestSimpleObject object.
        Dim obj As New TestSimpleObject()

        Console.WriteLine(vbLf + " Before serialization the object contains: ")
        obj.Print()

        ' Open a file and serialize the object into binary format.
        Dim stream As Stream = File.Open("DataFile.dat", FileMode.Create)
        Dim formatter As New BinaryFormatter()

        Try
            formatter.Serialize(stream, obj)

            ' Print the object again to see the effect of the 
            'OnSerializedAttribute.
            Console.WriteLine(vbLf + " After serialization the object contains: ")
            obj.Print()

            ' Set the original variable to null.
            obj = Nothing
            stream.Close()

            ' Open the file "DataFile.dat" and deserialize the object from it.
            stream = File.Open("DataFile.dat", FileMode.Open)

            ' Deserialize the object from the data file.
            obj = CType(formatter.Deserialize(stream), TestSimpleObject)

            Console.WriteLine(vbLf + " After deserialization the object contains: ")
            obj.Print()
            Console.ReadLine()
        Catch se As SerializationException
            Console.WriteLine("Failed to serialize. Reason: " + se.Message)
            Throw
        Catch exc As Exception
            Console.WriteLine("An exception occurred. Reason: " + exc.Message)
            Throw
        Finally
            stream.Close()
            obj = Nothing
            formatter = Nothing
        End Try
    End Sub
End Class


' This is the object that will be serialized and deserialized.
<Serializable()> _
Public Class TestSimpleObject
    ' This member is serialized and deserialized with no change.
    Public member1 As Integer

    ' The value of this field is set and reset during and 
    ' after serialization.
    Private member2 As String

    ' This field is not serialized. The OnDeserializedAttribute 
    ' is used to set the member value after serialization.
    <NonSerialized()> _
    Public member3 As String

    ' This field is set to null, but populated after deserialization.
    Private member4 As String

    ' Constructor for the class.
    Public Sub New()
        member1 = 11
        member2 = "Hello World!"
        member3 = "This is a nonserialized value"
        member4 = Nothing
    End Sub

    Public Sub Print()
        Console.WriteLine("member1 = '{0}'", member1)
        Console.WriteLine("member2 = '{0}'", member2)
        Console.WriteLine("member3 = '{0}'", member3)
        Console.WriteLine("member4 = '{0}'", member4)
    End Sub

    <OnSerializing()> _
    Friend Sub OnSerializingMethod(ByVal context As StreamingContext)
        member2 = "This value went into the data file during serialization."
    End Sub

    <OnSerialized()> _
    Friend Sub OnSerializedMethod(ByVal context As StreamingContext)
        member2 = "This value was reset after serialization."
    End Sub

    <OnDeserializing()> _
    Friend Sub OnDeserializingMethod(ByVal context As StreamingContext)
        member3 = "This value was set during deserialization"
    End Sub

    <OnDeserialized()> _
    Friend Sub OnDeserializedMethod(ByVal context As StreamingContext)
        member4 = "This value was set after deserialization."
    End Sub
End Class

' Output:
'  Before serialization the object contains: 
' member1 = '11'
' member2 = 'Hello World!'
' member3 = 'This is a nonserialized value'
' member4 = ''
'
'  After serialization the object contains: 
' member1 = '11'
' member2 = 'This value was reset after serialization.'
' member3 = 'This is a nonserialized value'
' member4 = ''
'
'  After deserialization the object contains: 
' member1 = '11'
' member2 = 'This value went into the data file during serialization.'
' member3 = 'This value was set during deserialization'
' member4 = 'This value was set after deserialization.'
' </snippet1>


Public Class ExampleCode
    Private Sub New()
        ' Empty constructor to get around security checks.
    End Sub
    ' <snippet2>
    <OnSerializing()> _
    Private Sub SetValuesOnSerializing(ByVal context As StreamingContext)
        ' Code not shown.
    End Sub
    ' </snippet2>

    ' <snippet3>
    <OnSerialized()> _
    Private Sub SetValuesOnSerialized(ByVal context As StreamingContext)
        ' Code not shown.
    End Sub
    ' </snippet3>

    ' <snippet4>
    <OnDeserializing()> _
    Private Sub SetValuesOnDeserializing(ByVal context As StreamingContext)
        ' Code not shown.
    End Sub
    ' </snippet4>

    '<snippet5>
    <OnDeserialized()> _
    Private Sub SetValuesOnDeserialized(ByVal context As StreamingContext)
        ' Code not shown.
    End Sub
    ' </snippet5>
End Class
