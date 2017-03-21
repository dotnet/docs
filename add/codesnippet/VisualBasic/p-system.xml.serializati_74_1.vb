Public Class MyClass1
    <XmlArray(IsNullable := True)> _
    Public IsNullableIsTrueArray() As String

    <XmlArray(IsNullable := False)> _
    Public IsNullableIsFalseArray() As String
End Class
