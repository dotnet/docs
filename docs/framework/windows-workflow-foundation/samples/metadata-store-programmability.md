---
title: "Metadata Store Programmability"
ms.date: "03/30/2017"
ms.assetid: 5b613661-f3f9-4e07-8e88-28c9ea2fd8f8
---
# Metadata Store Programmability
The metadata store is a [!INCLUDE[wfd1](../../../../includes/wfd1-md.md)] feature that allows for the association of arbitrary metadata, in the form of CLR attributes, to types at runtime. This allows for a loose coupling between the run-time components and their design-time counterparts, as well as the ability to change the design-time components without affecting the runtime. The sample shows how to program against the metadata store by applying attributes to a run-time type, the source for which we have no control over. The terminology typically used is that a hosting application registers the metadata for a set of types.  
  
 Within the output, you may notice an additional, unexpected attribute, <xref:System.Runtime.InteropServices.GuidAttribute>. This is added when using the Metadata API and has no impact on the running of the sample.  
  
 This sample demonstrates:  
  
## Demonstrates  
  
-   Attribute injection using the metadata store API.  
  
-   Using a callback mechanism to defer metadata registration.  
  
## To set up, build, and run the sample
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the ProgrammingMetadataStore.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](https://go.microsoft.com/fwlink/?LinkId=150780) to download all Windows Communication Foundation (WCF) and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\CustomActivities\CustomActivityDesigners\MetadataStore`