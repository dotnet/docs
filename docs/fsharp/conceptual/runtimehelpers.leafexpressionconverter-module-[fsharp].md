---
title: RuntimeHelpers.LeafExpressionConverter Module (F#)
description: RuntimeHelpers.LeafExpressionConverter Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: caef7f89-a853-4e0b-9023-113023cb1015
---

# RuntimeHelpers.LeafExpressionConverter Module (F#)

Contains functions that help implement F# query expressions.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module LeafExpressionConverter
    EvaluateQuotation : Expr -> obj
        ImplicitExpressionConversionHelper : 'T -> Expression<'T>
            MemberInitializationHelper : 'T -> 'T
                QuotationToExpression : Expr -> Expression
                   QuotationToLambdaExpression : Expr<'T> -> Expression<'T>
                       SubstHelper : Expr * Var [] * obj [] -> Expr<'T>
```

## Values


|Value|Description|
|-----|-----------|
|[EvaluateQuotation](https://msdn.microsoft.com/library/78d297ba-5713-4e81-b97c-437d816f336b): [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65) -&gt; [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)|Evaluates a subset of F# quotations by first converting to a LINQ expression, for the subset of LINQ expressions represented by the expression syntax in the C# language.|
|[ImplicitExpressionConversionHelper](https://msdn.microsoft.com/library/5f36b846-ac35-45a4-b845-5a058af226eb): 'T -&gt; **System.Linq.Expressions.Expression&#96;1**&lt;'T&gt;|When used in a quotation, this function indicates that a specific conversion should be performed when converting the quotation to a LINQ expression. This function should not be called directly.|
|[MemberInitializationHelper](https://msdn.microsoft.com/library/ef12e1ca-8676-43c0-b0ab-ca6e6cf120d0): 'T -&gt; 'T|When used in a quotation, this function indicates that a specific conversion should be performed when converting the quotation to a LINQ expression. This function should not be called directly.|
|[QuotationToExpression](https://msdn.microsoft.com/library/6a71ff35-492b-4047-b31e-fb2e3fc0e7ae): [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65) -&gt; **System.Linq.Expressions.Expression&#96;1**|Converts a subset of F# quotations to a LINQ expression, for the subset of LINQ expressions represented by the expression syntax in the C# language.|
|[QuotationToLambdaExpression](https://msdn.microsoft.com/library/a0e524a0-1056-424f-b964-a889456e6fcb): [Expr](https://msdn.microsoft.com/library/975ca4d3-ac2b-46db-9f01-23cf8b190c6e)&lt;'T&gt; -&gt; **System.Linq.Expressions.Expression&#96;1**&lt;'T&gt;|Converts a subset of F# quotations to a LINQ expression, for the subset of LINQ expressions represented by the expression syntax in the C# language.|
|[SubstHelper](https://msdn.microsoft.com/library/7d59f997-d947-42cf-b57a-c51dfecc67a6): [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65) &#42; [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5) [] &#42; [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7) [] -&gt; [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)&lt;'T&gt;|A runtime helper used to evaluate nested quotation literals.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)
