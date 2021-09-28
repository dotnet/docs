---
description: "Learn more about: BC32096: 'For Each' on type '<typename>' is ambiguous because the type implements multiple instantiations of 'System.Collections.Generic.IEnumerable(Of T)"
title: "'For Each' on type '<typename>' is ambiguous because the type implements multiple instantiations of 'System.Collections.Generic.IEnumerable(Of T)'"
ms.date: 07/20/2015
f1_keywords:
  - "vbc32096"
  - "bc32096"
helpviewer_keywords:
  - "BC32096"
ms.assetid: ed20d09c-913f-482e-89f8-c0a596c3ec24
---
# BC32096: 'For Each' on type '\<typename>' is ambiguous because the type implements multiple instantiations of 'System.Collections.Generic.IEnumerable(Of T)'

A `For Each` statement specifies an iterator variable that has more than one <xref:System.Collections.IEnumerable.GetEnumerator%2A> method.

 The iterator variable must be of a type that implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface in one of the `Collections` namespaces of the .NET Framework. It is possible for a class to implement more than one constructed generic interface, using a different type argument for each construction. If a class that does this is used for the iterator variable, that variable has more than one <xref:System.Collections.IEnumerable.GetEnumerator%2A> method. In such a case, Visual Basic cannot choose which method to call.

 **Error ID:** BC32096

## To correct this error

- Use [DirectCast Operator](../operators/directcast-operator.md) or [TryCast Operator](../operators/trycast-operator.md) to cast the iterator variable type to the interface defining the <xref:System.Collections.IEnumerable.GetEnumerator%2A> method you want to use.

## See also

- [For Each...Next Statement](../statements/for-each-next-statement.md)
- [Interfaces](../../programming-guide/language-features/interfaces/index.md)
