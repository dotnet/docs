---
title: "How to: Call a Web Service Asynchronously (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "asynchronous calls [Visual Basic]"
  - "Web services [Visual Basic], accessing"
ms.assetid: ff8046f4-f1f2-4d8b-90b7-95e3f7415418
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Call a Web Service Asynchronously (Visual Basic)
This example attaches a handler to a Web service's asynchronous handler event, so that it can retrieve the result of an asynchronous method call. This example used the DemoTemperatureService Web service at http://www.xmethods.net.  
  
 When you reference a Web service in your project in the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] Integrated Development Environment (IDE), it is added to the `My.WebServices` object, and the IDE generates a client proxy class to access a specified Web service  
  
 The proxy class allows you to call the Web service methods synchronously, where your application waits for the function to complete. In addition, the proxy creates additional members to help call the method asynchronously. For each Web service function, *NameOfWebServiceFunction*, the proxy creates a *NameOfWebServiceFunction*`Async` subroutine, a *NameOfWebServiceFunction*`Completed` event, and a *NameOfWebServiceFunction*`CompletedEventArgs` class. This example demonstrates how to use the asynchronous members to access the `getTemp` function of the DemoTemperatureService Web service.  
  
> [!NOTE]
>  This code does not work in Web applications, because ASP.NET does not support the `My.WebServices` object.  
  
### To call a Web service asynchronously  
  
1.  Reference the DemoTemperatureService Web service at http://www.xmethods.net. The address is  
  
    ```  
    http://www.xmethods.net/sd/2001/DemoTemperatureService.wsdl  
    ```  
  
2.  Add an event handler for the `getTempCompleted` event:  
  
    ```  
    Private Sub getTempCompletedHandler(ByVal sender As Object,   
        ByVal e As net.xmethods.www.getTempCompletedEventArgs)  
  
        MsgBox("Temperature: " & e.Result)  
    End Sub  
    ```  
  
    > [!NOTE]
    >  You cannot use the `Handles` statement to associate an event handler with the `My.WebServices` object's events.  
  
3.  Add a field to track if the event handler has been added to the `getTempCompleted` event:  
  
    ```  
    Private handlerAttached As Boolean = False  
    ```  
  
4.  Add a method to add the event handler to the `getTempCompleted` event, if necessary, and to call the `getTempAsynch` method:  
  
    ```  
    Sub CallGetTempAsync(ByVal zipCode As Integer)  
        If Not handlerAttached Then  
            AddHandler My.WebServices.  
                TemperatureService.getTempCompleted,   
                AddressOf Me.TS_getTempCompleted  
            handlerAttached = True  
        End If  
        My.WebServices.TemperatureService.getTempAsync(zipCode)  
    End Sub  
    ```  
  
     To call the `getTemp` Web method asynchronously, call the `CallGetTempAsync` method. When the Web method finishes, its return value is passed to the `getTempCompletedHandler` event handler.  
  
## See Also  
 [Accessing Application Web Services](../../../visual-basic/developing-apps/programming/accessing-application-web-services.md)  
 [My.WebServices Object](../../../visual-basic/language-reference/objects/my-webservices-object.md)
