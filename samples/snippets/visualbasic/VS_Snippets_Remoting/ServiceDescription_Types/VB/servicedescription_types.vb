' System.Web.Services.Description.ServiceDescription.Types
' System.Web.Services.Description.ServiceDescription.Write(Stream)

' The following program demonstrates the 'Write' method and 'Types' property
' of ServiceDescription class.An existing WSDL document is read.
' Types of the SericeDescription are removed.New Types are constructed.
' Types are then added to ServiceDescription . A new WSDL file is created as output.

Imports System
Imports System.Text
Imports System.Web.Services.Description
Imports System.Collections
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

Class ServiceDescription_Types
   
   Public Shared Sub Main()
      Try
         ' Read the existing WSDL.
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("Input_VB.wsdl")
' <Snippet1>
         myServiceDescription.Types.Schemas.Remove( _
            myServiceDescription.Types.Schemas(0))
         Dim myXmlSchema As New XmlSchema()
         myXmlSchema.AttributeFormDefault = XmlSchemaForm.Qualified
         myXmlSchema.ElementFormDefault = XmlSchemaForm.Qualified
         myXmlSchema.TargetNamespace = myServiceDescription.TargetNamespace
         
         Dim myXmlElement1 As New XmlSchemaElement()
         myXmlElement1.Name = "Add"

         Dim myXmlSchemaComplexType As New XmlSchemaComplexType()
         Dim myXmlSchemaSequence As New XmlSchemaSequence()
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement( _
            "1", "1", "a", New XmlQualifiedName("s:float")))
         
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement( _
            "1", "1", "b", New XmlQualifiedName("s:float")))
         
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence
         myXmlElement1.SchemaType = myXmlSchemaComplexType
         myXmlSchema.Items.Add(myXmlElement1)
         
         Dim myXmlElement2 As New XmlSchemaElement()
         myXmlElement2.Name = "AddResponse"
         myXmlSchemaComplexType = New XmlSchemaComplexType()
         myXmlSchemaSequence = New XmlSchemaSequence()
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement( _
            "1", "1", "AddResult", New XmlQualifiedName("s:float")))
         
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence
         myXmlElement2.SchemaType = myXmlSchemaComplexType
         myXmlSchema.Items.Add(myXmlElement2)
         
         Dim myXmlElement3 As New XmlSchemaElement()
         myXmlElement3.Name = "Subtract"
         myXmlSchemaComplexType = New XmlSchemaComplexType()
         myXmlSchemaSequence = New XmlSchemaSequence()
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement( _
            "1", "1", "a", New XmlQualifiedName("s:float")))
         
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement( _
            "1", "1", "b", New XmlQualifiedName("s:float")))
         
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence
         myXmlElement3.SchemaType = myXmlSchemaComplexType
         myXmlSchema.Items.Add(myXmlElement3)
         
         Dim myXmlElement4 As New XmlSchemaElement()
         myXmlElement4.Name = "SubtractResponse"
         myXmlSchemaComplexType = New XmlSchemaComplexType()
         myXmlSchemaSequence = New XmlSchemaSequence()
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement( _
            "1", "1", "SubtractResult", New XmlQualifiedName("s:int")))
         
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence
         myXmlElement4.SchemaType = myXmlSchemaComplexType
         myXmlSchema.Items.Add(myXmlElement4)
         
         ' Add the schemas to the Types property of the ServiceDescription.
         myServiceDescription.Types.Schemas.Add(myXmlSchema)
' </Snippet1>

' <Snippet2>
         Dim myFileStream As New FileStream("output.wsdl", _
            FileMode.OpenOrCreate, FileAccess.Write)
         Dim myStreamWriter As New StreamWriter(myFileStream)

         ' Write the WSDL.
         Console.WriteLine("Writing a new WSDL file.")
         myServiceDescription.Write(myStreamWriter)
         myStreamWriter.Close()
         myFileStream.Close()
' </Snippet2>
      Catch e As Exception
         Console.WriteLine("Exception Caught! " + e.Message)
      End Try
   End Sub 'Main
   
   ' This function creates a XmlComplex Element.
   Public Shared Function CreateComplexTypeXmlElement( _
         minoccurs As String, maxoccurs As String, name As String, _
         schemaTypeName As XmlQualifiedName) As XmlSchemaElement
      Dim myXmlSchemaElement As New XmlSchemaElement()
      myXmlSchemaElement.MinOccursString = minoccurs
      myXmlSchemaElement.MaxOccursString = maxoccurs
      myXmlSchemaElement.Name = name
      myXmlSchemaElement.SchemaTypeName = schemaTypeName
      Return myXmlSchemaElement
   End Function 'CreateComplexTypeXmlElement
End Class 'ServiceDescription_Types
