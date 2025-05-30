### CspParameters.ParentWindowHandle now expects HWND value

#### Details

The <xref:System.Security.Cryptography.CspParameters.ParentWindowHandle> value, introduced in .NET Framework 2.0, allows an application to register a parent window handle value such that any UI required to access the key (such as a PIN prompt or consent dialog) opens as a modal child to the specified window.Starting with apps that target the .NET Framework 4.7, a Windows Forms application can set the <xref:System.Security.Cryptography.CspParameters.ParentWindowHandle> property with code like the following:

```csharp
cspParameters.ParentWindowHandle = form.Handle;
```

In previous versions of the .NET Framework, the value was expected to be an <xref:System.IntPtr?displayProperty=fullName> representing a location in memory where the [HWND](/windows/desktop/WinProg/windows-data-types#HWND) value resided. Setting the property to form.Handle on Windows 7 and earlier versions had no effect, but on Windows 8 and later versions, it results in a &quot;<xref:System.Security.Cryptography.CryptographicException?displayProperty=fullName>: The parameter is incorrect.&quot;

#### Suggestion

Applications targeting .NET Framework 4.7 or higher wishing to register a parent window relationship are encouraged to use the simplified form:

```csharp
cspParameters.ParentWindowHandle = form.Handle;
```

Users who had identified that the correct value to pass was the address of a memory location which held the value `form.Handle` can opt out of the behavior change by setting the AppContext switch `Switch.System.Security.Cryptography.DoNotAddrOfCspParentWindowHandle` to `true`:

- By programmatically setting compat switches on the AppContext, as explained in [.NET Announcements at Build 2015](https://devblogs.microsoft.com/dotnet/net-announcements-at-build-2015/#dotnet46).
- By adding the following line to the `<runtime>` section of the app.config file:

```xml
<runtime>
 <AppContextSwitchOverrides value="Switch.System.Security.Cryptography.DoNotAddrOfCspParentWindowHandle=true"/>
</runtime>
```

Conversely, users who wish to opt in to the new behavior on the .NET Framework 4.7 runtime when the application loads under older .NET Framework versions can set the AppContext switch to `false`.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.7         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Security.Cryptography.CspParameters.ParentWindowHandle?displayProperty=nameWithType>
