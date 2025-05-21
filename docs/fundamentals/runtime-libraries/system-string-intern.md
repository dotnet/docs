---
title: System.String.Intern method
description: Learn about the System.String.Intern method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.String.Intern method

[!INCLUDE [context](includes/context.md)]

The common language runtime conserves string storage by maintaining a table, called the *intern pool*, that contains a single reference to each unique literal string declared or created programmatically in your program. Consequently, an instance of a literal string with a particular value only exists once in the system. For example, if you assign the same literal string to several variables, the runtime retrieves the same reference to the literal string from the intern pool and assigns it to each variable.

The <xref:System.String.Intern%2A> method uses the intern pool to search for a string equal to the value of its parameter, `str`. If such a string exists, its reference in the intern pool is returned. If the string does not exist, a reference to `str` is added to the intern pool, then that reference is returned. (In contrast, the <xref:System.String.IsInterned(System.String)> method returns a null reference if the requested string doesn't exist in the intern pool.)

In the following example, the string `s1`, which has a value of "MyTest", is already interned because it is a literal in the program. The <xref:System.Text.StringBuilder?displayProperty=nameWithType> class generates a new string object that has the same value as `s1`. A reference to that string is assigned to `s2`. The <xref:System.String.Intern%2A> method searches for a string that has the same value as `s2`. Because such a string exists, the method returns the same reference that's assigned to `s1`. That reference is then assigned to `s3`. References `s1` and `s2` compare unequal because they refer to different objects; references `s1` and `s3` compare equal because they refer to the same string.

:::code language="csharp" source="./snippets/System/String/Intern/csharp/Intern1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/String/Intern/fsharp/Intern1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/String/Intern/vb/Intern1.vb" id="Snippet1":::

## Performance considerations

If you're trying to reduce the total amount of memory your application allocates, keep in mind that interning a string has two unwanted side effects. First, the memory allocated for interned <xref:System.String> objects is not likely to be released until the common language runtime (CLR) terminates. The reason is that the CLR's reference to the interned <xref:System.String> object can persist after your application, or even your application domain, terminates. Second, to intern a string, you must first create the string. The memory used by the <xref:System.String> object must still be allocated, even though the memory will eventually be garbage collected.

The <xref:System.Runtime.CompilerServices.CompilationRelaxations.NoStringInterning?displayProperty=nameWithType> enumeration member marks an assembly as not requiring string-literal interning. You can apply <xref:System.Runtime.CompilerServices.CompilationRelaxations.NoStringInterning> to an assembly using the <xref:System.Runtime.CompilerServices.CompilationRelaxationsAttribute> attribute. Also, when you use [Ngen.exe (Native Image Generator)](../../framework/tools/ngen-exe-native-image-generator.md) to compile an assembly in advance of run time, strings are not interned across modules.
