---
title: "Accessibility Best Practices"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "best practices for accessibility"
  - "accessibility, best practices for"
ms.assetid: e6d5cd98-21a3-4b01-999c-fb953556d0e6
caps.latest.revision: 16
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Accessibility Best Practices
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 Implementing the following best practices in controls or applications will improve their accessibility for people who use [!INCLUDE[TLA#tla_at](../../../includes/tlasharptla-at-md.md)] devices. Many of these best practices focus on good [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] design. Each best practice includes implementation information for [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] controls or applications. In many cases, the work to meet these best practices is already included in [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] controls.  
  
<a name="Programmatic_Access"></a>   
## Programmatic Access  
 Programmatic access involves ensuring that all [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements are labeled, property values are exposed, and appropriate events are raised. For standard [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] controls, most of this work is already done through <xref:System.Windows.Automation.Peers.AutomationPeer>. Custom controls require additional work to ensure that programmatic access is correctly implemented.  
  
<a name="Enable_Programmatic_Access_to_all_UI_Elements_and_Text"></a>   
### Enable Programmatic Access to all UI Elements and Text  
 [!INCLUDE[TLA#tla_ui#initcap](../../../includes/tlasharptla-uisharpinitcap-md.md)] elements should enable programmatic access. If the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] is a standard [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] control, support for programmatic access is included in the control. If the control is a custom control – a control that has been subclassed from a common control or a control that has been subclassed from Control – then you must check the <xref:System.Windows.Automation.Peers.AutomationPeer> implementation for areas that may need modification.  
  
 Following this best practice allows [!INCLUDE[TLA2#tla_at](../../../includes/tla2sharptla-at-md.md)] vendors to identify and manipulate elements of your product's [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)].  
  
<a name="Place_Names__Titles_and_Descriptions_on_UI_Objects_"></a>   
### Place Names, Titles, and Descriptions on UI Objects, Frames, and Pages  
 Assistive technologies, especially screen readers, use the title to understand the location of the frame, object, or page in the navigation scheme. Therefore, the title must be very descriptive. For example, a Web page title of "Microsoft Web Page" is useless if the user has navigated deeply into some particular area. A descriptive title is critical for users who are blind and depend on screen readers. Similarly, for [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] controls, <xref:System.Windows.Automation.AutomationProperties.NameProperty> and <xref:System.Windows.Automation.AutomationProperties.HelpTextProperty> are important for [!INCLUDE[TLA2#tla_at](../../../includes/tla2sharptla-at-md.md)] devices.  
  
 Following this best practice allows [!INCLUDE[TLA2#tla_at](../../../includes/tla2sharptla-at-md.md)]s to identify and manipulate [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] in sample controls and applications.  
  
<a name="Ensure_Programmatic_Events_are_Triggered_by_all_UI"></a>   
### Ensure Programmatic Events Are Triggered by All UI Activities  
 Following this best practice allows [!INCLUDE[TLA2#tla_at](../../../includes/tla2sharptla-at-md.md)]s to listen for changes in the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] and notify the user about these changes.  
  
<a name="User_Settings"></a>   
## User Settings  
 The best practice in this section ensures that controls or applications do not override user settings.  
  
<a name="Respect_all_System_Wide_Settings_and_do_not_Interfere"></a>   
### Respect All System-Wide Settings and Do Not Interfere with Accessibility Functions  
 Users can use the Control Panel to set some system-wide flags; other flags can be set programmatically. These settings should not be changed by controls or applications. Also, applications must support the accessibility settings of their host operating system.  
  
 Following this best practice allows users to set accessibility settings and know that those settings will not be changed by applications.  
  
<a name="Visual_UI_Design"></a>   
## Visual UI Design  
 Best Practices in this section ensure that controls or applications use color and images effectively and are able to be used by [!INCLUDE[TLA2#tla_at#plural](../../../includes/tla2sharptla-atsharpplural-md.md)].  
  
<a name="Don_t_Hard_Code_Colors"></a>   
### Don't Hard-Code Colors  
 People who are color blind, have low vision, or are using a black and white screen might not be able to use applications with hard-coded colors.  
  
 Following this best practice allows users to adjust color combinations based on individual needs.  
  
<a name="Support_High_Contrast_and_all_System_Display_Attributes"></a>   
### Support High Contrast and all System Display Attributes  
 Applications should not disrupt or disable user-selected, system-wide contrast settings, color selections, or other system-wide display settings and attributes. System-wide settings adopted by a user enhance the accessibility of applications, so they should not be disabled or disregarded by applications. Color should be used in their correct foreground-on-background combination to provide proper contrast. Unrelated colors should not be mixed, and colors should not be reversed.  
  
 Many users require specific high-contrast combinations, such as white text on a black background. Drawing these reversed, as black text on a white background causes the background to bleed over the foreground and can make reading difficult for some users.  
  
<a name="Ensure_all_UI_Correctly_Scales_by_any_DPI_Setting"></a>   
### Ensure All UI Correctly Scales by Any DPI Setting  
 Ensure that all [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] can correctly scale by any [!INCLUDE[TLA#tla_dpi](../../../includes/tlasharptla-dpi-md.md)] setting. Also, ensure that [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements fit in a screen of 1024 x 768 with 120 [!INCLUDE[TLA#tla_dpi](../../../includes/tlasharptla-dpi-md.md)].  
  
<a name="Navigation"></a>   
## Navigation  
 Best Practices in this section ensure that navigation has been addressed for controls and applications.  
  
<a name="Provide_Keyboard_Interface_for_all_UI_Elements"></a>   
### Provide Keyboard Interface for All UI Elements  
 Tab stops, especially when carefully planned, give users another way to navigate the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)].  
  
 Applications should provide the following keyboard interfaces:  
  
-   tab stops for all controls that the user can interact with, such as buttons, links, or list boxes  
  
-   logical tab order  
  
<a name="Show_the_Keyboard_Focus"></a>   
### Show the Keyboard Focus  
 Users need to know which object has the keyboard focus so that they can anticipate the effect of their keystrokes. To highlight the keyboard focus, use colors, fonts, or graphics such as rectangles or magnification. To audibly highlight the keyboard focus, change the volume, pitch or tonal quality.  
  
 To avoid confusion, applications should hide all visual focus indicators and dim selections that are located in inactive windows (or panes).  
  
 Applications should do the following with keyboard focus:  
  
-   one item should always have keyboard focus  
  
-   keyboard focus should be visible and obvious  
  
-   selections and/or focused items should be visually highlighted  
  
<a name="Support_Navigation_Standards_and_Powerful_Navigation"></a>   
### Support Navigation Standards and Powerful Navigation Schemes  
 Different aspects of keyboard navigation provide different ways for users to navigate the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)].  
  
 Applications should provide the following keyboard interfaces:  
  
-   shortcut keys and underlined access keys for all commands, menus and controls  
  
-   keyboard shortcuts to important links  
  
-   all menu items have an access key; all buttons have accelerator keys, all commands have an accelerator key.  
  
<a name="Do_not_let_Mouse_Location_Interfere_with_Keyboard"></a>   
### Do Not Let Mouse Location Interfere with Keyboard Navigation  
 Mouse location should not interfere with keyboard navigation. For example, if the mouse is positioned someplace and the user is navigating with the keyboard, a mouse click should not happen unless initiated by the user.  
  
<a name="Multimodal_Interface"></a>   
## Multimodal Interface  
 Best Practices in this section ensure that application [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] includes alternatives for visual elements.  
  
<a name="Provide_User_Selectable_Equivalents_for_Non_Text"></a>   
### Provide User-Selectable Equivalents for Non-Text Elements  
 For each non-text element, provide a user-selectable equivalent for text, transcripts, or audio descriptions, such as alt text, captions, or visual feedback.  
  
 Non-text elements cover a wide range of [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)] elements including: images, image map regions, animations, applets, frames, scripts, graphical buttons, sounds, stand-alone audio files and video. Non-text elements are important when they contain visual information, speech, or general audio information that the user needs access to in order to understand the content of the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)].  
  
<a name="Use_Color_but_also_Provide_Alternatives_to_Color"></a>   
### Use Color but Also Provide Alternatives to Color  
 Use color to enhance, emphasize, or reiterate information shown by other means, but do not communicate information by using color alone. Users who are color blind or have a monochrome display need alternatives to color.  
  
<a name="Use_Standard_Input_APIs_with_Devices_Independent"></a>   
### Use Standard Input APIs with Device-Independent Calls  
 Device-independent calls ensure keyboard and mouse feature equality, while providing [!INCLUDE[TLA2#tla_at](../../../includes/tla2sharptla-at-md.md)] with needed information about the [!INCLUDE[TLA2#tla_ui](../../../includes/tla2sharptla-ui-md.md)].  
  
## See Also  
 <xref:System.Windows.Automation.Peers>  
 [NumericUpDown Custom Control with Theme and UI Automation Support Sample](http://msdn.microsoft.com/library/9aed3c10-68eb-419e-a57f-1d2af15a8253)  
 [Guidelines for Keyboard User Interface Design](http://msdn2.microsoft.com/library/ms971323.aspx)
