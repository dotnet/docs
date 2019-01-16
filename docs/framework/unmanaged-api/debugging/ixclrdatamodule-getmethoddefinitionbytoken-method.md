---
title: "IXCLRDataModule::GetMethodDefinitionByToken Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataModule::GetMethodDefinitionByToken"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::GetMethodDefinitionByToken Method"
helpviewer.keywords:
  - "IXCLRDataModule::GetMethodDefinitionByToken Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataModule::GetMethodDefinitionByToken Method
Get a method definition by metadata token.

## Syntax
```
HRESULT GetMethodDefinitionByToken(
    [in] mdMethodDef token,
    [out] IXCLRDataMethodDefinition** methodDefinition
);
```

### Parameters
`token`
[in] The method token.

`methodDefinition`
[out] The method definition.
