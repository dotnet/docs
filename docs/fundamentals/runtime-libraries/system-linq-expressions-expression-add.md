---
title: System.Linq.Expressions.Expression.Add methods
description: Learn about the System.Linq.Expressions.Expression.Add methods.
ms.date: 01/24/2024
ms.topic: article
---
# System.Linq.Expressions.Expression.Add methods

[!INCLUDE [context](includes/context.md)]

The <xref:System.Linq.Expressions.Expression.Add%2A> method returns a <xref:System.Linq.Expressions.BinaryExpression> that has the <xref:System.Linq.Expressions.BinaryExpression.Method> property set to the implementing method. The <xref:System.Linq.Expressions.Expression.Type> property is set to the type of the node. If the node is lifted, the <xref:System.Linq.Expressions.BinaryExpression.IsLifted%2A> and <xref:System.Linq.Expressions.BinaryExpression.IsLiftedToNull%2A> properties are both `true`. Otherwise, they are `false`. The <xref:System.Linq.Expressions.BinaryExpression.Conversion> property is `null`.

The following information describes the implementing method, the node type, and whether a node is lifted.

## Implementing method

The following rules determine the selected implementing method for the operation:

- If the <xref:System.Linq.Expressions.Expression.Type> property of either `left` or `right` represents a user-defined type that overloads the addition operator, the <xref:System.Reflection.MethodInfo> that represents that method is the implementing method.
- Otherwise, if `left`.Type and `right`.Type are numeric types, the implementing method is `null`.

## Node type and lifted versus non-lifted

If the implementing method is not `null`:

- If `left`.Type and `right`.Type are assignable to the corresponding argument types of the implementing method, the node is not lifted. The type of the node is the return type of the implementing method.
- If the following two conditions are satisfied, the node is lifted and the type of the node is the nullable type that corresponds to the return type of the implementing method:

  - `left`.Type and `right`.Type are both value types of which at least one is nullable and the corresponding non-nullable types are equal to the corresponding argument types of the implementing method.
  - The return type of the implementing method is a non-nullable value type.

If the implementing method is `null`:

- If `left`.Type and `right`.Type are both non-nullable, the node is not lifted. The type of the node is the result type of the predefined addition operator.
- If `left`.Type and `right`.Type are both nullable, the node is lifted. The type of the node is the nullable type that corresponds to the result type of the predefined addition operator.
