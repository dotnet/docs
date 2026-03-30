---
title: System.String.Intern method
description: Learn about the System.String.Intern method.
ms.date: 03/27/2026
ai-usage: ai-assisted
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.String.Intern method

[!INCLUDE [context](includes/context.md)]

The common language runtime maintains a table, called the *intern pool*, that holds a single reference for each unique string value. The <xref:System.String.Intern*> method uses the intern pool to search for a string equal to the value of `str`. If no such string exists, a reference to `str` is added to the pool, and that reference is returned. (In contrast, the <xref:System.String.IsInterned(System.String)> method returns a null reference if the requested string doesn't exist in the intern pool.)

The intern pool can be used by the runtime to conserve string storage. However, automatic interning of string literals isn't guaranteed—depending on how the assembly was compiled and executed, some literals might not be added to the pool.

In the following example, the string `s1` has a value of "MyTest". The <xref:System.Text.StringBuilder?displayProperty=nameWithType> class generates a new string object that has the same value as `s1`. A reference to that string is assigned to `s2`. The <xref:System.String.Intern*> method searches for a string that has the same value as `s2`. If `s1` was already interned (for example, because the assembly requires string-literal interning), the method returns the same reference as `s1`, which is then assigned to `s3`, and `s1` and `s3` compare equal. Otherwise, a new interned entry is created for `s2` and assigned to `s3`, and `s1` and `s3` compare unequal. In either case, `s1` and `s2` compare unequal because they refer to different objects.

:::code language="csharp" source="./snippets/System/String/Intern/csharp/Intern1.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/String/Intern/fsharp/Intern1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/String/Intern/vb/Intern1.vb" id="Snippet1":::

## Performance considerations

If you're trying to reduce the total amount of memory your application allocates, keep in mind that interning a string has two unwanted side effects. First, the memory allocated for interned <xref:System.String> objects is not likely to be released until the common language runtime (CLR) terminates. The reason is that the CLR's reference to the interned <xref:System.String> object can persist after your application, or even your application domain, terminates. Second, to intern a string, you must first create the string. The memory used by the <xref:System.String> object must still be allocated, even though the memory will eventually be garbage collected.

The <xref:System.Runtime.CompilerServices.CompilationRelaxations.NoStringInterning?displayProperty=nameWithType> enumeration member marks an assembly as not requiring string-literal interning. By default, the C# compiler emits a <xref:System.Runtime.CompilerServices.CompilationRelaxationsAttribute> with the <xref:System.Runtime.CompilerServices.CompilationRelaxations.NoStringInterning> flag on each assembly for better performance, which means string literals are not guaranteed to be added to the intern pool. You can customize <xref:System.Runtime.CompilerServices.CompilationRelaxations.NoStringInterning> on an assembly using the <xref:System.Runtime.CompilerServices.CompilationRelaxationsAttribute> attribute.

When you publish an app using [native AOT](../../core/deploying/native-aot/index.md), turning off <xref:System.Runtime.CompilerServices.CompilationRelaxations.NoStringInterning> is not supported. With native AOT, string literals aren't guaranteed to be added to the intern pool, so <xref:System.String.Intern*> might not find a match for a string that appears to be a literal in source code.
