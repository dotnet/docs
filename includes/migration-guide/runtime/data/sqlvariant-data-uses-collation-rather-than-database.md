### Sql_variant data uses sql_variant collation rather than database collation

#### Details

`sql_variant` data uses `sql_variant` collation rather than database collation.

#### Suggestion

This change addresses possible data corruption if the database collation differs from the `sql_variant` collation. Applications that rely on the corrupted data may experience failure.

| Name    | Value       |
|:--------|:------------|
| Scope   |Transparent|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
