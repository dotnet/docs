---
title: "Error handling"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c948841a-7db9-40ae-9b78-587d216cbcaf
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Error handling
## Error Handling in Windows Communication Foundation  
 When a service encounters an unexpected exception or error, there are multiple ways to design an exception-handling solution. While there is no single "correct" or "best practice" error-handling solution, there are multiple valid paths for one to consider. It is normally recommended that one implement a hybrid solution that combines multiple approaches from the list below, depending on the complexity of the WCF implementation, the type and frequency of the exceptions, the handled vs. unhandled nature of the exceptions, and any associated tracing, logging, or policy requirements.  
  
 These solutions are explained more deeply in the rest of this section.  
  
### The Microsoft Enterprise Library  
 The Microsoft Enterprise Library Exception Handling Application Block helps implement common design patterns and create a consistent strategy for processing exceptions that occur in all architectural layers of an enterprise application. It is designed to support the typical code contained in catch statements in application components. Instead of repeating this code (such as code that logs exception information) in identical catch blocks throughout an application, the Exception Handling Application Block allows developers to encapsulate this logic as reusable exception handlers.  
  
 This Library includes out-of-the-box a Fault Contract Exception Handler. This exception handler is designed for use at Windows® Communication Foundation (WCF) service boundaries, and generates a new Fault Contract from the exception.  
  
 Application blocks aim to incorporate commonly used best practices and provide a common approach for exception handling throughout your application. On the other hand, custom error handlers and fault contracts developed on one’s own can also be very useful. For instance, custom error handlers provide an excellent opportunity to automatically promote all exceptions to FaultExceptions and also to add logging capabilities to your application.  
  
 For more information, please see [Microsoft Enterprise Library](http://msdn.microsoft.com/library/ff632023.aspx).  
  
### Dealing with Expected Exceptions  
 The proper course of action is to catch expected exceptions in every operation or relevant extensibility point, decide whether they can be recovered from, and return the proper custom fault in a FaultException\<T>  
  
### Dealing with Unexpected Exceptions using an IErrorHandler  
 To deal with unexpected exceptions, the recommended course of action is to "hook" an IErrorHandler. Error handlers only catch exceptions at the WCF runtime level (the "service model" layer), not at the channel layer. The only way to hook an IErrorHandler at the channel level is to create a custom channel, which is not recommended in most scenarios.  
  
 An "unexpected exception" is generally neither an irrecoverable exception nor a processing exception; it is, instead, an unexpected user exception. An irrecoverable exception (such as an out-of-memory exception) – one generally handled by the [Service Model Exception Handler](http://msdn.microsoft.com/library/system.servicemodel.dispatcher.exceptionhandler.aspx) automatically – cannot generally be handled gracefully, and the only reason to handle such an exception at all may be do additional logging or to return a standard exception to the client. A processing exception occurs in the processing of the message – for example, at the serialization, encoder, or formatter level – generally cannot be handled at an IErrorHandler, because it is generally either too early or too late for the error handler to intervene by the time these exceptions occur. Similarly, transport exceptions cannot be handled at an IErrorHandler.  
  
 With an IErrorHandler, you can explicitly control the behavior of your application when an exception is thrown. You may:  
  
1.  Decide whether or not to send a fault to the client  
  
2.  Replace an exception with a fault  
  
3.  Replace a fault with another fault  
  
4.  Perform logging or tracing  
  
5.  Perform other custom activities  
  
 One can install a custom error handler by adding it to the ErrorHandlers property of the channel dispatchers for your service.  It is possible to have more than one error handler and they are called in the order they are added to this collection.  
  
 IErrorHandler.ProvideFault controls the fault message that is sent to the client. This method is called regardless of the type of the exception thrown by an operation in your service. If no operation is performed here, WCF assumes its default behaviour and continues as if there were no custom error handlers in place.  
  
 One area that you could perhaps use this approach is when you want to create a central place for converting exceptions to faults before they are sent to the client (ensuring that the instance is not disposed and the channel is not moved to the Faulted state).  
  
 The IErrorHandler.HandleError method is usually used to implement error-related behaviors such as error logging, system notifications, shutting down the application, etc. IErrorHandler.HandleError can be called at multiple places inside the service, and depending on where the error is thrown, the HandleError method may or may not be called by the same thread as the operation; no guarantees are made in this regard.  
  
### Dealing with Exceptions outside WCF  
 Often, configuration exceptions, database connection string exceptions, and other similar exceptions may occur within the context of a WCF application, but are themselves are not exceptions caused by the service model or the web service itself. These exceptions are "regular" exceptions external to the web service, and should be handled just as other external exceptions in the environment are to be handled.  
  
### Tracing exceptions  
 Tracing is the only "catch-all" place where one can potentially see all exceptions. For more information on tracing and logging exceptions, see Tracing and Logging.  
  
### URI template errors when using WebGetAttribute and WebInvokeAttribute  
 The WebGet and WebInvoke attributes allow you to specify a URI template that maps components of the request address to operation parameters. For example, the URI template "weather/{state}/{city}" maps the request address into literal tokens, a parameter named state, and a parameter named city. These parameters might then be bound by name to some of the formal parameters of the operation.  
  
 The template parameters appear in the form of strings within the URI while the formal parameters of a typed contract might be of non-string types. Therefore, a conversion needs to take place before the operation can be invoked. A [table of conversion formats](http://msdn.microsoft.com/library/bb412172.aspx) is available.  
  
 However, if the conversion fails, then there's no way to let the operation know that something has gone wrong. The type conversion instead surfaces in the form of a dispatch failure.  
  
 A type conversion dispatch failure can be inspected the same as with many other types of dispatch failures by installing an error handler. The IErrorHandler extensibility point is called to handle service-level exceptions. From there, the response to be sent back to the caller – as well as perform any custom tasks and reporting – may be chosen.  
  
## See Also  
 [Basic WCF Error Handling](http://msdn.microsoft.com/library/gg281715.aspx)
