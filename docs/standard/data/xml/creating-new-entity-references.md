---
title: "Creating New Entity References"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a42f81b3-0403-4e34-b346-7d2129804e54
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Creating New Entity References
The **CreateEntityReference** method creates a new **XmlEntityReference** node. The XML Document Object Model (DOM) looks to see if the entity name being referenced has already been declared. If it has, the child nodes of **XmlEntityReference** node are copied from the entity declaration node. If there is no entity declaration that matches, an empty text node is attached as the only child of the entity reference node. Because the child nodes of the **XmlEntityReference** node are copies of other nodes, these child nodes are read-only and cannot be modified.  
  
 When the nodes are copied, there may be a namespace in scope at the point of the entity reference. This namespace affects the configuration of any element or attribute nodes generated.  
  
> [!NOTE]
>  The DOM adds child nodes to the **EntityReference** only when you insert the **EntityReference** node to the document. Newly created **EntityReference** nodes have no child nodes.  
  
 Even though the **XmlDataDocument** is a derived class of the **XmlDocument**, the **XmlDataDocument** does not support the creation of entity references. This is because **EntityReference** children are read-only. The children of an **EntityReference** node can span more than one region. In this case, part of a row associated with the region that contains a part of an **EntityReference** will be read-only.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
