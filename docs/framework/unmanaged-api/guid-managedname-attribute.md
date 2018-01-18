---
title: "GUID_ManagedName Attribute"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "GUID_ManagedName"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GUID_ManagedName"
helpviewer_keywords: 
  - "GUID_ManagedName attribute"
ms.assetid: 11e18095-e444-47bc-aff6-b887ac5dc01e
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GUID_ManagedName Attribute
Defines a custom interface attribute that specifies the managed namespace name for a component object model (COM) library.  
  
## Syntax  
  
```  
[  
   custom(GUID_ManagedName, value)  
]  
```  
  
#### Parameters  
 `value`  
 The managed namespace name for the library.  
  
## Definition  
 `GUID_ManagedName` is defined in Cor.h as follows:  
  
```  
// {0F21F359-AB84-41e8-9A78-36D110E6D2F9}  
EXTERN_GUID(GUID_ManagedName, 0xf21f359, 0xab84, 0x41e8, 0x9a, 0x78, 0x36, 0xd1, 0x10, 0xe6, 0xd2, 0xf9);  
```  
  
## Remarks  
 A custom interface attribute defines metadata for an object in the type library.  
  
 Use <xref:System.Runtime.InteropServices.ComTypes.ITypeInfo2.GetCustData%2A?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.ComTypes.ITypeLib2.GetCustData%2A?displayProperty=nameWithType> to retrieve the managed name from the attribute.  
  
 For more information, see [Interface Attributes](/cpp/windows/interface-attributes) in the Visual C++ reference documentation.  
  
## Example  
 The following example shows a library definition using the `GUID_ManagedName` attribute.  
  
```  
[  
   ...  
   custom(GUID_ManagedName, Microsoft.VisualStudio.CommandBars.dll")  
]  
library Microsoft_VisualStudio_CommandBars  
{  
   ...  
}  
```  
  
## Requirements  
 **Header:** Cor.h
