' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Make three properties, one read-write, one default,
' and one read-only. 
Public Class Aproperty
    ' Define a read-write property.
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

Public Class Bproperty
    ' Define a default property.
    Private myCaption As String = "B Default caption"

    Default Public ReadOnly Property Item(ByVal index As Integer) As String
        Get
            Return "1"
        End Get
    End Property

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

Public Class Cproperty
    ' Define a read-only property.
    Private myCaption As String = "C Default caption"

    Public ReadOnly Property Caption() As String
        Get
            Return myCaption
        End Get
        'No setting is allowed because this property is read-only.
    End Property
End Class


Class propertyattributesenum

    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.CrLf & "Reflection.PropertyAttributes")

        ' Determine whether a property exists, and change its value.
        Dim Mypropertya As New Aproperty()
        Dim Mypropertyb As New Bproperty()
        Dim Mypropertyc As New Cproperty()

        Console.Write(ControlChars.CrLf & "1. Mypropertya.Caption = " & _
           Mypropertya.Caption)

        Console.Write(ControlChars.CrLf & "1. Mypropertyb.Caption = " & _
           Mypropertyb.Caption)

        Console.Write(ControlChars.CrLf & "1. Mypropertyc.Caption = " & _
           Mypropertyc.Caption)

        ' Only Mypropertya can be changed because Mypropertyb is read-only.
        Mypropertya.Caption = "A- This is changed."
        Mypropertyb.Caption = "B- This is changed."
        ' Note that Mypropertyc is not changed, because it is read-only.
        Console.Write(ControlChars.CrLf & ControlChars.CrLf & _
           "2. Mypropertya.Caption = " & Mypropertya.Caption)

        Console.Write(ControlChars.CrLf & "2. Mypropertyb.Caption = " & _
           Mypropertyb.Caption)

        Console.Write(ControlChars.CrLf + "2. Mypropertyc.Caption = " & _
           Mypropertyc.Caption)

        ' Get the PropertyAttributes Enumeration of the property.
        ' Get the type.
        Dim MyTypea As Type = Type.GetType("Aproperty")
        Dim MyTypeb As Type = Type.GetType("Bproperty")
        Dim MyTypec As Type = Type.GetType("Cproperty")

        ' Get the property attributes.
        Dim Mypropertyinfoa As PropertyInfo = MyTypea.GetProperty("Caption")
        Dim Myattributesa As PropertyAttributes = Mypropertyinfoa.Attributes
        Dim Mypropertyinfob As PropertyInfo = MyTypeb.GetProperty("Item")
        Dim Myattributesb As PropertyAttributes = Mypropertyinfob.Attributes
        Dim Mypropertyinfoc As PropertyInfo = MyTypec.GetProperty("Caption")
        Dim Myattributesc As PropertyAttributes = Mypropertyinfoc.Attributes

        ' Display the property attributes value.
        Console.Write(ControlChars.CrLf & ControlChars.CrLf & "a- " & _
           Myattributesa.ToString())

        Console.Write(ControlChars.CrLf & "b- " & Myattributesb.ToString())

        Console.Write(ControlChars.CrLf & "c- " & Myattributesc.ToString())
        Return 0
    End Function'    End Function
End Class

' This example displays the following output to the console
'
' Reflection.PropertyAttributes
'
' 1. Mypropertya.Caption = A Default caption
' 1. Mypropertyb.Caption = B Default caption
' 1. Mypropertyc.Caption = C Default caption
'
' 2. Mypropertya.Caption = A- This is changed.
' 2. Mypropertyb.Caption = B- This is changed.
' 2. Mypropertyc.Caption = C Default caption
'
' a- None
' b- None
' c- None
' </Snippet1>
