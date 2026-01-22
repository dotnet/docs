<!-- Orleans 10.0 Breaking Changes summary -->

## Breaking changes summary

| Breaking change | Impact | Migration |
|-----------------|--------|-----------|
| `AddGrainCallFilter` removed | Compile error | Use `AddIncomingGrainCallFilter` |
| `LeaseAquisitionPeriod` typo fixed | Compile error | Use `LeaseAcquisitionPeriod` |
| `LoadSheddingLimit` renamed | Compile error | Use `CpuThreshold` |
| `CancelRequestOnTimeout` default changed | Behavioral | Explicitly set to `true` if needed |
| ADO.NET provider requires `Microsoft.Data.SqlClient` | Compile/Runtime error | Replace `System.Data.SqlClient` package |
| `[Unordered]` attribute obsoleted | Warning | Remove attribute (has no effect) |
| `OrleansConstructorAttribute` obsoleted | Warning | Use <xref:Orleans.GeneratedActivatorConstructorAttribute> |
| `RegisterTimer` obsoleted | Warning | Use `RegisterGrainTimer` |
