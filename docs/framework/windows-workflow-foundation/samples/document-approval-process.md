---
title: "Document Approval Process"
description: This sample demonstrates many Windows Workflow Foundation and Windows Communication Foundation features in a document-approval process scenario.
ms.date: "03/30/2017"
ms.assetid: 9b240937-76a7-45cd-8823-7f82c34d03bd
---
# Document Approval Process

The [DocumentApprovalProcess sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/application/DocumentApprovalProcess/CS) demonstrates the use of many Windows Workflow Foundation (WF) and Windows Communication Foundation (WCF) features together. Together they implement a document approval process scenario. A client application can submit documents for approval and approve documents. An approval manager application exists to facilitate communications between clients and to enforce the rules of the approval process. The approval process is a workflow that can execute several types of approval. Activities exist to get a single approval, a quorum approval (a percentage of set of approvers), and a complex approval process that consists of a quorum and single approval in a sequence.

## Sample Details

The following graphic demonstrates the document approval process workflow:

![A document approval process workflow](./media/document-approval-process/document-approval-process.jpg)

From the client's perspective, the approval process functions as follows:

1. A client subscribes to be a user in the approval process system.

2. A WCF client sends to a WCF service hosted by the approval manager application.

3. A unique user ID is returned to the client. The client can now participate in approval processes.

4. Once joined, a client can send a document for approval using single, quorum or complex approval processes.

5. A button in the client's interface is clicked, starting a workflow instance in a client Workflow Service Host.

6. The workflow sends an approval request to the approval manager application.

7. The workflow manager starts a workflow on its own side to represent an approval process.

8. Once the manager approval workflow executes, the results are sent back to the client.

9. The client displays the results.

10. A client may receive an approval request and respond to the request at any point in time.

11. A WCF service hosted on the client can receive an approval request from the approval manager application.

12. The document information is presented on the client for review.

13. The user can approve or reject the document.

14. A WCF client is used to send an approval response back to the approval manager application.

From the approval manager application's point of view, the approval process functions as follows:

1. A client requests to participate to the approval process system.

2. A WCF service on the approval manager receives a request to be part of the approval process system.

3. A unique ID is generated for the client. The user information is stored in a database.

4. The unique ID is sent back to the user.

5. An approval request is receive. The approval manager executes an approval process.

6. An approval request is received by the approval manager, starting a new workflow.

7. Depending on the type of request (simple, quorum, or complex) a different activity is executed.

8. Send and Receive activities with correlation are used to send the approval request to the client for review and receive the response.

9. The result of the approval process workflow is sent to the client.

## Using the Sample

### To set up the database

1. From a Visual Studio command prompt opened with Administrator privileges, navigate to this DocumentApprovalProcess folder and run Setup.cmd.

### To set up the application

1. Using Visual Studio, open the DocumentApprovalProcess.sln solution file.

2. To build the solution, press CTRL+SHIFT+B.

3. To run the solution, launch the Approval Manager Application by right-clicking the ApprovalManager project in the **Solution Explorer** and clicking **Debug**->**Start** new instance from the right-click menu.

    Wait for the manager's output to let you know that it is ready.

### To run the single approval scenario

1. Open a command prompt with administrator permission.

2. Navigate to the directory that contains the solution.

3. Navigate to the ApprovalClient\Bin\Debug folder and execute two instances of ApprovalClient.exe.

4. Click **discover**, wait until the **subscribe** button is enabled.

5. Type any user name and click **subscribe**. For one client, use `UserType1` and the other type `UserType2`.

6. In the `UserType1` client, select the single approval type from the drop down menu and type a document name and content. Click **Request Approval**.

7. In the `UserType2` client, a document awaiting approval appears. Select it and press **approve** or **reject**. The results should show in the `UserType1` client.

### To run the quorum approval scenario

1. Open a command prompt with administrator permission.

2. Navigate to the directory that contains the solution.

3. Navigate to the ApprovalClient\Bin\Debug folder and execute three instances of ApprovalClient.exe.

4. Click **discover**, wait until the **subscribe** button is enabled.

5. Type any user name and click **subscribe**. For one client use `UserType1` and the other two type `UserType2`.

6. In the `UserType1` client, select the quorum approval type from the drop down menu and type a document name and content. Click **Request Approval**. This requests that the two `UserType2` clients approve or reject the document. While both `UserType2` clients must respond, only one client must approve the document for it to be approved.

7. In the `UserType2` clients, a document awaiting approval appears. Select it and press **approve** or **reject**. The results should show in the `UserType1` client.

### To run the complex approval scenario

1. Open a command prompt with administrator permission.

2. Navigate to the directory that contains the solution.

3. Navigate to the ApprovalClient\Bin\Debug folder and execute four instances of ApprovalClient.exe.

4. Click **discover**, wait until the **subscribe** button is enabled.

5. Type any user name and click **subscribe**. For one client use `UserType1`, in two uses type `UserType2`, and in the last use `UserType3`.

6. In the `UserType1` client, select the single approval type from the drop down menu and type a document name and content. Click **Request Approval**.

7. In the `UserType2` clients, a document awaiting approval appears. Select it and press **approve**, the document is passed to the `UserType3` client.

    If the document is approved by the first `UserType2` quorum, the document is passed to the `UserType3` client.

8. Approve or reject the document from the `UserType3` client. The results should show in the `UserType1` client.

### To clean up

1. From a Visual Studio command prompt, navigate to the DocumentApprovalProcess folder and run Cleanup.cmd.
