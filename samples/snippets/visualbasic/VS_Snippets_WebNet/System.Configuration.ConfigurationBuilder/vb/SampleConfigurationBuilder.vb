Imports System.Configuration
Imports System.Xml

Public Class SampleConfigurationBuilder : Inherits ConfigurationBuilder

    Public Overrides Function ProcessRawXml(rawXml As XmlNode)  As XmlNode

        Dim rawXmlString As String = rawXml.OuterXml

        If String.IsNullOrEmpty(rawXmlString) Then
            Return rawXml
        End If

        rawXmlString = Environment.ExpandEnvironmentVariables(rawXmlString)

        Dim doc As New XmlDocument()
        doc.PreserveWhitespace = True
        doc.LoadXml(rawXmlString)
        Return doc.DocumentElement
    End Function

    Public Overrides Function ProcessConfigurationSection(configSection As ConfigurationSection)  As ConfigurationSection
       Return configSection
    End Function

End Class
