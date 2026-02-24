---
applyTo: docs/**/*.md,includes/**/*.md
description: 'Provides goals for tasks involving reorganizing the C# guide around the concept of "Everyday C#".'
---
# Everyday C# goals

For every section in the C# Guide, we try to follow the general order of the C# standard: In other words, cover concepts that fit in a given section of the C# Guide in the order they are covered in the standard. This is not to say that everything in the C# standard is in every section of the C# Guide. Rather, the order of the journey should be similar.

Anything that is not in the standard (Coding style policies, compiler switches, compiler error messages and are added after the coverage of Documentation Comments, which is the last part of the standard covered in our docs.)

## Proposed sections

The TOC in the C# Guide represents an older style. Instead, the new major sections should be:

- Get Started (docs/csharp/tour-of-csharp) *completed*
- Fundamentals (docs/csharp/fundamentals) *in progress*
- What's new in C# (docs/csharp/whats-new) *continuously updated*
- Language Integrated Query (LINQ) (docs/csharp/linq) *Recently updated*
- Asynchronous programming (docs/csharp/async) *Not complete*
- Advanced Topics (docs/csharp/advanced-topics) *Not complete*
- Other C# documentation
  - Language reference
  - C# standard

As we catalog the content in the C# Guide, there may be other focus topic areas that are discovered. When we find those, we should consider new sections in the area around "Language Integrated Query", "Asynchronous programming", and "Advanced topics". If a focus area only applies to advanced scenarios, it should be under the "Advanced topics" section (like the roslyn SDK docs).

For this project, the "C# Standard" is outside of scope, and won't be modified.

Everything under the following headings will move to new locations under the above headings, if possible.

- Tutorials
- C# Concepts
- How to C# articles
- C# Programming Guide
- The .NET Compiler Platform SDK (roslyn) should move under "Advanced topics"

There may be instances where content under the "C# Programming guide" is better moved to the "Language reference" section.

## Presenting material in a logical order

The C# standard won't be modified for this project. However, the order of the C# standard does provide a template for ordering material in the other sections.

You can think of each of the major sections as adding more complexity and completeness to the reader's understanding of C#:

- ***Get started*** is the briefest overview to learn what C# is like.
- ***Fundamentals*** peels back another layer or two to learn more concepts that are used in almost all C# programs.
- ***Focus on...*** sections are deep dives into a single area of the language. These areas typically have more complexity and require more coverage. LINQ, Asynchronous programming, and Advanced concepts are examples.
- ***Language reference*** is an informative treatment of the language specification. The audience is C# developers, not implementers of compilers or other tools.
- ***C# Standard*** is the normative language specification. This is the authoritative reference to the language.

The order of the above sections is important for navigation: In almost all cases, earlier sections should link to later sections for readers to "learn more". Later sections should assume readers understand any concept covered in an earlier section.

## Organizing for learners

The C# Guide and related MS Learn materials serve three distinct audiences. Each of those audiences require different content organization for their specific journey learning C# and .NET. These notes describe those journeys, and then propose an organization for the C# Guide to support those journeys.

The current organization of the C# Guide reflects the history of the documentation updates, and therefore the history of the product. For example, the *LINQ* section reflects features added in C# 3.0; the *async* section reflects features added in C# 5.0. Throughout the guide, dedicated sections reflect the first release when that feature was added. This results in a poor experience. Readers must understand 20 years of C# history before navigating the guide well. This only serves developers that have used the language and platform for years. It doesn't help developers learn today's language or the platform quickly. This experience harms our ability to attract new developers to the platform.

The new organization intends to provide a better experience for all developers. Those new to C# learn the most common scenarios and coding patterns used today. Experienced developers quickly learn how they can update their skills, while still finding all the information for older paradigms.

## Data

The current organization means that many of the pages getting the most traffic represent features and techniques that are older. Examples in the top 30 topics (between 36,000 and 13,000 unique visitors per month) include:

