Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
<XmlType(Namespace := "http://www.cpandl.com", _
 TypeName := "GroupMember")> _
Public Class Person
    Public Name As String
End Class

<XmlType(Namespace := "http://www.cohowinery.com", _
 TypeName := "GroupAddress")> _ 
Public Class Address
    
    Public Line1 As String
    Public Line2 As String
    Public City As String
    Public State As String
    Public Zip As String
End Class

Public Class Group
    Public Staff() As Person
    Public Manager As Person
    Public Location As Address
End Class

' </Snippet1>
