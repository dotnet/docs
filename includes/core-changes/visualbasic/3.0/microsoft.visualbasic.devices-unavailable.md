### Types in Microsoft.VisualBasic.Devices namespace not available

The types in the <xref:Microsoft.VisualBasic.Devices?displayProperty=fullName> namespace are not available.

#### Version introduced

.NET Core 3.0

#### Change description

The types in the <xref:Microsoft.VisualBasic.Devices?displayProperty=fullName> namespace were available in .NET Framework. They're not available in .NET Core 3.0 - 3.1.

The types were removed to avoid unnecessary assembly dependencies or breaking changes in subsequent releases.

#### Recommended action

This namespace was added in .NET 5, upgrade your project to .NET 5 or later.

-or-

If your code depends on the use of <xref:Microsoft.VisualBasic.Devices> types and their members, you may be able to use a corresponding type or member in the .NET class library. For example, equivalent functionality to the <xref:Microsoft.VisualBasic.Devices.Clock?displayProperty=nameWithType> class is provided by the <xref:System.DateTime?displayProperty=nameWithType> and <xref:System.Environment?displayProperty=nameWithType> types, and equivalent functionality to the <xref:Microsoft.VisualBasic.Devices.Ports?displayProperty=nameWithType> class is provided by types in the <xref:System.IO.Ports?displayProperty=nameWithType> namespace.

#### Category

Visual Basic

#### Affected APIs

- <xref:Microsoft.VisualBasic.Devices?displayProperty=fullName>

<!--

#### Affected APIs

- `N:Microsoft.VisualBasic.Devices`

-->
