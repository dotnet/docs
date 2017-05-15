' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Define a class with a property.
Public Class TestClass
    Private myCaption As String = "A Default caption"

    Public Property Caption() As String
        Get
            Return myCaption
        End Get
        Set
            If myCaption <> value Then myCaption = value
        End Set
    End Property
End Class

Public Class TestPropertyInfo
    Public Shared Sub Main()
        Dim t As New TestClass()

        ' Get the type and PropertyInfo.
        Dim myType As Type = t.GetType()
        Dim pinfo As PropertyInfo = myType.GetProperty("Caption")

        ' Display the property value, using the GetValue method.
        Console.WriteLine(vbCrLf & "GetValue: " & pinfo.GetValue(t, Nothing))

        ' Use the SetValue method to change the caption.
        pinfo.SetValue(t, "This caption has been changed.", Nothing)

        ' Display the caption again.
        Console.WriteLine("GetValue: " & pinfo.GetValue(t, Nothing))

        Console.WriteLine(vbCrLf & "Press the Enter key to continue.")
        Console.ReadLine()
    End Sub
End Class

' This example produces the following output:
' 
'GetValue: A Default caption
'GetValue: This caption has been changed
'
'Press the Enter key to continue.
' </Snippet1>
