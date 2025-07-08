---
description: "Learn more about: ISymUnmanagedMethod Interface"
title: "ISymUnmanagedMethod Interface"
ms.date: "03/30/2017"
api_name:
  - "ISymUnmanagedMethod"
api_location:
  - "diasymreader.dll"
api_type:
  - "COM"
f1_keywords:
  - "ISymUnmanagedMethod"
helpviewer_keywords:
  - "ISymUnmanagedMethod interface [.NET Framework debugging]"
ms.assetid: f204d74c-cc79-4092-83bb-60654be95649
topic_type:
  - "apiref"
---
# ISymUnmanagedMethod Interface

Represents a method within the symbol store. This interface provides access to only the symbol-related attributes of a method, instead of the type-related attributes.

## Methods

|Method|Description|
|------------|-----------------|
|[GetNamespace Method](isymunmanagedmethod-getnamespace-method.md)|Gets the namespace within which this method is defined.|
|[GetOffset Method](isymunmanagedmethod-getoffset-method.md)|Returns the offset within this method that corresponds to a given position within a document.|
|[GetParameters Method](isymunmanagedmethod-getparameters-method.md)|Gets the parameters for this method.|
|[GetRanges Method](isymunmanagedmethod-getranges-method.md)|Given a position in a document, returns an array of start and end offset pairs that correspond to the ranges of common intermediate language (CIL) that the position covers within this method.|
|[GetRootScope Method](isymunmanagedmethod-getrootscope-method.md)|Gets the root lexical scope within this method. This scope encloses the entire method.|
|[GetScopeFromOffset Method](isymunmanagedmethod-getscopefromoffset-method.md)|Gets the most enclosing lexical scope within this method that encloses the given offset.|
|[GetSequencePointCount Method](isymunmanagedmethod-getsequencepointcount-method.md)|Gets the count of sequence points within this method.|
|[GetSequencePoints Method](isymunmanagedmethod-getsequencepoints-method.md)|Gets all the sequence points within this method.|
|[GetSourceStartEnd Method](isymunmanagedmethod-getsourcestartend-method.md)|Gets the start and end document positions for the source of this method.|
|[GetToken Method](isymunmanagedmethod-gettoken-method.md)|Returns the metadata token for this method.|

## Requirements

 **Header:** CorSym.idl, CorSym.h

## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
