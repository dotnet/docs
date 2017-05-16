' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Define one writable property and one not writable.
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

    Public ReadOnly Property Caption() As String
        Get
            Return myCaption
        End Get
    End Property
End Class

Class Mypropertyinfo

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.CrLf & "Reflection.PropertyInfo")

        ' Define two properties.
        Dim Mypropertya As New Mypropertya()
        Dim Mypropertyb As New Mypropertyb()

        ' Read and display the property.
        Console.Write(ControlChars.CrLf & "Mypropertya.Caption = " & _
           Mypropertya.Caption)
        Console.Write(ControlChars.CrLf & "Mypropertyb.Caption = " & _
           Mypropertyb.Caption)

        ' Write to the property.
        Mypropertya.Caption = "A- No Change"
        ' Mypropertyb.Caption cannot be written to because
        ' there is no set accessor.
        ' Read and display the property.
        Console.Write(ControlChars.CrLf & "Mypropertya.Caption = " & _
           Mypropertya.Caption)
        Console.Write(ControlChars.CrLf & "Mypropertyb.Caption = " & _
           Mypropertyb.Caption)

        ' Get the type and PropertyInfo.
        Dim MyTypea As Type = Type.GetType("Mypropertya")
        Dim Mypropertyinfoa As PropertyInfo = MyTypea.GetProperty("Caption")
        Dim MyTypeb As Type = Type.GetType("Mypropertyb")
        Dim Mypropertyinfob As PropertyInfo = MyTypeb.GetProperty("Caption")

        ' Get and display the CanWrite property.
        Console.Write(ControlChars.CrLf & "CanWrite a - " & _
           Mypropertyinfoa.CanWrite)

        Console.Write(ControlChars.CrLf & "CanWrite b - " & _
           Mypropertyinfob.CanWrite)

        Return 0
    End Function
End Class
' </Snippet1>
