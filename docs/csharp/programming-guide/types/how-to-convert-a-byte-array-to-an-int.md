---
title: "How to: Convert a byte Array to an int (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "conversions [C#], byte array to int"
  - "byte arrays [C#], converting to int"
ms.assetid: d6ac20e2-448e-4aea-99b9-faf04c6f1e79
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Convert a byte Array to an int (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This example shows you how to use the <xref:System.BitConverter> class to convert an array of bytes to an [int](../../../csharp/language-reference/keywords/int.md) and back to an array of bytes. You may have to convert from bytes to a built-in data type after you read bytes off the network, for example. In addition to the [ToInt32(Byte\<xref:System.BitConverter.ToInt32%28System.Byte%5B%5D%2CSystem.Int32%29> method in the example, the following table lists methods in the <xref:System.BitConverter> class that convert bytes (from an array of bytes) to other built-in types.  
  
|Type returned|Method|  
|-------------------|------------|  
|`bool`|[ToBoolean(Byte\<xref:System.BitConverter.ToBoolean%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`char`|[ToChar(Byte\<xref:System.BitConverter.ToChar%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`double`|[ToDouble(Byte\<xref:System.BitConverter.ToDouble%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`short`|[ToInt16(Byte\<xref:System.BitConverter.ToInt16%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`int`|[ToInt32(Byte\<xref:System.BitConverter.ToInt32%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`long`|[ToInt64(Byte\<xref:System.BitConverter.ToInt64%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`float`|[ToSingle(Byte\<xref:System.BitConverter.ToSingle%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`ushort`|[ToUInt16(Byte\<xref:System.BitConverter.ToUInt16%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`uint`|[ToUInt32(Byte\<xref:System.BitConverter.ToUInt32%28System.Byte%5B%5D%2CSystem.Int32%29>|  
|`ulong`|[ToUInt64(Byte\<xref:System.BitConverter.ToUInt64%28System.Byte%5B%5D%2CSystem.Int32%29>|  
  
## Example  
 This example initializes an array of bytes, reverses the array if the computer architecture is little-endian (that is, the least significant byte is stored first), and then calls the [ToInt32(Byte\<xref:System.BitConverter.ToInt32%28System.Byte%5B%5D%2CSystem.Int32%29> method to convert four bytes in the array to an `int`. The second argument to [ToInt32(Byte\<xref:System.BitConverter.ToInt32%28System.Byte%5B%5D%2CSystem.Int32%29> specifies the start index of the array of bytes.  
  
> [!NOTE]
>  The output may differ depending on the endianess of your computer's architecture.  
  
 [!code-csharp[csProgGuideTypes#22](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#22)]  
  
## Example  
 In this example, the <xref:System.BitConverter.GetBytes%28System.Int32%29> method of the <xref:System.BitConverter> class is called to convert an `int` to an array of bytes.  
  
> [!NOTE]
>  The output may differ depending on the endianess of your computer's architecture.  
  
 [!code-csharp[csProgGuideTypes#23](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#23)]  
  
## See Also  
 <xref:System.BitConverter>   
 <xref:System.BitConverter.IsLittleEndian>   
 [Types](../../../csharp/programming-guide/types/index.md)