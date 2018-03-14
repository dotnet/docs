---
title: "How to: Create a Custom Activity Template"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6760a5cc-6eb8-465f-b4fa-f89b39539429
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Custom Activity Template
Custom activity templates are used to customize the configuration of activities, including custom composite activities, so that users do not have to create each activity individually and configure their properties and other settings manually. These custom templates can be made available in the **Toolbox** on the [!INCLUDE[wfd1](../../../includes/wfd1-md.md)] or from a rehosted designer, from which users can drag them onto the preconfigured design surface. [!INCLUDE[wfd2](../../../includes/wfd2-md.md)] ships with good examples of such templates: the [SendAndReceiveReply Template Designer](/visualstudio/workflow-designer/sendandreceivereply-template-designer) and the [ReceiveAndSendReply Template Designer](/visualstudio/workflow-designer/receiveandsendreply-template-designer) in the [Messaging Activity Designers](/visualstudio/workflow-designer/messaging-activity-designers) category.  
  
 The first procedure in this topic describes how to create a custom activity template for a **Delay** activity and the second procedure describes briefly how to make it available in a [!INCLUDE[wfd2](../../../includes/wfd2-md.md)] to verify that the custom template works.  
  
 Custom activity templates must implement the <xref:System.Activities.Presentation.IActivityTemplateFactory>. The interface has a single <xref:System.Activities.Presentation.IActivityTemplateFactory.Create%2A> method with which you can create and configure the activity instances used in the template.  
  
### To create a template for the Delay activity  
  
1.  Start [!INCLUDE[vs2010](../../../includes/vs2010-md.md)].  
  
2.  On the **File** menu, point to **New**, and then select **Project**.  
  
     The **New Project** dialog box opens.  
  
3.  In the **Project Types** pane, select **Workflow** from either the **Visual C#** projects or **Visual Basic** groupings depending on your language preference.  
  
4.  In the **Templates** pane, select **Activity Library**.  
  
5.  In the **Name** box, enter `DelayActivityTemplate`.  
  
6.  Accept the defaults in the **Location** and **Solution name** text boxes, and then click **OK**.  
  
7.  Right-click the References directory of the DelayActivityTemplate project in **Solution Explorer** and choose **Add Reference** to open the **Add Reference** dialog box.  
  
8.  Go to the **.NET** tab and select **PresentationFramework** from the **Component Name** column on the left and click **OK** to add a reference to the PresentationFramework.dll file.  
  
9. Repeat this procedure to add references to the System.Activities.Presentation.dll and the WindowsBase.dll files.  
  
10. Right-click the DelayActivityTemplate project in **Solution Explorer** and choose **Add** and then **New Item** to open the **Add New Item** dialog box.  
  
11. Select the **Class** template, name it MyDelayTemplate, and then click **OK**.  
  
12. Open the MyDelayTemplate.cs file and add the following statements.  
  
    ```  
    //Namespaces added  
    using System.Activities;  
    using System.Activities.Statements;  
    using System.Activities.Presentation;  
    using System.Windows;  
    ```  
  
13. Implement the <xref:System.Activities.Presentation.IActivityTemplateFactory> with the `MyDelayActivity` class with the following code. This configures the delay to have a duration of 10 seconds.  
  
    ```  
    public sealed class MyDelayActivity : IActivityTemplateFactory  
    {  
        public Activity Create(System.Windows.DependencyObject target)  
        {  
            return new System.Activities.Statements.Delay  
            {  
                DisplayName = "DelayActivityTemplate",  
                Duration = new TimeSpan(0, 0, 10)  
  
            };  
        }  
    }  
    ```  
  
14. Select **Build Solution** from the **Build** menu to generate the DelayActivityTemplate.dll file.  
  
### To make the template available in a Workflow Designer  
  
1.  Right-click the DelayActivityTemplate solution in **Solution Explorer** and choose **Add** and then **New Project** to open the **Add New Project** dialog box.  
  
2.  Select the **Workflow Console Application** template, name it `CustomActivityTemplateApp`, and then click **OK**.  
  
3.  Right-click the References directory of the CustomActivityTemplateApp project in **Solution Explorer** and choose **Add Reference** to open the **Add Reference** dialog box.  
  
4.  Go to the **Projects** tab and select **DelayActivityTemplate** from the **Project Name** column on the left and click **OK** to add a reference to the DelayActivityTemplate.dll file that you created in the first procedure.  
  
5.  Right-click the CustomActivityTemplateApp project in **Solution Explorer** and choose **Build** to compile the application.  
  
6.  Right-click the CustomActivityTemplateApp project in **Solution Explorer** and choose **Set as Startup Project**.  
  
7.  Select **Start Without Debugging** from the **Debug** menu and press any key to continue when prompted from the cmd.exe window.  
  
8.  Open the Workflow1.xaml file and open the **Toolbox**.  
  
9. Locate the **MyDelayActivity** template in the **DelayActivityTemplate** category. Drag it onto the design surface. Confirm in the **Properties** window that the `Duration` property has been set to 10 seconds.  
  
## Example  
 The MyDelayActivity.cs file should contain the following code.  
  
```  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
  
//Namespaces added  
using System.Activities;  
using System.Activities.Statements;  
using System.Activities.Presentation;  
using System.Windows;  
  
namespace DelayActivityTemplate  
{  
    public sealed class MyDelayActivity : IActivityTemplateFactory  
    {  
        public Activity Create(System.Windows.DependencyObject target)  
        {  
            return new System.Activities.Statements.Delay  
            {  
                DisplayName = "DelayActivityTemplate",  
                Duration = new TimeSpan(0, 0, 10)  
  
            };  
        }  
    }  
}  
```  
  
## See Also  
 <xref:System.Activities.Presentation.IActivityTemplateFactory>  
 [Customizing the Workflow Design Experience](../../../docs/framework/windows-workflow-foundation/customizing-the-workflow-design-experience.md)
