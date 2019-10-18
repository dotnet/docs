---
title: "Enumerations and Name Qualification (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "declarations [Visual Basic], enumerations"
  - "Imports statement [Visual Basic], namespace declarations"
  - "declaring namespaces [Visual Basic], enumerations"
  - "name collisions"
  - "ambiguous names [Visual Basic], enumerations"
  - "enumerations [Visual Basic], name qualification"
  - "names [Visual Basic], avoiding conflicts"
  - "namespaces [Visual Basic], declaring"
  - "naming conflicts, enumerations"
  - "naming conflicts, qualifying names"
  - "declaring enumerations"
  - "references [Visual Basic], enumeration members"
  - "naming conventions [Visual Basic], naming conflicts"
  - "declarations [Visual Basic], namespaces"
ms.assetid: 08ba2738-df52-4140-bc55-f57c871c9b73
---
# Enumerations and Name Qualification (Visual Basic)
Normally, when referring to a member of an enumeration, you must qualify the member name with the enumeration name. For example, to refer to the `Sunday` member of your `Days` enumeration, you would use the following syntax:  
  
 [!code-vb[VbEnumsTask#18](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#18)]  
  
## Using the Imports Statement  
 You can avoid using fully qualified names by adding an `Imports` statement to the namespace declarations section of your code, as in the following example:  
  
 [!code-vb[VbEnumsTask#22](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class1.vb#22)]  
  
 An `Imports` statement imports namespace names from referenced projects and assemblies and from within the same project as the module in which the statement appears. Once this statement is added, you can refer to your enumeration members without qualification, as in the following example:  
  
 [!code-vb[VbEnumsTask#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class1.vb#24)]  
  
 By organizing sets of related constants in enumerations, you can use the same constant names in different contexts. For example, you can use the same names for the weekday constants in the `Days` and `WorkDays` enumerations. If you use the `Imports` statement with your enumerations, you must be careful to avoid ambiguous references. Consider the following example:  
  
 [!code-vb[VbEnumsTask#22](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class1.vb#22)]  
  
 [!code-vb[VbEnumsTask#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class1.vb#25)]  
  
 Assuming that `Monday` is a member of both the `Days` enumeration and the `Workdays` enumeration, this code generates a compiler error. To avoid ambiguous references when referring to an individual constant, qualify the constant name with its enumeration. The following code refers to the `Saturday` constants in the `Days` and `WorkDays` enumerations.  
  
 [!code-vb[VbEnumsTask#32](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#32)]  
  
## See also

- [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)
- [How to: Declare an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-enumerations.md)
- [How to: Refer to an Enumeration Member](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-refer-to-an-enumeration-member.md)
- [How to: Iterate Through An Enumeration in Visual Basic](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-iterate-through-an-enumeration.md)
- [How to: Determine the String Associated with an Enumeration Value](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-determine-the-string-associated-with-an-enumeration-value.md)
- [When to Use an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/when-to-use-an-enumeration.md)
- [Constant and Literal Data Types](../../../../visual-basic/programming-guide/language-features/constants-enums/constant-and-literal-data-types.md)
- [Enum Statement](../../../../visual-basic/language-reference/statements/enum-statement.md)
- [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)
- [Data Types](../../../../visual-basic/language-reference/data-types/index.md)
