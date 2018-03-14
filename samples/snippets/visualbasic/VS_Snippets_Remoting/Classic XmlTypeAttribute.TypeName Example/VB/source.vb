Imports System
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Class Group
    Public Staff() As Person
End Class

<XmlType(TypeName := "Employee", _
 Namespace := "http://www.cpandl.com")> _
Public Class Person
    Public PersonName As String
    Public Position As Job
End Class


<XmlType(TypeName := "Occupation", _
 Namespace := "http://www.cohowinery.com")> _
Public Class Job
    Public JobName As String
End Class

' </Snippet1>
