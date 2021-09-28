---
description: "Learn more about: Tracking Events Reference"
title: "Tracking Events Reference"
ms.date: "03/30/2017"
ms.assetid: c1c1ee87-f80a-449b-acd0-50d81eef116e
---
# Tracking Events Reference

During execution a workflow in [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] raises tracking events as it moves through various stages in its lifetime. The host can subscribe to these events and keep updated on the status of the workflow’s progress during its lifetime. The tracking events raised are discussed in this section.  
  
## Event Reference  
  
|Event ID|Event Level|Event Message|Keywords|  
|--------------|-----------------|-------------------|--------------|  
|[100 - WorkflowInstanceRecord](100-workflowinstancerecord.md)|Information|TrackRecord= WorkflowInstanceRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, State = %5, Annotations = %6, ProfileName = %7|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[101 - WorkflowInstanceUnhandledExceptionRecord](101-workflowinstanceunhandledexceptionrecord.md)|Error|TrackRecord = WorkflowInstanceUnhandledExceptionRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, SourceName = %5, SourceId = %6, SourceInstanceId = %7, SourceTypeName=%8, Exception=%9, Annotations= %10, ProfileName = %11|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[102 - WorkflowInstanceAbortedRecord](102-workflowinstanceabortedrecord.md)|Warning|TrackRecord = WorkflowInstanceAbortedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, Reason = %5, Annotations = %6, ProfileName = %7|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[103 - ActivityStateRecord](103-activitystaterecord.md)|Information|TrackRecord = ActivityStateRecord, InstanceID = %1, RecordNumber=%2, EventTime=%3, State = %4, Name=%5, ActivityId=%6, ActivityInstanceId=%7, ActivityTypeName=%8, Arguments=%9, Variables=%10, Annotations=%11, ProfileName = %12|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[104 - ActivityScheduledRecord](104-activityscheduledrecord.md)|Information|TrackRecord = ActivityScheduledRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, Name = %4, ActivityId = %5, ActivityInstanceId = %6, ActivityTypeName = %7, ChildActivityName = %8, ChildActivityId = %9, ChildActivityInstanceId = %10, ChildActivityTypeName =%11, Annotations=%12, ProfileName = %13|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[105 - FaultPropagationRecord](105-faultpropagationrecord.md)|Warning|TrackRecord = FaultPropagationRecord, InstanceID=%1, RecordNumber=%2, EventTime=%3, FaultSourceActivityName=%4, FaultSourceActivityId=%5, FaultSourceActivityInstanceId=%6, FaultSourceActivityTypeName=%7, FaultHandlerActivityName=%8, FaultHandlerActivityId = %9, FaultHandlerActivityInstanceId =%10, FaultHandlerActivityTypeName=%11, Fault=%12, IsFaultSource=%13, Annotations=%14, ProfileName = %15|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[106 - CancelRequestRecord](106-cancelrequestrecord.md)|Information|TrackRecord = CancelRequestedRecord, InstanceID=%1, RecordNumber=%2, EventTime=%3, Name=%4, ActivityId=%5, ActivityInstanceId=%6, ActivityTypeName = %7, ChildActivityName = %8, ChildActivityId = %9, ChildActivityInstanceId = %10, ChildActivityTypeName =%11, Annotations=%12, ProfileName = %13|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[107 -- BookmarkResumptionRecord](107-bookmarkresumptionrecord.md)|Information|TrackRecord = BookmarkResumptionRecord, InstanceID=%1, RecordNumber=%2,EventTime=%3, Name=%4, SubInstanceID=%5, OwnerActivityName=%6, OwnerActivityId =%7, OwnerActivityInstanceId=%8, OwnerActivityTypeName=%9, Annotations=%10, ProfileName = %11|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[108 - CustomTrackingRecordInfo](108-customtrackingrecordinfo.md)|Information|TrackRecord = CustomTrackingRecord, InstanceID = %1, RecordNumber=%2, EventTime=%3, Name=%4, ActivityName=%5, ActivityId=%6, ActivityInstanceId=%7, ActivityTypeName=%8, Data=%9, Annotations=%10, ProfileName = %11|UserEvents, EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[110 - CustomTrackingRecordWarning](110-customtrackingrecordwarning.md)|Warning|TrackRecord = CustomTrackingRecord, InstanceID = %1, RecordNumber=%2, EventTime=%3, Name=%4, ActivityName=%5, ActivityId=%6, ActivityInstanceId=%7, ActivityTypeName=%8, Data=%9, Annotations=%10, ProfileName = %11|UserEvents, EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[111 - CustomTrackingRecordError](111-customtrackingrecorderror.md)|Error|TrackRecord = CustomTrackingRecord, InstanceID = %1, RecordNumber=%2, EventTime=%3, Name=%4, ActivityName=%5, ActivityId=%6, ActivityInstanceId=%7, ActivityTypeName=%8, Data=%9, Annotations=%10, ProfileName = %11|UserEvents, EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[112 - WorkflowInstanceSuspendedRecord](112-workflowinstancesuspendedrecord.md)|Information|TrackRecord = WorkflowInstanceSuspendedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, Reason = %5, Annotations = %6, ProfileName = %7|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[113 - WorkflowInstanceTerminatedRecord](113-workflowinstanceterminatedrecord.md)|Error|TrackRecord = WorkflowInstanceTerminatedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, Reason = %5, Annotations = %6, ProfileName = %7|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|[114 - WorkflowInstanceRecordWithId](114-workflowinstancerecordwithid.md)|Information|TrackRecord= WorkflowInstanceRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, State = %5, Annotations = %6, ProfileName = %7, WorkflowDefinitionIdentity = %8|HealthMonitoring, WFTracking|  
|[115 - WorkflowInstanceAbortedRecordWithId](115-workflowinstanceabortedrecordwithid.md)|Warning|TrackRecord = WorkflowInstanceAbortedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, Reason = %5,  Annotations = %6, ProfileName = %7, WorkflowDefinitionIdentity = %8|HealthMonitoring, WFTracking|  
|[116 - WorkflowInstanceSuspendedRecordWithId](116-workflowinstancesuspendedrecordwithid.md)|Information|TrackRecord = WorkflowInstanceSuspendedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, Reason = %5, Annotations = %6, ProfileName = %7, WorkflowDefinitionIdentity = %8|HealthMonitoring, WFTracking|  
|[117 - WorkflowInstanceTerminatedRecordWithId](117-workflowinstanceterminatedrecordwithid.md)|Error|TrackRecord = WorkflowInstanceTerminatedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, Reason = %5,  Annotations = %6, ProfileName = %7, WorkflowDefinitionIdentity = %8|HealthMonitoring, WFTracking|  
|[118 - WorkflowInstanceUnhandledExceptionRecordWithId](118-workflowinstanceunhandledexceptionrecordwithid.md)|Error|TrackRecord = WorkflowInstanceUnhandledExceptionRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, SourceName = %5, SourceId = %6, SourceInstanceId = %7, SourceTypeName=%8, Exception=%9,  Annotations= %10, ProfileName = %11, WorkflowDefinitionIdentity = %12|HealthMonitoring, WFTrackingHealthMonitoring, WFTracking|  
|[119 - WorkflowInstanceUpdatedRecord](119-workflowinstanceupdatedrecord.md)|Information|TrackRecord= WorkflowInstanceUpdatedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, State = %5, OriginalDefinitionIdentity = %6, UpdatedDefinitionIdentity = %7, Annotations = %8, ProfileName = %9|HealthMonitoring, WFTracking|  
|[225 - TraceCorrelationKeys](225-tracecorrelationkeys.md)|Information|Calculated correlation key '%1' using values '%2' in parent scope '%3'.|Troubleshooting WFServices|  
|[440 - StartSignpostEvent1](440-startsignpostevent.md)|Information|Activity boundary.|Troubleshooting WFServices|  
|[441- StopSignpostEvent1](441-stopsignpostevent.md)|Information|Activity boundary.|Troubleshooting WFServices|  
|[1001 - WorkflowApplicationCompleted](1001-workflowapplicationcompleted.md)|Information|WorkflowInstance Id: '%1' has completed in the Closed state.|WFRuntime|  
|[1002 - WorkflowApplicationTerminated](1002-workflowapplicationterminated.md)|Information|WorkflowApplication Id: '%1' was terminated. It has completed in the Faulted state with an exception.|WFRuntime|  
|[1003 - WorkflowInstanceCanceled](1003-workflowinstancecanceled.md)|Information|WorkflowInstance Id: '%1' has completed in the Canceled state.|WFRuntime|  
|[1004 - WorkflowInstanceAborted](1004-workflowinstanceaborted.md)|Information|WorkflowInstance Id: '%1' was aborted with an exception.|WFRuntime|  
|[1005 - WorkflowApplicationIdled](1005-workflowapplicationidled.md)|Information|WorkflowApplication Id: '%1' went idle.|WFRuntime|  
|[1006 - WorkflowApplicationUnhandledException](1006-workflowapplicationunhandledexception.md)|Error|WorkflowInstance Id: '%1' has encountered an unhandled exception.  The exception originated from Activity '%2', DisplayName: '%3'.  The following action will be taken: %4.|WFRuntime|  
|[1007 - WorkflowApplicationPersisted](1007-workflowapplicationpersisted.md)|Information|WorkflowApplication Id: '%1' was Persisted.|WFRuntime|  
|[1008 - WorkflowApplicationUnloaded](1008-workflowapplicationunloaded.md)|Information|WorkflowInstance Id: '%1' was Unloaded.|WFRuntime|  
|[1009 - ActivityScheduled](1009-activityscheduled.md)|Information|Parent Activity '%1', DisplayName: '%2', InstanceId: '%3' scheduled child Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1010 - ActivityCompleted](1010-activitycompleted.md)|Information|Parent Activity '%1', DisplayName: '%2', InstanceId: '%3' scheduled child Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1011 - ScheduleExecuteActivityWorkItem](1011-scheduleexecuteactivityworkitem.md)|Verbose|An ExecuteActivityWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1012 - StartExecuteActivityWorkItem](1012-startexecuteactivityworkitem.md)|Verbose|Starting execution of an ExecuteActivityWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1013 - CompleteExecuteActivityWorkItem](1013-completeexecuteactivityworkitem.md)|Verbose|An ExecuteActivityWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1014 - ScheduleCompletionWorkItem](1014-schedulecompletionworkitem.md)|Verbose|A CompletionWorkItem has been scheduled for parent Activity '%1', DisplayName: '%2', InstanceId: '%3'.  Completed Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1015 - StartCompletionWorkItem](1015-startcompletionworkitem.md)|Verbose|Starting execution of a CompletionWorkItem for parent Activity '%1', DisplayName: '%2', InstanceId: '%3'. Completed Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1016 - CompleteCompletionWorkItem](1016-completecompletionworkitem.md)|Verbose|A CompletionWorkItem has completed for parent Activity '%1', DisplayName: '%2', InstanceId: '%3'. Completed Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1017 - ScheduleCancelActivityWorkItem](1017-schedulecancelactivityworkitem.md)|Verbose|A CancelActivityWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1018 - StartCancelActivityWorkItem](1018-startcancelactivityworkitem.md)|Verbose|Starting execution of a CancelActivityWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1019 - CompleteCancelActivityWorkItem](1019-completecancelactivityworkitem.md)|Verbose|A CancelActivityWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1020 - CreateBookmark](1020-createbookmark.md)|Verbose|A Bookmark has been created for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  BookmarkName: %4, BookmarkScope: %5.|WFRuntime|  
|[1021 - ScheduleBookmarkWorkItem](1021-schedulebookmarkworkitem.md)|Verbose|A BookmarkWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  BookmarkName: %4, BookmarkScope: %5.|WFRuntime|  
|[1022 - StartBookmarkWorkItem](1022-startbookmarkworkitem.md)|Verbose|Starting execution of a BookmarkWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  BookmarkName: %4, BookmarkScope: %5.|WFRuntime|  
|[1023 - CompleteBookmarkWorkItem](1023-completebookmarkworkitem.md)|Verbose|A BookmarkWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'. BookmarkName: %4, BookmarkScope: %5.|WFRuntime|  
|[1024 - CreateBookmarkScope](1024-createbookmarkscope.md)|Verbose|A BookmarkScope has been created: %1.|WFRuntime|  
|[1025 - BookmarkScopeInitialized](1025-bookmarkscopeinitialized.md)|Verbose|The BookmarkScope that had TemporaryId: '%1' has been initialized with Id: '%2'.|WFRuntime|  
|[1026 - ScheduleTransactionContextWorkItem](1026-scheduletransactioncontextworkitem.md)|Verbose|A TransactionContextWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1027 - StartTransactionContextWorkItem](1027-starttransactioncontextworkitem.md)|Verbose|Starting execution of a TransactionContextWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1028 - CompleteTransactionContextWorkItem](1028-completetransactioncontextworkitem.md)|Verbose|A TransactionContextWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1029 - ScheduleFaultWorkItem](1029-schedulefaultworkitem.md)|Verbose|A FaultWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  The exception was propagated from Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1030 - StartFaultWorkItem](1030-startfaultworkitem.md)|Verbose|Starting execution of a FaultWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  The exception was propagated from Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1031 - CompleteFaultWorkItem](1031-completefaultworkitem.md)|Verbose|A FaultWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'. The exception was propagated from Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1032 - ScheduleRuntimeWorkItem](1032-scheduleruntimeworkitem.md)|Verbose|A runtime work item has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1033 - StartRuntimeWorkItem](1033-startruntimeworkitem.md)|Verbose|Starting execution of a runtime work item for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1034 - CompleteRuntimeWorkItem](1034-completeruntimeworkitem.md)|Verbose|A runtime work item has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.|WFRuntime|  
|[1035 - RuntimeTransactionSet](1035-runtimetransactionset.md)|Verbose|The runtime transaction has been set by Activity '%1', DisplayName: '%2', InstanceId: '%3'.  Execution isolated to Activity '%4', DisplayName: '%5', InstanceId: '%6'.|WFRuntime|  
|[1036 - RuntimeTransactionCompletionRequested](1036-runtimetransactioncompletionrequested.md)|Verbose|Activity '%1', DisplayName: '%2', InstanceId: '%3' has scheduled completion of the runtime transaction.|WFRuntime|  
|[1037 - RuntimeTransactionComplete](1037-runtimetransactioncomplete.md)|Verbose|The runtime transaction has completed with the state '%1'.|WFRuntime|  
|[1038 - EnterNoPersistBlock](1038-enternopersistblock.md)|Verbose|Entering a no persist block.|WFRuntime|  
|[1039 - ExitNoPersistBlock](1039-exitnopersistblock.md)|Verbose|Exiting a no persist block.|WFRuntime|  
|[1040 - InArgumentBound](1040-inargumentbound.md)|Verbose|In argument '%1' on Activity '%2', DisplayName: '%3', InstanceId: '%4' has been bound with value: %5.|WFActivities|  
|[1041 - WorkflowApplicationPersistableIdle](1041-workflowapplicationpersistableidle.md)|Information|WorkflowApplication Id: '%1' is idle and persistable.  The following action will be taken: %2.|WFRuntime|  
|[1101 - WorkflowActivityStart](1101-workflowactivitystart.md)|Information|WorkflowInstance Id: '%1' E2E Activity|WFRuntime|  
|[1102 - WorkflowActivityStop](1102-workflowactivitystop.md)|Information|WorkflowInstance Id: '%1' E2E Activity|WFRuntime|  
|[1103 - WorkflowActivitySuspend](1103-workflowactivitysuspend.md)|Information|WorkflowInstance Id: '%1' E2E Activity|WFRuntime|  
|[1104 - WorkflowActivityResume](1104-workflowactivityresume.md)|Information|WorkflowInstance Id: '%1' E2E Activity|WFRuntime|  
|[1124 - InvokeMethodIsStatic](1124-invokemethodisstatic.md)|Information|InvokeMethod '%1' - method is Static.|WFRuntime|  
|[1125 - InvokeMethodIsNotStatic](1125-invokemethodisnotstatic.md)|Information|InvokeMethod '%1' - method is not Static.|WFRuntime|  
|[1126 - InvokedMethodThrewException](1126-invokedmethodthrewexception.md)|Information|An exception was thrown in the method called by the activity '%1'. %2|WFRuntime|  
|[1131 - InvokeMethodUseAsyncPattern](1131-invokemethoduseasyncpattern.md)|Information|InvokeMethod '%1' - method uses asynchronous pattern of '%2' and '%3'.|WFRuntime|  
|[1132 - InvokeMethodDoesNotUseAsyncPattern](1132-invokemethoddoesnotuseasyncpattern.md)|Information|InvokeMethod '%1' - method does not use asynchronous pattern.|WFRuntime|  
|[1140 - FlowchartStart](1140-flowchartstart.md)|Information|Flowchart '%1' - Start has been scheduled.|WFActivities|  
|[1141 - FlowchartEmpty](1141-flowchartempty.md)|Warning|Flowchart '%1' - was executed with no Nodes. An exception was thrown in the method called by the activity '%1'. %2|WFActivities|  
|[1143 - FlowchartNextNull](1143-flowchartnextnull.md)|Information|Flowchart '%1'/FlowStep - Next node is null. Flowchart execution will end.|WFActivities|  
|[1146 - FlowchartSwitchCase](1146-flowchartswitchcase.md)|Information|Flowchart '%1'/FlowSwitch - Case '%2' was selected.|WFActivities|  
|[1147 - FlowchartSwitchDefault](1147-flowchartswitchdefault.md)|Information|Flowchart '%1'/FlowSwitch - Default Case was selected.|WFActivities|  
|[1148 - FlowchartSwitchCaseNotFound](1148-flowchartswitchcasenotfound.md)|Information|Flowchart '%1'/FlowSwitch - could find neither a Case activity nor a Default Case matching the Expression result. Flowchart execution will end.|WFActivities|  
|[1150 - CompensationState](1150-compensationstate.md)|Information|CompensableActivity '%1' is in the '%2' state.|WFActivities|  
|[1223 - SwitchCaseNotFound](1223-switchcasenotfound.md)|Information|The Switch activity '%1' could not find a Case activity matching the Expression result.|WFActivities|  
|[1449 - WfMessageReceived](1449-wfmessagereceived.md)|Information|Message received by workflow|WFServices|  
|[1450 - WfMessageSent](1450-wfmessagesent.md)|Information|Message sent from workflow|WFServices|  
|[2021 - ExecuteWorkItemStart](2021-executeworkitemstart.md)|Verbose|Execute work item start|WFRuntime|  
|[2022 - ExecuteWorkItemStop](2022-executeworkitemstop.md)|Verbose|Execute work item stop|WFRuntime|  
|[2023 - SendMessageChannelCacheMiss](2023-sendmessagechannelcachemiss.md)|Verbose|SendMessageChannelCache miss|WFRuntime|  
|[2024 - InternalCacheMetadataStart](2024-internalcachemetadatastart.md)|Verbose|InternalCacheMetadata started on activity '%1'.|WFRuntime|  
|[2025 - InternalCacheMetadataStop](2025-internalcachemetadatastop.md)|Verbose|InternalCacheMetadata stopped on activity '%1'.|WFRuntime|  
|[2026 - CompileVbExpressionStart](2026-compilevbexpressionstart.md)|Verbose|Compiling VB expression '%1'|WFRuntime|  
|[2027 - CacheRootMetadataStart](2027-cacherootmetadatastart.md)|Verbose|CacheRootMetadata started on activity '%1'|WFRuntime|  
|[2028 - CacheRootMetadataStop](2028-cacherootmetadatastop.md)|Verbose|CacheRootMetadata stopped on activity %1.|WFRuntime|  
|[2029 - CompileVbExpressionStop](2029-compilevbexpressionstop.md)|Verbose|Finished compiling VB expression.|WFRuntime|  
|[2576 - TryCatchExceptionFromTry](2576-trycatchexceptionfromtry.md)|Information|The TryCatch activity '%1' has caught an exception of type '%2'.|WFActivities|  
|[2577 - TryCatchExceptionDuringCancelation](2577-trycatchexceptionduringcancelation.md)|Warning|A child activity of the TryCatch activity '%1' has thrown an exception during cancelation.|WFActivities|  
|[2578 - TryCatchExceptionFromCatchOrFinally](2578-trycatchexceptionfromcatchorfinally.md)|Warning|A Catch or Finally activity that is associated with the TryCatch activity '%1' has thrown an exception.|WFActivities|  
|[3501 - InferredContractDescription](3501-inferredcontractdescription.md)|Information|ContractDescription with Name='%1' and Namespace='%2' has been inferred from WorkflowService.|WFServices|  
|[3502 - InferredOperationDescription](3502-inferredoperationdescription.md)|Information|OperationDescription with Name='%1' in contract '%2' has been inferred from WorkflowService. IsOneWay=%3.|WFServices|  
|[3503 - DuplicateCorrelationQuery](3503-duplicatecorrelationquery.md)|Warning|A duplicate CorrelationQuery was found with Where='%1'. This duplicate query will not be used when calculating correlation.|WFServices|  
|[3507 - ServiceEndpointAdded](3507-serviceendpointadded.md)|Information|A service endpoint has been added for address '%1', binding '%2', and contract '%3'.|WFServices|  
|[3508 - TrackingProfileNotFound](3508-trackingprofilenotfound.md)|Verbose|TrackingProfile '%1' for the ActivityDefinitionId '%2' not found. Either the TrackingProfile is not found in the config file or the ActivityDefinitionId does not match.|WFServices|  
|[3550 - BufferOutOfOrderMessageNoInstance](3550-bufferoutofordermessagenoinstance.md)|Information|Operation '%1' cannot be performed at this time. Another attempt will be made when the service instance is ready to process this particular operation.|WFServices|  
|[3551 - BufferOutOfOrderMessageNoBookmark](3551-bufferoutofordermessagenobookmark.md)|Information|Operation '%2' on service instance '%1' cannot be performed at this time. Another attempt will be made when the service instance is ready to process this particular operation.|WFServices|  
|[3552 - MaxPendingMessagesPerChannelExceeded](3552-maxpendingmessagesperchannelexceeded.md)|Warning|The throttle 'MaxPendingMessagesPerChannel' limit of  '%1' was hit. To increase this limit, adjust the MaxPendingMessagesPerChannel property on BufferedReceiveServiceBehavior.|Quota WFServices|  
|[3557 - TransactedReceiveScopeEndCommitFailed](3557-transactedreceivescopeendcommitfailed.md)|Information|The call to EndCommit on the CommittableTransaction with id = '%1' threw a TransactionException with the following message: '%2'.|WFServices|  
|[4201 - EndSqlCommandExecute](4201-endsqlcommandexecute.md)|Verbose|End SQL command execution: %1|WFInstanceStore|  
|[4202 - StartSqlCommandExecute](4202-startsqlcommandexecute.md)|Verbose|Starting SQL command execution: %1|WFInstanceStore|  
|[4203 - RenewLockSystemError](4203-renewlocksystemerror.md)|Error|Failed to extend lock expiration, lock expiration already passed or the lock owner was deleted. Aborting SqlWorkflowInstanceStore.|WFInstanceStore|  
|[4205 - FoundProcessingError](4205-foundprocessingerror.md)|Error|Command failed: %1|WFInstanceStore|  
|[4206 - UnlockInstanceException](4206-unlockinstanceexception.md)|Error|Encountered exception %1 while attempting to unlock instance.|WFInstanceStore|  
|[4207 - MaximumRetriesExceededForSqlCommand](4207-maximumretriesexceededforsqlcommand.md)|Information|Giving up retrying a SQL command as the maximum number of retries have been performed.|Quota WFInstanceStore|  
|[4208 - RetryingSqlCommandDueToSqlError](4208-retryingsqlcommandduetosqlerror.md)|Information|Retrying a SQL command due to SQL error number %1.|WFInstanceStore|  
|[4209 - TimeoutOpeningSqlConnection](4209-timeoutopeningsqlconnection.md)|Error|Timeout trying to open a SQL connection. The operation did not complete within the allotted timeout of %1. The time allotted to this operation may have been a portion of a longer timeout.|WFInstanceStore|  
|[4210 - SqlExceptionCaught](4210-sqlexceptioncaught.md)|Warning|Caught SQL Exception number %1 message %2.|WFInstanceStore|  
|[4211 - QueuingSqlRetry](4211-queuingsqlretry.md)|Warning|Queuing SQL retry with delay %1 milliseconds.|WFInstanceStore|  
|[4212 - LockRetryTimeout](4212-lockretrytimeout.md)|Warning|Timeout trying to acquire the instance lock.  The operation did not complete within the allotted timeout of %1. The time allotted to this operation may have been a portion of a longer timeout.|WFInstanceStore|  
|[4213 - RunnableInstancesDetectionError](4213-runnableinstancesdetectionerror.md)|Error|Detection of runnable instances failed due to the following exception|WFInstanceStore|  
|[4214 - InstanceLocksRecoveryError](4214-instancelocksrecoveryerror.md)|Error|Recovering instance locks failed due to the following exception|WFInstanceStore|  
|[39456 - TrackingRecordDropped](39456-trackingrecorddropped.md)|Warning|Size of tracking record %1 exceeds maximum allowed by the ETW session for provider %2|WFTracking|  
|[39457 - TrackingRecordRaised](39457-trackingrecordraised.md)|Information|Tracking Record %1 raised to %2.|WFRuntime|  
|[39458 - TrackingRecordTruncated](39458-trackingrecordtruncated.md)|Warning|Truncated tracking record %1 written to ETW session with provider %2. Variables/annotations/user data have been removed|WFTracking|  
|[39459 - TrackingDataExtracted](39459-trackingdataextracted.md)|Verbose|Tracking data %1 extracted in activity %2.|WFRuntime|  
|[39460 - TrackingValueNotSerializable](39460-trackingvaluenotserializable.md)|Warning|The extracted argument/variable '%1' is not serializable.|WFTracking|  
|[57398 - MaxInstancesExceeded](57398-maxinstancesexceeded.md)|Warning|The system hit the limit set for throttle 'MaxConcurrentInstances'. Limit for this throttle was set to %1. Throttle value can be changed by modifying attribute 'maxConcurrentInstances' in serviceThrottle element or by modifying 'MaxConcurrentInstances' property on behavior ServiceThrottlingBehavior.|WFServices|
