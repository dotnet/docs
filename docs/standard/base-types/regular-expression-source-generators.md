---
title: ".NET regular expression source generators"
description: Learn how to use regular expression source generators to optimize the performance of matching algorithms in .NET.
ms.topic: conceptual
ms.date: 05/29/2024
author: IEvangelist
ms.author: dapine
---

# .NET regular expression source generators

A regular expression, or regex, is a string that enables a developer to express a pattern being searched for, making it a common way to search text and extract results as a subset from the searched string. In .NET, the `System.Text.RegularExpressions` namespace is used to define <xref:System.Text.RegularExpressions.Regex> instances and static methods and match on user-defined patterns. In this article, you'll learn how to use source generation to generate `Regex` instances to optimize performance.

> [!NOTE]
> Where possible, use source-generated regular expressions instead of compiling regular expressions using the <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType> option. Source generation can help your app start faster, run more quickly, and be more trimmable. To learn when source generation is possible, see [When to use it](#when-to-use-it).

## Compiled regular expressions

When you write `new Regex("somepattern")`, a few things happen. The specified pattern is parsed, both to ensure the validity of the pattern and to transform it into an internal tree that represents the parsed regex. The tree is then optimized in various ways, transforming the pattern into a functionally equivalent variation that can be more efficiently executed. The tree is written into a form that can be interpreted as a series of opcodes and operands that provide instructions to the regex interpreter engine on how to match. When a match is performed, the interpreter simply walks through those instructions, processing them against the input text. When instantiating a new `Regex` instance or calling one of the static methods on `Regex`, the interpreter is the default engine employed.

When you specify <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType>, all of the same construction-time work is performed. The resulting instructions are transformed further by the reflection-emit-based compiler into IL instructions that are written to a few <xref:System.Reflection.Emit.DynamicMethod> objects. When a match is performed, those `DynamicMethod` methods are invoked. This IL essentially does exactly what the interpreter would do, except specialized for the exact pattern being processed. For example, if the pattern contains `[ac]`, the interpreter would see an opcode that says "match the input character at the current position against the set specified in this set description". Whereas the compiled IL would contain code that effectively says, "match the input character at the current position against `'a'` or `'c'`". This special casing and the ability to perform optimizations based on knowledge of the pattern are some of the main reasons that specifying `RegexOptions.Compiled` yields much faster-matching throughput than the interpreter.

There are several downsides to `RegexOptions.Compiled`. The most impactful is that it is costly to construct. Not only are all of the same costs paid as for the interpreter, but it then needs to compile the resulting `RegexNode` tree and generated opcodes/operands into IL, which adds non-trivial expense. The generated IL further needs to be JIT-compiled on first use, leading to even more expense at startup. `RegexOptions.Compiled` represents a fundamental tradeoff between overheads on the first use and overheads on every subsequent use. The use of <xref:System.Reflection.Emit?displayProperty=nameWithType> also inhibits the use of `RegexOptions.Compiled` in certain environments; some operating systems don't permit dynamically generated code to be executed, and on such systems, `Compiled` becomes a no-op.

## Source generation

.NET 7 introduced a new `RegexGenerator` source generator. A *source generator* is a component that plugs into the compiler and augments the compilation unit with additional source code. The .NET SDK (version 7 and later) includes a source generator that recognizes the <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> attribute on a partial method that returns `Regex`. The source generator provides an implementation of that method that contains all the logic for the `Regex`. For example, you previously might have written code like this:

```csharp
private static readonly Regex s_abcOrDefGeneratedRegex =
    new(pattern: "abc|def",
        options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

private static void EvaluateText(string text)
{
    if (s_abcOrDefGeneratedRegex.IsMatch(text))
    {
        // Take action with matching text
    }
}
```

To use the source generator, you rewrite the previous code as follows:

```csharp
[GeneratedRegex("abc|def", RegexOptions.IgnoreCase, "en-US")]
private static partial Regex AbcOrDefGeneratedRegex();

private static void EvaluateText(string text)
{
    if (AbcOrDefGeneratedRegex().IsMatch(text))
    {
        // Take action with matching text
    }
}
```

> [!TIP]
> The `RegexOptions.Compiled` flag is ignored by the source generator, thus it's not needed in the source-generated version.

The generated implementation of `AbcOrDefGeneratedRegex()` similarly caches a singleton `Regex` instance, so no additional caching is needed to consume code.

The following image is a screen capture of the source generated cached instance, `internal` to the `Regex` subclass that the source generator emits:

:::image type="content" source="media/regular-expression-source-generators/cached-instance.png" alt-text="Cached regex static field":::

But as can be seen, it's not just doing `new Regex(...)`. Rather, the source generator is emitting as C# code a custom `Regex`-derived implementation with logic similar to what `RegexOptions.Compiled` emits in IL. You get all the throughput performance benefits of `RegexOptions.Compiled` (more, in fact) and the start-up benefits of `Regex.CompileToAssembly`, but without the complexity of `CompileToAssembly`. The source that's emitted is part of your project, which means it's also easily viewable and debuggable.

:::image type="content" source="media/regular-expression-source-generators/debuggable-source.png" lightbox="media/regular-expression-source-generators/debuggable-source.png" alt-text="Debugging through source-generated Regex code":::

> [!TIP]
> In Visual Studio, right-click on your partial method declaration and select **Go To Definition**. Or, alternatively, select the project node in **Solution Explorer**, then expand **Dependencies** > **Analyzers** > **System.Text.RegularExpressions.Generator** > **System.Text.RegularExpressions.Generator.RegexGenerator** > _RegexGenerator.g.cs_ to see the generated C# code from this regex generator.

You can set breakpoints in it, you can step through it, and you can use it as a learning tool to understand exactly how the regex engine is processing your pattern with your input. The generator even generates [triple-slash (XML) comments](../../csharp/language-reference/xmldoc/index.md) to help make the expression understandable at a glance and where it's used.

:::image type="content" source="media/regular-expression-source-generators/xml-comments.png" lightbox="media/regular-expression-source-generators/xml-comments.png" alt-text="Generated XML comments describing regex":::

## Inside the source-generated files

With .NET 7, both the source generator and `RegexCompiler` were almost entirely rewritten, fundamentally changing the structure of the generated code. This approach has been extended to handle all constructs (with one caveat), and both `RegexCompiler` and the source generator still map mostly 1:1 with each other, following the new approach. Consider the source generator output for one of the primary functions from the `abc|def` expression:

```csharp
private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
{
    int pos = base.runtextpos;
    int matchStart = pos;
    ReadOnlySpan<char> slice = inputSpan.Slice(pos);

    // Match with 2 alternative expressions, atomically.
    {
        if (slice.IsEmpty)
        {
            return false; // The input didn't match.
        }

        switch (slice[0])
        {
            case 'A' or 'a':
                if ((uint)slice.Length < 3 ||
                    !slice.Slice(1).StartsWith("bc", StringComparison.OrdinalIgnoreCase)) // Match the string "bc" (ordinal case-insensitive)
                {
                    return false; // The input didn't match.
                }

                pos += 3;
                slice = inputSpan.Slice(pos);
                break;

            case 'D' or 'd':
                if ((uint)slice.Length < 3 ||
                    !slice.Slice(1).StartsWith("ef", StringComparison.OrdinalIgnoreCase)) // Match the string "ef" (ordinal case-insensitive)
                {
                    return false; // The input didn't match.
                }

                pos += 3;
                slice = inputSpan.Slice(pos);
                break;

            default:
                return false; // The input didn't match.
        }
    }

    // The input matched.
    base.runtextpos = pos;
    base.Capture(0, matchStart, pos);
    return true;
}
```

The goal of the source-generated code is to be understandable, with an easy-to-follow structure, with comments explaining what's being done at each step, and in general with code emitted under the guiding principle that the generator should emit code as if a human had written it. Even when backtracking is involved, the structure of the backtracking becomes part of the structure of the code, rather than relying on a stack to indicate where to jump next. For example, here's the code for the same generated matching function when the expression is `[ab]*[bc]`:

```csharp
private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
{
    int pos = base.runtextpos;
    int matchStart = pos;
    int charloop_starting_pos = 0, charloop_ending_pos = 0;
    ReadOnlySpan<char> slice = inputSpan.Slice(pos);

    // Match a character in the set [ABab] greedily any number of times.
    //{
        charloop_starting_pos = pos;

        int iteration = slice.IndexOfAnyExcept(Utilities.s_ascii_600000006000000);
        if (iteration < 0)
        {
            iteration = slice.Length;
        }

        slice = slice.Slice(iteration);
        pos += iteration;

        charloop_ending_pos = pos;
        goto CharLoopEnd;

        CharLoopBacktrack:

        if (Utilities.s_hasTimeout)
        {
            base.CheckTimeout();
        }

        if (charloop_starting_pos >= charloop_ending_pos ||
            (charloop_ending_pos = inputSpan.Slice(charloop_starting_pos, charloop_ending_pos - charloop_starting_pos).LastIndexOfAny(Utilities.s_ascii_C0000000C000000)) < 0)
        {
            return false; // The input didn't match.
        }
        charloop_ending_pos += charloop_starting_pos;
        pos = charloop_ending_pos;
        slice = inputSpan.Slice(pos);

        CharLoopEnd:
    //}

    // Advance the next matching position.
    if (base.runtextpos < pos)
    {
        base.runtextpos = pos;
    }

    // Match a character in the set [BCbc].
    if (slice.IsEmpty || ((uint)((slice[0] | 0x20) - 'b') > (uint)('c' - 'b')))
    {
        goto CharLoopBacktrack;
    }

    // The input matched.
    pos++;
    base.runtextpos = pos;
    base.Capture(0, matchStart, pos);
    return true;
}
```

You can see the structure of the backtracking in the code, with a `CharLoopBacktrack` label emitted for where to backtrack to and a `goto` used to jump to that location when a subsequent portion of the regex fails.

If you look at the code implementing `RegexCompiler` and the source generator, they will look extremely similar: similarly named methods, similar call structure, and even similar comments throughout the implementation. For the most part, they result in identical code, albeit one in IL and one in C#. Of course, the C# compiler is then responsible for translating the C# into IL, so the resulting IL in both cases likely won't be identical. The source generator relies on that in various cases, taking advantage of the fact that the C# compiler will further optimize various C# constructs. There are a few specific things the source generator will thus produce more optimized matching code than does `RegexCompiler`. For example, in one of the previous examples, you can see the source generator emitting a switch statement, with one branch for `'a'` and another branch for `'b'`. Because the C# compiler is very good at optimizing switch statements, with multiple strategies at its disposal for how to do so efficiently, the source generator has a special optimization that `RegexCompiler` does not. For [alternations](alternation-constructs-in-regular-expressions.md#Either_Or), the source generator looks at all of the branches, and if it can prove that every branch begins with a different starting character, it will emit a switch statement over that first character and avoid outputting any backtracking code for that alternation.

Here's a slightly more complicated example of that. Alternations are more heavily analyzed to determine whether it's possible to refactor them in a way that will make them more easily optimized by the backtracking engines and that will lead to simpler source-generated code. One such optimization supports extracting common prefixes from branches, and if the alternation is atomic such that ordering doesn't matter, reordering branches to allow for more such extraction. You can see the impact of that for the following weekday pattern `Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday`, which produces a matching function like this:

```csharp
private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
{
    int pos = base.runtextpos;
    int matchStart = pos;
    char ch;
    ReadOnlySpan<char> slice = inputSpan.Slice(pos);

    // Match with 6 alternative expressions, atomically.
    {
        int alternation_starting_pos = pos;

        // Branch 0
        {
            if ((uint)slice.Length < 6 ||
                !slice.StartsWith("monday", StringComparison.OrdinalIgnoreCase)) // Match the string "monday" (ordinal case-insensitive)
            {
                goto AlternationBranch;
            }

            pos += 6;
            slice = inputSpan.Slice(pos);
            goto AlternationMatch;

            AlternationBranch:
            pos = alternation_starting_pos;
            slice = inputSpan.Slice(pos);
        }

        // Branch 1
        {
            if ((uint)slice.Length < 7 ||
                !slice.StartsWith("tuesday", StringComparison.OrdinalIgnoreCase)) // Match the string "tuesday" (ordinal case-insensitive)
            {
                goto AlternationBranch1;
            }

            pos += 7;
            slice = inputSpan.Slice(pos);
            goto AlternationMatch;

            AlternationBranch1:
            pos = alternation_starting_pos;
            slice = inputSpan.Slice(pos);
        }

        // Branch 2
        {
            if ((uint)slice.Length < 9 ||
                !slice.StartsWith("wednesday", StringComparison.OrdinalIgnoreCase)) // Match the string "wednesday" (ordinal case-insensitive)
            {
                goto AlternationBranch2;
            }

            pos += 9;
            slice = inputSpan.Slice(pos);
            goto AlternationMatch;

            AlternationBranch2:
            pos = alternation_starting_pos;
            slice = inputSpan.Slice(pos);
        }

        // Branch 3
        {
            if ((uint)slice.Length < 8 ||
                !slice.StartsWith("thursday", StringComparison.OrdinalIgnoreCase)) // Match the string "thursday" (ordinal case-insensitive)
            {
                goto AlternationBranch3;
            }

            pos += 8;
            slice = inputSpan.Slice(pos);
            goto AlternationMatch;

            AlternationBranch3:
            pos = alternation_starting_pos;
            slice = inputSpan.Slice(pos);
        }

        // Branch 4
        {
            if ((uint)slice.Length < 6 ||
                !slice.StartsWith("fr", StringComparison.OrdinalIgnoreCase) || // Match the string "fr" (ordinal case-insensitive)
                ((((ch = slice[2]) | 0x20) != 'i') & (ch != 'İ')) || // Match a character in the set [Ii\u0130].
                !slice.Slice(3).StartsWith("day", StringComparison.OrdinalIgnoreCase)) // Match the string "day" (ordinal case-insensitive)
            {
                goto AlternationBranch4;
            }

            pos += 6;
            slice = inputSpan.Slice(pos);
            goto AlternationMatch;

            AlternationBranch4:
            pos = alternation_starting_pos;
            slice = inputSpan.Slice(pos);
        }

        // Branch 5
        {
            // Match a character in the set [Ss].
            if (slice.IsEmpty || ((slice[0] | 0x20) != 's'))
            {
                return false; // The input didn't match.
            }

            // Match with 2 alternative expressions, atomically.
            {
                if ((uint)slice.Length < 2)
                {
                    return false; // The input didn't match.
                }

                switch (slice[1])
                {
                    case 'A' or 'a':
                        if ((uint)slice.Length < 8 ||
                            !slice.Slice(2).StartsWith("turday", StringComparison.OrdinalIgnoreCase)) // Match the string "turday" (ordinal case-insensitive)
                        {
                            return false; // The input didn't match.
                        }

                        pos += 8;
                        slice = inputSpan.Slice(pos);
                        break;

                    case 'U' or 'u':
                        if ((uint)slice.Length < 6 ||
                            !slice.Slice(2).StartsWith("nday", StringComparison.OrdinalIgnoreCase)) // Match the string "nday" (ordinal case-insensitive)
                        {
                            return false; // The input didn't match.
                        }

                        pos += 6;
                        slice = inputSpan.Slice(pos);
                        break;

                    default:
                        return false; // The input didn't match.
                }
            }

        }

        AlternationMatch:;
    }

    // The input matched.
    base.runtextpos = pos;
    base.Capture(0, matchStart, pos);
    return true;
}
```

At the same time, the source generator has other issues to contend with that simply don't exist when outputting to IL directly. If you look a couple of code examples back, you can see some braces somewhat strangely commented out. That's not a mistake. The source generator is recognizing that, if those braces weren't commented out, the structure of the backtracking is relying on jumping from outside of the scope to a label defined inside of that scope; such a label would not be visible to such a `goto` and the code would fail to compile. Thus, the source generator needs to avoid there being a scope in the way. In some cases, it'll simply comment out the scope as was done here. In other cases where that's not possible, it may sometimes avoid constructs that require scopes (such as a multi-statement `if` block) if doing so would be problematic.

The source generator handles everything `RegexCompiler` handles, with one exception. As with handling `RegexOptions.IgnoreCase`, the implementations now use a casing table to generate sets at construction time, and how `IgnoreCase` backreference matching needs to consult that casing table. That table is internal to `System.Text.RegularExpressions.dll`, and for now, at least, the code external to that assembly (including code emitted by the source generator) does not have access to it. That makes handling `IgnoreCase` backreferences a challenge in the source generator and they aren't supported. This is the one construct not supported by the source generator that is supported by `RegexCompiler`. If you try to use a pattern that has one of these (which is rare), the source generator won't emit a custom implementation and will instead fall back to caching a regular `Regex` instance:

:::image type="content" source="media/regular-expression-source-generators/cached-instance-fallback.png" lightbox="media/regular-expression-source-generators/cached-instance-fallback.png" alt-text="Unsupported regex still being cached":::

Also, neither `RegexCompiler` nor the source generator supports the new `RegexOptions.NonBacktracking`. If you specify `RegexOptions.Compiled | RegexOptions.NonBacktracking`, the `Compiled` flag will just be ignored, and if you specify `NonBacktracking` to the source generator, it will similarly fall back to caching a regular `Regex` instance.

## When to use it

The general guidance is if you can use the source generator, use it. If you're using `Regex` today in C# with arguments known at compile time, and especially if you're already using `RegexOptions.Compiled` (because the regex has been identified as a hot spot that would benefit from faster throughput), you should prefer to use the source generator. The source generator will give your regex the following benefits:

- All the throughput benefits of `RegexOptions.Compiled`.
- The startup benefits of not having to do all the regex parsing, analysis, and compilation at run time.
- The option of using ahead-of-time compilation with the code generated for the regex.
- Better debuggability and understanding of the regex.
- The possibility to reduce the size of your trimmed app by trimming out large swaths of code associated with `RegexCompiler` (and potentially even reflection emit itself).

When used with an option like `RegexOptions.NonBacktracking` for which the source generator can't generate a custom implementation, it will still emit caching and XML comments that describe the implementation, making it valuable. The main downside of the source generator is that it emits additional code into your assembly, so there's the potential for increased size. The more regexes in your app and the larger they are, the more code will be emitted for them. In some situations, just as `RegexOptions.Compiled` might be unnecessary, so too might be the source generator. For example, if you have a regex that's needed only rarely and for which throughput doesn't matter, it could be more beneficial to just rely on the interpreter for that sporadic usage.

> [!IMPORTANT]
> .NET 7 includes an [analyzer](../../fundamentals/syslib-diagnostics/syslib1040-1049.md) that identifies the use of `Regex` that could be converted to the source generator, and a fixer that does the conversion for you:
>
> :::image type="content" source="media/regular-expression-source-generators/convert-to-regexgenerator.png" lightbox="media/regular-expression-source-generators/convert-to-regexgenerator.png" alt-text="RegexGenerator analyzer and fixer":::

## See also

- [SYSLIB diagnostics for regex source generation](../../fundamentals/syslib-diagnostics/syslib1040-1049.md)
- [.NET regular expressions](regular-expressions.md)
- [Backtracking in regular expressions](backtracking-in-regular-expressions.md)
- [Compilation and reuse in regular expressions](compilation-and-reuse-in-regular-expressions.md)
- [Source generators](../../csharp/roslyn-sdk/index.md#source-generators)
- [.NET Blog: Regular Expression improvements in .NET 7](https://devblogs.microsoft.com/dotnet/regular-expression-improvements-in-dotnet-7)
