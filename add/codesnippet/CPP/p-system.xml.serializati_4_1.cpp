public:
   void SerializeOrder( String^ filename )
   {
      // Create an XmlSerializer instance using the method below.
      XmlSerializer^ myXmlSerializer = CreateOverrider();
      
      // Create the object, and set its Name property.
      Student^ myStudent = gcnew Student;
      myStudent->Name = "Student class1";
      
      // Serialize the class, and close the TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );
      myXmlSerializer->Serialize( writer, myStudent );
      writer->Close();
   }

   // Return an XmlSerializer to  the root serialization.
   XmlSerializer^ CreateOverrider()
   {
      // Create an XmlAttributes to  the default root element.
      XmlAttributes^ myXmlAttributes = gcnew XmlAttributes;
      
      // Create an XmlRootAttribute and set its element name and namespace.
      XmlRootAttribute^ myXmlRootAttribute = gcnew XmlRootAttribute;
      myXmlRootAttribute->ElementName = "OverriddenRootElementName";
      myXmlRootAttribute->Namespace = "http://www.microsoft.com";
      
      // Set the XmlRoot property to the XmlRoot object.
      myXmlAttributes->XmlRoot = myXmlRootAttribute;
      XmlAttributeOverrides^ myXmlAttributeOverrides =
         gcnew XmlAttributeOverrides;
      
      // Add the XmlAttributes object to the XmlAttributeOverrides object.
      myXmlAttributeOverrides->Add( Student::typeid, myXmlAttributes );
      
      // Create the Serializer, and return it.
      XmlSerializer^ myXmlSerializer = gcnew XmlSerializer(
         Student::typeid, myXmlAttributeOverrides );
      return myXmlSerializer;
   }