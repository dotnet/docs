### APIs that report version now report product and not file version

Many of the APIs that return versions in .NET Core now return the product version rather than the file version.

#### Change description

In .NET Core 2.2 and previous versions, methods such as <xref:System.Environment.Version?displayProperty=nameWithType>, <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=nameWithType>, and the file properties dialog for .NET Core assemblies reflect the file version. Starting with .NET Core 3.0, they reflect the product version.

The following figure illustrates the difference in version information for the *System.Runtime.dll* assembly for .NET Core 2.2 (on the left) and .NET Core 3.0 (on the right) as displayed by the **Windows Explorer** file properties dialog.

![Difference in product version information](~/docs/images/core-changes/corefx/version-information-changes/file-details.png)

#### Version introduced

3.0

#### Recommended action

None. This change should make version detection intuitive rather than obtuse.

#### Category

CoreFx

#### Affected APIs

- <xref:System.Environment.Version?displayProperty=nameWithType>
- <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=nameWithType>

<!--

### Affected APIs

- `P:System.Environment.Version`
- `P:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription`

-->
