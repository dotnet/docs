---
description: "Learn more about: ValidatorFlags Enumeration"
title: "ValidatorFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "ValidatorFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ValidatorFlags"
helpviewer_keywords: 
  - "ValidatorFlags enumeration [.NET Framework hosting]"
ms.assetid: a3f5c266-3fcc-4ad1-aaf5-4cdbe26304ad
topic_type: 
  - "apiref"
---
# ValidatorFlags Enumeration

Contains values that indicate the type of validation that should be performed in a call to the [ICLRValidator::Validate](iclrvalidator-validate-method.md) method.  
  
## Syntax  
  
```cpp  
enum ValidatorFlags {  
    VALIDATOR_EXTRA_VERBOSE =       0x00000001,  
    VALIDATOR_SHOW_SOURCE_LINES =   0x00000002,  
    VALIDATOR_CHECK_ILONLY =        0x00000004,  
    VALIDATOR_CHECK_PEFORMAT_ONLY = 0x00000008,  
    VALIDATOR_NOCHECK_PEFORMAT =    0x00000010,  
};  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`VALIDATOR_CHECK_ILONLY`|Specifies that only the Microsoft intermediate language (MSIL) in the executable file should be validated.|  
|`VALIDATOR_CHECK_PEFORMAT_ONLY`|Specifies that only the format of the executable file should be validated.|  
|`VALIDATOR_EXTRA_VERBOSE`|Specifies that all types of validation should be performed and reported on.|  
|`VALIDATOR_NOCHECK_PEFORMAT`|Specifies that the format of the executable file should not be validated.|  
|`VALIDATOR_SHOW_SOURCE_LINES`|Specifies that validation error messages should include the lines of source code that raise validation errors. This field value is not valid in the .NET Framework version 2.0.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** IValidator.idl, IValidator.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRErrorReportingManager Interface](iclrerrorreportingmanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
