---
title: "System.Xml namespaces1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a9a0f9fe-11a0-4e16-8083-723c867430dc
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Xml namespaces1
`System.Xml` and its child namespaces (`System.Xml.Linq`, `System.Xml.Schema`, and `System.Xml.Serialization`) contain types for processing XML.  
  
 This topic displays the types in the `System.Xml` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Xml namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Xml.ConformanceLevel>|Specifies the amount of input or output checking that the created XmlReader and XmlWriter objects perform.|  
|<xref:System.Xml.DtdProcessing>|Specifies the options for processing DTDs. The DtdProcessing enumeration is used by XmlReaderSettings.|  
|<xref:System.Xml.IXmlDictionary>|An interface that defines the contract that an Xml dictionary must implement to be used by XmlDictionaryReader and XmlDictionaryWriter implementations.|  
|<xref:System.Xml.IXmlLineInfo>|Provides an interface to enable a class to return line and position information.|  
|<xref:System.Xml.IXmlNamespaceResolver>|Provides read-only access to a set of prefix and namespace mappings.|  
|<xref:System.Xml.NamespaceHandling>|Specifies whether to remove duplicate namespace declarations in the XmlWriter.|  
|<xref:System.Xml.NameTable>|Implements a single-threaded XmlNameTable.|  
|<xref:System.Xml.NewLineHandling>|Specifies how to handle line breaks.|  
|<xref:System.Xml.ReadState>|Specifies the state of the reader.|  
|<xref:System.Xml.UniqueId>|A unique identifier optimized for Guids.|  
|<xref:System.Xml.WriteState>|Specifies the state of the XmlWriter.|  
|<xref:System.Xml.XmlBinaryReaderSession>|Enables optimized strings to be managed in a dynamic way.|  
|<xref:System.Xml.XmlBinaryWriterSession>|Enables using a dynamic dictionary to compress common strings that appear in a message and maintain state.|  
|<xref:System.Xml.XmlConvert>|Encodes and decodes XML names and provides methods for converting between common language runtime types and XML Schema definition language (XSD) types. When converting data types the values returned are locale independent.|  
|<xref:System.Xml.XmlDictionary>|Implements a dictionary used to optimize [!INCLUDE[indigo1](../net-uwp/includes/indigo1-md.md)]’s XML reader/writer implementations.|  
|<xref:System.Xml.XmlDictionaryReader>|An abstract class that the [!INCLUDE[indigo1](../net-uwp/includes/indigo1-md.md)] derives from to do serialization and deserialization.|  
|<xref:System.Xml.XmlDictionaryReaderQuotas>|Contains configurable quota values for XmlDictionaryReaders.|  
|<xref:System.Xml.XmlDictionaryString>|Represents an entry stored in a XmlDictionary.|  
|<xref:System.Xml.XmlDictionaryWriter>|An abstract class that the [!INCLUDE[indigo1](../net-uwp/includes/indigo1-md.md)] derives from to do serialization and deserialization.|  
|<xref:System.Xml.XmlException>|Returns detailed information about the last exception.|  
|<xref:System.Xml.XmlNamespaceManager>|Resolves, adds, and removes namespaces to a collection and provides scope management for these namespaces.|  
|<xref:System.Xml.XmlNamespaceScope>|Defines the namespace scope.|  
|<xref:System.Xml.XmlNameTable>|Table of atomized string objects.|  
|<xref:System.Xml.XmlNodeType>|Specifies the type of node.|  
|<xref:System.Xml.XmlParserContext>|Provides all the context information required by the XmlReader to parse an XML fragment.|  
|<xref:System.Xml.XmlQualifiedName>|Represents an XML qualified name.|  
|<xref:System.Xml.XmlReader>|Represents a reader that provides fast, non-cached, forward-only access to XML data.|  
|<xref:System.Xml.XmlReaderSettings>|Specifies a set of features to support on the XmlReader object created by the Create method.|  
|<xref:System.Xml.XmlSpace>|Specifies the current xml:space scope.|  
|<xref:System.Xml.XmlWriter>|Represents a writer that provides a fast, non-cached, forward-only means of generating streams or files containing XML data.|  
|<xref:System.Xml.XmlWriterSettings>|Specifies a set of features to support on the XmlWriter object created by the Create method.|  
  
