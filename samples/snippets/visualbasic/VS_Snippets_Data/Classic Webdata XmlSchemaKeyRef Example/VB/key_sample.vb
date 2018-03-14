' <Snippet1>
Imports System
Imports System.Collections
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.Schema

Public Class XmlSchemaObjectGenerator
   
   Private Shared Sub ValidationCallback(sender As Object, args As ValidationEventArgs)
      
      If args.Severity = XmlSeverityType.Warning Then
         Console.Write("WARNING: ")
      Else
         If args.Severity = XmlSeverityType.Error Then
            Console.Write("ERROR: ")
         End If 
      End If
      Console.WriteLine(args.Message)
   End Sub 'ValidationCallback
   
   
   
   Public Shared Sub Main()
      
      
      Dim tr As New XmlTextReader("empty.xsd")
      Dim schema As XmlSchema = XmlSchema.Read(tr, New ValidationEventHandler(AddressOf ValidationCallback))
      
      schema.ElementFormDefault = XmlSchemaForm.Qualified
      
      schema.TargetNamespace = "http://www.example.com/Report"
      
      If (True) Then
         
         Dim element As New XmlSchemaElement()
         element.Name = "purchaseReport"
         
         Dim element_complexType As New XmlSchemaComplexType()
         
         Dim element_complexType_sequence As New XmlSchemaSequence()
         
         If (True) Then
            
            Dim element_complexType_sequence_element As New XmlSchemaElement()
            element_complexType_sequence_element.Name = "region"
            element_complexType_sequence_element.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
            
            If (True) Then
               
               Dim element_complexType_sequence_element_keyref As New XmlSchemaKeyref()
               element_complexType_sequence_element_keyref.Name = "dummy2"
               element_complexType_sequence_element_keyref.Selector = New XmlSchemaXPath()
               element_complexType_sequence_element_keyref.Selector.XPath = "r:zip/r:part"
               
               If (True) Then
                  Dim field As New XmlSchemaXPath()
                  
                  field.XPath = "@number"
                  element_complexType_sequence_element_keyref.Fields.Add(field)
               End If
               element_complexType_sequence_element_keyref.Refer = New XmlQualifiedName("pNumKey", "http://www.example.com/Report")
               element_complexType_sequence_element.Constraints.Add(element_complexType_sequence_element_keyref)
            End If
            element_complexType_sequence.Items.Add(element_complexType_sequence_element)
         End If
         element_complexType.Particle = element_complexType_sequence
         
         If (True) Then
            
            Dim element_complexType_attribute As New XmlSchemaAttribute()
            element_complexType_attribute.Name = "periodEnding"
            element_complexType_attribute.SchemaTypeName = New XmlQualifiedName("date", "http://www.w3.org/2001/XMLSchema")
            element_complexType.Attributes.Add(element_complexType_attribute)
         End If
         element.SchemaType = element_complexType
         
         If (True) Then
            
            Dim element_key As New XmlSchemaKey()
            element_key.Name = "pNumKey"
            element_key.Selector = New XmlSchemaXPath()
            element_key.Selector.XPath = "r:parts/r:part"
            
            If (True) Then
               Dim field As New XmlSchemaXPath()
               
               field.XPath = "@number"
               element_key.Fields.Add(field)
            End If
            element.Constraints.Add(element_key)
         End If
         
         schema.Items.Add(element)
      End If
      
      schema.Write(Console.Out)
   End Sub 'Main 
End Class 'XmlSchemaObjectGenerator 

' Main() 

'XmlSchemaObjectGenerator
' </Snippet1>