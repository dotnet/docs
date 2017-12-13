---
title: "User-Defined Data Type"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "UserDefined"
  - "UDT"
  - "vb.UDT"
  - "User-Defined"
  - "vb.UserDefined"
  - "vb.User-Defined"
helpviewer_keywords: 
  - "user-defined data types [Visual Basic], Visual Basic"
  - "user-defined types"
  - "structures [Visual Basic], as user-defined data types"
  - "user-defined types [Visual Basic], Visual Basic"
  - "user-defined types [Visual Basic], structure declaration"
  - "user-defined types [Visual Basic], structures in Visual Basic"
  - "user-defined data types [Visual Basic], structure declaration"
  - "data types [Visual Basic], assigning"
  - "Structure statement [Visual Basic]"
  - "data types [Visual Basic], user-defined"
  - "user-defined data types [Visual Basic], structures in Visual Basic"
  - "user-defined data types"
  - "types [Visual Basic], user-defined"
ms.assetid: be913dca-a364-4a51-96a1-549a1b390b0a
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# User-Defined Data Type
Holds data in a format you define. The `Structure` statement defines the format.  
  
 Previous versions of Visual Basic support the user-defined type (UDT). The current version expands the UDT to a *structure*. A structure is a concatenation of one or more *members* of various data types. Visual Basic treats a structure as a single unit, although you can also access its members individually.  
  
## Remarks  
 Define and use a structure data type when you need to combine various data types into a single unit, or when none of the elementary data types serve your needs.  
  
 The default value of a structure data type consists of the combination of the default values of each of its members.  
  
## Declaration Format  
 A structure declaration starts with the [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md) and ends with the `End``Structure` statement. The `Structure` statement supplies the name of the structure, which is also the identifier of the data type the structure is defining. Other parts of the code can use this identifier to declare variables, parameters, and function return values to be of this structure's data type.  
  
 The declarations between the `Structure` and `End``Structure` statements define the members of the structure.  
  
## Member Access Levels  
 You must declare every member using a [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md) or a statement that specifies access level, such as [Public](../../../visual-basic/language-reference/modifiers/public.md), [Friend](../../../visual-basic/language-reference/modifiers/friend.md), or [Private](../../../visual-basic/language-reference/modifiers/private.md). If you use a `Dim` statement, the access level defaults to public.  
  
## Programming Tips  
  
-   **Memory Consumption.** As with all composite data types, you cannot safely calculate the total memory consumption of a structure by adding together the nominal storage allocations of its members. Furthermore, you cannot safely assume that the order of storage in memory is the same as your order of declaration. If you need to control the storage layout of a structure, you can apply the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute to the `Structure` statement.  
  
-   **Interop Considerations.** If you are interfacing with components not written for the .NET Framework, for example Automation or COM objects, keep in mind that user-defined types in other environments are not compatible with Visual Basic structure types.  
  
-   **Widening.** There is no automatic conversion to or from any structure data type. You can define conversion operators on your structure using the [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md), and you can declare each conversion operator to be `Widening` or `Narrowing`.  
  
-   **Type Characters.** Structure data types have no literal type character or identifier type character.  
  
-   **Framework Type.** There is no corresponding type in the .NET Framework. All structures inherit from the .NET Framework class <xref:System.ValueType?displayProperty=nameWithType>, but no individual structure corresponds to <xref:System.ValueType?displayProperty=nameWithType>.  
  
## Example  
 The following paradigm shows the outline of the declaration of a structure.  
  
```  
[Public | Protected | Friend | Protected Friend | Private] Structure structname  
    {Dim | Public | Friend | Private} member1 As datatype1  
    ' ...  
    {Dim | Public | Friend | Private} memberN As datatypeN  
End Structure  
```  
  
## See Also  
 <xref:System.ValueType>  
 <xref:System.Runtime.InteropServices.StructLayoutAttribute>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)  
 [Widening](../../../visual-basic/language-reference/modifiers/widening.md)  
 [Narrowing](../../../visual-basic/language-reference/modifiers/narrowing.md)  
 [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
