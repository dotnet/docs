---
title: Use the .NET Compiler Platform SDK syntax model 
description: This overview provides an understanding of the types you use to understand and manipulate syntax nodes.
author: billwagner
ms.author: wiwagn
ms.date: 10/15/2017
ms.topic: conceptual
ms.prod: .net
ms.devlang: devlang-csharp
ms.custom: mvc
---

# Work with syntax

The **syntax tree** is a fundamental data structure exposed by the compiler APIs. These trees represent the lexical and syntactic structure of source code. They serve two important purposes:

1. To allow tools - such as an IDE, add-ins, code analysis tools, and refactorings - to see and process the syntactic structure of source code in a user’s project.
2. To enable tools - such as refactorings and an IDE - to create, modify, and rearrange source code in a natural manner without having use direct text edits. By creating and manipulating trees, tools can easily create and rearrange source code.

## Syntax trees

Syntax trees are the primary structure used for compilation, code analysis, binding, refactoring, IDE features, and code generation. No part of the source code is understood without it first being identified and categorized into one of many well-known structural language elements. 

Syntax trees have three key attributes. The first attribute is that syntax trees hold all the source information in full fidelity. This means that the syntax tree contains every piece of information found in the source text, every grammatical construct, every lexical token, and everything else in between, including white space, comments, and preprocessor directives. For example, each literal mentioned in the source is represented exactly as it was typed. The syntax trees also represent errors in source code when the program is incomplete or malformed by representing skipped or missing tokens in the syntax tree.  

This enables the second attribute of syntax trees. A syntax tree obtained from the parser can produce the exact text it was parsed from. From any syntax node, it is possible to get the text representation of the sub-tree rooted at that node. This means that syntax trees can be used as a way to construct and edit source text. By creating a tree you have by implication created the equivalent text, and by editing a syntax tree, making a new tree out of changes to an existing tree, you have effectively edited the text. 

The third attribute of syntax trees is that they are immutable and thread-safe.  This means that after a tree is obtained, it is a snapshot of the current state of the code, and never changes. This allows multiple users to interact with the same syntax tree at the same time in different threads without locking or duplication. Because the trees are immutable and no modifications can be made directly to a tree, factory methods help create and modify syntax trees by creating additional snapshots of the tree. The trees are efficient in the way they reuse underlying nodes, so a new version can be rebuilt fast and with little extra memory.

A syntax tree is literally a tree data structure, where non-terminal structural elements parent other elements. Each syntax tree is made up of nodes, tokens, and trivia.  

## Syntax nodes

Syntax nodes are one of the primary elements of syntax trees. These nodes represent syntactic constructs such as declarations, statements, clauses, and expressions. Each category of syntax nodes is represented by a separate class derived from <xref:Microsoft.CodeAnalysis.SyntaxNode?displayProperty=nameWithType>. The set of node classes is not extensible. 

All syntax nodes are non-terminal nodes in the syntax tree, which means they always have other nodes and tokens as children. As a child of another node, each node has a parent node that can be accessed through the <xref:Microsoft.CodeAnalysis.SyntaxNode.Parent?displayProperty=nameWithType> property. Because nodes and trees are immutable, the parent of a node never changes. The root of the tree has a null parent.  

Each node has a <xref:Microsoft.CodeAnalysis.SyntaxNode.ChildNodes?displayProperty=nameWithType> method, which returns a list of child nodes in sequential order based on their position in the source text. This list does not contain tokens. Each node also has methods to examine Descendants, such as <xref:Microsoft.CodeAnalysis.SyntaxNode.DescendantNodes%2A>, <xref:Microsoft.CodeAnalysis.SyntaxNode.DescendantTokens%2A>, or <xref:Microsoft.CodeAnalysis.SyntaxNode.DescendantTrivia%2A> - that represent a list of all the nodes, tokens, or trivia, that exist in the sub-tree rooted by that node.  

In addition, each syntax node subclass exposes all the same children through strongly typed properties. For example, a <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax> node class has three additional properties specific to binary operators: <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.Left>, <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.OperatorToken>, and <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.Right>. The type of <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.Left> and <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.Right> is <xref:Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>, and the type of <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.OperatorToken> is <xref:Microsoft.CodeAnalysis.SyntaxToken>.

Some syntax nodes have optional children. For example, an <xref:Microsoft.CodeAnalysis.CSharp.Syntax.IfStatementSyntax> has an optional <xref:Microsoft.CodeAnalysis.CSharp.Syntax.ElseClauseSyntax>. If the child is not present, the property returns null. 

## Syntax tokens

Syntax tokens are the terminals of the language grammar, representing the smallest syntactic fragments of the code. They are never parents of other nodes or tokens. Syntax tokens consist of keywords, identifiers, literals, and punctuation. 

For efficiency purposes, the <xref:Microsoft.CodeAnalysis.SyntaxToken> type is a CLR value type. Therefore, unlike syntax nodes, there is only one structure for all kinds of tokens with a mix of properties that have meaning depending on the kind of token that is being represented.

For example, an integer literal token represents a numeric value. In addition to the raw source text the token spans, the literal token has a <xref:Microsoft.CodeAnalysis.SyntaxToken.Value> property that tells you the exact decoded integer value. This property is typed as <xref:System.Object> because it may be one of many primitive types.

The <xref:Microsoft.CodeAnalysis.SyntaxToken.ValueText> property tells you the same information as the <xref:Microsoft.CodeAnalysis.SyntaxToken.Value> property; however this property is always typed as <xref:System.String>. An identifier in C# source text may include Unicode escape characters, yet the syntax of the escape sequence itself is not considered part of the identifier name. So although the raw text spanned by the token does include the escape sequence, the <xref:Microsoft.CodeAnalysis.SyntaxToken.ValueText> property does not. Instead, it includes the Unicode characters identified by the escape. For example, if the source text contains an identifier written as `\u03C0`, then
the <xref:Microsoft.CodeAnalysis.SyntaxToken.ValueText> property for this
token will return `π`.

