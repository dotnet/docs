### URI paths with non-ASCII characters parse correctly on Unix

A bug was fixed in the <xref:System.Uri?displayProperty=fullName> class such that absolute URI paths that contain non-ASCII characters now parse correctly on Unix platforms.

#### Change description

In previous versions of .NET, absolute URI paths that contain non-ASCII characters are parsed incorrectly on Unix platforms, such that segments of the path are duplicated. (Absolute paths are those that start with "/".) The parsing issue has been fixed for .NET 5.0. If you move from a previous version to .NET 5.0 or later, you'll get different values produced by <xref:System.Uri.AbsoluteUri?displayProperty=nameWithType>, <xref:System.Uri.ToString?displayProperty=nameWithType>, and other members.

Consider the output of the following code when run on Unix on a previous .NET version and on .NET 5.0.

```csharp
Uri myuri = new Uri("/üri");

Console.WriteLine(myuri.AbsoluteUri);
Console.WriteLine(myuri.ToString());
```

Output on previous .NET version:

```text
AbsoluteUri: /%C3%BCri/%C3%BCri
ToString: /üri/üri
```

Output on .NET 5.0 or later version:

```text
AbsoluteUri: /%C3%BCri
ToString: /üri
```

#### Version introduced

5.0

#### Recommended action

If you have code that expects and accounts for the duplicated path segments, you can remove that code.

#### Category

Core .NET libraries

#### Affected APIs

- <xref:System.Uri?displayProperty=fullName>

<!--

#### Affected APIs

- `T:System.Uri`

-->
