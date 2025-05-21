---
title: "Accessibility Best Practices"
description: Learn about accessibility best practices in .NET. Explore programmatic access, user settings, visual UI design, navigation, and multimodal interfaces.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "best practices for accessibility"
  - "accessibility, best practices for"
ms.assetid: e6d5cd98-21a3-4b01-999c-fb953556d0e6
ms.topic: best-practice
---
# Accessibility best practices

> [!NOTE]
> This article is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

Implementing the following best practices in controls or applications will improve their accessibility for people who use assistive technology devices. Many of these best practices focus on good user interface (UI) design. Each best practice includes implementation information for Windows Presentation Foundation (WPF) controls or applications. In many cases, the work to meet these best practices is already included in WPF controls.

<a name="Programmatic_Access"></a>

## Programmatic Access

Programmatic access involves ensuring that all UI elements are labeled, property values are exposed, and appropriate events are raised. For standard WPF controls, most of this work is already done through <xref:System.Windows.Automation.Peers.AutomationPeer>. Custom controls require additional work to ensure that programmatic access is correctly implemented.

<a name="Enable_Programmatic_Access_to_all_UI_Elements_and_Text"></a>

### Enable Programmatic Access to all UI Elements and Text

User interface (UI) elements should enable programmatic access. If the UI is a standard WPF control, support for programmatic access is included in the control. If the control is a custom control – a control that has been subclassed from a common control or a control that has been subclassed from Control – then you must check the <xref:System.Windows.Automation.Peers.AutomationPeer> implementation for areas that may need modification.

Following this best practice allows assistive technology vendors to identify and manipulate elements of your product's UI.

<a name="Place_Names__Titles_and_Descriptions_on_UI_Objects_"></a>

### Place Names, Titles, and Descriptions on UI Objects, Frames, and Pages

Assistive technologies, especially screen readers, use the title to understand the location of the frame, object, or page in the navigation scheme. Therefore, the title must be descriptive. For example, a Web page title of "Microsoft Web Page" is useless if the user has navigated deeply into some particular area. A descriptive title is critical for users who are blind and depend on screen readers. Similarly, for WPF controls, <xref:System.Windows.Automation.AutomationProperties.NameProperty> and <xref:System.Windows.Automation.AutomationProperties.HelpTextProperty> are important for assistive technology devices.

Following this best practice allows assistive technologies to identify and manipulate UI in sample controls and applications.

<a name="Ensure_Programmatic_Events_are_Triggered_by_all_UI"></a>

### Ensure Programmatic Events Are Triggered by All UI Activities

Following this best practice allows assistive technologies to listen for changes in the UI and notify the user about these changes.

<a name="User_Settings"></a>

## User Settings

The best practice in this section ensures that controls or applications do not override user settings.

<a name="Respect_all_System_Wide_Settings_and_do_not_Interfere"></a>

### Respect All System-Wide Settings and Do Not Interfere with Accessibility Functions

Users can use the Control Panel to set some system-wide flags; other flags can be set programmatically. These settings should not be changed by controls or applications. Also, applications must support the accessibility settings of their host operating system.

Following this best practice allows users to set accessibility settings and know that those settings will not be changed by applications.

<a name="Visual_UI_Design"></a>

## Visual UI Design

Best Practices in this section ensure that controls or applications use color and images effectively and are able to be used by Assistive technologies.

<a name="Don_t_Hard_Code_Colors"></a>

### Don't Hard-Code Colors

People who are color blind, have low vision, or are using a black and white screen might not be able to use applications with hard-coded colors.

Following this best practice allows users to adjust color combinations based on individual needs.

<a name="Support_High_Contrast_and_all_System_Display_Attributes"></a>

### Support High Contrast and all System Display Attributes

Applications should not disrupt or disable user-selected, system-wide contrast settings, color selections, or other system-wide display settings and attributes. System-wide settings adopted by a user enhance the accessibility of applications, so they should not be disabled or disregarded by applications. Color should be used in their correct foreground-on-background combination to provide proper contrast. Don't mix unrelated colors, and don't reverse colors.

