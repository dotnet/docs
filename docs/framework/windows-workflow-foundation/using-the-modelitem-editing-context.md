---
title: "Using the ModelItem Editing Context"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7f9f1ea5-0147-4079-8eca-be94f00d3aa1
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the ModelItem Editing Context
The <xref:System.Activities.Presentation.Model.ModelItem> editing context is the object that the host application uses to communicate with the designer. <xref:System.Activities.Presentation.EditingContext> exposes two methods, <xref:System.Activities.Presentation.EditingContext.Items%2A> and <xref:System.Activities.Presentation.EditingContext.Services%2A>, which can be used  
  
## The Items collection  
 The <xref:System.Activities.Presentation.EditingContext.Items%2A> collection is used to access data that is shared between the host and the designer, or data that is available to all designers. This collection has the following capabilities, accessed via the <xref:System.Activities.Presentation.ContextItemManager> class:  
  
1.  <xref:System.Activities.Presentation.ContextItemManager.GetValue%2A>  
  
2.  <xref:System.Activities.Presentation.ContextItemManager.Subscribe%2A>  
  
3.  <xref:System.Activities.Presentation.ContextItemManager.Unsubscribe%2A>  
  
4.  <xref:System.Activities.Presentation.ContextItemManager.SetValue%2A>  
  
## The Services collection  
 The <xref:System.Activities.Presentation.EditingContext.Services%2A> collection is used to access services that the designer uses to interact with the host, or services that all designers use. This collection has the following methods of note:  
  
1.  <xref:System.Activities.Presentation.ServiceManager.Publish%2A>  
  
2.  <xref:System.Activities.Presentation.ServiceManager.Subscribe%2A>  
  
3.  <xref:System.Activities.Presentation.ServiceManager.Unsubscribe%2A>  
  
4.  <xref:System.Activities.Presentation.ServiceManager.GetService%2A>  
  
## Assigning a designer an activity  
 To specify which designer an activity uses, the Designer attribute is used.  
  
```  
[Designer(typeof(MyClassDesigner))]  
public sealed class MyClass : CodeActivity  
{  
```  
  
## Creating a service  
 To create a service that serves as a conduit of information between the designer and the host, an interface and an implementation must be created. The interface is used by the <xref:System.Activities.Presentation.ServiceManager.Publish%2A> method to define the members of the service, and the implementation contains the logic for the service. In the following code example, a service interface and implementation are created.  
  
```  
public interface IMyService  
    {  
        IEnumerable<string> GetValues(string DisplayName);  
    }  
  
    public class MyServiceImpl : IMyService  
    {  
        public IEnumerable<string> GetValues(string DisplayName)  
        {  
            return new string[]  {   
                DisplayName + " One",   
                DisplayName + " Two",  
                "Three " + DisplayName  
            } ;  
        }  
    }  
```  
  
## Publishing a service  
 For a designer to consume a service, it must first be published by the host using the <xref:System.Activities.Presentation.ServiceManager.Publish%2A> method.  
  
```  
this.Context.Services.Publish<IMyService>(new MyServiceImpl);  
```  
  
## Subscribing to a service  
 The designer obtains access to the service using the <xref:System.Activities.Presentation.ServiceManager.Subscribe%2A> method in the <xref:System.Activities.Presentation.WorkflowViewElement.OnModelItemChanged%2A> method. The following code snippet demonstrates how to subscribe to a service.  
  
```  
protected override void OnModelItemChanged(object newItem)  
{  
    if (!subscribed)  
    {  
        this.Context.Services.Subscribe<IMyService>(  
            servInstance =>  
            {  
                listBox1.ItemsSource = servInstance.GetValues(this.ModelItem.Properties["DisplayName"].ComputedValue.ToString());  
            }  
            );  
        subscribed = true;   
    }  
}  
```  
  
## Sharing data using the Items collection  
 Using the Items collection is similar to using the Services collection, except that <xref:System.Activities.Presentation.ContextItemManager.SetValue%2A> is used instead of Publish. This collection is more appropriate for sharing simple data between the designers and the host, rather than complex functionality.  
  
## EditingContext host items and services  
 The .Net Framework provides a number of built-in items and services accessed through the editing context.  
  
 Items:  
  
-   <xref:System.Activities.Presentation.Hosting.AssemblyContextControlItem>: Manages the list of referenced local assemblies that will be used inside the workflow for controls (such as the expression editor).  
  
-   <xref:System.Activities.Presentation.Hosting.ReadOnlyState>: Indicates whether the designer is in a read-only state.  
  
-   <xref:System.Activities.Presentation.View.Selection>: Defines the collection of objects that are currently selected.  
  
-   <xref:System.Activities.Presentation.Hosting.WorkflowCommandExtensionItem>:  
  
-   <xref:System.Activities.Presentation.WorkflowFileItem>: Provides information on the file that the current editing session is based on.  
  
 Services:  
  
-   <xref:System.Activities.Presentation.Model.AttachedPropertiesService>: Allows properties to be added to the current instance, using <xref:System.Activities.Presentation.Model.AttachedPropertiesService.AddProperty%2A>.  
  
-   <xref:System.Activities.Presentation.View.DesignerView>: Allows access to the properties of the designer canvas.  
  
-   <xref:System.Activities.Presentation.IActivityToolboxService>: Allows the contents of the toolbox to be updated.  
  
-   <xref:System.Activities.Presentation.Hosting.ICommandService>: Used to integrate designer commands (such as Context Menu) with custom-provided service implementations.  
  
-   <xref:System.Activities.Presentation.Debug.IDesignerDebugView>: Provides functionality for the designer debugger.  
  
-   <xref:System.Activities.Presentation.View.IExpressionEditorService>: Provides access to the Expression Editor dialog.  
  
-   <xref:System.Activities.Presentation.IIntegratedHelpService>: Provides the designer with integrated help functionality.  
  
-   <xref:System.Activities.Presentation.Validation.IValidationErrorService>: Provides access to validation errors using <xref:System.Activities.Presentation.Validation.IValidationErrorService.ShowValidationErrors%2A>.  
  
-   <xref:System.Activities.Presentation.IWorkflowDesignerStorageService>: Provides an internal service to store and retrieve data. This service is used internally by the .Net Framework, and is not intended for external use.  
  
-   <xref:System.Activities.Presentation.IXamlLoadErrorService>: Provides access to the XAML load error collection using <xref:System.Activities.Presentation.IXamlLoadErrorService.ShowXamlLoadErrors%2A>.  
  
-   <xref:System.Activities.Presentation.Services.ModelService>: Used by the designer to interact with the model of the workflow being edited.  
  
-   <xref:System.Activities.Presentation.Model.ModelTreeManager>: Provides access to the root of the model item tree using <xref:System.Activities.Presentation.Model.ModelItem.Root%2A>.  
  
-   <xref:System.Activities.Presentation.UndoEngine>: Provides undo and redo functionality.  
  
-   <xref:System.Activities.Presentation.Services.ViewService>: Maps visual elements to underlying model items.  
  
-   <xref:System.Activities.Presentation.View.ViewStateService>: Stores view states for model items.  
  
-   <xref:System.Activities.Presentation.View.VirtualizedContainerService>: Used to customize the virtual container UI behavior.  
  
-   <xref:System.Activities.Presentation.Hosting.WindowHelperService>: Used to register and unregister delegates for event notifications. Also allows a window owner to be set.
