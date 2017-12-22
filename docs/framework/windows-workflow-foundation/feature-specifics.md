---
title: "Windows Workflow Foundation Feature Specifics"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e84d12da-a055-45f6-b4d1-878d127b46b6
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Windows Workflow Foundation Feature Specifics
[!INCLUDE[netfx40_long](../../../includes/netfx40-long-md.md)] adds a number of features to Windows Workflow Foundation. This document describes a number of the new features, and gives details about scenarios in which they may be useful.  
  
## Messaging Activities  
 The messaging activities (<xref:System.ServiceModel.Activities.Receive>, <xref:System.ServiceModel.Activities.SendReply>, <xref:System.ServiceModel.Activities.Send>, <xref:System.ServiceModel.Activities.ReceiveReply>) are used to send and receive [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] messages from your workflow.  <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> activities are used to form a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service operation that is exposed via WSDL just like standard [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] web services.  <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.ReceiveReply> are used to consume a web service similar to a WCF <xref:System.ServiceModel.ChannelFactory>; an **Add Service Reference** experience also exists for Workflow Foundation that generates pre-configured activities.  
  
### Getting Started with Messaging Activities  
  
-   In [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], create a WCF Workflow Service Application project. A <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> pair will be placed on your canvas.  
  
-   Right-click on the project and select **Add Service Reference**.  Point to an existing web service WSDL and click **OK**.  Build your project to show the generated activities (implemented using <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.ReceiveReply>) in your toolbox.  
  
-   Samples for these activities can be found in the following sections:  
  
    -   Basic: [Services](../../../docs/framework/windows-workflow-foundation/samples/services.md)  
  
    -   Scenarios: [Services](../../../docs/framework/windows-workflow-foundation/samples/services.md)  
  
