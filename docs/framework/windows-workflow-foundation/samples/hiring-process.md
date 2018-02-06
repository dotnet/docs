---
title: "Hiring Process"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d5fcacbb-c884-4b37-a5d6-02b1b8eec7b4
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hiring Process
This sample demonstrates how to implement a business process using messaging activities and two workflows hosted as workflow services. These workflows are part of the IT infrastructure of a fictional company called Contoso, Inc.  
  
 The `HiringRequest` workflow process (implemented as a <xref:System.Activities.Statements.Flowchart>) asks for authorization from several managers in the organization. To achieve this goal, the workflow uses other existing services in the organization (in our case, an inbox service and an organizational data service implemented as plain [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services).  
  
 The `ResumeRequest` workflow (implemented as a <xref:System.Activities.Statements.Sequence>) publishes a job posting in Contoso's external careers Web site and manages the acquisition of resumes. A job posting is available in the external Web site for a fixed period of time (until a timeout expires) or until an employee from Contoso decides to remove it.  
  
 This sample demonstrates the following features of [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)]:  
  
-   <xref:System.Activities.Statements.Flowchart> and <xref:System.Activities.Statements.Sequence> workflows for modeling business processes.  
  
-   Workflow Services.  
  
-   Messaging Activities.  
  
-   Content-based correlation.  
  
-   Custom activities (declarative and code-based).  
  
-   System-provided SQL server persistence.  
  
-   Custom <xref:System.Activities.Persistence.PersistenceParticipant>.  
  
-   Custom tracking.  
  
-   Event Tracking for Windows (ETW) Tracking.  
  
-   Composition of activities.  
  
-   <xref:System.Activities.Statements.Parallel> activities.  
  
-   <xref:System.Activities.Statements.CancellationScope> activity.  
  
-   Durable timers (<xref:System.Activities.Statements.Delay> activity).  
  
-   Transactions.  
  
