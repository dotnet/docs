---
title: "How to: Create a workflow service that consumes an existing service contract"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 11d11b59-acc4-48bf-8e4b-e97b516aa0a9
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a workflow service that consumes an existing service contract
[!INCLUDE[net_v45](../../../includes/net-v45-md.md)] features better integration between web services and workflows in the form of contract-first workflow development. The contract-first workflow development tool allows you to design the contract in code first. The tool then automatically generates an activity template in the toolbox for the operations in the contract.  
  
> [!NOTE]
>  This topic provides step-by-step guidance on creating a contract-first workflow service. [!INCLUDE[crabout](../../../includes/crabout-md.md)] contract-first workflow service development, see [Contract First Workflow Service Development](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md).  
  
### Creating the workflow project  
  
1.  In [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)], select **File**, **New Project**. Select the **WCF** node under the **C#** node in the **Templates** tree, and select the **WCF Workflow Service Application** template.  
  
2.  Name the new project `ContractFirst` and click **Ok**.  
  
### Creating the service contract  
  
1.  Right-click the project in **Solution Explorer** and select **Add**, **New Item…**. Select the **Code** node on the left, and the **Class** template on the right. Name the new class `IBookService` and click **Ok**.  
  
2.  In the top of the code window that appears, add a Using statement to `System.Servicemodel`.  
  
    ```  
    using System.ServiceModel;  
    ```  
  
3.  Change the sample class definition to the following interface definition.  
  
    ```  
    [ServiceContract]  
        public interface IBookService  
        {  
            [OperationContract]  
            void Buy(string bookName);  
  
            [OperationContract(IsOneWay=true)]  
            void Checkout();  
        }  
    ```  
  
4.  Build the project by pressing **Ctrl+Shift+B**.  
  
### Importing the service contract  
  
1.  Right-click the project in **Solution Explorer** and select **Import Service Contract**. Under **\<Current Project>**, open all sub-nodes and select **IBookService**. Click **OK**.  
  
2.  A dialog will open, alerting you that the operation completed successfully, and that the generated activities will appear in the toolbox after you build the project. Click **OK**.  
  
3.  Build the project by pressing **Ctrl+Shift+B**, so that the imported activities will appear in the toolbox.  
  
4.  In **Solution Explorer**, open Service1.xamlx. The workflow service will appear in the designer.  
  
5.  Select the **Sequence** activity. In the Properties window, click the **…** button in the **ImplementedContract** property. In the **Type Collection Editor** window that appears, click the **Type** dropdown, and select the **Browse for Types…** entry. In the **Browse and Select a .Net Type** dialog, under **\<Current Project>**, open all sub-nodes and select **IBookService**. Click **OK**. In the **Type Collection Editor** dialog, click **OK**.  
  
6.  Select and delete the **ReceiveRequest** and **SendResponse** activities.  
  
7.  From the toolbox, drag a **Buy_ReceiveAndSendReply** and a **Checkout_Receive** activity onto the **Sequential Service** activity.
