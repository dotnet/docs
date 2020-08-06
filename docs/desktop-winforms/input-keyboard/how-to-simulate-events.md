---
title: "Simulate keyboard events"
description: Learn how to simulate keyboard events with the 
ms.date: "08/03/2020"
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keyboards [Windows Forms], event simulation"
  - "user input [Windows Forms], simulating"
  - "SendKeys [Windows Forms], using"
---
# How to simulate keyboard events (Windows Forms .NET)

Windows Forms provides a few options for programmatically simulating keyboard input. This article provides an overview of these options.

## Use SendKeys

Windows Forms provides the <xref:System.Windows.Forms.SendKeys?displayProperty=fullName> class for sending keystrokes to the active application. There are two methods to send keystrokes to an application: <xref:System.Windows.Forms.SendKeys.Send%2A?displayProperty=nameWithType> and <xref:System.Windows.Forms.SendKeys.SendWait%2A?displayProperty=nameWithType>. The difference between the two methods is that `SendWait` blocks the current thread when the keystroke is sent, waiting for a response, while `Send` doesn't. For more information about `SendWait`, see [To send a keystroke to a different application](#to-send-a-keystroke-to-a-different-application).

> [!CAUTION]
> If your application is intended for international use with a variety of keyboards, the use of <xref:System.Windows.Forms.SendKeys.Send%2A?displayProperty=nameWithType> could yield unpredictable results and should be avoided.

Behind the scenes, `SendKeys` uses an older Windows implementation for sending input, which may fail on modern Windows where it's expected that the application isn't running with administrative rights. If the older implementation fails, the code automatically tries the newer Windows implementation for sending input. Additionally, when the <xref:System.Windows.Forms.SendKeys> class uses the new implementation, the <xref:System.Windows.Forms.SendKeys.SendWait%2A> method no longer blocks the current thread when sending keystrokes to another application.

> [!IMPORTANT]
> If your application relies on consistent behavior regardless of the operating system, you can force the <xref:System.Windows.Forms.SendKeys> class to use the new implementation by adding the following application setting to your app.config file.
>
> ```xml
> <appSettings>
>   <add key="SendKeys" value="SendInput"/>
> </appSettings>
> ```
>
> To force the <xref:System.Windows.Forms.SendKeys> class to _only_ use the previous implementation, use the value `"JournalHook"` instead.

### To send a keystroke to the same application

Call the <xref:System.Windows.Forms.SendKeys.Send%2A?displayProperty=nameWithType> or <xref:System.Windows.Forms.SendKeys.SendWait%2A?displayProperty=nameWithType> method of the <xref:System.Windows.Forms.SendKeys> class. The specified keystrokes will be received by the active control of the application.

The following code example uses `Send` to simulate pressing the <kbd>ALT</kbd> and <kbd>DOWN</kbd> keys together. These keystrokes cause the <xref:System.Windows.Forms.ComboBox> control to display its dropdown. This example assumes a <xref:System.Windows.Forms.Form> with a <xref:System.Windows.Forms.Button> and <xref:System.Windows.Forms.ComboBox>.

:::code language="csharp" source="snippets/how-to-simulate-events/csharp/Form1.cs" id="ShowDropDown":::
:::code language="vb" source="snippets/how-to-simulate-events/vb/Form1.vb" id="ShowDropDown":::

### To send a keystroke to a different application

The <xref:System.Windows.Forms.SendKeys.Send%2A?displayProperty=nameWithType> and <xref:System.Windows.Forms.SendKeys.SendWait%2A?displayProperty=nameWithType> methods send keystrokes to the active application, which is usually the application you're sending keystrokes from. To send keystrokes to another application, you first need to activate it. Because there's no managed method to activate another application, you must use native Windows methods to focus the other application. The following code example uses platform invoke to call the `FindWindow` and `SetForegroundWindow` methods to activate the Calculator application window, and then calls `Send` to issue a series of calculations to the Calculator application.

The following code example uses `Send` to simulate pressing keys into the Windows 10 Calculator application. It first searches for an application window with title of `Calculator` and then activates it. Once activated, the keystrokes are sent to calculate 10 plus 10.

:::code language="csharp" source="snippets/how-to-simulate-events/csharp/Form2.cs" id="Calculator":::
:::code language="vb" source="snippets/how-to-simulate-events/vb/Form2.vb" id="Calculator":::

## Use OnEventName methods

The easiest way to simulate keyboard events is to call a method on the object that raises the event. Most events have a corresponding method that invokes them, named in the pattern of `On` followed by `EventName`, such as `OnKeyPress`. This option is only possible within custom controls or forms, because these methods are protected and can't be accessed from outside the context of the control or form.

These protected methods are available to simulate keyboard events.

- `OnKeyDown`
- `OnKeyPress`
- `OnKeyUp`

For more information about these events, see [Using keyboard events (Windows Forms .NET)](events.md).

## See also

- [Overview of using the keyboard (Windows Forms .NET)](overview.md)
- [Using keyboard events (Windows Forms .NET)](events.md)
- [Using mouse events (Windows Forms .NET)](../input-mouse/events.md)
- <xref:System.Windows.Forms.SendKeys>
- <xref:System.Windows.Forms.Keys>
- <xref:System.Windows.Forms.Control.KeyDown>
- <xref:System.Windows.Forms.Control.KeyPress>
