---
title: "Corporate Purchase Process"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a5e57336-4290-41ea-936d-435593d97055
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Corporate Purchase Process
This sample shows how to create a very basic Request for Proposals (RFP) based purchase process with automatic best proposal selection. It combines <xref:System.Activities.Statements.Parallel>, <xref:System.Activities.Statements.ParallelForEach%601>, and <xref:System.Activities.Statements.ForEach%601> and a custom activity to create a workflow that represents the process.  
  
 This sample contains an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] client application that allows interacting with the process as different participants (as the original requester or a particular vendor).  
  
## Requirements  
  
-   [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)].  
  
-   [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)].  
  
## Demonstrates  
  
-   Custom activities.  
  
-   Composition of activities.  
  
-   Bookmarks.  
  
-   Persistence.  
  
-   Schematized persistence.  
  
-   Tracing.  
  
-   Tracking.  
  
-   Hosting [!INCLUDE[wf1](../../../../includes/wf1-md.md)] in different clients ([!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web applications and WinForms applications).  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Application\PurchaseProcess`  
  
## Description of the Process  
 This sample shows an implementation of a [!INCLUDE[wf](../../../../includes/wf-md.md)] program to gather proposals from vendors for a generic company.  
  
1.  An employee of Company X creates a Request for Proposal (RFP).  
  
    1.  The employee types in the RFP title and description.  
  
    2.  The employee selects the vendors that he wants to invite to submit proposals.  
  
2.  The employee submits the proposal.  
  
    1.  An instance of the workflow is created.  
  
    2.  The workflow is waiting for all vendors to submit their proposals.  
  
3.  After all proposals are received, the workflow iterates through all the received proposals and selects the best one.  
  
    1.  Each vendor has a reputation (this sample stores the reputation list in VendorRepository.cs).  
  
    2.  The total value of the proposal is determined by (The value typed in by the vendor) * (The vendor's recorded reputation) / 100.  
  
4.  The original requester can see all the submitted proposals. The best proposal is presented in a special section in the report.  
  
## Process Definition  
 The core logic of the sample uses a <xref:System.Activities.Statements.ParallelForEach%601> activity that waits for the offers from each vendor (using a custom activity that creates a bookmark), and registers the vendor proposal as an RFP (using an <xref:System.Activities.Statements.InvokeMethod> activity).  
  
 The sample then iterates through all of the received proposals stored in the `RfpRepository`, calculating the adjusted value (using an <xref:System.Activities.Statements.Assign> activity and <xref:System.Activities.Expressions> activities), and if the adjusted value is better than the previous best offer, assigns the new value as the best offer (using <xref:System.Activities.Statements.If> and <xref:System.Activities.Statements.Assign> activities).  
  
## Projects in this Sample  
 This sample contains the following projects.  
  
|Project|Description|  
|-------------|-----------------|  
|Common|The entity objects used within the process (Request for Proposal, Vendor, and Vendor Proposal).|  
|WfDefinition|The definition of the process (as a [!INCLUDE[wf1](../../../../includes/wf1-md.md)] program) and host (`PurchaseProcessHost`) used by client applications for creating and using instances of the purchase process workflow.|  
|WebClient|An [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] client application that allows the users to create and participate in instances of the purchase process. It uses a custom-created host to interact with the workflow engine.|  
|WinFormsClient|A Windows Forms client application that allows the users to create and participate in instances of the purchase process. It uses a custom-created host to interact with the workflow engine.|  
  
### WfDefinition  
 The following table contains a description of the most important files in the WfDefinition project.  
  
|File|Description|  
|----------|-----------------|  
|IPurchaseProcessHost.cs|Interface for the host of the workflow.|  
|PurchaseProcessHost.cs|Implementation of a host for the workflow. The host abstracts the details of the workflow runtime and is used in all the client applications to load, run, and interact with `PurchaseProcess` workflow instances.|  
|PurchaseProcessWorkflow.cs|An activity that contains the definition of the Purchase Process workflow (derives from <xref:System.Activities.Activity>).<br /><br /> Activities that derive from <xref:System.Activities.Activity> compose functionality by assembling existing custom activities and activities from the [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] activity library. Assembling these activities is the most basic way to create custom functionality.|  
|WaitForVendorProposal.cs|This custom activity derives from <xref:System.Activities.NativeActivity> and creates a named bookmark that must be resumed later by a vendor when submitting the proposal.<br /><br /> Activities that derive from <xref:System.Activities.NativeActivity>, like those that derive from <xref:System.Activities.CodeActivity>, create imperative functionality by overriding <xref:System.Activities.NativeActivity.Execute%2A>, but also have access to all of the functionality of the workflow runtime through the <xref:System.Activities.ActivityContext> that gets passed into the `Execute` method. This context has support for scheduling and canceling child activities, setting up no-persist zones (execution blocks during which the runtime does not persist the workflow’s data, such as within atomic transactions), and <xref:System.Activities.Bookmark> objects (handles for resuming paused workflows).|  
|TrackingParticipant.cs|A <xref:System.Activities.Tracking.TrackingParticipant> that receives all tracking events and saves them to a text file.<br /><br /> Tracking participants are added to workflow instance as Extensions.|  
|XmlWorkflowInstanceStore.cs|A custom <xref:System.Runtime.DurableInstancing.InstanceStore> that saves workflow applications to XML files.|  
|XmlPersistenceParticipant.cs|A custom <xref:System.Activities.Persistence.PersistenceParticipant> that saves an instance of request for proposal to an XML file.|  
|AsyncResult.cs / CompletedAsyncResult.cs|Helper classes for implementing the asynchronous pattern in the persistence components.|  
  
### Common  
 The following table contains a description of the most important classes in the Common project.  
  
|Class|Description|  
|-----------|-----------------|  
|Vendor|A vendor that submits proposals in a Request for Proposals.|  
|RequestForProposal|A request for proposals (RFP) is an invitation for vendors to submit proposals on a specific commodity or service.|  
|VendorProposal|A proposal submitted by a vendor to a concrete RFP.|  
|VendorRepository|The repository of Vendors. This implementation contains an in-memory collection of instances of Vendor and methods for exposing those instances.|  
|RfpRepository|The repository of Requests for Proposals. This implementation contains uses Linq to XML to query the XML file of Requests for Proposal generated by the schematized persistence. This class implements [System.Runtime.Persistence.IDataViewMapper](https://msdn.microsoft.com/library/system.runtime.persistence.idataviewmapper(v=vs.110).aspx).|  
|IOHelper|This class handles all I/O-related issues (folders, paths, and so on.)|  
  
### Web Client  
 The following table contains a description of the most important Web pages in the Web Client project.  
  
|File|Description|  
|-|-|  
|CreateRfp.aspx|Creates and submits a new Request for Proposals.|  
|Default.aspx|Shows all active and completed Requests for Proposals.|  
|GetVendorProposal.aspx|Gets a proposal from a vendor in a concrete Request for Proposals. This page is used only by vendors.|  
|ShowRfp.aspx|Show all the information about a Request for Proposals (received proposals, dates, values, and other information). This page is only used by the creator of the Request for Proposal.|  
  
### WinForms Client  
 The following table contains a description of the most important forms in the Win Forms project.  
  
|Form|Description|  
|-|-|  
|NewRfp|Creates and submits a new Request for Proposals.|  
|ShowProposals|Show all active and finished Requests for Proposals. **Note:**  You may need to click the **Refresh** button in the UI to see changes in that screen after you create or modify a Request for Proposal.|  
|SubmitProposal|Get a proposal from a vendor in a concrete Request for Proposals. This window is used only by vendors.|  
|ViewRfp|Show all the information about a Request for Proposals (received proposals, dates, values, and other information). This window  is only used by the creator of the Request for Proposals.|  
  
### Persistence Files  
 The following table shows the files generated by the persistence provider (`XmlPersistenceProvider`) are located in the path of the current system's temporary folder (using <xref:System.IO.Path.GetTempPath%2A>). The tracing file is created in the current execution path.  
  
|File Name|Description|Path|  
|-|-|-|  
|rfps.xml|The XML file with all the active and finished Requests for Proposals.|<xref:System.IO.Path.GetTempPath%2A>|  
|[instanceid]|This file contains all the information about a workflow instance.<br /><br /> This file is generated by the schematized persistence implementation (PersistenceParticipant in XmlPersistenceProvider).|<xref:System.IO.Path.GetTempPath%2A>|  
|[instanceId].tracking|A text file with all the events that occurred within a concrete instance.<br /><br /> This file is generated by TrackingParticipant.|<xref:System.IO.Path.GetTempPath%2A>|  
|PurchaseProcess.Tracing.TraceLog.txt|The tracing file generated by the workflow based on the configuration parameters in the App.config or Web.config files.|Current execution path|  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the PurchaseProcess.sln solution file.  
  
2.  To execute the Web Client project, open **Solution Explorer** and right-click the **Web Client** project. Select **Set as Startup Project**.  
  
3.  To execute the WinForms Client project, open **Solution Explorer** and right-click the **WinForms Client** project. Select **Set as Startup Project**.  
  
4.  To build the solution, press CTRL+SHIFT+B.  
  
5.  To run the solution, press CTRL+F5.  
  
### Web Client Options  
  
-   **Create a new RFP**: Creates a new Request for Proposals (RFP) and starts a Purchase Process workflow.  
  
-   **Refresh**: Refreshes the list of Active and Finished RFPs in the main window.  
  
-   **View**: Shows the content of an existing RFP. Vendors can submit their proposals (if invited or the RFP is not finished).  
  
-   View As: The user can access the RFP using different identities by selecting the desired participant in the **View as** combo box in the active RFPs grid.  
  
### WinForms Client Options  
  
-   **Create RFP**: Creates a new Request for Proposals (RFP) and starts a Purchase Process workflow.  
  
-   **Refresh**: Refreshes the list of Active and Finished RFPs in the main window.  
  
-   **View RFP**: Shows the content of an existing RFP. Vendors can submit their proposals (if invited or the RFP is not finished)  
  
-   **Connect As**: The user can access the RFP using different identities by selecting the desired participant in the **View as** combo box in the active RFPs grid.