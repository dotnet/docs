---
title: "Marshaling Data with Platform Invoke"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "cpp"
helpviewer_keywords: 
  - "platform invoke, marshaling data"
  - "data marshaling, platform invoke"
  - "marshaling, platform invoke"
ms.assetid: dc5c76cf-7b12-406f-b79c-d1a023ec245d
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Marshaling Data with Platform Invoke
To call functions exported from an unmanaged library, a .NET Framework application requires a function prototype in managed code that represents the unmanaged function. To create a prototype that enables platform invoke to marshal data correctly, you must do the following:  
  
-   Apply the <xref:System.Runtime.InteropServices.DllImportAttribute> attribute to the static function or method in managed code.  
  
-   Substitute managed data types for unmanaged data types.  
  
 You can use the documentation supplied with an unmanaged function to construct an equivalent managed prototype by applying the attribute with its optional fields and substituting managed data types for unmanaged types. For instructions about how to apply the **DllImportAttribute**, see [Consuming Unmanaged DLL Functions](../../../docs/framework/interop/consuming-unmanaged-dll-functions.md).  
  
 This section provides samples that demonstrate how to create managed function prototypes for passing arguments to and receiving return values from functions exported by unmanaged libraries. The samples also demonstrate when to use the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute and the <xref:System.Runtime.InteropServices.Marshal> class to explicitly marshal data.  
  
## Platform invoke data types  
 The following table lists data types used in the Win32 API (listed in Wtypes.h) and C-style functions. Many unmanaged libraries contain functions that pass these data types as parameters and return values. The third column lists the corresponding .NET Framework built-in value type or class that you use in managed code. In some cases, you can substitute a type of the same size for the type listed in the table.  
  
|Unmanaged type in Wtypes.h|Unmanaged C language type|Managed class name|Description|  
|--------------------------------|-------------------------------|------------------------|-----------------|  
|**HANDLE**|**void\***|<xref:System.IntPtr?displayProperty=nameWithType>|32 bits on 32-bit Windows operating systems, 64 bits on 64-bit Windows operating systems.|  
|**BYTE**|**unsigned char**|<xref:System.Byte?displayProperty=nameWithType>|8 bits|  
|**SHORT**|**short**|<xref:System.Int16?displayProperty=nameWithType>|16 bits|  
|**WORD**|**unsigned short**|<xref:System.UInt16?displayProperty=nameWithType>|16 bits|  
|**INT**|**int**|<xref:System.Int32?displayProperty=nameWithType>|32 bits|  
|**UINT**|**unsigned int**|<xref:System.UInt32?displayProperty=nameWithType>|32 bits|  
|**LONG**|**long**|<xref:System.Int32?displayProperty=nameWithType>|32 bits|  
|**BOOL**|**long**|<xref:System.Byte>|32 bits|  
|**DWORD**|**unsigned long**|<xref:System.UInt32?displayProperty=nameWithType>|32 bits|  
|**ULONG**|**unsigned long**|<xref:System.UInt32?displayProperty=nameWithType>|32 bits|  
|**CHAR**|**char**|<xref:System.Char?displayProperty=nameWithType>|Decorate with ANSI.|  
|**WCHAR**|**wchar_t**|<xref:System.Char?displayProperty=nameWithType>|Decorate with Unicode.|  
|**LPSTR**|**char\***|<xref:System.String?displayProperty=nameWithType> or <xref:System.Text.StringBuilder?displayProperty=nameWithType>|Decorate with ANSI.|  
|**LPCSTR**|**Const char\***|<xref:System.String?displayProperty=nameWithType> or <xref:System.Text.StringBuilder?displayProperty=nameWithType>|Decorate with ANSI.|  
|**LPWSTR**|**wchar_t\***|<xref:System.String?displayProperty=nameWithType> or <xref:System.Text.StringBuilder?displayProperty=nameWithType>|Decorate with Unicode.|  
|**LPCWSTR**|**Const wchar_t\***|<xref:System.String?displayProperty=nameWithType> or <xref:System.Text.StringBuilder?displayProperty=nameWithType>|Decorate with Unicode.|  
|**FLOAT**|**Float**|<xref:System.Single?displayProperty=nameWithType>|32 bits|  
|**DOUBLE**|**Double**|<xref:System.Double?displayProperty=nameWithType>|64 bits|  
  
 For corresponding types in [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)], C#, and C++, see the [Introduction to the .NET Framework Class Library](../../../docs/standard/class-library-overview.md).  
  
## PinvokeLib.dll  
 The following code defines the library functions provided by Pinvoke.dll. Many samples described in this section call this library.  
  
### Example  
 [!code-cpp[PInvokeLib#1](../../../samples/snippets/cpp/VS_Snippets_CLR/pinvokelib/cpp/pinvokelib.cpp#1)]  
  
 [!code-cpp[PInvokeLib#2](../../../samples/snippets/cpp/VS_Snippets_CLR/pinvokelib/cpp/pinvokelib.h#2)]
