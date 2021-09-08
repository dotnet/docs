---
title: "Breaking change: Cookie path handling now conforms to RFC 6265"
description: Learn about the breaking change in .NET 5 where path-handling algorithms defined in RFC 6265 were implemented for the Cookie and CookieContainer classes.
ms.date: 08/18/2020
---
# Cookie path handling now conforms to RFC 6265

Path-handling algorithms defined in [RFC 6265](https://tools.ietf.org/html/rfc6265) were implemented for the <xref:System.Net.Cookie> and <xref:System.Net.CookieContainer> classes.

## Version introduced

5.0

## Change description

- The <xref:System.Net.Cookie.Path> property is no longer required to be a prefix of the request path.
- The calculation of the default value of <xref:System.Net.Cookie.Path> and path-matching algorithms were implemented as defined in [section 5.1.4](https://tools.ietf.org/html/rfc6265#section-5.1.4) of RFC 6265.

## Recommended action

In most cases, you won't need to take any action. However, if your code was dependent on <xref:System.Net.Cookie.Path> validation, you'll need to implement required validation in your code. If your code was dependent on default value calculation for <xref:System.Net.Cookie.Path>, consider supplying the <xref:System.Net.Cookie.Path> value manually instead of using the default value.

## Affected APIs

- <xref:System.Net.Cookie?displayProperty=fullName>
- <xref:System.Net.CookieContainer?displayProperty=fullName>

<!--

### Affected APIs

- `T:System.Net.Cookie`
- `T:System.Net.CookieContainer`

### Category

Networking

-->
