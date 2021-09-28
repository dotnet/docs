---
description: "Learn more about: Inferring Element Text"
title: "Inferring Element Text"
ms.date: "03/30/2017"
ms.assetid: 789799e5-716f-459f-a168-76c5cf22178b
---
# Inferring Element Text

If an element contains text and has no child elements to be inferred as tables (such as elements with attributes or repeated elements), a new column with the name **TableName_Text** will be added to the table that is inferred for the element. The text contained in the element will be added to a row in the table and stored in the new column. The **ColumnMapping** property of the new column will be set to **MappingType.SimpleContent**.  
  
 For example, consider the following XML.  
  
```xml  
<DocumentElement>  
  <Element1 attr1="value1">Text1</Element1>  
</DocumentElement>  
```  
  
 The inference process will produce a table named **Element1** with two columns: **attr1** and **Element1_Text**. The **ColumnMapping** property of the **attr1** column will be set to **MappingType.Attribute**. The **ColumnMapping** property of the **Element1_Text** column will be set to **MappingType.SimpleContent**.  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|attr1|Element1_Text|  
|-----------|--------------------|  
|value1|Text1|  
  
 If an element contains text, but also has child elements that contain text, a column will not be added to the table to store the text contained in the element. The text contained in the element will be ignored, while the text in the child elements is included in a row in the table. For example, consider the following XML.  
  
```xml  
<Element1>  
  Text1  
  <ChildElement1>Text2</ChildElement1>  
  Text3  
</Element1>  
```  
  
 The inference process will produce a table named **Element1** with one column named **ChildElement1**. The text for the **ChildElement1** element will be included in a row in the table. The other text will be ignored. The **ColumnMapping** property of the **ChildElement1** column will be set to **MappingType.Element**.  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|ChildElement1|  
|-------------------|  
|Text2|  
  
## See also

- [Inferring DataSet Relational Structure from XML](inferring-dataset-relational-structure-from-xml.md)
- [Loading a DataSet from XML](loading-a-dataset-from-xml.md)
- [Loading DataSet Schema Information from XML](loading-dataset-schema-information-from-xml.md)
- [Using XML in a DataSet](using-xml-in-a-dataset.md)
- [DataSets, DataTables, and DataViews](index.md)
- [ADO.NET Overview](../ado-net-overview.md)
