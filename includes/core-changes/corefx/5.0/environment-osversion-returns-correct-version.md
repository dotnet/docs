### Environment.OSVersion returns the correct operating system version

<xref:System.Environment.OSVersion?displayProperty=nameWithType> returns the actual version of the operating system (OS) instead of, for example, the OS that's selected for application compatibility.

#### Change description

In previous .NET versions, <xref:System.Environment.OSVersion?displayProperty=nameWithType> returns an OS version that may be incorrect when an application runs under Windows compatibility mode. For more information, see [GetVersionExA function remarks](/windows/win32/api/sysinfoapi/nf-sysinfoapi-getversionexa#remarks).

Starting in .NET 5.0, <xref:System.Environment.OSVersion?displayProperty=nameWithType> returns the actual version of the operating system.

#### Reason for change

Users of this property expect it to return the actual version of the operating system. Most .NET apps don't specify their supported version in their application manifest, and thus get the default supported version from the dotnet host. As a result, the compatibility shim is rarely meaningful for the app that's running. When Windows releases a new version and an older dotnet host is still in use, these apps may get an incorrect OS version. Returning the actual version is more inline with developers' expectations of this API.

#### Version introduced

5.0

#### Recommended action

Review and test any code that uses <xref:System.Environment.OSVersion?displayProperty=nameWithType> to ensure it behaves as desired.

#### Category

Core .NET libraries

#### Affected APIs

- <xref:System.Environment.OSVersion?displayProperty=fullName>

<!--

#### Affected APIs

- `P:System.Environment.OSVersion`

-->