## System.Xml.Linq namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Xml.Linq.Extensions>|Contains the LINQ to XML extension methods.|  
|<xref:System.Xml.Linq.LoadOptions>|Specifies load options when parsing XML.|  
|<xref:System.Xml.Linq.ReaderOptions>|Specifies whether to omit duplicate namespaces when loading an XDocument with an XmlReader.|  
|<xref:System.Xml.Linq.SaveOptions>|Specifies serialization options.|  
|<xref:System.Xml.Linq.XAttribute>|Represents an XML attribute.|  
|<xref:System.Xml.Linq.XCData>|Represents a text node that contains CDATA.|  
|<xref:System.Xml.Linq.XComment>|Represents an XML comment.|  
|<xref:System.Xml.Linq.XContainer>|Represents a node that can contain other nodes.|  
|<xref:System.Xml.Linq.XDeclaration>|Represents an XML declaration.|  
|<xref:System.Xml.Linq.XDocument>|Represents an XML document.|  
|<xref:System.Xml.Linq.XDocumentType>|Represents an XML Document Type Definition (DTD).|  
|<xref:System.Xml.Linq.XElement>|Represents an XML element.|  
|<xref:System.Xml.Linq.XName>|Represents a name of an XML element or attribute.|  
|<xref:System.Xml.Linq.XNamespace>|Represents an XML namespace. This class cannot be inherited.|  
|<xref:System.Xml.Linq.XNode>|Represents the abstract concept of a node (element, comment, document type, processing instruction, or text node) in the XML tree.|  
|<xref:System.Xml.Linq.XNodeDocumentOrderComparer>|Contains functionality to compare nodes for their document order. This class cannot be inherited.|  
|<xref:System.Xml.Linq.XNodeEqualityComparer>|Compares nodes to determine whether they are equal. This class cannot be inherited.|  
|<xref:System.Xml.Linq.XObject>|Represents a node or an attribute in an XML tree.|  
|<xref:System.Xml.Linq.XObjectChange>|Specifies the event type when an event is raised for an XObject.|  
|<xref:System.Xml.Linq.XObjectChangeEventArgs>|Provides data for the Changing and Changed events.|  
|<xref:System.Xml.Linq.XProcessingInstruction>|Represents an XML processing instruction.|  
|<xref:System.Xml.Linq.XStreamingElement>|Represents elements in an XML tree that supports deferred streaming output.|  
|<xref:System.Xml.Linq.XText>|Represents a text node.|  
  
## System.Xml.Schema namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Xml.Schema.XmlSchema>|An in-memory representation of an XML Schema as specified in the World Wide Web Consortium (W3C) XML Schema Part 1: Structures and XML Schema Part 2: Datatypes specifications.|  
|<xref:System.Xml.Schema.XmlSchemaForm>|Indicates if attributes or elements need to be qualified with a namespace prefix.|  
  
## System.Xml.Serialization namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Xml.Serialization.IXmlSerializable>|Provides custom formatting for XML serialization and deserialization.|  
|<xref:System.Xml.Serialization.XmlAnyAttributeAttribute>|Specifies that the member (a field that returns an array of XmlAttribute objects) can contain any XML attributes.|  
|<xref:System.Xml.Serialization.XmlAnyElementAttribute>|Specifies that the member (a field that returns an array of XmlElement or XmlNode objects) contains objects that represent any XML element that has no corresponding member in the object being serialized or deserialized.|  
|<xref:System.Xml.Serialization.XmlAnyElementAttributes>|Represents a collection of XmlAnyElementAttribute objects.|  
|<xref:System.Xml.Serialization.XmlArrayAttribute>|Specifies that the XmlSerializer must serialize a particular class member as an array of XML elements.|  
|<xref:System.Xml.Serialization.XmlArrayItemAttribute>|Specifies the derived types that the XmlSerializer can place in a serialized array.|  
|<xref:System.Xml.Serialization.XmlArrayItemAttributes>|Represents a collection of XmlArrayItemAttribute objects.|  
|<xref:System.Xml.Serialization.XmlAttributeAttribute>|Specifies that the XmlSerializer must serialize the class member as an XML attribute.|  
|<xref:System.Xml.Serialization.XmlAttributeOverrides>|Allows you to override property, field, and class attributes when you use the XmlSerializer to serialize or deserialize an object.|  
|<xref:System.Xml.Serialization.XmlAttributes>|Represents a collection of attribute objects that control how the XmlSerializer serializes and deserializes an object.|  
|<xref:System.Xml.Serialization.XmlChoiceIdentifierAttribute>|Specifies that the member can be further detected by using an enumeration.|  
|<xref:System.Xml.Serialization.XmlElementAttribute>|Indicates that a public field or property represents an XML element when the XmlSerializer serializes or deserializes the object that contains it.|  
|<xref:System.Xml.Serialization.XmlElementAttributes>|Represents a collection of XmlElementAttribute objects used by the XmlSerializer to override the default way it serializes a class.|  
|<xref:System.Xml.Serialization.XmlEnumAttribute>|Controls how the XmlSerializer serializes an enumeration member.|  
|<xref:System.Xml.Serialization.XmlIgnoreAttribute>|Instructs the Serialize method of the XmlSerializer not to serialize the public field or public read/write property value.|  
|<xref:System.Xml.Serialization.XmlIncludeAttribute>|Allows the XmlSerializer to recognize a type when it serializes or deserializes an object.|  
|<xref:System.Xml.Serialization.XmlNamespaceDeclarationsAttribute>|Specifies that the target property, parameter, return value, or class member contains prefixes associated with namespaces that are used within an XML document.|  
|<xref:System.Xml.Serialization.XmlRootAttribute>|Controls XML serialization of the attribute target as an XML root element.|  
|<xref:System.Xml.Serialization.XmlSchemaProviderAttribute>|When applied to a type, stores the name of a static method of the type that returns an XML schema and a XmlQualifiedName (or XmlSchemaType for anonymous types) that controls the serialization of the type.|  
|<xref:System.Xml.Serialization.XmlSerializer>|Serializes and deserializes objects into and from XML documents. The XmlSerializer enables you to control how objects are encoded into XML.|  
|<xref:System.Xml.Serialization.XmlSerializerNamespaces>|Contains the XML namespaces and prefixes that the XmlSerializer uses to generate qualified names in an XML-document instance.|  
|<xref:System.Xml.Serialization.XmlTextAttribute>|Indicates to the XmlSerializer that the member must be treated as XML text when the class that contains it is serialized or deserialized.|  
|<xref:System.Xml.Serialization.XmlTypeAttribute>|Controls the XML schema that is generated when the attribute target is serialized by the XmlSerializer.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)