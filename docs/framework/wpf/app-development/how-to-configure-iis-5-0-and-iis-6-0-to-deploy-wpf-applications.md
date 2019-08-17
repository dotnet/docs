---
title: "How to: Configure IIS 5.0 and IIS 6.0 to Deploy WPF Applications"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "MIME types [WPF], registering"
  - "adjusting content expiration setting [WPF]"
  - "registering file extensions [WPF]"
  - "deploying applications [WPF]"
  - "applications [WPF], deploying"
  - "Web servers [WPF], configuring to deploy WPF applications"
  - "configuring Web servers to deploy WPF applications [WPF]"
  - "content expiration setting [WPF], adjusting"
  - "file extensions [WPF], registering"
  - "registering MIME types [WPF]"
ms.assetid: c6e8c2cb-9ba2-4e75-a0d5-180ec9639433
---

# How to: Configure IIS 5.0 and IIS 6.0 to Deploy WPF Applications

You can deploy a [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] application from most Web servers, as long as they are configured with the appropriate Multipurpose Internet Mail Extensions (MIME) types. By default, Microsoft Internet Information Services (IIS) 7.0 is configured with these MIME types, but Microsoft Internet Information Services (IIS) 5.0 and Microsoft Internet Information Services (IIS) 6.0 are not.

This topic describes how to configure Microsoft Internet Information Services (IIS) 5.0 and Microsoft Internet Information Services (IIS) 6.0 to deploy [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications.

> [!NOTE]
> You can check the *UserAgent* string in the registry to determine whether a system has .NET Framework installed. For details and a script that examines the *UserAgent* string to determine whether .NET Framework is installed on a system, see [Detect Whether the .NET Framework 3.0 Is Installed](how-to-detect-whether-the-net-framework-3-0-is-installed.md).

<a name="content_expiration"></a>

## Adjust the Content Expiration Setting

You should adjust the content expiration setting to 1 minute. The following procedure outlines how to do this with [!INCLUDE[TLA2#tla_iis5](../../../../includes/tla2sharptla-iis5-md.md)].

1. Click the **Start** menu, point to **Administrative Tools**, and click **Internet Information Services (IIS) Manager**. You can also launch this application from the command line with "%SystemRoot%\system32\inetsrv\iis.msc".

2. Expand the [!INCLUDE[TLA2#tla_iis5](../../../../includes/tla2sharptla-iis5-md.md)] tree until you find the **Default Web site** node.

3. Right-click **Default Web site** and select **Properties** from the context menu.

4. Select the **HTTP Headers** tab and click "Enable Content Expiration".

5. Set the content to expire after 1 minute.

<a name="register_mime_types"></a>

## Register MIME Types and File Extensions

You must register several MIME types and file extensions so that the browser on the client's system can load the correct handler. You need to add the following types:

|Extension|MIME Type|
|---------------|---------------|
|.manifest|application/manifest|
|.xaml|application/xaml+xml|
|.application|application/x-ms-application|
|.xbap|application/x-ms-xbap|
|.deploy|application/octet-stream|
|.xps|application/vnd.ms-xpsdocument|

> [!NOTE]
> You do not need to register MIME types or file extensions on client systems. They are registered automatically when you install Microsoft .NET Framework.

The following Microsoft Visual Basic Scripting Edition (VBScript) sample automatically adds the necessary MIME types to [!INCLUDE[TLA2#tla_iis5](../../../../includes/tla2sharptla-iis5-md.md)]. To use the script, copy the code to a .vbs file on your server. Then, run the script by running the file from the command line or double-clicking the file in [!INCLUDE[TLA#tla_winexpl](../../../../includes/tlasharptla-winexpl-md.md)].

```vb
' This script adds the necessary Windows Presentation Foundation MIME types
' to an IIS Server.
' To use this script, just double-click or execute it from a command line.
' Running this script multiple times results in multiple entries in the IIS MimeMap.

Dim MimeMapObj, MimeMapArray, MimeTypesToAddArray, WshShell, oExec
Const ADS_PROPERTY_UPDATE = 2

' Set the MIME types to be added
MimeTypesToAddArray = Array(".manifest", "application/manifest", ".xaml", _
    "application/xaml+xml", ".application", "application/x-ms-application", _
    ".deploy", "application/octet-stream", ".xbap", "application/x-ms-xbap", _
    ".xps", "application/vnd.ms-xpsdocument")

' Get the MimeMap object
Set MimeMapObj = GetObject("IIS://LocalHost/MimeMap")

' Call AddMimeType for every pair of extension/MIME type
For counter = 0 to UBound(MimeTypesToAddArray) Step 2
    AddMimeType MimeTypesToAddArray(counter), MimeTypesToAddArray(counter+1)
Next

' Create a Shell object
Set WshShell = CreateObject("WScript.Shell")

' Stop and Start the IIS Service
Set oExec = WshShell.Exec("net stop w3svc")
Do While oExec.Status = 0
    WScript.Sleep 100
Loop

Set oExec = WshShell.Exec("net start w3svc")
Do While oExec.Status = 0
    WScript.Sleep 100
Loop

Set oExec = Nothing

' Report status to user
WScript.Echo "Windows Presentation Foundation MIME types have been registered."

' AddMimeType Sub
Sub AddMimeType (Ext, MType)

    ' Get the mappings from the MimeMap property.
    MimeMapArray = MimeMapObj.GetEx("MimeMap")

    ' Add a new mapping.
    i = UBound(MimeMapArray) + 1
    ReDim Preserve MimeMapArray(i)
    Set MimeMapArray(i) = CreateObject("MimeMap")
    MimeMapArray(i).Extension = Ext
    MimeMapArray(i).MimeType = MType
    MimeMapObj.PutEx ADS_PROPERTY_UPDATE, "MimeMap", MimeMapArray
    MimeMapObj.SetInfo

End Sub
```

> [!NOTE]
> Running this script multiple times creates multiple MIME map entries in the Microsoft Internet Information Services (IIS) 5.0 or Microsoft Internet Information Services (IIS) 6.0 metabase.

After you have run this script, you may not see additional MIME types from the Microsoft Internet Information Services (IIS) 5.0 or Microsoft Internet Information Services (IIS) 6.0 Microsoft Management Console (MMC). However, these MIME types have been added to the Microsoft Internet Information Services (IIS) 5.0 or Microsoft Internet Information Services (IIS) 6.0 metabase. The following script will display all the MIME types in the Microsoft Internet Information Services (IIS) 5.0 or Microsoft Internet Information Services (IIS) 6.0 metabase.

```vb
' This script lists the MIME types for an IIS Server.
' To use this script, just double-click or execute it from a command line
' by calling cscript.exe

dim mimeMapEntry, allMimeMaps

' Get the MimeMap object.
Set mimeMapEntry = GetObject("IIS://localhost/MimeMap")
allMimeMaps = mimeMapEntry.GetEx("MimeMap")

' Display the mappings in the table.
For Each mimeMap In allMimeMaps
    WScript.Echo(mimeMap.MimeType & " (" & mimeMap.Extension + ")")
Next
```

Save the script as a `.vbs` file (for example, `DiscoverIISMimeTypes.vbs`) and run it from the command prompt using the following command:

```console
cscript DiscoverIISMimeTypes.vbs
```
