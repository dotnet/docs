---
title: "Breaking change: Uri parsing and UriBuilder validation changes"
description: "Learn about the breaking changes in .NET 11 involving Uri parsing and UriBuilder host validation."
ms.date: 10/21/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/55744
---

# Uri parsing and UriBuilder validation changes

In .NET 11, several parsing and validation behaviors in <xref:System.Uri> and <xref:System.UriBuilder> have been tightened to align more strictly with the URI specification and eliminate parsing discrepancies across constructor overloads and factories.

## Version introduced

.NET 11 GA

## Previous behavior

Previously, the following behaviors were permitted or exhibited:

1. **Missing IPv6 path delimiter:** A URI string without a delimiter between an IPv6 address and the path (such as `"http://[::]extra"`) was parsed the same as if a delimiter was present (`"http://[::]/extra"`).
2. **`UriBuilder.Host` accepted composite or invalid values:** Setting the <xref:System.UriBuilder.Host?displayProperty=nameWithType> property allowed values containing path delimiters or user information (such as `"contoso.com/path"` or `"user@host"`), potentially altering other URI components when the builder combined values via <xref:System.UriBuilder.Uri?displayProperty=nameWithType> or <xref:System.UriBuilder.ToString?displayProperty=nameWithType>.
3. **IPv6 length prefixes:** <xref:System.Uri> allowed parsing of IPv6 length prefixes (such as `"/64"` in `"http://[AB::/64]/path"`).
4. **Embedded IPv4 octal segments:** <xref:System.Uri> allowed an octal value in the last segment of an IPv4 address embedded within an IPv6 address (for example, `"http://[::1.2.3.04]/"` was parsed, whereas `"http://[::1.2.03.4]/"` was rejected).
5. **Relative URI normalization discrepancy:** `new Uri("p%41th", UriKind.Relative)` normalized the relative URI input to `"pAth"`, whereas `Uri.TryCreate("p%41th", UriKind.Relative, out uri)` left the value unnormalized as `"p%41th"`.

## New behavior

Starting in .NET 11:

1. **IPv6 path delimiter required:** URI parsing enforces that a delimiter (`/`) is present after an IPv6 host. Parsing strings like `"http://[::]extra"` now throws <xref:System.UriFormatException> or causes <xref:System.Uri.TryCreate*?displayProperty=nameWithType> to return `false`.
2. **`UriBuilder.Host` validates input:** The <xref:System.UriBuilder.Host?displayProperty=nameWithType> property setter performs best-effort validation and rejects inputs that would alter other URI components. Assigning values such as `"contoso.com/path"` or `"user@host"` throws <xref:System.ArgumentException>. Certain invalid host formats, such as `"[127.0.0.1]"`, are also caught early.
3. **IPv6 length prefixes rejected:** If an IPv6 length prefix is present in the input, URI parsing fails with <xref:System.UriFormatException>. Allowed characters in the zone ID (IPv6 scope identifier) are also more strictly constrained.
4. **Embedded IPv4 octal segments rejected:** Octal values are rejected in any segment of an IPv4 address embedded in an IPv6 address. Parsing strings such as `"http://[::1.2.3.04]/"` now fails.
5. **Consistent relative URI normalization:** <xref:System.Uri.%23ctor(System.String,System.UriKind)> and <xref:System.Uri.TryCreate(System.String,System.UriKind,System.Uri@)> apply identical normalization rules. Passing `"p%41th"` to either API normalizes the value to `"pAth"`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

These changes enforce stricter adherence to RFC URI standards, improve security posture by preventing URI component injection in <xref:System.UriBuilder>, and eliminate subtle differences between <xref:System.Uri> constructors and <xref:System.Uri.TryCreate*?displayProperty=nameWithType>.

## Recommended action

Most applications will not need changes. However, if your application:

- Uses <xref:System.UriBuilder.Host?displayProperty=nameWithType> to set composite values containing paths or user credentials, update the code to assign the individual <xref:System.UriBuilder.Path>, <xref:System.UriBuilder.UserName>, or <xref:System.UriBuilder.Password> properties directly.
- Parses IPv6 URIs without trailing delimiters or with CIDR length prefixes, ensure the input URIs are formatted with a path delimiter and without prefix lengths.

## Affected APIs

- <xref:System.Uri.%23ctor*?displayProperty=fullName>
- <xref:System.Uri.TryCreate*?displayProperty=fullName>
- <xref:System.UriBuilder.Host?displayProperty=fullName>
