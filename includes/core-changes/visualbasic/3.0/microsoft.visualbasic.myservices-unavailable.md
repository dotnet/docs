﻿### Types in Microsoft.VisualBasic.MyServices namespace not available

The types in the <xref:Microsoft.VisualBasic.MyServices?displayProperty=fullName> namespace are not available.

#### Version introduced

.NET Core 3.0

#### Change description

The types in the <xref:Microsoft.VisualBasic.MyServices?displayProperty=fullName> namespace were available in .NET Framework. They're not available in .NET Core 3.0 - 3.1.

The types were removed to avoid unnecessary assembly dependencies or breaking changes in subsequent releases.

#### Recommended action

This namespace was added in .NET 5, upgrade your project to .NET 5 or later.

-or-

If your code depends on the use of **Microsoft.VisualBasic.MyServices** types and their members, there are corresponding types and members in the .NET class library. The following is a mapping of  **Microsoft.VisualBasic.MyServices** types to their equivalent .NET class library types:

|Microsoft.VisualBasic.MyServices type|.NET class library type|
|--|--|
|<xref:Microsoft.VisualBasic.MyServices.ClipboardProxy>|<xref:System.Windows.Clipboard?displayProperty=nameWithType> for WPF applications, <xref:System.Windows.Forms.Clipboard?displayProperty=nameWithType> for Windows Forms applications|
|<xref:Microsoft.VisualBasic.MyServices.FileSystemProxy>|Types in the <xref:System.IO> namespace|
|<xref:Microsoft.VisualBasic.MyServices.RegistryProxy>|Registry-related types in the <xref:Microsoft.Win32> namespace|
|<xref:Microsoft.VisualBasic.MyServices.SpecialDirectoriesProxy>|<xref:System.Environment.GetFolderPath%2A?displayProperty=nameWithType>|

#### Category

Visual Basic

#### Affected APIs

- <xref:Microsoft.VisualBasic.MyServices?displayProperty=fullName>

<!--

#### Affected APIs

- `N:Microsoft.VisualBasic.MyServices`

-->
