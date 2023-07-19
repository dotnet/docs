
Imports System
Imports System.Xml

Public Partial Class WebForm1
    Inherits System.Web.UI.Page

    ' <violation>
    Sub Page_Load(sender As Object, e As EventArgs)
        Dim d As XmlDocument = New XmlDocument()
        Dim root As XmlElement = d.CreateElement("root")
        d.AppendChild(root)

        Dim allowedUser As XmlElement = d.CreateElement("allowedUser")
        root.AppendChild(allowedUser)
        allowedUser.InnerXml = "alice"

        Dim input As String = Request.Form("in")
        root.InnerXml = input

        ' If an attacker uses this for input:
        '     some text<allowedUser>oscar</allowedUser>
        ' Then the XML document will be:
        '     <root>some text<allowedUser>oscar</allowedUser></root>
    End Sub
    ' </violation>
End Class

Public Partial Class WebForm2
    Inherits System.Web.UI.Page

    ' <fix>
    Sub Page_Load(sender As Object, e As EventArgs)
        Dim d As XmlDocument = New XmlDocument()
        Dim root As XmlElement = d.CreateElement("root")
        d.AppendChild(root)

        Dim allowedUser As XmlElement = d.CreateElement("allowedUser")
        root.AppendChild(allowedUser)
        allowedUser.InnerText = "alice"

        Dim input As String = Request.Form("in")
        root.InnerText = input

        ' If an attacker uses this for input:
        '     some text<allowedUser>oscar</allowedUser>
        ' Then the XML document will be:
        '     <root>&lt;allowedUser&gt;oscar&lt;/allowedUser&gt;some text<allowedUser>alice</allowedUser></root>
    End Sub
    ' </fix>
End Class
