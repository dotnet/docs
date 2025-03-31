---
title: System.Uri class
description: Learn about the System.Uri class.
ms.date: 12/31/2023
---
# System.Uri class

[!INCLUDE [context](includes/context.md)]

A URI is a compact representation of a resource available to your application on the intranet or internet. The <xref:System.Uri> class defines the properties and methods for handling URIs, including parsing, comparing, and combining. The <xref:System.Uri> class properties are read-only; to create a modifiable object, use the <xref:System.UriBuilder> class.

Relative URIs (for example, "/new/index.htm") must be expanded with respect to a base URI so that they are absolute. The <xref:System.Uri.MakeRelativeUri%2A> method is provided to convert absolute URIs to relative URIs when necessary.

The <xref:System.Uri> constructors do not escape URI strings if the string is a well-formed URI including a scheme identifier.

The <xref:System.Uri> properties return a canonical data representation in escaped encoding, with all characters with Unicode values greater than 127 replaced with their hexadecimal equivalents. To put the URI in canonical form, the <xref:System.Uri> constructor performs the following steps:

- Converts the URI scheme to lowercase.

- Converts the host name to lowercase.

- If the host name is an IPv6 address, the canonical IPv6 address is used. ScopeId and other optional IPv6 data are removed.

- Removes default and empty port numbers.

- Converts implicit file paths without the file:// scheme (for example, "C:\my\file") to explicit file paths with the file:// scheme.

- Escaped characters (also known as percent-encoded octets) that don't have a reserved purpose are decoded (also known as being unescaped). These unreserved characters include uppercase and lowercase letters (%41-%5A and %61-%7A), decimal digits (%30-%39), hyphen (%2D), period (%2E), underscore (%5F), and tilde (%7E).

- Canonicalizes the path for hierarchical URIs by compacting sequences such as /./, /../, and // (whether or not the sequence is escaped). Note that there are some schemes for which these sequences are not compacted.

- For hierarchical URIs, if the host is not terminated with a forward slash (/), one is added.

- By default, any reserved characters in the URI are escaped in accordance with RFC 2396. This behavior changes if International Resource Identifiers or International Domain Name parsing is enabled in which case reserved characters in the URI are escaped in accordance with RFC 3986 and RFC 3987.

As part of canonicalization in the constructor for some schemes, dot-segments and empty segments (`/./`, `/../`, and `//`) are compacted (in other words, they are removed). The schemes for which <xref:System.Uri> compacts segments include http, https, tcp, net.pipe, and net.tcp. For some other schemes, these sequences are not compacted. The following code snippet shows how compacting looks in practice. The escaped sequences are unescaped, if necessary, and then compacted.

```csharp
var uri = new Uri("http://myUrl/../.."); // http scheme, unescaped
OR
var uri = new Uri("http://myUrl/%2E%2E/%2E%2E"); // http scheme, escaped
OR
var uri = new Uri("ftp://myUrl/../.."); // ftp scheme, unescaped
OR
var uri = new Uri("ftp://myUrl/%2E%2E/%2E%2E"); // ftp scheme, escaped

Console.WriteLine($"AbsoluteUri: {uri.AbsoluteUri}");
Console.WriteLine($"PathAndQuery: {uri.PathAndQuery}");
```

When this code executes, it returns output similar to the following text.

```output
AbsoluteUri: http://myurl/
PathAndQuery: /
```

You can transform the contents of the <xref:System.Uri> class from an escape encoded URI reference to a readable URI reference by using the <xref:System.Uri.ToString%2A> method. Note that some reserved characters might still be escaped in the output of the <xref:System.Uri.ToString%2A> method. This is to support unambiguous reconstruction of a URI from the value returned by <xref:System.Uri.ToString%2A>.

