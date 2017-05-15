' <Snippet1>
Imports Microsoft.VisualBasic
Imports System.Web.Script.Serialization

Public Class Group
    ' The JavaScriptSerializer ignores this field.
    <ScriptIgnore()> Public Comment As String

    ' The JavaScriptSerializer serializes this field.
    Public GroupName As String
End Class
' </Snippet1>
