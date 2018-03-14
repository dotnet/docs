---
title: "Error handling in asynchronous activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e8f8ce2b-50c9-4e44-b187-030e0cf30a5d
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Error handling in asynchronous activities
Providing error handling in an <xref:System.Activities.AsyncCodeActivity> involves routing the error through the activity’s callback system. This topic describes how to get an error that is thrown in an asynchronous operation back to the host, using the SendMail activity sample.  
  
## Returning an error thrown in an asynchronous activity back to the host  
 Routing an error in an asynchronous operation back to the host in the SendMail activity sample involves the following steps:  
  
-   Add an Exception property to the `SendMailAsyncResult` class.  
  
-   Copy the thrown error to that property in the `SendCompleted` event handler.  
  
-   Throw the exception in the `EndExecute` event handler.  
  
 The resulting code is as follows.  
  
```csharp  
class SendMailAsyncResult : IAsyncResult  
        {  
            …  
            public Exception Error { get; set; }   
            …  
            void SendCompleted(object sender, AsyncCompletedEventArgs e)  
            {  
                Error = e.Error;  
                this.asyncWaitHandle.Set();  
                callback(this);  
            }  
         }  
  
    public sealed class SendMail: AsyncCodeActivity  
    {  
         …  
        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)  
        {  
            SendMailAsyncResult sendMailResult = result as SendMailAsyncResult;  
            if (sendMailResult != null && sendMailResult.Error != null)  
                throw sendMailResult.Error;   
        }  
    }  
```
