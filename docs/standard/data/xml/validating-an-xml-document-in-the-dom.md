---
title: "Validating an XML Document in the DOM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
ms.assetid: 2c61c920-d0f8-4c72-bfcc-6524570f3060
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Validating an XML Document in the DOM
The <xref:System.Xml.XmlDocument> class does not validate the XML in the Document Object Model (DOM) against an XML Schema definition language (XSD) schema or document type definition (DTD) by default; the XML is only verified to be well-formed.  
  
 To validate the XML in the DOM, you can validate the XML as it is loaded into the DOM by passing a schema-validating <xref:System.Xml.XmlReader> to the <xref:System.Xml.XmlDocument.Load%2A> method of the <xref:System.Xml.XmlDocument> class, or validate a previously unvalidated XML document in the DOM using the <xref:System.Xml.XmlDocument.Validate%2A> method of the <xref:System.Xml.XmlDocument> class.  
  
## Validating an XML Document As It Is Loaded into the DOM  
 The <xref:System.Xml.XmlDocument> class validates the XML data as it is loaded into the DOM when a validating <xref:System.Xml.XmlReader> is passed to the <xref:System.Xml.XmlDocument.Load%2A> method of the <xref:System.Xml.XmlDocument> class.  
  
 After successful validation, schema defaults are applied, text values are converted to atomic values as necessary, and type information is associated with validated information items. As a result, typed XML data replaces previously untyped XML data.  
  
### Creating an XML Schema-Validating XmlReader  
 To create an XML schema-validating <xref:System.Xml.XmlReader>, follow these steps.  
  
1.  Construct a new <xref:System.Xml.XmlReaderSettings> instance.  
  
2.  Add an XML schema to the <xref:System.Xml.XmlReaderSettings.Schemas%2A> property of the <xref:System.Xml.XmlReaderSettings> instance.  
  
3.  Specify `Schema` as the <xref:System.Xml.XmlReaderSettings.ValidationType%2A>.  
  
4.  Optionally specify <xref:System.Xml.XmlReaderSettings.ValidationFlags%2A> and a <xref:System.Xml.XmlReaderSettings.ValidationEventHandler> to handle schema validation errors and warnings encountered during validation.  
  
5.  Finally, pass the <xref:System.Xml.XmlReaderSettings> object to the <xref:System.Xml.XmlReader.Create%2A> method of the <xref:System.Xml.XmlReader> class along with the XML document, creating a schema-validating <xref:System.Xml.XmlReader>.  
  
