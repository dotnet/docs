---
title: "Mapping XML Schema (XSD) Constraints to DataSet Constraints"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3d0d1a4b-9104-434f-ac04-6c01ab5716b5
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Mapping XML Schema (XSD) Constraints to DataSet Constraints
The XML Schema definition language (XSD) allows constraints to be specified on the elements and attributes it defines. When mapping an XML Schema to relational schema in a <xref:System.Data.DataSet>, XML Schema constraints are mapped to appropriate relational constraints on the tables and columns within the **DataSet**.  
  
 This section discusses the mapping of the following XML Schema constraints:  
  
-   The uniqueness constraint specified using the **unique** element.  
  
-   The key constraint specified using the **key** element.  
  
-   The keyref constraint specified using the **keyref** element.  
  
 By using a constraint on an element or attribute, you specify certain restrictions on the values of the element in any instance of the document. For example, a key constraint on a **CustomerID** child element of a **Customer** element in the schema indicates that the values of the **CustomerID** child element must be unique in any document instance, and that null values are not allowed.  
  
 Constraints can also be specified between elements and attributes in a document, in order to establish a relationship within the document. The key and keyref constraints are used in the schema to specify the constraints within the document, resulting in a relationship between document elements and attributes.  
  
 The mapping process converts these schema constraints into appropriate constraints on the tables created within the **DataSet**.  
  
## In This Section  
 [Map unique XML Schema (XSD) Constraints to DataSet Constraints](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/map-unique-xml-schema-xsd-constraints-to-dataset-constraints.md)  
 Describes the XML Schema elements used to create unique constraints in a **DataSet**.  
  
 [Map key XML Schema (XSD) Constraints to DataSet Constraints](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/map-key-xml-schema-xsd-constraints-to-dataset-constraints.md)  
 Describes the XML Schema elements used to create key constraints (unique constraints where null values are not allowed) in a **DataSet**.  
  
 [Map keyref XML Schema (XSD) Constraints to DataSet Constraints](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/map-keyref-xml-schema-xsd-constraints-to-dataset-constraints.md)  
 Describes the XML Schema elements used to create keyref (foreign key) constraints in a **DataSet**.  
  
## Related Sections  
 [Deriving DataSet Relational Structure from XML Schema (XSD)](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/deriving-dataset-relational-structure-from-xml-schema-xsd.md)  
 Describes the relational structure, or schema, of a **DataSet** that is created from XSD schema.  
  
 [Generating DataSet Relations from XML Schema (XSD)](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/generating-dataset-relations-from-xml-schema-xsd.md)  
 Describes the XML Schema elements used to create relations between table columns in a **DataSet**.  
  
## See Also  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