Many users require specific high-contrast combinations, such as white text on a black background. Drawing these reversed, as black text on a white background causes the background to bleed over the foreground and can make reading difficult for some users.

<a name="Ensure_all_UI_Correctly_Scales_by_any_DPI_Setting"></a>

### Ensure All UI Correctly Scales by Any DPI Setting

Ensure that all UI can correctly scale by any dots per inch (dpi) setting. Also, ensure that UI elements fit in a screen of 1024 x 768 with 120 dots per inch (dpi).

<a name="Navigation"></a>

## Navigation

Best Practices in this section ensure that navigation has been addressed for controls and applications.

<a name="Provide_Keyboard_Interface_for_all_UI_Elements"></a>

### Provide Keyboard Interface for All UI Elements

Tab stops, especially when carefully planned, give users another way to navigate the UI.

Applications should provide the following keyboard interfaces:

- tab stops for all controls that the user can interact with, such as buttons, links, or list boxes
- logical tab order

<a name="Show_the_Keyboard_Focus"></a>

### Show the Keyboard Focus

Users need to know which object has the keyboard focus so that they can anticipate the effect of their keystrokes. To highlight the keyboard focus, use colors, fonts, or graphics such as rectangles or magnification. To audibly highlight the keyboard focus, change the volume, pitch, or tonal quality.

To avoid confusion, applications should hide all visual focus indicators and dim selections that are located in inactive windows (or panes).

Applications should do the following with keyboard focus:

- one item should always have keyboard focus
- keyboard focus should be visible and obvious
- selections and/or focused items should be visually highlighted

<a name="Support_Navigation_Standards_and_Powerful_Navigation"></a>

### Support Navigation Standards and Powerful Navigation Schemes

Different aspects of keyboard navigation provide different ways for users to navigate the UI.

Applications should provide the following keyboard interfaces:

- shortcut keys and underlined access keys for all commands, menus, and controls
- keyboard shortcuts to important links
- all menu items have an access key; all buttons have accelerator keys, all commands have an accelerator key.

<a name="Do_not_let_Mouse_Location_Interfere_with_Keyboard"></a>

### Do Not Let Mouse Location Interfere with Keyboard Navigation

Mouse location should not interfere with keyboard navigation. For example, if the mouse is positioned some place and the user is navigating with the keyboard, a mouse click should not happen unless initiated by the user.

<a name="Multimodal_Interface"></a>

## Multimodal Interface

Best Practices in this section ensure that application UI includes alternatives for visual elements.

<a name="Provide_User_Selectable_Equivalents_for_Non_Text"></a>

### Provide User-Selectable Equivalents for Non-Text Elements

For each non-text element, provide a user-selectable equivalent for text, transcripts, or audio descriptions, such as alt text, captions, or visual feedback.

<!-- markdownlint-disable DOCSMD011 -->
Non-text elements cover a wide range of UI elements including: images, image map regions, animations, applets, frames, scripts, graphical buttons, sounds, stand-alone audio files, and video. Non-text elements are important when they contain visual information, speech, or general audio information that the user needs access to in order to understand the content of the UI.

<a name="Use_Color_but_also_Provide_Alternatives_to_Color"></a>

### Use Color but Also Provide Alternatives to Color

Use color to enhance, emphasize, or reiterate information shown by other means, but do not communicate information by using color alone. Users who are color blind or have a monochrome display need alternatives to color.

<a name="Use_Standard_Input_APIs_with_Devices_Independent"></a>

### Use Standard Input APIs with Device-Independent Calls

Device-independent calls ensure keyboard and mouse feature equality, while providing assistive technology with needed information about the UI.

## See also

- <xref:System.Windows.Automation.Peers>
- [NumericUpDown Custom Control with Theme and UI Automation Support Sample](</previous-versions/dotnet/netframework-3.5/ms771573(v=vs.90)>)
- [Guidelines for Keyboard User Interface Design](/previous-versions/windows/desktop/dnacc/guidelines-for-keyboard-user-interface-design)
