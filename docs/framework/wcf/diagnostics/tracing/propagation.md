---
title: "Propagation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f8181e75-d693-48d1-b333-a776ad3b382a
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Propagation
This topic describes activity propagation in the [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] tracing model.  
  
## Using Propagation to Correlate Activities Across Endpoints  
 Propagation provides the user with direct correlation of error traces for the same unit of processing across application endpoints, for example, a request. Errors emitted at different endpoints for the same unit of processing are grouped in the same activity, even across application domains. This is done through propagation of the activity ID in the message headers. Therefore, if a client times out because of an internal error in the server, both errors appear in the same activity for direct correlation.  
  
 To do this, use the `ActivityTracing` setting as demonstrated in the previous example. In addition, set the `propagateActivity` attribute for the `System.ServiceModel` trace source at all endpoints.  
  
```xml  
<source name="System.ServiceModel" switchValue="Verbose,ActivityTracing" propagateActivity="true" >  
```  
  
 Activity propagation is a configurable capability that causes [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] to add a header to outbound messages, which includes the activity ID on the TLS. By including this on subsequent traces on the server side, we can correlate client and server activities.  
  
## Propagation Definition  
 Activity M’s gAId is propagated to activity N if all of the following conditions apply.  
  
-   N is created because of M  
  
-   M’s gAId is known to N  
  
-   N's gAId is equal to M’s gAId.  
  
 The gAId is propagated through the ActivityId message header, as illustrated in the following XML schema.  
  
```xml  
<xsd:element name="ActivityId" type="integer" minOccurs="0">  
  <xsd:attribute name="CorrelationId" type="integer" minOccurs="0"/>  
</xsd:element>  
```  
  
 The following is an example of the message header.  
  
```xml  
<MessageLogTraceRecord>  
  <s:Envelope xmlns:s="http://www.w3.org/2003/05/soap-envelope"     
                      xmlns:a="http://www.w3.org/2005/08/addressing">  
    <s:Header>  
      <a:Action s:mustUnderstand="1">http://Microsoft.ServiceModel.Samples/ICalculator/Subtract  
      </a:Action>  
      <a:MessageID>urn:uuid:f0091eae-d339-4c7e-9408-ece34602f1ce  
      </a:MessageID>  
      <ActivityId CorrelationId="f94c6af1-7d5d-4295-b693-4670a8a0ce34"   
  
               xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">  
        17f59a29-b435-4a15-bf7b-642ffc40eac8  
      </ActivityId>  
      <a:ReplyTo>  
          <a:Address>http://www.w3.org/2005/08/addressing/anonymous  
          </a:Address>  
      </a:ReplyTo>  
      <a:To s:mustUnderstand="1">net.tcp://localhost/servicemodelsamples/service</a:To>  
   </s:Header>  
   <s:Body>  
     <Subtract xmlns="http://Microsoft.ServiceModel.Samples">  
       <n1>145</n1>  
       <n2>76.54</n2>  
     </Subtract>  
   </s:Body>  
  </s:Envelope>  
</MessageLogTraceRecord>  
```  
  
## Propagation and Activity Boundaries  
 When the activity ID is propagated across endpoints, the message receiver emits a Start and Stop traces with that (propagated) activity ID. Therefore, there is a Start and Stop trace with that gAId from each trace source. If the endpoints are in the same process and use the same trace source name, multiple Start and Stop with the same lAId (same gAId, same trace source, same process) are created.  
  
## Synchronization  
 To synchronize events across endpoints that run on different machines, a CorrelationId is added to the ActivityId header that is propagated in messages. Tools can use this ID to synchronize events across machines with clock discrepancy. Specifically, the Service Trace Viewer tool uses this ID for showing message flows between endpoints.  
  
## See Also  
 [Configuring Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md)  
 [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](../../../../../docs/framework/wcf/diagnostics/tracing/using-service-trace-viewer-for-viewing-correlated-traces-and-troubleshooting.md)  
 [End-To-End Tracing Scenarios](../../../../../docs/framework/wcf/diagnostics/tracing/end-to-end-tracing-scenarios.md)  
 [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md)
