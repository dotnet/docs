---
title: ".NET regular expression source generators"
description: Learn how to use regular expression source generators to optimize performance of matching algorithms in .NET.
ms.topic: conceptual
ms.date: 10/10/2022
dev_langs:
  - "csharp"
  - "vb"
---

# .NET regular expression source generators

A regular expression, or regex, is a string that enables a developer to express a pattern being searched for, making it a very common way to search text and to extract results as a subset from the searched string. In .NET, the `System.Text.RegularExpressions` namespace is used to define <xref:System.Text.RegularExpressions.Regex> instances (or static methods), and match on user-defined patterns. In this post, you'll learn how to use source generation with `Regex`.

## Source generation

When you write `new Regex("somepattern")`, a few things happen. The specified pattern is parsed, both to ensure validity of the pattern and to transform it it into an internal `RegexNode` tree that represents the parsed regex. The tree is then optimized in various ways, transforming the pattern into a variation that's functionally equivalent but that can be more efficiently executed. The tree is written into a form that can be interpreted as a series of opcodes and operands that provide instructions to the `RegexInterpreter` engine on how to match. When a match is performed, the interpreter simply walks through those instructions, processing them against the input text. When instantiating a new `Regex` instance or calling one of the static methods on `Regex`, the interpreter is the default engine employed.

When you specify <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType>, prior to .NET 7, all of the same construction-time work would be performed. The resulting instructions would be transformed further by the reflection-emit-based compiler into IL instructions that would be written to a few <xref:System.Reflection.Emit.DynamicMethod>s. When a match was performed, those `DynamicMethod`s would be invoked. This IL would essentially do exactly what the interpreter would do, except specialized for the exact pattern being processed. For example, if the pattern contained `[ac]`, the interpreter would see an opcode that said "match the input character at the current position against the set specified in this set description" whereas the compiled IL would contain code that effectively said "match the input character at the current position against `'a'` or `'c'`". This special-casing and the ability to perform optimizations based on knowledge of the pattern are some of the main reasons specifying `RegexOptions.Compiled` yields much faster matching throughput than does the interpreter.

There are, however, several downsides to `RegexOptions.Compiled`. The most impactful, it involves much more construction cost than does using the interpreter. Not only are all of the same costs paid as for the interpreter, but it then needs to compile that resulting `RegexNode` tree and generated opcodes/operands into IL, which adds non-trivial expense. And that generated IL further needs to be JIT-compiled on first use leading to even more expense at startup. `RegexOptions.Compiled` represents a fundamental tradeoff between overheads on first use and overheads on every subsequent use. The use of reflection emit also inhibits the use of `RegexOptions.Compiled` in certain environments; some operating systems don't permit dynamically generated code to be executed, and on such systems, `Compiled` will become a nop.

To help with these issues, the .NET Framework provides a method `Regex.CompileToAssembly`. This method enables the same IL that would have been generated for `RegexOptions.Compiled` to instead be written to a generated assembly on disk, and that assembly can then be referenced as a library from your app. This has the benefits of avoiding the startup overheads involved in parsing, optimizing, and outputting the IL for the expression, as that can all be done ahead of time rather than each time the app is invoked. Further, that assembly could be ahead-of-time compiled with a technology like ngen / crossgen, avoiding most of the associated JIT costs as well.

`Regex.CompileToAssembly` itself has problems, however. First, it was never particularly user friendly. The ergonomics of having to have a utility that would call `CompileToAssembly` in order to produce an assembly your app would reference resulted in relatively little use of this otherwise valuable feature. And on .NET Core, `CompileToAssembly` has never been supported, as it requires the ability to save reflection-emit code to assemblies on disk, which also isn't supported.

.NET 7 addresses all of this with the new `RegexGenerator` source generator. The original compiler for C# was implemented in C/C++. A decade ago, in the grand tradition of compilers being implemented in the language they compile, the "Roslyn" C# compiler was implemented in C#. As part of this, it exposed object models for the entire compilation pipeline, with APIs the compiler itself uses to parse and understand C# but that are also exposed for arbitrary code to use to do the same. It then also enabled components that could plug into the compiler itself, with the compiler handing these "analyzers" all of the information the compiler had built up about the code being compiled and allowing the analyzers to inspect the data and issue additional "diagnostics" (e.g. warnings). More recently, Roslyn also enabled source generators. Just like an analyzer, a source generator is a component that plugs into the compiler and is handed all of the same information as an analyzer, but in addition to being able to emit diagnostics, it can also augment the compilation unit with additional source code. The .NET 7 SDK includes a new source generator which recognizes use of the new `RegexGeneratorAttribute` on a partial method that returns `Regex`, and provides an implementation of that method which implements on your behalf all the logic for the `Regex`. For example, if previously you would have written:

