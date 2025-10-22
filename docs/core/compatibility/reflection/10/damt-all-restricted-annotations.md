---
title: "Breaking change: Replace DAMT.All with more restricted annotation on InvokeMember/FindMembers/DeclaredMembers"
description: Learn about the .NET 10 breaking change in core .NET libraries where InvokeMember, FindMembers, and DeclaredMembers APIs use more restricted annotations instead of DAMT.All.
ms.date: 10/22/2025
ai-usage: ai-assisted
---
# Replace DAMT.All with more restricted annotation on InvokeMember/FindMembers/DeclaredMembers

Starting in .NET 10, the <xref:System.Reflection.IReflect.InvokeMember%2A?displayProperty=nameWithType>, <xref:System.Type.FindMembers%2A?displayProperty=nameWithType>, and <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=nameWithType> APIs use more restricted annotations instead of `DAMT.All`. This change affects scenarios where you implement the <xref:System.Reflection.IReflect> interface or derive from <xref:System.Reflection.TypeInfo>.

## Version introduced

.NET 10 Preview 1

## Previous behavior

Previously, the `InvokeMember`, `FindMembers`, and `DeclaredMembers` APIs used the `DAMT.All` annotation, which was overly permissive. This could result in capturing additional members, such as interface methods implemented by a class, and potentially caused runtime warnings or unsafe reflection calls.

```csharp
public class MyType : IReflect
{
    public MethodInfo[] GetMethods(BindingFlags bindingAttr)
    {
        // Previous behavior: DAMT.All annotation applied
        // This could capture additional members, including interface methods implemented by the class
    }
}
```

## New behavior

The `InvokeMember`, `FindMembers`, and `DeclaredMembers` APIs now use more restricted annotations, which provide better control over the members captured during reflection. You must update your annotations to match the new behavior if you implement <xref:System.Reflection.IReflect> or derive from <xref:System.Reflection.TypeInfo>.

```csharp
public class MyType : IReflect
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    public MethodInfo[] GetMethods(BindingFlags bindingAttr)
    {
        // New behavior: More restricted annotation applied
        // Only public methods are captured, avoiding unintended members
    }
}
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-incompatible) and is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change was introduced to improve the accuracy of annotations in <xref:System.Reflection> APIs and to address issues caused by the overly permissive `DAMT.All` annotation. This ensures better compatibility with trimming and reflection scenarios, reduces runtime warnings, and prevents unsafe reflection calls.

## Recommended action

If you implement <xref:System.Reflection.IReflect> or derive from <xref:System.Reflection.TypeInfo>, review your code and update annotations to align with the new behavior. Specifically:

1. Replace `DAMT.All` annotations with more restricted annotations, such as <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods?displayProperty=nameWithType>, <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicMethods?displayProperty=nameWithType>, or other appropriate types.
1. Test reflection scenarios to ensure that the updated annotations capture the intended members and don't introduce runtime errors or warnings.

**Before:**

```csharp
public class MyType : IReflect
{
    public MethodInfo[] GetMethods(BindingFlags bindingAttr)
    {
        // Previous behavior: DAMT.All annotation applied
    }
}
```

**After:**

```csharp
public class MyType : IReflect
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    public MethodInfo[] GetMethods(BindingFlags bindingAttr)
    {
        // New behavior: More restricted annotation applied
    }
}
```

## Affected APIs

- <xref:System.Reflection.IReflect.InvokeMember%2A?displayProperty=fullName>
- <xref:System.Type.FindMembers%2A?displayProperty=fullName>
- <xref:System.Reflection.TypeInfo.DeclaredMembers?displayProperty=fullName>

## See also

- [Prepare .NET libraries for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming)
