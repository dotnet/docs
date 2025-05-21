---
title: System.Linq.Expressions.BinaryExpression class
description: Learn about the System.Linq.Expressions.BinaryExpression class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Linq.Expressions.BinaryExpression class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Linq.Expressions.BinaryExpression> class represents an expression that has a binary operator.

The following tables summarize the factory methods that can be used to create a <xref:System.Linq.Expressions.BinaryExpression> that has a specific node type, represented by the <xref:System.Linq.Expressions.Expression.NodeType> property. Each table contains information for a specific class of operations such as arithmetic or bitwise.

## Binary arithmetic operations

|Node Type|Factory Method|
|---------------|--------------------|
|<xref:System.Linq.Expressions.ExpressionType.Add>|<xref:System.Linq.Expressions.Expression.Add%2A>|
|<xref:System.Linq.Expressions.ExpressionType.AddChecked>|<xref:System.Linq.Expressions.Expression.AddChecked%2A>|
|<xref:System.Linq.Expressions.ExpressionType.Divide>|<xref:System.Linq.Expressions.Expression.Divide%2A>|
|<xref:System.Linq.Expressions.ExpressionType.Modulo>|<xref:System.Linq.Expressions.Expression.Modulo%2A>|
|<xref:System.Linq.Expressions.ExpressionType.Multiply>|<xref:System.Linq.Expressions.Expression.Multiply%2A>|
|<xref:System.Linq.Expressions.ExpressionType.MultiplyChecked>|<xref:System.Linq.Expressions.Expression.MultiplyChecked%2A>|
|<xref:System.Linq.Expressions.ExpressionType.Power>|<xref:System.Linq.Expressions.Expression.Power%2A>|
|<xref:System.Linq.Expressions.ExpressionType.Subtract>|<xref:System.Linq.Expressions.Expression.Subtract%2A>|
|<xref:System.Linq.Expressions.ExpressionType.SubtractChecked>|<xref:System.Linq.Expressions.Expression.SubtractChecked%2A>|

## Bitwise operations

|Node Type|Factory Method|
|---------------|--------------------|
|<xref:System.Linq.Expressions.ExpressionType.And>|<xref:System.Linq.Expressions.Expression.And%2A>|
|<xref:System.Linq.Expressions.ExpressionType.Or>|<xref:System.Linq.Expressions.Expression.Or%2A>|
|<xref:System.Linq.Expressions.ExpressionType.ExclusiveOr>|<xref:System.Linq.Expressions.Expression.ExclusiveOr%2A>|

## Shift operations

|Node Type|Factory Method|
|---------------|--------------------|
|<xref:System.Linq.Expressions.ExpressionType.LeftShift>|<xref:System.Linq.Expressions.Expression.LeftShift%2A>|
|<xref:System.Linq.Expressions.ExpressionType.RightShift>|<xref:System.Linq.Expressions.Expression.RightShift%2A>|

## Conditional Boolean operations

|Node Type|Factory Method|
|---------------|--------------------|
|<xref:System.Linq.Expressions.ExpressionType.AndAlso>|<xref:System.Linq.Expressions.Expression.AndAlso%2A>|
|<xref:System.Linq.Expressions.ExpressionType.OrElse>|<xref:System.Linq.Expressions.Expression.OrElse%2A>|

## Comparison operations

|Node Type|Factory Method|
|---------------|--------------------|
|<xref:System.Linq.Expressions.ExpressionType.Equal>|<xref:System.Linq.Expressions.Expression.Equal%2A>|
|<xref:System.Linq.Expressions.ExpressionType.NotEqual>|<xref:System.Linq.Expressions.Expression.NotEqual%2A>|
|<xref:System.Linq.Expressions.ExpressionType.GreaterThanOrEqual>|<xref:System.Linq.Expressions.Expression.GreaterThanOrEqual%2A>|
|<xref:System.Linq.Expressions.ExpressionType.GreaterThan>|<xref:System.Linq.Expressions.Expression.GreaterThan%2A>|
|<xref:System.Linq.Expressions.ExpressionType.LessThan>|<xref:System.Linq.Expressions.Expression.LessThan%2A>|
|<xref:System.Linq.Expressions.ExpressionType.LessThanOrEqual>|<xref:System.Linq.Expressions.Expression.LessThanOrEqual%2A>|

## Coalescing operations

|Node Type|Factory Method|
|---------------|--------------------|
|<xref:System.Linq.Expressions.ExpressionType.Coalesce>|<xref:System.Linq.Expressions.Expression.Coalesce%2A>|

## Array indexing operations

|Node Type|Factory Method|
|---------------|--------------------|
|<xref:System.Linq.Expressions.ExpressionType.ArrayIndex>|<xref:System.Linq.Expressions.Expression.ArrayIndex%2A>|

In addition, the <xref:System.Linq.Expressions.Expression.MakeBinary%2A> methods can also be used to create a <xref:System.Linq.Expressions.BinaryExpression>. These factory methods can be used to create a <xref:System.Linq.Expressions.BinaryExpression> of any node type that represents a binary operation. The parameter of these methods that is of type <xref:System.Linq.Expressions.Expression.NodeType%2A> specifies the desired node type.
