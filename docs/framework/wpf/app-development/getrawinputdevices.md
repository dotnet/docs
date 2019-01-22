---
title: "GetRawInputDevices"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "raw input [WPF]"
ms.assetid: c4d37ecd-065a-4d1c-9e6c-26804ae968ca
---
# GetRawInputDevices
Allows PresentationHost.exe to discover the raw input devices (Human Interface Devices) that the host application is interested in.  
  
## Syntax  
  
```  
HRESULT GetRawInputDevices( [out] IEnumRAWINPUTDEVICE **ppEnum );  
```  
  
#### Parameters  
 `ppEnum`  
  
 [out] A pointer to an [IEnumRAWINPUTDEVICE](../../../../docs/framework/wpf/app-development/ienumrawinputdevice.md) for enumerating the raw input devices.  
  
## Property Value/Return Value  
 HRESULT:  
  
 S_OK - [IEnumRAWINPUTDEVICE](../../../../docs/framework/wpf/app-development/ienumrawinputdevice.md) will only be used by PresentationHost.exe if S_OK is returned.  
  
 E_NOTIMPL  
  
## Remarks  
 Raw input devices are the set of input devices that includes keyboards, mice, and less traditional devices like remote controls.  
  
 Once the list of raw input devices has been retrieved, PresentationHost.exe registers with the devices to receive WM_INPUT notification messages.  
  
## See also
 [GetRawInputDeviceList](/windows/desktop/api/winuser/nf-winuser-getrawinputdevicelist)  
 [FilterInputMessage](../../../../docs/framework/wpf/app-development/filterinputmessage.md)
