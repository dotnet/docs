WF Migration Kit Sample for State Machine

Instructions

1. Open Begin/StateMachineMigrationSample.sln, and compile DelayStateMachine3 project. You'll receive a DelayStateMachine3.dll file.

2. Execute the migration with command line: WfMigration DelayStateMachine3.dll, and a DelayWorkflow.xaml will be generated under the same folder.

3. Copy DelayWorkflow.xaml to the DelayStateMachine4 project, and start debugging.

4. You'll notice that some custom code activities have been emitted with WF4 WriteLine activities. You have to manually modify that.

For more information on migration details, please refer to WF Migration Kit User Guide.