---
title: "Tutorial: Write your first analyzer and code fix"
description: This tutorial provides step-by-step instructions to build an analyzer and code fix using the .NET Compiler SDK (Roslyn APIs).
ms.date: 08/01/2018
ms.custom: mvc
---
# Tutorial: Write your first analyzer and code fix

The .NET Compiler Platform SDK provides the tools you need to create custom warnings that target C# or Visual Basic code. Your **analyzer** contains code that recognizes violations of your rule. Your **code fix** contains the code that fixes the violation. The rules you implement can be anything from code structure to coding style to naming conventions and more. The .NET Compiler Platform provides the framework for running analysis as developers are writing code, and all the Visual Studio UI features for fixing code: showing squiggles in the editor, populating the Visual Studio Error List, creating the "light bulb" suggestions and showing the rich preview of the suggested fixes.

In this tutorial, you'll explore the creation of an **analyzer** and an accompanying **code fix** using the Roslyn APIs. An analyzer is a way to perform source code analysis and report a problem to the user. Optionally, an Analyzer can also provide a Code fix that represents a modification to the user's source code. This tutorial creates an analyzer that finds local variable declarations that could be declared using the `const` modifier but are not. The accompanying code fix modifies those declarations to add the `const` modifier.

## Prerequisites

* [Visual Studio 2017](https://www.visualstudio.com/downloads)
* [.NET Compiler Platform SDK](https://aka.ms/roslynsdktemplates)
* [Getting Started C# Syntax Analysis](../get-started/syntax-analysis.md)
* [Getting Started C# Semantic Analysis](../get-started/semantic-analysis.md)
* [Getting Started C# Syntax Transformation](../get-started/syntax-transformation.md)

## Create the analyzer project

Your analyzer reports to the user any local variable declarations that can be converted to local constants. For example, consider the following code:

```csharp
int x = 0;
Console.WriteLine(x);
```

In the code above, x is assigned a constant value and is never modified. It can be declared using the const modifier:

```csharp
const int x = 0;
Console.WriteLine(x);
```

The analysis to determine whether a variable can be made constant is involved, requiring syntactic analysis, constant analysis of the initializer expression and dataflow analysis to ensure that the variable is never written to. The .NET Compiler Platform provides APIs that make it easier to perform this analysis. The first step is to create a new C# **Analyzer with Code Fix** project.

* In Visual Studio, choose **File -> New -> Project...** to display the New Project dialog.
* Under **Visual C# -> Extensibility**, choose **Analyzer with Code Fix (NuGet + VSIX)**.
* Name your project "**MakeConst**" and click OK.

The Analyzer with Code Fix template creates three projects: one contains the analyzer and code fix, the second is a unit test project, and the third is the VSIX project. The default startup project is the VSIX project. Press **F5** to start the VSIX project. This starts a second instance of Visual Studio that has loaded your new analyzer.

> [!TIP]
> When you run your analyzer, you start a second copy of Visual Studio. This second copy uses a different registry hive to store settings. That enables you to differentiate the visual settings in the two copies of Visual Studio. You can pick a different theme for the experimental run of Visual Studio. In addition, don't roam your settings or login to your Visual Studio account using the experimental run of Visual Studio. That keeps the settings different.
  
In the second Visual Studio instance that you just started, create a new C# Console Application project. Hover over the token with a wavy underline, and the warning text provided by an Analyzer appears.

This Analyzer is provided by the `AnalyzeSymbol` method in the debugger project. So initially, the debugger project contains enough code to create an Analyzer for every type declaration in a C# file whose identifier contains lowercase letters:

![Analyzer reporting warning](media/how-to-write-csharp-analyzer-code-fix/report-warning.png)

Now that you've seen the initial Analyzer in action, close the second Visual Studio instance and return to your Analyzer project.

The template creates the initial `DiagnosticAnalyzer` class, in the **DiagnosticAnalyzer.cs** file. This initial analyzer shows two important properties of every analyzer.

* Every Diagnostic Analyzer must provide a `[DiagnosticAnalyzer]` attribute that describes the language it operates on.
* Every Diagnostic Analyzer must derive from the <xref:Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer> class.

The analyzer project template also creates a test project template for you. Look at the **MakeConstAnalyzerUnitTest.cs** file in the test project. It contains two tests: one that analyzes the empty string, and one that analyzes a snippet of code with a class whose name contains lower case letters. The first shows the general format for a test where your analyzer does not find code that it should change. The second shows the general format for a test where your analyzer finds code that it modifies.

Throughout this tutorial, you'll use a combination of running your analyzer in a second copy of Visual Studio, and adding new unit tests that validate your analyzer and code fix. This combination provides a way to explore your analyzer's capabilities as you build it, and create quality tests to prevent regressions and validate actions quickly. This practice is often a good way to proceed with your analyzers: experiment in Visual Studio, and then write tests as you learn more about the code to spot and change.

## Create the analyzer

The template shows the basic features that are part of any analyzer:

1. Register actions. The actions represent code changes that should trigger your analyzer to examine code for violations. When Visual Studio detects code edits that match a registered action, it calls your analyzer's registered method.
1. Create diagnostics. When your analyzer detects a violation, it creates a diagnostic object that Visual Studio uses to notify the user of the violation.

You register actions in your override of <xref:Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer.Initalize((Microsoft.CodeAnalysis.Diagnostics.AnalysisContext)?displayProperty=nameWithType> method. The actions your register create the diagnostics. In this tutorial, you'll visit **syntax nodes** looking for local declarations, and see which of those have constant values.

### Create the analyzer structure

Open **MakeConstAnalyzer.cs** in Visual Studio. Change the registered action from one that acts on symbols to one that acts on syntax. In the `MakeConstAnalyzerAnalyzer.Initializer` method, find the line that registers the action on symbols:

```csharp
context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
```

Replace it with the following line:

[!code-csharp[Register the node action](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstAnalyzer.cs#RegisterNodeAction "Register a node action")]

After that change, you can delete the `AnalyzeSymbol` method. This analyzer examines <xref:Microsoft.CodeAnalysis.CSharp.SyntaxKind.LocalDeclarationStatement?displayProperty=nameWithType>, not <xref:Microsoft.CodeAnalysis.CSharp.SyntaxKind.NamedType?displayProperty=nameWithType> statements. Then, put your cursor on the `AnalyzeNode` method, press **Ctrl+.** and generate the `AnalyzeNode` method.

This change highlights an important design consideration for every analyzer you write: Visual Studio calls analyzers as the user is editing code. Register actions for the types of code changes that could create something your analyzer should examine. That helps minimize any performance impact for Visual Studio users that load your analyzer.

Next, you should update the string resources:

* Change `AnalyzerTitle` to "Variable can be made constant".
* Change `AnalyzerMessageFormat` to "Can be made constant".
* Change `Description` to "Make Constant".

You can see the update resources in the following figure:

![Update string resources](media/how-to-write-csharp-analyzer-code-fix/update-string-resources.png)

Also, change the `Category` to "Usage" as shown in the following code:
```C#
private const string Category = "Usage";
```

When you're finished, the code in DiagnosticAnalyzer.cs should look like the following code.

```C#
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FirstAnalyzerCS
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class MakeConstAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "MakeConstCS";
        private const string Title = "Variable can be made constant";
        private const string MessageFormat = "Can be made constant";
        private const string Description = "Make Constant";
        private const string Category = "Usage";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.LocalDeclarationStatement);
        }

        private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            throw new NotImplementedException();
        }
    }
}
```

### Spot declarations that are already const

Now you're ready to write the logic to determine whether a local variable can be declared as a const in the AnalyzeNode method. You'll make these changes in steps as you learn about the APIs available to write code that understands code.

Start by performing some syntactic analyzer when your action is invoked. Open **MakeConst.cs**. In the `AnalyzeNode` method, cast the node passed in to the <xref:Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax> type. You can safely assume this cast will succeed because the registered action specifies that type of node.

```C#
var localDeclaration = (LocalDeclarationStatementSyntax)context.Node;
```

To ensure the best performance, the general structure of an action method is to quickly eliminate cases where it won't create or report a diagnostic. The MakeConst analyzer can exit immediately if a local declaration is already a constant. To illustrate this construct, you'll write your first test.

The structure of the unit tests is shown in the two example tests created by the template. Open **MakeConstUnitTests.cs**. The first test, `TestMethod1` shows the structure of a test when you want to verify that analyzed code does not trigger a diagnostic. `TestMethod2` shows the structure of a test when analyzed code triggers a diagnostic and provides a fix.

Change `TestMethod1` to the following code:

[!code-csharp[Don't report diagnostics on const declarations](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#AlreadyConst "Test to ensure no diagnostics are reported on already const definition")]

Run all the unit tests now. This new test passes. After all, your analyzer doesn't do anything yet. Add the following code to `AnalyzeNode` to ensure this test continues to pass:

```csharp
// Only consider local variable declarations that aren't already const.
if (localDeclaration.Modifiers.Any(SyntaxKind.ConstKeyword))
{
    return;
}
```

### Examine declaration initializers

Constant declarations are not the only case where your analyzer can exit quickly. Any variable declaration that doesn't contain an initializer cannot be made constant. Also, any variable declaration whose initializer is not a compile-time constant cannot be made const. Write two new tests that verify these two rules:

[!code-csharp[Don't report diagnostics on declarations that can't be const](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#CantBeConst "Test to ensure no diagnostics are reported when the declaration can't be made const")]

There's one additional C# spec rule that you should take care of with the same code: If a declaration statement includes multiple variables, they must all be const, or none of them can be const. That means one other test to ensure that a diagnostic is not reported when a declaration statement has multiple variables, and not all of them can be made const. That suggests one more test:

[!code-csharp[Don't report diagnostics on multiple declarations if all can't be const](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#MultipleDeclarations "Test to ensure no diagnostics are reported when multiple declarations can't all be made const")]

As before, these tests will pass now. It's time to write the code that checks for these conditions. You'll perform some semantic analysis using the <xref:Microsoft.CodeAnalysis.Diagnostics.SyntaxNodeAnalysisContext>. You use the `context` argument to determine whether the local variable declaration can be made `const`. A <xref:Microsoft.CodeAnalysis.SemanticModel?displayProperty=nameWithType> represents of all semantic information in a single source file. You can earn more in the article that covers [semantic models](../work-with-semantics.md). Add the following code to the `AnalyzeNode` method:

```csharp
// Ensure that all variables in the local declaration have initializers that
// are assigned with constant values.
foreach (var variable in localDeclaration.Declaration.Variables)
{
    var initializer = variable.Initializer;
    if (initializer == null)
    {
        return;
    }

    var constantValue = context.SemanticModel.GetConstantValue(initializer.Value);
    if (!constantValue.HasValue)
    {
        return;
    }
}
```

The first `if` in the preceding code exits as soon one variable declaration that doesn't have an initializer was found. The second `if` returns when a declaration has an initializer that is not a constant.

At this point, your code has found a declaration that is initialized with a constant. The declaration can be made constant provided its value is not modified after it has been initialized. You can illustrate that by creating one more test:

[!code-csharp[Don't report diagnostics when variable is assigned to](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#VariableChangesValue "Test to ensure no diagnostics are reported when the variable declaration is assigned to")]

### Make sure the variable isn't assigned after initialization

You'll use the <xref:Microsoft.CodeAnalysis.SemanticModel?displayProperty=nameWithType> to perform data flow analysis on the local declaration statement. Then, you use the results of this data flow analysis to ensure that none of the local variables are written with a new value anywhere else. Call the <xref:Microsoft.CodeAnalysis.ModelExtensions.GetDeclaredSymbol%2A> extension method to retrieve the <xref:Microsoft.CodeAnalysis.ILocalSymbol> for each variable and checking that it isn't contained with the <xref:Microsoft.CodeAnalysis.DataFlowAnalysis.WrittenOutside%2A?displayProperty=nameWithType> collection of the data flow analysis. Add the following code to `AnalyzeNode` after the closing brace of the `foreach` loop:

[!code-csharp[Use flow analysis to find writes](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstAnalyzer.cs#FlowAnalysis "Use flow analysis to detect writes")]

### Create and report the diagnostic

You're almost done. You've written the code to find a local declaration, and filtered out cases where a local declaration cannot be const. Now, let's write a test the shows a declaration that should be const. Open **MakeConstUnitTests.cs** and change `TestMethod2` to the following test:

[!code-csharp[Report diagnostic when declaration could be const](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#TestMethodIntConstantV1 "Report a diagnostic when a declaration could be const")]

This test does follow the Test Driven Development (TDD) practices. If you run this test, it will fail. There's one step left to perform. With all of the necessary analysis performed, you can create a new <xref:Microsoft.CodeAnalysis.Diagnostic> object that represents a warning for the non-const variable declaration. This Diagnostic will get its metadata from the static Rule template defined above. Add the following line to the bottom of `AnalyzeNode`:

[!code-csharp[Report the diagnostic](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstAnalyzer.cs#ReportDiagnostic "Report the diagnostic")]

At this point, your `AnalyzeNode` method should look like the following code:

```csharp
private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
{
    var localDeclaration = (LocalDeclarationStatementSyntax)context.Node;

    // Only consider local variable declarations that aren't already const.
    if (localDeclaration.Modifiers.Any(SyntaxKind.ConstKeyword))
    {
        return;
    }

    // Ensure that all variables in the local declaration have initializers that
    // are assigned with constant values.
    foreach(var variable in localDeclaration.Declaration.Variables)
    {
        var initializer = variable.Initializer;
        if (initializer == null)
        {
            return;
        }

        var constantValue = context.SemanticModel.GetConstantValue(initializer.Value);
        if (!constantValue.HasValue)
        {
            return;
        }
    }

    // Perform data flow analysis on the local declaration.
    var dataFlowAnalysis = context.SemanticModel.AnalyzeDataFlow(localDeclaration);

    // Retrieve the local symbol for each variable in the local declaration
    // and ensure that it is not written outside of the data flow analysis region.
    foreach (var variable in localDeclaration.Declaration.Variables)
    {
        var variableSymbol = context.SemanticModel.GetDeclaredSymbol(variable);
        if (dataFlowAnalysis.WrittenOutside.Contains(variableSymbol))
        {
            return;
        }
    }

    context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
}
```

Run your tests, and they should pass. Press F5 to run the Analyzer project in a second instance of Visual Studio. In the second Visual Studio instance, create a new C# Console Application project and add a few local variable declarations initialized with constant values to the Main method. You can look at the code in your unit tests for examples to analyze. You'll see that they are reported as warnings as below.

![Can make const warnings](media/make-const-warning.png)

Notice that if you type const before each variable, the warnings are automatically removed. Additionally, changing a variable to const can affect the reporting of other variables. Add the `const` modifier to both `i` and `j`, and you get a new warning on `k` because it can now be `const`.

Congratulations! You've created your first Analyzer using the .NET Compiler Platform APIs to perform non-trivial syntactic and semantic analysis.

## Write the Code Fix

An Analyzer can provide one or more Code Fixes. A Code Fix defines an edit that addresses the reported issue. For the Analyzer that you created, you can provide a Code Fix that inserts the const keyword. The user chooses it from the light bulb UI in the editor and Visual Studio changes the code. To illustrate the change, open **MakeConstUnitTests.cs** and add the following code to the end of your `WhenLocalIntCouldBeConstantAnalyzerReportsOneDiagnosticWithFix` test case:

[!code-csharp[Verify the code fix](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#TestMethodIntConstantFix "Verify the code fix")]

The test you've added instructs the Roslyn APIs to apply the code fix, and then verifies the modified code. This test will fail until we write the code fix. 

### Register your code fix

Open the **CodeFixProvider.cs** file that was already added by the Analyzer with Code Fix template.  This Code Fix is already wired up to the Diagnostic ID produced by your Diagnostic Analyzer, but it doesn't yet implement the right code transform. First you should remove some of the template code. Change the title string to "Make constant":

[!code-csharp[Update the CodeFix title](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstCodeFixProvider.cs#CodeFixTitle "Update the CodeFix title")]

Next, delete the `MakeUppercaseAsync` method. It no longer applies. All Code Fixes derive from <xref:Microsoft.CodeAnalysis.CodeFixesCodeFixProvider>. They all override <xref:Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider.RegisterCodeFixesAsync(Microsoft.CodeAnalysis.CodeFixes.CodeFixContext)?displayProperty=nameWithType> to report available code fixes. In `RegisterCodeFixesAsync`, change the ancestor node type you're searching for to a <xref:Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax> to match the diagnostic:

[!code-csharp[Update the CodeFix title](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstCodeFixProvider.cs#FindDeclarationNode  "Update the CodeFix title")]

Next, change the last line to register a code fix. Your fix will create a new document that results from adding the `const` modifier to an existing declaration:  

[!code-csharp[Register the new code fix](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstCodeFixProvider.cs#RegisterCodeFix  "Register the new code fix")]

The **MakeConstCodeFixProvider.cs** file should look like the following code:

```csharp
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;

namespace FirstAnalyzerCS
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(FirstAnalyzerCSCodeFixProvider)), Shared]
    public class FirstAnalyzerCSCodeFixProvider : CodeFixProvider
    {
        private const string title = "Make constant";

        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(FirstAnalyzerCSAnalyzer.DiagnosticId); }
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            // Find the type declaration identified by the diagnostic.
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<LocalDeclarationStatementSyntax>().First();

            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(
                    title: title,
                    createChangedDocument: c => MakeConstAsync(context.Document, declaration, c),
                    equivalenceKey: title),
                diagnostic);
        }
    }
}
```

### Implement the fix method

Now it's time to implement the MakeConstAsync method, which will transform the original Document into the fixed Document. Place your cursor on the `MakeConstAsync` method call you added in the preceding code. Press **Ctrl+.** and select **Generate Method**. Your new `MakeConstAsync` method will transform the <xref:Microsoft.CodeAnalysis.Document> representing the user's source file into a fixed <xref:Microsoft.CodeAnalysis.Document> that now contains a `const` declaration.

Next, create a new `const` keyword token that you will insert at the front of the declaration statement. Be careful to first remove any leading trivia from the first token of the declaration statement and attach it to the `const` token. Add the following code to the `MakeConstAsync` method:

[!code-csharp[Create a new const keyword token](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstCodeFixProvider.cs#CreateConstToken  "Create the new const keyword token")]

Next, format the new declaration to match C# formatting rules. Formatting your changes to match existing code creates a better experience. Add the following statement immediately after the existing code:

[!code-csharp[Format the new declaration](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstCodeFixProvider.cs#FormatLocal  "Format the new declaration")]

You have to add a new namespace for this code. Click the light bulb and add the suggested `using`. The final step is to make your edit. There are three steps to this process:

1. Get a handle to the existing document.
1. Create a new document by replacing the existing declaration with the new declaration.
1. Return the new document.

Add the following code to the end of the `MakeConstAsync` method:

[!code-csharp[Format the new declaration](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstCodeFixProvider.cs#ReplaceDocument  "Format the new declaration")]

Your `MakeConstAsync` method should look like the following code:

```csharp
private async Task<Document> MakeConstAsync(Document document, LocalDeclarationStatementSyntax localDeclaration, CancellationToken cancellationToken)
{
    // Remove the leading trivia from the local declaration.
    var firstToken = localDeclaration.GetFirstToken();
    var leadingTrivia = firstToken.LeadingTrivia;
    var trimmedLocal = localDeclaration.ReplaceToken(
        firstToken, firstToken.WithLeadingTrivia(SyntaxTriviaList.Empty));

    // Create a const token with the leading trivia.
    var constToken = SyntaxFactory.Token(leadingTrivia, SyntaxKind.ConstKeyword, SyntaxFactory.TriviaList(SyntaxFactory.ElasticMarker));

    // Insert the const token into the modifiers list, creating a new modifiers list.
    var newModifiers = trimmedLocal.Modifiers.Insert(0, constToken);

    // Produce the new local declaration.
    var newLocal = trimmedLocal.WithModifiers(newModifiers);

    // Add an annotation to format the new local declaration.
    var formattedLocal = newLocal.WithAdditionalAnnotations(Formatter.Annotation);

    // Replace the old local declaration with the new local declaration.
    var oldRoot = await document.GetSyntaxRootAsync(cancellationToken);
    var newRoot = oldRoot.ReplaceNode(localDeclaration, formattedLocal);

    // Return document with transformed tree.
    return document.WithSyntaxRoot(newRoot);
}
```

Your code fix is ready to try. Run your tests, and the new test that verifies the fix should pass. Then, try it interactively. Press F5 to run the Analyzer project in a second instance of Visual Studio. In the second Visual Studio instance, create a new C# Console Application project and, like before, add a few local variable declarations initialized with to constant values in the Main method.

```csharp
static void Main(string[] args)
{
    int i = 1;
    int j = 2;
    int k = i + j;
}
```

You'll see that they are reported as warnings and "light bulb" suggestions appear next to them when the editor caret is on the same line. Move the editor caret to one of the squiggly underlines and press Ctrl+. to display the suggestion. Notice that a preview window appears next to the suggestion menu showing what the code will look like after the Code Fix is invoked.

### Improve the quality

Your analyzer works, but some C# expressions that aren't handled correctly:

* The Diagnostic Analyzer's `AnalyzeNode` method does not check to see if the constant value is convertible to the variable type. So, the current implementation will happily convert an incorrect declaration such as int i = "abc"' to a local constant. This test will check that condition:

[!code-csharp[Mismatched types don't raise diagnostics](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#AssignStringToInt "When the variable type and the constant type don't match, there's no diagnostic")]

* Reference types are not handled properly. The only constant value allowed for a reference type is `null`, except in this case of <xref:System.String?displayPropert=nameWIthType>, which allows string literals. In other words, `const string s = "abc"` is legal, but `const object s = "abc"` is not. These two tests verify that condition:

[!code-csharp[Reference types don't raise diagnostics](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#NoReferenceTypes "When the variable type is a reference type other than string, there's no diagnostic")]

* If a variable is declared with the `var` keyword, the Code Fix does the wrong thing and generates a `const var` declaration, which is not supported by the C# language. To fix this bug, the code fix must replace the `var` keyword with the inferred type's name.
Fortunately, all of the above bugs can be addressed using the same techniques that you just learned.

[!code-csharp[Var declarations require types when constant](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst.Test/MakeConstUnitTests.cs#ReplaceVarDeclarationWithConst "Var must be replaced with the type when made const")]

To fix the first bug, first open **DiagnosticAnalyzer.cs** and locate the foreach loop where each of the local declaration's initializers are checked to ensure that they're assigned with constant values. Immediately _before_ the first foreach loop, call `context.SemanicModel.GetTypeInfo()` to retrieve detailed information about the declared type of the local declaration:

[!code-csharp[GetDetailedTypeInformation](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstAnalyzer.cs#GetTypeInfo "Get the detailed information on the types in the declaration")]

Next, add the following code before the closing curly brace of the foreach loop to call `context.SemanticModel.ClassifyConversion()` and determine whether the initializer is convertible to the local declaration type. If there is no conversion, or the conversion is user-defined, the variable can't be a local constant.

[!code-csharp[EnsureConvertibility](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstAnalyzer.cs#EnsureConvertible "Ensure the variable type is convertible to the initializer type")]

Build and run your tests. The `WhenDeclarationIsInvalidNoDiagnosticIsReported` test should pass now.

The next change builds upon the last one. Before the closing curly brace of the same foreach loop, add the following code to check the type of the local declaration when the constant is a string or null.

[!code-csharp[CheckConstantType](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstAnalyzer.cs#SpecialCase "Check that the type can be constant")]

With this code in place, the AnalyzeNode method should look like the following code:

```csharp
private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
{
    var localDeclaration = (LocalDeclarationStatementSyntax)node;

    // Only consider local variable declarations that aren't already const.
    if (localDeclaration.Modifiers.Any(SyntaxKind.ConstKeyword))
    {
        return;
    }

    var variableTypeName = localDeclaration.Declaration.Type;
    var variableType = context.SemanticModel.GetTypeInfo(variableTypeName).ConvertedType;

    // Ensure that all variables in the local declaration have initializers that
    // are assigned with constant values.
    foreach (var variable in localDeclaration.Declaration.Variables)
    {
        var initializer = variable.Initializer;
        if (initializer == null)
        {
            return;
        }

        var constantValue = context.SemanticModel.GetConstantValue(initializer.Value);
        if (!constantValue.HasValue)
        {
            return;
        }

        // Ensure that the initializer value can be converted to the type of the
        // local declaration without a user-defined conversion.
        var conversion = semanticModel.ClassifyConversion(initializer.Value, variableType);
        if (!conversion.Exists || conversion.IsUserDefined)
        {
            return;
        }

        // Special cases:
        //  * If the constant value is a string, the type of the local declaration
        //    must be System.String.
        //  * If the constant value is null, the type of the local declaration must
        //    be a reference type.
        if (constantValue.Value is string)
        {
            if (variableType.SpecialType != SpecialType.System_String)
            {
                return;
            }
        }
        else if (variableType.IsReferenceType && constantValue.Value != null)
        {
            return;
        }
    }

    // Perform data flow analysis on the local declaration.
    var dataFlowAnalysis = semanticModel.AnalyzeDataFlow(localDeclaration);

    // Retrieve the local symbol for each variable in the local declaration
    // and ensure that it is not written outside of the data flow analysis region.
    foreach (var variable in localDeclaration.Declaration.Variables)
    {
        var variableSymbol = semanticModel.GetDeclaredSymbol(variable);
        if (dataFlowAnalysis.WrittenOutside.Contains(variableSymbol))
        {
            return;
        }
    }

    context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
}
```

Fixing the third test requires a little more code to replace the var' keyword with the correct type name. Return to **CodeFixProvider.cs** and replace the code at the comment that reads "Produce the new local declaration" with the following code:

```csharp
// If the type of the declaration is 'var', create a new type name
// for the inferred type.
var variableDeclaration = localDeclaration.Declaration;
var variableTypeName = variableDeclaration.Type;
if (variableTypeName.IsVar)
{

}

// Produce the new local declaration.
var newLocal = trimmedLocal.WithModifiers(newModifiers)
                           .WithDeclaration(variableDeclaration);
```

Next, add a check inside curly braces of the if-block you wrote above to ensure that the type of the variable declaration is not an alias. If it is an alias to some other type (e.g. ), then it is legal to declare a local `const var`.

```csharp
var semanticModel = await document.GetSemanticModelAsync(cancellationToken);

// Special case: Ensure that 'var' isn't actually an alias to another type
// (e.g. using var = System.String).
var aliasInfo = semanticModel.GetAliasInfo(variableTypeName);
if (aliasInfo == null)
{

}
```

Inside the curly braces that you wrote in the code above, add the following code to retrieve the type inferred for `var` inside the curly braces of the if-block you wrote above.

```csharp
// Retrieve the type inferred for var.
var type = semanticModel.GetTypeInfo(variableTypeName).ConvertedType;

// Special case: Ensure that 'var' isn't actually a type named 'var'.
if (type.Name != "var")
{

}
```

Now, add the code to create a new <xref:Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax> for the inferred type inside the curly braces of the if-block you wrote above.

```csharp
// Create a new TypeSyntax for the inferred type. Be careful
// to keep any leading and trailing trivia from the var keyword.
var typeName = SyntaxFactory.ParseTypeName(type.ToDisplayString())
    .WithLeadingTrivia(variableTypeName.GetLeadingTrivia())
    .WithTrailingTrivia(variableTypeName.GetTrailingTrivia());
```

Add a <xref:Microsoft.CodeAnalysis.Simplification.Simplifier>syntax annotation to the type name to ensure that the code fix engine reduces the type name to its minimally qualified form.  Use **Ctrl+.** on <xref:Microsoft.CodeAnalysis.Simplification.Simplifier> to add the using statement for `Microsoft.CodeAnalysis.Simplification`.

```csharp
// Add an annotation to simplify the type name.
var simplifiedTypeName = typeName.WithAdditionalAnnotations(Simplifier.Annotation);
```

Finally, replace the variable declaration's type with the one you created.

```csharp
// Replace the type in the variable declaration.
variableDeclaration = variableDeclaration.WithType(simplifiedTypeName);
```

The code you've added should be shown in the following example:

[!code-csharp[Replace Var designations](/samples/csharp/roslyn-sdk/Tutorials/MakeConst/MakeConst/MakeConstAnalyzer.cs#ReplaceVar "Replace a var designation with the explicit type")]

Run your tests, and they should all pass. Congratulate yourself by running your finished analyzer. Press Ctrl+F5 to run the Analyzer project in a second instance of Visual Studio with the Roslyn Preview extension loaded.

    * In the second Visual Studio instance, create a new C# Console Application project and add int x = "abc";' to the Main method. Thanks to the first bug fix, no warning should be reported for this local variable declaration (though there's a compiler error as expected).
    * Next, add object s = "abc";' to the Main method. Because of the second bug fix, no warning should be reported.
    * Finally, add another local variable that uses the var' keyword. You'll see that a warning is reported and a suggestion appears beneath to the left.
    * Move the editor caret over the squiggly underline and press Ctrl+. to display the suggested code fix. Upon selecting your code fix, note that the var' keyword is now handled correctly.

Congratulations! You've created your first .NET Compiler Platform extension that performs on-the-fly code analysis to detect an issue and provides a quick fix to correct it.