```csharp
private static readonly Regex s_myCoolRegex = new Regex("abc|def", RegexOptions.Compiled | RegexOptions.IgnoreCase);
...
if (s_myCoolRegex.IsMatch(text) { ... }
```

you can now write that as:

```csharp
[RegexGenerator("abc|def", RegexOptions.IgnoreCase)]
private static partial Regex MyCoolRegex();
...
if (MyCoolRegex().IsMatch(text) { ... }
```

The generated implementation of `MyCoolRegex()` similarly caches a singleton `Regex` instance, so no additional caching is needed in consuming code.

:::image type="content" source="media/regular-expression-source-generators/cached-instance.png" alt-text="Cached regex static field":::

But as can be seen, it's not just doing `new Regex(...)`. Rather, the source generator is emitting as C# code a custom `Regex`-derived implementation with logic akin to what `RegexOptions.Compiled` emits in IL. You get all the throughput performance benefits of `RegexOptions.Compiled` (more, in fact) and the start-up benefits of `Regex.CompileToAssembly`, but without the complexity of `CompileToAssembly`. The source that's emitted is part of your project, which means it's also easily viewable and debuggable.

:::image type="content" source="media/regular-expression-source-generators/debuggable-source.png" alt-text="Debugging through source-generated Regex code":::

You can set breakpoints in it, you can step through it, and you can use it as a learning tool to understand exactly how the regex engine is processing your pattern and your input. The generator even spits out XML comments in order to help make the expression understandable at a glance and at the usage site.

:::image type="content" source="media/regular-expression-source-generators/xml-comments.png" alt-text="Generated XML comments describing regex":::

The initial creation of the source generator was a straight port of the `RegexCompiler` used internally to implement `RegexOptions.Compiled`; line-for-line, it would essentially just emit a C# version of the IL that was being emitted. Let's take a simple example:

```csharp
[RegexGenerator(@"(a|bc)d")]
public static partial Regex Example();
```

Here's what the initial incarnation of the source generator emitted for the core matching routine:

```csharp
protected override void Go()
{
    string runtext = base.runtext!;
    int runtextbeg = base.runtextbeg;
    int runtextend = base.runtextend;
    int runtextpos = base.runtextpos;
    int[] runtrack = base.runtrack!;
    int runtrackpos = base.runtrackpos;
    int[] runstack = base.runstack!;
    int runstackpos = base.runstackpos;
    int tmp1, tmp2, ch;
                    
    // 000000 *Lazybranch       addr = 20
    L0:
    runtrack[--runtrackpos] = runtextpos;
    runtrack[--runtrackpos] = 0;
                    
    // 000002 *Setmark
    L1:
    runstack[--runstackpos] = runtextpos;
    runtrack[--runtrackpos] = 1;
                    
    // 000003 *Setmark
    L2:
    runstack[--runstackpos] = runtextpos;
    runtrack[--runtrackpos] = 1;
                    
    // 000004 *Lazybranch       addr = 10
    L3:
    runtrack[--runtrackpos] = runtextpos;
    runtrack[--runtrackpos] = 2;
                    
    // 000006  One              'a'
    L4:
    if (runtextpos >= runtextend || runtext[runtextpos++] != 97)
    {
        goto Backtrack;
    }
                    
    // 000008 *Goto             addr = 12
    L5:
    goto L7;
                    
    // 000010  Multi            "bc"
    L6:
    if (runtextend - runtextpos < 2 ||
        runtext[runtextpos] != 'b' ||
        runtext[runtextpos + 1] != 'c')
    {
        goto Backtrack;
    }
    runtextpos += 2;
                    
    // 000012 *Capturemark      index = 1
    L7:
    tmp1 = runstack[runstackpos++];
    base.Capture(1, tmp1, runtextpos);
    runtrack[--runtrackpos] = tmp1;
    runtrack[--runtrackpos] = 3;
                    
    // 000015  One              'd'
    L8:
    if (runtextpos >= runtextend || runtext[runtextpos++] != 100)
    {
        goto Backtrack;
    }
                    
    // 000017 *Capturemark      index = 0
    L9:
    tmp1 = runstack[runstackpos++];
    base.Capture(0, tmp1, runtextpos);
    runtrack[--runtrackpos] = tmp1;
    runtrack[--runtrackpos] = 3;
                    
    // 000020  Stop
    L10:
    base.runtextpos = runtextpos;
    return;
                    
    Backtrack:
    int limit = base.runtrackcount * 4;
    if (runstackpos < limit)
    {
        base.runstackpos = runstackpos;
        base.DoubleStack(); // might change runstackpos and runstack
        runstackpos = base.runstackpos;
        runstack = base.runstack!;
    }
    if (runtrackpos < limit)
    {
        base.runtrackpos = runtrackpos;
        base.DoubleTrack(); // might change runtrackpos and runtrack
        runtrackpos = base.runtrackpos;
        runtrack = base.runtrack!;
    }
                    
    switch (runtrack[runtrackpos++])
    {
        case 0:
        {
            // 000000 *Lazybranch       addr = 20
            runtextpos = runtrack[runtrackpos++];
            goto L10;
        }
                        
        case 1:
        {
            // 000002 *Setmark
            runstackpos++;
            goto Backtrack;
        }
                        
        case 2:
        {
            // 000004 *Lazybranch       addr = 10
            runtextpos = runtrack[runtrackpos++];
            goto L6;
        }
                        
        case 3:
        {
            // 000012 *Capturemark      index = 1
            runstack[--runstackpos] = runtrack[runtrackpos++];
            base.Uncapture();
            goto Backtrack;
        }
                        
        default:
        {
            global::System.Diagnostics.Debug.Fail($"Unexpected backtracking state {runtrack[runtrackpos - 1]}");
            break;
        }
    }
}
```

