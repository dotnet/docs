### Deserialization of objects across appdomains can fail

#### Details

In some cases, when an app uses two or more app domains with different application bases, trying to deserialize objects in the logical call context across app domains throws an exception.

#### Suggestion

See [Mitigation: Deserialization of Objects Across App Domains](~/docs/framework/migration-guide/mitigation-deserialization-of-objects-across-app-domains.md)

| Name    | Value       |
|:--------|:------------|
| Scope   |Edge|
|Version|4.5.1|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
