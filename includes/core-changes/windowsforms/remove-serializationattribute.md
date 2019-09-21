### SerializableAttribute removed from some Windows Forms types

The <xref:System.SerializableAttribute> has been removed from some Windows Forms classes that have no known binary serialization scenarios.

#### Change description

The following types are decorated with the <xref:System.SerializableAttribute> in .NET Framework, but the attribute has been removed in .NET Core:

- `System.InvariantComparer`
- <xref:System.ComponentModel.Design.ExceptionCollection?displayProperty=nameWithType>
- <xref:System.ComponentModel.Design.Serialization.CodeDomSerializerException?displayProperty=nameWithType>
- `System.ComponentModel.Design.Serialization.CodeDomComponentSerializationService.CodeDomSerializationStore`
- <xref:System.Drawing.Design.ToolboxItem?displayProperty=nameWithType>
- `System.Resources.ResXNullRef`
- `System.Resources.ResXDataNode`
- `System.Resources.ResXFileRef`
- <xref:System.Windows.Forms.Cursor?displayProperty=nameWithType>
- `System.Windows.Forms.NativeMethods.MSOCRINFOSTRUCT`
- `System.Windows.Forms.NativeMethods.MSG`

Historically, this serialization mechanism has had serious maintenance and security concerns. Maintaining `SerializableAttribute` on types means those types must be tested for version-to-version serialization changes and potentially framework-to-framework serialization changes. This makes it harder to evolve those types and can be costly to maintain. These types have no known binary serialization scenarios, which minimizes the impact of removing the attribute.

For more information, see <https://docs.microsoft.com/en-us/dotnet/standard/serialization/binary-serialization>.

#### Version introduced

3.0 Preview 9

#### Recommended action

Update any code that may depend on these types being marked as serializable.

#### Category

Windows Forms

#### Affected APIs

- None

<!--

### Affected APIs

- Not detectable via API analysis

-->
