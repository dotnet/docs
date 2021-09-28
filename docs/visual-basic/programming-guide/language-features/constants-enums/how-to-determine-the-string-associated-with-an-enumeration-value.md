---
description: "Learn more about: How to: Determine the String Associated with an Enumeration Value (Visual Basic)"
title: "How to: Determine the String Associated with an Enumeration Value"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "enumerations [Visual Basic]"
  - "strings [Visual Basic], enumeration values"
  - "values [Visual Basic], enumeration members"
ms.assetid: 9253e7c8-579c-49a2-8f26-392b20ea99eb
---
# How to: Determine the String Associated with an Enumeration Value (Visual Basic)

The <xref:System.Enum.GetValues%2A> and <xref:System.Enum.GetNames%2A> methods allow you to determine the strings and values associated with enumeration members.  
  
### To determine the string associated with an enumeration  
  
- Use the <xref:System.Enum.GetNames%2A> method to retrieve the strings associated with the enumeration members. This example declares an enumeration, `flavorEnum`, then uses the <xref:System.Enum.GetNames%2A> method to display the strings associated with each member.  
  
     [!code-vb[VbEnumsTask#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#2)]  
  
## See also

- <xref:System.Enum.GetValues%2A>
- <xref:System.Enum.GetNames%2A>
- <xref:System.Enum>
- [How to: Declare an Enumeration](how-to-declare-enumerations.md)
- [How to: Refer to an Enumeration Member](how-to-refer-to-an-enumeration-member.md)
- [Enumerations and Name Qualification](enumerations-and-name-qualification.md)
- [How to: Iterate Through An Enumeration in Visual Basic](how-to-iterate-through-an-enumeration.md)
- [When to Use an Enumeration](when-to-use-an-enumeration.md)
- [Enum Statement](../../../language-reference/statements/enum-statement.md)
