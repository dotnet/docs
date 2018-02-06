---
title: "Enum Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Enum"
helpviewer_keywords: 
  - "enumerated constants [Visual Basic]"
  - "Enum statement [Visual Basic]"
  - "Private keyword [Visual Basic], Enum statements"
  - "Public keyword [Visual Basic], in Enum statement"
  - "variables [Visual Basic], enumeration"
  - "constants [Visual Basic], enumerated"
ms.assetid: a45e51f1-65ff-48e1-bf32-79130f137377
caps.latest.revision: 44
author: dotnet-bot
ms.author: dotnetcontent
---
# Enum Statement (Visual Basic)
Declares an enumeration and defines the values of its members.  
  
## Syntax  
  
```  
[ <attributelist> ] [ accessmodifier ]  [ Shadows ]   
Enum enumerationname [ As datatype ]   
   memberlist  
End Enum  
```  
  
## Parts  
  
-   `attributelist`  
  
     Optional. List of attributes that apply to this enumeration. You must enclose the [attribute list](../../../visual-basic/language-reference/statements/attribute-list.md) in angle brackets ("`<`" and "`>`").  
  
     The <xref:System.FlagsAttribute> attribute indicates that the value of an instance of the enumeration can include multiple enumeration members, and that each member represents a bit field in the enumeration value.  
  
-   `accessmodifier`  
  
     Optional. Specifies what code can access this enumeration. Can be one of the following:  
  
    -   [Public](../../../visual-basic/language-reference/modifiers/public.md)  
  
    -   [Protected](../../../visual-basic/language-reference/modifiers/protected.md)  
  
    -   [Friend](../../../visual-basic/language-reference/modifiers/friend.md)  
  
    -   [Private](../../../visual-basic/language-reference/modifiers/private.md)  
  
     You can specify `Protected``Friend` to allow access from code within the enumeration's class, a derived class, or the same assembly.  
  
-   `Shadows`  
  
     Optional. Specifies that this enumeration redeclares and hides an identically named programming element, or set of overloaded elements, in a base class. You can specify [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md) only on the enumeration itself, not on any of its members.  
  
-   `enumerationname`  
  
     Required. Name of the enumeration. For information on valid names, see [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).  
  
-   `datatype`  
  
     Optional. Data type of the enumeration and all its members.  
  
-   `memberlist`  
  
     Required. List of member constants being declared in this statement. Multiple members appear on individual source code lines.  
  
     Each `member` has the following syntax and parts: `[<attribute list>] member name [ = initializer ]`  
  
    |Part|Description|  
    |---|---|  
    |`membername`|Required. Name of this member.|  
    |`initializer`|Optional. Expression that is evaluated at compile time and assigned to this member.|  
  
-   `End` `Enum`  
  
     Terminates the `Enum` block.  
  
## Remarks  
 If you have a set of unchanging values that are logically related to each other, you can define them together in an enumeration. This provides meaningful names for the enumeration and its members, which are easier to remember than their values. You can then use the enumeration members in many places in your code.  
  
 The benefits of using enumerations include the following:  
  
-   Reduces errors caused by transposing or mistyping numbers.  
  
-   Makes it easy to change values in the future.  
  
-   Makes code easier to read, which means it is less likely that errors will be introduced.  
  
-   Ensures forward compatibility. If you use enumerations, your code is less likely to fail if in the future someone changes the values corresponding to the member names.  
  
 An enumeration has a name, an underlying data type, and a set of members. Each member represents a constant.  
  
 An enumeration declared at class, structure, module, or interface level, outside any procedure, is a *member enumeration*. It is a member of the class, structure, module, or interface that declares it.  
  
 Member enumerations can be accessed from anywhere within their class, structure, module, or interface. Code outside a class, structure, or module must qualify a member enumeration's name with the name of that class, structure, or module. You can avoid the need to use fully qualified names by adding an [Imports](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md) statement to the source file.  
  
 An enumeration declared at namespace level, outside any class, structure, module, or interface, is a member of the namespace in which it appears.  
  
 The *declaration context* for an enumeration must be a source file, namespace, class, structure, module, or interface, and cannot be a procedure. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 You can apply attributes to an enumeration as a whole, but not to its members individually. An attribute contributes information to the assembly's metadata.  
  
## Data Type  
 The `Enum` statement can declare the data type of an enumeration. Each member takes the enumeration's data type. You can specify `Byte`, `Integer`, `Long`, `SByte`, `Short`, `UInteger`, `ULong`, or `UShort`.  
  
 If you do not specify `datatype` for the enumeration, each member takes the data type of its `initializer`. If you specify both `datatype` and `initializer`, the data type of `initializer` must be convertible to `datatype`. If neither `datatype` nor `initializer` is present, the data type defaults to `Integer`.  
  
