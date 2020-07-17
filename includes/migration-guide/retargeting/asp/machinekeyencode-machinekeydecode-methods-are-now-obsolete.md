### MachineKey.Encode and MachineKey.Decode methods are now obsolete

#### Details

These methods are now obsolete. Compilation of code that calls these methods produces a compiler warning.

#### Suggestion

The recommended alternatives are <xref:System.Web.Security.MachineKey.Protect(System.Byte[],System.String[])> and <xref:System.Web.Security.MachineKey.Unprotect(System.Byte[],System.String[])>. Alternatively, the build warnings can be suppressed, or they can be avoided by using an older compiler. The APIs are still supported.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.5         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Web.Security.MachineKey.Encode(System.Byte[],System.Web.Security.MachineKeyProtection)?displayProperty=nameWithType>
- <xref:System.Web.Security.MachineKey.Decode(System.String,System.Web.Security.MachineKeyProtection)?displayProperty=nameWithType>