## Syntax trivia

Syntax trivia represent the parts of the source text that are largely insignificant for normal understanding of the code, such as white space, comments, and preprocessor directives. Like syntax tokens, trivia are value types. The single <xref:Microsoft.CodeAnalysis.SyntaxTrivia?displayProperty=nameWithType> type is used to describe all kinds of trivia.

Because trivia are not part of the normal language syntax and can appear anywhere between any two tokens, they are not included in the syntax tree as a child of a node. Yet, because they are important when implementing a feature like refactoring and to maintain full fidelity with the source text, they do exist as part of the syntax tree.

You can access trivia by inspecting a token’s <xref:Microsoft.CodeAnalysis.SyntaxToken.LeadingTrivia?displayProperty=nameWithType> or <xref:Microsoft.CodeAnalysis.SyntaxToken.TrailingTrivia?displayProperty=nameWithType> collections. When source text is parsed, sequences of trivia are associated with tokens. In general, a token owns any trivia after it on the same line up to the next token. Any trivia after that line is associated with the following token. The first token in the source file gets all the initial trivia, and the last sequence of trivia in the file is tacked onto the end-of-file token, which otherwise has zero width.

Unlike syntax nodes and tokens, syntax trivia do not have parents. Yet, because they are part of the tree and each is associated with a single token, you may access the token it is associated with using the <xref:Microsoft.CodeAnalysis.SyntaxTrivia.Token?displayProperty=nameWithType> property.

## Spans

Each node, token, or trivia knows its position within the source text and the number of characters it consists of. A text position is represented as a 32-bit integer, which is a zero-based `char` index. A <xref:Microsoft.CodeAnalysis.Text.TextSpan> object is the beginning position and a count of characters, both represented as integers. If <xref:Microsoft.CodeAnalysis.Text.TextSpan> has a zero length, it refers to a location between two characters.

Each node has two <xref:Microsoft.CodeAnalysis.Text.TextSpan> properties: <xref:Microsoft.CodeAnalysis.SyntaxNode.Span*> and <xref:Microsoft.CodeAnalysis.SyntaxNode.FullSpan*>. 

The <xref:Microsoft.CodeAnalysis.SyntaxNode.Span*> property is the text span from the start of the first token in the node’s sub-tree to the end of the last token. This span does not include any leading or trailing trivia.

The <xref:Microsoft.CodeAnalysis.SyntaxNode.FullSpan*> property is the text span that includes the node’s normal span, plus the span of any leading or trailing trivia.

For example: 

``` csharp
      if (x > 3)
      {
||        // this is bad
          |throw new Exception("Not right.");|  // better exception?||
      }
```

The statement node inside the block has a span indicated by the single vertical bars (|). It includes the characters `throw new Exception("Not right.");`. The full span is indicated by the double vertical bars (||). It includes the same characters as the span and the characters associated with the leading and trailing trivia.

## Kinds

Each node, token, or trivia has a <xref:Microsoft.CodeAnalysis.SyntaxNode.RawKind?displayProperty=nameWithType> property, of type <xref:System.Int32?displayProperty=nameWithType>, that identifies the exact syntax element represented. This value can be cast to a language-specific enumeration; each language, C# or VB, has a single `SyntaxKind` enumeration  (<xref:Microsoft.CodeAnalysis.CSharp.SyntaxKind?displayProperty=nameWithType> and <xref:Microsoft.CodeAnalysis.VisualBasic.SyntaxKind?displayProperty=nameWithType>, respectively) that lists all the possible nodes, tokens, and trivia elements in the grammar. This conversion can be done automatically by accessing the <xref:Microsoft.CodeAnalysis.CSharp.CSharpExtensions.Kind*?displayProperty=nameWithType> or <xref:Microsoft.CodeAnalysis.VisualBasic.VisualBasicExtensions.Kind*?displayProperty=nameWithType> extension methods.

The <xref:Microsoft.CodeAnalysis.SyntaxToken.RawKind> property allows for easy disambiguation of syntax node types that share the same node class. For tokens and trivia, this property is the only way to distinguish one type of element from another. 

For example, a single <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax> class has <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.Left>, <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.OperatorToken>, and <xref:Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.Right> as children. The <xref:Microsoft.CodeAnalysis.CSharp.CSharpExtensions.Kind*> property distinguishes whether it is an <xref:Microsoft.CodeAnalysis.CSharp.SyntaxKind.AddExpression>, <xref:Microsoft.CodeAnalysis.CSharp.SyntaxKind.SubtractExpression>, or <xref:Microsoft.CodeAnalysis.CSharp.SyntaxKind.MultiplyExpression> kind of syntax node.

## Errors

Even when the source text contains syntax errors, a full syntax tree that is round-trippable to the source is exposed. When the parser encounters code that does not conform to the defined syntax of the language, it uses one of two techniques to create a syntax tree.

First, if the parser expects a particular kind of token but does not find it, it may insert a missing token into the syntax tree in the location that the token was expected. A missing token represents the actual token that was expected, but it has an empty span, and its <xref:Microsoft.CodeAnalysis.SyntaxNode.IsMissing?displayProperty=nameWithType> property returns `true`.

Second, the parser may skip tokens until it finds one where it can continue parsing. In this case, the skipped tokens are attached as a trivia node with the kind <xref:Microsoft.CodeAnalysis.CSharp.SyntaxKind.SkippedTokensTrivia>.
