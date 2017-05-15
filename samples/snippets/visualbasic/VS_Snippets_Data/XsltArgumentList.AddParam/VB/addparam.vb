'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl

Public Class Sample

    Public Shared Sub Main()

        ' Create the XslCompiledTransform and load the stylesheet.
        Dim xslt As New XslCompiledTransform()
        xslt.Load("order.xsl")

        ' Create the XsltArgumentList.
        Dim xslArg As New XsltArgumentList()

        ' Create a parameter which represents the current date and time.
        Dim d As DateTime = DateTime.Now
        xslArg.AddParam("date", "", d.ToString())

        Using w As XmlWriter = XmlWriter.Create("output.xml")
            ' Transform the file.
            xslt.Transform("order.xml", xslArg, w)
        End Using

    End Sub 'Main 
End Class 'Sample
'</snippet1>