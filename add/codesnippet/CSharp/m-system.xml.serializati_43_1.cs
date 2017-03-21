   public void SerializeOrder(string filename)
   {
      // Create an XmlSerializer instance using the method below.
      XmlSerializer myXmlSerializer = CreateOverrider();

      // Create the object, and set its Name property.
      Student myStudent = new Student();
      myStudent.Name = "Student class1";

      // Serialize the class, and close the TextWriter.
      TextWriter writer = new StreamWriter(filename);
      myXmlSerializer.Serialize(writer, myStudent);
      writer.Close();
   }

   // Return an XmlSerializer to override the root serialization.
   public XmlSerializer CreateOverrider()
   {
      // Create an XmlAttributes to override the default root element.
      XmlAttributes myXmlAttributes = new XmlAttributes();

      // Create an XmlRootAttribute overloaded constructer 
      //and set its namespace.
      XmlRootAttribute myXmlRootAttribute = 
                     new XmlRootAttribute("OverriddenRootElementName");
      myXmlRootAttribute.Namespace = "http://www.microsoft.com";

      // Set the XmlRoot property to the XmlRoot object.
      myXmlAttributes.XmlRoot = myXmlRootAttribute;
      XmlAttributeOverrides myXmlAttributeOverrides = 
                                          new XmlAttributeOverrides();
      
      /* Add the XmlAttributes object to the 
      XmlAttributeOverrides object. */
      myXmlAttributeOverrides.Add(typeof(Student), myXmlAttributes);

      // Create the Serializer, and return it.
      XmlSerializer myXmlSerializer = new XmlSerializer
         (typeof(Student), myXmlAttributeOverrides);
      return myXmlSerializer;
   }