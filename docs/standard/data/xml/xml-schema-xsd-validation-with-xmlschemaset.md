---
title: "XML Schema (XSD) Validation with XmlSchemaSet"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
ms.assetid: 359b10eb-ec05-4cc6-ac96-c2b060afc4de
author: "mairaw"
ms.author: "mairaw"
---
# XML Schema (XSD) Validation with XmlSchemaSet
XML documents can be validated against an XML schema definition language (XSD) schema in an <xref:System.Xml.Schema.XmlSchemaSet>.  
  
## Validating XML Documents  
 XML documents are validated by the <xref:System.Xml.XmlReader.Create%2A> method of the <xref:System.Xml.XmlReader> class. To validate an XML document, construct an <xref:System.Xml.XmlReaderSettings> object that contains an XML schema definition language (XSD) schema with which to validate the XML document.  
  
> [!NOTE]
> The <xref:System.Xml.Schema> namespace contains extension methods that make it easy to validate an XML tree against an XSD file when using [LINQ to XML (C#)](../../../csharp/programming-guide/concepts/linq/linq-to-xml.md) and [LINQ to XML (Visual Basic)](../../../visual-basic/programming-guide/concepts/linq/linq-to-xml.md). For more information on validating XML documents with LINQ to XML, see [How to: Validate Using XSD (LINQ to XML) (C#)](../../../csharp/programming-guide/concepts/linq/how-to-validate-using-xsd-linq-to-xml.md) and [How to: Validate Using XSD (LINQ to XML) (Visual Basic)](../../../visual-basic/programming-guide/concepts/linq/how-to-validate-using-xsd-linq-to-xml.md).  
  
 An individual schema or a set of schemas (as an <xref:System.Xml.Schema.XmlSchemaSet>) can be added to an <xref:System.Xml.Schema.XmlSchemaSet> by passing either one as a parameter to the <xref:System.Xml.Schema.XmlSchemaSet.Add%2A> method of <xref:System.Xml.Schema.XmlSchemaSet>. Note that when validating a document the target namespace of the document must match the target namespace of the schema in the schema set.  
  
 The following is an example XML document.  
  
 [!code-xml[XSDInference Examples#5](../../../../samples/snippets/xml/VS_Snippets_Data/XSDInference Examples/XML/contosoBooks.xml#5)]  
  
 The following is the schema that validates the example XML document.  
  
 [!code-xml[XSDInference Examples#6](../../../../samples/snippets/xml/VS_Snippets_Data/XSDInference Examples/XML/contosoBooks.xsd#6)]  
  
 In the code example that follows, the schema above is added to the <xref:System.Xml.Schema.XmlSchemaSet><xref:System.Xml.XmlReaderSettings.Schemas%2A> property of the <xref:System.Xml.XmlReaderSettings> object. The <xref:System.Xml.XmlReaderSettings> object is passed as a parameter to the <xref:System.Xml.XmlReader.Create%2A> method of the <xref:System.Xml.XmlReader> object, which validates the XML document above.  
  
 The <xref:System.Xml.XmlReaderSettings.ValidationType%2A> property of the <xref:System.Xml.XmlReaderSettings> object is set to `Schema` to enforce validation of the XML document by the <xref:System.Xml.XmlReader.Create%2A> method of the <xref:System.Xml.XmlReader> object. A <xref:System.Xml.Schema.ValidationEventHandler> is added to the <xref:System.Xml.XmlReaderSettings> object to handle any <xref:System.Xml.Schema.XmlSeverityType.Warning> or <xref:System.Xml.Schema.XmlSeverityType.Error> events raised by errors found during the validation process of both the XML document and the schema.  
  
 [!code-cpp[XmlSchemaSetOverall Example#1](../../../../samples/snippets/cpp/VS_Snippets_Data/XmlSchemaSetOverall Example/CPP/xmlschemasetexample.cpp#1)]
 [!code-csharp[XmlSchemaSetOverall Example#1](../../../../samples/snippets/csharp/VS_Snippets_Data/XmlSchemaSetOverall Example/CS/xmlschemasetexample.cs#1)]
 [!code-vb[XmlSchemaSetOverall Example#1](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XmlSchemaSetOverall Example/VB/xmlschemasetexample.vb#1)]  
  
## See also

- [XmlSchemaSet for Schema Compilation](../../../../docs/standard/data/xml/xmlschemaset-for-schema-compilation.md)
- [Working with XML Schemas](../../../../docs/standard/data/xml/working-with-xml-schemas.md)
