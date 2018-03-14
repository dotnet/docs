Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
    Public Shared Sub MyMethod(type As Type, baseType As Type)
        Trace.Assert( Not (type Is Nothing), "Type parameter is null", _
            "Can't get object for null type")

        ' Perform some processing.
    End Sub

' </Snippet1>
End Class

