---
description: "Learn more about: ISymUnmanagedConstant::GetSignature Method"
title: "ISymUnmanagedConstant::GetSignature Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedConstant.GetSignature"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedConstant::GetSignature"
helpviewer_keywords: 
  - "GetSignature method, ISymUnmanagedConstant interface [.NET Framework debugging]"
  - "ISymUnmanagedConstant::GetSignature method [.NET Framework debugging]"
ms.assetid: 3eb41151-a228-43e3-ba8f-e6dd3ceb8542
topic_type: 
  - "apiref"
---
# ISymUnmanagedConstant::GetSignature Method

Gets the signature of the constant.  
  
## Syntax  
  
```cpp  
HRESULT GetSignature(  
    [in]  ULONG32  cSig,  
    [out] ULONG32  *pcSig,  
    [out, size_is(cSig),  
        length_is(*pcSig)] BYTE sig[]);  
```  
  
## Parameters  

 `cSig`  
 [in] The length of the buffer that the `pcSig` parameter points to.  
  
 `pcSig`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the signature.  
  
 `sig`  
 [out] The buffer that stores the signature.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedConstant Interface](isymunmanagedconstant-interface.md)
- [GetName Method](isymunmanagedconstant-getname-method.md)
- [GetValue Method](isymunmanagedconstant-getvalue-method.md)
