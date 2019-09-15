---
title: "UriTemplate Table Sample"
ms.date: "03/30/2017"
ms.assetid: 5dd1d38f-1989-4c64-820d-821f5a02216a
---
# UriTemplate Table Sample
The <xref:System.UriTemplateTable> class provides a dictionary-like associative table structure for working with a set of `UriTemplate` instances. Specific Uniform Resource Identifiers (URIs) can be matched efficiently against all templates in the table, and data associated with the matched template can be retrieved.  
  
 This sample demonstrates the following key concepts related to the `UriTemplateTable` class:  
  
- Syntax for instantiating a `UriTemplateTable`.  
  
- Populating a `UriTemplateTable` with a set of key/value pairs.  
  
- Matching a candidate URI against the table using <xref:System.UriTemplateTable.MatchSingle%2A>.  
  
### To set up, build, and run the sample  
  
1. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
2. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
> [!IMPORTANT]
> The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
> `<InstallDrive>:\WF_WCF_Samples`  
>   
> If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](https://go.microsoft.com/fwlink/?LinkId=150780) to download all Windows Communication Foundation (WCF) and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
> `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Web\UriTemplateTable`  
  
## See also

- [UriTemplate Table Dispatcher](../../../../docs/framework/wcf/samples/uritemplate-table-dispatcher-sample.md)
- [UriTemplate](../../../../docs/framework/wcf/samples/uritemplate-sample.md)
