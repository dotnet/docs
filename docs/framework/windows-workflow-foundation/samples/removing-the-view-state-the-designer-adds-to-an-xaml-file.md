---
description: "Learn more about: Removing the view state the designer adds to an XAML file"
title: "Removing the view state the designer adds to an XAML file - WF"
ms.date: "03/30/2017"
ms.assetid: a801ce22-8699-483c-a392-7bb3834aae4f
---
# Removing the view state the designer adds to an XAML file

The [ViewStateCleaningWriter sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/Designer/ViewStateCleaningWriter/cs) demonstrates how to create a class that derives from <xref:System.Xaml.XamlWriter> and removes view state from a XAML file. Windows Workflow Designer writes information into the XAML document, which is known as view state. View state refers to the information that is required at design time, such as layout positioning, that is not required at runtime. Workflow Designer inserts this information into the XAML document as it is edited. Workflow Designer writes the view state into the XAML file with the `mc:Ignorable` attribute, so this information is not loaded when the runtime loads the XAML file. This sample demonstrates how to create a class that removes that view state information while processing XAML nodes.

## Discussion

This sample demonstrates how to create a custom writer.

To build a custom XAML writer, create a class that inherits from <xref:System.Xaml.XamlWriter>. As XAML writers are often nested, it is typical to keep track of an "inner" XAML writer. These "inner' writers can be thought of as the reference to the remaining stack of XAML writers, allowing you to have multiple entry points to do work and then delegate processing to the remainder of the stack.

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

This also creates a stack of XAML members that are used while traversing the node stream. The remaining work of this sample is largely contained in the `WriteStartMember` method.

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

## To use this sample

1. Using Visual Studio, open the ViewStateCleaningWriter.sln solution file.

2. Open a command prompt and navigate to the directory where the ViewStageCleaningWriter.exe is built.

3. Run ViewStateCleaningWriter.exe on the Workflow1.xaml file.

   The syntax for the executable is shown in the following example.

   ```console
   ViewStateCleaningWriter.exe [input file] [output file]
   ```

   This outputs a XAML file to \[outfile], which has all its view state information removed.

> [!NOTE]
> For a <xref:System.Activities.Statements.Sequence> workflow, a number of virtualization hints are removed. This causes the designer to recalculate layout the next time it is loaded. When you use this sample for a <xref:System.Activities.Statements.Flowchart>, all positioning and line routing information are removed and on subsequent loading into the designer, all activities are stacked on the left side of the screen.

## To create a sample XAML file for use with this sample

1. Open Visual Studio.

2. Create a new Workflow Console Application.

3. Drag and drop a few activities onto the canvas

4. Save the workflow XAML file.

5. Inspect the XAML file to see the view state attached properties.
