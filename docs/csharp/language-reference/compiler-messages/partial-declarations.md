---
title: Compiler Errors on partial type and member declarations
description: Use this article to diagnose and correct compiler errors and warnings when you write `partial` types and `partial` members.
f1_keywords:
  - "CS0750"
  - "CS0751"
  - "CS0754"
  - "CS0763"
  - "CS0764"
  - "CS8142"
  - "CS8663"
  - "CS8799"
  - "CS8800"
  - "CS8818"
  - "CS8988"
  - "CS9248"
  - "CS9249"
  - "CS9250"
  - "CS9251"
  - "CS9152"
  - "CS9253"
  - "CS9254"
  - "CS9255"
  - "CS9256"
  - "CS9257"
helpviewer_keywords:
ms.date: 08/21/2024
---
# Errors and warnings related to `partial` type and `partial` member declarations

There are numerous *errors* related to `partial` type and `partial` member declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS8142**: *Both partial member declarations must use the same tuple element names.*
- **CS8663**: *Both partial member declarations must be readonly or neither may be readonly*
- **CS8799**: *Both partial member declarations must have identical accessibility modifiers.*
- **CS8800**: *Both partial member declarations must have identical combinations of `virtual`, `override`, `sealed`, and `new` modifiers.*
- **CS8818**: *Partial member declarations must have matching ref return values.*
- **CS8988**: *The `scoped` modifier of parameter doesn't match partial definition.*
- [**CS9248**](#partial-properties): *Partial property must have an implementation part.*
- [**CS9249**](#partial-properties): *Partial property must have a definition part.*
- [**CS9250**](#partial-properties): *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- [**CS9251**](#partial-properties): *A partial property may not have multiple implementing declarations*
- [**CS9252**](#partial-properties): *Property accessor must be implemented because it is declared on the definition part*
- [**CS9253**](#partial-properties): *Property accessor does not implement any accessor declared on the definition part*
- [**CS9254**](#partial-properties): *Property accessor must match the definition part*
- [**CS9255**](#partial-properties): *Both partial property declarations must have the same type.*
- [**CS9256**](#partial-properties): *Partial property declarations have signature differences.*
- [**CS9257**](#partial-properties): *Both partial property declarations must be required or neither may be required*

## Partial properties

The following errors and warnings are issued when a partial property or indexer is declared incorrectly:

- **CS9248**: *Partial property must have an implementation part.*
- **CS9249**: *Partial property must have a definition part.*
- **CS9250**: *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- **CS9251**: *A partial property may not have multiple implementing declarations*
- **CS9252**: *Property accessor must be implemented because it is declared on the definition part*
- **CS9253**: *Property accessor does not implement any accessor declared on the definition part*
- **CS9254**: *Property accessor must match the definition part*
- **CS9255**: *Both partial property declarations must have the same type.*
- **CS9257**: *Both partial property declarations must be required or neither may be required*

The following warning indicates signature differences in the partial property declarations:

- **CS9256**: *Partial property declarations have signature differences.*

## Compiler Error CS0750

A partial method cannot have access modifiers or the virtual, abstract, override, new, sealed, or extern modifiers.

Because of their special behavior, partial methods are subject to restrictions as to the modifiers they can accept.

Remove the unauthorized modifier from the method declaration.

The following example generates CS0750:

```csharp
// cs0750.cs
using System;

public class Base
{
    protected virtual void PartG()
    {
    }

    protected void PartH()
    {
    }
    protected virtual void PartI()
    {
    }
}

public partial class C:Base
{
    // All these partial method declarations
    // will generate CS0750.
    public partial void PartA();
    private partial void PartB();
    protected partial void PartC();
    internal partial void PartD();
    virtual partial void PartE();
    abstract partial void PartF();
    override partial void PartG();
    new partial void PartH();
    sealed override partial void PartI();
    extern partial void PartJ();

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0751

A partial member must be declared in a partial class or partial struct

It is not possible to declare a [partial](../language-reference/keywords/partial-method.md) method unless it is encapsulated inside a partial class or partial struct.

Either remove the `partial` modifier from the method and provide an implementation, or else add the `partial` modifier to the enclosing class or struct.

The following example generates CS0751:

```csharp
// cs0751.cs
using System;

public class C
{
    partial void Part(); // CS0751
    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0754

A partial method may not explicitly implement an interface method.

A partial method cannot be declared as an explicit implementation of a method defined in an interface.

Remove the explicit interface qualification from the method declaration.

The following code generates CS0754:

```csharp
// cs0754.cs
using System;

    public interface IF
    {
        void Part();
    }

    public partial class C : IF
    {
        partial void IF.Part(); //CS0754
        public static int Main()
        {
            return 1;
        }
    }
```

## Compiler Error CS0763

Both partial method declarations must be static or neither may be static.

A partial method declaration cannot have one part static and the other part not static.

Make both parts either static or non-static.

The following code generates CS0763:

```csharp
// cs0763.cs
using System;

public partial class C
{
    static partial void Part();
    partial void Part() // CS0763
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0764

Both partial method declarations must be unsafe or neither may be unsafe

A partial method consists of a defining declaration (signature) and an optional implementing declaration (body). If the defining declaration has the `unsafe` modifier, the implementing declaration must also have it. Conversely, if the implementing declaration has the `unsafe` modifier, the defining declaration must also.

Assuming that the defining declaration is correct, add or remove the `unsafe` modifier from the implementing declaration to match the defining declaration.

```csharp
// cs0764.cs
//  Compile with: /target:library /unsafe
public partial class C
{
    partial void Part();
    unsafe partial void Part() //CS0764
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```
