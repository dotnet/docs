---
title: "Regular Expression Activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b8f24694-49db-4339-92ec-014e3d4ae63b
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Regular Expression Activities
This sample demonstrates how to create a set of activities that expose the regular expression functionality of the <xref:System.Text.RegularExpressions> namespace. These custom activities can be used within a workflow application. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] regular expressions, see [N:System.Text.RegularExpressions](http://go.microsoft.com/fwlink/?LinkId=150434) Namespace.  
  
 The following table details the custom activities in this sample.  
  
|Activity|Description|  
|--------------|-----------------|  
|IsMatch|Specifies whether the regular expression found a match in the input string.|  
|Matches|Searches an input string for all occurrences of a regular expression and returns all the successful matches.|  
|Replace|Within a specified input string, replaces strings that match a regular expression pattern with a specified replacement string.|  
  
## IsMatch  
 The `IsMatch` custom activity returns `true` if the `Input` string property finds a match in the regular expression specified in the `Pattern` property. The activity derives from <xref:System.Activities.CodeActivity%601> and within the <xref:System.Activities.CodeActivity%601.Execute%2A> method calls the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A> method.  
  
 The following table describes the properties and return value for the `IsMatch` custom activity.  
  
|Property or Return Value|Description|  
|------------------------------|-----------------|  
|Pattern (required)|The regular expression to search with.|  
|Input (required)|The input string to search.|  
|RegexOptions|Bitwise OR combination of [RegexOptions](http://go.microsoft.com/fwlink/?LinkId=150446) enumeration values.|  
|Return value|`true` if the input finds a match in the provided pattern; otherwise `false`.|  
  
 The following code example demonstrates how to use the `IsMatch` custom activity.  
  
```  
new IsMatch  
{  
    Pattern = new InArgument<string>( @"^-?\d+(\.\d{2})?$"),  
    Input = "20.00",  
};  
```  
  
## Matches  
 The `Matches` custom activity searches an input string for all occurrences of a regular expression and returns all the successful matches. The activity derives from <xref:System.Activities.CodeActivity%601> and within the <xref:System.Activities.CodeActivity%601.Execute%2A> method calls the <xref:System.Text.RegularExpressions.Regex.Matches%2A> method.  
  
 The following table describes the properties and return value for the `IsMatch` custom activity.  
  
|Property or Return Value|Description|  
|------------------------------|-----------------|  
|Pattern (required)|The regular expression to search with.|  
|Input (required)|The input string to search.|  
|RegexOptions|Bitwise OR combination of [RegexOptions](http://go.microsoft.com/fwlink/?LinkId=150446) enumeration values.|  
|Return Value|A <xref:System.Text.RegularExpressions.MatchCollection> that contains the collection of successful matches.|  
  
 The following code example demonstrates how to use the `Matches` custom activity.  
  
```  
new Matches  
{  
    Pattern = @"\b(?<word>\w+)\s+(\k<word>)\b",  
    Input = "The quick brown fox  fox jumped over over the lazy dog dog.",  
};  
```  
  
## Replace  
 The `Replace` custom activity searches an input string and replaces all strings that match a specified regular expression with a string. The activity derives from <xref:System.Activities.CodeActivity%601> and within the <xref:System.Activities.CodeActivity%601.Execute%2A> method calls the <xref:System.Text.RegularExpressions.Regex.Replace%2A> method.  
  
 The following table describes the properties and return value for the `Replace` custom activity.  
  
|Property or Return Value|Description|  
|------------------------------|-----------------|  
|Pattern (required)|The regular expression to search with.|  
|Input (required)|The input string to search.|  
|Replacement|The replacement string.<br /><br /> If a `Replacement` is specified, then the `MatchEvaluator` property is ignored. Either the `Replacement` or `MatchEvaluator` property must be set.|  
|MatchEvaluator|A custom method that examines each match and returns either the original matched string or a replacement string.<br /><br /> If a `Replacement` is specified, then the `MatchEvaluator` property is ignored. Either the `Replacement` or `MatchEvaluator` property must be set.|  
|RegexOptions|Bitwise OR combination of [RegexOptions](http://go.microsoft.com/fwlink/?LinkId=150446) enumeration values.|  
|Return Value|A <xref:System.Text.RegularExpressions.MatchCollection> that contains the collection of successful matches.|  
  
 The following code example demonstrates how to use the `Replace` custom activity.  
  
```  
// Using the replacement string.  
new Replace  
{  
    Pattern = @"\bWorld\b",  
    Input = "Hello World! This is a wonderful World",  
    Replacement = "Universe"  
};  
  
// Using a match evaluator.  
new Replace  
{  
    Pattern = new InArgument<string>(pattern),  
    Input = new InArgument<string>(input),  
    MatchEvaluator = new MatchEvaluator(CapText)                  
};  
```  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the RegexActivities.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\Regex`