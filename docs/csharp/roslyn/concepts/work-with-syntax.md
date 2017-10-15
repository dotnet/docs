---
title: Work with syntax | Microsoft Docs 
description: This overview provides an understanding of the type you use to understand and manipulate syntax nodes.
keywords: Roslyn, C#, Compiler, SDK, analyzer, codefix
author: billwagner
ms.author: wiwagn
ms.date: 10/15/2017
ms.topic: conceptual
ms.prod: .net
ms.devlang: devlang-csharp
ms.custom: mvc
---

# Work with Syntax

The most fundamental data structure exposed by the Compiler APIs is the syntax tree. These trees represent the lexical and syntactic structure of source code. They serve two important purposes:

1. To allow tools - such as an IDE, add-ins, code analysis tools, and refactorings - to see and process the syntactic structure of source code in a user’s project.
2. To enable tools - such as refactorings and an IDE - to create, modify, and rearrange source code in a natural manner without having use direct text edits. By creating and manipulating trees, tools can easily create and rearrange source code.

## Syntax Trees

Syntax trees are the primary structure used for compilation, code analysis, binding, refactoring, IDE features, and code generation. No part of the source code is understood without it first being identified and categorized into one of many well-known structural language elements. 

Syntax trees have three key attributes. The first attribute is that syntax trees hold all the source information in full fidelity. This means that the syntax tree contains every piece of information found in the source text, every grammatical construct, every lexical token, and everything else in between including whitespace, comments, and preprocessor directives. For example, each literal mentioned in the source is represented exactly as it was typed. The syntax trees also represent errors in source code when the program is incomplete or malformed, by representing skipped or missing tokens in the syntax tree.  

This enables the second attribute of syntax trees. A syntax tree obtained from the parser is completely round-trippable back to the text it was parsed from. From any syntax node, it is possible to get the text representation of the sub-tree rooted at that node. This means that syntax trees can be used as a way to construct and edit source text. By creating a tree you have by implication created the equivalent text, and by editing a syntax tree, making a new tree out of changes to an existing tree, you have effectively edited the text. 

The third attribute of syntax trees is that they are immutable and thread-safe.  This means that after a tree is obtained, it is a snapshot of the current state of the code, and never changes. This allows multiple users to interact with the same syntax tree at the same time in different threads without locking or duplication. Because the trees are immutable and no modifications can be made directly to a tree, factory methods help create and modify syntax trees by creating additional snapshots of the tree. The trees are efficient in the way they reuse underlying nodes, so the new version can be rebuilt fast and with little extra memory.

A syntax tree is literally a tree data structure, where non-terminal structural elements parent other elements. Each syntax tree is made up of nodes, tokens, and trivia.  

## Syntax Nodes

Syntax nodes are one of the primary elements of syntax trees. These nodes represent syntactic constructs such as declarations, statements, clauses, and expressions. Each category of syntax nodes is represented by a separate class derived from SyntaxNode. The set of node classes is not extensible. 

All syntax nodes are non-terminal nodes in the syntax tree, which means they always have other nodes and tokens as children. As a child of another node, each node has a parent node that can be accessed through the Parent property. Because nodes and trees are immutable, the parent of a node never changes. The root of the tree has a null parent.  

Each node has a ChildNodes method, which returns a list of child nodes in sequential order based on its position in the source text. This list does not contain tokens. Each node also has a collection of Descendant methods - such as DescendantNodes, DescendantTokens, or DescendantTrivia - that represent a list of all the nodes, tokens, or trivia that exist in the sub-tree rooted by that node.  

In addition, each syntax node subclass exposes all the same children through strongly typed properties. For example, a BinaryExpressionSyntax node class has three additional properties specific to binary operators: Left, OperatorToken, and Right. The type of Left and Right is ExpressionSyntax, and the type of OperatorToken is SyntaxToken.

Some syntax nodes have optional children. For example, an IfStatementSyntax has an optional ElseClauseSyntax. If the child is not present, the property returns null. 

## Syntax Tokens

Syntax tokens are the terminals of the language grammar, representing the smallest syntactic fragments of the code. They are never parents of other nodes or tokens. Syntax tokens consist of keywords, identifiers, literals, and punctuation. 

