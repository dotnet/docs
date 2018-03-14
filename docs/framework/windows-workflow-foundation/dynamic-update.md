---
title: "Dynamic Update"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8b6ef19b-9691-4b4b-824c-3c651a9db96e
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Dynamic Update
Dynamic update provides a mechanism for workflow application developers to update the workflow definition of a persisted workflow instance. This can be to implement a bug fix, new requirements, or to accommodate unexpected changes. This topic provides an overview of the dynamic update functionality introduced in [!INCLUDE[net_v45](../../../includes/net-v45-md.md)].  
  
## Dynamic Update  
 To apply dynamic updates to a persisted workflow instance, a <xref:System.Activities.DynamicUpdate.DynamicUpdateMap> is created that contains instructions for the runtime that describe how to modify the persisted workflow instance to reflect the desired changes. Once the update map is created, it is applied to the desired persisted workflow instances. Once the dynamic update is applied, the workflow instance may be resumed using the new updated workflow definition. There are four steps required to create and apply an update map.  
  
1.  [Prepare the workflow definition for dynamic update](../../../docs/framework/windows-workflow-foundation/dynamic-update.md#Prepare)  
  
2.  [Update the workflow definition to reflect the desired changes](../../../docs/framework/windows-workflow-foundation/dynamic-update.md#Update)  
  
3.  [Create the update map](../../../docs/framework/windows-workflow-foundation/dynamic-update.md#Create)  
  
4.  [Apply the update map to the desired persisted workflow instances](../../../docs/framework/windows-workflow-foundation/dynamic-update.md#Apply)  
  
> [!NOTE]
>  Note that steps 1 through 3, which cover the creation of the update map, may be performed independently of applying the update. A common scenario that that the workflow developer will create the update map offline, and then an administrator will apply the update at a later time.  
  
 This topic provides an overview of the dynamic update process of adding a new activity to a persisted instance of a compiled Xaml workflow.  
  
###  <a name="Prepare"></a> Prepare the workflow definition for dynamic update  
 The first step in the dynamic update process is to prepare the desired workflow definition for update. This is done by calling the <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.PrepareForUpdate%2A?displayProperty=nameWithType> method and passing in the workflow definition to modify. This method validates and then walks the workflow tree to identify all of the objects such as public activities and variables that need to be tagged so they can be compared later with the modified workflow definition. When this is complete, the workflow tree is cloned and attached to the original workflow definition. When the update map is created, the updated version of the workflow definition is compared with the original workflow definition and the update map is generated based on the differences.  
  
 To prepare a Xaml workflow for dynamic update it may be loaded into an <xref:System.Activities.ActivityBuilder>, and then the <xref:System.Activities.ActivityBuilder> is passed into <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.PrepareForUpdate%2A?displayProperty=nameWithType>.  
  
> [!NOTE]
>  For more information about working with serialized workflows and <xref:System.Activities.ActivityBuilder>, see [Serializing Workflows and Activities to and from XAML](../../../docs/framework/windows-workflow-foundation/serializing-workflows-and-activities-to-and-from-xaml.md).  
  
 In the following example, a `MortgageWorkflow` definition (that consists of a <xref:System.Activities.Statements.Sequence> with several child activities) is loaded into an <xref:System.Activities.ActivityBuilder>, and then prepared for dynamic update. After the method returns, the <xref:System.Activities.ActivityBuilder> contains the original workflow definition as well as a copy.  
  
```csharp  
// Load the MortgageWorkflow definition from Xaml into  
// an ActivityBuilder.  
XamlXmlReaderSettings readerSettings = new XamlXmlReaderSettings()  
{  
    LocalAssembly = Assembly.GetExecutingAssembly()  
};  
  
XamlXmlReader xamlReader = new XamlXmlReader(@"C:\WorkflowDefitinions\MortgageWorkflow.xaml",   
    readerSettings);  
  
ActivityBuilder ab = XamlServices.Load(  
    ActivityXamlServices.CreateBuilderReader(xamlReader)) as ActivityBuilder;  
  
// Prepare the workflow definition for dynamic update.  
DynamicUpdateServices.PrepareForUpdate(ab);  
```  
  
> [!NOTE]
>  To download the sample code that accompanies this topic, see [Dynamic Update sample code](http://go.microsoft.com/fwlink/?LinkId=227905).  
  
###  <a name="Update"></a> Update the workflow definition to reflect the desired changes  
 Once the workflow definition has been prepared for updating, the desired changes can be made. You can add or remove activities, add, move or delete public variables, add or remove arguments, and make changes to the signature of activity delegates. You cannot remove a running activity or change the signature of a running delegate. These changes may be made using code, or in a re-hosted workflow designer. In the following example, a custom `VerifyAppraisal` activity is added to the Sequence that makes up the body of the `MortgageWorkflow` from the previous example.  
  
```csharp  
// Make desired changes to the definition. In this example, we are  
// inserting a new VerifyAppraisal activity as the 3rd child of the root Sequence.  
VerifyAppraisal va = new VerifyAppraisal  
{  
    Result = new VisualBasicReference<bool>("LoanCriteria")  
};  
  
// Get the Sequence that makes up the body of the workflow.  
Sequence s = ab.Implementation as Sequence;  
  
// Insert the new activity into the Sequence.  
s.Activities.Insert(2, va);  
```  
  
###  <a name="Create"></a> Create the update map  
 Once the workflow definition that was prepared for update has been modified, the update map can be created. To create a dynamic update map, the <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.CreateUpdateMap%2A?displayProperty=nameWithType> method is invoked. This returns a <xref:System.Activities.DynamicUpdate.DynamicUpdateMap> that contains the information the runtime needs to modify a persisted workflow instance so that it may be loaded and resumed with the new workflow definition. In the following example, a dynamic map is created for the modified `MortgageWorkflow` definition from the previous example.  
  
```csharp  
// Create the update map.  
DynamicUpdateMap map = DynamicUpdateServices.CreateUpdateMap(ab);  
```  
  
 This update map can immediately be used to modify persisted workflow instances, or more typically it can be saved and the updates applied later. One way to save the update map is to serialize it to a file, as shown in the following example.  
  
```csharp  
// Serialize the update map to a file.  
DataContractSerializer serializer = new DataContractSerializer(typeof(DynamicUpdateMap));  
using (FileStream fs = System.IO.File.Open(@"C:\WorkflowDefitinions\MortgageWorkflow.map", FileMode.Create))  
{  
    serializer.WriteObject(fs, map);  
}  
```  
  
 When <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.CreateUpdateMap%2A?displayProperty=nameWithType> returns, the cloned workflow definition and other dynamic update information that was added in the call to <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.PrepareForUpdate%2A?displayProperty=nameWithType> is removed, and the modified workflow definition is ready to be saved so that it can be used later when resuming updated workflow instances. In the following example, the modified workflow definition is saved to `MortgageWorkflow_v2.xaml`.  
  
```csharp  
// Save the modified workflow definition.  
StreamWriter sw = File.CreateText(@"C:\WorkflowDefitinions\MortgageWorkflow_v1.1.xaml");  
XamlWriter xw = ActivityXamlServices.CreateBuilderWriter(new XamlXmlWriter(sw, new XamlSchemaContext()));  
XamlServices.Save(xw, ab);  
sw.Close();  
```  
  
###  <a name="Apply"></a> Apply the update map to the desired persisted workflow instances  
 Applying the update map can be done at any time after creating it. It can be done right away using the <xref:System.Activities.DynamicUpdate.DynamicUpdateMap> instance that was returned by <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.CreateUpdateMap%2A?displayProperty=nameWithType>, or it can be done later using a saved copy of the update map. To update a workflow instance, load it into a <xref:System.Activities.WorkflowApplicationInstance> using <xref:System.Activities.WorkflowApplication.GetInstance%2A?displayProperty=nameWithType>. Next, create a <xref:System.Activities.WorkflowApplication> using the updated workflow definition, and the desired <xref:System.Activities.WorkflowIdentity>. This <xref:System.Activities.WorkflowIdentity> may be different than the one that was used to persist the original workflow, and typically is in order to reflect that the persisted instance has been modified. Once the <xref:System.Activities.WorkflowApplication> is created, it is loaded using the overload of <xref:System.Activities.WorkflowApplication.Load%2A?displayProperty=nameWithType> that takes a <xref:System.Activities.DynamicUpdate.DynamicUpdateMap>, and then unloaded with a call to <xref:System.Activities.WorkflowApplication.Unload%2A?displayProperty=nameWithType>. This applies the dynamic update and persists the updated workflow instance.  
  
```csharp  
// Load the serialized update map.  
DynamicUpdateMap map;  
using (FileStream fs = File.Open(@"C:\WorkflowDefitinions\MortgageWorkflow.map", FileMode.Open))  
{  
    DataContractSerializer serializer = new DataContractSerializer(typeof(DynamicUpdateMap));  
    object updateMap = serializer.ReadObject(fs);  
    if (updateMap == null)  
    {  
        throw new ApplicationException("DynamicUpdateMap is null.");  
    }  
  
    map = (DynamicUpdateMap)updateMap;  
}  
  
// Retrieve a list of workflow instance ids that corresponds to the  
// workflow instances to update. This step is the responsibility of  
// the application developer.  
List<Guid> ids = GetPersistedWorkflowIds();  
foreach (Guid id in ids)  
{  
    // Get a proxy to the persisted workflow instance.  
    SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(connectionString);  
    WorkflowApplicationInstance instance = WorkflowApplication.GetInstance(id, store);  
  
    // If desired, you can inspect the WorkflowIdentity of the instance  
    // using the DefinitionIdentity property to determine whether to apply  
    // the update.  
    Console.WriteLine(instance.DefinitionIdentity);  
  
    // Create a workflow application. You must specify the updated workflow definition, and  
    // you may provide an updated WorkflowIdentity if desired to reflect the update.  
    WorkflowIdentity identity = new WorkflowIdentity  
    {  
        Name = "MortgageWorkflow v1.1",  
        Version = new Version(1, 1, 0, 0)  
    };  
  
    // Load the persisted workflow instance using the updated workflow definition  
    // and with an updated WorkflowIdentity. In this example the MortgageWorkflow class  
    // contains the updated definition.  
    WorkflowApplication wfApp = new WorkflowApplication(new MortgageWorkflow(), identity);  
  
    // Apply the dynamic update on the loaded instance.                
    wfApp.Load(instance, map);  
  
    // Unload the updated instance.  
    wfApp.Unload();  
}  
```  
  
### Resuming an Updated Workflow Instance  
 Once dynamic update has been applied, the workflow instance may be resumed. Note that the new updated definition and <xref:System.Activities.WorkflowIdentity> must be used.  
  
> [!NOTE]
>  For more information about working with <xref:System.Activities.WorkflowApplication> and <xref:System.Activities.WorkflowIdentity>, see[Using WorkflowIdentity and Versioning](../../../docs/framework/windows-workflow-foundation/using-workflowidentity-and-versioning.md).  
  
 In the following example, the `MortgageWorkflow_v1.1.xaml` workflow from the previous example has been compiled, and is loaded and resumed using the updated workflow definition.  
  
```csharp  
// Load the persisted workflow instance using the updated workflow definition  
// and updated WorkflowIdentity.  
WorkflowIdentity identity = new WorkflowIdentity  
{  
    Name = "MortgageWorkflow v1.1",  
    Version = new Version(1, 1, 0, 0)  
};  
  
WorkflowApplication wfApp = new WorkflowApplication(new MortgageWorkflow(), identity);  
  
// Configure persistence and desired workflow event handlers.  
// (Omitted for brevity.)  
ConfigureWorkflowApplication(wfApp);  
  
// Load the persisted workflow instance.  
wfApp.Load(InstanceId);  
  
// Resume the workflow.  
// wfApp.ResumeBookmark(...);  
```  
  
> [!NOTE]
>  To download the sample code that accompanies this topic, see [Dynamic Update sample code](http://go.microsoft.com/fwlink/?LinkId=227905).
