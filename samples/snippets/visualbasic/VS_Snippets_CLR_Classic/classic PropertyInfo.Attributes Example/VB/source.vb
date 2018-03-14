' <Snippet1>
Imports System.Reflection

Public Class Myproperty
    Private myCaption As String = "Default caption"

    Public Property Caption() As String
        Get
            Return myCaption
        End Get
        Set
            If myCaption <> value Then
                myCaption = value
            End If
        End Set
    End Property
End Class

Class Mypropertyinfo
    Public Shared Sub Main()
        Console.WriteLine(ControlChars.CrLf & "Reflection.PropertyInfo")

        ' Define a property.
        Dim Myproperty As New Myproperty()
        Console.Write(ControlChars.CrLf & "Myproperty.Caption = " & _
           Myproperty.Caption)

        ' Get the type and PropertyInfo.
        Dim MyType As Type = Type.GetType("Myproperty")
        Dim Mypropertyinfo As PropertyInfo = MyType.GetProperty("Caption")

        ' Get and display the attributes property.
        Dim Myattributes As PropertyAttributes = Mypropertyinfo.Attributes

        Console.Write(ControlChars.CrLf & "PropertyAttributes - " & _
           Myattributes.ToString())
    End Sub
End Class
' The example displays the following output:
'       Reflection.PropertyInfo
'
'       Myproperty.Caption = Default caption
'       PropertyAttributes - None
' </Snippet1>
