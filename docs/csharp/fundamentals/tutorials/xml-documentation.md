---
title: Generate XML documentation from your source code
description: "Learn to add `///` comments that generate XML documentation directly from your source code. Learn which tags are available and how to add documentation blocks to types and members."
ms.topic: tutorial  #Don't change.
ms.date: 10/14/2025
ai-usage: ai-assisted
#customer intent: As a developer, I want to generate XML dcoumentation comments so that other developers can use my code successfully.
---
# Tutorial: Create XML documentation

In this tutorial, you take an existing object‑oriented sample (from the preceding [tutorial](oop.md)) and enhance it with XML documentation comments. XML documentation comments provide helpful IntelliSense tooltips, and can participate in generated API reference docs. You learn which elements deserve comments, how to use core tags like `<summary>`, `<param>`, `<returns>`, `<value>`, `<remarks>`, `<example>`, `<seealso>`, `<exception>`, and `<inheritdoc>`, and how consistent, purposeful commenting improves maintainability, discoverability, and collaboration—without adding noise. By the end, you annotated the public surface of the sample, built the project to emit the XML documentation file, and seen how those comments flow directly into the developer experience and downstream documentation tooling.

In this tutorial, you:

> [!div class="checklist"]
> * [Tell the user what they'll do in the tutorial]
> * [Each of these bullet points align with a key H2]
> * [Use these green checkmarks]


## Prerequisites

- The [.NET SDK](https://dot.net)
- Either [Visual Studio](https://visualstudio.com) or [Visual Studio Code](https://visualstudio.com/vscode) with the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Enable XML documentation

Load the project you built in the preceding [object-oriented tutorial](oop.md). If you prefer to start fresh, clone the sample from the `dotnet/docs` repository under the [`snippets/object-oriented-programming`](https://github.com/dotnet/docs/tree/main/docs/csharp/fundamentals/tutorials/snippets/object-oriented-programming) folder.

Next, enable XML documentation output so the compiler emits a `.xml` file alongside your assembly. Edit the project file and add (or confirm) the following property inside a `<PropertyGroup>` element:

```xml
<GenerateDocumentationFile>True</GenerateDocumentationFile>
```

If you're using Visual Studio, you can enable this using the "build" property page.

Build the project. The compiler produces an XML file that aggregates all the `///` comments from publicly visible types and members. That file feeds IntelliSense tooltips, static analysis tools, and downstream documentation generation systems.

Build the project now. You see warnings for any public members that are missing `<summary>` comments. Treat those warnings as a to-do list that helps you provide complete, intentional documentation. Open the generated XML file (it's next to your build output) and inspect the initial structure. At first, the `<members>` section is empty because you didn't add comments yet:

```xml
<?xml version="1.0"?>
<doc>
    <assembly>
        <name>oo-programming</name>
    </assembly>
    <members>
    </members>
</doc>
```

With the file in place, start adding targeted XML comments and immediately verify how each one appears in the generated output.

## Add documentation comments

You now cycle through the build warnings to add concise, useful documentation to the `BankAccount` type. Each warning pinpoints a public member that lacks a `<summary>` (or other required) element. Treat the warning list as a checklist. Avoid adding noise: focus on describing intent, invariants, and important usage constraints—skip restating obvious type names or parameter types.

1. Build the project again. In Visual Studio or Visual Studio Code, open the Error List / Problems panel and filter for documentation warnings (CS1591). At the command line, run a build and review the warnings emitted to the console.
1. Navigate to the first warning (the `BankAccount` class). On the line above the declaration, type `///`. The editor scaffolds a `<summary>` element. Replace the placeholder with a single, action‑focused sentence. The sentence explains the role of the account in the domain. For example,  it tracks transactions and enforces a minimum balance.
1. Add `<remarks>` only if you need to explain behavior. Examples include how minimum balance enforcement works or how account numbers are generated. Keep remarks short.
1. For each property (`Number`, `Owner`, `Balance`), type `///` and write a `<summary>` that states what the value represents—not how a trivial getter returns it. If a property calculates a value (like `Balance`), add a `<value>` element that clarifies the calculation.
1. For each constructor, add `<summary>` plus `<param>` elements describing the meaning of each argument, not just restating the parameter name. If one overload delegates to another, add a concise `<remarks>` element.
1. For methods that can throw, add `<exception>` tags for each intentional exception type. Describe the condition that triggers it. Don't document exceptions thrown by argument validation helpers unless they're part of the public contract.
1. For methods that return a value, add `<returns>` with a short description of what callers receive. Avoid repeating the method name or managed type.
1. Work with the `BankAccount` base class first.

When you're done, open the regenerated XML file and confirm that each member appears with your new elements. A trimmed portion might look like this:

```xml
<member name="T:OOProgramming.BankAccount">
  <summary>Represents a bank account that records transactions and enforces an optional minimum balance.</summary>
  <remarks>Account numbers are generated sequentially when each instance is constructed.</remarks>
</member>
<member name="P:OOProgramming.BankAccount.Balance">
  <summary>Gets the current balance based on all recorded transactions.</summary>
  <value>The net sum of deposits and withdrawals.</value>
</member>
```

> [!TIP]
> Keep summaries to a single sentence. If you need more than one, move secondary context into `<remarks>`.

## Use <inheritdoc/> in derived classes

If you derive from `BankAccount` (for example, a `SavingsAccount` that applies interest), you can inherit base documentation instead of copying it. Add a self-closing `<inheritdoc/>` element inside the derived member's documentation block. You can still append more elements (such as extra `<remarks>` details) after `<inheritdoc/>` to document the specialized behavior.

```csharp
/// <inheritdoc/>
/// <remarks>Adds monthly interest during month-end processing.</remarks>
public class SavingsAccount : BankAccount { /* ... */ }
```

> [!NOTE]
> `<inheritdoc/>` reduces duplication and helps maintain consistency when you update base type documentation later.

After you finish documenting the public surface, build one final time to confirm there are no remaining CS1591 warnings. Your project now produces useful IntelliSense and a structured XML file ready for publishing workflows.

## Build output from comments

You can explore more by trying any of these tools to create output from XML comments:

- [DocFX](https://dotnet.github.io/docfx/): *DocFX* is an API documentation generator for .NET, which currently supports C#, Visual Basic, and F#. It also allows you to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files. Also, DocFX provides you with the flexibility to customize the layout and style of your website through templates. You can also create custom templates.
- [Sandcastle](https://github.com/EWSoftware/SHFB): The *Sandcastle tools* create help files for managed class libraries containing both conceptual and API reference pages. The Sandcastle tools are command-line based and have no GUI front-end, project management features, or automated build process. The Sandcastle Help File Builder provides standalone GUI and command-line-based tools to build a help file in an automated fashion. A Visual Studio integration package is also available for it so that help projects can be created and managed entirely from within Visual Studio.
- [Doxygen](https://github.com/doxygen/doxygen): *Doxygen* generates an online documentation browser (in HTML) or an offline reference manual (in LaTeX) from a set of documented source files. There's also support for generating output in RTF (MS Word), PostScript, hyperlinked PDF, compressed HTML, DocBook, and Unix manual pages. You can configure Doxygen to extract the code structure from undocumented source files.

## Related content

- [XML Doc language reference](../../language-reference/xmldoc/index.md)
- [Recommended XML tags](../../language-reference/xmldoc/recommended-tags.md)
- [XML Documentation examples](../../language-reference/xmldoc/examples.md)