- 2: [How to convert a string to a number - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number)
- 4: [Arrays - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/)
- 6: [Single-Dimensional Arrays - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)
- 7: [Extension Methods - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
- 12: [Multidimensional Arrays - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays)
- 20: [Named and Optional Arguments - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments)
- 21: [Main() and command-line arguments](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/main-command-line)
- 24: [How to initialize a dictionary with a collection initializer - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer)
- 25: [How to read from a text file - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file)
- 28: [Using Properties - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties)
- 30: [Casting and type conversions - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions)

All the preceding topics receive more traffic than topics we'd like more developers to see:

- 33: [Use record types - C# tutorial](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records) - (13,000 unique visitors per month)
- 42: [Pattern matching overview - C# guide](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching) - (10,000)
- 51: [Local functions - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions) - (9,500)
- 88: [Top-level statements - programs without Main methods](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements) - (5,800)
- 97: [Discards - unassigned discardable variables](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards) - (5000)
- 102: [Deconstructing tuples and other types](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct) - (5000)
- 121: [Expression-bodied members - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members) - (4000)
- 129: [Resolve nullable warnings](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-warnings) - (3500)
- 131: [Top-level statements - C# tutorial](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/top-level-statements) - (3500)
- 144: [Explore ranges of data using indices and ranges](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/ranges-indexes) - (3000)
- 149: [Update your codebase to use nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-migration-strategies) - (2750)
- 166: [Records](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records) - (2126)
- 177: [Generate and consume async streams](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/generate-consume-asynchronous-stream) - (1800)
- 181: [Tutorial: Build algorithms with pattern matching](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/pattern-matching)  - (1700)
- 184: [Safely update interfaces using default interface methods in C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/default-interface-methods-versions) - (1600)
- 226: [Use patterns in objects - C# tutorial](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/patterns-objects) - (920)
- 249: [Create mixin types using default interface methods](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/mixins-with-default-interface-methods) - (707)
- 272: [String interpolation - C# tutorial](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/exploration/interpolated-strings-local) - (525)

The rankings and traffic reflects the organization of the C# Guide. By better focusing on the current audience, with an emphasis on new C# developers, we'll drive more traffic to the articles describing the current idioms.

## Audiences

- ***New developer***: This person has never written a program before. They've never read code. C# will be their first experience reading and writing programs. Their goal for the journey is to become excited about programming. Initially, they are exploring if programming is something they'll enjoy. If so, they want to become excited by creating programs.
- ***Student***: These are people in an academic program to learn software development. They are learning C# for the first time.
- ***Early in career***: These are people who are in their first or second job as a software developer. This is their first job using C#.
- ***Professional***: These are people with several years of software development experience, but are new to C#. They might have prior knowledge about C#'s history that's no longer correct (Windows only, closed source). We may occasionally identify the following subgroups of professinal developers:
  - ***New to C# developer***: This person has experience developing software, but is new to the C# language. They may be new to the field, or more experienced. They've likely seen programs written in some C-based language (JavaScript, Java, C++, or C). They are unfamiliar with the platform. Their motivation may be internal (they want to learn C#) or external (they've taken a position where the codebase is in C#.) They'll likely map C# concepts unto their current programming environment.
  - ***Legacy C# developer***: This person has been writing C#for some time. They can get the job done, but are missing opportunities for improvement. New language or platform features are unknown. Their comfort level with their own existing practices are a disincentive to learn new techniques.
  - ***Current C# developer***: This person already uses C# regularly. They are looking to gain more knowledge.

To help readers navigate the C# Guide, overviews in each section should provide guidance on who should read these articles.

## C# Guide sections and content

Each of the major sections of the C# Guide support different audience members in different stages of their journey. The stage of the journey impacts the goals of the reader. Those, in kind, impact the content that best support the reader in that moment.

### Get started

*Get started* gives the reader their first impression of C#. The purpose is to help the reader decide if they want to learn more about the platform and the language. To achieve these goals, this content adheres to the following guidelines:

- **Minimize content**: The average time to complete this section should be an hour. Someone going through it quickly could complete it in under 30 minutes.
- **No prerequisites**: We can't expect the reader to install SDKs and tools before deciding to invest more time.
- **Maximize interactivity**: The reader wants immediate satisfaction by creating code for their investment. Deeper learning of all concepts will happen after the reader has decided to invest.

By completing this section, the reader has learned to read and write methods in C#. They've learned to consume the most commonly used types in the BCL, and know that the BCL contains many more types and capabilities. They can consume types, although aren't yet confident defining them. This section gives the reader information to take the following next actions:

1. **Download the SDK**: Further learning and require a local SDK.
1. **Install tools**: Further lessons can require VS Code, or Visual Studio.
1. **Invest time learning**: Further lessons can include more conceptual content.

The reader has decided to invest time learning more about C#. They have seen enough snippets of C# that they can read C# code and generally understand it. They won't yet recognize every keyword, or every concept, but will understand enough that they can reason about the rest. They will continue with the *Fundamentals* section.

### Fundamentals

*Fundamentals* teaches the reader the language constructs that (almost) every C# developer uses (almost) everyday. These are the techniques and constructs that are at your fingertips for many tasks. The purpose is to give the reader enough skills in C# concepts that after finishing, a reader should be ready for an entry level programming role. (Those readers that have previous programming experience would be ready for a more senior role using C#). The reader has made the decision to learn C#, but doesn't have experience with either yet. This section focuses on concepts that apply to any .NET Workload. The reader should be able to complete this entire section in a month. To achieve these goals, this section adheres to the following guidelines:

- **Avoid specialized techniques**: Readers may later focus on any given workload. Samples or examples that require significant knowledge of a given workload will lose readers.
- **Prefer recent concepts**: In almost all cases, there are multiple ways to write code for a given scenario. In our docs, we should prefer the modern syntax.
- **Build robust examples**: Readers need to learn how to write code for a professional use. That means these samples should demonstrate resilient coding practices.

You can consider the "Fundamentals" section to cover "Everyday C#: The 20% of the language that 80% of C# developers will use everyday."

The samples in this section use the more popular workloads: web, console application, class library, MAUI. Avoid platform specific workloads (WPF, Xamarin iOS, etc), and less common workloads, like Unity or Roslyn analyzers because they limit the audience. Where a UI toolkit is used (either web or MAUI), the sample should not expect experience in those workloads.

We help our readers evolve as the language evolves. To do that, they need to see those concepts used often. Therefore, examples in this section will use the latest C# features as appropriate. Where needed, this section should alert uses to earlier syntax choices they are likely to see often. One example is that this section will primarily use top-level statements in examples. However, it will explain the classic `public static class Program` and `public static void Main` syntax because of its prevalence today.

The examples in this section should demonstrate techniques used in most professional applications. However, that doesn't mean using advanced techniques for any given concept. Exception handling and Task based asynchronous programming are two examples that demonstrate this. Professional programs require error reporting, handling and recovery. The examples in this section won't demonstrate every possible exception handling technique, but must demonstrate how to throw exceptions to indicate error conditions, how to recover when a program can, and how to safely exit without corrupting data. In the case of Task based asynchronous programming, this section must explain the basics of using `await` and declaring methods using the `async` modifier. This section will not explain more specialized techniques of waiting on one of many tasks, cancelling tasks, or using `ValueTask`. (I still need to decide if discussing `ConfigureAwait` fits here.)

Upon finishing this section, the reader is confident reading and writing C#. They should be familiar with the expressions and statements up to and including the latest C# version. This includes areas like query expressions (LINQ), pattern matching expressions, and range and index expressions. They know common types in the BCL and can find others with reasonable searches for assemblies, namespaces and NuGet packages. They should be confident creating types. They should be confident deciding if a new type should be a `record`, `record struct`, `struct` or `class`. They should be able to create interfaces for common contracts. They can continue to explore a single workload, or one of the following "focus" sections.

More details on this section are described in the [Everyday C# content](everyday-csharp.md) document.

### Whats new

This section is the only section still focused on the existing C# community. Its purpose is to help developers find the new features as quickly as possible and learn to integrate them into their regular programming practices. This section also covers the overall history of the language, and any recent breaking changes developers should be aware of.

This section won't substantially change.

### Focus on ... sections

Each of these sections focus on an area of the C# language. These sections cover lesson common scenarios for each section than are covered in the fundamentals section. Readers come to each of these sections to learn about that area of the language and libraries in more depth. While each section can't cover every possible scenario, it will cover all scenarios that drove the inclusion of a language feature.

A partial list of sections includes:

- async programming: all you ever wanted to know about async / await and task based programming.
- LINQ and query expressions: Full coverage of query expressions and the equivalent fluent syntax. Cover the distinction between an `IEnumerable<T>` implementation and an `IQueryable<T>` implementation.
- Industrial C#: Yeah, this needs a better name. It's techniques for managing larger scale applications. Things like using assmeblies, namespaces, explicit interface implementation, partial classes and methods, and `#if` directives for conditional compilation.
- Roslyn APIs and code generators: Learn to build analyzers, code fixes, and code generators.
- Techniques for increasing performance, primarily for minimizing allocations: This section covers techniques to avoid allocations and copying: `ref` and `in` arguments, use of `ref struct` and `ref readonly struct`, authoring APIs that leverage `Span<T>` and `Memory<T>`.

The final "Focus on..." section is the "Advanced topics" section. When content only applies to advanced scenarios, that section should be a sub-section of the "Advanced topics" Focus section.

### Language reference

Readers use the language reference to answer detailed questions about the language. Their goal is to troubleshoot a problem and understand the reasoning behind. Unlike the previous sections, we don't expect visitors to read this section end-to-end. Instead, they'll search for topics that solve their current issue. Once they've found the needed answer, they'll return to their current task. The completeness of the reference section means that other sections may omit techniques we no longer actively promote. Articles in fundamentals or focus sections can link to areas in the reference or standard that show older syntax.

The language reference contains two sections:

- An informative reference: This section is a reader-friendly description of the language. It is not complete enough for the standard, and the language is more approachable than the official standard.
- Options, errors and warnings: This section explains the compiler options, compiler error messages, and compiler warnings messages. This area needs the most investment.

The compiler messages section has two major shortcomings:

1. **Out of date**: None of the warnings added after version 5.0 have been documented. We do get regular issues for warnings that are not documented.
1. **Organization**: Where messages are documented, there is a single page for each error or warning. Historically, this made it easy to direct *F1* traffic to the correct page. We can update the organization without losing this feature. Instead, we should create pages for *classes* of errors and warnings around coming coding mistakes. Some potential classifications could be:
   - *nullable warnings*: All null related warnings could be a single page, with techniques to address them.
   - *type mismatches*: All warnings and errors related to types, assignment, and argument passing.
   - *exception related errors*: All warnings and errors for a throwing, catching, and filtering exceptions could be in one page.

We will prototype the new organization using pages for messages enabled in warnings waves. They have a natural organization, and we can measure the performance of the new pages.

### C# Standard

The C# standard is the language specification. None of the work in this project should modify those articles. This section contains:

- The C# standard: This is the current draft from the ECMA standardization committee. It is the definitive normative reference. That goal makes it less approachable than the informative reference content.
- The latest feature specifications: While the standards committee lags behind the current implementation, we will publish the feature specifications for features not incorporated in the current specification.

### Navigation aids (Hub & landing)

The hub page for the C# guide provides the roadmap for each of the audiences to find their journey through the content:

- The *new developer* should be routed to *Get started* and from their to *Fundamentals*. They should be encouraged to complete the entire *Get started* section.
- The *new to C# developer* should be encouraged to skim the *Get started* TOC, and try any lessons of interest. Once they complete they, the should be directed to *Fundamentals*.
- The *experienced C# developer* should be encouraged to visit the *What's new* section to learn what skills to learn. They should be given the option to dive into any of the *Focus* sections. They should be given the option of visiting the *Fundamentals* section for the latest technique, and the *Reference* section for detailed information.

Some sections may include a 2nd level landing page where that can provide value.
