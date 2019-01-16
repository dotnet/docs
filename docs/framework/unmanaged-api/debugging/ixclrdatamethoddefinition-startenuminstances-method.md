---
title: "IXCLRDataMethodDefinition::StartEnumInstances Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataMethodDefinition::StartEnumInstances"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition::StartEnumInstances Method"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition::StartEnumInstances Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodDefinition::StartEnumInstances Method
Start enumerate instances of this definition.

## Syntax
```
HRESULT StartEnumInstances(
    [in] IXCLRDataAppDomain* appDomain,
    [out] CLRDATA_ENUM *handle
);
```

### Parameters
`appDomain`
[in] An AppDomain for the enumeration.

`handle`
[out] A handle for enumerating the instances.
