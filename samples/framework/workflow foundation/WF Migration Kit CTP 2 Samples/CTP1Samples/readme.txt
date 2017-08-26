WF Migration Kit samples

Instructions

1. Open the WF3Workflows/WF3Workflows solution and compile.

This solution contains two WF3 workflows and some custom activities.


2. Open the WFMigrationSamples solution, compile, and run.

This solution shows how to programmatically migrate the workflows defined in WF3Workflows.

It provides a custom migrator for the Write activity.
It shows (in commented code) how to use an ActivityTypeMapping in place of this custom migrator.
It includes a second custom migrator for unsupported activities.

Please note that the behavior of the UnsupportedActivityMigrator is such that when a source workflow containing a CodeActivity is migrated, migration succeeds but a ReportMigrationError activity (defined in this solution) is emitted in place of the CodeActivity.  This activity raises a WF validation error, thus preventing the target workflow from executing.