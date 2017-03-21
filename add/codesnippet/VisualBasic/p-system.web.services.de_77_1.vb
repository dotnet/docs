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