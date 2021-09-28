---
description: "Learn more about: ISymUnmanagedENCUpdate Interface"
title: "ISymUnmanagedENCUpdate Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedENCUpdate"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate"
helpviewer_keywords: 
  - "ISymUnmanagedENCUpdate interface [.NET Framework debugging]"
ms.assetid: 63a9ef45-01a6-46da-b958-5c6dc2dc232c
topic_type: 
  - "apiref"
---
# ISymUnmanagedENCUpdate Interface

Provides functions for the Edit and Continue feature.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetLocalVariableCount Method](isymunmanagedencupdate-getlocalvariablecount-method.md)|Gets the number of local variables.|  
|[GetLocalVariables Method](isymunmanagedencupdate-getlocalvariables-method.md)|Gets the local variables.|  
|[InitializeForEnc Method](isymunmanagedencupdate-initializeforenc-method.md)|Allows method boundaries to be computed before the first call to the [ISymUnmanagedENCUpdate::UpdateSymbolStore2](isymunmanagedencupdate-updatesymbolstore2-method.md) method.|  
|[UpdateMethodLines Method](isymunmanagedencupdate-updatemethodlines-method.md)|Allows updating the line information for a method that has not been recompiled, but whose lines have moved independently. A delta for each statement is allowed.|  
|[UpdateSymbolStore2 Method](isymunmanagedencupdate-updatesymbolstore2-method.md)|Allows a compiler to omit functions that have not been modified from the program database (PDB) stream, provided that the line information meets the requirements. The correct line information can be determined with the old PDB line information and one delta for all lines in the function.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
