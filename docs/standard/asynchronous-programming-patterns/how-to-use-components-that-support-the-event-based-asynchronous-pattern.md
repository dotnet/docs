---
description: "Learn more about: How to: Use Components That Support the Event-based Asynchronous Pattern"
title: "How to: Use Components That Support the Event-based Asynchronous Pattern"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Event-based Asynchronous Pattern"
  - "ProgressChangedEventArgs class"
  - "BackgroundWorker component"
  - "events [.NET], asynchronous"
  - "Asynchronous Pattern"
  - "AsyncOperationManager class"
  - "threading [.NET], asynchronous features"
  - "components [.NET], asynchronous"
  - "AsyncOperation class"
  - "threading [Windows Forms], asynchronous features"
  - "AsyncCompletedEventArgs class"
ms.topic: how-to
---
# How to: Use Components That Support the Event-based Asynchronous Pattern

Many components provide you with the option of performing their work asynchronously. The <xref:System.Media.SoundPlayer> and <xref:System.Windows.Forms.PictureBox> components, for example, enable you to load sounds and images "in the background" while your main thread continues running without interruption.  
  
 Using asynchronous methods on a class that supports the [Event-based Asynchronous Pattern Overview](event-based-asynchronous-pattern-overview.md) can be as simple as attaching an event handler to the component's _MethodName_**Completed** event, just as you would for any other event. When you call the _MethodName_**Async** method, your application will continue running without interruption until the _MethodName_**Completed** event is raised. In your event handler, you can examine the <xref:System.ComponentModel.AsyncCompletedEventArgs> parameter to determine if the asynchronous operation successfully completed or if it was canceled.  
  
 For more information about using event handlers, see [Event Handlers Overview](/dotnet/desktop/winforms/event-handlers-overview-windows-forms).  
  
 The following procedure shows how to use the asynchronous image-loading capability of a <xref:System.Windows.Forms.PictureBox> control.  
  
### To enable a PictureBox control to asynchronously load an image  
  
1. Create an instance of the <xref:System.Windows.Forms.PictureBox> component in your form.  
  
2. Assign an event handler to the <xref:System.Windows.Forms.PictureBox.LoadCompleted> event.  
  
     Check for any errors that may have occurred during the asynchronous download here. This is also where you check for cancellation.  
  
     [!code-csharp[System.Windows.Forms.PictureBox.LoadAsync#2](snippets/component-that-supports-the-event-based-asynchronous-pattern/csharp/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.PictureBox.LoadAsync#2](snippets/component-that-supports-the-event-based-asynchronous-pattern/vb/Form1.vb#2)]  
  
     [!code-csharp[System.Windows.Forms.PictureBox.LoadAsync#5](snippets/component-that-supports-the-event-based-asynchronous-pattern/csharp/Form1.cs#5)]
     [!code-vb[System.Windows.Forms.PictureBox.LoadAsync#5](snippets/component-that-supports-the-event-based-asynchronous-pattern/vb/Form1.vb#5)]  
  
3. Add two buttons, called `loadButton` and `cancelLoadButton`, to your form. Add <xref:System.Windows.Forms.Control.Click> event handlers to start and cancel the download.  
  
     [!code-csharp[System.Windows.Forms.PictureBox.LoadAsync#3](snippets/component-that-supports-the-event-based-asynchronous-pattern/csharp/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.PictureBox.LoadAsync#3](snippets/component-that-supports-the-event-based-asynchronous-pattern/vb/Form1.vb#3)]  
  
     [!code-csharp[System.Windows.Forms.PictureBox.LoadAsync#4](snippets/component-that-supports-the-event-based-asynchronous-pattern/csharp/Form1.cs#4)]
     [!code-vb[System.Windows.Forms.PictureBox.LoadAsync#4](snippets/component-that-supports-the-event-based-asynchronous-pattern/vb/Form1.vb#4)]  
  
4. Run your application.  
  
     As the image download proceeds, you can move the form freely, minimize it, and maximize it.  
  
## See also

- [How to: Run an Operation in the Background](/dotnet/desktop/winforms/controls/how-to-run-an-operation-in-the-background)
- [Event-based Asynchronous Pattern Overview](event-based-asynchronous-pattern-overview.md)
