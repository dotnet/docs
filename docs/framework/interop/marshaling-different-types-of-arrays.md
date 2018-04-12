---
title: "Marshaling Different Types of Arrays"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "marshaling, Arrays sample"
  - "data marshaling, Arrays sample"
ms.assetid: c5ac9920-5b6e-4dc9-bf2d-1f6f8ad3b0bf
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Marshaling Different Types of Arrays
An array is a reference type in managed code that contains one or more elements of the same type. Although arrays are reference types, they are passed as In parameters to unmanaged functions. This behavior is inconsistent with way managed arrays are passed to managed objects, which is as In/Out parameters. For additional details, see [Copying and Pinning](copying-and-pinning.md).  
  
 The following table lists marshaling options for arrays and describes their usage.  
  
|Array|Description|  
|-----------|-----------------|  
|Of integers by value.|Passes an array of integers as an In parameter.|  
|Of integers by reference.|Passes an array of integers as an In/Out parameter.|  
|Of integers by value (two-dimensional).|Passes a matrix of integers as an In parameter.|  
|Of strings by value.|Passes an array of strings as an In parameter.|  
|Of structures with integers.|Passes an array of structures that contain integers as an In parameter.|  
|Of structures with strings.|Passes an array of structures that contain only integers as an In/Out parameter. Members of the array can be changed.|  
  
## Example  
 This sample demonstrates how to pass the following types of arrays:  
  
-   Array of integers by value.  
  
-   Array of integers by reference, which can be resized.  
  
-   Multidimensional array (matrix) of integers by value.  
  
-   Array of strings by value.  
  
-   Array of structures with integers.  
  
-   Array of structures with strings.  
  
 Unless an array is explicitly marshaled by reference, the default behavior marshals the array as an In parameter. You can change this behavior by applying the <xref:System.Runtime.InteropServices.InAttribute> and <xref:System.Runtime.InteropServices.OutAttribute> attributes explicitly.  
  
 The Arrays sample uses the following unmanaged functions, shown with their original function declaration:  
  
-   **TestArrayOfInts** exported from PinvokeLib.dll.  
  
    ```  
    int TestArrayOfInts(int* pArray, int pSize);  
    ```  
  
-   **TestRefArrayOfInts** exported from PinvokeLib.dll.  
  
    ```  
    int TestRefArrayOfInts(int** ppArray, int* pSize);  
    ```  
  
-   **TestMatrixOfInts** exported from PinvokeLib.dll.  
  
    ```  
    int TestMatrixOfInts(int pMatrix[][COL_DIM], int row);  
    ```  
  
-   **TestArrayOfStrings** exported from PinvokeLib.dll.  
  
    ```  
    int TestArrayOfStrings(char** ppStrArray, int size);  
    ```  
  
-   **TestArrayOfStructs** exported from PinvokeLib.dll.  
  
    ```  
    int TestArrayOfStructs(MYPOINT* pPointArray, int size);  
    ```  
  
-   **TestArrayOfStructs2** exported from PinvokeLib.dll.  
  
    ```  
    int TestArrayOfStructs2 (MYPERSON* pPersonArray, int size);  
    ```  
  
 [PinvokeLib.dll](https://msdn.microsoft.com/library/5d1438d7-9946-489d-8ede-6c694a08f614(v=vs.100)) is a custom unmanaged library that contains implementations for the previously listed functions and two structure variables, **MYPOINT** and **MYPERSON**. The structures contain the following elements:  
  
```  
typedef struct _MYPOINT  
{  
   int x;   
   int y;   
} MYPOINT;  
  
typedef struct _MYPERSON  
{  
   char* first;   
   char* last;   
} MYPERSON;  
```  
  
 In this sample, the `MyPoint` and `MyPerson` structures contain embedded types. The <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute is set to ensure that the members are arranged in memory sequentially, in the order in which they appear.  
  
 The `LibWrap` class contains a set of methods called by the `App` class. For specific details about passing arrays, see the comments in the following sample. An array, which is a reference type, is passed as an In parameter by default. For the caller to receive the results, **InAttribute** and **OutAttribute** must be applied explicitly to the argument containing the array.  
  
### Declaring Prototypes  
 [!code-csharp[Conceptual.Interop.Marshaling#31](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/arrays.cs#31)]
 [!code-vb[Conceptual.Interop.Marshaling#31](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/arrays.vb#31)]  
  
### Calling Functions  
 [!code-csharp[Conceptual.Interop.Marshaling#32](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/arrays.cs#32)]
 [!code-vb[Conceptual.Interop.Marshaling#32](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/arrays.vb#32)]  
  
## See Also  
 [Marshaling Arrays of Types](https://msdn.microsoft.com/library/049b1c1b-228f-4445-88ec-91bc7fd4b1e8(v=vs.100))  
 [Platform Invoke Data Types](https://msdn.microsoft.com/library/16014d9f-d6bd-481e-83f0-df11377c550f(v=vs.100))  
 [Creating Prototypes in Managed Code](creating-prototypes-in-managed-code.md)