That's... intense. But it's the equivalent of what `RegexCompiler` was producing, essentially walking through the operators/operands created for the interpreter and emitting code for each. There are multiple issues with this. First, it's mostly unintelligible. If one of the goals of the source generator is to emit debuggable code, this largely fails at that goal, as even for someone deeply knowledgeable about regular expressions, this isn't going to be very meaningful. Second, there are performance issues; for example, every operation involves pushing and popping state from a "runstack". And third, this loses out on additional possible optimizations, such as being able to use vectorized operations as part of handling specific constructs in the pattern; with this lowered opcode/operand representation, we lose much of the information that could enable the compiler or source generator to add useful improvements based on knowledge of the initial tree.

As such, for .NET 7, after this initial incarnation of the source generator, both the source generator and `RegexCompiler` were almost entirely rewritten, fundamentally changing the structure of the generated code. In .NET 5, we experimented with an alternative approach, and for simple patterns that didn't involve any backtracking, the `RegexCompiler` could emit code that was much cleaner, the primary goal being performance. That approach has now been extended to handle all constructs (with one caveat), and both `RegexCompiler` and the source generator still mapping mostly 1:1 with each other, following the new approach.

Now, here's what the source generator outputs for that same method (which has been renamed) today:

```csharp
private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
{
    int pos = base.runtextpos;
    int matchStart = pos;
    int capture_starting_pos = 0;
    ReadOnlySpan<char> slice = inputSpan.Slice(pos);

    // 1st capture group.
    //{
        capture_starting_pos = pos;

        // Match with 2 alternative expressions.
        //{
            if (slice.IsEmpty)
            {
                UncaptureUntil(0);
                return false; // The input didn't match.
            }

            switch (slice[0])
            {
                case 'a':
                    pos++;
                    slice = inputSpan.Slice(pos);
                    break;

                case 'b':
                    // Match 'c'.
                    if ((uint)slice.Length < 2 || slice[1] != 'c')
                    {
                        UncaptureUntil(0);
                        return false; // The input didn't match.
                    }

                    pos += 2;
                    slice = inputSpan.Slice(pos);
                    break;

                default:
                    UncaptureUntil(0);
                    return false; // The input didn't match.
            }
        //}

        base.Capture(1, capture_starting_pos, pos);
    //}

    // Match 'd'.
    if (slice.IsEmpty || slice[0] != 'd')
    {
        UncaptureUntil(0);
        return false; // The input didn't match.
    }

    // The input matched.
    pos++;
    base.runtextpos = pos;
    base.Capture(0, matchStart, pos);
    return true;
}
```

That's a whole lot more understandable, with a much more followable structure, with comments explaining what's being done at each step, and in general with code emitted under the guiding principle that we want the generator to emit code as if a human had written it. Even when backtracking is involved, the structure of the backtracking gets baked into the structure of the code, rather than relying on a stack to indicate where to jump next. For example, here's the code for the same generated matching function when the expression is `[ab]*[bc]`:

