'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaObject
   
   Public Shared Sub Main()
      Dim s As New XmlSchema()
      s.TargetNamespace = "myNamespace"
      s.Namespaces.Add("myImpPrefix", "myImportNamespace")
      
      ' Create the <xs:import> element.
      Dim import As New XmlSchemaImport()
      import.Namespace = "myImportNamespace"
      import.SchemaLocation = "http://www.example.com/myImportNamespace"
      s.Includes.Add(import)
      
      ' Create an element and assign a type from imported schema.
      Dim elem As New XmlSchemaElement()
      elem.SchemaTypeName = New XmlQualifiedName("importType", "myImportNamespace")
      elem.Name = "element1"
      
      s.Items.Add(elem)
      s.Write(Console.Out)
   End Sub 'Main 
End Class 'XmlSchemaObject
'</Snippet1>
