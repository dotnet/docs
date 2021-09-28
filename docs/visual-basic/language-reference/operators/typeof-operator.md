---
description: "Learn more about: TypeOf Operator (Visual Basic)"
title: "TypeOf Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "TypeOf"
  - "vb.TypeOf"
helpviewer_keywords: 
  - "types [Visual Basic], compatible"
  - "comparison operators [Visual Basic]"
  - "TypeOf...Is expression"
  - "data types [Visual Basic], compatible"
  - "TypeOf operator [Visual Basic]"
  - "compatible data types [Visual Basic]"
ms.assetid: 33f65296-659a-4b9a-9a29-c2a91cff68b2
---
# TypeOf Operator (Visual Basic)

Checks whether the runtime type of an expression's result is type-compatible with the specified type.
  
## Syntax  
  
```vb  
result = TypeOf objectexpression Is typename  
```  
  
```vb  
result = TypeOf objectexpression IsNot typename  
```  
  
## Parts  

 `result`  
 Returned. A `Boolean` value.  
  
 `objectexpression`  
 Required. Any expression that evaluates to a reference type.  
  
 `typename`  
 Required. Any data type name.  
  
## Remarks  

 The `TypeOf` operator determines whether the run-time type of `objectexpression` is compatible with `typename`. The compatibility depends on the type category of `typename`. The following table shows how compatibility is determined.  
  
|Type category of `typename`|Compatibility criterion|  
|---------------------------------|-----------------------------|  
|Class|`objectexpression` is of type `typename` or inherits from `typename`|  
|Structure|`objectexpression` is of type `typename`|  
|Interface|`objectexpression` implements `typename` or inherits from a class that implements `typename`|  
  
 If the run-time type of `objectexpression` satisfies the compatibility criterion, `result` is `True`. Otherwise, `result` is `False`.  If `objectexpression` is null, then `TypeOf`...`Is` returns `False`, and ...`IsNot` returns `True`.  
  
 `TypeOf` is always used with the `Is` keyword to construct a `TypeOf`...`Is` expression, or with the `IsNot` keyword to construct a `TypeOf`...`IsNot` expression.  
  
## Example  

 The following example uses `TypeOf`...`Is` expressions to test the type compatibility of two object reference variables with various data types.  
  
 [!code-vb[VbVbalrOperators#39](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#39)]  
  
 The variable `refInteger` has a run-time type of `Integer`. It is compatible with `Integer` but not with `Double`. The variable `refForm` has a run-time type of <xref:System.Windows.Forms.Form>. It is compatible with <xref:System.Windows.Forms.Form> because that is its type, with <xref:System.Windows.Forms.Control> because <xref:System.Windows.Forms.Form> inherits from <xref:System.Windows.Forms.Control>, and with <xref:System.ComponentModel.IComponent> because <xref:System.Windows.Forms.Form> inherits from <xref:System.ComponentModel.Component>, which implements <xref:System.ComponentModel.IComponent>. However, `refForm` is not compatible with <xref:System.Windows.Forms.Label>.  
  
## See also

- [Is Operator](is-operator.md)
- [IsNot Operator](isnot-operator.md)
- [Comparison Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/comparison-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Operators and Expressions](../../programming-guide/language-features/operators-and-expressions/index.md)
