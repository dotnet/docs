---
title: "Security and Serialization"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "code security, serialization"
  - "serialization, security"
  - "secure coding, serialization"
  - "security [.NET Framework], serialization"
ms.assetid: b921bc94-bd3a-4c91-9ede-2c8d4f78ea9a
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security and Serialization
Because serialization can allow other code to see or modify object instance data that would otherwise be inaccessible, a special permission is required of code performing serialization: <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter> flag specified. Under default policy, this permission is not given to Internet-downloaded or intranet code; only code on the local computer is granted this permission.  
  
 Normally, all fields of an object instance are serialized, meaning that data is represented in the serialized data for the instance. It is possible for code that can interpret the format to determine what the data values are, independent of the accessibility of the member. Similarly, deserialization extracts data from the serialized representation and sets object state directly, again irrespective of accessibility rules.  
  
 Any object that could contain security-sensitive data should be made nonserializable, if possible. If it must be serializable, try to make specific fields that hold sensitive data nonserializable. If this cannot be done, be aware that this data will be exposed to any code that has permission to serialize, and make sure that no malicious code can get this permission.  
  
 The <xref:System.Runtime.Serialization.ISerializable> interface is intended for use only by the serialization infrastructure. However, if unprotected, it can potentially release sensitive information. If you provide custom serialization by implementing **ISerializable**, make sure you take the following precautions:  
  
-   The <xref:System.Runtime.Serialization.ISerializable.GetObjectData%2A> method should be explicitly secured either by demanding the **SecurityPermission** with **SerializationFormatter** permission specified or by making sure that no sensitive information is released with the method output. For example:  
  
    ```vb  
    Public Overrides<SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter := True)>  _  
    Sub GetObjectData(info As SerializationInfo, context As StreamingContext)  
    End Sub  
    ```  
  
    ```csharp  
    [SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter   
    =true)]  
    public override void GetObjectData(SerializationInfo info,   
    StreamingContext context)  
    {  
    }  
    ```  
  
-   The special constructor used for serialization should also perform thorough input validation and should be either protected or private to help protect against misuse by malicious code. It should enforce the same security checks and permissions required to obtain an instance of such a class by any other means, such as explicitly creating the class or indirectly creating it through some kind of factory.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
