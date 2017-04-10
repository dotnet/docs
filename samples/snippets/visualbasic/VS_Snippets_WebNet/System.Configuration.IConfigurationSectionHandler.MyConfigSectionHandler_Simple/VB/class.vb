'<snippet1>
Imports System
Imports System.Collections
Imports System.Text
Imports System.Configuration
Imports System.Xml

Namespace MyConfigSectionHandler
  Public Class MyHandler
    Implements IConfigurationSectionHandler

    Public Function Create( _
    ByVal parent As Object, ByVal configContext As Object, ByVal section As System.Xml.XmlNode) _
    As Object Implements System.Configuration.IConfigurationSectionHandler.Create

      Throw New System.Exception("The method is not implemented.")

    End Function
  End Class
End Namespace
'</snippet1>