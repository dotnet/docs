---
title: "Breaking change: Replace DAMT.All with more restricted annotation on InvokeMember/FindMembers/DeclaredMembers"
description: "Learn about the breaking change in .NET 10 where System.Reflection APIs InvokeMember, FindMembers, and DeclaredMembers use more restricted annotations instead of DAMT.All."
ms.date: 01/10/2025
ai-usage: ai-generated
---

# Replace DAMT.All with more restricted annotation on InvokeMember/FindMembers/DeclaredMembers

Starting in .NET 10, the <xref:System.Reflection> APIs <xref:System.Reflection.IReflect.InvokeMember%2A>, <xref:System.Type.FindMembers%2A?displayProperty=nameWithType>, and <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=nameWithType> have been updated to use more restricted annotations instead of <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType>. This change affects scenarios where developers implement the <xref:System.Reflection.IReflect> interface or derive from <xref:System.Reflection.TypeInfo>. The previous use of `DAMT.All` was overly permissive and could lead to unintended behavior, such as capturing interface methods implemented by a class or generating warnings due to unsafe reflection calls.

## Version introduced

.NET 10 Preview 1

## Previous behavior

The <xref:System.Reflection.IReflect.InvokeMember%2A>, <xref:System.Type.FindMembers%2A?displayProperty=nameWithType>, and <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=nameWithType> APIs used the <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> annotation, which was overly permissive. This could result in capturing additional members, such as interface methods implemented by a class, and potentially cause runtime warnings or unsafe reflection calls.

## New behavior

The <xref:System.Reflection.IReflect.InvokeMember%2A>, <xref:System.Type.FindMembers%2A?displayProperty=nameWithType>, and <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=nameWithType> APIs now use more restricted annotations, which provide better control over the members captured during reflection. Developers implementing <xref:System.Reflection.IReflect> or deriving from <xref:System.Reflection.TypeInfo> must update their annotations to match the new behavior.

The following code snippet shows an example of the required annotation for implementing <xref:System.Reflection.IReflect.InvokeMember%2A>:

:::code language="csharp" source="./snippets/ireflect-damt-annotations/csharp/MyType.cs" id="snippet_InvokeMember":::

:::code language="vb" source="./snippets/ireflect-damt-annotations/vb/MyType.vb" id="snippet_InvokeMember":::

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change) and can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The change was introduced to improve the accuracy of annotations in <xref:System.Reflection> APIs and to address issues caused by the overly permissive <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> annotation. This ensures better compatibility with trimming and reflection scenarios, reduces runtime warnings, and prevents unsafe reflection calls.

## Recommended action

Developers who implement <xref:System.Reflection.IReflect> or derive from <xref:System.Reflection.TypeInfo> should review their code and update annotations to align with the new behavior. Specifically:

1. Replace <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> annotations with more restricted annotations, such as <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods?displayProperty=nameWithType>, <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicMethods?displayProperty=nameWithType>, or other appropriate types.
2. Test reflection scenarios to ensure that the updated annotations capture the intended members and don't introduce runtime errors or warnings.

For more information on `DynamicallyAccessedMembers` annotations and their usage, refer to [Prepare .NET libraries for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming).

## Affected APIs

- <xref:System.Reflection.IReflect.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[],System.Reflection.ParameterModifier[],System.Globalization.CultureInfo,System.String[])?displayProperty=fullName>
- <xref:System.Type.FindMembers(System.Reflection.MemberTypes,System.Reflection.BindingFlags,System.Reflection.MemberFilter,System.Object)?displayProperty=fullName>
- <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=fullName>
