---
title: "How to: Infer Property Names and Types in Anonymous Type Declarations (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "inferring property names [Visual Basic]"
  - "anonymous types [Visual Basic], inferring property names and types"
  - "inferring property types [Visual Basic]"
ms.assetid: 7c748b22-913f-4d9d-b747-6b7bf296a0bc
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Infer Property Names and Types in Anonymous Type Declarations (Visual Basic)
Anonymous types provide no mechanism for directly specifying the data types of properties. Types of all properties are inferred. In the following example, the types of `Name` and `Price` are inferred directly from the values that are used to initialize them.  
  
 [!code-vb[VbVbalrAnonymousTypes#1](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_1.vb)]  
  
 Anonymous types can also infer property names and types from other sources. The sections that follow provide a list of the circumstances where inference is possible, and examples of situations where it is not.  
  
## Successful Inference  
  
#### Anonymous types can infer property names and types from the following sources:  
  
-   From variable names. Anonymous type `anonProduct` will have two properties, `productName` and `productPrice`. Their data types will be those of the original variables, `String` and `Double`, respectively.  
  
     [!code-vb[VbVbalrAnonymousTypes#11](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_2.vb)]  
  
-   From property or field names of other objects. For example, consider a `car` object of a `CarClass` type that includes `Name` and `ID` properties. To create a new anonymous type instance, `car1`, with `Name` and `ID` properties that are initialized with the values from the `car` object, you can write the following:  
  
     [!code-vb[VbVbalrAnonymousTypes#34](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_3.vb)]  
  
     The previous declaration is equivalent to the longer line of code that defines anonymous type `car2`.  
  
     [!code-vb[VbVbalrAnonymousTypes#35](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_4.vb)]  
  
-   From XML member names.  
  
     [!code-vb[VbVbalrAnonymousTypes#12](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_5.vb)]  
  
     The resulting type for `anon` would have one property, `Book`, of type <xref:System.Collections.IEnumerable>(Of XElement).  
  
-   From a function that has no parameters, such as `SomeFunction` in the following example.  
  
     `Dim sc As New SomeClass`  
  
     `Dim anon1 = New With {Key sc.SomeFunction()}`  
  
     The variable `anon2` in the following code is an anonymous type that has one property, a character named `First`. This code will display a letter "E," the letter that is returned by function <xref:System.Linq.Enumerable.First%2A>.  
  
     [!code-vb[VbVbalrAnonymousTypes#13](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_6.vb)]  
  
## Inference Failures  
  
#### Name inference will fail in many circumstances, including the following:  
  
-   The inference derives from the invocation of a method, a constructor, or a parameterized property that requires arguments. The previous declaration of `anon1` fails if `someFunction` has one or more arguments.  
  
     `' Not valid.`  
  
     `' Dim anon3 = New With {Key sc.someFunction(someArg)}`  
  
     Assignment to a new property name solves the problem.  
  
     `' Valid.`  
  
     `Dim anon4 = New With {Key .FunResult = sc.someFunction(someArg)}`  
  
-   The inference derives from a complex expression.  
  
    ```  
    Dim aString As String = "Act "  
    ' Not valid.  
    ' Dim label = New With {Key aString & "IV"}  
    ```  
  
     The error can be resolved by assigning the result of the expression to a property name.  
  
     [!code-vb[VbVbalrAnonymousTypes#14](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_7.vb)]  
  
-   Inference for multiple properties produces two or more properties that have the same name. Referring back to declarations in earlier examples, you cannot list both `product.Name` and `car1.Name` as properties of the same anonymous type. This is because the inferred identifier for each of these would be `Name`.  
  
     `' Not valid.`  
  
     `' Dim anon5 = New With {Key product.Name, Key car1.Name}`  
  
     The problem can be solved by assigning the values to distinct property names.  
  
     [!code-vb[VbVbalrAnonymousTypes#36](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_8.vb)]  
  
     Note that changes in case (changes between uppercase and lowercase letters) do not make two names distinct.  
  
     `Dim price = 0`  
  
     `' Not valid, because Price and price are the same name.`  
  
     `' Dim anon7 = New With {Key product.Price, Key price}`  
  
-   The initial type and value of one property depends on another property that is not yet established. For example, `.IDName = .LastName` is not valid in an anonymous type declaration unless `.LastName` is already initialized.  
  
     `' Not valid.`  
  
     `' Dim anon8 = New With {Key .IDName = .LastName, Key .LastName = "Jones"}`  
  
     In this example, you can fix the problem by reversing the order in which the properties are declared.  
  
     [!code-vb[VbVbalrAnonymousTypes#15](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_9.vb)]  
  
-   A property name of the anonymous type is the same as the name of a member of <xref:System.Object>. For example, the following declaration fails because `Equals` is a method of <xref:System.Object>.  
  
     `' Not valid.`  
  
     `' Dim relationsLabels1 = New With {Key .Equals = "equals", Key .Greater = _`  
  
     `'                       "greater than", Key .Less = "less than"}`  
  
     You can fix the problem by changing the property name:  
  
     [!code-vb[VbVbalrAnonymousTypes#16](../../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/how-to-infer-property-names-and-types-in-anonymous-type-declarations_10.vb)]  
  
## See Also  
 [Object Initializers: Named and Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)  
 [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 [Key](../../../../visual-basic/language-reference/modifiers/key.md)
