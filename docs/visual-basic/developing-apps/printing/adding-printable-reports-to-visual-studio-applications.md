---
title: "Adding Printable Reports to Visual Studio Applications"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "printing [Visual Studio], reports"
  - "reports [Visual Basic], printing in Visual Studio"
ms.assetid: 93928405-ef41-495e-bce2-9d43d5a7080a
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
---
# Adding Printable Reports to Visual Studio Applications
Visual Studio supports a variety of reporting solutions to help you add rich data reporting to your Visual Basic applications. You can create and add reports using ReportViewer controls, Crystal Reports, or SQL Server Reporting Services.  
  
> [!NOTE]
>  SQL Server Reporting Services is part of SQL Server 2005 rather than Visual Studio. Reporting Services not installed on your system unless you have installed SQL Server 2005.  
  
## Overview of Microsoft Reporting Technology in Visual Basic Applications  
 Choose from the following approaches to use a Microsoft reporting technology in your application:  
  
-   Add one or more instances of a ReportViewer control to a Visual Basic Windows application.  
  
-   Integrate SQL Server Reporting Services programmatically by making calls to the Report Server Web service.  
  
-   Use the ReportViewer control and Microsoft SQL Server 2005 Reporting Services together, using the control as a report viewer and a report server as a report processor. (Note that you must use the SQL Server 2005 version of Reporting Services if you want to use a report server and the ReportViewer control together).  
  
## Using ReportViewer Controls  
 The easiest way to embed report functionality into a Visual Basic Windows application is to add the ReportViewer control to a form in your application. The control adds report processing capabilities directly to your application and provides an integrated report designer so that you can build reports using data from any ADO.NET data object. A full-featured API provides programmatic access to the control and reports so that you can configure run-time functionality.  
  
 ReportViewer provides built-in report processing and viewing capability in a single, freely distributable data control. Choose ReportViewer controls if you require the following report functionality:  
  
-   Report processing in the client application. A processed report appears in a view area provided by the control.  
  
-   Data binding to ADO.NET data tables. You can create reports that consume <xref:System.Data.DataTable> instances supplied to the control. You can also bind directly to business objects.  
  
-   Redistributable controls that you can include in your application.  
  
-   Runtime functionality such as page navigation, printing, searching, and export formats. A ReportViewer toolbar provides support for these operations.  
  
 To use the ReportViewer control, you can drag it from the **Data** section of the Visual Studio Toolbox onto a form in your Visual Basic Windows application.  
  
### Creating Reports in Visual Studio for ReportViewer Controls  
 To build a report that runs in ReportViewer, add a **Report** template to your project. Visual Studio creates a client report definition file (.rdlc), adds the file to your project, and opens an integrated report designer in the Visual Studio workspace.  
  
 The Visual Studio Report Designer integrates with the **Data Sources** window. When you drag a field from the **Data Sources** window to the report, the Report Designer copies metadata about the data source into the report definition file. This metadata is used by the ReportViewer control to automatically generate data-binding code.  
  
 The Visual Studio Report Designer does not include report preview functionality. To preview your report, run the application and preview the report embedded in it.  
  
|To add basic report functionality to your application|  
|---|    
|1.  Drag a ReportViewer control from the **Data** tab of the **Toolbox** onto your form.<br />2.  On the **Project** menu, choose **Add New Item**. In the **Add New Item** dialog box, select the **Report** icon and click **Add**.<br />     The Report Designer opens in the development environment, and a report (.rdlc) file is added to the project.<br />3.  Drag report items from the **Toolbox** on the report layout and arrange them as you want.<br />4.  Drag fields from the **Data Sources** window to the report items in the report layout.|  
  
## Using Reporting Services in Visual Basic Applications  
 Reporting Services is a server-based reporting technology that is included with SQL Server. Reporting Services includes additional features that are not found in the ReportViewer controls. Choose Reporting Services if you require any of the following features:  
  
-   Scale-out deployment and server-side report processing that provides improved performance for complex or long-running reports and for high-volume report activity.  
  
-   Integrated data and report processing, with support for custom report controls and rich rendering output formats.  
  
-   Scheduled report processing so that you can specify exactly when reports are run.  
  
-   Subscriber-based report distribution through email or to file share locations.  
  
-   Ad hoc reporting so that business users can create reports as needed.  
  
-   Data-driven subscriptions that route customized report output to a dynamic list of recipients.  
  
-   Custom extensions for data processing, report delivery, custom authentication, and report rendering.  
  
 The report server is implemented as Web service. Your application code must include calls to the Web service to access reports and other metadata. The Web service provides complete programmatic access to a report server instance.  
  
 Because Reporting Services is a Web-based reporting technology, the default viewer shows reports that are rendered in HTML format. If you do not want to use HTML as the default report presentation format, you will have to write a custom report viewer for your application.  
  
### Creating Reports in Visual Studio for Reporting Services  
 To build reports that run on a report server, you create report definition (.rdl) files in Visual Studio through the Business Intelligence Development Studio, which is included with SQL Server 2005.  
  
> [!NOTE]
>  You must have SQL Server 2005 installed in order to use SQL Server Reporting Services and the Business Intelligence Development Studio.  
  
 The Business Intelligence Development Studio adds project templates that are specific to SQL Server components. To create reports, you can choose from the **Report Server Project** or **Report Server Project Wizard** templates. You can specify data source connections and queries to a variety of data source types, including SQL Server, Oracle, Analysis Services, XML, and SQL Server Integration Services. A **Data** tab, **Layout** tab, and **Preview** tab allow you to define data, create a report layout, and preview the report all in the same workspace.  
  
 Report definitions that you build for the control or the report server can be reused in either technology.  
  
|To create a report that runs on a report server|  
|---|    
|1.  On the **File** menu, choose **New**.<br />     The **New Project** dialog box opens.<br />2.  In the **Project types** pane, click **Business Intelligence Projects**.<br />3.  In the Templates pane, select **Report Server Project** or **Report Server Project Wizard**.|  
  
## Using ReportViewer Controls and SQL Server Reporting Services Together  
 The ReportViewer controls and SQL Server 2005 Reporting Services can be used together in the same application.  
  
-   The ReportViewer control provides a viewer that is used to display reports in your application.  
  
-   Reporting Services provides the reports and performs all processing on a remote server.  
  
 The ReportViewer control can be configured to show reports that are stored and processed on a remote Reporting Services report server. This type of configuration is called *remote processing mode*. In remote processing mode, the control requests a report that is stored on a remote report server. The report server performs all report processing, data processing, and report rendering. A finished, rendered report is returned to the control and displayed in the view area.  
  
 Reports that run on a report server support additional export formats, have a different report parameterization implementation, use the data source types that are supported by the report server, and are accessed through the role-based authorization model on the report server.  
  
 To use remote processing mode, specify the URL and path to a server report when configuring the ReportViewer control.
