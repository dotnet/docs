### XML parsing changes

#### Details

For security reasons, the following changes were introduced into XML parsing APIS:

- <xref:System.Xml.XmlReaderSettings.MaxCharactersFromEntities?displayProperty=nameWithType> is set to 10 million when <xref:System.Xml.XmlReaderSettings> is initialized.
- <xref:System.Xml.XmlReaderSettings.XmlResolver?displayProperty=nameWithType> is set to `null` by default.

> [!NOTE]
> <xref:System.Xml.XmlReaderSettings> is used by all XML parsers, so while this change helps the <xref:System.Xml.XmlReader> case, it also affects other scenarios.

#### Suggestion

To revert to the previous behavior, set [\<EnableLegacyXmlSettings> element](../../../../docs/framework/configure-apps/file-schema/runtime/enablelegacyxmlsettings-element.md) to `1`.

| Name    | Value   |
|:--------|:--------|
| Scope   | Minor   |
| Version | 4.5.2   |
| Type    | Runtime |

#### Affected APIs

- <xref:System.Xml.XmlReaderSettings.MaxCharactersFromEntities?displayProperty=fullName>
- <xref:System.Xml.XmlReaderSettings.XmlResolver?displayProperty=fullName>

<!--

#### Affected APIs

- `P:System.Xml.XmlReaderSettings.MaxCharactersFromEntities`
- `P:System.Xml.XmlReaderSettings.XmlResolver`

-->