For efficiency purposes, the SyntaxToken type is a CLR value type. Therefore, unlike syntax nodes, there is only one structure for all kinds of tokens with a mix of properties that have meaning depending on the kind of token that is being represented.

For example, an integer literal token represents a numeric value. In addition to the raw source text the token spans, the literal token has a Value property that tells you the exact decoded integer value. This property is typed as Object because it may be one of many primitive types.

The ValueText property tells you the same information as the Value property; however this property is always typed as String. An identifier in C# source text may include Unicode escape characters, yet the syntax of the escape sequence itself is not considered part of the identifier name. So although the raw text spanned by the token does include the escape sequence, the ValueText property does not. Instead, it includes the Unicode characters identified by the escape.

## Syntax Trivia

Syntax trivia represent the parts of the source text that are largely insignificant for normal understanding of the code, such as whitespace, comments, and preprocessor directives. 

Because trivia are not part of the normal language syntax and can appear anywhere between any two tokens, they are not included in the syntax tree as a child of a node. Yet, because they are important when implementing a feature like refactoring and to maintain full fidelity with the source text, they do exist as part of the syntax tree.

You can access trivia by inspecting a token’s LeadingTrivia or TrailingTrivia collections. When source text is parsed, sequences of trivia are associated with tokens. In general, a token owns any trivia after it on the same line up to the next token. Any trivia after that line is associated with the following token. The first token in the source file gets all the initial trivia, and the last sequence of trivia in the file is tacked onto the end-of-file token, which otherwise has zero width.

Unlike syntax nodes and tokens, syntax trivia do not have parents. Yet, because they are part of the tree and each is associated with a single token, you may access the token it is associated with using the Token property.

Like syntax tokens, trivia are value types. The single SyntaxTrivia type is used to describe all kinds of trivia.

## Spans

Each node, token, or trivia knows its position within the source text and the number of characters it consists of. A text position is represented as a 32-bit integer, which is a zero-based Unicode character index. A TextSpan object is the beginning position and a count of characters, both represented as integers. If TextSpan has a zero length, it refers to a location between two characters.

Each node has two TextSpan properties: Span and FullSpan. 

The Span property is the text span from the start of the first token in the node’s sub-tree to the end of the last token. This span does not include any leading or trailing trivia.

The FullSpan property is the text span that includes the node’s normal span, plus the span of any leading or trailing trivia.

For example: 

``` csharp
      if (x > 3)
      {
||        // this is bad
          |throw new Exception("Not right.");|  // better exception?||
      }
```

The statement node inside the block has a span indicated by the single vertical bars (|). It includes the characters +throw new Exception(“Not right.”);+. The full span is indicated by the double vertical bars (||). It includes the same characters as the span and the characters associated with the leading and trailing trivia.

## Kinds

Each node, token, or trivia has a RawKind property, of type System.Int32, that identifies the exact syntax element represented. This value can be cast to a language-specific enumeration; each language, C# or VB, has a single SyntaxKind enumeration that lists all the possible nodes, tokens, and trivia elements in the grammar. This conversion can be done automatically by accessing the CSharpSyntaxKind() or VisualBasicSyntaxKind() extension methods.

The RawKind property allows for easy disambiguation of syntax node types that share the same node class. For tokens and trivia, this property is the only way to distinguish one type of element from another. 

For example, a single BinaryExpressionSyntax class has Left, OperatorToken, and Right as children. The Kind property distinguishes whether it is an AddExpression, SubtractExpression, or MultiplyExpression kind of syntax node.

## Errors

Even when the source text contains syntax errors, a full syntax tree that is round-trippable to the source is exposed. When the parser encounters code that does not conform to the defined syntax of the language, it uses one of two techniques to create a syntax tree.

First, if the parser expects a particular kind of token, but does not find it, it may insert a missing token into the syntax tree in the location that the token was expected. A missing token represents the actual token that was expected, but it has an empty span, and its IsMissing property returns true.

Second, the parser may skip tokens until it finds one where it can continue parsing. In this case, the skipped tokens that were skipped are attached as a trivia node with the kind SkippedTokens.
