### Sql_variant data uses sql_variant collation rather than database collation

|   |   |
|---|---|
|Details|<code>sql_variant</code> data uses <code>sql_variant</code> collation rather than database collation.|
|Suggestion|This change addresses possible data corruption if the database collation differs from the <code>sql_variant</code> collation. Applications that rely on the corrupted data may experience failure.|
|Scope|Transparent|
|Version|4.5|
|Type|Runtime|
