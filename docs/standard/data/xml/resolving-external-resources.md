---
title: "Resolving External Resources"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ad3fa320-4b8f-4e5c-b549-01157591007a
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Resolving External Resources
The **XmlResolver** property of the **XmlDocument** is used by the **XmlDocument** class to locate resources that are not inline in the XML data, such as external document type definitions (DTDs), entities, and schemas. These items can be located on a network or on a local drive, and are identifiable by a Uniform Resource Identifier (URI). This allows the **XmlDocument** to resolve **EntityReference** nodes that are present in the document and validate the document according to the external DTD or schema.  
  
## Fully-Trusted XmlDocument  
 The **XmlResolver** property affects the functionality of the **XmlDocument.Load** method. The table below shows how the **XmlDocument.XmlResolver** property works when the **XmlDocument** object is fully trusted. The following table shows the **XmlDocument.Load** methods when the input to the Load is a **TextReader**, **String**, **Stream**, or **URI**. This table does not apply to the **Load** method if the **XmlDocument** is loaded from an **XmlReader**.  
  
|XmlResolver property|Function|Notes|  
|--------------------------|--------------|-----------|  
|The property is set to an **XmlResolver** class that has been previously created and has properties already set on it by the user.|The **XmlDocument** uses the **XmlResolver** that is given to resolve file names, to resolve references to external resources such as DTDs, entities, and schemas.<br /><br /> The **XmlResolver** is also used when resolving external resources that are needed when adding or editing nodes in the **XmlDocument**.|The **XmlResolver** given to the **XmlDocument** is the resolver that is used whenever external resources need to be located and resolved.|  
|The property is set to **null** (**Nothing** in Microsoft Visual Basic .NET).|Features that require an external resource are not supported, such as locating an external schema, or DTD. Nor will external entities be resolved, and performing editing functions, such as inserting entity nodes that require resolution, are not supported.|The **XmlDocument** loads files as anonymous and does not attempt to resolve any other resources.|  
|The property is not set, but left in its default state.|An **XmlUrlResolver** with NULL credentials will be instantiated and used by the **XmlDocument** when resolving file names, locating external DTDs, entities, and schemas, and **null** credentials are used when editing nodes.||  
  
 The following table shows the **XmlDocument.Load** method when the input to the **Load** is an **XmlReader** and the **XmlDocument** is fully trusted.  
  
|XmlResolver property|Function|Notes|  
|--------------------------|--------------|-----------|  
|The **XmlResolver** class used by the **XmlDocument** is the same class being used by the **XmlReader**.|The **XmlDocument** uses the **XmlResolver** that was assigned to the **XmlReader**.<br /><br /> The **XmlDocument.Resolver** property cannot be set, regardless of the **XmlDocument** trust level, because it is getting an **XmlResolver** from the **XmlReader**. You cannot attempt to override the settings of the **XmlReaders**' **XmlResolver** by setting the **XmlResolver** property of the **XmlDocument**.|The **XmlReader** can be the **XmlTextReader**, **XmlValidatingReader**, or a custom-written reader. If the reader used supports entity resolution, external entities are resolved. If the reader passed does not support entity references, then entity references are not resolved.|  
  
## Semi-Trusted XmlDocument  
 The following table shows how the **XmlDocument.XmlResolver** property works when the object is semi-trusted. This table applies to the **XmlDocument.Load** methods when the input to the Load is a **TextReader**, **String**, **Stream**, or **URI**. This table does not apply to the **Load** method if the **XmlDocument** is loaded from an **XmlReader**.  
  
|XmlResolver property|Function|Notes|  
|--------------------------|--------------|-----------|  
|In the semi-trusted scenario, the **XmlResolver** property cannot be set to anything other than null.|An **XmlUrlResolver** with **null** credentials will be instantiated and used by the **XmlDocument** when resolving file names, locating external DTDs, entities, and schemas, and **null** credentials are used when editing nodes.|This behavior is identical to the behavior when the **XmlResolver** property is not set, but left in its default state.<br /><br /> The **XmlDocument** uses anonymous permissions for all actions.|  
|The property is set to **null** (**Nothing** in Microsoft Visual Basic .NET).|No features that require an external resource are supported, such as locating an external schema or DTD. Nor will external entities be resolved, and performing editing functions such as inserting entity nodes that require resolution, are not supported.|When the property is **null**, the behavior is the same regardless if the **XmlDocument** is fully trusted or semi-trusted.|  
|The property is not set, but left in its default state.|An **XmlUrlResolver** with **null** credentials will be instantiated and used by the **XmlDocument** when resolving file names, locating external DTDs, entities, and schemas, and **null** credentials are used when editing nodes.|The **XmlDocument** uses anonymous permissions for all actions.|  
  
 This table applies to the **XmlDocument.Load** method when the input to the **Load** is an **XmlReader**, and the **XmlDocument** is semi-trusted.  
  
|XmlResolver property|Function|Notes|  
|--------------------------|--------------|-----------|  
|The **XmlResolver** class used by the **XmlDocument** is the same one being used by the **XmlReader**.|The **XmlDocument** uses the **XmlResolver** that was assigned to the **XmlReader**.<br /><br /> The **XmlDocument.Resolver** property cannot be set, regardless of the **XmlDocument** trust level, because it is getting an **XmlResolver** from the **XmlReader**. You cannot attempt to override the settings of the **XmlReaders** **XmlResolver** by setting the **XmlResolver** property of the **XmlDocument**.|The **XmlReader** can be the **XmlTextReader**, validating <xref:System.Xml.XmlReader>, or a custom-written reader. If the reader used supports entity resolution, external entities are resolved. If the reader passed in does not support entity references, then entity references are not resolved.|  
  
 Setting the XmlResolver to contain the correct credentials allows access to external resources.  
  
> [!NOTE]
>  There is no way to retrieve the **XmlResolver** property. This helps to prevent a user from reusing an **XmlResolver** on which credentials have been set. Also, if an **XmlTextReader** or validating <xref:System.Xml.XmlReader> is used to load the **XmlDocument** and the **XmlDocument** has a resolver that has been set, the resolvers from these readers are not cached by the **XmlDocument** after the **Load** phase, since this also presents a security risk.  
  
 For more information, see the Remarks section of the <xref:System.Xml.XmlResolver> reference page.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