### Example  
 In the code example that follows, a schema-validating <xref:System.Xml.XmlReader> validates the XML data loaded into the DOM. Invalid modifications are made to the XML document and the document is then revalidated, causing schema validation errors. Finally, one of the errors is corrected, and then part of the XML document is partially validated.  
  
 [!code-cpp[XmlDocumentValidation.Load#1](../../../../samples/snippets/cpp/VS_Snippets_Data/XmlDocumentValidation.Load/CPP/XmlDocumentValidationExample.cpp#1)]
 [!code-csharp[XmlDocumentValidation.Load#1](../../../../samples/snippets/csharp/VS_Snippets_Data/XmlDocumentValidation.Load/CS/XmlDocumentValidationExample.cs#1)]
 [!code-vb[XmlDocumentValidation.Load#1](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XmlDocumentValidation.Load/VB/XmlDocumentValidationExample.vb#1)]  
  
 The example takes the `contosoBooks.xml` file as input.  
  
 [!code-xml[XPathXMLExamples#2](../../../../samples/snippets/xml/VS_Snippets_Data/XPathXMLExamples/XML/contosoBooks.xml#2)]  
  
 The example also takes the `contosoBooks.xsd` file as input.  
  
 [!code-xml[XPathXMLExamples#3](../../../../samples/snippets/xml/VS_Snippets_Data/XPathXMLExamples/XML/contosoBooks.xsd#3)]  
  
 Consider the following when validating XML data as it is loaded into the DOM.  
  
-   In the above example, the <xref:System.Xml.XmlReaderSettings.ValidationEventHandler> is called whenever an invalid type is encountered. If a <xref:System.Xml.XmlReaderSettings.ValidationEventHandler> is not set on the validating <xref:System.Xml.XmlReader>,an <xref:System.Xml.Schema.XmlSchemaValidationException> is thrown when <xref:System.Xml.XmlDocument.Load%2A> is called if any attribute or element type does not match the corresponding type specified in the validating schema.  
  
-   When an XML document is loaded into an <xref:System.Xml.XmlDocument> object with an associated schema that defines default values, the <xref:System.Xml.XmlDocument> treats these defaults as if they appeared in the XML document. This means that the <xref:System.Xml.XmlReader.IsEmptyElement%2A> property always returns `false` for an element that was defaulted from the schema. Even if in the XML document, it was written as an empty element.  
  
## Validating an XML Document in the DOM  
 The <xref:System.Xml.XmlDocument.Validate%2A> method of the <xref:System.Xml.XmlDocument> class validates the XML data loaded in the DOM against the schemas in the <xref:System.Xml.XmlDocument> object's <xref:System.Xml.XmlDocument.Schemas%2A> property. After successful validation, schema defaults are applied, text values are converted to atomic values as necessary, and type information is associated with validated information items. As a result, typed XML data replaces previously untyped XML data.  
  
 The example below is similar to the example in "Validating an XML Document As It Is Loaded into the DOM" above. In this example, the XML document is not validated as it is loaded into the DOM, but rather is validated after it has been loaded into the DOM using the <xref:System.Xml.XmlDocument.Validate%2A> method of the <xref:System.Xml.XmlDocument> class. The <xref:System.Xml.XmlDocument.Validate%2A> method validates the XML document against the XML schemas contained in the <xref:System.Xml.XmlDocument.Schemas%2A> property of the <xref:System.Xml.XmlDocument>. Invalid modifications are then made to the XML document, and the document is then revalidated, causing schema validation errors. Finally, one of the errors is corrected, and then part of the XML document is partially validated.  
  
 [!code-csharp[XmlDocumentValidation.Validate#1](../../../../samples/snippets/csharp/VS_Snippets_Data/XmlDocumentValidation.Validate/CS/XmlDocumentValidationExample.cs#1)]
 [!code-vb[XmlDocumentValidation.Validate#1](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XmlDocumentValidation.Validate/VB/XmlDocumentValidationExample.vb#1)]  
  
 The example takes as input the `contosoBooks.xml` and `contosoBooks.xsd` files referred to in "Validating an XML Document as it is Loaded into the DOM" above.  
  
## Handling Validation Errors and Warnings  
 XML schema validation errors are reported when validating XML data loaded in the DOM. You are notified about all schema validation errors found while validating the XML data as it is being loaded, or when validating a previously unvalidated XML document.  
  
 Validation errors are handled by the <xref:System.Xml.Schema.ValidationEventHandler>. If a <xref:System.Xml.Schema.ValidationEventHandler> was assigned to the <xref:System.Xml.XmlReaderSettings> instance, or passed to the <xref:System.Xml.XmlDocument.Validate%2A> method of the <xref:System.Xml.XmlDocument> class, the <xref:System.Xml.Schema.ValidationEventHandler> will handle schema validation errors; otherwise an <xref:System.Xml.Schema.XmlSchemaValidationException> is raised when a schema validation error is encountered.  
  
> [!NOTE]
>  The XML data is loaded into the DOM despite schema validation errors unless your <xref:System.Xml.Schema.ValidationEventHandler> raises an exception to stop the process.  
>   
>  Schema validation warnings are not reported unless the <xref:System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings> flag is specified to the <xref:System.Xml.XmlReaderSettings> object.  
  
 For examples illustrating the <xref:System.Xml.Schema.ValidationEventHandler>, see "Validating an XML Document As It Is Loaded into the DOM" and "Validating an XML Document in the DOM" above.  
  
## See Also  
 <xref:System.Xml.XmlDocument>  
 <xref:System.Xml.XmlReader>  
 <xref:System.Xml.Schema.ValidationEventHandler>  
 <xref:System.Xml.XmlReaderSettings>  
 [Process XML Data Using the DOM Model](../../../../docs/standard/data/xml/process-xml-data-using-the-dom-model.md)  
 [Working with XML Schemas](../../../../docs/standard/data/xml/working-with-xml-schemas.md)