Some URIs include a fragment identifier or a query or both. A fragment identifier is any text that follows a number sign (#), not including the number sign; the fragment text is stored in the <xref:System.Uri.Fragment> property. Query information is any text that follows a question mark (?) in the URI; the query text is stored in the <xref:System.Uri.Query> property.

> [!NOTE]
> The URI class supports the use of IP addresses in both quad-notation for IPv4 protocol and colon-hexadecimal for IPv6 protocol. Remember to enclose the IPv6 address in square brackets, as in http://[::1].

## International resource identifier support

Web addresses are typically expressed using uniform resource identifiers that consist of a very restricted set of characters:

- Upper and lower case ASCII letters from the English alphabet.
- Digits from 0 to 9.
- A small number of other ASCII symbols.

The specifications for URIs are documented in RFC 2396, RFC 2732, RFC 3986, and RFC 3987 published by the Internet Engineering Task Force (IETF).

Identifiers that facilitate the need to identify resources using languages other than English and allow non-ASCII characters (characters in the Unicode/ISO 10646 character set) are known as International Resource Identifiers (IRIs). The specifications for IRIs are documented in RFC 3987 published by IETF. Using IRIs allows a URL to contain Unicode characters.

In .NET Framework 4.5 and later versions, IRI is always enabled and can't be changed using a configuration option. You can set a configuration option in the *machine.config* or in the *app.config* file to specify whether you want Internationalized Domain Name (IDN) parsing applied to the domain name. For example:

```xml
<configuration>
  <uri>
    <idn enabled="All" />
  </uri>
</configuration>
```

Enabling IDN converts all Unicode labels in a domain name to their Punycode equivalents. Punycode names contain only ASCII characters and always start with the xn-- prefix. The reason for this is to support existing DNS servers on the Internet, since most DNS servers only support ASCII characters (see RFC 3940).

Enabling IDN affects the value of the <xref:System.Uri.DnsSafeHost?displayProperty=nameWithType> property. Enabling IDN can also change the behavior of the <xref:System.Uri.Equals%2A>, <xref:System.Uri.OriginalString%2A>, <xref:System.Uri.GetComponents%2A>, and <xref:System.Uri.IsWellFormedOriginalString%2A> methods.

There are three possible values for IDN depending on the DNS servers that are used:

- idn enabled = All

  This value will convert any Unicode domain names to their Punycode equivalents (IDN names).

- idn enabled = AllExceptIntranet

  This value will convert all Unicode domain names not on the local Intranet to use the Punycode equivalents (IDN names). In this case to handle international names on the local Intranet, the DNS servers that are used for the Intranet should support Unicode name resolution.

- idn enabled = None

  This value will not convert any Unicode domain names to use Punycode. This is the default value.

Normalization and character checking are done according to the latest IRI rules in RFC 3986 and RFC 3987.

IRI and IDN processing in the <xref:System.Uri> class can also be controlled using the <xref:System.Configuration.IriParsingElement?displayProperty=nameWithType>, <xref:System.Configuration.IdnElement?displayProperty=nameWithType>, and <xref:System.Configuration.UriSection?displayProperty=nameWithType> configuration setting classes. The <xref:System.Configuration.IriParsingElement?displayProperty=nameWithType> setting enables or disables IRI processing in the <xref:System.Uri> class. The <xref:System.Configuration.IdnElement?displayProperty=nameWithType> setting enables or disables IDN processing in the <xref:System.Uri> class.

The configuration setting for the <xref:System.Configuration.IriParsingElement?displayProperty=nameWithType> and <xref:System.Configuration.IdnElement?displayProperty=nameWithType> are read once when the first <xref:System.Uri?displayProperty=nameWithType> class is constructed. Changes to configuration settings after that time are ignored.

The <xref:System.GenericUriParser?displayProperty=nameWithType> class has also been extended to allow creating a customizable parser that supports IRI and IDN. The behavior of a <xref:System.GenericUriParser?displayProperty=nameWithType> object is specified by passing a bitwise combination of the values available in the <xref:System.GenericUriParserOptions?displayProperty=nameWithType> enumeration to the <xref:System.GenericUriParser?displayProperty=nameWithType> constructor. The <xref:System.GenericUriParserOptions.IriParsing?displayProperty=nameWithType> type indicates the parser supports the parsing rules specified in RFC 3987 for International Resource Identifiers (IRI).

The <xref:System.GenericUriParserOptions.Idn?displayProperty=nameWithType> type indicates that the parser supports Internationalized Domain Name (IDN) parsing of host names. In .NET 5 and later versions (including .NET Core) and .NET Framework 4.5+, IDN is always used. In previous versions, a configuration option determines whether IDN is used.

## Implicit file path support

<xref:System.Uri> can also be used to represent local file system paths. These paths can be represented *explicitly* in URIs that begin with the file:// scheme, and *implicitly* in URIs that do not have the file:// scheme. As a concrete example, the following two URIs are both valid, and represent the same file path:

```csharp
Uri uri1 = new Uri("C:/test/path/file.txt") // Implicit file path.
Uri uri2 = new Uri("file:///C:/test/path/file.txt") // Explicit file path.
```

These implicit file paths are not compliant with the URI specification and so should be avoided when possible. When using .NET Core on Unix-based systems, implicit file paths can be especially problematic, because an absolute implicit file path is *indistinguishable* from a relative path. When such ambiguity is present, <xref:System.Uri> default to interpreting the path as an absolute URI.

## Security considerations

Because of security concerns, your application should use caution when accepting <xref:System.Uri> instances from untrusted sources and with `dontEscape` set to `true` in the [constructor](xref:System.Uri.%23ctor(System.String,System.Boolean)). You can check a URI string for validity by calling the <xref:System.Uri.IsWellFormedOriginalString%2A> method.

When dealing with untrusted user input, confirm assumptions about the newly created `Uri` instance before trusting its properties.
This can be done in the following way:

```csharp
string userInput = ...;

Uri baseUri = new Uri("https://myWebsite/files/");

if (!Uri.TryCreate(baseUri, userInput, out Uri newUri))
{
    // Fail: invalid input.
}

if (!baseUri.IsBaseOf(newUri))
{
    // Fail: the Uri base has been modified - the created Uri is not rooted in the original directory.
}
```

This validation can be used in other cases, like when dealing with UNC paths, by simply changing the `baseUri`:

```csharp
Uri baseUri = new Uri(@"\\host\share\some\directory\name\");
```

## Performance considerations

If you use a *Web.config* file that contains URIs to initialize your application, additional time is required to process the URIs if their scheme identifiers are nonstandard. In such a case, initialize the affected parts of your application when the URIs are needed, not at start time.
