---
title: "Generating DataSet Relations from XML Schema (XSD)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1c9a1413-c0d2-4447-88ba-9a2b0cbc0aa8
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Generating DataSet Relations from XML Schema (XSD)
In a <xref:System.Data.DataSet>, you form an association between two or more columns by creating a parent-child relation. There are three ways to represent a **DataSet** relation within an XML Schema definition language (XSD) schema:  
  
-   Specify nested complex types.  
  
-   Use the **msdata:Relationship** annotation.  
  
-   Specify an **xs:keyref** without the **msdata:ConstraintOnly** annotation.  
  
## Nested Complex Types  
 Nested complex type definitions in a schema indicate the parent-child relationships of the elements. The following XML Schema fragment shows that **OrderDetail** is a child element of the **Order** element.  
  
```xml  
<xs:element name="Order">  
  <xs:complexType>  
     <xs:sequence>          
       <xs:element name="OrderDetail" />  
           <xs:complexType>               
           </xs:complexType>  
     </xs:sequence>  
  </xs:complexType>  
</xs:element>  
```  
  
 The XML Schema mapping process creates tables in the **DataSet** that correspond to the nested complex types in the schema. It also creates additional columns that are used as parent**-**child columns for the generated tables. Note that these parent**-**child columns specify relationships, which is not the same as specifying primary key/foreign key constraints.  
  
## msdata:Relationship Annotation  
 The **msdata:Relationship** annotation allows you to explicitly specify parent-child relationships between elements in the schema that are not nested. The following example shows the structure of the **Relationship** element.  
  
```xml  
<msdata:Relationship name="CustOrderRelationship"    
msdata:parent=""    
msdata:child=""    
msdata:parentkey=""    
msdata:childkey="" />  
```  
  
 The attributes of the **msdata:Relationship** annotation identify the elements involved in the parent-child relationship, as well as the **parentkey** and **childkey** elements and attributes involved in the relationship. The mapping process uses this information to generate tables in the **DataSet** and to create the primary key/foreign key relationship between these tables.  
  
 For example, the following schema fragment specifies **Order** and **OrderDetail** elements at the same level (not nested). The schema specifies an **msdata:Relationship** annotation, which specifies the parent-child relationship between these two elements. In this case, an explicit relationship must be specified using the **msdata:Relationship** annotation.  
  
```xml  
 <xs:element name="MyDataSet" msdata:IsDataSet="true">  
  <xs:complexType>  
    <xs:choice maxOccurs="unbounded">  
        <xs:element name="OrderDetail">  
          <xs:complexType>  
  
          </xs:complexType>  
       </xs:element>  
       <xs:element name="Order">  
          <xs:complexType>  
  
          </xs:complexType>  
       </xs:element>  
    </xs:choice>  
  </xs:complexType>  
</xs:element>  
   <xs:annotation>  
     <xs:appinfo>  
       <msdata:Relationship name="OrdOrdDetailRelation"  
          msdata:parent="Order"  
          msdata:child="OrderDetail"   
          msdata:parentkey="OrderNumber"  
          msdata:childkey="OrderNo"/>  
     </xs:appinfo>  
  </xs:annotation>  
```  
  
 The mapping process uses the **Relationship** element to create a parent-child relationship between the **OrderNumber** column in the **Order** table and the **OrderNo** column in the **OrderDetail** table in the **DataSet**. The mapping process only specifies the relationship; it does not automatically specify any constraints on the values in these columns, as do the primary key/foreign key constraints in relational databases.  
  
### In This Section  
 [Map Implicit Relations Between Nested Schema Elements](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/map-implicit-relations-between-nested-schema-elements.md)  
 Describes the constraints and relations that are implicitly created in a **DataSet** when nested elements are encountered in XML Schema.  
  
 [Map Relations Specified for Nested Elements](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/map-relations-specified-for-nested-elements.md)  
 Describes how to explicitly set relations in a **DataSet** for nested elements in XML Schema.  
  
 [Specify Relations Between Elements with No Nesting](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/specify-relations-between-elements-with-no-nesting.md)  
 Describes how to create relations in a **DataSet** between XML Schema elements that are not nested.  
  
### Related Sections  
 [Deriving DataSet Relational Structure from XML Schema (XSD)](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/deriving-dataset-relational-structure-from-xml-schema-xsd.md)  
 Describes the relational structure, or schema, of a **DataSet** that is created from XML Schema definition language (XSD) schema.  
  
 [Mapping XML Schema (XSD) Constraints to DataSet Constraints](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/mapping-xml-schema-xsd-constraints-to-dataset-constraints.md)  
 Describes the XML Schema elements used to create unique and foreign key constraints in a **DataSet**.  
  
## See Also  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
