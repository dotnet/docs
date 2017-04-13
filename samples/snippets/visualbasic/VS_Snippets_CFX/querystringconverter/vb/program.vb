Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel.Web

Module Program

    Sub Main()
        ' <Snippet0>
        ' <Snippet1>
        Dim converter As New QueryStringConverter()
        ' </Snippet1>
        ' <Snippet2>
        If (converter.CanConvert(GetType(Int32))) Then
            converter.ConvertStringToValue("123", GetType(Int32))
        End If

        ' </Snippet2>
        ' <Snippet3>
        Dim value As Integer = 321
        Dim strValue As String = converter.ConvertValueToString(value, GetType(Int32))
        Console.WriteLine("the value = {0}, the string representation of the value = {1}", value, strValue)
        ' </Snippet3>
        ' </Snippet0>
    End Sub

End Module
