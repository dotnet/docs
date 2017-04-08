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

      ' Creates the configuration object that this method will return.
      ' This can be a custom configuration class.
      ' In this example, we use a System.Collections.Hashtable.
      Dim myConfigObject As New Hashtable

      ' Gets any attributes for this section element.
      Dim myAttribs As New Hashtable
      For Each attrib As XmlAttribute In section.Attributes
        If XmlNodeType.Attribute = attrib.NodeType Then
          myAttribs.Add(attrib.Name, attrib.Value)
        End If
      Next

      ' Puts the section name and attributes as the first config object item.
      myConfigObject.Add(section.Name, myAttribs)

      ' Gets the child element names and attributes.
      For Each child As XmlNode In section.ChildNodes
        If XmlNodeType.Element = child.NodeType Then
          Dim myChildAttribs As New Hashtable

          For Each childAttrib As XmlAttribute In child.Attributes
            If XmlNodeType.Attribute = childAttrib.NodeType Then
              myChildAttribs.Add(childAttrib.Name, childAttrib.Value)
            End If
          Next
          myConfigObject.Add(child.Name, myChildAttribs)
        End If
      Next

      Return (myConfigObject)

    End Function

  End Class

End Namespace
'</snippet1>


