### Types in Microsoft.VisualBasic.ApplicationServices namespace not available

The types in the <xref:Microsoft.VisualBasic.ApplicationServices?displayProperty=fullName> namespace are not available.

#### Version introduced

.NET Core 3.0 Preview 8

#### Details

The types in the <xref:Microsoft.VisualBasic.ApplicationServices?displayProperty=fullName> namespace were available in some .NET Core 3.0 Preview releases. They are no longer available starting with .NET Core 3.0 Preview 9.

The types were removed to avoid unnecessary assembly dependencies or breaking changes in subsequent releases.
 
#### Recommended action

If your code depends on the use of <xref:Microsoft.VisualBasic.ApplicationServices> types and their members, you may be able to use a corresponding type or member in the .NET class library. For example, some <xref:System.Environment?displayProperty=nameWithType> and <xref:System.Security.Principal.WindowsIdentity?displayProperty=nameWithType> members provide equivalent functionality to the properties of the <xref:Microsoft.VisualBasic.ApplicationServices.User?displayProperty=nameWithType> class.

#### Category

Visual Basic

#### Affected APIs

- <xref:Microsoft.VisualBasic.ApplicationServices?displayProperty=fullName>

<!--

### Affected APIs

- `N:Microsoft.VisualBasic.ApplicationServices`

-- >

