---
title: "Breaking change: URI length limits removed"
description: "Learn about the .NET 10 breaking change in networking where URI length limits of around 65K characters have been removed."
ms.date: 08/11/2025
ai-usage: ai-assisted
---

# `Uri` length limits removed

Methods that create <xref:System.Uri> instances (constructors and <xref:System.Uri.TryCreate*> factory methods) have historically limited the length of the URI string to around 65,000 characters (exact limits varied slightly depending on the input format). These limits have been lifted such that there is practically no upper bound on how long `Uri` instances can be.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, it wasn't possible to create a <xref:System.Uri> instance whose length exceeded around 65,000 characters. Code like the following example threw a <xref:System.UriFormatException> with the message "Invalid URI: The Uri string is too long."

```csharp
new Uri($"https://host/{new string('a', 100_000)}")
```

## New behavior

Starting in .NET 10, <xref:System.Uri> instances containing large amounts of data can now be created. For example:

```csharp
string largeQuery = ...;
return new Uri($"https://someService/?query={Uri.EscapeDataString(largeQuery)}");
```

The removed restrictions mainly apply to paths, queries, and fragments as the most practical components to carry large amounts of data. Components such as the scheme and host might still enforce some length limits. Practical limitations as you approach the length limits of `string` also apply, so you can't (nor should you) use <xref:System.Uri> to represent a 10 GB file.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Most HTTP servers enforce strict length restrictions on URLs they are willing to accept in requests. The limits are generally much lower than <xref:System.Uri>'s previous limits. However, since <xref:System.Uri> is the de facto exchange type in .NET for URI-like information, the previous limits limited its use in some scenarios without good workarounds aside from removing the use of <xref:System.Uri> throughout API contracts.

The main scenarios for large <xref:System.Uri> are:

- `data:` uris, which contain arbitrary binary blobs encoded in Base64. These might be transmitted outside of the HTTP request line. For example, they might be part of the request body, and can therefore be arbitrarily large. <xref:System.Uri> can now be used to represent data URIs containing larger files.
- Large query strings. <xref:System.Uri> is often used as an exchange type between systems even if it will never be sent as part of an HTTP request. User request information is often encoded as part of the query string, so the new behavior enables such scenarios even as the amount of data grows.

## Recommended action

For most users, there is no action required.

If you rely on <xref:System.Uri> to impose length restrictions as part of your input validation, you must now perform length checking yourself, preferably as a step before you construct the <xref:System.Uri> instance. As most HTTP servers enforce much stricter length limits in practice, very long inputs were already likely to result in failures when sent as part of an HTTP request. You might find that your scenario would benefit from performing even stricter length validation than <xref:System.Uri> had done previously.

## Affected APIs

- <xref:System.Uri.%23ctor*>
- <xref:System.Uri.TryCreate*?displayProperty=fullName>
- All <xref:System.Uri> members that return information about the <xref:System.Uri> instance, such as:
  - <xref:System.Uri.AbsolutePath?displayProperty=fullName>
  - <xref:System.Uri.AbsoluteUri?displayProperty=fullName>
  - <xref:System.Uri.PathAndQuery?displayProperty=fullName>
