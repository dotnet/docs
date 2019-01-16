---
title: "IXCLRDataProcess Interface"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataProcess"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess Interface"
helpviewer.keywords:
  - "IXCLRDataProcess Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess Interface
Provide methods for querying information about a process.

## Methods
|Method                           |Description                                                         |
|---------------------------------|--------------------------------------------------------------------|
|GetAppDomainByUniqueId           |Get the AppDomain by its unique id.                                 |
|StartEnumModules                 |Start enumerate modules of this process.                            |
|EnumModule                       |Enumerate modules of this process.                                  |
|EndEnumModules                   |End enumerate modules of this process.                              |
|StartEnumMethodInstancesByAddress|Start enumerate method instances of this process by an address.     |
|EnumMethodInstanceByAddress      |Enumerate method instances of this process by an address.           |
|EndEnumMethodInstancesByAddress  |End enumerate method instances of this process by an address.       |
