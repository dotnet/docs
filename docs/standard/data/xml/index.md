---
description: "Learn more about: XML Documents and Data"
title: "XML Documents and Data"
ms.date: "03/30/2017"
ms.assetid: e695047f-3c0f-4045-8708-5baea91cc380
ms.topic: article
---
# XML Documents and Data

.NET provides a comprehensive and integrated set of classes that enable you to build XML-aware apps easily. The classes in the following namespaces support parsing and writing XML, editing XML data in memory, data validation, and XSLT transformation.

- <xref:System.Xml>

- <xref:System.Xml.XPath>

- <xref:System.Xml.Xsl>

- <xref:System.Xml.Schema>

- <xref:System.Xml.Linq>

For a full list, search for "System.Xml" on the [.NET API browser](../../../../api/index.md?term=system.xml).

The classes in these namespaces support World Wide Web Consortium (W3C) recommendations. For example:

- The <xref:System.Xml.XmlDocument?displayProperty=nameWithType> class implements the [W3C Document Object Model (DOM) Level 1 Core](https://www.w3.org/TR/REC-DOM-Level-1/) and [DOM Level 2 Core](https://www.w3.org/TR/DOM-Level-2-Core/) recommendations.

- The <xref:System.Xml.XmlReader?displayProperty=nameWithType> and <xref:System.Xml.XmlWriter?displayProperty=nameWithType> classes support the [W3C XML 1.0](https://www.w3.org/TR/2006/REC-xml-20060816/) and the [Namespaces in XML](https://www.w3.org/TR/REC-xml-names/) recommendations.

- Schemas in the <xref:System.Xml.Schema.XmlSchemaSet?displayProperty=nameWithType> class support the [W3C XML Schema Part 1: Structures](https://www.w3.org/TR/xmlschema-1/) and [XML Schema Part 2: Datatypes](https://www.w3.org/TR/xmlschema-2/) recommendations.

- Classes in the <xref:System.Xml.Xsl?displayProperty=nameWithType> namespace support XSLT transformations that conform to the [W3C XSLT 1.0](https://www.w3.org/TR/xslt) recommendation.

The XML classes in the .NET Framework provide these benefits:

- **Productivity.** [LINQ to XML (C#)](../../linq/linq-xml-overview.md) and [LINQ to XML (Visual Basic)](../../linq/linq-xml-overview.md) makes it easier to program with XML and provides a query experience that is similar to SQL.

- **Extensibility.** The XML classes in the .NET Framework are extensible through the use of abstract base classes and virtual methods. For example, you can create a derived class of the <xref:System.Xml.XmlUrlResolver> class that stores the cache stream to the local disk.

- **Pluggable architecture.** The .NET Framework provides an architecture in which components can utilize one another, and data can be streamed between components. For example, a data store, such as an <xref:System.Xml.XPath.XPathDocument> or <xref:System.Xml.XmlDocument> object, can be transformed with the <xref:System.Xml.Xsl.XslCompiledTransform> class, and the output can then be streamed either into another store or returned as a stream from a web service.

- **Performance.** For better app performance, some of the XML classes in the .NET Framework support a streaming-based model with the following characteristics:

  - Minimal caching for forward-only, pull-model parsing (<xref:System.Xml.XmlReader>).

  - Forward-only validation (<xref:System.Xml.XmlReader>).

  - Cursor style navigation that minimizes node creation to a single virtual node while providing random access to the document (<xref:System.Xml.XPath.XPathNavigator>).

  For better performance whenever XSLT processing is required, you can use the <xref:System.Xml.XPath.XPathDocument> class, which is an optimized, read-only store for XPath queries designed to work efficiently with the <xref:System.Xml.Xsl.XslCompiledTransform> class.

- **Integration with ADO.NET.** The XML classes and [ADO.NET](../../../framework/data/adonet/index.md) are tightly integrated to bring together relational data and XML. The <xref:System.Data.DataSet> class is an in-memory cache of data retrieved from a database. The <xref:System.Data.DataSet> class has the ability to read and write XML by using the <xref:System.Xml.XmlReader> and <xref:System.Xml.XmlWriter> classes, to persist its internal relational schema structure as XML schemas (XSD), and to infer the schema structure of an XML document.

## In This Section

[XML Processing Options](xml-processing-options.md)
Discusses options for processing XML data.

[Processing XML Data In-Memory](processing-xml-data-in-memory.md)
Discusses the three models for processing XML data in-memory: [LINQ to XML (C#)](../../linq/linq-xml-overview.md) and [LINQ to XML (Visual Basic)](../../linq/linq-xml-overview.md), the <xref:System.Xml.XmlDocument> class (based on the W3C Document Object Model), and the <xref:System.Xml.XPath.XPathDocument> class (based on the XPath data model).

[XSLT Transformations](xslt-transformations.md)\
Describes how to use the XSLT processor.

[XML Schema Object Model (SOM)](xml-schema-object-model-som.md)\
Describes the classes used for building and manipulating XML Schemas (XSD) by providing an <xref:System.Xml.Schema.XmlSchema> class to load and edit a schema.

[XML Integration with Relational Data and ADO.NET](xml-integration-with-relational-data-and-adonet.md)\
Describes how the .NET Framework enables real-time, synchronous access to both the relational and hierarchical representations of data through the <xref:System.Data.DataSet> object and the <xref:System.Xml.XmlDataDocument> object.

[Managing Namespaces in an XML Document](managing-namespaces-in-an-xml-document.md)\
Describes how the <xref:System.Xml.XmlNamespaceManager> class is used to store and maintain namespace information.

[Type Support in the System.Xml Classes](type-support-in-the-system-xml-classes.md)\
Describes how XML data types map to CLR types, how to convert XML data types, and other type support features in the <xref:System.Xml> classes.

## Related Sections

[ADO.NET](../../../framework/data/adonet/index.md)\
Provides information on how to access data using ADO.NET.

[Security](../../security/index.md)\
Provides an overview of the .NET Framework security system.
