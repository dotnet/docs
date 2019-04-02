---
title: "Key (Visual Basic)"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.AnonymousKey"
helpviewer_keywords: 
  - "anonymous types [Visual Basic], key"
  - "Key [Visual Basic]"
  - "Key keyword [Visual Basic]"
ms.assetid: 7697a928-7d14-4430-a72a-c9e96e8d6c11
---
# Key (Visual Basic)
The `Key` keyword enables you to specify behavior for properties of anonymous types. Only properties you designate as key properties participate in tests of equality between anonymous type instances, or calculation of hash code values. The values of key properties cannot be changed.  
  
 You designate a property of an anonymous type as a key property by placing the keyword `Key` in front of its declaration in the initialization list. In the following example, `Airline` and `FlightNo` are key properties, but `Gate` is not.  
  
 [!code-vb[VbVbalrAnonymousTypes#26](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#26)]  
  
 When a new anonymous type is created, it inherits directly from <xref:System.Object>. The compiler overrides three inherited members: <xref:System.Object.Equals%2A>, <xref:System.Object.GetHashCode%2A>, and <xref:System.Object.ToString%2A>. The override code that is produced for <xref:System.Object.Equals%2A> and <xref:System.Object.GetHashCode%2A> is based on key properties. If there are no key properties in the type, <xref:System.Object.GetHashCode%2A> and <xref:System.Object.Equals%2A> are not overridden.  
  
## Equality  
 Two anonymous type instances are equal if they are instances of the same type and if the values of their key properties are equal. In the following examples, `flight2` is equal to `flight1` from the previous example because they are instances of the same anonymous type and they have matching values for their key properties. However, `flight3` is not equal to `flight1` because it has a different value for a key property, `FlightNo`. Instance `flight4` is not the same type as `flight1` because they designate different properties as key properties.  
  
 [!code-vb[VbVbalrAnonymousTypes#27](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#27)]  
  
 If two instances are declared with only non-key properties, identical in name, type, order, and value, the two instances are not equal. An instance without key properties is equal only to itself.  
  
 For more information about the conditions under which two anonymous type instances are instances of the same anonymous type, see [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md).  
  
## Hash Code Calculation  
 Like <xref:System.Object.Equals%2A>, the hash function that is defined in <xref:System.Object.GetHashCode%2A> for an anonymous type is based on the key properties of the type. The following examples show the interaction between key properties and hash code values.  
  
 Instances of an anonymous type that have the same values for all key properties have the same hash code value, even if non-key properties do not have matching values. The following statement returns `True`.  
  
 [!code-vb[VbVbalrAnonymousTypes#37](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#37)]  
  
 Instances of an anonymous type that have different values for one or more key properties have different hash code values. The following statement returns `False`.  
  
 [!code-vb[VbVbalrAnonymousTypes#38](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#38)]  
  
 Instances of anonymous types that designate different properties as key properties are not instances of the same type. They have different hash code values even when the names and values of all properties are the same. The following statement returns `False`.  
  
 [!code-vb[VbVbalrAnonymousTypes#39](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#39)]  
  
## Read-Only Values  
 The values of key properties cannot be changed. For example, in `flight1` in the earlier examples, the `Airline` and `FlightNo` fields are read-only, but `Gate` can be changed.  
  
 [!code-vb[VbVbalrAnonymousTypes#28](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrAnonymousTypes/VB/Class2.vb#28)]  
  
## See also

- [Anonymous Type Definition](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-type-definition.md)
- [How to: Infer Property Names and Types in Anonymous Type Declarations](../../../visual-basic/programming-guide/language-features/objects-and-classes/how-to-infer-property-names-and-types-in-anonymous-type-declarations.md)
- [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)
