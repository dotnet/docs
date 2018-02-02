---
title: "Custom Filters"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 97cf247d-be0a-4057-bba9-3be5c45029d5
caps.latest.revision: 5
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Filters
Custom filters allow you to define matching logic that cannot be accomplished using the system-provided message filters. For example, you might create a custom filter that hashes a particular message element and then examines the value to determine whether the filter should return true or false.  
  
## Implementation  
 A custom filter is an implementation of the <xref:System.ServiceModel.Dispatcher.MessageFilter> abstract base class. When implementing your custom filter, the constructor can optionally accept a single string parameter. This parameter contains the configuration information that is passed to the MessageFilter constructor in order to provide any values or configuration that the filter needs at runtime in order to perform matches. For example, this might be used to provide a value that the filter looks for within the message being evaluated. The following example demonstrates a basic implementation of a custom message filter that accepts a string parameter:  
  
```csharp  
public class MyMessageFilter: MessageFilter  
{  
    string filterData;  
    public MyMessageFilter(string filterData)  
    {  
        if(string.IsNullOrEmpty(filterData)  
            throw new ArgumentNullException("filterData");  
        this.filterData=filterData;  
    }  
    public override bool Match(System.ServiceModel.Channels.Message message)  
    {  
        ...  
        return retValue;  
    }  
    public override bool Match(System.ServiceModel.Channels.MessageBuffer buffer)  
    {  
        ...  
        return retValue;  
    }  
}  
```  
  
> [!NOTE]
>  In an actual implementation, the Match method(s) contains logic that will examine the message to determine if this message filter should return **true** or **false**.  
  
### Performance  
 When implementing a custom filter, it is important to take into consideration the maximum length of time required for the filter to complete the evaluation of a message. Since a message may be evaluated against multiple filters before a match is found, it is important to ensure that the client request does not time out before all filters can be evaluated. Therefore a custom filter should contain only the code necessary to evaluate the contents or attributes of a message in order to determine if it matches the filter criteria.  
  
 In general, you should avoid the following when implementing a custom filter:  
  
-   IO, such as saving data to disk or to a database.  
  
-   Unnecessary processing, such as looping over multiple records in a document.  
  
-   Blocking operations, such as calls that involve obtaining a lock on shared resources or performing lookups against a database.  
  
 Before using a custom filter in a production environment, you should run performance tests to determine the average length of time that the filter takes to evaluate a message. When combined with the average processing time of the other filters used in the filter table, this will allow you to accurately determine the maximum timeout value that should be specified by the client application.  
  
## Usage  
 In order to use your custom filter with the Routing Service, you must add it to the filter table by specifying a new filter entry of type "Custom," the fully qualified type name of the message filter, and the name of your assembly.  As with other MessageFilters, you can specify the string filterData that will be passed to your custom filter’s constructor.  
  
 The following examples demonstrate using a custom filter with the Routing Service:  
  
```xml  
<!--ROUTING SECTION -->  
<routing>  
  <filters>  
    <filter name="CustomFilter1" filterType="Custom"   
            customType="CustomAssembly.MyMessageFilter,   
            CustomAssembly" filterData="custom data" />  
  </filters>  
  <filterTables>  
    <table name="routingTable1">  
      <filters>  
        <add filterName="CustomFilter1" endpointName="CalculatorService" />  
      </filters>  
    </table>  
  </filterTables>  
</routing>  
```  
  
```csharp  
RoutingConfiguration rc = new RoutingConfiguration();  
List<ServiceEndpoint> endpointList = new List<ServiceEndpoint>();  
endpointList.Add(client);  
rc.FilterTable.Add(new MyMessageFilter("CustomData"), endpointList);  
```
