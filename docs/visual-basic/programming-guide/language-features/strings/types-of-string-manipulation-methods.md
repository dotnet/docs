---
title: "Types of String Manipulation Methods"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "strings [Visual Basic], manipulating [Visual Basic]"
  - "string manipulation"
ms.assetid: 905055cd-7f50-48fb-9eed-b0995af1dc1f
---
# Types of String Manipulation Methods in Visual Basic
There are several different ways to analyze and manipulate your strings. Some of the methods are a part of the Visual Basic language, and others are inherent in the `String` class.  
  
## Visual Basic Language and the .NET Framework  
 Visual Basic methods are used as inherent functions of the language. They may be used without qualification in your code. The following example shows typical use of a Visual Basic string-manipulation command:  
  
 [!code-vb[VbVbalrStrings#44](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#44)]  
  
 In this example, the `Mid` function performs a direct operation on `aString` and assigns the value to `bString`.  
  
 For a list of Visual Basic string manipulation methods, see [String Manipulation Summary](../../../../visual-basic/language-reference/keywords/string-manipulation-summary.md).  
  
### Shared Methods and Instance Methods  
 You can also manipulate strings with the methods of the `String` class. There are two types of methods in `String`: *shared* methods and *instance* methods.  
  
#### Shared Methods  
 A shared method is a method that stems from the `String` class itself and does not require an instance of that class to work. These methods can be qualified with the name of the class (`String`) rather than with an instance of the `String` class. For example:  
  
 [!code-vb[VbVbalrStrings#45](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#45)]  
  
 In the preceding example, the <xref:System.String.Copy%2A?displayProperty=nameWithType> method is a static method, which acts upon an expression it is given and assigns the resulting value to `bString`.  
  
#### Instance Methods  
 Instance methods, by contrast, stem from a particular instance of `String` and must be qualified with the instance name. For example:  
  
 [!code-vb[VbVbalrStrings#46](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#46)]  
  
 In this example, the <xref:System.String.Substring%2A?displayProperty=nameWithType> method is a method of the instance of `String` (that is, `aString`). It performs an operation on `aString` and assigns that value to `bString`.  
  
 For more information, see the documentation for the <xref:System.String> class.  
  
## See also

- [Introduction to Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/introduction-to-strings.md)
