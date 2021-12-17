---
description: "C# Keywords"
title: "C# Keywords"
ms.date: 03/17/2021
f1_keywords: 
  - "cs.keywords"
helpviewer_keywords:
  - "keywords [C#]"
  - "C# language, keywords"
  - "Visual C#, keywords"
  - "@ keyword"
ms.custom: "updateeachrelease"
---
# C# Keywords

Keywords are predefined, reserved identifiers that have special meanings to the compiler. They cannot be used as identifiers in your program unless they include `@` as a prefix. For example, `@if` is a valid identifier, but `if` is not because `if` is a keyword.

The first table in this topic lists keywords that are reserved identifiers in any part of a C# program. The second table in this topic lists the contextual keywords in C#. Contextual keywords have special meaning only in a limited program context and can be used as identifiers outside that context. Generally, as new keywords are added to the C# language, they are added as contextual keywords in order to avoid breaking programs written in earlier versions.

:::row:::
    :::column:::
        [abstract](abstract.md)  
        [as](../operators/type-testing-and-cast.md#as-operator)  
        [base](base.md)  
        [bool](../builtin-types/bool.md)  
        [break](../statements/jump-statements.md#the-break-statement)  
        [byte](../builtin-types/integral-numeric-types.md)  
        [case](../statements/selection-statements.md#the-switch-statement)  
        [catch](try-catch.md)  
        [char](../builtin-types/char.md)  
        [checked](checked.md)  
        [class](class.md)  
        [const](const.md)  
        [continue](../statements/jump-statements.md#the-continue-statement)  
        [decimal](../builtin-types/floating-point-numeric-types.md)  
        [default](default.md)  
        [delegate](../builtin-types/reference-types.md)  
        [do](../statements/iteration-statements.md#the-do-statement)  
        [double](../builtin-types/floating-point-numeric-types.md)  
        [else](../statements/selection-statements.md#the-if-statement)  
        [enum](../builtin-types/enum.md)  
    :::column-end:::
    :::column:::
        [event](event.md)  
        [explicit](../operators/user-defined-conversion-operators.md)  
        [extern](extern.md)  
        [false](../builtin-types/bool.md)  
        [finally](try-finally.md)  
        [fixed](fixed-statement.md)  
        [float](../builtin-types/floating-point-numeric-types.md)  
        [for](../statements/iteration-statements.md#the-for-statement)  
        [foreach](../statements/iteration-statements.md#the-foreach-statement)  
        [goto](../statements/jump-statements.md#the-goto-statement)  
        [if](../statements/selection-statements.md#the-if-statement)  
        [implicit](../operators/user-defined-conversion-operators.md)  
        [in](in.md)  
        [int](../builtin-types/integral-numeric-types.md)  
        [interface](interface.md)  
        [internal](internal.md)  
        [is](../operators/is.md)  
        [lock](../statements/lock.md)  
        [long](../builtin-types/integral-numeric-types.md)  
    :::column-end:::
    :::column:::
        [namespace](namespace.md)  
        [new](../operators/new-operator.md)  
        [null](null.md)  
        [object](../builtin-types/reference-types.md)  
        [operator](../operators/operator-overloading.md)  
        [out](out.md)  
        [override](override.md)  
        [params](params.md)  
        [private](private.md)  
        [protected](protected.md)  
        [public](public.md)  
        [readonly](readonly.md)  
        [ref](ref.md)  
        [return](../statements/jump-statements.md#the-return-statement)  
        [sbyte](../builtin-types/integral-numeric-types.md)  
        [sealed](sealed.md)  
        [short](../builtin-types/integral-numeric-types.md)  
        [sizeof](../operators/sizeof.md)  
        [stackalloc](../operators/stackalloc.md)  
    :::column-end:::
    :::column:::
        [static](static.md)  
        [string](../builtin-types/reference-types.md)  
        [struct](../builtin-types/struct.md)  
        [switch](../operators/switch-expression.md)  
        [this](this.md)  
        [throw](throw.md)  
        [true](../builtin-types/bool.md)  
        [try](try-catch.md)  
        [typeof](../operators/type-testing-and-cast.md#typeof-operator)  
        [uint](../builtin-types/integral-numeric-types.md)  
        [ulong](../builtin-types/integral-numeric-types.md)  
        [unchecked](unchecked.md)  
        [unsafe](unsafe.md)  
        [ushort](../builtin-types/integral-numeric-types.md)  
        [using](using.md)  
        [virtual](virtual.md)  
        [void](../builtin-types/void.md)  
        [volatile](volatile.md)  
        [while](../statements/iteration-statements.md#the-while-statement)  
    :::column-end:::
:::row-end:::

## Contextual keywords

A contextual keyword is used to provide a specific meaning in the code, but it is not a reserved word in C#. Some contextual keywords, such as `partial` and `where`, have special meanings in two or more contexts.

:::row:::
    :::column:::
        [add](add.md)  
        [and](../operators/patterns.md#logical-patterns)  
        [alias](extern-alias.md)  
        [ascending](ascending.md)  
        [async](async.md)  
        [await](../operators/await.md)  
        [by](by.md)  
        [descending](descending.md)  
        [dynamic](../builtin-types/reference-types.md)  
        [equals](equals.md)  
        [from](from-clause.md)  
    :::column-end:::
    :::column:::
        [get](get.md)  
        [global](../operators/namespace-alias-qualifier.md)  
        [group](group-clause.md)  
        [init](init.md)  
        [into](into.md)  
        [join](join-clause.md)  
        [let](let-clause.md)  
        [managed (function pointer calling convention)](../unsafe-code.md#function-pointers)  
        [nameof](../operators/nameof.md)  
        [nint](../builtin-types/nint-nuint.md)  
        [not](../operators/patterns.md#logical-patterns)  
    :::column-end:::
    :::column:::
        [notnull](../../programming-guide/generics/constraints-on-type-parameters.md#notnull-constraint)  
        [nuint](../builtin-types/nint-nuint.md)  
        [on](on.md)  
        [or](../operators/patterns.md#logical-patterns)  
        [orderby](orderby-clause.md)  
        [partial (type)](partial-type.md)  
        [partial (method)](partial-method.md)  
        [record](../../fundamentals/types/records.md)  
        [remove](remove.md)  
        [select](select-clause.md)  
    :::column-end:::
    :::column:::
        [set](set.md)  
        [unmanaged (function pointer calling convention)](../unsafe-code.md#function-pointers)  
        [unmanaged (generic type constraint)](../../programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint)  
        [value](value.md)  
        [var](var.md)  
        [when (filter condition)](when.md)  
        [where (generic type constraint)](where-generic-type-constraint.md)  
        [where (query clause)](where-clause.md)  
        [with](../operators/with-expression.md)  
        [yield](yield.md)  
    :::column-end:::
:::row-end:::

## See also

- [C# reference](../index.md)
