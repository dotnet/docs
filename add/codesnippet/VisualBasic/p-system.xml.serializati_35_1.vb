Public Class Vehicle
    <XmlAttribute(Form := XmlSchemaForm.Qualified)> _
    Public Maker As String    

    <XmlAttribute(Form := XmlSchemaForm.Unqualified)> _
    Public ModelID As String
End Class
