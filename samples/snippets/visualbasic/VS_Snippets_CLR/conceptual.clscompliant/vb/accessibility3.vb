' Visual Basic .NET Document
Option Strict On

' <Snippet27>
Imports System.Text

<Assembly: CLSCompliant(True)>

Public Class StringWrapper

    Dim internalString As String
    Dim internalSB As StringBuilder = Nothing
    Dim useSB As Boolean = False

    Public Sub New(type As StringOperationType)
        If type = StringOperationType.Normal Then
            useSB = False
        Else
            internalSB = New StringBuilder()
            useSB = True
        End If
    End Sub

    ' The remaining source code...
End Class

Friend Enum StringOperationType As Integer
    Normal = 0
    Dynamic = 1
End Enum
' The attempt to compile the example displays the following output:
'    error BC30909: 'type' cannot expose type 'StringOperationType'
'     outside the project through class 'StringWrapper'.
'    
'       Public Sub New(type As StringOperationType)
'                              ~~~~~~~~~~~~~~~~~~~
' </Snippet27>

Module Example
    Public Sub Main()

    End Sub
End Module

