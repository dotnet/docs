### Change in behavior in Data Definition Language (DDL) APIs

|   |   |
|---|---|
|Details|The behavior of DDL APIs when AttachDBFilename is specified has changed as follows:<ul><li>Connection strings need not specify an Initial Catalog value. Previously, both AttachDBFilename and Initial Catalog were required.</li><li>If both AttatchDBFilename and Initial Catalog are specified and the given MDF file exists, the ObjectContext.DatabaseExists method returns true. Previously, it returned false.</li><li>If both AttatchDBFilename and Initial Catalog are specified and the given MDF file exists, calling the ObjectContext.DeleteDatabase method deletes the files.</li><li>If ObjectContext.DeleteDatabase is called when the connection string specifies an AttachDBFilename value with an MDF that doesn&#39;t exist and an Initial Catalog that doesn&#39;t exist, the method throws an InvalidOperationException exception. Previously, it threw a SqlException exception.</li></ul>|
|Suggestion|These changes make it easier to build tools and applications that use the DDL APIs. These changes can affect application compatibility in the following scenarios:<ul><li>The user writes code that executes a DROP DATABASE command directly instead of calling ObjectContext.DeleteDatabase if ObjectContext.DatabaseExists returns true. This breaks existing code If the database is not attached but the MDF file exists.</li><li>The user writes code that expects the ObjectContext.DeleteDatabase method to throw a SqlException exception rather than an InvalidOperationException exception when the Initial Catalog and MDF file don&#39;t exist.</li></ul>|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Analyzers|<ul><li>CD0027</li></ul>|

