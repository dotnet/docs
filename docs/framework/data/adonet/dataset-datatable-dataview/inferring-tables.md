---
description: "Learn more about: Inferring Tables"
title: "Inferring Tables"
ms.date: "03/30/2017"
ms.assetid: 74a288d4-b8e9-4f1a-b2cd-10df92c1ed1f
---
# Inferring Tables

When inferring a schema for a <xref:System.Data.DataSet> from an XML document, ADO.NET first determines which XML elements represent tables. The following XML structures result in a table for the **DataSet** schema:  
  
- Elements with attributes  
  
- Elements with child elements  
  
- Repeating elements  
  
## Elements with Attributes  

 Elements that have attributes specified in them result in inferred tables. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1 attr1="value1"/>  
  <Element1 attr1="value2">Text1</Element1>  
</DocumentElement>  
```  
  
 The inference process produces a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|attr1|Element1_Text|  
|-----------|--------------------|  
|value1||  
|value2|Text1|  
  
## Elements with Child Elements  

 Elements that have child elements result in inferred tables. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>  
    <ChildElement1>Text1</ChildElement1>  
  </Element1>  
</DocumentElement>  
```  
  
 The inference process produces a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|ChildElement1|  
|-------------------|  
|Text1|  
  
 The document, or root, element result in an inferred table if it has attributes or child elements that are inferred as columns. If the document element has no attributes and no child elements that would be inferred as columns, the element is inferred as a **DataSet**. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>Text1</Element1>  
  <Element2>Text2</Element2>  
</DocumentElement>  
```  
  
 The inference process produces a table named "DocumentElement."  
  
 **DataSet:** NewDataSet  
  
 **Table:** DocumentElement  
  
|Element1|Element2|  
|--------------|--------------|  
|Text1|Text2|  
  
 Alternatively, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1 attr1="value1" attr2="value2"/>  
</DocumentElement>  
```  
  
 The inference process produces a **DataSet** named "DocumentElement" that contains a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|attr1|attr2|  
|-----------|-----------|  
|value1|value2|  
  
## Repeating Elements  

 Elements that repeat result in a single inferred table. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>Text1</Element1>  
  <Element1>Text2</Element1>  
</DocumentElement>  
```  
  
 The inference process produces a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|Element1_Text|  
|--------------------|  
|Text1|  
|Text2|  
  
## See also

- [Inferring DataSet Relational Structure from XML](inferring-dataset-relational-structure-from-xml.md)
- [Loading a DataSet from XML](loading-a-dataset-from-xml.md)
- [Loading DataSet Schema Information from XML](loading-dataset-schema-information-from-xml.md)
- [Using XML in a DataSet](using-xml-in-a-dataset.md)
- [DataSets, DataTables, and DataViews](index.md)
- [ADO.NET Overview](../ado-net-overview.md)
