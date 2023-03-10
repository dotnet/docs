---
title: Perform culture-insensitive case changes
description: "Learn how to perform culture-insensitive case changes"
ms.date: 06/06/2022
dev_langs:
    - "csharp"
    - "vb"
helpviewer_keywords:
    - "String.ToLower method"
    - "culture, case sensitivity"
    - "Char.ToLower method"
    - "case, changing in culture-insensitive strings"
    - "Char.ToUpper method"
    - "culture-insensitive string operations, case changes"
    - "String.ToUpper method"
    - "culture parameter"
ms.topic: how-to
---

# Perform culture-insensitive case changes

The <xref:System.String.ToUpper%2A?displayProperty=nameWithType>, <xref:System.String.ToLower%2A?displayProperty=nameWithType>, <xref:System.Char.ToUpper%2A?displayProperty=nameWithType>, and <xref:System.Char.ToLower%2A?displayProperty=nameWithType> methods provide overloads that do not accept any parameters. By default, these overloads without parameters perform case changes based on the value of the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType>. This produces case-sensitive results that can vary by culture. To make it clear whether you want case changes to be culture-sensitive or culture-insensitive, you should use the overloads of these methods that require you to explicitly specify a `culture` parameter. For culture-sensitive case changes, specify `CultureInfo.CurrentCulture` for the `culture` parameter. For culture-insensitive case changes, specify `CultureInfo.InvariantCulture` for the `culture` parameter.

Often, strings are converted to a standard case to enable easier lookup later. When strings are used in this way, you should specify `CultureInfo.InvariantCulture` for the `culture` parameter, because the value of <xref:System.Threading.Thread.CurrentCulture%2A?displayProperty=nameWithType> can potentially change between the time that the case is changed and the time that the lookup occurs.

If a security decision is based on a case change operation, the operation should be culture-insensitive to ensure that the result is not affected by the value of `CultureInfo.CurrentCulture`. See the "String Comparisons that Use the Current Culture" section of the [Best Practices for Using Strings](../../standard/base-types/best-practices-strings.md) article for an example that demonstrates how culture-sensitive string operations can produce inconsistent results.

## String.ToUpper and String.ToLower

For code clarity, it's recommended that you always use overloads of the `String.ToUpper` and `String.ToLower` methods that let you specify a culture explicitly. For example, the following code performs an identifier lookup. The `key.ToLower` operation is culture-sensitive by default, but this behavior is not clear from reading the code.

### Example

```vb
Shared Function LookupKey(key As String) As Object
   Return internalHashtable(key.ToLower())
End Function
```

```csharp
static object LookupKey(string key)
{
    return internalHashtable[key.ToLower()];
}
```

If you want the `key.ToLower` operation to be culture-insensitive, change the preceding example as follows to explicitly use `CultureInfo.InvariantCulture` when changing the case.

```vb
Shared Function LookupKey(key As String) As Object
    Return internalHashtable(key.ToLower(CultureInfo.InvariantCulture))
End Function
```

```csharp
static object LookupKey(string key)
{
    return internalHashtable[key.ToLower(CultureInfo.InvariantCulture)];
}
```

## Char.ToUpper and Char.ToLower

Although the `Char.ToUpper` and `Char.ToLower` methods have the same characteristics as the `String.ToUpper` and `String.ToLower` methods, the only cultures that are affected are Turkish (Türkiye) and Azerbaijani (Latin, Azerbaijan). These are the only two cultures with single-character casing differences. For more details about this unique case mapping, see the "Casing" section in the <xref:System.String> class documentation. For code clarity and to ensure consistent results, it's recommended that you always use the overloads of these methods that accept a <xref:System.Globalization.CultureInfo> parameter.

## See also

- <xref:System.String.ToUpper%2A?displayProperty=nameWithType>
- <xref:System.String.ToLower%2A?displayProperty=nameWithType>
- <xref:System.Char.ToUpper%2A?displayProperty=nameWithType>
- <xref:System.Char.ToLower%2A?displayProperty=nameWithType>
- [CA1311: Specify a culture or use an invariant version](../../fundamentals/code-analysis/quality-rules/ca1311.md)
- [Change case in .NET](../../standard/base-types/changing-case.md)
- [Perform culture-insensitive string operations](performing-culture-insensitive-string-operations.md)
