---
description: "Learn more about: Working with XML Schemas"
title: "Working with XML Schemas"
ms.date: "03/30/2017"
ms.assetid: bbbcc70c-bf9a-4f6a-af72-1bab5384a187
---
# Working with XML Schemas

To define the structure of an XML document, as well as its element relationships, data types, and content constraints, you use a document type definition (DTD) or XML Schema definition language (XSD) schema. Although an XML document is considered to be well-formed if it meets all the syntactical requirements defined by the World Wide Web Consortium (W3C) Extensible Markup Language (XML) 1.0 Recommendation, it is not considered valid unless it is both well-formed and conforms to the constraints defined by its DTD or schema. Therefore, although all valid XML documents are well-formed, not all well-formed XML documents are valid.  
  
 For more information about XML, see the [W3C XML 1.0 Recommendation](https://www.w3.org/TR/REC-xml/). For more information about XML Schema, see the [W3C XML Schema Part 1: Structures Recommendation](https://www.w3.org/TR/xmlschema-1/) and the [W3C XML Schema Part 2: Datatypes Recommendation](https://www.w3.org/TR/xmlschema-2/) recommendations.  
  
## In This Section  

 [XML Schema Object Model (SOM)](xml-schema-object-model-som.md)  
 Discusses the Schema Object Model (SOM) in the <xref:System.Xml.Schema?displayProperty=nameWithType> namespace that provides a set of classes that allows you to read a Schema definition language (XSD) schema from a file or programmatically create a schema in-memory.  
  
 [XmlSchemaSet for Schema Compilation](xmlschemaset-for-schema-compilation.md)  
 Discusses the <xref:System.Xml.Schema.XmlSchemaSet> class that is a cache where XSD schemas can be stored and validated.  
  
 [XmlSchemaValidator Push-Based Validation](xmlschemavalidator-push-based-validation.md)  
 Discusses the <xref:System.Xml.Schema.XmlSchemaValidator> class that provides an efficient, high-performance mechanism to validate XML data against XSD schemas in a push-based manner.  
  
 [Inferring an XML Schema](inferring-an-xml-schema.md)  
 Discusses how to use the <xref:System.Xml.Schema.XmlSchemaInference> class to infer an XSD schema from the structure of an XML document.  
  
## Reference  

 <xref:System.Xml.Schema.XmlSchemaSet> &#124; <xref:System.Xml.Schema.XmlSchemaInference> &#124; <xref:System.Xml.XmlReader>  
  
## Related Sections  

 [Validating an XML Document in the DOM](validating-an-xml-document-in-the-dom.md)  
 Discusses how to validate the XML in the Document Object Model (DOM). You can validate the XML as it is loaded into the DOM, or validate a previously unvalidated XML document in the DOM.  
  
 [Schema Validation using XPathNavigator](schema-validation-using-xpathnavigator.md)  
 Discusses how to validate XML being navigated and edited using the <xref:System.Xml.XPath.XPathNavigator> class.
