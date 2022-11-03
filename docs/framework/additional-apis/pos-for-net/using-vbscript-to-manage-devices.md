---
title: Using VBScript to Manage Devices
description: Using VBScript to Manage Devices (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# Using VBScript to Manage Devices (POS for .NET v1.14 SDK Documentation)

Using the WMI API documented in this section, it is possible to manage devices using managed code or scripting. **POSDM.EXE** is a command-line interface to this API. This VBScript sample does the following:

- It uses the WMI method **ExecQuery** to retrieve a list of installed **PosDevice** objects. With this list of Service Objects, the script displays their type, name, corresponding path, and their enabled or disabled status. This is analogous to running the following command:

    `PosDM.exe LISTDEVICES`

- It then attempts to assign the path **COM1** to the installed Service Object, **Microsoft Msr Simulator** using the **AddDevice** method. This is equivalent to running:

    `PosDM.exe ADDDEVICE COM1 /SONAME:Microsoft Msr Simulator`

- If the **AddDevice** method fails, the script catches the error and assumes that **COM1** may have already been added to the device and therefore attempts to delete it by calling **DeleteDevice**. This is equivalent to running:

    `PosDM.exe DELETEDEVICE COM1`

- If the **AddDevice** method had previously failed, the script then attempts to call **AddDevice** again. The program exits if the method fails.

- Finally, the sample attempts to add the logical name **MSRSim** to this Service Object by calling **AddName**. This is equivalent to running:

    `PosDM.exe ADDNAME MSRSim /SONAME:"Microsoft Msr Simulator"`

It is possible to see the results of this sample by running:

  `PosDM.exe LISTDEVICES`

And

  `PosDM.exe LISTNAMES`

## To run the sample

1. The Service Object **Microsoft Msr Simulator** was installed with the SDK. Be sure that it is installed on the computer which you will be using to run the sample.

2. Copy this script to a file **PosDMSample.vbs**

3. Execute the script with the following command line:

    `CScript //U PosDMSample.vbs`

## Example

```vbscript
'Get a handle to the POS namespace service into 'objServices'.
Set objLocator = CreateObject("WbemScripting.SWbemLocator")
Set objServices = objLocator.ConnectServer(, "/root/MicrosoftPointOfService")

'List the POS devices.
EnumeratePosDevice

'Add a name: MSRSim for Msr Simulator by retrieving the SO and invoking AddDevice() then AddName()
WScript.Echo "Add Device on COM1 and add name 'MSRSim' for MsrSimulator ..."
Set objSO = objServices.Get("ServiceObject.Type='Msr',Name='Microsoft Msr Simulator'")

On Error Resume Next
objSO.AddDevice "COM1"
if Err.number <> 0 Then
  WScript.Echo "AddDevice failed - it already is in use."
  WScript.Echo "Try to delete the device..."

  On Error Resume Next
  objSO.DeleteDevice "COM1"
  if Err.number <> 0 Then
    WScript.Echo "DeleteDevice failed"
    WScript.Quit 1
  end if

  WScript.Echo "DeleteDevice succeeded! Attempting AddDevice again..."

  On Error Resume Next
  objSO.AddDevice "COM1"
  if Err.number <> 0 Then
      WScript.Echo "AddDevice failed a second time - exiting"
      WScript.Quit 2
  end if
end if

Set objDevice = objServices.Get("PosDevice.SoName='Microsoft Msr Simulator',Type='Msr',Path='COM1'")
objDevice.AddName "MSRSim"
Set objDevice = GetDevice("Msr", "MSRSim")
WScript.Echo "Added 'MSRSim' to: " & objDevice.Type & vbTab & objDevice.SoName & vbTab & objDevice.Path

'Enumerate the sClass by name
Sub EnumeratePosDevice( )
  sClass = "PosDevice"
  WScript.Echo "Enumerating " & sClass & "..." & vbCrLf

  Set collection = objServices.ExecQuery("SELECT * From " & sClass)
  For Each obj In collection
    Enabled = "DISABLED"
    if obj.Enabled = true Then
      Enabled = "ENABLED"
    end If
      WScript.Echo obj.Type & Space(15-len(obj.type)) & obj.SoName & Space(35-len(obj.SoName)) & Enabled & vbTab & obj.Path
  Next
  WScript.Echo vbCrLf
End Sub

'Return a PosDevice matching DeviceType and Name.
Function GetDevice( DeviceType, Name )
  Set Logical = GetLogicalDevice( DeviceType, Name )
  objectPath = "PosDevice.SoName='" & Logical.SoName & "',Type='" & DeviceType & "',Path='" & Logical.Path & "'"
  Set GetDevice = objServices.Get(objectPath)
End Function

'Return a LogicalDevice matching DeviceType and Name.
Function GetLogicalDevice( DeviceType, Name )
  Query = "SELECT * From LogicalDevice WHERE Type = '" & DeviceType & "' AND Name='" & Name & "'"
  Set collection = objServices.ExecQuery( Query )
  For Each obj In collection
    Set GetLogicalDevice = obj
    exit For
  Next
End Function
```

If the path COM1 has not been assigned to a device, the sample produces output similar to this code.

```console
Microsoft (R) Windows Script Host Version 5.6
Copyright (C) Microsoft Corporation 1996-2001. All rights reserved.

Enumerating PosDevice...

Msr            Microsoft Msr Simulator            ENABLED
Msr            Microsoft Msr Simulator            ENABLED       COM1
Keylock        Microsoft Keylock Simulator        ENABLED
Scanner        Microsoft Scanner Simulator        ENABLED
CashDrawer     Microsoft CashDrawer Simulator     ENABLED
CheckScanner   Microsoft CheckScanner Simulator   ENABLED
LineDisplay    Microsoft LineDisplay Simulator    ENABLED
PinPad         Microsoft PinPad Simulator         ENABLED
PosPrinter     Microsoft PosPrinter Simulator     ENABLED
PosKeyboard    Microsoft PosKeyboard Simulator    ENABLED

Add Device on COM1 and add name 'MSRSim' for MsrSimulator ...
AddDevice failed - it already be in use.
Try to delete the device...
DeleteDevice succeeded! Attempting AddDevice again...
Added 'MSRSim' to: Msr  Microsoft Msr Simulator
```

If the path COM1 is already in use and no other error occurs, the script produces output that looks like this code.

```console
Microsoft (R) Windows Script Host Version 5.6
Copyright (C) Microsoft Corporation 1996-2001. All rights reserved.

Enumerating PosDevice...

Msr            Microsoft Msr Simulator            ENABLED
Msr            Microsoft Msr Simulator            ENABLED       COM1
Keylock        Microsoft Keylock Simulator        ENABLED
Scanner        Microsoft Scanner Simulator        ENABLED
CashDrawer     Microsoft CashDrawer Simulator     ENABLED
CheckScanner   Microsoft CheckScanner Simulator   ENABLED
LineDisplay    Microsoft LineDisplay Simulator    ENABLED
PinPad         Microsoft PinPad Simulator         ENABLED
PosPrinter     Microsoft PosPrinter Simulator     ENABLED
PosKeyboard    Microsoft PosKeyboard Simulator    ENABLED

Add Device on COM1 and add name 'MSRSim' for MsrSimulator ...
AddDevice failed - it already be in use.
Try to delete the device...
DeleteDevice succeeded! Attempting AddDevice again...
Added 'MSRSim' to: Msr  Microsoft Msr Simulator
```

## See Also

#### Other Resources

- [Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
- [POS Device Manager](pos-device-manager.md)
