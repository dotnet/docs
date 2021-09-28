---
description: "Learn more about: How to: Declare an Object by Using an Object Initializer (Visual Basic)"
title: "How to: Declare an Object by Using an Object Initializer"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "declaring objects using object initializer"
  - "object initializers [Visual Basic]"
  - "initializers [Visual Basic]"
  - "Video How tos, Visual Basic"
ms.assetid: 0f53a553-efd6-466d-80bf-6b679e5cd174
---
# How to: Declare an Object by Using an Object Initializer (Visual Basic)

Object initializers enable you to declare and instantiate an instance of a class in a single statement. In addition, you can initialize one or more members of the instance at the same time, without invoking a parameterized constructor.  
  
 When you use an object initializer to create an instance of a named type, the parameterless constructor for the class is called, followed by initialization of designated members in the order you specify.  
  
 The following procedure shows how to create an instance of a `Student` class in three different ways. The class has first name, last name, and class year properties, among others. Each of the three declarations creates a new instance of `Student`, with property `First` set to "Michael", property `Last` set to "Tucker", and all other members set to their default values. The result of each declaration in the procedure is equivalent to the following example, which does not use an object initializer.  
  
 [!code-vb[VbVbalrObjectInit#20](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrObjectInit/VB/Class2.vb#20)]  
  
 For an implementation of the `Student` class, see [How to: Create a List of Items](../../concepts/linq/how-to-create-a-list-of-items.md). You can copy the code from that topic to set up the class and create a list of `Student` objects to work with.  
  
### To create an object of a named class by using an object initializer  
  
1. Begin the declaration as if you planned to use a constructor.  
  
     `Dim student1 As New Student`  
  
2. Type the keyword `With`, followed by an initialization list in braces.  
  
     `Dim student1 As New Student With { <initialization list> }`  
  
3. In the initialization list, include each property that you want to initialize and assign an initial value to it. The name of the property is preceded by a period.  
  
     [!code-vb[VbVbalrObjectInit#21](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrObjectInit/VB/Class2.vb#21)]  
  
     You can initialize one or more members of the class.  
  
4. Alternatively, you can declare a new instance of the class and then assign a value to it. First, declare an instance of `Student`:  
  
     `Dim student2 As Student`  
  
5. Begin the creation of an instance of `Student` in the normal way.  
  
     `Dim student2 As Student = New Student`  
  
6. Type `With` and then an object initializer to initialize one or more members of the new instance.  
  
     [!code-vb[VbVbalrObjectInit#22](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrObjectInit/VB/Class2.vb#22)]  
  
7. You can simplify the definition in the previous step by omitting `As Student`. If you do this, the compiler determines that `student3` is an instance of `Student` by using local type inference.  
  
     [!code-vb[VbVbalrObjectInit#23](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrObjectInit/VB/Class2.vb#23)]  
  
     For more information, see [Local Type Inference](../variables/local-type-inference.md).  
  
## See also

- [Local Type Inference](../variables/local-type-inference.md)
- [How to: Create a List of Items](../../concepts/linq/how-to-create-a-list-of-items.md)
- [Object Initializers: Named and Anonymous Types](object-initializers-named-and-anonymous-types.md)
- [Anonymous Types](anonymous-types.md)
