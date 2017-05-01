### Workflow SQL persistence adds primary key clusters and disallows null values in some columns

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.7, the tables created for the SQL Workflow Instance Store (SWIS) by the SqlWorkflowInstanceStoreSchema.sql script use clustered primary keys. Because of this, identities do not support <code>null</code> values. The operation of SWIS is not impacted by this change. The updates were made to support SQL Server Transactional Replication.|
|Suggestion|The SQL file SqlWorkflowInstanceStoreSchemaUpgrade.sql must be applied to existing installations in order to experience this change. New database installations will automatically have the change.|
|Scope|Edge|
|Version|4.7|
|Type|Runtime|
