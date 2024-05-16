---
description: "Learn more about: Using Editing Scope"
title: "Using Editing Scope"
ms.date: "03/30/2017"
ms.assetid: 79306f9e-318b-4687-9863-8b93d1841716
---
# Using Editing Scope

The [UsingEditingScope sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/CustomActivities/CustomActivityDesigners/UsingEditingScope/cs) demonstrates how to batch a set of changes so that they can be undone in a single atomic unit. By default, the actions taken by an activity designer author are automatically integrated into the Undo/Redo system.

## Demonstrates

 Editing scope and Undo and Redo.

## Discussion

 This sample demonstrates how to batch a set of changes to the <xref:System.Activities.Presentation.Model.ModelItem> tree within a single unit of work. Note that when binding to <xref:System.Activities.Presentation.Model.ModelItem> values directly from a WPF designer, changes are applied automatically. This sample demonstrates what must be done when multiple changes to be batched are being made through imperative code, rather than a single change.

 In this sample, three activities are added. When editing begins, <xref:System.Activities.Presentation.Model.ModelItem.BeginEdit%2A> is called on an instance of <xref:System.Activities.Presentation.Model.ModelItem>. Changes made to the <xref:System.Activities.Presentation.Model.ModelItem> tree within this editing scope are batched. The <xref:System.Activities.Presentation.Model.ModelItem.BeginEdit%2A> command returns an <xref:System.Activities.Presentation.Model.EditingScope>, which can be used to control this instance. Either <xref:System.Activities.Presentation.Model.EditingScope.OnComplete%2A> or <xref:System.Activities.Presentation.Model.EditingScope.OnRevert%2A> can be called to either commit or revert the editing scope.

 You can also nest <xref:System.Activities.Presentation.Model.EditingScope> objects, which allows for multiple sets of changes to be tracked as part of a larger editing scope and can be controlled individually. A scenario that may use this feature would be when changes from multiple dialogs must be committed or reverted separately, with all changes being treated as a single atomic operation. In this sample, the editing scopes are stacked using an <xref:System.Collections.ObjectModel.ObservableCollection%601> of type <xref:System.Activities.Presentation.Model.ModelEditingScope>. The <xref:System.Collections.ObjectModel.ObservableCollection%601> is used so that the depth of the nesting can be observed on the designer surface.

## To set up, build, and run the sample

1. Build and run the sample, and then use the buttons on the left to modify the workflow.

2. Click **Open Editing Scope**.

    1. This command calls <xref:System.Activities.Presentation.Model.ModelItem.BeginEdit%2A> that creates an editing scope and pushes it onto the editing stack.

    2. Three activities are then added to the selected <xref:System.Activities.Presentation.Model.ModelItem>. Note that if the editing scope had not been opened with <xref:System.Activities.Presentation.Model.ModelItem.BeginEdit%2A>, three new activities would appear on the designer canvas. Because this operation is still pending within the <xref:System.Activities.Presentation.Model.EditingScope>, the designer is not yet updated.

3. Press **Close Editing Scope** to commit the editing scope. Three activities appear in the designer.
