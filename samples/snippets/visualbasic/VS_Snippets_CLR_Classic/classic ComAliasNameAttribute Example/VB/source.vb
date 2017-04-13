Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

' <Snippet2>
Interface Baz
    Sub SetColor( <ComAliasName("stdole.OLE_COLOR")> cl As Integer)
    Function GetColor() As <ComAliasName("stdole.OLE_COLOR")> Integer
End Interface
' </Snippet2>