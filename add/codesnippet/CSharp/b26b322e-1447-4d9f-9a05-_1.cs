        // Get the name and the type of the field using its XML 
        // element name and its XML namespace. For this query to work,
        // the containing type must be preloaded, and the XML element 
        // name and the XML namespace must be explicitly declared on 
        // the field using a SoapFieldAttribute.

        // Preload the containing type.
        SoapServices.PreLoad(typeof(ExampleNamespace.ExampleClass));

        // Get the name and the type of a field that will be 
        // serialized as an XML element.
        Type containingType = typeof(ExampleNamespace.ExampleClass);
        string xmlElementNamespace = 
            "http://example.org/ExampleFieldNamespace";
        string xmlElementName = "ExampleFieldElementName";
        Type fieldType;
        string fieldName;
        SoapServices.GetInteropFieldTypeAndNameFromXmlElement(
            containingType, xmlElementName, xmlElementNamespace, 
            out fieldType, out fieldName);
        Console.WriteLine(
            "The type of the field is {0}.",
            fieldType);
        Console.WriteLine(
            "The name of the field is {0}.",
            fieldName);

        // Get the name and the type of a field that will be 
        // serialized as an XML attribute.
        string xmlAttributeNamespace = 
            "http://example.org/ExampleAttributeNamespace";
        string xmlAttributeName = "ExampleFieldAttributeName";
        SoapServices.GetInteropFieldTypeAndNameFromXmlAttribute(
            containingType, xmlAttributeName, xmlAttributeNamespace, 
            out fieldType, out fieldName);
        Console.WriteLine(
            "The type of the field is {0}.",
            fieldType);
        Console.WriteLine(
            "The name of the field is {0}.",
            fieldName);