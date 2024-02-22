---
title: Exception Classes
description: Exception Classes (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Exception Classes (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) error handling is implemented through the use of *exceptions*. The four POS for .NET exception classes are as follows:

- <xref:Microsoft.PointOfService.PosException>
- <xref:Microsoft.PointOfService.PosControlException>
- <xref:Microsoft.PointOfService.PosManagementException>
- <xref:Microsoft.PointOfService.PosLibraryException>

Standard Unified Point Of Service (UnifiedPOS) error codes are represented by the <xref:Microsoft.PointOfService.ErrorCode> enumeration.

## PosException

**PosException** is the **Base** exception class for **PosControlException**, **PosManagementException**, and **PosLibraryException**. **PosException** is derived from **System.Exception**.

## PosControlException

**PosControlException** is the standard exception thrown by Service Objects to POS for .NET applications.

## PosManagementException

**PosManagementException** is thrown by POS for .NET Device Management. Applications and Service Objects must not throw **PosManagementException**.

## PosLibraryException

**PosLibraryException** is thrown by <xref:Microsoft.PointOfService.PosExplorer>. Applications and Service Objects must not throw **PosLibraryException**.

## Error Codes

The following table provides a mapping between the UnifiedPOS standard error codes and the **ErrorCode** values that POS for .NET provides.

| POS ErrorCode Member | UnifiedPOS Error Code | Error Cause                                                                                                                                |
|----------------------|-----------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| Busy                 | E_BUSY                | The current Service Object state does not allow this request.                                                                              |
| Claimed              | E_CLAIMED             | Another Service Object instance has already claimed the POS device.                                                                        |
| Closed               | E_CLOSED              | The POS device is closed.                                                                                                                  |
| Deprecated           | E_DEPRECATED          | The method has been deprecated and is no longer available.                                                                                 |
| Disabled             | E_DISABLED            | The operation cannot be performed while the device is disabled.                                                                            |
| Exists               | E_EXISTS              | The file name or other specified value already exists.                                                                                     |
| Extended             | E_EXTENDED            | A device-specific error condition occurred.                                                                                                |
| Failure              | E_FAILURE             | The POS device cannot perform the requested procedure, even though the device is connected to the system and active.                       |
| Illegal              | E_ILLEGAL             | The POS application attempted an illegal or unsupported operation with the device, or used an invalid parameter value.                     |
| NoExist              | E_NOEXIST             | The file name or other specified value does not exist.                                                                                     |
| NoHardware           | E_NOHARDWARE          | The POS device is not connected to the system or is not turned on.                                                                         |
| NoService            | E_NOSERVICE           | The Service Object cannot communicate with the device, normally because of a setup or configuration error.                                 |
| NotClaimed           | E_NOTCLAIMED          | The POS application attempted to access an exclusive-use device that must be claimed before the method or property set action can be used. |
| Offline              | E_OFFLINE             | The POS device is offline.                                                                                                                 |
| Timeout              | E_TIMEOUT             | The Service Object timed out waiting for a response from the POS device.                                                                   |

## Example

The following code example demonstrates how MSR handles POS exceptions and uses the **ErrorCodes** contained in those exceptions to gather information about them.

```csharp
// Create a new instance of the MSR and opens the device.
msr = (Msr)explorer.CreateInstance(msrinfo);
msr.Open();

// Try to enable the device without first claiming it.
// This will throw a PosControlException which, through
// its ErrorCode, will yield information about the exception.
try
{
   msr.DeviceEnabled = true;
}
catch (PosControlException e)
{

   // Examine the ErrorCode to determine the cause of the error.
   if (e.ErrorCode == ErrorCode.NoHardware)
   {
      Console.WriteLine("The POS device is not connected ");
      Console.WriteLine("to the system or is not turned on.");
   }
   if (e.ErrorCode == ErrorCode.Timeout)
   {
      Console.WriteLine("The Service Object timed out
            waiting for a response from the POS device.");
   }

   // The example has not claimed the MSR, which is an
   // exclusive-access device, before trying to enable
   // it. This will throw the PosControlException
   // and trigger the following conditional block.
   // Once triggered, the MSR will be claimed and enabled.
   if (e.ErrorCode == ErrorCode.NotClaimed)
   {
      Console.WriteLine("The POS application attempted to access ");
      Console.WriteLine("an exclusive-use device that must be ");
      Console.WriteLine("claimed before the method or property ");
      Console.WriteLine("set action can be used.")
      msr.Claim(1000);
      msr.DeviceEnabled = true;
   }
}
```

## See Also

#### Reference

- <xref:Microsoft.PointOfService.PosException>
- <xref:Microsoft.PointOfService.PosControlException>
- <xref:Microsoft.PointOfService.PosManagementException>
- <xref:Microsoft.PointOfService.PosLibraryException>

#### Concepts

- [PosExplorer Class](posexplorer-class.md)
- [POS Exception Handling](pos-exception-handling.md)

#### Other Resources

- [POS for .NET API Support](pos-for-net-api-support.md)