-   More than one workflow in the same solution.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Application\HiringProcess`  
  
## Description of the Process  
 Contoso, Inc. wants to have close control of the headcount in each of its departments. Therefore, anytime any employee wants to start a new hiring process, they need to go through a hiring request process approval before the recruiting can actually happen. This process is called hiring process request (defined in the HiringRequestService project) and consists of the following steps:  
  
1.  An employee (the requester) starts the hiring process request.  
  
2.  The requester’s manager must approve the request:  
  
    1.  The manager can reject the request.  
  
    2.  The manager can return the request to the requester for additional information:  
  
        1.  The requester reviews and sends the request back to the manager.  
  
    3.  The manager can approve.  
  
3.  After the requester’s manager approves, the department owner must approve the request:  
  
    1.  The department owner can reject.  
  
    2.  The department owner can approve.  
  
4.  After the department owner approves, the process requires the approval of 2 HR managers or the CEO:  
  
    1.  The process can transition to the accepted or rejected state.  
  
    2.  If the process is Accepted, a new instance of the `ResumeRequest` workflow is started (`ResumeRequest` is linked to HiringRequest.csproj through a service reference.)  
  
 Once the managers approve the hiring of a new employee, HR must find the appropriate candidate. This process is performed by the second workflow (`ResumeRequest`, defined in ResumeRequestService.csproj). This workflow defines the process for submitting a job posting with a career opportunity to Contoso's external Careers Web site, receives resumes from applicants, and monitors the state of the job posting. Positions are available for a fixed time period (until a time expires) or until an employee from Contoso decides to remove it. The `ResumeRequest` workflow consists of the following steps:  
  
1.  An employee from Contoso types in the information about the position and a time-out duration. Once the employee types in this information, the position is posted in the Careers Web site.  
  
2.  Once the information is published, interested parties can submit their resumes. When a resume is submitted, it is stored in a record linked to the job opening.  
  
3.  Applicants can submit resumes until the time-out expires or someone from Contoso HR department explicitly decides to remove the posting by stopping the process.  
  
## Projects in the sample  
 The following table shows the projects in the sample solution.  
  
|Project|Description|  
|-------------|-----------------|  
|ContosoHR|Contains data contracts, business objects and repository classes.|  
|HiringRequestService|Contains the definition of the Hiring Request Process workflow.<br /><br /> This project is implemented as a console application that self-hosts the workflow (xaml file) as a service.|  
|ResumeRequestService|A workflow service that collects resumes from candidates until a time-out expires or someone decides that the process has to be stopped.<br /><br /> This project is implemented as a declarative workflow service (xamlx).|  
|OrgService|A service that exposes organizational information (Employees, Positions, PositionTypes, and Departments). You can think of this service as the Company Organization module of an Enterprise Resource Plan (ERP).<br /><br /> This project is implemented as a console application that exposes a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service.|  
|InboxService|An inbox that contains actionable tasks for employees.<br /><br /> This project is implemented as a console application that exposes a WCF service.|  
|InternalClient|A Web application for interacting with the process. Users can start, participate, and view their HiringProcess workflows. Using this application, they can also start and monitor ResumeRequest processes.<br /><br /> This site is implemented to be internal to Contoso's intranet. This project is implemented as an ASP.NET Web site.|  
|CareersWebSite|An external Web site that exposes the open positions in Contoso. Any potential candidate can navigate to this site and submit a resume.|  
  
## Feature summary  
 The following table describes how each feature is used in this sample.  
  
|Feature|Description|Project|  
|-------------|-----------------|-------------|  
|Flowchart|The business process is represented as a flowchart . This flowchart description represents the process in the same way in which a business would have drawn it in a whiteboard.|HiringRequestService|  
|Workflow services|The Flowchart with the process definition is hosted in a service (in this example, the service is hosted in a console application).|HiringRequestService|  
|Messaging activities|The flowchart uses messaging activities in two ways:<br /><br /> -   To get information from the user (to receive the decisions and related information in each approval step).<br />-   To interact with other existing services (InboxService and OrgDataService, used through service references).|HiringRequestService|  
|Content based correlation|Approval messages correlate on the ID property of the hiring request:<br /><br /> -   When a process is started, the correlation handle is initialized with the ID of the request.<br />-   Incoming approval messages correlate on their ID (the first parameter of each approval message is the ID of the request).|HiringRequestService / ResumeRequestService|  
|Custom activities (declarative and code based)|There are several custom activities in this sample:<br /><br /> -   `SaveActionTracking`: This activity emits a custom <xref:System.Activities.Tracking.TrackingRecord> (using <xref:System.Activities.NativeActivityContext.Track%2A>). This activity has been authored using imperative code extending <xref:System.Activities.NativeActivity>.<br />-   `GetEmployeesByPositionTypes`: This activity receives a list of position type IDs and returns a list of people that have that position in Contoso. This activity has been authored declaratively (using the activity designer).<br />-   `SaveHiringRequestInfo`: This activity saves the information of a `HiringRequest` (using `HiringRequestRepository.Save`). This activity has been authored using imperative code extending <xref:System.Activities.CodeActivity>.|HiringRequestService|  
|System-provided SQL Server Persistence|The <xref:System.ServiceModel.Activities.WorkflowServiceHost> instance that hosts the Flowchart process definition is configured to use the system-provided SQL Server persistence.|HiringRequestService / ResumeRequestService|  
|Custom Tracking|The sample includes a custom tracking participant that saves the history of a `HiringRequestProcess` (this records what action has been done, by whom, and when). The source code is in the Tracking folder of HiringRequestService.|HiringRequestService|  
|ETW Tracking|System-provided ETW Tracking is configured in the App.config file in the HiringRequestService service.|HiringRequestService|  
|Composition of Activities|The process definition uses the free composition of <xref:System.Activities.Activity>. The Flowchart contains several Sequence and Parallel activities that at the same time contain other activities (and so on).|HiringRequestService|  
|Parallel Activities|-   <xref:System.Activities.Statements.ParallelForEach%601> is used to register in the Inbox of the CEO and HR Managers in parallel (Waiting for two HR Managers' Approval step).<br />-   <xref:System.Activities.Statements.Parallel> is used to do some clean-up tasks in the Completed and Rejected steps|HiringRequestService|  
|Model Cancellation|The Flowchart uses <xref:System.Activities.Statements.CancellationScope> to create cancellation behavior (in this case it does some clean-up.)|HiringRequestService|  
|Customer Persistence Participant|`HiringRequestPersistenceParticipant` saves data from a workflow variable to a table stored in the Contoso HR database.|HiringRequestService|  
|Workflow Services|`ResumeRequestService` is implemented using workflow services. Workflow definition and service information is contained in ResumeRequestService.xamlx. The service is configured to use persistence and tracking.|ResumeRequestService|  
|Durable Timers|`ResumeRequestService` uses durable timers to define the duration of a Job Posting (once a time-out expires, the Job Posting is closed).|ResumeRequestService|  
|Transactions|<xref:System.Activities.Statements.TransactionScope> is used to ensure consistency of data within the execution of several activities (when a new resume is received).|ResumeRequestService|  
|Transactions|The custom persistence participant (`HiringRequestPersistenceParticipant`) and custom tracking participant (`HistoryFileTrackingParticipant`) use the same transaction.|HiringRequestService|  
|Using [!INCLUDE[wf1](../../../../includes/wf1-md.md)] in [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] applications.|Workflows are accessed from two [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] applications.|InternalClient / CareersWebSite|  
  
## Data Storage  
 Data is stored in a SQL Server database called `ContosoHR` (the script for creating this database is located in the `DbSetup` folder). Workflow instances are stored in a SQL Server database called `InstanceStore` (the scripts for creating the instance store are part of the [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)] distribution).  
  
 Both databases are created by running Setup.cmd script from a  [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] command prompt.  
  
## Running the sample  
  
#### To create the databases  
  
1.  Open a [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] command prompt.  
  
2.  Navigate to the sample folder.  
  
3.  Run Setup.cmd.  
  
4.  Verify that the two databases `ContosoHR` and `InstanceStore` were created in SQL Express.  
  
#### To set up the solution for execution  
  
1.  Run [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] as an administrator. Open HiringRequest.sln.  
  
2.  Right-click the solution in **Solution Explorer** and select **Properties**.  
  
3.  Select the option **Multiple Startup Projects** and set the **CareersWebSite**, **InternalClient**, **HiringRequestService**, and **ResumeRequestService** to **Start**. Leave **ContosoHR**, **InboxService**, and **OrgService** as None.  
  
4.  Build the solution by pressing CTRL+SHIFT+B. Verify that the build succeeded.  
  
#### To run the solution  
  
1.  After the solution builds, press CTRL+F5 to run without debugging. Verify that all services have started.  
  
2.  Right click **InternalClient** in the solution and then select **View in Browser**. The default page for `InternalClient` is displayed. Ensure that services are running, and click the link.  
  
3.  The **HiringRequest** module is displayed. You can follow the scenario detailed here.  
  
4.  Once the `HiringRequest` is complete, you can start the `ResumeRequest`. You can follow the scenario detailed here.  
  
5.  When the `ResumeRequest` is posted, it is available in the public Web site (Contoso Careers Web Site). To see the Job Posting (and apply for the position), navigate to the Careers Web Site.  
  
6.  Right-click **CareersWebSite** in the solution and select **View in Browser**.  
  
7.  Navigate back to the `InternalClient` by right-clicking **InternalClient** in the solution and selecting **View in Browser**.  
  
8.  Go to the **JobPostings** section by clicking the **Job Postings** link in the inbox top menu. You can follow the scenario detailed here.  
  
## Scenarios  
  
### Hiring request  
  
1.  Michael Alexander (Software Engineer) wants to request a new position for hiring a Software Engineer in Test (SDET) in the Engineering department who has at least 3 years of experience in C#.  
  
2.  After being created, the request appears in Michael’s inbox (click **Refresh** if you do not see the request) awaiting Peter Brehm’s approval, who is Michael’s manager.  
  
3.  Peter wants to act on Michael’s request. He thinks the position demands 5 years of C# experience instead of 3, so he sends his comments back for review.  
  
4.  Michael sees a message in his inbox from his manager and wants to act. Michael sees the history of the position request and agrees with Peter. Michael modifies the description to require 5 years of C# experience and accepts the modification.  
  
5.  Peter acts on Michael’s modified request and accepts it. The request now must be approved by the Director of Engineering, Tsvi Reiter.  
  
6.  Tsvi Reiter wants to expedite the request, so he puts in a comment to say that the request is urgent and accepts it.  
  
7.  The request now has to be approved by two HR managers or the CEO. The CEO, Brian Richard Goldstein, sees the urgent request by Tsvi. He acts on the request by accepting it, thus bypassing the approval by two HR managers.  
  
8.  The request is removed from Michael’s inbox and the process of hiring an SDET has now begun.  
  
### Start Resume Request  
  
1.  Now, the job position is waiting to be posted to an external Web site where people can apply (you can see it clicking the **Job Postings** link). Currently, the job position is sitting with an HR representative who is responsible for finalizing the job position and posting it.  
  
2.  HR wants to edit this job position (by clicking the **Edit** link) by setting a time-out of 60 minutes (in real life, this could be days or weeks). The time-out allows the job position to be taken off the external Web site according to the time specified.  
  
3.  After saving the edited job position, it appears in the **Receiving Resumes** tab (refresh the Web page to see the new job position).  
  
### Collecting Resumes  
  
1.  The job position should appear on the external Web site. As a person interested in applying for the job, you may apply for this position and submit your resume.  
  
2.  If you go back to the Job Postings List service, you can "view resumes" that have been collected so far.  
  
3.  HR can also stop collecting resumes (for example, once the right candidate has been identified).  
  
## Troubleshooting  
  
1.  Ensure that you are running [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] with administrator privileges.  
  
2.  If the solution fails to build, verify the following:  
  
    -   The reference to `ContosoHR` is not missing from the `InternalClient` or `CareersWebSite` projects.  
  
3.  If the solution fails to execute, verify the following:  
  
    1.  All services are running.  
  
    2.  The service references are updated.  
  
        1.  Open the App_WebReferences folder  
  
        2.  Right-click **Contoso** and select **Update Web/Service References**.  
  
        3.  Rebuild the solution by pressing CTRL+SHIFT+B in [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)].  
  
## Uninstalling  
  
1.  Delete the SQL Server instance store by running Cleanup.bat, located in DbSetup folder.  
  
2.  Delete the source code form your hard drive.