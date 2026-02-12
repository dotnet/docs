---
title: System.Reflection.Emit.DynamicILInfo class
description: Learn about the System.Reflection.Emit.DynamicILInfo class.
ms.date: 02/12/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicILInfo class

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.Reflection.Emit.DynamicILInfo> class to write your own MSIL generators instead of using <xref:System.Reflection.Emit.ILGenerator>.

To create instances of other types, call methods, access fields, or reference types, the MSIL you generate must include tokens for those entities. The <xref:System.Reflection.Emit.DynamicILInfo> class provides several overloads of the <xref:System.Reflection.Emit.DynamicILInfo.GetTokenFor%2A> method, which return tokens valid in the scope of the current <xref:System.Reflection.Emit.DynamicILInfo>. For example, if you need to call an overload of the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method, you can obtain a <xref:System.RuntimeMethodHandle> for that overload and pass it to the <xref:System.Reflection.Emit.DynamicILInfo.GetTokenFor%2A> method to obtain a token to embed in your MSIL.

Once you have created <xref:System.Byte> arrays for your local variable signature, exceptions, and code body, you can use the <xref:System.Reflection.Emit.DynamicILInfo.SetCode%2A>, <xref:System.Reflection.Emit.DynamicILInfo.SetExceptions%2A>, and <xref:System.Reflection.Emit.DynamicILInfo.SetLocalSignature%2A> methods to insert them into the <xref:System.Reflection.Emit.DynamicMethod> associated with your <xref:System.Reflection.Emit.DynamicILInfo> object.

Generating your own metadata and MSIL requires familiarity with the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics" and "Partition III: CIL Instruction Set". For more information, see [ECMA 335 Common Language Infrastructure (CLI)](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/).

> [!NOTE]
> Don't use <xref:System.Reflection.Emit.DynamicILInfo> to generate code that creates a delegate to another dynamic method by calling the delegate constructor directly. Instead, use the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> method to create the delegate. A delegate that is created with the delegate constructor doesn't have a reference to the target dynamic method. The dynamic method might be reclaimed by garbage collection while the delegate is still in use.
