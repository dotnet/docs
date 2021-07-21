---
description: "Learn more about: Programming Model Item Tree"
title: "Programming Model Item Tree"
ms.date: "03/30/2017"
ms.assetid: 0229efde-19ac-4bdc-a187-c6227a7bd1a5
---
# Programming Model Item Tree

The [ProgrammingModelItemTree sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/Designer/ProgrammingModelItemTree/cs) demonstrates how to navigate the <xref:System.Activities.Presentation.Model.ModelItem> tree using declarative data binding from the Windows Presentation Foundation (WPF) Tree View.

## Sample Details

 The <xref:System.Activities.Presentation.Model.ModelItem> tree is the abstraction that is used by the Windows Workflow Designer infrastructure to expose the data about the underlying instance being edited. The following illustration is a depiction of the various layers of infrastructure within the Workflow Designer.

 ![Diagram that shows the Workflow Designer architecture.](./media/programming-model-item-tree/workflow-designer-architecture.jpg)

 A <xref:System.Activities.Presentation.Model.ModelItem> consists of a pointer to the underlying value, as well as a collection of <xref:System.Activities.Presentation.Model.ModelProperty> objects. A <xref:System.Activities.Presentation.Model.ModelProperty> object in turn, consists of data such as the name and type of the property and then a pointer to the value, which in turn, is another <xref:System.Activities.Presentation.Model.ModelItem>. A value converter is used to manipulate some of the <xref:System.Activities.Presentation.Model.ModelItem>s returned from a <xref:System.Activities.Presentation.Model.ModelProperty> to make them appear correctly in the tree view. The sample then demonstrates how to imperatively program against the <xref:System.Activities.Presentation.Model.ModelItem> tree using the imperative syntax, as seen in the following example.

```csharp
ModelItem mi = wd.Context.Services.GetService<ModelService>().Root;
ModelProperty mp = mi.Properties["Activities"];
mp.Collection.Add(new Persist());
ModelItem justAdded = mp.Collection.Last();
justAdded.Properties["DisplayName"].SetValue("new name");
```

## To use this sample

1. Open the ProgrammingModelItemTree.sln solution in Visual Studio.

2. Build the solution by selecting **Build Solution** from the **Build** menu.

3. Press F5 to run the application. The WPF form is then displayed.

4. Click the **Load WF** button to load the <xref:System.Activities.Presentation.Model.ModelItem> and bind it to the tree view.

5. Clicking the **Change Model Item Tree** button executes the preceding code to add an item into the tree and set a property.

## See also

- <xref:System.Windows.Data.IValueConverter>
