---
title: "Breaking change: More restricted annotations on InvokeMember/FindMembers/DeclaredMembers"
description: "Learn about the breaking change in .NET 10 where System.Reflection APIs InvokeMember, FindMembers, and DeclaredMembers use more restricted annotations instead of DynamicallyAccessedMemberTypes.All."
ms.date: 10/09/2025
ai-usage: ai-generated
---

# More restricted annotations on InvokeMember/FindMembers/DeclaredMembers

Starting in .NET 10, the <xref:System.Reflection> APIs <xref:System.Reflection.IReflect.InvokeMember%2A>, <xref:System.Type.FindMembers%2A>, and <xref:System.Reflection.TypeInfo.DeclaredMembers> use more restricted annotations instead of <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType>.

This change affects scenarios where developers implement the <xref:System.Reflection.IReflect> interface or derive from <xref:System.Reflection.TypeInfo>. The previous use of <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> was overly permissive and could lead to unintended behavior, such as capturing interface methods implemented by a class or generating warnings due to unsafe reflection calls.

## Version introduced

.NET 10

## Previous behavior

Previously, the <xref:System.Reflection.IReflect.InvokeMember%2A>, <xref:System.Type.FindMembers%2A?displayProperty=nameWithType>, and <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=nameWithType> APIs used the <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> annotation, which was overly permissive. This could result in capturing additional members, such as interface methods implemented by a class, and potentially cause runtime warnings or unsafe reflection calls.

## New behavior

The <xref:System.Reflection.IReflect.InvokeMember%2A>, <xref:System.Type.FindMembers%2A?displayProperty=nameWithType>, and <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=nameWithType> APIs now use more restricted annotations, which provide better control over the members captured during reflection.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change) and can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The change was introduced to improve the accuracy of annotations in <xref:System.Reflection> APIs and to address issues caused by the overly permissive <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> annotation. This ensures better compatibility with trimming and reflection scenarios, reduces run-time warnings, and prevents unsafe reflection calls.

## Recommended action

If you implement <xref:System.Reflection.IReflect> or derive from <xref:System.Reflection.TypeInfo>, review your code and update annotations to align with the new behavior. Specifically:

1. Replace <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.All?displayProperty=nameWithType> annotations with more restricted annotations, such as <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods?displayProperty=nameWithType>, <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicMethods?displayProperty=nameWithType>, or other appropriate types.

   The following code snippet shows an example.

   ```csharp
   class MyType : IReflect
   {
       [DynamicallyAccessedMembers(
           DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields |
           DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods |
           DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties |
           DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
        public object InvokeMember(string name, BindingFlags invokeAttr, Binder? binder, object? target,
            object?[]? args, ParameterModifier[]? modifiers, CultureInfo? culture, string[]? namedParameters)
        { }
   }
   ```

1. Test reflection scenarios to ensure that the updated annotations capture the intended members and don't introduce run-time errors or warnings.

For more information on `DynamicallyAccessedMembers` annotations and their usage, see [Prepare .NET libraries for trimming](../../../deploying/trimming/prepare-libraries-for-trimming.md).

## Affected APIs

- <xref:System.Reflection.IReflect.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[],System.Reflection.ParameterModifier[],System.Globalization.CultureInfo,System.String[])?displayProperty=fullName>
- <xref:System.Type.FindMembers(System.Reflection.MemberTypes,System.Reflection.BindingFlags,System.Reflection.MemberFilter,System.Object)?displayProperty=fullName>
- <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=fullName>
