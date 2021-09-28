---
description: "Learn more about: Inference Limitations"
title: "Inference Limitations"
ms.date: "03/30/2017"
ms.assetid: 78517994-5d57-44f8-9d20-38812977de09
---
# Inference Limitations

The process of inferring a <xref:System.Data.DataSet> schema from XML can result in different schemas depending on the XML elements in each document. For example, consider the following XML documents.  
  
 Document1:  
  
```xml  
<DocumentElement>  
  <Element1>Text1</Element1>  
  <Element1>Text2</Element1>  
</DocumentElement>  
```  
  
 Document2:  
  
```xml  
<DocumentElement>  
  <Element1>Text1</Element1>  
</DocumentElement>  
```  
  
 For "Document1," the inference process produces a **DataSet** named "DocumentElement" and a table named "Element1," because "Element1" is a repeating element.  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|Element1_Text|  
|--------------------|  
|Text1|  
|Text2|  
  
 However, for "Document2," the inference process produces a **DataSet** named "NewDataSet" and a table named "DocumentElement." "Element1" is inferred as a column because it has no attributes and no child elements.  
  
 **DataSet:** NewDataSet  
  
 **Table:** DocumentElement  
  
|Element1|  
|--------------|  
|Text1|  
  
 These two XML documents may have been intended to produce the same schema, but the inference process produces very different results based on the elements contained in each document.  
  
 To avoid the discrepancies that can occur when generating schema from an XML document, we recommend that you explicitly specify a schema using XML Schema definition language (XSD) or XML-Data Reduced (XDR) when loading a **DataSet** from XML. For more information about explicitly specifying a **DataSet** schema with XML Schema, see [Deriving DataSet Relational Structure from XML Schema (XSD)](deriving-dataset-relational-structure-from-xml-schema-xsd.md).  
  
## See also

- [Inferring DataSet Relational Structure from XML](inferring-dataset-relational-structure-from-xml.md)
- [Loading a DataSet from XML](loading-a-dataset-from-xml.md)
- [Loading DataSet Schema Information from XML](loading-dataset-schema-information-from-xml.md)
- [Using XML in a DataSet](using-xml-in-a-dataset.md)
- [DataSets, DataTables, and DataViews](index.md)
- [ADO.NET Overview](../ado-net-overview.md)
