         myServiceDescription.Types.Schemas.Remove(
            myServiceDescription.Types.Schemas[0]);
         XmlSchema myXmlSchema = new XmlSchema();
         myXmlSchema.AttributeFormDefault = XmlSchemaForm.Qualified;
         myXmlSchema.ElementFormDefault = XmlSchemaForm.Qualified;
         myXmlSchema.TargetNamespace = myServiceDescription.TargetNamespace;

         XmlSchemaElement myXmlElement1 = new XmlSchemaElement();
         myXmlElement1.Name="Add";

         XmlSchemaComplexType myXmlSchemaComplexType = 
            new XmlSchemaComplexType();
         XmlSchemaSequence myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "a", new XmlQualifiedName("s:float")));

         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "b", new XmlQualifiedName("s:float")));
                                              
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement1.SchemaType = myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement1);

         XmlSchemaElement myXmlElement2 = new XmlSchemaElement();
         myXmlElement2.Name = "AddResponse";
         myXmlSchemaComplexType = new XmlSchemaComplexType();
         myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "AddResult", new XmlQualifiedName("s:float")));
                                
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement2.SchemaType=myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement2);

         XmlSchemaElement myXmlElement3 = new XmlSchemaElement();
         myXmlElement3.Name="Subtract";
         myXmlSchemaComplexType = new XmlSchemaComplexType();
         myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "a", new XmlQualifiedName("s:float")));
                                              
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "b", new XmlQualifiedName("s:float")));
                                               
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement3.SchemaType=myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement3);

         XmlSchemaElement myXmlElement4 = new XmlSchemaElement();
         myXmlElement4.Name="SubtractResponse";
         myXmlSchemaComplexType = new XmlSchemaComplexType();
         myXmlSchemaSequence = new XmlSchemaSequence();
         myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement(
            "1", "1", "SubtractResult", new XmlQualifiedName("s:int")));
                           
         myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
         myXmlElement4.SchemaType = myXmlSchemaComplexType;
         myXmlSchema.Items.Add(myXmlElement4);

         // Add the schemas to the Types property of the ServiceDescription.
         myServiceDescription.Types.Schemas.Add(myXmlSchema);