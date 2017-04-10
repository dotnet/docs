' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Collections
Imports Microsoft.VisualBasic

' A test class that has some properties.
Public Class MyProperty

    ' Define a simple string property.
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

    ' A very limited indexed default property that gets or
    ' sets one of four string values.
    Private strings() As String = {"abc", "def", "ghi", "jkl"}
    Public Default Property Item(ByVal Index As Integer) As String
        Get
            Return strings(Index)
        End Get
        Set
            strings(Index) = Value
        End Set 
    End Property
End Class

Public Class Example

    Public Shared Function Main() As Integer

        ' Get the type and PropertyInfo.
        Dim t As Type = GetType(MyProperty)
        Dim pi As PropertyInfo = t.GetProperty("Caption")

        ' Get an array containing the parameters (if any).
        Dim params As ParameterInfo() = pi.GetIndexParameters()
        Console.WriteLine(vbCrLf & t.FullName & "." & pi.Name & _
           " has " & params.GetLength(0) & " parameters.")

        ' Display a property that has parameters.
        pi = t.GetProperty("Item")
        params = pi.GetIndexParameters()
        Console.WriteLine(t.FullName & "." & pi.Name & _
           " has " & params.GetLength(0) & " parameters.")
        For Each p As ParameterInfo In params
            Console.WriteLine("   Parameter: " & p.Name)
        Next

        Return 0
    End Function
End Class

' This example produces the following output:
' MyProperty.Caption has 0 parameters.
' MyProperty.Item has 1 parameters.
'    Parameter: Index
' </Snippet1>
