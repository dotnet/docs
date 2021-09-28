---
description: "Learn more about: How To: Access a Service From a Workflow Application"
title: "How To: Access a Service From a Workflow Application"
ms.date: "03/30/2017"
ms.assetid: 925ef8ea-5550-4c9d-bb7b-209e20c280ad
---
# How To: Access a Service From a Workflow Application

This topic describes how to call a workflow service from a workflow console application. It depends on completion of the [How to: Create a Workflow Service with Messaging Activities](how-to-create-a-workflow-service-with-messaging-activities.md) topic. Although this topic describes how to call a workflow service from a workflow application, the same methods can be used to call any Windows Communication Foundation (WCF) service from a workflow application.

### Create a Workflow Console Application Project

1. Start Visual Studio 2012.

2. Load the MyWFService project you created in the [How to: Create a Workflow Service with Messaging Activities](how-to-create-a-workflow-service-with-messaging-activities.md) topic.

3. Right click the **MyWFService** solution in the **Solution Explorer** and select **Add**, **New Project**. Select **Workflow** in the **Installed Templates** and **Workflow Console Application** from the list of project types. Name the project MyWFClient and use the default location as shown in the following illustration.

     ![Add New Project Dialog](./media/how-to-access-a-service-from-a-workflow-application/add-new-project-dialog.jpg)

     Click the **OK** button to dismiss the **Add New Project Dialog**.

4. After the project is created, the Workflow1.xaml file is opened in the designer. Click the **Toolbox** tab to open the toolbox if it is not already open and click the pushpin to keep the toolbox window open.

5. Press **Ctrl**+**F5** to build and launch the service. As before, the ASP.NET Development Server is launched and Internet Explorer displays the WCF Help Page. Notice the URI for this page as you must use it in the next step.

     ![IE displaying WCF help page and URI](./media/how-to-access-a-service-from-a-workflow-application/ie-wcf-help-page-uri.jpg)

6. Right click the **MyWFClient** project in the **Solution Explorer** and select **Add** > **Service Reference**. Click the **Discover** button to search the current solution for any services. Click the triangle next to Service1.xamlx in the Services list. Click the triangle next to Service1 to list the contracts implemented by the Service1 service. Expand the **Service1** node in the **Services** list. The Echo operation is displayed in the **Operations** list as shown in the following illustration.

     ![Add Service Reference Dialog](./media/how-to-access-a-service-from-a-workflow-application/add-service-reference.jpg)

     Keep the default namespace and click **OK** to dismiss the **Add Service Reference** dialog. The following dialog is displayed.

     ![Add Service Reference Notification dialog](./media/how-to-access-a-service-from-a-workflow-application/add-service-reference-dialog.jpg)

     Click **OK** to dismiss the dialog. Next, press CTRL+SHIFT+B to build the solution. Notice in the toolbox a new section has been added called **MyWFClient.ServiceReference1.Activities**. Expand this section and notice the Echo activity that has been added as shown in the following illustration.

     ![Echo activity in the toolbox](./media/how-to-access-a-service-from-a-workflow-application/echo-activity-toolbox.jpg)

7. Drag and drop a <xref:System.Activities.Statements.Sequence> activity onto the designer surface. It is under the **Control Flow** section of the toolbox.

8. With the <xref:System.Activities.Statements.Sequence> activity in focus, click the **Variables** link and add a string variable named `inString`. Give the variable a default value of `"Hello, world"` as well as a string variable named `outString` as shown in the following diagram.

     ![Adding an inString variable](./media/how-to-access-a-service-from-a-workflow-application/add-instring-variable.jpg)

9. Drag and drop an **Echo** activity into the <xref:System.Activities.Statements.Sequence>. In the properties window bind the `inMsg` argument to the `inString` variable and the `outMsg` argument to the `outString` variable as shown in the following illustration. This passes in the value of the `inString` variable to the operation and then takes the return value and places it in the `outString` variable.

     ![Binding the arguments to variables](./media/how-to-access-a-service-from-a-workflow-application/bind-arguments-variables.jpg)

10. Drag and drop a **WriteLine** activity below the **Echo** activity to display the string returned by the service call. The **WriteLine** activity is located in the **Primitives** node in the toolbox. Bind the **Text** argument of the **WriteLine** activity to the `outString` variable by typing `outString` into the text box on the **WriteLine** activity. The workflow should now look like the following illustration.

     ![The complete client workflow](./media/how-to-access-a-service-from-a-workflow-application/complete-client-workflow.jpg)

11. Right-click the MyWFService solution and select **Set Startup Projects ...**. Select the **Multiple startup projects** radio button and select **Start** for each project in the **Action** column as shown in the following illustration.

     ![Startup projects options](./media/how-to-access-a-service-from-a-workflow-application/startup-project-options.jpg)

12. Press Ctrl + F5 to launch both the service and the client. The ASP.NET Development Server hosts the service, Internet Explorer displays the WCF help page, and the client workflow application is launched in a console window and displays the string returned from the service ("Hello, world").

## See also

- [Workflow Services](workflow-services.md)
- [How to: Create a Workflow Service with Messaging Activities](how-to-create-a-workflow-service-with-messaging-activities.md)
- [Consuming a WCF Service from a Workflow in a Web Project](/archive/blogs/endpoint/how-to-consume-a-wcf-service-from-a-wf4-workflow)