## Initializing Members  
 The `Enum` statement can initialize the contents of selected members in `memberlist`. You use `initializer` to supply an expression to be assigned to the member.  
  
 If you do not specify `initializer` for a member, Visual Basic initializes it either to zero (if it is the first `member` in `memberlist`), or to a value greater by one than that of the immediately preceding `member`.  
  
 The expression supplied in each `initializer` can be any combination of literals, other constants that are already defined, and enumeration members that are already defined, including a previous member of this enumeration. You can use arithmetic and logical operators to combine such elements.  
  
 You cannot use variables or functions in `initializer`. However, you can use conversion keywords such as `CByte` and `CShort`. You can also use `AscW` if you call it with a constant `String` or `Char` argument, since that can be evaluated at compile time.  
  
 Enumerations cannot have floating-point values. If a member is assigned a floating-point value and `Option Strict` is set to on, a compiler error occurs. If `Option Strict` is off, the value is automatically converted to the `Enum` type.  
  
 If the value of a member exceeds the allowable range for the underlying data type, or if you initialize any member to the maximum value allowed by the underlying data type, the compiler reports an error.  
  
## Modifiers  
 Class, structure, module, and interface member enumerations default to public access. You can adjust their access levels with the access modifiers. Namespace member enumerations default to friend access. You can adjust their access levels to public, but not to private or protected. For more information, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
 All enumeration members have public access, and you cannot use any access modifiers on them. However, if the enumeration itself has a more restricted access level, the specified enumeration access level takes precedence.  
  
 By default, all enumerations are types and their fields are constants. Therefore the `Shared`, `Static`, and `ReadOnly` keywords cannot be used when declaring an enumeration or its members.  
  
## Assigning Multiple Values  
 Enumerations typically represent mutually exclusive values. By including the <xref:System.FlagsAttribute> attribute in the `Enum` declaration, you can instead assign multiple values to an instance of the enumeration. The <xref:System.FlagsAttribute> attribute specifies that the enumeration be treated as a bit field, that is, a set of flags. These are called *bitwise* enumerations.  
  
 When you declare an enumeration by using the <xref:System.FlagsAttribute> attribute, we recommend that you use powers of 2, that is, 1, 2, 4, 8, 16, and so on, for the values. We also recommend that "None" be the name of a member whose value is 0. For additional guidelines, see <xref:System.FlagsAttribute> and <xref:System.Enum>.  
  
## Example  
 The following example shows how to use the `Enum` statement. Note that the member is referred to as `EggSizeEnum.Medium`, and not as `Medium`.  
  
 [!code-vb[VbEnumsTask#41](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enum-statement_1.vb)]  
  
## Example  
 The method in the following example is outside the `Egg` class. Therefore, `EggSizeEnum` is fully qualified as `Egg.EggSizeEnum`.  
  
 [!code-vb[VbEnumsTask#42](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enum-statement_2.vb)]  
  
## Example  
 The following example uses the `Enum` statement to define a related set of named constant values. In this case, the values are colors you might choose to design data entry forms for a database.  
  
 [!code-vb[VbEnumsTask#30](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enum-statement_3.vb)]  
  
## Example  
 The following example shows values that include both positive and negative numbers.  
  
 [!code-vb[VbEnumsTask#31](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enum-statement_4.vb)]  
  
## Example  
 In the following example, an `As` clause is used to specify the `datatype` of an enumeration.  
  
 [!code-vb[VbEnumsTask#6](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enum-statement_5.vb)]  
  
## Example  
 The following example shows how to use a bitwise enumeration. Multiple values can be assigned to an instance of a bitwise enumeration. The `Enum` declaration includes the <xref:System.FlagsAttribute> attribute, which indicates that the enumeration can be treated as a set of flags.  
  
 [!code-vb[VbEnumsTask#61](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enum-statement_6.vb)]  
  
## Example  
 The following example iterates through an enumeration. It uses the <xref:System.Enum.GetNames%2A> method to retrieve an array of member names from the enumeration, and <xref:System.Enum.GetValues%2A> to retrieve an array of member values.  
  
 [!code-vb[VbEnumsTask#51](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enum-statement_7.vb)]  
  
## See Also  
 <xref:System.Enum>  
 <xref:Microsoft.VisualBasic.Strings.AscW%2A>  
 [Const Statement](../../../visual-basic/language-reference/statements/const-statement.md)  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
 [Implicit and Explicit Conversions](../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Constants and Enumerations](../../../visual-basic/language-reference/constants-and-enumerations.md)
