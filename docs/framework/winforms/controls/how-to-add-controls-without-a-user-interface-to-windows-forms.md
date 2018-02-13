---
title: "How to: Add Controls Without a User Interface to Windows Forms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
f1_keywords: 
  - "NonVisualSelection"
helpviewer_keywords: 
  - "invisible controls [Windows Forms]"
  - "Windows Forms controls, adding to form"
  - "controls [Windows Forms], nonvisual"
  - "Windows Forms controls, nonvisual"
  - "nonvisual controls [Windows Forms]"
ms.assetid: 52134d9c-cff6-4eed-8e2b-3d5eb3bd494e
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Controls Without a User Interface to Windows Forms
A nonvisual control (or component) provides functionality to your application. Unlike other controls, components do not provide a user interface to the user and thus do not need to be displayed on the Windows Forms Designer surface. When a component is added to a form, the Windows Forms Designer displays a resizable tray at the bottom of the form where all components are displayed. Once a control has been added to the component tray, you can select the component and set its properties as you would any other control on the form.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To add a component to a Windows Form  
  
1.  Open the form. For details, see [How to: Display Windows Forms in the Designer](http://msdn.microsoft.com/library/bf3f1e5b-ea07-4529-85c6-6af3ded0cec5).  
  
2.  In the **Toolbox**, click a component and drag it to your form.  
  
     Your component appears in the component tray.  
  
 Furthermore, components can be added to a form at run time. This is a common scenario, especially because components do not have a visual expression, unlike controls that have a user interface. In the example below, a <xref:System.Windows.Forms.Timer> component is added at run time. (Note that [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] contains a number of different timers; in this case, use a Windows Forms <xref:System.Windows.Forms.Timer> component. For more information about the different timers in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)], see [Introduction to Server-Based Timers](http://msdn.microsoft.com/library/adc0bc0a-a519-4812-bafc-fb9d1a5801fc).)  
  
> [!CAUTION]
>  Components often have control-specific properties that must be set for the component to function effectively. In the case of the <xref:System.Windows.Forms.Timer> component below, you set the `Interval` property. Be sure, when adding components to your project, that you set the properties necessary for that component.  
  
#### To add a component to a Windows Form programmatically  
  
1.  Create an instance of the <xref:System.Windows.Forms.Timer> class in code.  
  
2.  Set the `Interval` property to determine the time between ticks of the timer.  
  
3.  Configure any other necessary properties for your component.  
  
     The following code shows the creation of a <xref:System.Windows.Forms.Timer> with its `Interval` property set.  
  
    ```vb  
    Public Sub CreateTimer()  
       Dim timerKeepTrack As New System.Windows.Forms.Timer  
       timerKeepTrack.Interval = 1000  
    End Sub  
    ```  
  
    ```csharp  
    public void createTimer()  
    {  
       System.Windows.Forms.Timer timerKeepTrack = new  
           System.Windows.Forms.Timer();  
       timerKeepTrack.Interval = 1000;  
    }  
    ```  
  
    ```cpp  
    public:  
       void createTimer()  
       {  
          System::Windows::Forms::Timer^ timerKeepTrack = gcnew  
             System::Windows::Forms::Timer();  
          timerKeepTrack->Interval = 1000;  
       }  
    ```  
  
    > [!IMPORTANT]
    >  You might expose your local computer to a security risk through the network by referencing a malicious UserControl. This would only be a concern in the case of a malicious person creating a damaging custom control, followed by you mistakenly adding it to your project.  
  
## See Also  
 [Windows Forms Controls](../../../../docs/framework/winforms/controls/index.md)  
 [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md)  
 [How to: Add ActiveX Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-activex-controls-to-windows-forms.md)  
 [How to: Copy Controls Between Windows Forms](../../../../docs/framework/winforms/controls/how-to-copy-controls-between-windows-forms.md)  
 [Putting Controls on Windows Forms](../../../../docs/framework/winforms/controls/putting-controls-on-windows-forms.md)  
 [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](../../../../docs/framework/winforms/controls/labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 [Windows Forms Controls by Function](../../../../docs/framework/winforms/controls/windows-forms-controls-by-function.md)
