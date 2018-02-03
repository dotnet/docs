---
title: "Tlbexp Helper Functions (Unmanaged API Reference)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "exporter tool [.NET Framework]"
  - "TlbRef.dll"
  - "Tlbexp.exe"
  - "Type Library Exporter"
ms.assetid: 5c0a3d14-5f26-4267-94a9-82c30f8db09a
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tlbexp Helper Functions (Unmanaged API Reference)
The [Type Library Exporter tool](../../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md) (Tlbexp.exe) loads a dynamic link library named TlbRef.dll. This DLL contains two helper functions and an interface that the exporter tool uses during the assembly-to-type-library conversion process.  
  
## In This Section  
 [GetTypeLibInfo Function](../../../../docs/framework/unmanaged-api/tlbexp/gettypelibinfo-function.md)  
 Provides localization and operating system information for a type library.  
  
 [LoadTypeLibWithResolver Function](../../../../docs/framework/unmanaged-api/tlbexp/loadtypelibwithresolver-function.md)  
 Loads a type library by using an implementation of the [ITypeLibResolver interface](../../../../docs/framework/unmanaged-api/tlbexp/itypelibresolver-interface.md) to resolve any referenced type libraries.  
  
 [ITypeLibResolver Interface](../../../../docs/framework/unmanaged-api/tlbexp/itypelibresolver-interface.md)  
 Provides the [ResolveTypeLib method](../../../../docs/framework/unmanaged-api/tlbexp/resolvetypelib-method.md), which returns the fully qualified path of a type library.
