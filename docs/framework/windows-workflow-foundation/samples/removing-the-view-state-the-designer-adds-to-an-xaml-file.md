---
title: "Removing the View State the Designer Adds to an XAML File"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a801ce22-8699-483c-a392-7bb3834aae4f
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Removing the View State the Designer Adds to an XAML File
This sample demonstrates how to create a class that derives from <xref:System.Windows.Markup.XamlWriter> and removes view state from a XAML file. [!INCLUDE[wfd1](../../../../includes/wfd1-md.md)] writes information into the XAML document, which is known as view state. View state refers to the information that is required at design time, such as layout positioning, that is not required at runtime. [!INCLUDE[wfd2](../../../../includes/wfd2-md.md)] inserts this information into the XAML document as it is edited. [!INCLUDE[wfd2](../../../../includes/wfd2-md.md)] writes the view state into the XAML file with the `mc:Ignorable` attribute, so this information is not loaded when the runtime loads the XAML file. This sample demonstrates how to create a class that removes that view state information while processing XAML nodes.  
  
## Discussion  
 This sample demonstrates how to create a custom writer.  
  
 To build a custom XAML writer, create a class that inherits from <xref:System.Windows.Markup.XamlWriter>. As XAML writers are often nested, it is typical to keep track of an "inner" XAML writer. These "inner’ writers can be thought of as the reference to the remaining stack of XAML writers, allowing you to have multiple entry points to do work and then delegate processing to the remainder of the stack.  
  
 In this sample, there are a few items of interest. One is the check to see whether the item being written is from a designer namespace. Note that this also strips out the use of other types from the designer namespace in a workflow.  
  
```csharp
static Boolean IsDesignerAttachedProperty(XamlMember xamlMember)  
{  
    return xamlMember.IsAttachable &&  
        xamlMember.PreferredXamlNamespace.Equals(c_sapNamespaceURI, StringComparison.OrdinalIgnoreCase);  
}  
  
const String c_sapNamespaceURI = "http://schemas.microsoft.com/netfx/2009/xaml/activities/presentation";  

// The next item of interest is the constructor, where the utilization of the inner XAML writer is seen.  
public ViewStateCleaningWriter(XamlWriter innerWriter)  
{  
    this.InnerWriter = innerWriter;  
    this.MemberStack = new Stack<XamlMember>();  
}  
  
XamlWriter InnerWriter {get; set; }  
Stack<XamlMember> MemberStack {get; set; }  
```  
  
 This also creates a stack of XAML members that are used while traversing the node stream. The remaining work of this sample is largely contained in the <!--zz  <xref:System.Windows.Markup.XamlWriter.WriteStartMember%2A>--> `System.Windows.Markup.XamlWriter.WriteStartMember` method.  
  
```csharp
public override void WriteStartMember(XamlMember xamlMember)  
{  
    MemberStack.Push(xamlMember);

    if (IsDesignerAttachedProperty(xamlMember))  
    {  
        m_attachedPropertyDepth++;  
    }  
  
    if (m_attachedPropertyDepth > 0)  
    {  
        return;  
    }  
  
    InnerWriter.WriteStartMember(xamlMember);  
}  
```  
  
 Subsequent methods then check to see whether they are still contained in a view state container, and if so, return, and do not pass the node down the writer stack.  
  
```csharp
public override void WriteValue(Object value)  
{  
    if (m_attachedPropertyDepth > 0)  
    {  
        return;  
    }  
  
    InnerWriter.WriteValue(value);  
}  
```  
  
 To use a custom XAML writer, you must chain it together in a stack of XAML writers. The following code shows how this can be used.  
  
```csharp 
XmlWriterSettings writerSettings = new XmlWriterSettings {  Indent = true };  
XmlWriter xmlWriter = XmlWriter.Create(File.OpenWrite(args[1]), writerSettings);  
XamlXmlWriter xamlWriter = new XamlXmlWriter(xmlWriter, new XamlSchemaContext());  
XamlServices.Save(new ViewStateCleaningWriter(ActivityXamlServices.CreateBuilderWriter(xamlWriter)), ab);  
```  
  
#### To use this sample  
  
1. Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the ViewStateCleaningWriter.sln solution file.  
  
2. Open a command prompt and navigate to the directory where the ViewStageCleaningWriter.exe is built.  
  
3. Run ViewStateCleaningWriter.exe on the Workflow1.xaml file.  

   The syntax for the executable is shown in the following example.  
  
   ```console
   ViewStateCleaningWriter.exe [input file] [output file]
   ```
   
   This outputs a XAML file to \[outfile], which has all its view state information removed.  
  
> [!NOTE]
> For a <xref:System.Activities.Statements.Sequence> workflow, a number of virtualization hints are removed. This causes the designer to recalculate layout the next time it is loaded. When you use this sample for a <xref:System.Activities.Statements.Flowchart>, all positioning and line routing information are removed and on subsequent loading into the designer, all activities are stacked on the left side of the screen.  
  
#### To create a sample XAML file for use with this sample  
  
1. Open [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2. Create a new Workflow Console Application.  
  
3. Drag and drop a few activities onto the canvas  
  
4. Save the workflow XAML file.  
  
5. Inspect the XAML file to see the view state attached properties.  
  
> [!IMPORTANT]
> The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
> `<InstallDrive>:\WF_WCF_Samples`  
>   
> If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
> `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Designer\ViewStateCleaningWriter`
