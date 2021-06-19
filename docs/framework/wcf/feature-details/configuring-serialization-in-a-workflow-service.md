---
description: "Learn more about: Configuring Serialization in a Workflow Service"
title: "Configuring Serialization in a Workflow Service"
ms.date: "03/30/2017"
ms.topic: how-to
---
# Configuring Serialization in a Workflow Service

Workflow services are Windows Communication Foundation (WCF) services and so have the option of using either the <xref:System.Runtime.Serialization.DataContractSerializer> (the default) or the <xref:System.Xml.Serialization.XmlSerializer>. When writing non-workflow services the type of serializer to use is specified on the service or operation contract. When creating WCF workflow services you don't specify these contracts in code, but rather they are generated at runtime by contract inference. For more information about contract inference, see  [Using Contracts in Workflow](using-contracts-in-workflow.md).  The serializer is specified using the <xref:System.ServiceModel.Activities.Receive.SerializerOption%2A> property. This can be set in the designer as shown in the following illustration.  
  
 ![Setting the SerializerOption property in the Properties Window.](./media/configuring-serialization-in-a-workflow-service/setting-serializer-property.png)  
  
 The serializer can also be set in code as shown in the following example,  
  
```csharp  
Receive approveExpense = new Receive  
            {  
                OperationName = "ApproveExpense",  
                CanCreateInstance = true,  
                ServiceContractName = "FinanceService",  
                SerializerOption = SerializerOption.DataContractSerializer,  
                Content = ReceiveContent.Create(new OutArgument<Expense>(expense))  
            };  
```  
  
  Known types can be specified on Workflow services as well. For more information about Known Types, see [Data Contract Known Types](data-contract-known-types.md). Known types can be specified in the designer or in code. To specify known types in the designer, click the ellipsis button next to the KnownTypes property in the **Properties Window** for a <xref:System.ServiceModel.Activities.Receive> activity as shown in the following illustration.
  
 ![Screenshot of the KnownTypes property dialog box.](./media/configuring-serialization-in-a-workflow-service/known-types-properties.png)  
  
 This displays the Type Collections Editor that allows you to search for and specify known types.  
  
 ![Screenshot of the Type Collections Editor.](./media/configuring-serialization-in-a-workflow-service/type-collection-editor.gif)  
  
 Click the **Add new type** link and use the drop down to select or search for a type to add to the known types collection. To specify known types in code use the <xref:System.ServiceModel.Activities.Receive.KnownTypes%2A> property as shown in the following example.  
  
```csharp
Receive approveExpense = new Receive  
            {  
                OperationName = "ApproveExpense",  
                CanCreateInstance = true,  
                ServiceContractName = "FinanceService",  
                SerializerOption = SerializerOption.DataContractSerializer,  
                Content = ReceiveContent.Create(new OutArgument<Expense>(expense))  
            };  
            approveExpense.KnownTypes.Add(typeof(Travel));  
            approveExpense.KnownTypes.Add(typeof(Meal));  
```
