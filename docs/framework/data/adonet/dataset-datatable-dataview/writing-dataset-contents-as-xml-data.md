---
title: "Writing DataSet Contents as XML Data"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: fd15f8a5-3b4c-46d0-a561-4559ab2a4705
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Writing DataSet Contents as XML Data
In ADO.NET you can write an XML representation of a <xref:System.Data.DataSet>, with or without its schema. If schema information is included inline with the XML, it is written using the XML Schema definition language (XSD). The schema contains the table definitions of the <xref:System.Data.DataSet> as well as the relation and constraint definitions.  
  
 When a <xref:System.Data.DataSet> is written as XML data, the rows in the <xref:System.Data.DataSet> are written in their current versions. However, the <xref:System.Data.DataSet> can also be written as a DiffGram so that both the current and the original values of the rows will be included.  
  
 The XML representation of the <xref:System.Data.DataSet> can be written to a file, a stream, an **XmlWriter**, or a string. These choices provide great flexibility for how you transport the XML representation of the <xref:System.Data.DataSet>. To obtain the XML representation of the <xref:System.Data.DataSet> as a string, use the **GetXml** method as shown in the following example.  
  
```vb  
Dim xmlDS As String = custDS.GetXml()  
```  
  
```csharp  
string xmlDS = custDS.GetXml();  
```  
  
 **GetXml** returns the XML representation of the <xref:System.Data.DataSet> without schema information. To write the schema information from the <xref:System.Data.DataSet> (as XML Schema) to a string, use **GetXmlSchema**.  
  
 To write a <xref:System.Data.DataSet> to a file, stream, or **XmlWriter**, use the **WriteXml** method. The first parameter you pass to **WriteXml** is the destination of the XML output. For example, pass a string containing a file name, a **System.IO.TextWriter** object, and so on. You can pass an optional second parameter of an **XmlWriteMode** to specify how the XML output is to be written.  
  
 The following table shows the options for **XmlWriteMode**.  
  
|XmlWriteMode option|Description|  
|-------------------------|-----------------|  
|**IgnoreSchema**|Writes the current contents of the <xref:System.Data.DataSet> as XML data, without an XML Schema. This is the default.|  
|**WriteSchema**|Writes the current contents of the <xref:System.Data.DataSet> as XML data with the relational structure as inline XML Schema.|  
|**DiffGram**|Writes the entire <xref:System.Data.DataSet> as a DiffGram, including original and current values. For more information, see [DiffGrams](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/diffgrams.md).|  
  
 When writing an XML representation of a <xref:System.Data.DataSet> that contains **DataRelation** objects, you will most likely want the resulting XML to have the child rows of each relation nested within their related parent elements. To accomplish this, set the **Nested** property of the **DataRelation** to **true** when you add the **DataRelation** to the <xref:System.Data.DataSet>. For more information, see [Nesting DataRelations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/nesting-datarelations.md).  
  
 Following are two examples of how to write the XML representation of a <xref:System.Data.DataSet> to a file. The first example passes the file name for the resulting XML as a string to **WriteXml**. The second example passes a **System.IO.StreamWriter** object.  
  
```vb  
custDS.WriteXml("Customers.xml", XmlWriteMode.WriteSchema)  
```  
  
```csharp  
custDS.WriteXml("Customers.xml", XmlWriteMode.WriteSchema);  
```  
  
```vb  
Dim xmlSW As System.IO.StreamWriter = New System.IO.StreamWriter("Customers.xml")  
custDS.WriteXml(xmlSW, XmlWriteMode.WriteSchema)  
xmlSW.Close()  
```  
  
```csharp  
System.IO.StreamWriter xmlSW = new System.IO.StreamWriter("Customers.xml");  
custDS.WriteXml(xmlSW, XmlWriteMode.WriteSchema);  
xmlSW.Close();  
```  
  
## Mapping Columns to XML Elements, Attributes, and Text  
 You can specify how a column of a table is represented in XML using the **ColumnMapping** property of the **DataColumn** object. The following table shows the different **MappingType** values for the **ColumnMapping** property of a table column, and the resulting XML.  
  
|MappingType value|Description|  
|-----------------------|-----------------|  
|**Element**|This is the default. The column is written as an XML element where the ColumnName is the name of the element and the contents of the column are written as the text of the element. For example:<br /><br /> `<ColumnName>Column Contents</ColumnName>`|  
|**Attribute**|The column is written as an XML attribute of the XML element for the current row where the ColumnName is the name of the attribute and the contents of the column are written as the value of the attribute. For example:<br /><br /> `<RowElement ColumnName="Column Contents" />`|  
|**SimpleContent**|The contents of the column are written as text in the XML element for the current row. For example:<br /><br /> `<RowElement>Column Contents</RowElement>`<br /><br /> Note that **SimpleContent** cannot be set for a column of a table that has **Element** columns or nested relations.|  
|**Hidden**|The column is not written in the XML output.|  
  
## See Also  
 [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)  
 [DiffGrams](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/diffgrams.md)  
 [Nesting DataRelations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/nesting-datarelations.md)  
 [Writing DataSet Schema Information as XSD](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/writing-dataset-schema-information-as-xsd.md)  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
