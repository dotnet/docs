'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Group
   ' Only the GroupName field will be known.
   Public GroupName As String
End Class

Public Class Test
   Shared Sub Main()
      Dim t As Test = New Test()
      t.DeserializeObject("UnknownNodes.xml")
   End Sub

   Private Sub DeserializeObject(filename As String )
      Dim mySerializer As XmlSerializer  = New XmlSerializer(GetType(Group))
      Dim fs As FileStream = New FileStream(filename, FileMode.Open)
      AddHandler mySerializer.UnknownNode, _
      AddressOf serializer_UnknownNode
      Dim myGroup As Group = _
      CType(mySerializer.Deserialize(fs), Group)
      fs.Close()
   End Sub
   
   Private Sub serializer_UnknownNode _
   (sender As object , e As XmlNodeEventArgs )
      Console.WriteLine _
      ("UnknownNode Name: {0}", e.Name)
      Console.WriteLine _
      ("UnknownNode LocalName: {0}" ,e.LocalName)
      Console.WriteLine _
      ("UnknownNode Namespace URI: {0}", e.NamespaceURI)
      Console.WriteLine _
      ("UnknownNode Text: {0}", e.Text)

      Dim myNodeType As XmlNodeType = e.NodeType
      Console.WriteLine("NodeType: {0}", myNodeType)
 
      Dim myGroup As Group = CType(e.ObjectBeingDeserialized, Group)
      Console.WriteLine("GroupName: {0}", myGroup.GroupName)
      Console.WriteLine()
   End Sub
End Class
' Paste this XML into a file named UnknownNodes:
'<?xml version="1.0" encoding="utf-8"?>
'<Group xmlns:xsi="http:'www.w3.org/2001/XMLSchema-instance" 

'xmlns:xsd="http:'www.w3.org/2001/XMLSchema" xmlns:coho = "http:'www.cohowinery.com" 

'xmlns:cp="http:'www.cpandl.com">
'   <coho:GroupName>MyGroup</coho:GroupName>
'   <cp:GroupSize>Large</cp:GroupSize>
'   <cp:GroupNumber>444</cp:GroupNumber>
'   <coho:GroupBase>West</coho:GroupBase>
'   <coho:ThingInfo>
'      <Number>1</Number>
'      <Name>Thing1</Name>
'      <Elmo>
'         <Glue>element</Glue>
'      </Elmo>
'  </coho:ThingInfo>
'/Group>
' </Snippet1>


