' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Define one readable property and one not readable.
Public Class Mypropertya
    Private myCaption As String = "A Default caption"

    Public Property Caption() As String
        Get
            Return myCaption
        End Get
        Set(ByVal Value As String)
            If myCaption <> value Then
                myCaption = value
            End If
        End Set
    End Property
End Class

Public Class Mypropertyb
    Private myCaption As String = "B Default caption"

    Public WriteOnly Property Caption() As String
        Set(ByVal Value As String)
            If myCaption <> value Then
                myCaption = value
            End If
        End Set
    End Property
End Class

Class Mypropertyinfo

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.CrLf & "Reflection.PropertyInfo")

        ' Define two properties.
        Dim Mypropertya As New Mypropertya()
        Dim Mypropertyb As New Mypropertyb()

        Console.Write(ControlChars.Cr & "Mypropertya.Caption = " & _
           Mypropertya.Caption)
        ' Mypropertyb.Caption cannot be read because
        ' there is no get accessor.
        ' Get the type and PropertyInfo.
        Dim MyTypea As Type = Type.GetType("Mypropertya")
        Dim Mypropertyinfoa As PropertyInfo = MyTypea.GetProperty("Caption")
        Dim MyTypeb As Type = Type.GetType("Mypropertyb")
        Dim Mypropertyinfob As PropertyInfo = MyTypeb.GetProperty("Caption")

        ' Get and display the CanRead property.
        Console.Write(ControlChars.CrLf & "CanRead a - " & _
           Mypropertyinfoa.CanRead)

        Console.Write(ControlChars.CrLf & "CanRead b - " & _
           Mypropertyinfob.CanRead)

        Return 0
    End Function
End Class
' </Snippet1>
