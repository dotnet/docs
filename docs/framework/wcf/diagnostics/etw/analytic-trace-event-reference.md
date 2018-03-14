---
title: "Analytic Trace Event Reference"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "analytic tracing [WCF]. reference"
ms.assetid: e44540cf-44a1-4efc-b965-7fbfd2131d73
caps.latest.revision: 50
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Analytic Trace Event Reference
The following table defines the event levels, identifiers, and messages associated with the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] Analytic Tracing.  
  
## Event Reference  
  
|Event ID|Event Level|Event Message|Keywords|  
|--------------|-----------------|-------------------|--------------|  
|[131 - BufferPoolAllocation](../../../../../docs/framework/wcf/diagnostics/etw/131-bufferpoolallocation.md)|Verbose|Pool allocating %1 Bytes.|Infrastructure|  
|[132 - BufferPoolChangeQuota](../../../../../docs/framework/wcf/diagnostics/etw/132-bufferpoolchangequota.md)|Verbose|BufferPool of size %1, changing quota by %2.|Infrastructure|  
|[133 - ActionItemScheduled](../../../../../docs/framework/wcf/diagnostics/etw/133-actionitemscheduled.md)|Verbose|IO Thread scheduler callback invoked.|Infrastructure|  
|[134 - ActionItemCallbackInvoked](../../../../../docs/framework/wcf/diagnostics/etw/134-actionitemcallbackinvoked.md)|Verbose|IO Thread scheduler callback invoked.|Infrastructure|  
|[201 - ClientMessageInspectorAfterReceiveInvoked](../../../../../docs/framework/wcf/diagnostics/etw/201-clientmessageinspectorafterreceiveinvoked.md)|Information|The Dispatcher invoked 'AfterReceiveReply' on a ClientMessageInspector of type '%1'.|Troubleshooting, ServiceModel|  
|[202 - ClientMessageInspectorBeforeSendInvoked](../../../../../docs/framework/wcf/diagnostics/etw/202-clientmessageinspectorbeforesendinvoked.md)|Information|The Dispatcher invoked 'BeforeSendRequest' on a ClientMessageInspector of type  '%1'.|Troubleshooting, ServiceModel|  
|[203 - ClientParameterInspectorAfterCallInvoked](../../../../../docs/framework/wcf/diagnostics/etw/203-clientparameterinspectoraftercallinvoked.md)|Information|The Dispatcher invoked 'AfterCall' on a ClientParameterInspector. of type '%1'.|Troubleshooting, ServiceModel|  
|[204 - ClientParameterInspectorBeforeCallInvoked](../../../../../docs/framework/wcf/diagnostics/etw/204-clientparameterinspectorbeforecallinvoked.md)|Information|The Dispatcher invoked 'BeforeCall' on a ClientParameterInspector of type '%1'.|Troubleshooting, ServiceModel|  
|[205 - OperationInvoked](../../../../../docs/framework/wcf/diagnostics/etw/205-operationinvoked.md)|Information|An OperationInvoker invoked the '%1' method.|EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[206 - ErrorHandlerInvoked](../../../../../docs/framework/wcf/diagnostics/etw/206-errorhandlerinvoked.md)|Information|The Dispatcher invoked an ErrorHandler of type  '%1' with an exception of type '%3'.  ErrorHandled == '%2'.|Troubleshooting, ServiceModel|  
|[207 - FaultProviderInvoked](../../../../../docs/framework/wcf/diagnostics/etw/207-faultproviderinvoked.md)|Information|The Dispatcher invoked a FaultProvider of type '%1' with an exception of type '%2'.|Troubleshooting, ServiceModel|  
|[208 - MessageInspectorAfterReceiveInvoked](../../../../../docs/framework/wcf/diagnostics/etw/208-messageinspectorafterreceiveinvoked.md)|Information|The Dispatcher invoked 'AfterReceiveReply' on a MessageInspector of type '%1'.|Troubleshooting, ServiceModel|  
|[209 - MessageInspectorBeforeSendInvoked](../../../../../docs/framework/wcf/diagnostics/etw/209-messageinspectorbeforesendinvoked.md)|Information|The Dispatcher invoked 'BeforeSendRequest' on a MessageInspector of type '%1'.|Troubleshooting, ServiceModel|  
|[210 - MessageThrottleExceeded](../../../../../docs/framework/wcf/diagnostics/etw/210-messagethrottleexceeded.md)|Warning|The '%1' throttle limit of '%2' was hit.|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[211 - ParameterInspectorAfterCallInvoked](../../../../../docs/framework/wcf/diagnostics/etw/211-parameterinspectoraftercallinvoked.md)|Information|The Dispatcher invoked 'AfterCall' on a ParameterInspector of type '%1'.|Troubleshooting, ServiceModel|  
|[212 - ParameterInspectorBeforeCallInvoked](../../../../../docs/framework/wcf/diagnostics/etw/212-parameterinspectorbeforecallinvoked.md)|Information|The Dispatcher invoked 'BeforeCall' on a ParameterInspector of type '%1'.|Troubleshooting, ServiceModel|  
|[213 - ServiceHostStarted](../../../../../docs/framework/wcf/diagnostics/etw/213-servicehoststarted.md)|LogAlways|ServiceHost started: '%1'.|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[214 - OperationCompleted](../../../../../docs/framework/wcf/diagnostics/etw/214-operationcompleted.md)|Information|An OperationInvoker completed the call to the '%1' method.  The method call duration was '%2' ms.|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[215 - MessageReceivedByTransport](../../../../../docs/framework/wcf/diagnostics/etw/215-messagereceivedbytransport.md)|Information|The transport received a message from '%1'.|Troubleshooting, ServiceModel|  
|[216 - MessageSentByTransport](../../../../../docs/framework/wcf/diagnostics/etw/216-messagesentbytransport.md)|Information|The transport sent a message to '%1'.|Troubleshooting, ServiceModel|  
|[217 - ClientOperationPrepared](../../../../../docs/framework/wcf/diagnostics/etw/217-clientoperationprepared.md)|Information|The Client is executing the '%1' operation defined in the '%2' contract. The message will be sent to '%3'.|Troubleshooting, ServiceModel|  
|[218 - ClientOperationCompleted](../../../../../docs/framework/wcf/diagnostics/etw/218-clientoperationcompleted.md)|Information|The Client completed executing the '%1' operation defined in the '%2' contract. The message was sent to '%3'.|Troubleshooting, ServiceModel|  
|[219 - ServiceException](../../../../../docs/framework/wcf/diagnostics/etw/219-serviceexception.md)|Error|There was an unhandled exception of type '%2' during message processing.  Full Exception ToString: %1.|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[220 - MessageSentToTransport](../../../../../docs/framework/wcf/diagnostics/etw/220-messagesenttotransport.md)|Information|The Dispatcher sent a message to the transport. Correlation ID == '%1'.|EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[221 - MessageReceivedFromTransport](../../../../../docs/framework/wcf/diagnostics/etw/221-messagereceivedfromtransport.md)|Information|The Dispatcher received a message from the transport. Correlation ID == '%1'.|EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[222 - OperationFailed](../../../../../docs/framework/wcf/diagnostics/etw/222-operationfailed.md)|Warning|The '%1' method threw an unhandled exception when invoked by the OperationInvoker. The method call duration was '%2' ms.|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[223 - OperationFaulted](../../../../../docs/framework/wcf/diagnostics/etw/223-operationfaulted.md)|Warning|The '%1' method threw a FaultException when invoked by the OperationInvoker. The method call duration was '%2' ms.|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[224 - MessageThrottleAtSeventyPercent](../../../../../docs/framework/wcf/diagnostics/etw/224-messagethrottleatseventypercent.md)|Warning|The '%1' throttle limit of '%2' is at 70%.|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[226 - IdleServicesClosed](../../../../../docs/framework/wcf/diagnostics/etw/226-idleservicesclosed.md)|LogAlways|%1 idle services out of total %2 activated services closed.|HealthMonitoring WebHost|  
|[301 - UserDefinedErrorOccurred](../../../../../docs/framework/wcf/diagnostics/etw/301-userdefinederroroccurred.md)|Error|Name: '%1', Reference: '%2', Payload:  %3.|UserEvents, HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[302 - UserDefinedWarningOccurred](../../../../../docs/framework/wcf/diagnostics/etw/302-userdefinedwarningoccurred.md)|Warning|Name: '%1', Reference: '%2', Payload: %3.|UserEvents, HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[303 - UserDefinedInformationEventOccured](../../../../../docs/framework/wcf/diagnostics/etw/303-userdefinedinformationeventoccured.md)|Information|Name: '%1', Reference: '%2', Payload: %3.|UserEvents, HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|[401- StopSignPostEvent](../../../../../docs/framework/wcf/diagnostics/etw/401-stopsignpostevent.md)|Information|Activity boundary.|Troubleshooting|  
|[402 - StartSignpostEvent](../../../../../docs/framework/wcf/diagnostics/etw/402-startsignpostevent.md)|Information|Activity boundary.|Troubleshooting|  
|[403 - SuspendSignpostEvent](../../../../../docs/framework/wcf/diagnostics/etw/403-suspendsignpostevent.md)|Information|Activity boundary.|Troubleshooting|  
|[404 - ResumeSignpostEvent](../../../../../docs/framework/wcf/diagnostics/etw/404-resumesignpostevent.md)|Information|Activity boundary.|Troubleshooting|  
|[451 - MessageLogInfo](../../../../../docs/framework/wcf/diagnostics/etw/451-messageloginfo.md)|Information|%1|Troubleshooting, WCFMessageLogging|  
|[452 - MessageLogWarning](../../../../../docs/framework/wcf/diagnostics/etw/452-messagelogwarning.md)|Warning|%1|Troubleshooting, WCFMessageLogging|  
|[499 - TransferEmitted](../../../../../docs/framework/wcf/diagnostics/etw/499-transferemitted.md)|LogAlways|Transfer event emitted.|Troubleshooting, UserEvents, EndToEndMonitoring, ServiceModel, WFTracking, ServiceHost, WCFMessageLogging|  
|[501 - CompilationStart](../../../../../docs/framework/wcf/diagnostics/etw/501-compilationstart.md)|Information|Begin compilation.|WebHost|  
|[502 - CompilationStop](../../../../../docs/framework/wcf/diagnostics/etw/502-compilationstop.md)|Information|End compilation.|WebHost|  
|[503 - ServiceHostFactoryCreationStart](../../../../../docs/framework/wcf/diagnostics/etw/503-servicehostfactorycreationstart.md)|Information|ServiceHostFactory begin creation.|WebHost|  
|[504 - ServiceHostFactoryCreationStop](../../../../../docs/framework/wcf/diagnostics/etw/504-servicehostfactorycreationstop.md)|Information|ServiceHostFactory end creation.|WebHost|  
|[505 - CreateServiceHostStart](../../../../../docs/framework/wcf/diagnostics/etw/505-createservicehoststart.md)|Information|Begin CreateServiceHost.|WebHost|  
|[506 - CreateServiceHostStop](../../../../../docs/framework/wcf/diagnostics/etw/506-createservicehoststop.md)|Information|End CreateServiceHost.|WebHost|  
|[507 - HostedTransportConfigurationManagerConfigInitStart](../../../../../docs/framework/wcf/diagnostics/etw/507-hostedtransportconfigurationmanagerconfiginitstart.md)|Information|HostedTransportConfigurationManager begin configuration initialization.|WebHost|  
|[508 - HostedTransportConfigurationManagerConfigInitStop](../../../../../docs/framework/wcf/diagnostics/etw/508-hostedtransportconfigurationmanagerconfiginitstop.md)|Information|HostedTransportConfigurationManager end configuration initialization.|WebHost|  
|[509 - ServiceHostOpenStart](../../../../../docs/framework/wcf/diagnostics/etw/509-servicehostopenstart.md)|Information|HostedTransportConfigurationManager end configuration initialization.|ServiceHost|  
|[510 - ServiceHostOpenStop](../../../../../docs/framework/wcf/diagnostics/etw/510-servicehostopenstop.md)|Information|ServiceHost Open completed.|ServiceHost|  
|[513 - WebHostRequestStart](../../../../../docs/framework/wcf/diagnostics/etw/513-webhostrequeststart.md)|Information|Received request with virtual path '%2' from the AppDomain '%1'.|WebHost|  
|[514 - WebHostRequestStop](../../../../../docs/framework/wcf/diagnostics/etw/514-webhostrequeststop.md)|Information|WebHostRequest stop.|WebHost|  
|[601 - CBAEntryRead](../../../../../docs/framework/wcf/diagnostics/etw/601-cbaentryread.md)|Verbose|Processed ServiceActivation Element Relative Address:'%1', Normalized Relative Address '%2' .||  
|[602 - CBAMatchFound](../../../../../docs/framework/wcf/diagnostics/etw/602-cbamatchfound.md)|Verbose|Incoming request matches a ServiceActivation element with address '%1'.||  
|[603 - AspNetRoutingService](../../../../../docs/framework/wcf/diagnostics/etw/603-aspnetroutingservice.md)|Verbose|Incoming request matches a WCF Service defined in Asp.Net route with address %1.|RoutingServices|  
|[604 - AspNetRoute](../../../../../docs/framework/wcf/diagnostics/etw/604-aspnetroute.md)|Verbose|A new Asp.Net route '%1' with serviceType '%2' and serviceHostFactoryType '%3' is added.|RoutingServices|  
|[605 - IncrementBusyCount](../../../../../docs/framework/wcf/diagnostics/etw/605-incrementbusycount.md)|Verbose|IncrementBusyCount called. Source : %1|WebHost|  
|[606 - DecrementBusyCount](../../../../../docs/framework/wcf/diagnostics/etw/606-decrementbusycount.md)|Verbose|DecrementBusyCount called. Source : %1|WebHost|  
|[701 - ServiceChannelOpenStart](../../../../../docs/framework/wcf/diagnostics/etw/701-servicechannelopenstart.md)|Verbose|ServiceChannelOpen started.|WebHost|  
|[702 - ServiceChannelOpenStop](../../../../../docs/framework/wcf/diagnostics/etw/702-servicechannelopenstop.md)|Information|ServiceChannelOpen completed.|ServiceModel|  
|[703 - ServiceChannelCallStart](../../../../../docs/framework/wcf/diagnostics/etw/703-servicechannelcallstart.md)|Information|ServiceChannelCall started.|ServiceModel|  
|[704 - ServiceChannelBeginCallStart](../../../../../docs/framework/wcf/diagnostics/etw/704-servicechannelbegincallstart.md)|Information|ServiceChannel asynchronous calls started.|ServiceModel|  
|[706 - HttpSendMessageStart](../../../../../docs/framework/wcf/diagnostics/etw/706-httpsendmessagestart.md)|Verbose|Http Send Request Start.|HTTP|  
|[707 - HttpSendStop](../../../../../docs/framework/wcf/diagnostics/etw/707-httpsendstop.md)|Verbose|Http Send Request Stop.|HTTP|  
|[708 - HttpMessageReceiveStart](../../../../../docs/framework/wcf/diagnostics/etw/708-httpmessagereceivestart.md)|Verbose|Message received from http transport.|HTTP|  
|[709 - DispatchMessageStart](../../../../../docs/framework/wcf/diagnostics/etw/709-dispatchmessagestart.md)|Information|Message dispatching started.|ServiceModel|  
|[710 - HttpContextBeforeProcessAuthentication](../../../../../docs/framework/wcf/diagnostics/etw/710-httpcontextbeforeprocessauthentication.md)|Verbose|Start authentication for message dispatching.|ServiceModel|  
|[711 - DispatchMessageBeforeAuthorization](../../../../../docs/framework/wcf/diagnostics/etw/711-dispatchmessagebeforeauthorization.md)|Verbose|Start authorization for message dispatching.|ServiceModel|  
|[712 - DispatchMessageStop](../../../../../docs/framework/wcf/diagnostics/etw/712-dispatchmessagestop.md)|Information|Message dispatching completed.|ServiceModel|  
|[715 - ClientChannelOpenStart](../../../../../docs/framework/wcf/diagnostics/etw/715-clientchannelopenstart.md)|Information|ServiceChannel Open Start.|ServiceModel|  
|[716 - ClientChannelOpenStop](../../../../../docs/framework/wcf/diagnostics/etw/716-clientchannelopenstop.md)|Information|ServiceChannel Open Stop.|ServiceModel|  
|[717 - HttpSendStreamedMessageStart](../../../../../docs/framework/wcf/diagnostics/etw/717-httpsendstreamedmessagestart.md)|Information|Http Send streamed message started.|HTTP|  
|[1400 - ChannelInitializationTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1400-channelinitializationtimeout.md)|Error|1%|ServiceModel|  
|[1401 - CloseTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1401-closetimeout.md)|Error|1%|ServiceModel|  
|[1402 - IdleTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1402-idletimeout.md)|Error|%1 Connection pool key: %2|ServiceModel|  
|[1403 - LeaseTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1403-leasetimeout.md)|Information|%1 Connection pool key: %2|ServiceModel|  
|[1405 - OpenTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1405-opentimeout.md)|Error|%1|ServiceModel|  
|[1406 - ReceiveTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1406-receivetimeout.md)|Error|%1|ServiceModel|  
|[1407 - SendTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1407-sendtimeout.md)|Error|%1|ServiceModel|  
|[1409 - InactivityTimeout](../../../../../docs/framework/wcf/diagnostics/etw/1409-inactivitytimeout.md)|Information|%1|ServiceModel|  
|[1416 - MaxReceivedMessageSizeExceeded](../../../../../docs/framework/wcf/diagnostics/etw/1416-maxreceivedmessagesizeexceeded.md)|Error|%1|Quota|  
|[1417 - MaxSentMessageSizeExceeded](../../../../../docs/framework/wcf/diagnostics/etw/1417-maxsentmessagesizeexceeded.md)|Error|%1|Quota|  
|[1418 - MaxOutboundConnectionsPerEndpointExceeded](../../../../../docs/framework/wcf/diagnostics/etw/1418-maxoutboundconnectionsperendpointexceeded.md)|Information|%1|Quota|  
|[1419 - MaxPendingConnectionsExceeded](../../../../../docs/framework/wcf/diagnostics/etw/1419-maxpendingconnectionsexceeded.md)|Information|%1|Quota|  
|[1420 - ReaderQuotaExceeded](../../../../../docs/framework/wcf/diagnostics/etw/1420-readerquotaexceeded.md)|Error|%1|Quota|  
|[1422 - NegotiateTokenAuthenticatorStateCacheExceeded](../../../../../docs/framework/wcf/diagnostics/etw/1422-negotiatetokenauthenticatorstatecacheexceeded.md)|Error|%1|Quota|  
|[1423 - NegotiateTokenAuthenticatorStateCacheRatio](../../../../../docs/framework/wcf/diagnostics/etw/1423-negotiatetokenauthenticatorstatecacheratio.md)|Verbose|Negotiate token authenticator state cache ratio: %1/%2|Quota|  
|[1424 - SecuritySessionRatio](../../../../../docs/framework/wcf/diagnostics/etw/1424-securitysessionratio.md)|Verbose|Security session ratio: %1/%2|Quota|  
|[1430 - PendingConnectionsRatio](../../../../../docs/framework/wcf/diagnostics/etw/1430-pendingconnectionsratio.md)|Verbose|Pending connections ratio: %1/%2|Quota|  
|[1431 - ConcurrentCallsRatio](../../../../../docs/framework/wcf/diagnostics/etw/1431-concurrentcallsratio.md)|Verbose|Concurrent sessions ratio: %1/%2|Quota|  
|[1432 - ConcurrentSessionsRatio](../../../../../docs/framework/wcf/diagnostics/etw/1432-concurrentsessionsratio.md)|Verbose|Concurrent sessions ratio: %1/%2|Quota|  
|[1433 - OutboundConnectionsPerEndpointRatio](../../../../../docs/framework/wcf/diagnostics/etw/1433-outboundconnectionsperendpointratio.md)|Verbose|Outbound connections per endpoint ratio: %1/%2|Quota|  
|[1433 - OutboundConnectionsPerEndpointRatio](../../../../../docs/framework/wcf/diagnostics/etw/1433-outboundconnectionsperendpointratio.md)|Verbose|Outbound connections per endpoint ratio: %1/%2|Quota|  
|[1436 - PendingMessagesPerChannelRatio](../../../../../docs/framework/wcf/diagnostics/etw/1436-pendingmessagesperchannelratio.md)|Verbose|Pending messages per channel ratio: %1/%2|Quota|  
|[1438 - ConcurrentInstancesRatio](../../../../../docs/framework/wcf/diagnostics/etw/1438-concurrentinstancesratio.md)|Verbose|Concurrent instances ratio: %1/%2|Quota|  
|[1439 - PendingAcceptsAtZero](../../../../../docs/framework/wcf/diagnostics/etw/1439-pendingacceptsatzero.md)|Information|Zero pending accepts left|Quota|  
|[1441 - MaxSessionSizeReached](../../../../../docs/framework/wcf/diagnostics/etw/1441-maxsessionsizereached.md)|Warning|1%|Quota|  
|[1442 - ReceiveRetryCountReached](../../../../../docs/framework/wcf/diagnostics/etw/1442-receiveretrycountreached.md)|Warning|Receive retry count reached on MSMQ message with id '%1'|Quota|  
|[1443 - MaxRetryCyclesExceededMsmq](../../../../../docs/framework/wcf/diagnostics/etw/1443-maxretrycyclesexceededmsmq.md)|Error|Max retry cycles exceeded on MSMQ message with id '%1'|Quota|  
|[1445 - ReadPoolMiss](../../../../../docs/framework/wcf/diagnostics/etw/1445-readpoolmiss.md)|Verbose|Created new '%1'|Quota|  
|[1446 - WritePoolMiss](../../../../../docs/framework/wcf/diagnostics/etw/1446-writepoolmiss.md)|Verbose|Created new '%1'|Quota|  
|[1451 - MaxRetryCyclesExceeded](../../../../../docs/framework/wcf/diagnostics/etw/1451-maxretrycyclesexceeded.md)|Error|1%|Quota|  
|[3300 - ReceiveContextCompleteFailed](../../../../../docs/framework/wcf/diagnostics/etw/3300-receivecontextcompletefailed.md)|Warning|Failed to Complete %1.|Channel|  
|[3301 - ReceiveContextAbandonFailed](../../../../../docs/framework/wcf/diagnostics/etw/3301-receivecontextabandonfailed.md)|Warning|Failed to Abandon %1.|Channel|  
|[3303 - ReceiveContextAbandonWithException](../../../../../docs/framework/wcf/diagnostics/etw/3303-receivecontextabandonwithexception.md)|Warning|Receive Context faulted.|ServiceModel|  
|[3303 - ReceiveContextAbandonWithException](../../../../../docs/framework/wcf/diagnostics/etw/3303-receivecontextabandonwithexception.md)|Information|%1 was Abandoned with exception %2.|Channel|  
|[3305 - ClientBaseCachedChannelFactoryCount](../../../../../docs/framework/wcf/diagnostics/etw/3305-clientbasecachedchannelfactorycount.md)|Information|Number of cached channel factories is: '%1'.  At most '%2' channel factories can be cached.|ServiceModel|  
|[3306 - ClientBaseChannelFactoryAgedOutofCache](../../../../../docs/framework/wcf/diagnostics/etw/3306-clientbasechannelfactoryagedoutofcache.md)|Information|A channel factory has been aged out of the cache because the cache has reached its limit of '%1'.|ServiceModel|  
|[3307 - ClientBaseChannelFactoryCacheHit](../../../../../docs/framework/wcf/diagnostics/etw/3307-clientbasechannelfactorycachehit.md)|Information|Used matching channel factory found in cache.|ServiceModel|  
|[3308 - ClientBaseUsingLocalChannelFactory](../../../../../docs/framework/wcf/diagnostics/etw/3308-clientbaseusinglocalchannelfactory.md)|Information|Not using channel factory from cache, i.e. caching disabled for instance.|ServiceModel|  
|[3309 - QueryCompositionExecuted](../../../../../docs/framework/wcf/diagnostics/etw/3309-querycompositionexecuted.md)|Information|Query composition using '%1' was executed on the Request Uri: '%2'.|ServiceModel|  
|[3310 - DispatchFailed](../../../../../docs/framework/wcf/diagnostics/etw/3310-dispatchfailed.md)|Error|The '%1' operation was dispatched with errors.|ServiceModel|  
|[3311 - DispatchSuccessful](../../../../../docs/framework/wcf/diagnostics/etw/3311-dispatchsuccessful.md)|Information|The '%1' operation was dispatched successfully.|ServiceModel|  
|[3312 - MessageReadByEncoder](../../../../../docs/framework/wcf/diagnostics/etw/3312-messagereadbyencoder.md)|Information|A message with size '%1' bytes was read by the encoder.|Channel|  
|[3312 - MessageReadByEncoder](../../../../../docs/framework/wcf/diagnostics/etw/3312-messagereadbyencoder.md)|Information|A message with size '%1' bytes was written by the encoder.|Channel|  
|[3314 - SessionIdleTimeout](../../../../../docs/framework/wcf/diagnostics/etw/3314-sessionidletimeout.md)|Error|Session aborting for idle channel to uri:'%1'.|ServiceModel|  
|[3319 - SocketAcceptEnqueued](../../../../../docs/framework/wcf/diagnostics/etw/3319-socketacceptenqueued.md)|Verbose|Connection accept started.|TCP|  
|[3320 - SocketAccepted](../../../../../docs/framework/wcf/diagnostics/etw/3320-socketaccepted.md)|Verbose|ListenerId:%1 accepted SocketId:%2.|TCP|  
|[3321 - ConnectionPoolMiss](../../../../../docs/framework/wcf/diagnostics/etw/3321-connectionpoolmiss.md)|Verbose|Pool for %1 has no available connection and %2 busy connections.|Channel|  
|[3322 - DispatchFormatterDeserializeRequestStart](../../../../../docs/framework/wcf/diagnostics/etw/3322-dispatchformatterdeserializerequeststart.md)|Verbose|Dispatcher started deserialization the request message.|ServiceModel|  
|[3323 - DispatchFormatterDeserializeRequestStop](../../../../../docs/framework/wcf/diagnostics/etw/3323-dispatchformatterdeserializerequeststop.md)|Verbose|Dispatcher completed deserialization the request message.|ServiceModel|  
|[3324 - DispatchFormatterSerializeReplyStart](../../../../../docs/framework/wcf/diagnostics/etw/3324-dispatchformatterserializereplystart.md)|Verbose|Dispatcher started serialization of the reply message.|ServiceModel|  
|[3325 - DispatchFormatterSerializeReplyStop](../../../../../docs/framework/wcf/diagnostics/etw/3325-dispatchformatterserializereplystop.md)|Verbose|Dispatcher completed serialization of the reply message.|ServiceModel|  
|[3326 - ClientFormatterSerializeRequestStart](../../../../../docs/framework/wcf/diagnostics/etw/3326-clientformatterserializerequeststart.md)|Verbose|Client request serialization started.|ServiceModel|  
|[3327 - ClientFormatterSerializeRequestStop](../../../../../docs/framework/wcf/diagnostics/etw/3327-clientformatterserializerequeststop.md)|Verbose|Client completed serialization of the request message.|ServiceModel|  
|[3328 - ClientFormatterDeserializeReplyStart](../../../../../docs/framework/wcf/diagnostics/etw/3328-clientformatterdeserializereplystart.md)|Verbose|Client started deserializing the reply message.|ServiceModel|  
|[3329 - ClientFormatterDeserializeReplyStop](../../../../../docs/framework/wcf/diagnostics/etw/3329-clientformatterdeserializereplystop.md)|Verbose|Client completed deserializing the reply message.|ServiceModel|  
|[3330 - SecurityNegotiationStart](../../../../../docs/framework/wcf/diagnostics/etw/3330-securitynegotiationstart.md)|Verbose|Security negotiation started.|Security|  
|[3331 - SecurityNegotiationStop](../../../../../docs/framework/wcf/diagnostics/etw/3331-securitynegotiationstop.md)|Verbose|Security negotiation completed.|Security|  
|[3332 - SecurityTokenProviderOpened](../../../../../docs/framework/wcf/diagnostics/etw/3332-securitytokenprovideropened.md)|Verbose|SecurityTokenProvider opening completed.|Security|  
|[3333 - OutgoingMessageSecured](../../../../../docs/framework/wcf/diagnostics/etw/3333-outgoingmessagesecured.md)|Verbose|Outgoing message has been secured.|Security|  
|[3334 - IncomingMessageVerified](../../../../../docs/framework/wcf/diagnostics/etw/3334-incomingmessageverified.md)|Verbose|Incoming message has been verified.|Security ServiceModel|  
|[3335 - GetServiceInstanceStart](../../../../../docs/framework/wcf/diagnostics/etw/3335-getserviceinstancestart.md)|Verbose|Service instance retrieval started.|ServiceModel|  
|[3336 - GetServiceInstanceStop](../../../../../docs/framework/wcf/diagnostics/etw/3336-getserviceinstancestop.md)|Verbose|Service instance retrieved.|ServiceModel|  
|[3337 - ChannelReceiveStart](../../../../../docs/framework/wcf/diagnostics/etw/3337-channelreceivestart.md)|Verbose|ChannelHandlerId:%1 - Message receive loop started.|Channel|  
|[3338 - ChannelReceiveStop](../../../../../docs/framework/wcf/diagnostics/etw/3338-channelreceivestop.md)|Verbose|ChannelHandlerId:%1 - Message receive loop stopped.|Channel|  
|[3339 - ChannelFactoryCreated](../../../../../docs/framework/wcf/diagnostics/etw/3339-channelfactorycreated.md)|Verbose|ChannelFactory created.|ServiceModel|  
|[3340 - PipeConnectionAcceptStart](../../../../../docs/framework/wcf/diagnostics/etw/3340-pipeconnectionacceptstart.md)|Verbose|Pipe connection accept started on %1.|Channel|  
|[3341 - PipeConnectionAcceptStop](../../../../../docs/framework/wcf/diagnostics/etw/3341-pipeconnectionacceptstop.md)|Verbose|Pipe connection accepted.|Channel|  
|[3342 - EstablishConnectionStart](../../../../../docs/framework/wcf/diagnostics/etw/3342-establishconnectionstart.md)|Verbose|Connection establishment started for %1.|Channel|  
|[3343 - EstablishConnectionStop](../../../../../docs/framework/wcf/diagnostics/etw/3343-establishconnectionstop.md)|Verbose|Connection established.|Channel|  
|[3345 - SessionPreambleUnderstood](../../../../../docs/framework/wcf/diagnostics/etw/3345-sessionpreambleunderstood.md)|Verbose|Session preamble for '%1' understood.|Channel|  
|[3346 - ConnectionReaderSendFault](../../../../../docs/framework/wcf/diagnostics/etw/3346-connectionreadersendfault.md)|Error|Connection reader sending fault '%1'.|Channel|  
|[3347 - SocketAcceptClosed](../../../../../docs/framework/wcf/diagnostics/etw/3347-socketacceptclosed.md)|Verbose|Socket accept closed.|TCP|  
|[3348 - ServiceHostFaulted](../../../../../docs/framework/wcf/diagnostics/etw/3348-servicehostfaulted.md)|Critical|Service host faulted.|TCP|  
|[3349 - ListenerOpenStart](../../../../../docs/framework/wcf/diagnostics/etw/3349-listeneropenstart.md)|Verbose|Listener opening for '%1'.|Channel|  
|[3350 - ListenerOpenStop](../../../../../docs/framework/wcf/diagnostics/etw/3350-listeneropenstop.md)|Verbose|Listener open completed.|Channel|  
|[3351 - ServerMaxPooledConnectionsQuotaReached](../../../../../docs/framework/wcf/diagnostics/etw/3351-servermaxpooledconnectionsquotareached.md)|Verbose|Server max pooled connections quota reached.|Quota|  
|[3352 - TcpConnectionTimedOut](../../../../../docs/framework/wcf/diagnostics/etw/3352-tcpconnectiontimedout.md)|Error|SocketId:%1 to remote address %2 timed out.|TCP|  
|[3353 - TcpConnectionResetError](../../../../../docs/framework/wcf/diagnostics/etw/3353-tcpconnectionreseterror.md)|Warning|SocketId:%1 to remote address %2 had a connection reset error.|TCP|  
|[3354 - ServiceSecurityNegotiationCompleted](../../../../../docs/framework/wcf/diagnostics/etw/3354-servicesecuritynegotiationcompleted.md)|Verbose|Service security negotiation completed.|Security|  
|[3355 - SecurityNegotiationProcessingFailure](../../../../../docs/framework/wcf/diagnostics/etw/3355-securitynegotiationprocessingfailure.md)|Error|Security negotiation processing failed.|Security|  
|[3356 - SecurityIdentityVerificationSuccess](../../../../../docs/framework/wcf/diagnostics/etw/3356-securityidentityverificationsuccess.md)|Verbose|Security verification succeeded.|Security|  
|[3357 - SecurityIdentityVerificationFailure](../../../../../docs/framework/wcf/diagnostics/etw/3357-securityidentityverificationfailure.md)|Error|Security verification failed.|Security|  
|[3358 - PortSharingDuplicatedSocket](../../../../../docs/framework/wcf/diagnostics/etw/3358-portsharingduplicatedsocket.md)|Verbose|Socket duplicated for %1.|ActivationServices|  
|[3359 - SecurityImpersonationSuccess](../../../../../docs/framework/wcf/diagnostics/etw/3359-securityimpersonationsuccess.md)|Verbose|Security impersonation succeeded.|Security|  
|[3360 - SecurityImpersonationFailure](../../../../../docs/framework/wcf/diagnostics/etw/3360-securityimpersonationfailure.md)|Warning|Security impersonation failed.|Security|  
|[3361 - HttpChannelRequestAborted](../../../../../docs/framework/wcf/diagnostics/etw/3361-httpchannelrequestaborted.md)|Warning|Http channel request aborted.|HTTP|  
|[3362 - HttpChannelResponseAborted](../../../../../docs/framework/wcf/diagnostics/etw/3362-httpchannelresponseaborted.md)|Warning|Http channel response aborted.|HTTP|  
|[3363 - HttpAuthFailed](../../../../../docs/framework/wcf/diagnostics/etw/3363-httpauthfailed.md)|Warning|Http authentication failed.|HTTP|  
|[3364 - SharedListenerProxyRegisterStart](../../../../../docs/framework/wcf/diagnostics/etw/3364-sharedlistenerproxyregisterstart.md)|Verbose|SharedListenerProxy registration started for uri '%1'.|ActivationServices|  
|[3365 - SharedListenerProxyRegisterStop](../../../../../docs/framework/wcf/diagnostics/etw/3365-sharedlistenerproxyregisterstop.md)|Verbose|SharedListenerProxy Register Stop.|ActivationServices|  
|[3366 - SharedListenerProxyRegisterFailed](../../../../../docs/framework/wcf/diagnostics/etw/3366-sharedlistenerproxyregisterfailed.md)|Error|SharedListenerProxy register failed with status '%1'.|ActivationServices|  
|[3367 - ConnectionPoolPreambleFailed](../../../../../docs/framework/wcf/diagnostics/etw/3367-connectionpoolpreamblefailed.md)|Error|ConnectionPoolPreambleFailed.|Channel|  
|[3368 - SslOnInitiateUpgrade](../../../../../docs/framework/wcf/diagnostics/etw/3368-ssloninitiateupgrade.md)|Verbose|SslOnAcceptUpgradeStart|Security|  
|[3369 - SslOnAcceptUpgrade](../../../../../docs/framework/wcf/diagnostics/etw/3369-sslonacceptupgrade.md)|Verbose|SslOnAcceptUpgradeStop|Security|  
|[3370 - BinaryMessageEncodingStart](../../../../../docs/framework/wcf/diagnostics/etw/3370-binarymessageencodingstart.md)|Verbose|BinaryMessageEncoder started encoding the message.|Channel|  
|[3371 - MtomMessageEncodingStart](../../../../../docs/framework/wcf/diagnostics/etw/3371-mtommessageencodingstart.md)|Verbose|MtomMessageEncoder started encoding the message.|Channel|  
|[3372 - TextMessageEncodingStart](../../../../../docs/framework/wcf/diagnostics/etw/3372-textmessageencodingstart.md)|Verbose|TextMessageEncoder started encoding the message.|Channel|  
|[3373 - BinaryMessageDecodingStart](../../../../../docs/framework/wcf/diagnostics/etw/3373-binarymessagedecodingstart.md)|Verbose|BinaryMessageEncoder started decoding the message.|Channel|  
|[3374 - MtomMessageDecodingStart](../../../../../docs/framework/wcf/diagnostics/etw/3374-mtommessagedecodingstart.md)|Verbose|MtomMessageEncoder started decoding  the message.|Channel|  
|[3375 - TextMessageDecodingStart](../../../../../docs/framework/wcf/diagnostics/etw/3375-textmessagedecodingstart.md)|Verbose|TextMessageEncoder started decoding the message.|Channel|  
|[3376 - HttpResponseReceiveStart](../../../../../docs/framework/wcf/diagnostics/etw/3376-httpresponsereceivestart.md)|Information|Http transport started receiving a message.|HTTP|  
|[3377 - SocketReadStop](../../../../../docs/framework/wcf/diagnostics/etw/3377-socketreadstop.md)|Verbose|SocketId:%1 read '%2' bytes read from '%3'.|TCP|  
|[3378 - SocketAsyncReadStop](../../../../../docs/framework/wcf/diagnostics/etw/3378-socketasyncreadstop.md)|Verbose|SocketId:%1 read '%2' bytes read from '%3'.|TCP|  
|[3379 - SocketWriteStart](../../../../../docs/framework/wcf/diagnostics/etw/3379-socketwritestart.md)|Verbose|SocketId:%1 writing '%2' bytes to '%3'.|TCP|  
|[3380 - SocketAsyncWriteStart](../../../../../docs/framework/wcf/diagnostics/etw/3380-socketasyncwritestart.md)|Verbose|SocketId:%1 writing '%2' bytes to '%3'.|TCP|  
|[3381 - SequenceAcknowledgementSent](../../../../../docs/framework/wcf/diagnostics/etw/3381-sequenceacknowledgementsent.md)|Verbose|SessionId:%1 acknowledgement sent.|Channel|  
|[3382 - ClientReliableSessionReconnect](../../../../../docs/framework/wcf/diagnostics/etw/3382-clientreliablesessionreconnect.md)|Information|SessionId:%1 reconnecting.|Channel|  
|[3383 - ReliableSessionChannelFaulted](../../../../../docs/framework/wcf/diagnostics/etw/3383-reliablesessionchannelfaulted.md)|Information|SessionId:%1 faulted.|Channel|  
|[3384 - WindowsStreamSecurityOnInitiateUpgrade](../../../../../docs/framework/wcf/diagnostics/etw/3384-windowsstreamsecurityoninitiateupgrade.md)|Verbose|WindowsStreamSecurity initiating security upgrade.|Security|  
|[3385 - WindowsStreamSecurityOnAcceptUpgrade](../../../../../docs/framework/wcf/diagnostics/etw/3385-windowsstreamsecurityonacceptupgrade.md)|Verbose|Windows streaming security on accepting upgrade.|Security|  
|[3386 - SocketConnectionAbort](../../../../../docs/framework/wcf/diagnostics/etw/3386-socketconnectionabort.md)|Warning|SocketId:%1 is aborting.|TCP|  
|[3388 - HttpGetContextStart](../../../../../docs/framework/wcf/diagnostics/etw/3388-httpgetcontextstart.md)|Verbose|HttpGetContext start.|HTTP|  
|[3389 - ClientSendPreambleStart](../../../../../docs/framework/wcf/diagnostics/etw/3389-clientsendpreamblestart.md)|Verbose|Client sending preamble start.|Channel|  
|[3390 - ClientSendPreambleStop](../../../../../docs/framework/wcf/diagnostics/etw/3390-clientsendpreamblestop.md)|Verbose|Client sending preamble stop.|Channel|  
|[3391 - HttpMessageReceiveFailed](../../../../../docs/framework/wcf/diagnostics/etw/3391-httpmessagereceivefailed.md)|Warning|Http Message receive failed.|HTTP|  
|[3392 - TransactionScopeCreate](../../../../../docs/framework/wcf/diagnostics/etw/3392-transactionscopecreate.md)|Information|TransactionScope is being created with LocalIdentifier:'%1' and DistributedIdentifier:'%2'.|ServiceModel|  
|[3393 - StreamedMessageReadByEncoder](../../../../../docs/framework/wcf/diagnostics/etw/3393-streamedmessagereadbyencoder.md)|Information|A streamed message was read by the encoder.|Channel|  
|[3394 - StreamedMessageWrittenByEncoder](../../../../../docs/framework/wcf/diagnostics/etw/3394-streamedmessagewrittenbyencoder.md)|Information|A streamed message was written by the encoder.|Channel|  
|[3395 - MessageWrittenAsynchronouslyByEncoder](../../../../../docs/framework/wcf/diagnostics/etw/3395-messagewrittenasynchronouslybyencoder.md)|Information|A message was written asynchronously by the encoder.|Channel|  
|[3396 - BufferedAsyncWriteStart](../../../../../docs/framework/wcf/diagnostics/etw/3396-bufferedasyncwritestart.md)|Information|BufferId:%1 completed writing '%2' bytes to underlying stream.|Channel|  
|[3397 - BufferedAsyncWriteStop](../../../../../docs/framework/wcf/diagnostics/etw/3397-bufferedasyncwritestop.md)|Information|A message was written asynchronously by the encoder.|Channel|  
|[3398 - PipeSharedMemoryCreated](../../../../../docs/framework/wcf/diagnostics/etw/3398-pipesharedmemorycreated.md)|Verbose|Pipe shared memory created at '%1' .|Channel|  
|[3399 - NamedPipeCreated](../../../../../docs/framework/wcf/diagnostics/etw/3399-namedpipecreated.md)|Verbose|NamedPipe '%1' created.|Channel|  
|[3401 - SignatureVerificationStart](../../../../../docs/framework/wcf/diagnostics/etw/3401-signatureverificationstart.md)|Verbose|Signature verification started.|Security|  
|[3402 - SignatureVerificationSuccess](../../../../../docs/framework/wcf/diagnostics/etw/3402-signatureverificationsuccess.md)|Verbose|Signature verification succeeded.|Security|  
|[3403 - WrappedKeyDecryptionStart](../../../../../docs/framework/wcf/diagnostics/etw/3403-wrappedkeydecryptionstart.md)|Verbose|Wrapped key decryption started.|Security|  
|[3404 - WrappedKeyDecryptionSuccess](../../../../../docs/framework/wcf/diagnostics/etw/3404-wrappedkeydecryptionsuccess.md)|Verbose|Wrapped key decryption succeeded.|Security|  
|[3405 - EncryptedDataProcessingStart](../../../../../docs/framework/wcf/diagnostics/etw/3405-encrypteddataprocessingstart.md)|Verbose|Encrypted data processing started.|Security|  
|[3406 - EncryptedDataProcessingSuccess](../../../../../docs/framework/wcf/diagnostics/etw/3406-encrypteddataprocessingsuccess.md)|Verbose|Encrypted data processing succeeded.|Security|  
|[3407 - HttpPipelineProcessInboundRequestStart](../../../../../docs/framework/wcf/diagnostics/etw/3407-httppipelineprocessinboundrequeststart.md)|Verbose|Http message handler started processing the inbound request.|HTTP|  
|[3408 - HttpPipelineBeginProcessInboundRequestStart](../../../../../docs/framework/wcf/diagnostics/etw/3408-httppipelinebeginprocessinboundrequeststart.md)|Verbose|Http message handler started processing the inbound request asynchronously.|HTTP|  
|[3409 - HttpPipelineProcessInboundRequestStop](../../../../../docs/framework/wcf/diagnostics/etw/3409-httppipelineprocessinboundrequeststop.md)|Verbose|Http message handler completed processing an inbound request.|HTTP|  
|[3410 - HttpPipelineFaulted](../../../../../docs/framework/wcf/diagnostics/etw/3410-httppipelinefaulted.md)|Warning|Http message handler is faulted.|HTTP|  
|[3411 - HttpPipelineTimeoutException](../../../../../docs/framework/wcf/diagnostics/etw/3411-httppipelinetimeoutexception.md)|Error|WebSocket connection timed out.|HTTP|  
|[3412 - HttpPipelineProcessResponseStart](../../../../../docs/framework/wcf/diagnostics/etw/3412-httppipelineprocessresponsestart.md)|Verbose|Http message handler started processing the response.|HTTP|  
|[3413 - HttpPipelineBeginProcessResponseStart](../../../../../docs/framework/wcf/diagnostics/etw/3413-httppipelinebeginprocessresponsestart.md)|Verbose|Http message handler started processing the response asynchronously.|HTTP|  
|[3414 - HttpPipelineProcessResponseStop](../../../../../docs/framework/wcf/diagnostics/etw/3414-httppipelineprocessresponsestop.md)|Verbose|Http message handler completed processing the response.|HTTP|  
|[3415 - WebSocketConnectionRequestSendStart](../../../../../docs/framework/wcf/diagnostics/etw/3415-websocketconnectionrequestsendstart.md)|Verbose|WebSocket connection request to '%1' send start.|HTTP|  
|[3416 - WebSocketConnectionRequestSendStop](../../../../../docs/framework/wcf/diagnostics/etw/3416-websocketconnectionrequestsendstop.md)|Verbose|WebSocketId:%1 connection request sent.|HTTP|  
|[3417 - WebSocketConnectionAcceptStart](../../../../../docs/framework/wcf/diagnostics/etw/3417-websocketconnectionacceptstart.md)|Verbose|WebSocket connection accept start.|HTTP|  
|[3418 - WebSocketConnectionAccepted](../../../../../docs/framework/wcf/diagnostics/etw/3418-websocketconnectionaccepted.md)|Verbose|WebSocketId:%1 connection accepted.|HTTP|  
|[3419 - WebSocketConnectionDeclined](../../../../../docs/framework/wcf/diagnostics/etw/3419-websocketconnectiondeclined.md)|Error|WebSocket connection declined with status code '%1'|HTTP|  
|[3420 - WebSocketConnectionFailed](../../../../../docs/framework/wcf/diagnostics/etw/3420-websocketconnectionfailed.md)|Error|WebSocket connection request failed: '%1'|HTTP|  
|[3421 - WebSocketConnectionAborted](../../../../../docs/framework/wcf/diagnostics/etw/3421-websocketconnectionaborted.md)|Error|WebSocketId:%1 connection is aborted.|HTTP|  
|[3422 - WebSocketAsyncWriteStart](../../../../../docs/framework/wcf/diagnostics/etw/3422-websocketasyncwritestart.md)|Verbose|WebSocketId:%1 writing '%2' bytes to '%3'.|HTTP|  
|[3423 - WebSocketAsyncWriteStop](../../../../../docs/framework/wcf/diagnostics/etw/3423-websocketasyncwritestop.md)|Verbose|WebSocketId:%1 asynchronous write stop.|HTTP|  
|[3424 - WebSocketAsyncReadStart](../../../../../docs/framework/wcf/diagnostics/etw/3424-websocketasyncreadstart.md)|Verbose|WebSocketId:%1 read start.|HTTP|  
|[3425 - WebSocketAsyncReadStop](../../../../../docs/framework/wcf/diagnostics/etw/3425-websocketasyncreadstop.md)|Verbose|WebSocketId:%1 read '%2' bytes from '%3'.|HTTP|  
|[3426 - WebSocketCloseSent](../../../../../docs/framework/wcf/diagnostics/etw/3426-websocketclosesent.md)|Verbose|WebSocketId:%1 sending close message to '%2' with close status '%3'.|HTTP|  
|[3427 - WebSocketCloseOutputSent](../../../../../docs/framework/wcf/diagnostics/etw/3427-websocketcloseoutputsent.md)|Verbose|WebSocketId:%1 sending close output message to '%2' with close status '%3'.|HTTP|  
|[3428 - WebSocketConnectionClosed](../../../../../docs/framework/wcf/diagnostics/etw/3428-websocketconnectionclosed.md)|Verbose|WebSocketId:%1 connection closed.|HTTP|  
|[3429 - WebSocketCloseStatusReceived](../../../../../docs/framework/wcf/diagnostics/etw/3429-websocketclosestatusreceived.md)|Verbose|WebSocketId:%1 connection close message received with status '%2'.|HTTP|  
|[3430 - WebSocketUseVersionFromClientWebSocketFactory](../../../../../docs/framework/wcf/diagnostics/etw/3430-websocketuseversionfromclientwebsocketfactory.md)|Verbose|Using the WebSocketVersion from a client WebSocket factory of type '%1'.|HTTP|  
|[3431 - WebSocketCreateClientWebSocketWithFactory](../../../../../docs/framework/wcf/diagnostics/etw/3431-websocketcreateclientwebsocketwithfactory.md)|Verbose|Creating the client WebSocket with a factory of type '%1'.|HTTP|  
|[3553 - XamlServicesLoadStart](../../../../../docs/framework/wcf/diagnostics/etw/3553-xamlservicesloadstart.md)|Information|XamlServicesLoad start|WebHost|  
|[3554 - XamlServicesLoadStop](../../../../../docs/framework/wcf/diagnostics/etw/3554-xamlservicesloadstop.md)|Information|XamlServicesLoad Stop|WebHost|  
|[3555 - CreateWorkflowServiceHostStart](../../../../../docs/framework/wcf/diagnostics/etw/3555-createworkflowservicehoststart.md)|Information|CreateWorkflowServiceHost start|WebHost|  
|[3556 - CreateWorkflowServiceHostStop](../../../../../docs/framework/wcf/diagnostics/etw/3556-createworkflowservicehoststop.md)|Information|CreateWorkflowServiceHost Stop|WebHost|  
|[3558 - ServiceActivationStart](../../../../../docs/framework/wcf/diagnostics/etw/3558-serviceactivationstart.md)|Information|Service activation start|WebHost|  
|[3559 - ServiceActivationStop](../../../../../docs/framework/wcf/diagnostics/etw/3559-serviceactivationstop.md)|Information|Service activation Stop|WebHost|  
|[3560 - ServiceActivationAvailableMemory](../../../../../docs/framework/wcf/diagnostics/etw/3560-serviceactivationavailablememory.md)|Verbose|Available memory (bytes): %1|Quota|  
|[3800 - RoutingServiceClosingClient](../../../../../docs/framework/wcf/diagnostics/etw/3800-routingserviceclosingclient.md)|Information|The Routing Service is closing client '%1'.|RoutingServices|  
|[3800 - RoutingServiceClosingClient](../../../../../docs/framework/wcf/diagnostics/etw/3800-routingserviceclosingclient.md)|Warning|Routing Service client '%1' has faulted.|RoutingServices|  
|[3802 - RoutingServiceCompletingOneWay](../../../../../docs/framework/wcf/diagnostics/etw/3802-routingservicecompletingoneway.md)|Information|A Routing Service one way message is completing.|RoutingServices|  
|[3803 - RoutingServiceProcessingFailure](../../../../../docs/framework/wcf/diagnostics/etw/3803-routingserviceprocessingfailure.md)|Error|The Routing Service failed while processing a message on the endpoint with address '%1'.|RoutingServices|  
|[3804 - RoutingServiceCreatingClientForEndpoint](../../../../../docs/framework/wcf/diagnostics/etw/3804-routingservicecreatingclientforendpoint.md)|Information|The Routing Service is creating a client for endpoint: '%1'.|RoutingServices|  
|[3805 - RoutingServiceDisplayConfig](../../../../../docs/framework/wcf/diagnostics/etw/3805-routingservicedisplayconfig.md)|Verbose|The Routing Service is configured with RouteOnHeadersOnly: %1, SoapProcessingEnabled: %2, EnsureOrderedDispatch: %3.|RoutingServices|  
|[3807 - RoutingServiceCompletingTwoWay](../../../../../docs/framework/wcf/diagnostics/etw/3807-routingservicecompletingtwoway.md)|Information|A Routing Service request reply message is completing.|RoutingServices|  
|[3809 - RoutingServiceMessageRoutedToEndpoints](../../../../../docs/framework/wcf/diagnostics/etw/3809-routingservicemessageroutedtoendpoints.md)|Verbose|The Routing Service routed message with ID: '%1' to %2 endpoint lists.|RoutingServices|  
|[3810 - RoutingServiceConfigurationApplied](../../../../../docs/framework/wcf/diagnostics/etw/3810-routingserviceconfigurationapplied.md)|Information|A new RoutingConfiguration has been applied to the Routing Service.|RoutingServices|  
|[3815 - RoutingServiceProcessingMessage](../../../../../docs/framework/wcf/diagnostics/etw/3815-routingserviceprocessingmessage.md)|Information|The Routing Service is processing a message with ID: '%1', Action: '%2', Inbound URL: '%3' Received in Transaction: %4.|RoutingServices|  
|[3816 - RoutingServiceTransmittingMessage](../../../../../docs/framework/wcf/diagnostics/etw/3816-routingservicetransmittingmessage.md)|Information|The Routing Service is transmitting the message with ID: '%1' [operation %2] to '%3'.|RoutingServices|  
|[3817 - RoutingServiceCommittingTransaction](../../../../../docs/framework/wcf/diagnostics/etw/3817-routingservicecommittingtransaction.md)|Information|The Routing Service is committing a transaction with id: '%1'.|RoutingServices|  
|[3818 - RoutingServiceDuplexCallbackException](../../../../../docs/framework/wcf/diagnostics/etw/3818-routingserviceduplexcallbackexception.md)|Error|Routing Service component %1 encountered a duplex callback exception.|RoutingServices|  
|[3819 - RoutingServiceMovedToBackup](../../../../../docs/framework/wcf/diagnostics/etw/3819-routingservicemovedtobackup.md)|Information|Routing Service message with ID: '%1' [operation %2] moved to backup endpoint '%3'.|RoutingServices|  
|[3820 - RoutingServiceCreatingTransaction](../../../../../docs/framework/wcf/diagnostics/etw/3820-routingservicecreatingtransaction.md)|Information|The Routing Service created a new Transaction with id '%1' for processing message(s).|RoutingServices|  
|[3821 - RoutingServiceCloseFailed](../../../../../docs/framework/wcf/diagnostics/etw/3821-routingserviceclosefailed.md)|Warning|The Routing Service failed while closing outbound client '%1'.|RoutingServices|  
|[3822 - RoutingServiceSendingResponse](../../../../../docs/framework/wcf/diagnostics/etw/3822-routingservicesendingresponse.md)|Information|The Routing Service is sending back a response message with Action '%1'.|RoutingServices|  
|[3823 - RoutingServiceSendingFaultResponse](../../../../../docs/framework/wcf/diagnostics/etw/3823-routingservicesendingfaultresponse.md)|Warning|The Routing Service is sending back a Fault response message with Action '%1'.|RoutingServices|  
|[3824 - RoutingServiceCompletingReceiveContext](../../../../../docs/framework/wcf/diagnostics/etw/3824-routingservicecompletingreceivecontext.md)|Verbose|The Routing Service is calling ReceiveContext.Complete for Message with ID: '%1'.|RoutingServices|  
|[3825 - RoutingServiceAbandoningReceiveContext](../../../../../docs/framework/wcf/diagnostics/etw/3825-routingserviceabandoningreceivecontext.md)|Warning|The Routing Service is calling ReceiveContext.Abandon for Message with ID: '%1'.|RoutingServices|  
|[3826 - RoutingServiceUsingExistingTransaction](../../../../../docs/framework/wcf/diagnostics/etw/3826-routingserviceusingexistingtransaction.md)|Verbose|The Routing Service will send messages using existing transaction '%1'.|RoutingServices|  
|[3827 - RoutingServiceTransmitFailed](../../../../../docs/framework/wcf/diagnostics/etw/3827-routingservicetransmitfailed.md)|Warning|The Routing Service failed while sending to '%1'.|RoutingServices|  
|[3828 - RoutingServiceFilterTableMatchStart](../../../../../docs/framework/wcf/diagnostics/etw/3828-routingservicefiltertablematchstart.md)|Information|Routing Service MessageFilterTable Match Start.|RoutingServices|  
|[3829 - RoutingServiceFilterTableMatchStop](../../../../../docs/framework/wcf/diagnostics/etw/3829-routingservicefiltertablematchstop.md)|Information|Routing Service MessageFilterTable Match Stop.|RoutingServices|  
|[3830 - RoutingServiceAbortingChannel](../../../../../docs/framework/wcf/diagnostics/etw/3830-routingserviceabortingchannel.md)|Verbose|The Routing Service is calling abort on channel: '%1'.|RoutingServices|  
|[3831 - RoutingServiceHandledException](../../../../../docs/framework/wcf/diagnostics/etw/3831-routingservicehandledexception.md)|Verbose|The Routing Service has handled an exception.|RoutingServices|  
|[3832 - RoutingServiceTransmitSucceeded](../../../../../docs/framework/wcf/diagnostics/etw/3832-routingservicetransmitsucceeded.md)|Information|The Routing Service successfully transmitted Message with ID: '%1 [operation %2] to '%3'.|RoutingServices|  
|[4001 - TransportListenerSessionsReceived](../../../../../docs/framework/wcf/diagnostics/etw/4001-transportlistenersessionsreceived.md)|Verbose|Transport listener session received with via '%1'|ActivationServices|  
|[4002 - FailFastException](../../../../../docs/framework/wcf/diagnostics/etw/4002-failfastexception.md)|Critical|FailFastException.|ActivationServices|  
|[4003 - ServiceStartPipeError](../../../../../docs/framework/wcf/diagnostics/etw/4003-servicestartpipeerror.md)|Error|Service start pipe error.|ActivationServices|  
|[4008 - DispatchSessionStart](../../../../../docs/framework/wcf/diagnostics/etw/4008-dispatchsessionstart.md)|Verbose|Session dispatch started.|ActivationServices|  
|[4008 - DispatchSessionStart](../../../../../docs/framework/wcf/diagnostics/etw/4008-dispatchsessionstart.md)|Warning|Session dispatch for '%1' failed since pending session queue is full with '%2' pending items.|ActivationServices|  
|[4011 - MessageQueueRegisterStart](../../../../../docs/framework/wcf/diagnostics/etw/4011-messagequeueregisterstart.md)|Verbose|Message queue register start.|ActivationServices|  
|[4012 - MessageQueueRegisterAbort](../../../../../docs/framework/wcf/diagnostics/etw/4012-messagequeueregisterabort.md)|Error|Message queue registration aborted with status:'%1' for uri:'%2'.|ActivationServices|  
|[4013 - MessageQueueUnregisterSucceeded](../../../../../docs/framework/wcf/diagnostics/etw/4013-messagequeueunregistersucceeded.md)|Verbose|Message queue unregister succeeded for uri:'%1'.|ActivationServices|  
|[4014 - MessageQueueRegisterFailed](../../../../../docs/framework/wcf/diagnostics/etw/4014-messagequeueregisterfailed.md)|Error|Message queue registration for uri:'%1' failed with status:'%2'.|ActivationServices|  
|[4015 - MessageQueueRegisterCompleted](../../../../../docs/framework/wcf/diagnostics/etw/4015-messagequeueregistercompleted.md)|Information|Message queue registration completed for uri '%1'.|ActivationServices|  
|[4016 - MessageQueueDuplicatedSocketError](../../../../../docs/framework/wcf/diagnostics/etw/4016-messagequeueduplicatedsocketerror.md)|Error|Message queue failed duplicating socket.|ActivationServices|  
|[4019 - MessageQueueDuplicatedSocketComplete](../../../../../docs/framework/wcf/diagnostics/etw/4019-messagequeueduplicatedsocketcomplete.md)|Verbose|MessageQueueDuplicatedSocketComplete|ActivationServices|  
|[4020 - TcpTransportListenerListeningStart](../../../../../docs/framework/wcf/diagnostics/etw/4020-tcptransportlistenerlisteningstart.md)|Verbose|Tcp transport listener starting to listen on uri:'%1'.|ActivationServices|  
|[4021 - TcpTransportListenerListeningStop](../../../../../docs/framework/wcf/diagnostics/etw/4021-tcptransportlistenerlisteningstop.md)|Verbose|Tcp transport listener listening.|ActivationServices|  
|[4022 - WebhostUnregisterProtocolFailed](../../../../../docs/framework/wcf/diagnostics/etw/4022-webhostunregisterprotocolfailed.md)|Error|Error Code:%1|ActivationServices|  
|[4023 - WasCloseAllListenerChannelInstancesCompleted](../../../../../docs/framework/wcf/diagnostics/etw/4023-wasclosealllistenerchannelinstancescompleted.md)|Information|Was closing all listener channel instances completed.|ActivationServices|  
|[4024 - WasCloseAllListenerChannelInstancesFailed](../../../../../docs/framework/wcf/diagnostics/etw/4024-wasclosealllistenerchannelinstancesfailed.md)|Error|Error Code:%1|ActivationServices|  
|[4025 - OpenListenerChannelInstanceFailed](../../../../../docs/framework/wcf/diagnostics/etw/4025-openlistenerchannelinstancefailed.md)|Error|Error Code:%1|ActivationServices|  
|[4026 - WasConnected](../../../../../docs/framework/wcf/diagnostics/etw/4026-wasconnected.md)|Verbose|WAS Connected.|ActivationServices|  
|[4027 - WasDisconnected](../../../../../docs/framework/wcf/diagnostics/etw/4027-wasdisconnected.md)|Verbose|WAS Disconnected.|ActivationServices|  
|[4028 - PipeTransportListenerListeningStart](../../../../../docs/framework/wcf/diagnostics/etw/4028-pipetransportlistenerlisteningstart.md)|Verbose|Pipe transport listener listening start on uri:%1.|ActivationServices|  
|[4029 - PipeTransportListenerListeningStop](../../../../../docs/framework/wcf/diagnostics/etw/4029-pipetransportlistenerlisteningstop.md)|Verbose|Pipe transport listener listening stop.|ActivationServices|  
|[4030 - DispatchSessionSuccess](../../../../../docs/framework/wcf/diagnostics/etw/4030-dispatchsessionsuccess.md)|Information|Session dispatch succeeded.|ActivationServices|  
|[4031 - DispatchSessionFailed](../../../../../docs/framework/wcf/diagnostics/etw/4031-dispatchsessionfailed.md)|Error|Session dispatch failed.|ActivationServices|  
|[4032 - WasConnectionTimedout](../../../../../docs/framework/wcf/diagnostics/etw/4032-wasconnectiontimedout.md)|Critical|WAS connection timed out.|ActivationServices|  
|[4033 - RoutingTableLookupStart](../../../../../docs/framework/wcf/diagnostics/etw/4033-routingtablelookupstart.md)|Verbose|Routing table lookup started.|ActivationServices|  
|[4034 - RoutingTableLookupStop](../../../../../docs/framework/wcf/diagnostics/etw/4034-routingtablelookupstop.md)|Verbose|Routing table lookup completed.|ActivationServices|  
|[4035 - PendingSessionQueueRatio](../../../../../docs/framework/wcf/diagnostics/etw/4035-pendingsessionqueueratio.md)|Verbose|Pending session queue ratio: %1/%2|Quota|  
|[4600 - MessageLogEventSizeExceeded](../../../../../docs/framework/wcf/diagnostics/etw/4600-messagelogeventsizeexceeded.md)|Warning|Message could not be logged as it exceeds the ETW event size|WCFMessageLogging|  
|[4801 - DiscoveryClientInClientChannelFailedToClose](../../../../../docs/framework/wcf/diagnostics/etw/4801-discoveryclientinclientchannelfailedtoclose.md)|Warning|The DiscoveryClient created inside DiscoveryClientChannel failed to close and hence has been aborted.|Discovery|  
|[4802 - DiscoveryClientProtocolExceptionSuppressed](../../../../../docs/framework/wcf/diagnostics/etw/4802-discoveryclientprotocolexceptionsuppressed.md)|Information|A ProtocolException was suppressed while closing the DiscoveryClient. This could be because a DiscoveryService is still trying to send response to the DiscoveryClient.|Discovery|  
|[4803 - DiscoveryClientReceivedMulticastSuppression](../../../../../docs/framework/wcf/diagnostics/etw/4803-discoveryclientreceivedmulticastsuppression.md)|Information|The DiscoveryClient received a multicast suppression message from a DiscoveryProxy.|Discovery|  
|[4804 - DiscoveryMessageReceivedAfterOperationCompleted](../../../../../docs/framework/wcf/diagnostics/etw/4804-discoverymessagereceivedafteroperationcompleted.md)|Information|A %1 message with messageId='%2' was dropped by the DiscoveryClient because the corresponding %3 operation was completed.|Discovery|  
|[4805 - DiscoveryMessageWithInvalidContent](../../../../../docs/framework/wcf/diagnostics/etw/4805-discoverymessagewithinvalidcontent.md)|Warning|A %1 message with messageId='%2' was dropped because it had invalid content.|Discovery|  
|[4806 - DiscoveryMessageWithInvalidRelatesToOrOperationCompleted](../../../../../docs/framework/wcf/diagnostics/etw/4806-discoverymessagewithinvalidrelatestooroperationcompleted.md)|Warning|A %1 message with messageId='%2' and relatesTo='%3' was dropped by the DiscoveryClient because either the corresponding %4 operation was completed or the relatesTo value is invalid.|Discovery|  
|[4807 - DiscoveryMessageWithInvalidReplyTo](../../../../../docs/framework/wcf/diagnostics/etw/4807-discoverymessagewithinvalidreplyto.md)|Warning|A discovery request message with messageId='%1' was dropped because it had an invalid ReplyTo address.|Discovery|  
|[4808 - DiscoveryMessageWithNoContent](../../../../../docs/framework/wcf/diagnostics/etw/4808-discoverymessagewithnocontent.md)|Warning|A %1 message was dropped because it did not have any content.|Discovery|  
|[4809 - DiscoveryMessageWithNullMessageId](../../../../../docs/framework/wcf/diagnostics/etw/4809-discoverymessagewithnullmessageid.md)|Warning|A %1 message was dropped because the message header did not contain the required MessageId property.|Discovery|  
|[4810 - DiscoveryMessageWithNullMessageSequence](../../../../../docs/framework/wcf/diagnostics/etw/4810-discoverymessagewithnullmessagesequence.md)|Warning|A %1 message with messageId='%2' was dropped by the DiscoveryClient because it did not have the DiscoveryMessageSequence property.|Discovery|  
|[4811 - DiscoveryMessageWithNullRelatesTo](../../../../../docs/framework/wcf/diagnostics/etw/4811-discoverymessagewithnullrelatesto.md)|Warning|A %1 message with messageId='%2' was dropped by the DiscoveryClient because the message header did not contain the required RelatesTo property.|Discovery|  
|[4812 - DiscoveryMessageWithNullReplyTo](../../../../../docs/framework/wcf/diagnostics/etw/4812-discoverymessagewithnullreplyto.md)|Warning|A discovery request message with messageId='%1' was dropped because it did not have a ReplyTo address.|Discovery|  
|[4813 - DuplicateDiscoveryMessage](../../../../../docs/framework/wcf/diagnostics/etw/4813-duplicatediscoverymessage.md)|Warning|A %1 message with messageId='%2' was dropped because it was a duplicate.|Discovery|  
|[4814 - EndpointDiscoverabilityDisabled](../../../../../docs/framework/wcf/diagnostics/etw/4814-endpointdiscoverabilitydisabled.md)|Information|The discoverability of endpoint with EndpointAddress='%1' and ListenUri='%2' has been disabled.|Discovery|  
|[4814 - EndpointDiscoverabilityDisabled](../../../../../docs/framework/wcf/diagnostics/etw/4814-endpointdiscoverabilitydisabled.md)|Information|The discoverability of endpoint with EndpointAddress='%1' and ListenUri='%2' has been enabled.|Discovery|  
|[4816 - FindInitiatedInDiscoveryClientChannel](../../../../../docs/framework/wcf/diagnostics/etw/4816-findinitiatedindiscoveryclientchannel.md)|Verbose|A Find operation was initiated in the DiscoveryClientChannel to discover endpoint(s).|Discovery|  
|[4817 - InnerChannelCreationFailed](../../../../../docs/framework/wcf/diagnostics/etw/4817-innerchannelcreationfailed.md)|Warning|The DiscoveryClientChannel failed to create the channel with a discovered endpoint with EndpointAddress='%1' and Via='%2'. The DiscoveryClientChannel will now attempt to use the next available discovered endpoint.|Discovery|  
|[4818 - InnerChannelOpenFailed](../../../../../docs/framework/wcf/diagnostics/etw/4818-innerchannelopenfailed.md)|Warning|The DiscoveryClientChannel failed to open the channel with a discovered endpoint with EndpointAddress='%1' and Via='%2'. The DiscoveryClientChannel will now attempt to use the next available discovered endpoint.|Discovery|  
|[4819 - InnerChannelOpenSucceeded](../../../../../docs/framework/wcf/diagnostics/etw/4819-innerchannelopensucceeded.md)|Information|The DiscoveryClientChannel successfully discovered an endpoint and opened the channel using it. The client is connected to a service using EndpointAddress='%1' and Via='%2'.|Discovery|  
|[4820 - SynchronizationContextReset](../../../../../docs/framework/wcf/diagnostics/etw/4820-synchronizationcontextreset.md)|Information|The SynchronizationContext has been reset to its original value of %1 by DiscoveryClientChannel.|Discovery|  
|[4821 - SynchronizationContextSetToNull](../../../../../docs/framework/wcf/diagnostics/etw/4821-synchronizationcontextsettonull.md)|Information|The SynchronizationContext has been set to null by DiscoveryClientChannel before initiating the Find operation.|Discovery|  
|[5001 - DCSerializeWithSurrogateStart](../../../../../docs/framework/wcf/diagnostics/etw/5001-dcserializewithsurrogatestart.md)|Verbose|DataContract serialize %1 with surrogates start.|Serialization|  
|[5002 - DCSerializeWithSurrogateStop](../../../../../docs/framework/wcf/diagnostics/etw/5002-dcserializewithsurrogatestop.md)|Verbose|DataContract serialize with surrogates stop.|Serialization|  
|[5003 - DCDeserializeWithSurrogateStart](../../../../../docs/framework/wcf/diagnostics/etw/5003-dcdeserializewithsurrogatestart.md)|Verbose|DataContract deserialize %1 with surrogates start.|Serialization|  
|[5004 - DCDeserializeWithSurrogateStop](../../../../../docs/framework/wcf/diagnostics/etw/5004-dcdeserializewithsurrogatestop.md)|Verbose|DataContract deserialize with surrogates stop.|Serialization|  
|[5005 - ImportKnownTypesStart](../../../../../docs/framework/wcf/diagnostics/etw/5005-importknowntypesstart.md)|Verbose|ImportKnownTypes start.|Serialization|  
|[5006 - ImportKnownTypesStop](../../../../../docs/framework/wcf/diagnostics/etw/5006-importknowntypesstop.md)|Verbose|ImportKnownTypes stop.|Serialization|  
|[5007 - DCResolverResolve](../../../../../docs/framework/wcf/diagnostics/etw/5007-dcresolverresolve.md)|Verbose|DataContract resolver resolving %1 start.|Serialization|  
|[5008 - DCGenWriterStart](../../../../../docs/framework/wcf/diagnostics/etw/5008-dcgenwriterstart.md)|Verbose|DataContract generate %1 writer for %2 start.|Serialization|  
|[5009 - DCGenWriterStop](../../../../../docs/framework/wcf/diagnostics/etw/5009-dcgenwriterstop.md)|Verbose|DataContract generate writer stop.|Serialization|  
|[5010 - DCGenReaderStart](../../../../../docs/framework/wcf/diagnostics/etw/5010-dcgenreaderstart.md)|Verbose|DataContract generate %1 reader for %2 start.|Serialization|  
|[5011 - DCGenReaderStop](../../../../../docs/framework/wcf/diagnostics/etw/5011-dcgenreaderstop.md)|Verbose|DataContract generation stop.|Serialization|  
|[5012 - DCJsonGenReaderStart](../../../../../docs/framework/wcf/diagnostics/etw/5012-dcjsongenreaderstart.md)|Verbose|Json generate %1 reader for %2 start.|Serialization|  
|[5013 - DCJsonGenReaderStop](../../../../../docs/framework/wcf/diagnostics/etw/5013-dcjsongenreaderstop.md)|Verbose|Json reader generation stop.|Serialization|  
|[5014 - DCJsonGenWriterStart](../../../../../docs/framework/wcf/diagnostics/etw/5014-dcjsongenwriterstart.md)|Verbose|Json generate %1 writer for %2 start.|Serialization|  
|[5015 - DCJsonGenWriterStop](../../../../../docs/framework/wcf/diagnostics/etw/5015-dcjsongenwriterstop.md)|Verbose|Json generate writer stop.|Serialization|  
|[5016 - GenXmlSerializableStart](../../../../../docs/framework/wcf/diagnostics/etw/5016-genxmlserializablestart.md)|Verbose|Generate Xml serializable for '%1' start.|Serialization|  
|[5017 - GenXmlSerializableStop](../../../../../docs/framework/wcf/diagnostics/etw/5017-genxmlserializablestop.md)|Verbose|Generate Xml serializable stop.|Serialization|  
|[5203 - JsonMessageDecodingStart](../../../../../docs/framework/wcf/diagnostics/etw/5203-jsonmessagedecodingstart.md)|Verbose|JsonMessageEncoder started decoding the message.|Channel|  
|[5204 - JsonMessageEncodingStart](../../../../../docs/framework/wcf/diagnostics/etw/5204-jsonmessageencodingstart.md)|Verbose|JsonMessageEncoder started encoding the message.|Channel|  
|[5402 - TokenValidationStarted](../../../../../docs/framework/wcf/diagnostics/etw/5402-tokenvalidationstarted.md)|Verbose|SecurityToken (type '%1' and id '%2') validation started.|Security|  
|[5403 - TokenValidationSuccess](../../../../../docs/framework/wcf/diagnostics/etw/5403-tokenvalidationsuccess.md)|Verbose|SecurityToken (type '%1' and id '%2') validation succeeded.|Security|  
|[5404 - TokenValidationFailure](../../../../../docs/framework/wcf/diagnostics/etw/5404-tokenvalidationfailure.md)|Error|SecurityToken (type '%1' and id '%2') validation failed. %3|Security|  
|[5405 - GetIssuerNameSuccess](../../../../../docs/framework/wcf/diagnostics/etw/5405-getissuernamesuccess.md)|Verbose|Retrieval of issuer name:%1 from tokenId:%2 succeeded.|Security|  
|[5406 - GetIssuerNameFailure](../../../../../docs/framework/wcf/diagnostics/etw/5406-getissuernamefailure.md)|Error|Retrieval of issuer name from tokenId:%1 failed.|Security|  
|[5600 - FederationMessageProcessingStarted](../../../../../docs/framework/wcf/diagnostics/etw/5600-federationmessageprocessingstarted.md)|Verbose|Federation message processing started.|Security|  
|[5601 - FederationMessageProcessingSuccess](../../../../../docs/framework/wcf/diagnostics/etw/5601-federationmessageprocessingsuccess.md)|Verbose|Federation message processing succeeded.|Security|  
|[5602 - FederationMessageCreationStarted](../../../../../docs/framework/wcf/diagnostics/etw/5602-federationmessagecreationstarted.md)|Verbose|Creating federation message from form post started.|Security|  
|[5603 - FederationMessageCreationSuccess](../../../../../docs/framework/wcf/diagnostics/etw/5603-federationmessagecreationsuccess.md)|Verbose|Creating federation message from form post succeeded.|Security|  
|[5604 - SessionCookieReadingStarted](../../../../../docs/framework/wcf/diagnostics/etw/5604-sessioncookiereadingstarted.md)|Verbose|Reading session token from session cookie started.|Security|  
|[5605 - SessionCookieReadingSuccess](../../../../../docs/framework/wcf/diagnostics/etw/5605-sessioncookiereadingsuccess.md)|Verbose|Reading session token from session cookie succeeded.|Security|  
|[5606 - PrincipalSettingFromSessionTokenStarted](../../../../../docs/framework/wcf/diagnostics/etw/5606-principalsettingfromsessiontokenstarted.md)|Verbose|Principal setting from session token started.|Security|  
|[5607 - PrincipalSettingFromSessionTokenSuccess](../../../../../docs/framework/wcf/diagnostics/etw/5607-principalsettingfromsessiontokensuccess.md)|Verbose|Principal setting from session token succeeded.|Security|  
|[57393 - AppDomainUnload](../../../../../docs/framework/wcf/diagnostics/etw/57393-appdomainunload.md)|Information|AppDomain unloading. AppDomain.FriendlyName %1, ProcessName %2, ProcessId %3.|Infrastructure|  
|[57394 - HandledException](../../../../../docs/framework/wcf/diagnostics/etw/57394-handledexception.md)|Information|Handling an exception.|Infrastructure|  
|[57395 - ShipAssertExceptionMessage](../../../../../docs/framework/wcf/diagnostics/etw/57395-shipassertexceptionmessage.md)|Error|An unexpected failure occurred. Applications should not attempt to handle this error. For diagnostic purposes, this English message is associated with the failure: %1.|Infrastructure|  
|[57396 - ThrowingException](../../../../../docs/framework/wcf/diagnostics/etw/57396-throwingexception.md)|Warning|Throwing an exception. Source %1.|Infrastructure|  
|[57397 - UnhandledException](../../../../../docs/framework/wcf/diagnostics/etw/57397-unhandledexception.md)|Critical|Unhandled exception.|Infrastructure|  
|[57399 - TraceCodeEventLogCritical](../../../../../docs/framework/wcf/diagnostics/etw/57399-tracecodeeventlogcritical.md)|Critical|Wrote to the EventLog.|Infrastructure|  
|[57400 - TraceCodeEventLogError](../../../../../docs/framework/wcf/diagnostics/etw/57400-tracecodeeventlogerror.md)|Error|Wrote to the EventLog.|Infrastructure|  
|[57401 - TraceCodeEventLogInfo](../../../../../docs/framework/wcf/diagnostics/etw/57401-tracecodeeventloginfo.md)|Information|Wrote to the EventLog.|Infrastructure|  
|[57402 - TraceCodeEventLogVerbose](../../../../../docs/framework/wcf/diagnostics/etw/57402-tracecodeeventlogverbose.md)|Verbose|Wrote to the EventLog.|Infrastructure|  
|[57403 - TraceCodeEventLogWarning](../../../../../docs/framework/wcf/diagnostics/etw/57403-tracecodeeventlogwarning.md)|Warning|Wrote to the EventLog.|Infrastructure|  
|[57404 - HandledExceptionWarning](../../../../../docs/framework/wcf/diagnostics/etw/57404-handledexceptionwarning.md)|Warning|Handling an exception.|Infrastructure|  
|[62326 - HttpHandlerPickedForUrl](../../../../../docs/framework/wcf/diagnostics/etw/62326-httphandlerpickedforurl.md)|Information|The url '%1' hosts XAML document with root element type '%2'. The HTTP handler type '%3' is picked to serve all the requests made to this url.|WebHost|
