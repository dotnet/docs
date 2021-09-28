---
description: "Learn more about: Type Promotion (Visual Basic)"
title: "Type Promotion"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "declared elements [Visual Basic], scope"
  - "visibility [Visual Basic], declared elements"
  - "Partial keyword [Visual Basic], unexpected results with type promotion"
  - "scope [Visual Basic], declared elements"
  - "scope [Visual Basic], Visual Basic"
  - "type promotion"
  - "declared elements [Visual Basic], visibility"
ms.assetid: 035eeb15-e4c5-4288-ab3c-6bd5d22f7051
---
# Type Promotion (Visual Basic)

When you declare a programming element in a module, Visual Basic promotes its scope to the namespace containing the module. This is known as *type promotion*.  
  
 The following example shows a skeleton definition of a module and two members of that module.  
  
 [!code-vb[VbVbalrDeclaredElements#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDeclaredElements/VB/Class1.vb#1)]  
  
 Within `projModule`, programming elements declared at module level are promoted to `projNamespace`. In the preceding example, `basicEnum` and `innerClass` are promoted, but `numberSub` is not, because it is not declared at module level.  
  
## Effect of Type Promotion  

 The effect of type promotion is that a qualification string does not need to include the module name. The following example makes two calls to the procedure in the preceding example.  
  
 [!code-vb[VbVbalrDeclaredElements#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDeclaredElements/VB/Class1.vb#2)]  
  
 In the preceding example, the first call uses complete qualification strings. However, this is not necessary because of type promotion. The second call also accesses the module's members without including `projModule` in the qualification strings.  
  
## Defeat of Type Promotion  

 If the namespace already has a member with the same name as a module member, type promotion is defeated for that module member. The following example shows a skeleton definition of an enumeration and a module within the same namespace.  
  
 [!code-vb[VbVbalrDeclaredElements#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDeclaredElements/VB/Class1.vb#3)]  
  
 In the preceding example, Visual Basic cannot promote class `abc` to `thisNameSpace` because there is already an enumeration with the same name at namespace level. To access `abcSub`, you must use the full qualification string `thisNamespace.thisModule.abc.abcSub`. However, class `xyz` is still promoted, and you can access `xyzSub` with the shorter qualification string `thisNamespace.xyz.xyzSub`.  
  
### Defeat of Type Promotion for Partial Types  

 If a class or structure inside a module uses the [Partial](../../../language-reference/modifiers/partial.md) keyword, type promotion is automatically defeated for that class or structure, whether or not the namespace has a member with the same name. Other elements in the module are still eligible for type promotion.  
  
 **Consequences.** Defeat of type promotion of a partial definition can cause unexpected results and even compiler errors. The following example shows skeleton partial definitions of a class, one of which is inside a module.  
  
 [!code-vb[VbVbalrDeclaredElements#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDeclaredElements/VB/Class1.vb#4)]  
  
 In the preceding example, the developer might expect the compiler to merge the two partial definitions of `sampleClass`. However, the compiler does not consider promotion for the partial definition inside `sampleModule`. As a result, it attempts to compile two separate and distinct classes, both named `sampleClass` but with different qualification paths.  
  
 The compiler merges partial definitions only when their fully qualified paths are identical.  
  
## Recommendations  

 The following recommendations represent good programming practice.  
  
- **Unique Names.** When you have full control over the naming of programming elements, it is always a good idea to use unique names everywhere. Identical names require extra qualification and can make your code harder to read. They can also lead to subtle errors and unexpected results.  
  
- **Full Qualification.** When you are working with modules and other elements in the same namespace, the safest approach is to always use full qualification for all programming elements. If type promotion is defeated for a module member and you do not fully qualify that member, you could inadvertently access a different programming element.  
  
## See also

- [Module Statement](../../../language-reference/statements/module-statement.md)
- [Namespace Statement](../../../language-reference/statements/namespace-statement.md)
- [Partial](../../../language-reference/modifiers/partial.md)
- [Scope in Visual Basic](scope.md)
- [How to: Control the Scope of a Variable](how-to-control-the-scope-of-a-variable.md)
- [References to Declared Elements](references-to-declared-elements.md)
