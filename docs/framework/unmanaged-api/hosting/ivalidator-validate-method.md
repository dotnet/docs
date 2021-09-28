---
description: "Learn more about: IValidator::Validate Method"
title: "IValidator::Validate Method"
ms.date: "03/30/2017"
api_name: 
  - "IValidator.Validate"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "Validate"
helpviewer_keywords: 
  - "IValidator::Validate method [.NET Framework hosting]"
  - "Validate method, IValidator interface [.NET Framework hosting]"
ms.assetid: 7d68666a-fb73-4455-bebd-908d49a16abc
topic_type: 
  - "apiref"
---
# IValidator::Validate Method

Validates the specified portable executable (PE) or Microsoft intermediate language (MSIL) file.  
  
## Syntax  
  
```cpp  
HRESULT Validate (  
    [in] IVEHandler            *veh,  
    [in] IUnknown              *pAppDomain,  
    [in] unsigned long          ulFlags,  
    [in] unsigned long          ulMaxError,  
    [in] unsigned long          token,  
    [in] LPWSTR                 fileName,  
    [in, size_is(ulSize)] BYTE *pe,  
    [in] unsigned long          ulSize  
);  
```  
  
## Parameters  

 `veh`  
 [in] A pointer to an `IVEHandler` instance that handles validation errors.  
  
 `pAppDomain`  
 [in] A pointer to the application domain in which the file is loaded.  
  
 `ulFlags`  
 [in] A bitwise combination of [ValidatorFlags](validatorflags-enumeration.md) values, indicating the validations that should be performed.  
  
 `ulMaxError`  
 [in] The maximum number of errors to allow before exiting the validation.  
  
 `token`  
 [in] Not used.  
  
 `fileName`  
 [in] A string that specifies the name of the file to be validated.  
  
 `pe`  
 [in] A pointer to the memory buffer in which the file is stored.  
  
 `ulSize`  
 [in] The size, in bytes, of the file to be validated.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** IValidator.idl, IValidator.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
