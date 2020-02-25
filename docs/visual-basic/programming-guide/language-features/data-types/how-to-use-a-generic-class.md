---
title: "How to: Use a Generic Class"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "type parameters [Visual Basic], defining"
  - "data type arguments [Visual Basic], defining"
  - "arguments [Visual Basic], data types"
  - "Of keyword [Visual Basic], using"
  - "generic parameters"
  - "data type parameters"
  - "generics [Visual Basic], about generics"
  - "data types [Visual Basic], as parameters"
  - "data types [Visual Basic], as arguments"
  - "parameters [Visual Basic], type"
  - "types [Visual Basic], generic"
  - "parameters [Visual Basic], generic"
  - "generics [Visual Basic], creating generic types"
  - "data type arguments"
  - "parameters [Visual Basic], data type"
  - "data type parameters [Visual Basic], defining"
  - "type arguments [Visual Basic], defining"
  - "arguments [Visual Basic], type"
ms.assetid: 242dd2a6-86c4-4ce7-83f2-f2661803f752
---
# How to: Use a Generic Class (Visual Basic)
A class that takes *type parameters* is called a *generic class*. If you are using a generic class, you can generate a *constructed class* from it by supplying a *type argument* for each of these parameters. You can then declare a variable of the constructed class type, and you can create an instance of the constructed class and assign it to that variable.  
  
 In addition to classes, you can also define and use generic structures, interfaces, procedures, and delegates.  
  
 The following procedure takes a generic class defined in the .NET Framework and creates an instance from it.  
  
### To use a class that takes a type parameter  
  
1. At the beginning of your source file, include an [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md) to import the <xref:System.Collections.Generic?displayProperty=nameWithType> namespace. This allows you to refer to the <xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType> class without having to fully qualify it to differentiate it from other queue classes such as <xref:System.Collections.Queue?displayProperty=nameWithType>.  
  
2. Create the object in the normal way, but add `(Of type)` immediately after the class name.  
  
     The following example uses the same class (<xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType>) to create two queue objects that hold items of different data types. It adds items to the end of each queue and then removes and displays items from the front of each queue.  
  
     [!code-vb[VbVbalrDataTypes#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb#9)]  
  
## See also

- [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)
- [Generic Types in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)
- [Language Independence and Language-Independent Components](../../../../standard/language-independence-and-language-independent-components.md)
- [Of](../../../../visual-basic/language-reference/statements/of-clause.md)
- [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)
- [How to: Define a Class That Can Provide Identical Functionality on Different Data Types](../../../../visual-basic/programming-guide/language-features/data-types/how-to-define-a-class-that-can-provide-identical-functionality.md)
- [Iterators](../../../../visual-basic/programming-guide/concepts/iterators.md)
