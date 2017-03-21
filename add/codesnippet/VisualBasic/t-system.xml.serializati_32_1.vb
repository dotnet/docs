Public Class Group
    ' the XmlSerializer ignores this field.
    <XmlIgnore()> Public Comment As String
    
    ' The XmlSerializer serializes this field.
    Public GroupName As String
End Class
