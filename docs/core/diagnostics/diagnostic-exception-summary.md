---
title: Exception summarization in C#
description: Learn the value proposition of exception summarization within diagnostic metrics for .NET app development.
ms.date: 11/29/2023
---

# Exception summarization

When you're trying to generate meaningful diagnostic messages for exceptions, maintaining the inclusion of pertinent information can pose a challenge. The standard exception message often lacks critical details that accompany the exception, while invoking the <xref:System.Exception.ToString%2A?displayProperty=nameWithType> method yields an excess of state information.

This article relies on the [Microsoft.Extensions.Diagnostics.ExceptionSummarization](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ExceptionSummarization) NuGet package.

## The goal of exception summarization

Metric tags typically support a limited number of distinct values, and as such they are not suitable to represent values which are highly variable, such as the result of <xref:System.Exception.ToString?displayProperty=nameWithType>. An exception summary represents a low-cardinality version of an exception's information, suitable for such cases.

The goal of exception summarization is twofold:

- To reduce the cardinality associated with exception state such that exceptions can be reliably counted in metrics. This matters since metric dimensions have limited cardinality.
- To eliminate privacy-sensitive information from exception state such that some meaningful exception information can be added to logs.

## Exception summarization API

The <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.IExceptionSummarizer> interface offers methods for extracting crucial details from recognized exception types, thereby furnishing a singular `string` that serves as the foundation for crafting top-quality diagnostic messages.

The <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.IExceptionSummarizer.Summarize%2A?displayProperty=nameWithType> method systematically traverses the roster of registered summarizers until it identifies a summarizer capable of handling the specific exception type. In the event that no summarizer is capable of recognizing the exception type, a meaningful default exception summary is provided instead.

The result of the `Summarize` method returns an <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.ExceptionSummary> struct, and it contains the following properties:

- <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.ExceptionSummary.Description?displayProperty=nameWithType>: The summary description of the exception.
- <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.ExceptionSummary.AdditionalDetails?displayProperty=nameWithType>: Intended for low-level diagnostic use, this property contains additional details about the exception and has a relatively high cardinality. This property may contain privacy-sensitive information.
- <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.ExceptionSummary.ExceptionType?displayProperty=nameWithType>:  The type of the exception, unless inner exceptions are present, in which case both outer and inner types are reflected.

## Example exception summarization usage

The following example demonstrates how to use the `IExceptionSummarizer` interface to retrieve a summary of an exception.

:::code source="snippets/exception-summary/Program.cs":::

The preceding code:

- Instantiates a new <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> instance, chaining a call to the <xref:Microsoft.Extensions.DependencyInjection.ExceptionSummarizationServiceCollectionExtensions.AddExceptionSummarizer%2A> extension method.
  - The `AddExceptionSummarizer` extension method accepts a delegate that is used to configure the `ExceptionSummarizerBuilder` instance.
  - The `builder` is used to add the HTTP provider, which handles exceptions of type:
    - <xref:System.OperationCanceledException>
    - <xref:System.Threading.Tasks.TaskCanceledException>
    - <xref:System.Net.Sockets.SocketException>
    - <xref:System.Net.WebException>
- Builds a new `ServiceProvider` instance from the `ServiceCollection` instance.
- Gets an instance of the `IExceptionSummarizer` interface from the `ServiceProvider` instance.
- Iterates over a collection of exceptions, calling the `Summarize` method on each exception and displaying the result.

> [!NOTE]
> The primary focus in the design of all exception summarization implementations is to provide diagnostic convenience, rather than prioritizing the protection of personally identifiable information (PII). The <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.ExceptionSummary.Description?displayProperty=nameWithType> doesn't contain sensitive information, but the <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.ExceptionSummary.AdditionalDetails?displayProperty=nameWithType> might contain sensitive information depending on the implementation.
