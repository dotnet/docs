---
description: "Learn more about: How to: Create a Workflow Service with Messaging Activities"
title: "How to: Create a Workflow Service with Messaging Activities"
ms.date: "03/30/2017"
ms.assetid: 53d094e2-6901-4aa1-88b8-024b27ccf78b
---
# How to: Create a Workflow Service with Messaging Activities

This topic describes how to create a simple workflow service using messaging activities. This topic focuses on the mechanics of creating a workflow service where the service consists solely of messaging activities. In a real-world service, the workflow contains many other activities. The service implements one operation called Echo, which takes a string and returns the string to the caller. This topic is the first in a series of two topics. The next topic [How To: Access a Service From a Workflow Application](how-to-access-a-service-from-a-workflow-application.md) discusses how to create a workflow application that can call the service created in this topic.  
  
### To create a workflow service project  
  
1. Start Visual Studio 2012.  
  
2. Click the **File** menu, select **New**, and then **Project** to display the **New Project Dialog**. Select **Workflow** from the list of installed templates and **WCF Workflow Service Application** from the list of project types. Name the project `MyWFService` and use the default location as shown in the following illustration.  
  
     Click the **OK** button to dismiss the **New Project Dialog**.  
  
3. When the project is created, the Service1.xamlx file is opened in the designer as shown in the following illustration.  
  
     ![Screenshot shows the open Service1.xamlx file in the designer.](./media/how-to-create-a-workflow-service-with-messaging-activities/default-workflow-service.jpg)  
  
     Right-click the activity labeled **Sequential Service** and select **Delete**.  
  
### To implement the workflow service  
  
1. Select the **Toolbox** tab on the left side of the screen to display the toolbox and click the pushpin to keep the window open. Expand the **Messaging** section of the toolbox to display the messaging activities and the messaging activity templates as shown in the following illustration.  
  
     ![Screenshot that shows the toolbox with Messaging section expanded.](./media/how-to-create-a-workflow-service-with-messaging-activities/toolbox-messaging-section.jpg)  
  
2. Drag and drop a **ReceiveAndSendReply** template to the workflow designer. This creates a <xref:System.Activities.Statements.Sequence> activity with a **Receive** activity followed by a <xref:System.ServiceModel.Activities.SendReply> activity as shown in the following illustration.  
  
     ![Screenshot that shows the ReceiveAndSendReply template.](./media/how-to-create-a-workflow-service-with-messaging-activities/receiveandsendreply-template.jpg)  
  
     Notice that the <xref:System.ServiceModel.Activities.SendReply> activity’s <xref:System.ServiceModel.Activities.SendReply.Request%2A> property is set to `Receive`, the name of the <xref:System.ServiceModel.Activities.Receive> activity to which the <xref:System.ServiceModel.Activities.SendReply> activity is replying.  
  
3. In the <xref:System.ServiceModel.Activities.Receive> activity type `Echo` into the textbox labeled **OperationName**. This defines the name of the operation the service implements.  
  
     ![Screenshot that shows where to specify the operation name.](./media/how-to-create-a-workflow-service-with-messaging-activities/define-operation-name.jpg)  
  
4. With the <xref:System.ServiceModel.Activities.Receive> activity selected, open the properties window if not already open by clicking the **View** menu and selecting **Properties Window**. In the **Properties Window** scroll down until you see **CanCreateInstance** and click the checkbox as shown in the following illustration. This setting enables the workflow service host to create a new instance of the service (if needed) when a message is received.  
  
     ![Screenshot that shows the CanCreateInstance property.](./media/how-to-create-a-workflow-service-with-messaging-activities/cancreateinstance-property.jpg)  
  
5. Select the <xref:System.Activities.Statements.Sequence> activity and click the **Variables** button in the lower left corner of the designer. This displays the variables editor. Click the **Create Variable** link to add a variable to store the string sent to the operation. Name the variable `msg` and set its **Variable** type to String as shown in the following illustration.  
  
     ![Screenshot that shows how to add a variable.](./media/how-to-create-a-workflow-service-with-messaging-activities/add-variable-msg-string.jpg)  
  
     Click the **Variables** button again to close the variables editor.  
  
6. Click the **Define..** link in the **Content** text box in the <xref:System.ServiceModel.Activities.Receive> activity to display the **Content Definition** dialog. Select the **Parameters** radio button, click the **Add new Parameter** link, type `inMsg` in the **name** text box, select **String** in the **Type** drop down list box, and type `msg` in the **Assign To** text box as shown in the following illustration.  
  
     ![Screenshot that shows adding Parameters content.](./media/how-to-create-a-workflow-service-with-messaging-activities/adding-parameters-content.jpg)  
  
     This specifies that the Receive activity receives string parameter and that data is bound to the `msg` variable. Click **OK** to close the **Content Definition** dialog.  
  
7. Click the **Define...** link in the **Content** box in the <xref:System.ServiceModel.Activities.SendReply> activity to display the **Content Definition** dialog. Select the **Parameters** radio button, click the **Add new Parameter** link, type `outMsg` in the **name** textbox, select **String** in the **Type** dropdown list box, and `msg` in the **Value** text box as shown in the following illustration.  
  
     ![Screenshot that shows how to add the outMsg parameter.](./media/how-to-create-a-workflow-service-with-messaging-activities/outmsg-parameters-content.jpg)  
  
     This specifies that the <xref:System.ServiceModel.Activities.SendReply> activity sends a message or message contract type and that data is bound to the `msg` variable. Because this is a <xref:System.ServiceModel.Activities.SendReply> activity, this means the data in `msg` is used to populate the message the activity sends back to the client. Click **OK** to close the **Content Definition** dialog.  
  
8. Save and build the solution by clicking the **Build** menu and selecting **Build Solution**.  
  
## Configure the Workflow Service Project  

 The workflow service is complete. This section explains how to configure the workflow service solution to make it easy to host and run. This solution uses the ASP.NET Development Server to host the service.  
  
#### To set project start up options  
  
1. In the **Solution Explorer**, right-click **MyWFService** and select **Properties** to display the **Project Properties** dialog.  
  
2. Select the **Web** tab and select **Specific Page** under **Start Action** and type `Service1.xamlx` in the text box as shown in the following illustration.  
  
     ![Screenshot that shows the project properties dialog.](./media/how-to-create-a-workflow-service-with-messaging-activities/project-properties-dialog.jpg)  
  
     This hosts the service defined in Service1.xamlx in the ASP.NET Development Server.  
  
3. Press Ctrl + F5 to launch the service. The ASP.NET Development Server icon is displayed in the lower right side of the desktop as shown in the following image.  
  
     ![Screenshot that shows the ASP.NET Developer Server icon.](./media/how-to-create-a-workflow-service-with-messaging-activities/asp-net-dev-server-icon.jpg)  
  
     In addition, Internet Explorer displays the WCF Service Help Page for the service.  
  
     ![Screenshot that shows the WCF Service Help Page.](./media/how-to-create-a-workflow-service-with-messaging-activities/wcf-service-help-page.jpg)  
  
4. Continue on to the [How To: Access a Service From a Workflow Application](how-to-access-a-service-from-a-workflow-application.md) topic to create a workflow client that calls this service.  
  
## See also

- [Workflow Services](workflow-services.md)
- [Hosting Workflow Services Overview](hosting-workflow-services-overview.md)
- [Messaging Activities](messaging-activities.md)
