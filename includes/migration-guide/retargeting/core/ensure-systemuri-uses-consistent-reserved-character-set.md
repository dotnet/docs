### Ensure System.Uri uses a consistent reserved character set

#### Details

In <xref:System.Uri?displayProperty=fullName>, certain percent-encoded characters that were sometimes decoded are now consistently left encoded. This occurs across the properties and methods that access the path, query, fragment, or userinfo components of the URI. The behavior will change only when both of the following are true:

- The URI contains the encoded form of any of the following reserved characters: `:`, `'`, `(`, `)`, `!` or `*`.
- The URI contains a Unicode or encoded non-reserved character. If both of the above are true, the encoded reserved characters are left encoded. In previous versions of the .NET Framework, they are decoded.

#### Suggestion

For applications that target versions of .NET Framework starting with 4.7.2, the new decoding behavior is enabled by default. If this change is undesirable, you can disable it by adding the following [AppContextSwitchOverrides](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) switch to the `<runtime>` section of the application configuration file:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.System.Uri.DontEnableStrictRFC3986ReservedCharacterSets=true" />
</runtime>
```

For applications that target earlier versions of the .NET Framework but are running under versions starting with .NET Framework 4.7.2, the new decoding behavior is disabled by default. You can enable it by adding the following [AppContextSwitchOverrides](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) switch to the `<runtime>` section of the application configuration file:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.System.Uri.DontEnableStrictRFC3986ReservedCharacterSets=false" />
</runtime>
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.7.2       |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Uri?displayProperty=nameWithType>
