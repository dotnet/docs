---
title: "Breaking change: Uri length limits have been removed"
description: "Learn about the .NET 10 breaking change in networking where Uri length limits of around 65k characters have been removed."
ms.date: 12/13/2024
ai-usage: ai-assisted
---

# Uri length limits have been removed

Methods that create <xref:System.Uri> instances (constructors and `TryCreate` factory methods) have historically limited the length of the Uri string to around 65k characters (exact limits varied slightly depending on the input format). As of .NET 10 preview 7, these limits have been lifted such that there is practically no upper bound on how long `Uri`s can be.

## Version introduced

.NET 10 Preview 7

## Previous behavior

It was previously not possible to create a <xref:System.Uri> instance whose length exceeded around 65k characters. Code like the following example previously threw a <xref:System.UriFormatException> with the message "Invalid URI: The Uri string is too long."

```csharp
new Uri($"https://host/{new string('a', 100_000)}")
```

## New behavior

<xref:System.Uri> instances containing large amounts of data can now be created. For example:

```csharp
string largeQuery = ...;
return new Uri($"https://someService/?query={Uri.EscapeDataString(largeQuery)}");
```

The removed restrictions mainly apply to paths, queries, and fragments as the most practical components to carry large amounts of data. Components such as the scheme and host might still enforce some length limits. Practical limitations as you approach the length limits of `string` also apply, so you may not (nor should you) use <xref:System.Uri> to represent a 10 GB file.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Most HTTP servers enforce strict length restrictions on URLs they are willing to accept in requests, generally much lower than <xref:System.Uri>'s existing limits. However, since <xref:System.Uri> is the de facto exchange type in .NET for Uri-like information, the previous limits limited its use in some scenarios without good workarounds aside from removing the use of <xref:System.Uri> throughout API contracts.

Main scenarios for large <xref:System.Uri> are:

- `data:` uris, which contain arbitrary binary blobs encoded in Base64. These might be transmitted outside of the HTTP request line, for example, they might be part of the request body, and can therefore be arbitrarily large. <xref:System.Uri> might now be used to represent data Uris containing larger files.
- Large query strings. <xref:System.Uri> is often used as an exchange type between systems even if it will never be sent as part of an HTTP request. User request information is often encoded as part of the query string, so the new behavior enables such scenarios even as the amount of data grows.

## Recommended action

For the majority of users, there is no action required.

If you are relying on <xref:System.Uri> imposing such length restrictions as part of your input validation, you must now perform length checking yourself, preferably as a step before you construct the <xref:System.Uri> instance. As most HTTP servers are enforcing much stricter length limits in practice, very long inputs were already likely to result in failures when sent as part of an HTTP request. You might find that your scenario would benefit from performing even stricter length validation than <xref:System.Uri> had done previously.

## Affected APIs

- All <xref:System.Uri> constructors
- All <xref:System.Uri.TryCreate*?displayProperty=nameWithType> overloads
- By extension also all <xref:System.Uri> members that return information about the <xref:System.Uri> instance, such as <xref:System.Uri.AbsolutePath?displayProperty=nameWithType>, <xref:System.Uri.AbsoluteUri?displayProperty=nameWithType>, <xref:System.Uri.PathAndQuery?displayProperty=nameWithType>, and others
