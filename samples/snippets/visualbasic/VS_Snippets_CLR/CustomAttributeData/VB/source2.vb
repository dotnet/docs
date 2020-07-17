' <snippet2>
Public Class ExampleAttribute
    Inherits Attribute

    Private stringVal As String

    Public Sub New()
        stringVal = "This is the default string."
    End Sub

    Public Property StringValue() As String
        Get
            Return stringVal
        End Get
        Set(Value As String)
            stringVal = Value
        End Set
    End Property
End Class

<Example(StringValue:="This is a string.")> _
Class Class1
    Public Shared Sub Main()
        Dim info As System.Reflection.MemberInfo = GetType(Class1)
        For Each attrib As Object In info.GetCustomAttributes(true)
            Console.WriteLine(attrib)
        Next attrib
    End Sub
End Class
' </snippet2>
