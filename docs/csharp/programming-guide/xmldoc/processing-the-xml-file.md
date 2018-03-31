---
title: "Processing the XML File (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "XML processing [C#]"
  - "XML [C#], processing"
ms.assetid: 60c71193-9dac-4cd3-98c5-100bd0edcc42
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# Processing the XML File (C# Programming Guide)
The compiler generates an ID string for each construct in your code that is tagged to generate documentation. (For information about how to tag your code, see [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md).) The ID string uniquely identifies the construct. Programs that process the XML file can use the ID string to identify the corresponding .NET Framework metadata/reflection item that the documentation applies to.  
  
 The XML file is not a hierarchical representation of your code; it is a flat list that has a generated ID for each element.  
  
 The compiler observes the following rules when it generates the ID strings:  
  
-   No white space is in the string.  
  
-   The first part of the ID string identifies the kind of member being identified, by way of a single character followed by a colon. The following member types are used:  
  
    |Character|Description|  
    |---------------|-----------------|  
    |N|namespace<br /><br /> You cannot add documentation comments to a namespace, but you can make cref references to them, where supported.|  
    |T|type: class, interface, struct, enum, delegate|  
    |F|field|  
    |P|property (including indexers or other indexed properties)|  
    |M|method (including such special methods as constructors, operators, and so forth)|  
    |E|event|  
    |!|error string<br /><br /> The rest of the string provides information about the error. The C# compiler generates error information for links that cannot be resolved.|  
  
-   The second part of the string is the fully qualified name of the item, starting at the root of the namespace. The name of the item, its enclosing type(s), and namespace are separated by periods. If the name of the item itself has periods, they are replaced by the hash-sign ('#'). It is assumed that no item has a hash-sign directly in its name. For example, the fully qualified name of the String constructor would be "System.String.#ctor".  
  
-   For properties and methods, if there are arguments to the method, the argument list enclosed in parentheses follows. If there are no arguments, no parentheses are present. The arguments are separated by commas. The encoding of each argument follows directly how it is encoded in a .NET Framework signature:  
  
    -   Base types. Regular types (ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE) are represented as the fully qualified name of the type.  
  
    -   Intrinsic types (for example, ELEMENT_TYPE_I4, ELEMENT_TYPE_OBJECT, ELEMENT_TYPE_STRING, ELEMENT_TYPE_TYPEDBYREF. and ELEMENT_TYPE_VOID) are represented as the fully qualified name of the corresponding full type. For example, System.Int32 or System.TypedReference.  
  
    -   ELEMENT_TYPE_PTR is represented as a '*' following the modified type.  
  
    -   ELEMENT_TYPE_BYREF is represented as a '@' following the modified type.  
  
    -   ELEMENT_TYPE_PINNED is represented as a '^' following the modified type. The C# compiler never generates this.  
  
    -   ELEMENT_TYPE_CMOD_REQ is represented as a '&#124;' and the fully qualified name of the modifier class, following the modified type. The C# compiler never generates this.  
  
    -   ELEMENT_TYPE_CMOD_OPT is represented as a '!' and the fully qualified name of the modifier class, following the modified type.  
  
    -   ELEMENT_TYPE_SZARRAY is represented as "[]" following the element type of the array.  
  
    -   ELEMENT_TYPE_GENERICARRAY is represented as "[?]" following the element type of the array. The C# compiler never generates this.  
  
    -   ELEMENT_TYPE_ARRAY is represented as [*lowerbound*:`size`,*lowerbound*:`size`] where the number of commas is the rank - 1, and the lower bounds and size of each dimension, if known, are represented in decimal. If a lower bound or size is not specified, it is simply omitted. If the lower bound and size for a particular dimension are omitted, the ':' is omitted as well. For example, a 2-dimensional array with 1 as the lower bounds and unspecified sizes is [1:,1:].  
  
    -   ELEMENT_TYPE_FNPTR is represented as "=FUNC:`type`(*signature*)", where `type` is the return type, and *signature* is the arguments of the method. If there are no arguments, the parentheses are omitted. The C# compiler never generates this.  
  
     The following signature components are not represented because they are never used for differentiating overloaded methods:  
  
    -   calling convention  
  
    -   return type  
  
    -   ELEMENT_TYPE_SENTINEL  
  
-   For conversion operators only (op_Implicit and op_Explicit), the return value of the method is encoded as a '~' followed by the return type, as encoded above.  
  
-   For generic types, the name of the type will be followed by a back tick and then a number that indicates the number of generic type parameters.  For example,  
  
     `<member name="T:SampleClass`2">` is the tag for a type that is defined as `public class SampleClass\<T, U>`.  
  
     For methods taking generic types as parameters, the generic type parameters are specified as numbers prefaced with back ticks (for example \`0,`1).  Each number representing a zero-based array notation for the type's generic parameters.  
  
## Examples  
 The following examples show how the ID strings for a class and its members would be generated:  
  
 [!code-csharp[csProgGuidePointers#21](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/processing-the-xml-file_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [/doc (C# Compiler Options)](../../../csharp/language-reference/compiler-options/doc-compiler-option.md)  
 [XML Documentation Comments](../../../csharp/programming-guide/xmldoc/xml-documentation-comments.md)
