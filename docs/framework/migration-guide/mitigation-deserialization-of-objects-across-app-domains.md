---
title: "Mitigation: Deserialization of Objects Across App Domains"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 30c2d66c-04a8-41a5-ad31-646b937f61b5
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Mitigation: Deserialization of Objects Across App Domains
In some cases, when an app uses two or more app domains with different application bases, the attempt to deserialize objects in the logical call context across app domains throws an exception.  
  
## Diagnosing the issue  
 The issue arises under the following sequence of conditions:  
  
1.  An app uses two or more app domains with different application bases.  
  
2.  Some types are explicitly added to the <xref:System.Runtime.Remoting.Messaging.LogicalCallContext> by calling a method such as <xref:System.Runtime.Remoting.Messaging.LogicalCallContext.SetData%2A?displayProperty=nameWithType> or <xref:System.Runtime.Remoting.Messaging.CallContext.LogicalSetData%2A?displayProperty=nameWithType>. These types are not marked as serializable and are not stored in the global assembly cache.  
  
3.  Later, code running in the non-default app domain tries to read a value from a configuration file or use XML to deserialize an object.  
  
4.  In order to read from a configuration file or deserialize the object, an <xref:System.Xml.XmlReader> object tries to access the configuration system.  
  
5.  If the configuration system has not already been initialized, it must complete its initialization. This means, among other things, that the runtime has to create a stable path for a configuration system, which it does as follows:  
  
    1.  It looks for evidence for the non-default app domain.  
  
    2.  It tries to calculate the evidence for the non-default app domain based on the default app domain.  
  
    3.  The call to get evidence for the default app domain triggers a cross-app domain call from the non-default app domain to the default app domain.  
  
    4.  As part of the cross-app domain contract in the .NET Framework, the contents of the logical call context also have to be marshaled across app domain boundaries.  
  
6.  Because the types that are in the logical call context cannot be resolved in the default app domain, an exception is thrown.  
  
## Mitigation  
 To work around this issue, do the following  
  
1.  Look for the call to `get_Evidence` in the call stack when the exception is thrown. The exception can be any of a large subset of exceptions, including <xref:System.IO.FileNotFoundException> and <xref:System.Runtime.Serialization.SerializationException>.  
  
2.  Identify the place in the app where no objects are added to the logical call context and add the following code:  
  
    ```  
    System.Configuration.ConfigurationManager.GetSection("system.xml/xmlReader");  
    ```  
  
## See Also  
 [Runtime Changes](../../../docs/framework/migration-guide/runtime-changes-in-the-net-framework-4-5-1.md)
