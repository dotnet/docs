### Some .NET APIs cause first chance (handled) EntryPointNotFoundExceptions

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, a small number of .NET methods began throwing first chance <xref:System.EntryPointNotFoundException?displayProperty=name>s. These exceptions were handled within the .Net Framework, but could break test automation that did not expect the first chance exceptions. These same APIs break some ApiVerifier scenarios when HighVersionLie is enabled.|
|Suggestion|This bug can be avoided by upgrading to .NET Framework 4.5.1. Alternatively, test automation can be updated to not break on first-chance <xref:System.EntryPointNotFoundException?displayProperty=name>s.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Diagnostics.Debug.Assert(System.Boolean)?displayProperty=fullName></li><li><xref:System.Diagnostics.Debug.Assert(System.Boolean%2CSystem.String)?displayProperty=fullName></li><li><xref:System.Diagnostics.Debug.Assert(System.Boolean%2CSystem.String%2CSystem.String)?displayProperty=fullName></li><li><xref:System.Diagnostics.Debug.Assert(System.Boolean%2CSystem.String%2CSystem.String%2CSystem.Object%5B%5D)?displayProperty=fullName></li><li><xref:System.Xml.Serialization.XmlSerializer.%23ctor(System.Type)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0085</li></ul>|

