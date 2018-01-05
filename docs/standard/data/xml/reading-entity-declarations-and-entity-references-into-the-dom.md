---
title: "Reading Entity Declarations and Entity References into the DOM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 86dba977-5cc4-4567-964f-027ffabc47b2
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Reading Entity Declarations and Entity References into the DOM
An entity is a declaration that states a name to be used in the XML in place of content or markup. There are two parts to entities. First, you must tie a name to the replacement content using an entity declaration. An entity declaration is created by using the `<!ENTITY name "value">` syntax in a document type definition (DTD) or XML schema. Secondly, the name defined in the entity declaration is subsequently used in the XML. When used in the XML, it is called an entity reference. For example, the following entity declaration declares an entity of the name `publisher` being associated with the content of "Microsoft Press".  
  
```xml  
<!ENTITY publisher "Microsoft Press">  
```  
  
 The following example shows the use of this entity declaration in XML as an entity reference.  
  
```xml  
<author>Fred</author>  
<pubinfo>Published by &publisher;</pubinfo>  
```  
  
 Some parsers automatically expand entities when a document is loaded into memory. Therefore, when the XML is being read into memory, entity declarations are remembered and saved. When the parser subsequently encounters `&;` characters, which identify a general entity reference, the parser looks up that name in an entity declaration table. The reference, `&publisher;` is replaced by the content that it represents. Using the following XML,  
  
```xml  
<author>Fred</author>  
<pubinfo>Published by &publisher;</pubinfo>  
```  
  
 expanding the entity reference and replacing the `&publisher;` with the Microsoft Press content gives the following expanded XML.  
  
 **Output**  
  
```xml  
<author>Fred</author>  
<pubinfo>Published by Microsoft Press</pubinfo>  
```  
  
 There are many kinds of entities. The following diagram shows the breakdown of entity types and terminology.  
  
 ![flow chart of entity type hierarchy](../../../../docs/standard/data/xml/media/entity-hierarchy.gif "Entity_hierarchy")  
  
 The default for the Microsoft .NET Framework implementation of the XML Document Object Model (DOM) is to preserve the entities references and not expand the entities when the XML is loaded. The implication of this is that as a document is loaded in the DOM, an **XmlEntityReference** node containing the reference variable `&publisher;` is created, with child nodes representing the content in the entity declared in the DTD.  
  
 Using the `<!ENTITY publisher "Microsoft Press">` entity declaration, the following diagram shows the **XmlEntity** and **XmlText** nodes created from this declaration.  
  
 ![nodes created from entity declaration](../../../../docs/standard/data/xml/media/xml-entitydeclaration-node2.png "xml_entitydeclaration_node2")  
  
 The differences when entity references are expanded and when they are not makes a difference in what nodes are generated in the DOM tree, in memory. The difference in the nodes that are generated is explained in the topics [Entity References are Preserved](../../../../docs/standard/data/xml/entity-references-are-preserved.md) and [Entity References are Expanded and Not Preserved](../../../../docs/standard/data/xml/entity-references-are-expanded-and-not-preserved.md).  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
