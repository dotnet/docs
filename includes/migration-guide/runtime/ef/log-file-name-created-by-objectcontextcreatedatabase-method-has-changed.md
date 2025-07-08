### Log file name created by the ObjectContext.CreateDatabase method has changed to match SQL Server specifications

#### Details

When the <xref:System.Data.Objects.ObjectContext.CreateDatabase?displayProperty=fullName> method is called either directly or by using Code First with the SqlClient provider and an AttachDBFilename value in the connection string, it creates a log file named filename_log.ldf instead of filename.ldf (where filename is the name of the file specified by the AttachDBFilename value). This change improves debugging by providing a log file named according to SQL Server specifications.

#### Suggestion

If the log file name is important for an app, the app should be updated to expect the standard _log.ldf file name format.

|             | Value   |
|:------------|:--------|
| **Scope**   | Edge    |
| **Version** | 4.5     |
| **Type**    | Runtime |

#### Affected APIs

- <xref:System.Data.Objects.ObjectContext.CreateDatabase?displayProperty=nameWithType>

<!--

#### Affected APIs

- `M:System.Data.Objects.ObjectContext.CreateDatabase`

-->
