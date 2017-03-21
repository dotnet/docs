   // Get the name and the type of the field using its XML
   // element name and its XML namespace. For this query to work,
   // the containing type must be preloaded, and the XML element
   // name and the XML namespace must be explicitly declared on
   // the field using a SoapFieldAttribute.
   // Preload the containing type.
   SoapServices::PreLoad( ExampleNamespace::ExampleClass::typeid );
   
   // Get the name and the type of a field that will be
   // serialized as an XML element.
   Type^ containingType = ExampleNamespace::ExampleClass::typeid;
   String^ xmlElementNamespace = L"http://example.org/ExampleFieldNamespace";
   String^ xmlElementName = L"ExampleFieldElementName";
   Type^ fieldType;
   String^ fieldName;
   SoapServices::GetInteropFieldTypeAndNameFromXmlElement(
      containingType,xmlElementName,xmlElementNamespace,fieldType,fieldName );
   Console::WriteLine( L"The type of the field is {0}.", fieldType );
   Console::WriteLine( L"The name of the field is {0}.", fieldName );
   
   // Get the name and the type of a field that will be
   // serialized as an XML attribute.
   String^ xmlAttributeNamespace =
      L"http://example.org/ExampleAttributeNamespace";
   String^ xmlAttributeName = L"ExampleFieldAttributeName";
   SoapServices::GetInteropFieldTypeAndNameFromXmlAttribute(
      containingType,xmlAttributeName,xmlAttributeNamespace,fieldType,fieldName );
   Console::WriteLine( L"The type of the field is {0}.", fieldType );
   Console::WriteLine( L"The name of the field is {0}.", fieldName );