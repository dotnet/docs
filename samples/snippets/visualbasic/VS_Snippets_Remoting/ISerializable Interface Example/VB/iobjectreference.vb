'<snippet1>
Imports System.Text
Imports System.IO
' Add references to Soap and Binary formatters.
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Runtime.Serialization


<Serializable()> _
Public Class MyItemType
    Implements ISerializable
    ' Empty constructor required to compile.
    Public Sub New()
    End Sub

    ' The value to serialize.
    Private myProperty_value As String

    Public Property MyProperty() As String
        Get
            Return myProperty_value
        End Get
        Set(value As String)
            myProperty_value = value
        End Set
    End Property

    ' Implement this method to serialize data. The method is called 
    ' on serialization.
    Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
        ' Use the AddValue method to specify serialized values.
        info.AddValue("props", myProperty_value, GetType(String))

    End Sub

    ' The special constructor is used to deserialize values.
    Public Sub New(info As SerializationInfo, context As StreamingContext)
        ' Reset the property value using the GetValue method.
        myProperty_value = DirectCast(info.GetValue("props", GetType(String)), String)
    End Sub
End Class

' This is a console application. 
Public Class Test


    Public Shared Sub Main()
        ' This is the name of the file holding the data. You can use any file extension you like.
        Dim fileName As String = "dataStuff.myData"

        ' Use a BinaryFormatter or SoapFormatter.
        Dim formatter As IFormatter = New BinaryFormatter()
        ' Dim formatter As IFormatter = New SoapFormatter()

        Test.SerializeItem(fileName, formatter)
        ' Serialize an instance of the class.
        Test.DeserializeItem(fileName, formatter)
        ' Deserialize the instance.
        Console.WriteLine("Done")
        Console.ReadLine()
    End Sub

    Public Shared Sub SerializeItem(fileName As String, formatter As IFormatter)
        ' Create an instance of the type and serialize it.
        Dim myType As New MyItemType()
        myType.MyProperty = "Hello World"

        Dim fs As New FileStream(fileName, FileMode.Create)
        formatter.Serialize(fs, myType)
        fs.Close()
    End Sub


    Public Shared Sub DeserializeItem(fileName As String, formatter As IFormatter)
        Dim fs As New FileStream(fileName, FileMode.Open)

        Dim myType As MyItemType = DirectCast(formatter.Deserialize(fs), MyItemType)
        Console.WriteLine(myType.MyProperty)
    End Sub
End Class
'</snippet1>

