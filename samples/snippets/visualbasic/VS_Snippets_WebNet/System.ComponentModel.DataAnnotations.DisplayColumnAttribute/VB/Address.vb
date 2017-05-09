'<Snippet1>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization

'<Snippet2>
<DisplayColumn("City", "PostalCode", False)> _
Partial Public Class Address

End Class
'</Snippet2>

'<Snippet3>
<DisplayColumn("LastName")> _
Public Partial Class Customer

End Class
'</Snippet3>

'</Snippet1>

