---
title: "Breaking change: Nullable reference type annotation changes"
description: Learn about the .NET 6 breaking change in core .NET libraries where some nullable reference type annotations have changed.
ms.date: 06/17/2021
---
# Changes to nullable reference type annotations

In .NET 6, some nullability annotations in the .NET libraries have changed.

## Change description

In previous .NET versions, some nullable reference type annotations are incorrect, and build warnings are either absent or incorrect. Starting in .NET 6, some annotations that were previously applied have been updated. New build warnings will be produced and incorrect build warnings will no longer be produced for the affected APIs.

Some of these changes are considered to be *breaking* because they can lead to new build-time warnings. When you migrate to .NET 6, code that references these APIs will need to be updated.

Other changes that aren't considered to be breaking are also documented on this page. Any code that references the updated APIs may benefit from removing operators or pragmas that are no longer necessary.

## Version introduced

6.0

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Starting in .NET Core 3.0, nullability annotations were applied to the .NET libraries. From the outset of the effort, mistakes in these annotations were anticipated. Through feedback and further testing, the nullable annotations for the affected APIs were determined to be inaccurate. The updated annotations correctly represent the nullability contracts for the APIs.

## Recommended action

Update code that calls these APIs to reflect the revised nullability contracts.

## Affected APIs

The following table lists the affected APIs:

| API | What changed | Breaking or nonbreaking |
| - | - |
| <xref:System.ComponentModel.ISite.Container?displayProperty=nameWithType> | Property type is nullable | Breaking |
| <xref:System.Xml.Linq.XContainer.Add(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XContainer.AddFirst(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XContainer.ReplaceNodes(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XDocument.%23ctor(System.Object[])> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XDocument.%23ctor(System.Xml.Linq.XDeclaration,System.Object[])> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XElement.%23ctor(System.Xml.Linq.XName,System.Object[])> | Second parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XElement.ReplaceAll(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XElement.ReplaceAttributes(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XNode.AddAfterSelf(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XNode.AddBeforeSelf(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XNode.ReplaceWith(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XStreamingElement.%23ctor(System.Xml.Linq.XName,System.Object)> | Second parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XStreamingElement.%23ctor(System.Xml.Linq.XName,System.Object[])> | Second parameter type is nullable | Nonbreaking |
| <xref:System.Xml.Linq.XStreamingElement.Add(System.Object[])?displayProperty=nameWithType> | Parameter type is nullable | Nonbreaking |
| <xref:System.Net.Http.HttpClient.PatchAsync%2A?displayProperty=nameWithType> | `content` parameter type is nullable | Nonbreaking |
| <xref:System.Net.Http.HttpClient.PostAsync%2A?displayProperty=nameWithType> | `content` parameter type is nullable  | Nonbreaking |
| <xref:System.Net.Http.HttpClient.PutAsync%2A?displayProperty=nameWithType> | `content` parameter type is nullable  | Nonbreaking |
| <xref:System.Linq.Expressions.MethodCallExpression.Update(System.Linq.Expressions.Expression,System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})?displayProperty=nameWithType> | First parameter type is nullable | Nonbreaking |
| <xref:System.Linq.Expressions.Expression%601.Update(System.Linq.Expressions.Expression,System.Collections.Generic.IEnumerable{System.Linq.Expressions.ParameterExpression})?displayProperty=nameWithType> | Return type is not nullable | Nonbreaking |
| <xref:System.Data.IDataRecord.GetBytes(System.Int32,System.Int64,System.Byte[],System.Int32,System.Int32)?displayProperty=nameWithType> | `buffer` parameter type is nullable | Breaking |
| <xref:System.Data.IDataRecord.GetChars(System.Int32,System.Int64,System.Char[],System.Int32,System.Int32)?displayProperty=nameWithType> | `buffer` parameter type is nullable | Breaking |
| <xref:System.Data.Common.DbDataRecord.GetBytes(System.Int32,System.Int64,System.Byte[],System.Int32,System.Int32)?displayProperty=nameWithType> | `buffer` parameter type is nullable | Breaking |
| <xref:System.Data.Common.DbDataRecord.GetChars(System.Int32,System.Int64,System.Char[],System.Int32,System.Int32)?displayProperty=nameWithType> | `buffer` parameter type is nullable | Breaking |
| <xref:System.Net.HttpListenerContext.AcceptWebSocketAsync%2A?displayProperty=fullName> | `subProtocol` parameter type is nullable | Nonbreaking |
| Methods that override <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> and [many others that return `bool`](https://github.com/dotnet/runtime/pull/47598/files) | `[NotNullWhen(true)]` added to first nullable parameter | Breaking |
| <xref:System.Collections.Immutable.ImmutableArray%601.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Collections.Specialized.BitVector32.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `o` parameter | Breaking |
| <xref:System.Collections.Specialized.BitVector32.Section.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `o` parameter | Breaking |
| <xref:System.Reflection.Metadata.BlobContentId.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.BlobHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.CustomDebugInformationHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.DocumentNameBlobHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.EntityHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.GuidHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.Handle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.ImportScopeHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.LocalConstantHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.NamespaceDefinitionHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.SequencePoint.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.SignatureHeader.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.Ecma335.EditAndContinueLogEntry.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Metadata.Ecma335.LabelHandle.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Emit.Label.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| <xref:System.Reflection.Emit.OpCode.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |
| `DateOnly.Equals(System.Object)` | `NotNullWhen(true)` was added to the `value` parameter | Breaking |
| `TimeOnly.Equals(System.Object)` | `NotNullWhen(true)` was added to the `value` parameter | Breaking |
| <xref:System.Reflection.Pointer.Equals(System.Object)?displayProperty=nameWithType> | `NotNullWhen(true)` was added to the `obj` parameter | Breaking |

## See also

- [Attributes for null-state static analysis](../../../../csharp/language-reference/attributes/nullable-analysis.md)
- [Nullable reference type annotation changes in ASP.NET Core](../../aspnet-core/6.0/nullable-reference-type-annotations-changed.md)