```csharp
private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
{
    int pos = base.runtextpos;
    int matchStart = pos;
    int charloop_starting_pos = 0, charloop_ending_pos = 0;
    ReadOnlySpan<char> slice = inputSpan.Slice(pos);

    // Match a character in the set [ab] greedily any number of times.
    //{
        charloop_starting_pos = pos;
                            
        int iteration = 0;
        while ((uint)iteration < (uint)slice.Length && (((uint)slice[iteration]) - 'a' <= (uint)('b' - 'a')))
        {
            iteration++;
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
            (charloop_ending_pos = inputSpan.Slice(charloop_starting_pos, charloop_ending_pos - charloop_starting_pos).LastIndexOfAny('b', 'c')) < 0)
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

    // Match a character in the set [bc].
    if (slice.IsEmpty || (((uint)slice[0]) - 'b' > (uint)('c' - 'b')))
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

If you look at the code implementing `RegexCompiler` and the source generator, they will look extremely similar: similarly named methods, similar call structure, even similar comments throughout the implementation. For the most part, they spit identical code, albeit one in IL and one in C#. Of course, the C# compiler is then responsible for translating the C# into IL, so the resulting IL in both cases likely won't be identical. In fact, the source generator relies on that in various cases, taking advantage of the fact that the C# compiler will further optimize various C# constructs. There are a few specific things the source generator will thus produce more optimized matching code for than does `RegexCompiler`. For example, in one of the previous examples, you can see the source generator emitting a switch statement, with one branch for `'a'` and another branch for `'b'`. Because the C# compiler is very good at optimizing switch statements, with multiple strategies at its disposal for how to do so efficiently, the source generator has a special optimization that `RegexCompiler` does not. For [alternations](alternation-constructs-in-regular-expressions#Either_Or), the source generator looks at all of the branches, and if it can prove that every branch begins with a different starting character, it will emit a switch statement over that first character and avoid outputting any backtracking code for that alternation (since if every branch has a different starting first character, once we enter the case for that branch, we know no other branch could possibly match).

Here's a slightly more complicated example of that. In .NET 7, alternations are more heavily analyzed to determine whether it's possible to refactor them in a way that will make them more easily optimized by the backtracking engines and that will lead to simpler source-generated code. One such optimization supports extracting common prefixes from branches, and if the alternation is atomic such that ordering doesn't matter, reordering branches to allow for more such extraction. We can see the impact of that for a weekday pattern `Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday`, which produces a matching function like this:

```csharp
private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
{
    int pos = base.runtextpos;
    int matchStart = pos;
    ReadOnlySpan<char> slice = inputSpan.Slice(pos);

    // Match with 5 alternative expressions, atomically.
    {
        if (slice.IsEmpty)
        {
            return false; // The input didn't match.
        }

        switch (slice[0])
        {
            case 'M':
                // Match the string "onday".
                if (!slice.Slice(1).StartsWith("onday"))
                {
                    return false; // The input didn't match.
                }

                pos += 6;
                slice = inputSpan.Slice(pos);
                break;

            case 'T':
                // Match with 2 alternative expressions, atomically.
                {
                    if ((uint)slice.Length < 2)
                    {
                        return false; // The input didn't match.
                    }

                    switch (slice[1])
                    {
                        case 'u':
                            // Match the string "esday".
                            if (!slice.Slice(2).StartsWith("esday"))
                            {
                                return false; // The input didn't match.
                            }

                            pos += 7;
                            slice = inputSpan.Slice(pos);
                            break;

                        case 'h':
                            // Match the string "ursday".
                            if (!slice.Slice(2).StartsWith("ursday"))
                            {
                                return false; // The input didn't match.
                            }

                            pos += 8;
                            slice = inputSpan.Slice(pos);
                            break;

                        default:
                            return false; // The input didn't match.
                    }
                }

                break;

            case 'W':
                // Match the string "ednesday".
                if (!slice.Slice(1).StartsWith("ednesday"))
                {
                    return false; // The input didn't match.
                }

                pos += 9;
                slice = inputSpan.Slice(pos);
                break;

            case 'F':
                // Match the string "riday".
                if (!slice.Slice(1).StartsWith("riday"))
                {
                    return false; // The input didn't match.
                }

                pos += 6;
                slice = inputSpan.Slice(pos);
                break;

            case 'S':
                // Match with 2 alternative expressions, atomically.
                {
                    if ((uint)slice.Length < 2)
                    {
                        return false; // The input didn't match.
                    }

                    switch (slice[1])
                    {
                        case 'a':
                            // Match the string "turday".
                            if (!slice.Slice(2).StartsWith("turday"))
                            {
                                return false; // The input didn't match.
                            }

                            pos += 8;
                            slice = inputSpan.Slice(pos);
                            break;

                        case 'u':
                            // Match the string "nday".
                            if (!slice.Slice(2).StartsWith("nday"))
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

Note how `Thursday` was reordered to be just after `Tuesday`, and how for both the `Tuesday`/`Thursday` pair and the `Saturday`/`Sunday` pair, we end up with multiple levels of switches. In the extreme, if you were to create a long alternation of many different words, the source generator would end up emitting the logical equivalent of a trie, reading each character and `switch`'ing to the branch for handling the remainder of the word.

At the same time, the source generator has other issues to contend with that simply don't exist when outputting to IL directly. If you look a couple of code examples back, you can see some braces somewhat strangely commented out. That's not a mistake. The source generator is recognizing that, if those braces weren't commented out, the structure of the backtracking is relying on jumping from outside of a scope to a label defined inside of that scope; such a label would not be visible to such a `goto` and the code would fail to compile. Thus, the source generator needs to avoid there actually being a scope in the way. In some cases, it'll simply comment out the scope as was done here. In other cases where that's not possible, it may sometimes avoid constructs that require scopes (e.g. a multi-statement `if` block) if doing so would be problematic.

The source generator handles everything `RegexCompiler` handles, with one exception. Earlier in this post we discussed the new approach to handling `RegexOptions.IgnoreCase`, how the implementations now use a casing table to generate sets at construction time, and how `IgnoreCase` backreference matching needs to consult that casing table. That table is internal to `System.Text.RegularExpressions.dll`, and for now at least, code external to that assembly (including code emitted by the source generator) does not have access to it. That makes handling `IgnoreCase` backreferences a challenge in the source generator. We could choose to also output the casing table if it's required, but it's quite a hefty chunk of data to blit into consuming assemblies. So at least for now, `IgnoreCase` backreferences are the one construct not supported by the source generator that is supported by `RegexCompiler`. If you try to use a pattern that has one of these (which, at least according to our research, are very rare), the source generator won't emit a custom implementation and will instead fall back to caching a regular `Regex` instance:

:::image type="content" source="media/regular-expression-source-generators/cached-instance-fallback.png" alt-text="Unsupported regex still being cached":::

Also, neither `RegexCompiler` nor the source generator support the new `RegexOptions.NonBacktracking`. If you specify `RegexOptions.Compiled | RegexOptions.NonBacktracking`, the `Compiled` flag will just be ignored, and if you specify `NonBacktracking` to the source generator, it will similarly fall back to caching a regular `Regex` instance. (It's possible the source generator will support `NonBacktracking` as well in the future, but that's unlikely to happen for .NET 7.)

Finally, the $10 million dollar question: when should you use the source generator?  The general guidance is, if you can use it, use it. If you're using `Regex` today in C# with arguments known at compile-time, and especially if you're already using `RegexOptions.Compiled` (because the regex has been identified as a hot spot that would benefit from faster throughput), you should prefer to use the source generator. The source generator will give your regex all the throughput benefits of `RegexOptions.Compiled`, the startup benefits of not having to do all the regex parsing, analysis, and compilation at runtime, the option of using ahead-of-time compilation with the code generated for the regex, better debugability and understanding of the regex, and even the possibility to reduce the size of your trimmed app by trimming out large swaths of code associated with `RegexCompiler` (and potentially even reflection emit itself). And even if used with an option like `RegexOptions.NonBacktracking` for which it can't yet generate a custom implementation, it will still helpfully emit caching, XML comments describing the implementation, and so on, such that it's still valuable. The main downside of the source generator is that it is emitting additional code into your assembly, so there's the potential for increased size; the more regexes in your app and the larger they are, the more code will be emitted for them. In some situations, just as `RegexOptions.Compiled` may be unnecessary, so too may be the source generator, e.g. if you have a regex that's needed only rarely and for which throughput doesn't matter, it could be more beneficial to just rely on the interpreter for that sporadic usage. However, we're so confident in the general "if you can use it, use it" guidance that .NET 7 will also include an analyzer that identifies use of `Regex` that could be converted to the source generator, and a fixer that does the conversion for you:

:::image type="content" source="media/regular-expression-source-generators/convert-to-regexgenerator.png" alt-text="RegexGenerator analyzer and fixer":::

## Summary

## See also

- [.NET regular expressions](regular-expressions.md)
- [Source Generators](../../csharp/roslyn-sdk/source-generators-overview.md)
