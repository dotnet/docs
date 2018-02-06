---
title: "Copy Existing Nodes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2aa8f65c-cc62-4638-9c46-129dc15be786
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Copy Existing Nodes
There are many methods and properties in the XML Document Object Model (DOM)you can use to select a node, such as **SelectSingleNode**, **ChildNodes[int i]**, **Attributes[int i]**. Once the node is selected, you can insert it into the tree using one of the insert methods that work for that particular node type. The only restriction to inserting a node into the tree is that the document must still be well-formed after the node is inserted. When an existing node is inserted into the DOM tree, it is removed from its original position and added to its target position.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