-   [Conceptual documentation](http://go.microsoft.com/fwlink/?LinkId=204801)  
  
-   [Messaging activities designer documentation](http://go.microsoft.com/fwlink/?LinkId=204802)  
  
### Messaging Activities Example Scenario  
 A `BestPriceFinder` service calls out to multiple airline services to find the best ticket price for a particular route.  Implementing this scenario would require you to use the message activities to receive the price request, retrieve the prices from the back-end services, and reply to the price request with the best price.  It would also require you to use other out-of-box activities to create the business logic for calculating the best price.  
  
## WorkflowServiceHost  
 The <xref:System.ServiceModel.WorkflowServiceHost> is the out-of-box workflow host that supports multiple instances, configuration, and [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] messaging (although the workflows aren’t required to use messaging in order to be hosted).  It also integrates with persistence, tracking, and instance control through a set of service behaviors.  Just like [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]’s <xref:System.ServiceModel.ServiceHost>, the <xref:System.ServiceModel.WorkflowServiceHost> can be self-hosted in a console/WinForms/WPF application or Windows service, or web-hosted (as a .xamlx file) in IIS or WAS.  
  
### Getting Started with Workflow Service Host  
  
-   In Visual Studio 2010, create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Workflow Service Application project: this project will be set up to use <xref:System.ServiceModel.WorkflowServiceHost> in a web-host environment.  
  
-   In order to host a non-messaging workflow, add a custom <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint> that will create the instance based on a message.  
  
-   Workflow instances can be controlled (e.g. suspended or terminated) by adding a <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> to the <xref:System.ServiceModel.WorkflowServiceHost> and then using a <xref:System.ServiceModel.Activities.WorkflowControlClient>.  
  
-   Samples for the <xref:System.ServiceModel.WorkflowServiceHost> can be found in the following sections:  
  
    -   [Execution](../../../docs/framework/windows-workflow-foundation/samples/execution.md)  
  
    -   Basic: [Services](../../../docs/framework/windows-workflow-foundation/samples/services.md)  
  
    -   Scenarios: [Services](../../../docs/framework/windows-workflow-foundation/samples/services.md)  
  
    -   Application: [Suspended Instance Management](../../../docs/framework/windows-workflow-foundation/samples/suspended-instance-management.md)  
  
-   [WorkflowServiceHost Conceptual Documentation](http://go.microsoft.com/fwlink/?LinkId=204807)  
  
### WorkflowServiceHost Scenario  
 A BestPriceFinder service calls out to multiple airline services to find the best ticket price for a particular route.  Implementing this scenario would require you to host the workflow in <xref:System.ServiceModel.WorkflowServiceHost>.  It would also use the message activities to receive the price request, retrieve the prices from the back-end services, and reply to the price request with the best price.  
  
## Correlation  
 A correlation is one of two things:  
  
-   A way of grouping messages together; that is, the relationship between a request message and its reply.  
  
-   A way of mapping a piece of data to a service instance  
  
### Getting Started  
  
-   To get started with correlation, create a new project in Visual Studio. Create a variable of type <xref:System.ServiceModel.Activities.CorrelationHandle>.  
  
-   An example of correlation used to group messages together is a Request-Reply correlation that groups messages together.  
  
    -   On a <xref:System.ServiceModel.Activities.Receive> activity, click on the <xref:System.ServiceModel.Activities.Receive.CorrelationInitializers%2A> property and add a <xref:System.ServiceModel.Activities.RequestReplyCorrelationInitializer> using the CorrelationHandle created in the first step above.  
  
    -   Create a <xref:System.ServiceModel.Activities.SendReply> activity by right-clicking on the <xref:System.ServiceModel.Activities.Receive> and clicking "Create SendReply". Paste it into your workflow after the <xref:System.ServiceModel.Activities.Receive> activity.  
  
-   An example of mapping a piece of data to a service instance is content-based correlation which maps a piece of data (for example, an order ID) to a particular workflow instance.  
  
    -   On any messaging activity, click on the `CorrelationInitializers` property and add a <xref:System.ServiceModel.Activities.QueryCorrelationInitializer> using the <xref:System.ServiceModel.Activities.CorrelationHandle> variable created above. Double-click on the desired property on the message (e.g. OrderID) from the drop-down menu. Set the `CorrelatesWith` property to the <xref:System.ServiceModel.Activities.CorrelationHandle> variable used above.  
  
-   Samples:  
  
    -   Basic: [Services](../../../docs/framework/windows-workflow-foundation/samples/services.md)  
  
    -   Scenarios: [Services](../../../docs/framework/windows-workflow-foundation/samples/services.md)  
  
    -   [Correlation Conceptual Documentation](http://go.microsoft.com/fwlink/?LinkId=204939)  
  
### Correlation Scenario  
 An order-processing workflow is used to handle new order creation and updating existing orders that are in process.  Implementing this scenario would require you to host the workflow in <xref:System.ServiceModel.WorkflowServiceHost> and use the messaging activities.  It would also require correlation based on the `orderId` to ensure that updates are made to the correct workflow.  
  
## Simplified Configuration  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration schema is complex and provides users with many hard to find features. In [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)], we have focused on helping [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] users configure their services with the following features:  
  
-   Removing the need for explicit per-service configuration. If you do not configure any \<service> elements for your service, and your service does not define programmatically any endpoint, then a set of endpoints will be automatically added to your service, one per service base address and per contract implemented by your service.  
  
-   Enables the user to define default values for WCF bindings and behaviors, which will be applied to services with no explicit configuration.  
  
-   Standard endpoints define reusable preconfigured endpoints, which have fixed values for one or more of the endpoint properties (address, binding and contract), and allow defining custom properties.  
  
-   Finally, the <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601> allows you to do central management of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client configuration, useful in scenarios in which configuration is selected or changed after the application domain load time.  
  
### Getting Started  
  
-   [A Developer's Guide to WCF 4.0](http://go.microsoft.com/fwlink/?LinkId=204940)  
  
-   [Configuration Channel Factory](http://go.microsoft.com/fwlink/?LinkId=204941)  
  
-   [Standard Endpoint Element](http://go.microsoft.com/fwlink/?LinkId=204942)  
  
-   [Service configuration improvements in .Net Framework 4](http://go.microsoft.com/fwlink/?LinkId=204943)  
  
-   [Common User Mistake in .NET 4: Mistyping the WF/WCF Service Configuration Name](http://go.microsoft.com/fwlink/?LinkId=204944)  
  
### Simplified Configuration Scenarios  
  
-   An experienced ASMX developer wants to start using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]. However, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] seems way too complicated! What is all that information that I need to write in a configuration file? In .NET 4, you can even decide to not have a configuration file at all.  
  
-   An existing set of WCF services are very difficult to configure and maintain. The configuration file has thousands of lines of XML code that are extremely dangerous to touch. Help is needed to reduce that amount of code to something more manageable.  
  
## Data Contract Resolver  
 In .NET 3.5, there were a few limitations in the design of known types:  
  
-   Adding known types dynamically, during serialization or deserialization, was not possible.  
  
-   Serializers could not deal with unknown xsi:type information.  
  
-   It was not possible for users to specify what xsi:type they would like to have appear on the wire to, for instance, make the size of a serialization instance on the wire smaller.  
  
 The [DataContractResolver](../../../docs/framework/wcf/samples/datacontractresolver.md) solves these issues in .NET 4.5.  
  
### Getting Started  
  
-   [Data Contract Resolver API documentation](http://go.microsoft.com/fwlink/?LinkId=204946)  
  
-   [Introducing the Data Contract Resolver](http://go.microsoft.com/fwlink/?LinkId=204947)  
  
-   Samples:  
  
    -   [DataContractResolver](../../../docs/framework/wcf/samples/datacontractresolver.md)  
  
    -   [KnownAssemblyAttribute](../../../docs/framework/wcf/samples/knownassemblyattribute.md)  
  
### Data Contract Resolver Scenarios  
  
-   Avoiding having to declare tens of <xref:System.Runtime.Serialization.KnownTypeAttribute> objects in a service.  
  
-   Reducing the size of the XML blob.  
  
## Flowchart  
 Flowchart is a well-known paradigm to visually represent domain problems. It is a new control flow style we’re introducing in .NET 4. A core characteristic of Flowchart is that only one activity is executed at any given time. Flowcharts can express loops and alternative outcomes, but cannot natively express concurrent execution of multiple nodes.  
  
### Getting Started  
  
-   In [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], create a workflow console application. Add a Flowchart in the workflow designer.  
  
-   The flowchart feature uses the following classes:  
  
    -   <xref:System.Activities.Statements.Flowchart>  
  
    -   <xref:System.Activities.Statements.FlowNode>  
  
    -   <xref:System.Activities.Statements.FlowDecision>  
  
    -   <xref:System.Activities.Statements.FlowStep>  
  
    -   <xref:System.Activities.Statements.FlowSwitch%601>  
  
-   Samples:  
  
    -   [Fault Handling in a Flowchart Activity Using TryCatch](../../../docs/framework/windows-workflow-foundation/samples/fault-handling-in-a-flowchart-activity-using-trycatch.md)  
  
    -   [StateMachine Scenario Using a Combination of FlowChart and Pick](../../../docs/framework/windows-workflow-foundation/samples/statemachine-scenario-using-a-combination-of-flowchart-and-pick.md)  
  
    -   [Hiring Process](../../../docs/framework/windows-workflow-foundation/samples/hiring-process.md)  
  
-   Designer Documentation:  
  
    -   [Flowchart Activity Designers](/visualstudio/workflow-designer/flowchart-activity-designers)  
  
### Flowchart Scenarios  
 A flowchart activity can be used to implement a guessing game. The guessing game is very simple: the computer selects a random number and the player has to guess that number. When the player submits each guess, the computer shows him a hint (i.e. "try a lower number"). If the player finds the number in less than 7 attempts, he receives a special congratulation from the computer. This game can be implemented with a combination of the following procedural activities:  
  
-   <xref:System.Activities.Statements.Sequence>  
  
-   <xref:System.Activities.Statements.While>  
  
-   <xref:System.Activities.Statements.Switch%601>  
  
-   <xref:System.Activities.Statements.TryCatch>  
  
-   <xref:System.Activities.Statements.Assign%601>  
  
-   <xref:System.Activities.Statements.If>  
  
## Procedural activities (Sequence, If, ForEach, Switch, Assign, DoWhile, While)  
 Procedural activities provide a mechanism to model sequential control flow using concepts that are familiar to programmers. These activities enable traditionally structured programming language constructs and, when appropriate, provide language parity with common procedural languages such as C#/VB.  
  
### Getting Started  
  
-   In [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], create a workflow console application. Add procedural activities in the workflow designer.  
  
-   Samples:  
  
    -   [Hiring Process](../../../docs/framework/windows-workflow-foundation/samples/hiring-process.md)  
  
    -   [Corporate Purchase Process](../../../docs/framework/windows-workflow-foundation/samples/corporate-purchase-process.md)  
  
-   Designer Documentation:  
  
    -   [Parallel Activity Designer](/visualstudio/workflow-designer/parallel-activity-designer)  
  
    -   [ParallelForEach\<T> Activity Designer](/visualstudio/workflow-designer/parallelforeach-t-activity-designer)  
  
### Procedural Activity Scenarios  
  
-   <xref:System.Activities.Statements.Parallel>: An intranet document management system has a document approval workflow. Documents need to be approved by people in several departments before they can be published to the intranet. There isn’t an established order for the approvals; they can occur at any time while the document is in the "approval pending" phase. When a user submits a document for review it must be approved by her direct manager, the intranet administrator, and the internal communications manager.  
  
-   <xref:System.Activities.Statements.ParallelForEach%601>: A WF application manages corporate buys within a large company. The corporate rules dictate that before planning any purchase operation, the valuations of three different vendors is required. An employee from the buying department selects three vendors from the company’s vendor list. After these vendors have been selected and notified, the company will wait for their economic proposals. The proposals can come in any order. To implement this scenario in WF, we use a <xref:System.Activities.Statements.ParallelForEach%601> that will iterate through our collection of vendors and ask for their economic proposals. After all offers are gathered, the best one is selected and displayed.  
  
## InvokeMethod  
 The <xref:System.Activities.Statements.InvokeMethod> activity allows invoking public methods in objects or types in scope. It supports invoking instance and static methods with or without parameters (including parameter arrays), and generic methods. It also allows executing method synchronously and asynchronously.  
  
### Getting Started  
  
-   In [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], create a workflow console application. Add an <xref:System.Activities.Statements.InvokeMethod> activity in the workflow designer, and configure static and instance methods on it.  
  
-   Samples:  
  
    -   [InvokeMethod](../../../docs/framework/windows-workflow-foundation/samples/invokemethod.md)  
  
-   Designer Documentation: [InvokeMethod Activity Designer](/visualstudio/workflow-designer/invokemethod-activity-designer)  
  
### InvokeMethod Scenarios  
  
-   A method in an object in scope needs to be invoked. For example, a value needs to be added to a dictionary. The Add method of the instance of the dictionary is invoked, and the key and value are provided.  
  
-   A method needs to be invoked on a legacy CLR object. Instead of creating a custom activity to wrap the call to that legacy class, if it is in scope during the workflow execution, <xref:System.Activities.Statements.InvokeMethod> can be used.  
  
## Error handling activities  
 The <xref:System.Activities.Statements.TryCatch> activity provides a mechanism for catching exceptions that occur during the execution of a set of contained activities (similar to the Try/Catch construct in C#/VB). <xref:System.Activities.Statements.TryCatch> provides exception handling at the workflow level. When an unhandled exception is thrown, the workflow is aborted and the Finally block won’t be executed. This behavior is consistent with C#.  
  
### Getting Started  
  
-   In [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], create a workflow console application. Add a <xref:System.Activities.Statements.TryCatch> activity in the workflow designer.  
  
-   Samples:  
  
    1.  [Fault Handling in a Flowchart Activity Using TryCatch](../../../docs/framework/windows-workflow-foundation/samples/fault-handling-in-a-flowchart-activity-using-trycatch.md)  
  
    2.  [Using Procedural Activities](../../../docs/framework/windows-workflow-foundation/samples/using-procedural-activities.md)  
  
-   Designer Documentation: [Error Handling Activity Designers](/visualstudio/workflow-designer/error-handling-activity-designers)  
  
### Error handling scenarios  
 A set of activities needs to be executed, and specific logic needs to be executed when an error occurs. If during that error handling logic it is found that the error is not recoverable, the exception will be rethrown, and the parent activity (or the host) will deal with the problem.  
  
## Pick activity  
 The <xref:System.Activities.Statements.Pick> Activity provides event-based control flow modeling in WF. <xref:System.Activities.Statements.Pick> contains many branches where each branch waits for a particular event to occur before running. In this setup, a <xref:System.Activities.Statements.Pick> behaves similar to a <xref:System.Activities.Statements.Switch%601> to which the Activity will execute only one of the set of events it is listening. Each branch is event driven and the event that occurs runs the corresponding branch first. All other branches cancel and stop listening for events.  
  
### Getting Started  
  
-   In [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], create a workflow console application. Add a <xref:System.Activities.Statements.Pick> activity in the workflow designer.  
  
-   Sample: [Using the Pick Activity](../../../docs/framework/windows-workflow-foundation/samples/using-the-pick-activity.md)  
  
-   Designer documentation: [Pick Activity Designer](/visualstudio/workflow-designer/pick-activity-designer)  
  
### Pick Scenario  
 A user needs to be prompted for input. Under normal circumstances, the developer would use a method call like <xref:System.Console.ReadLine%2A> to prompt for a user’s input. The problem with this setup is that the program waits until the user enters something. In this scenario, a time-out is needed to unblock a blocking activity. A common scenario is one that requires a task to be completed within a given time duration. Timing out a blocking activity is a scenario where Pick adds a lot of value.  
  
## WCF Routing Service  
 The Routing Service is designed to be a generic software Router that allows you to control how [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]messages flow in between your clients and services.  The Routing Service allows you to decouple your clients from your services, which gives you much more freedom in terms of the configurations that you can support and the flexibility you have when considering how to host your services.  In .NET 3.5, clients and services were tightly coupled; a client had to know about all of the services it needed to talk to and where they were located. In addition, WCF in .Net Framework 3.5 had the following limitations:  
  
-   Error handling was complex, as this logic had to be hard-coded into the client.  
  
-   Clients and services had to always use the same bindings.  
  
-   Services were rarely well factored: it is easier to have the client talk to one service which implements everything, rather than needing to choose between multiple services.  
  
 The routing service in .Net 4 is designed to make these problems easier to solve. The new routing service has the following features:  
  
1.  Content based routing (<xref:System.ServiceModel.Dispatcher.MessageFilter> objects examine a message to determine where it should be sent.)  
  
2.  Protocol bridging (transport & message)  
  
3.  Error handling (the router catches communication exceptions and fails over to backup endpoints)  
  
4.  Dynamic (in memory) update of <xref:System.ServiceModel.Dispatcher.MessageFilterTable%601> and Routing Configuration.  
  
### Getting Started  
  
1.  Documentation: [Routing](../../../docs/framework/wcf/feature-details/routing.md)  
  
2.  Samples: [Routing Services &#91;WCF Samples&#93;](../../../docs/framework/wcf/samples/routing-services.md)  
  
3.  Blog: [Routing Rules!](http://go.microsoft.com/fwlink/?LinkId=204956)  
  
### Routing Scenarios  
 The routing service is useful in the following scenarios:  
  
-   Clients can talk to multiple services without having to address them all directly.  
  
-   Clients can perform additional logic on a client request to determine where to route it  
  
-   Decompose the operations a client performs into multiple service implementations without refactoring the client.  
  
-   Clients and services can speak different bindings with different security settings.  
  
-   Clients can be enabled to be more robust against failure or the unavailability of services.  
  
## WCF Discovery  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Discovery is a framework technology that allows you to incorporate a discovery mechanism to your application infrastructure. You can use this to make your service discoverable, and configure your clients to search for services. Clients no longer need to be hard coded with endpoint, making your application more robust and fault tolerant. Discovery is the perfect platform to build auto-configuration capabilities into your application.  
  
 The product is built on top of the WS-Discovery standard. It’s designed to be interoperable, extensible, and generic. The product supports two modes of operation:  
  
1.  Managed: where there is an entity on the network knowledgeable about existing services, clients query it directly for information. This is analogous to Active Directory.  
  
2.  Ad-hoc: where clients use multicast messages to locate services.  
  
 Furthermore, discovery messages are network protocol agnostic; you can use them on top any protocol that supports the mode requirements. For example, discovery multicast messages can be sent over the UDP channel or any other network that supports multicast messaging.  These design points, combined with feature flexibility, allow you to adapt the discovery specifically to your solution.  
  
### Getting Started  
  
-   Documentation: [WCF Discovery](../../../docs/framework/wcf/feature-details/wcf-discovery.md)  
  
-   Samples: [Discovery (Samples)](../../../docs/framework/wcf/samples/discovery-samples.md)  
  
### Discovery Scenarios  
 A developer doesn't want to hard code endpoints, since it is unknown when my service will be available. Instead, the developer wants to choose a service at runtime. More decoupling, robustness, and auto-configuration is needed between the components in the application.  
  
## Tracking  
 Workflow tracking provides insight into the execution of a workflow instance.  The tracking events are emitted from a workflow at the workflow instance level and when activities within the workflow execute. A workflow tracking participant needs to be added to the workflow host to subscribe to tracking records. The tracking records are filtered using a tracking profile. The .Net Framework provides an ETW (Event Tracing for Windows) tracking participant, and a basic profile is installed in the machine.config file.  
  
### Getting Started  
  
1.  In [!INCLUDE[vs2010](../../../includes/vs2010-md.md)], create a WCF Workflow Service Application project. A <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> pair will be placed on your canvas to start.  
  
2.  Open the web.config and add an ETW tracking behavior with no profile.  
  
    1.  The default profile is used.  
  
    2.  Open event viewer and enable the analytic channel in the following node: **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Enable Log**.  
  
    3.  Run the workflow service.  
  
    4.  Observe the workflow tracking events in event viewer.  
  
3.  Samples: [Tracking](../../../docs/framework/windows-workflow-foundation/samples/tracking.md)  
  
4.  Conceptual documentation: [Workflow Tracking and Tracing](../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)  
  
## SQL Workflow Instance Store  
 The <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> is a SQL Server-based implementation of an instance store. An instance store stores the state of a running instance together with all data necessary to load and resume that instance. The service host instructs the instance store to save the instance state if the workflow persists, and it instructs the instance store to load the instance state when a message arrives for that instance or a delay activity expires.  
  
### Getting Started  
  
1.  In [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], create a Workflow that contains an implicit or explicit <xref:System.Activities.Statements.Persist> activity. Add the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> behavior to your workflow service host. This can be done in code or in the application configuration file.  
  
2.  Samples: [Persistence](../../../docs/framework/windows-workflow-foundation/samples/persistence.md)  
  
3.  Conceptual documentation: [SQL Workflow Instance Store](../../../docs/framework/windows-workflow-foundation/sql-workflow-instance-store.md).
