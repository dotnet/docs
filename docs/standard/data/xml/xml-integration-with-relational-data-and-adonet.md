---
title: "XML Integration with Relational Data and ADO.NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f6ebb1a1-f2ca-49b9-92c9-0150940cf6e6
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XML Integration with Relational Data and ADO.NET
The **XmlDataDocument** class is a derived class of the **XmlDocument**, and contains XML data. The advantage of the **XmlDataDocument** is that it provides a bridge between relational and hierarchical data. It is an **XmlDocument** that can be bound to a **DataSet** and both classes can synchronize changes made to data contained in the two classes. An **XmlDocument** that is bound to a **DataSet** allows XML to integrate with relational data, and you do not have to have your data represented as either XML or in a relational format. You can do both and not be constrained to a single representation of the data.  
  
 The benefits of having data available in two views are:  
  
-   The structured portion of an XML document can be mapped to a dataset, and be efficiently stored, indexed, and searched.  
  
-   Transformations, validation, and navigation can be done efficiently through a cursor model over the XML data that is stored relationally. At times, it can be done more efficiently against relational structures than if the XML is stored in an **XmlDocument** model.  
  
-   The **DataSet** can store a portion of the XML. That is, you can use **XPath** or **XslTransform** to store to a **DataSet** only those elements and attributes of interest. From there, changes can be made to the smaller, filtered subset of data, with the changes propagating to the larger data in the **XmlDataDocument**.  
  
 You can also run a transform over data that was loaded into the **DataSet** from SQL Server. Another option is to bind .NET Framework classes-style-managed WinForm and WebForm controls to a **DataSet** that was populated from an XML input stream.  
  
 In addition to supporting **XslTransform**, an **XmlDataDocument** exposes relational data to **XPath** queries and validation.  Basically, all XML services are available over relational data, and relational facilities, such as control binding, codegen, and so on, are available over a structured projection of XML without compromising XML fidelity.  
  
 Because **XmlDataDocument** is inherited from an **XmlDocument**, it provides an implementation of the W3C DOM. The fact that the **XmlDataDocument** is associated with, and stores a subset of its data within, a **DataSet** does not restrict or alter its use as an **XmlDocument** in any way. Code written to consume an **XmlDocument** works unaltered against an **XmlDataDocument**. The **DataSet** provides the relational view of the same data by defining tables, columns, relations, and constraints, and is a stand-alone, in-memory user data store.  
  
 The following illustration shows the different associations that XML data has with the **DataSet** and **XmlDataDocument**.  
  
 ![XML DataSet](../../../../docs/standard/data/xml/media/xmlintegrationwithrelationaldataandadodotnet.gif "xmlIntegrationWithRelationalDataAndADOdotNet")  
  
 The illustration shows that XML data can be loaded directly into a **DataSet**, which allows direct manipulation with XML in the relational manner. Or, the XML can be loaded into a derived class of the DOM, which is the **XmlDataDocument**, and subsequently loaded and synchronized with the **DataSet**. Because the **DataSet** and **XmlDataDocument** are synchronized over a single set of data, changes made to the data in one store are reflected in the other store.  
  
 The **XmlDataDocument** inherits all the editing and navigational features from the **XmlDocument**. There are times when using the **XmlDataDocument** and its inherited features, synchronized with a **DataSet**, is a more appropriate option than loading XML directly into the **DataSet**. The following table shows the items to be considered when choosing which method to use to load the **DataSet**.  
  
|When to load XML directly into a DataSet|When to synchronize an XmlDataDocument with a DataSet|  
|----------------------------------------------|-----------------------------------------------------------|  
|Queries of data in the **DataSet** are easier using SQL than XPath.|XPath queries are needed over data in the **DataSet**.|  
|Preservation of element ordering in the source XML is not critical.|Preservation of element ordering in the source XML is critical.|  
|White space between elements and formatting does not need to be preserved in the source XML.|White space and formatting preservation in the source XML is critical.|  
  
 If loading and writing XML directly into and out of a **DataSet** addresses your needs, see [Loading a DataSet from XML](../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-a-dataset-from-xml.md) and [Writing a DataSet as XML Data](../../../../docs/framework/data/adonet/dataset-datatable-dataview/writing-dataset-contents-as-xml-data.md).  
  
 If loading the **DataSet** from an **XmlDataDocument** addresses your needs, see [Synchronizing a Datasetwith an XML Document](../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataset-and-xmldatadocument-synchronization.md).  
  
## See Also  
 [Using XML in a DataSet](../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)
