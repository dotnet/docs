---
title: "Namespace Affect on Entity Reference Expansion for New Nodes Containing Elements and Attributes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 64359aee-aab0-4042-9a32-d19789af6ca7
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Namespace Affect on Entity Reference Expansion for New Nodes Containing Elements and Attributes
Because the content of an entity declaration can contain almost anything, there is a possibility that the content could contain an element like `<!ENTITY aname "<elem>test</elem>">`.  
  
 When the XML is parsed, `&aname;` is not expanded with its replacement content at parse time. The expansion of the XML is not done because resolution of the namespace for the element cannot occur until the node is placed in the document. Until that time, there is no knowledge of what namespace is in scope. When the node is put into the document, then the namespace resolution occurs, and the resulting entity content is parsed into its appropriate nodes.  
  
> [!NOTE]
>  Once the expansion occurs on a newly created entity reference node, it never reoccurs. Therefore, the namespaces used in the replacement text for the element are bound at the time that the parent node is set. However, the namespace can be changed for existing entity reference nodes when you remove and insert them somewhere else, or on entity reference nodes that are cloned with the **CloneNode** method.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
