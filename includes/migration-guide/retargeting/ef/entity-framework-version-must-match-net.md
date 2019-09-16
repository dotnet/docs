### Entity Framework version must match the .NET Framework version

|   |   |
|---|---|
|Details|The entity framework version should be matched with the .NET framework version. Entity Framework 5 is recommended for .NET Framework 4.5. There are some known issues with EF 4.x in a .NET Framework 4.5 project around <xref:System.ComponentModel.DataAnnotations>. In .NET 4.5, these were moved to a different assembly, so there are issues determining which annotations to use.|
|Suggestion|Upgrade to Entity Framework 5 for .NET Framework 4.5|
|Scope|Major|
|Version|4.5|
|Type|Retargeting|
