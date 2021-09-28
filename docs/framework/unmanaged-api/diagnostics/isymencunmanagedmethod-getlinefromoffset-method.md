---
description: "Learn more about: ISymENCUnmanagedMethod::GetLineFromOffset Method"
title: "ISymENCUnmanagedMethod::GetLineFromOffset Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymENCUnmanagedMethod.GetLineFromOffset"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymENCUnmanagedMethod::GetLineFromOffset"
helpviewer_keywords: 
  - "GetLineFromOffset method [.NET Framework debugging]"
  - "ISymENCUnmanagedMethod::GetLineFromOffset method [.NET Framework debugging]"
ms.assetid: cc09bad2-fb34-4d13-a521-6ec7b1a1d915
topic_type: 
  - "apiref"
---
# ISymENCUnmanagedMethod::GetLineFromOffset Method

Gets the line information associated with an offset. If the offset parameter (`dwOffset`) is not a sequence point, this method gets the line information associated with the previous offset.  
  
## Syntax  
  
```cpp  
HRESULT GetLineFromOffset(  
     [in]  ULONG32   dwOffset,  
     [out] ULONG32*  pline,  
     [out] ULONG32*  pcolumn,  
     [out] ULONG32*  pendLine,  
     [out] ULONG32*  pendColumn,  
     [out] ULONG32*  pdwStartOffset);  
```  
  
## Parameters  

 `dwOffset`  
 [in] A `ULONG32` that contains the offset.  
  
 `pline`  
 [out] A pointer to a `ULONG32` that receives the line.  
  
 `pcolumn`  
 [out] A pointer to a `ULONG32` that receives the column.  
  
 `pendLine`  
 [out] A pointer to a `ULONG32` that receives the end line.  
  
 `pendColumn`  
 [out] A pointer to a `ULONG32` that receives the end column.  
  
 `pdwStartOffset`  
 [out] A pointer to a `ULONG32` that receives the associated sequence point.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymENCUnmanagedMethod Interface](isymencunmanagedmethod-interface.md)
