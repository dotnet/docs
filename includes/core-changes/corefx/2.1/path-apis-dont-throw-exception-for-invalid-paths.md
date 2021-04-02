### Path APIs don't throw an exception for invalid characters

<xref:System.IO.Path?displayProperty=fullName> APIs no longer validate path characters and throw an <xref:System.ArgumentException> if an invalid character is found.

#### Change description

Starting in .NET Core 2.1, the <xref:System.IO.Path> methods listed in the [Affected APIs](#affected-apis) section no longer check for [invalid path characters](xref:System.IO.Path.GetInvalidPathChars%2A) and throw an exception if an invalid character is found. In .NET Framework and .NET Core 1.0 - 2.0, these methods throw an <xref:System.ArgumentException> if the path argument contains an invalid path character.

#### Reason for change

Aggressive validation of path characters blocks some cross-platform scenarios. This change was introduced so that .NET does not try to replicate or predict the outcome of operating system API calls. For more information, see the [System.IO in .NET Core 2.1 sneak peek](/archive/blogs/jeremykuhne/system-io-in-net-core-2-1-sneak-peek) blog post.

#### Version introduced

.NET Core 2.1

#### Recommended action

If your code relied on these APIs to check for invalid characters, you can add a call to <xref:System.IO.Path.GetInvalidPathChars%2A?displayProperty=nameWithType>.

#### Affected APIs

- <xref:System.IO.Path.GetFullPath(System.String)?displayProperty=fullName>
- <xref:System.IO.Path.IsPathRooted(System.String)?displayProperty=fullName>
- <xref:System.IO.Path.GetPathRoot(System.String)?displayProperty=fullName>
- <xref:System.IO.Path.ChangeExtension(System.String,System.String)?displayProperty=fullName>
- <xref:System.IO.Path.GetDirectoryName(System.String)?displayProperty=fullName>
- <xref:System.IO.Path.GetExtension(System.String)?displayProperty=fullName>
- <xref:System.IO.Path.HasExtension(System.String)?displayProperty=fullName>
- <xref:System.IO.Path.Combine%2A?displayProperty=fullName>

#### See also

- [System.IO in .NET Core 2.1 sneak peek](/archive/blogs/jeremykuhne/system-io-in-net-core-2-1-sneak-peek)

<!--

### Category

Core .NET libraries

### Affected APIs

- `M::System.IO.Path.GetFullPath(System.String)`
- `M::System.IO.Path.IsPathRooted(System.String)`
- `M::System.IO.Path.GetPathRoot(System.String)`
- `M::System.IO.Path.ChangeExtension(System.String,System.String)`
- `M::System.IO.Path.GetDirectoryName(System.String)`
- `M::System.IO.Path.GetExtension(System.String)`
- `M::System.IO.Path.HasExtension(System.String)`
- `M::System.IO.Path.Combine%2A`

-->
