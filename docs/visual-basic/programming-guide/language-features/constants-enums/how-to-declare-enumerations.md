---
description: "Learn more about: How to: Declare Enumerations (Visual Basic)"
title: "How to: Declare Enumerations"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "declarations [Visual Basic], enumerations"
  - "enumerations [Visual Basic], declaring"
  - "declaring enumerations [Visual Basic]"
ms.assetid: db4ca1c3-f429-4c81-ae81-29e0157b29fd
---
# How to: Declare Enumerations (Visual Basic)

You create an enumeration with the `Enum` statement in the declarations section of a class or module. You cannot declare an enumeration within a method. To specify the appropriate level of access, use `Private`, `Protected`, `Friend`, or `Public`.  
  
 An `Enum` type has a name, an underlying type, and a set of fields, each representing a constant. The name must be a valid Visual Basic .NET qualifier. The underlying type must be one of the integer types—`Byte`, `Short`, `Long` or `Integer`. `Integer` is the default. Enumerations are always strongly typed and are not interchangeable with integer number types.  
  
 Enumerations cannot have floating-point values. If an enumeration is assigned a floating-point value with `Option Strict On`, a compiler error results. If `Option Strict` is `Off`, the value is automatically converted to the `Enum` type.  
  
 For information on names, and how to use the `Imports` statement to make name qualification unnecessary, see [Enumerations and Name Qualification](enumerations-and-name-qualification.md).  
  
### To declare an enumeration  
  
1. Write a declaration that includes a code access level, the `Enum` keyword, and a valid name, as in the following examples, each of which declares a different `Enum`.  
  
     [!code-vb[VbEnumsTask#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#3)]  
  
2. Define the constants in the enumeration. By default, the first constant in an enumeration is initialized to `0`, and subsequent constants are initialized to a value of one more than the previous constant. For example, the following enumeration, `Days`, contains a constant named `Sunday` with the value `0`, a constant named `Monday` with the value `1`, a constant named `Tuesday` with the value of `2`, and so on.  
  
     [!code-vb[VbEnumsTask#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#4)]  
  
3. You can explicitly assign values to constants in an enumeration by using an assignment statement. You can assign any integer value, including negative numbers. For example, you may want constants with values less than zero to represent error conditions. In the following enumeration, the constant `Invalid` is explicitly assigned the value `–1`, and the constant `Sunday` is assigned the value `0`. Because it is the first constant in the enumeration, `Saturday` is also initialized to the value `0`. The value of `Monday` is `1` (one more than the value of `Sunday`); the value of `Tuesday` is `2`, and so on.  
  
     [!code-vb[VbEnumsTask#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#5)]  
  
### To declare an enumeration as an explicit type  
  
- Specify the type of the enum by using the `As` clause, as shown in the following example.  
  
     [!code-vb[VbEnumsTask#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#6)]  
  
## See also

- [Enumerations and Name Qualification](enumerations-and-name-qualification.md)
- [How to: Refer to an Enumeration Member](how-to-refer-to-an-enumeration-member.md)
- [How to: Iterate Through An Enumeration in Visual Basic](how-to-iterate-through-an-enumeration.md)
- [How to: Determine the String Associated with an Enumeration Value](how-to-determine-the-string-associated-with-an-enumeration-value.md)
- [When to Use an Enumeration](when-to-use-an-enumeration.md)
- [Constants Overview](constants-overview.md)
- [Constant and Literal Data Types](constant-and-literal-data-types.md)
- [Constants and Enumerations](../../../language-reference/constants-and-enumerations.md)
