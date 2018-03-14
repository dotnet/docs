---
title: "How to: Create a Workflow Service That Calls Another Workflow Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 99b3ee3e-aeb7-4e6f-8321-60fe6140eb67
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Workflow Service That Calls Another Workflow Service
It is sometimes necessary for a workflow service to obtain information from another workflow service.  This topic demonstrates how to call one workflow service from another. In this topic, we’ll create two workflow services; one that has a method that reverses the input string, and another that converts the input string to uppercase after reversing the string that uses the first service.  
  
### To create the Reverser workflow service  
  
1.  Run [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] as an administrator.  
  
2.  Select **File**, **New Project**. Under the **Workflow** node in the **Installed Templates** pane, select **WCF Workflow Service Application**. Name the solution `NestedServices` and then click **OK**.  
  
3.  Under **Servers**, make sure that **Use Local IIS Web Server** is selected. Click **Create Virtual Directory**. Click **OK** in the dialog box stating that the virtual directory was successfully created.  
  
4.  In Solution Explorer, rename Service1.xamlx to `StringReverserService.xamlx`.  
  
5.  On the **Project Properties** page for the new project, click the **Web** tab. Set the **Start Action** to **Specific Page**, and select StringReverserService.xamlx as the page to start.  
  
6.  Open StringReverserService.xamlx in the designer and delete the existing `ReceiveRequest` and `SendReply` activities, and then drag a `ReceiveAndSendReply` activity into the existing sequence activity.  
  
    1.  Set the **OperationName** to ReverseString.  
  
    2.  Set the **ServiceContractName** to IReverseString.  
  
    3.  Select the **CanCreateInstance** check box.  
  
7.  Select the **SequentialService** activity, and then click the **Variables** tab at the bottom of the designer. Create two new variables named StringToReverse and ReversedStringToReturn of type String.  
  
8.  Click the **Define** link in the **Receive** activity. Click the  **Parameters**, and create a parameter named InputString of type String that assigns to StringToReverse.  
  
9. Click the **Define** link in the **SendReplyToReceive** activity. Click the **Parameters**, and create a parameter named ReversedString of type String, assigned to ReversedStringToReturn.  
  
10. To implement the logic for the service, create a new class in the project called StringLibrary.  Replace the class definition with the following code.  
  
    ```  
    public class StringLibrary  
        {  
            public static String ReverseString(string StringToReverse)  
            {  
                char[] charArray = StringToReverse.ToCharArray();  
                Array.Reverse(charArray);  
                return new String(charArray);  
            }  
        }  
    ```  
  
11. To call the ReverseString method on the input, drag an **InvokeMethod** activity from the toolbox to the space between the **Receive** and **SendReply** activities. Set the properties of the activity as follows:  
  
    1.  **MethodName**: ReverseString  
  
    2.  **Result**: ReversedStringToReturn  
  
    3.  **Parameters**: Create a new parameter with a **Direction** of In, a **Type** of String, and a **Value** of StringToReverse.  
  
    4.  **TargetType**: NestedServices.StringLibrary  
  
12. Test the service by pressing F5. In the WCF Test Client that appears, double-click the ReverseString() method. In the Request pane, enter `Sample` for the Value of the InputString parameter. Click **Invoke**. The service should return "elpmaS".  
  
### To create the UpperCaser workflow service  
  
1.  Right-click the NestedServices project and select **Add**, **New Item**. In the **Workflow** node, select **WCF Workflow Service**, and name the new service `UpperCaserService`. Click **Add**. This should add a new workflow service called UpperCaserService.xamlx to the project.  
  
2.  Open UpperCaserService.xamlx in the designer and delete the existing **ReceiveRequest** and `SendReply` activities, and drag a `ReceiveAndSendReply` activity into the existing sequence activity.  
  
    1.  Set the **OperationName** to UpperCaseString.  
  
    2.  Set the **ServiceContractName** to IUpperCaseString.  
  
    3.  Select the **CanCreateInstance** check box.  
  
3.  Select the SequentialService activity, and then click the **Variables** tab at the bottom of the designer. Create three new variables named StringToUpper, StringToReverse, and StringToReturn of type String.  
  
4.  Click the **Define** link in the **Receive** activity. Click the **Parameters**, and create a parameter named InputString of type String that assigns to StringToUpper.  
  
5.  Click the **Define** link in the **SendReplyToReceive** activity. Click the **Parameters**, and create a parameter named ModifiedString of type String, assigned to StringToReturn.  
  
6.  To implement the logic for the service, create a new method in the StringLibrary class using the following code.  
  
    ```  
    public static String UpperCaseString(string StringToUpperCase)  
    {  
         return StringToUpperCase.ToUpper();  
  
    }  
    ```  
  
7.  To call the UpperCaseString method on the input, drag an **InvokeMethod** activity from the toolbox to the space between the **Receive** and **SendReply** activities. Set the properties of the activity as follows:  
  
    1.  **MethodName**: UpperCaseString  
  
    2.  **Result**: StringToReverse  
  
    3.  **Parameters**: Create a new parameter with a **Direction** of In, a **Type** of String, and a **Value** of StringToUpper.  
  
    4.  **TargetType**: NestedServices.StringLibrary  
  
8.  We’ll now call the first service on the modified string. Right-click the project and select **Add Service Reference**. Add a service reference to the service at http://localhost/NestedServices/StringReverserService.xamlx and build the project to create a custom activity to access the first Web service.  
  
9. Drag an instance of the new activity onto the workflow, between the **InvokeMethod** activity and the **SendReplyToReceive** activities. Assign the variable StringToReverse to the InputString property of the new activity, and the variable StringToReturn to the StringToReturn property.  
  
10. Open the Properties page for the NestedServices project, and change the **Specific Page** in the **Web** tab to UpperCaserService.xamlx.  
  
11. Test the service by pressing F5. In the WCF Test Client that appears, double-click the ReverseString() method. In the Request pane, enter `Sample` for the Value of the InputString parameter. Click **Invoke**. The service should return "ELPMAS".  
  
### To create a client to call the services  
  
1.  Add a new Console application project called Client to the solution.  
  
2.  Right-click the Client project and select **Add Service Reference**. In the window that appears, click **Discover**. Select StringReverserService.xamlx, and enter ReverseService as the namespace.  Click **OK**.  
  
3.  Replace the Main method in Program.cs with the following code.  
  
    ```  
    static void Main(string[] args)  
    {  
        Console.Write("Input string to process:");  
        String input = Console.ReadLine();  
        var service = new ReverseService.ReverseStringClient();  
        Console.WriteLine("Output from service: {0}", service.ReverseString(input));  
        Console.ReadKey();  
    }  
    ```
