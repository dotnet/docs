---
title: Exception Classes
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# Exception Classes (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) error handling is implemented through the use of *exceptions*. The four POS for .NET exception classes are as follows:

- [PosException](ms884839\(v=winembedded.11\).md)
- [PosControlException](ms884827\(v=winembedded.11\).md)
- [PosManagementException](ms884858\(v=winembedded.11\).md)
- [PosLibraryException](ms884854\(v=winembedded.11\).md)

Standard Unified Point Of Service (UnifiedPOS) error codes are represented by the [ErrorCode](ms884224\(v=winembedded.11\).md) enumeration.

## PosException

**PosException** is the **Base** exception class for **PosControlException**, **PosManagementException**, and **PosLibraryException**. **PosException** is derived from **System.Exception**.

## PosControlException

**PosControlException** is the standard exception thrown by Service Objects to POS for .NET applications.

## PosManagementException

**PosManagementException** is thrown by POS for .NET Device Management. Applications and Service Objects must not throw **PosManagementException**.

## PosLibraryException

**PosLibraryException** is thrown by [PosExplorer](ms884843\(v=winembedded.11\).md). Applications and Service Objects must not throw **PosLibraryException**.

## Error Codes

The following table provides a mapping between the UnifiedPOS standard error codes and the **ErrorCode** values that POS for .NET provides.

<table>
<colgroup>
<col style="width: 33%" />
<col style="width: 33%" />
<col style="width: 33%" />
</colgroup>
<thead>
<tr class="header">
<th>POS ErrorCode Member</th>
<th>UnifiedPOS Error Code</th>
<th>Error Cause</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>Busy</p></td>
<td><p>E_BUSY</p></td>
<td><p>The current Service Object state does not allow this request.</p></td>
</tr>
<tr class="even">
<td><p>Claimed</p></td>
<td><p>E_CLAIMED</p></td>
<td><p>Another Service Object instance has already claimed the POS device.</p></td>
</tr>
<tr class="odd">
<td><p>Closed</p></td>
<td><p>E_CLOSED</p></td>
<td><p>The POS device is closed.</p></td>
</tr>
<tr class="even">
<td><p>Deprecated</p></td>
<td><p>E_DEPRECATED</p></td>
<td><p>The method has been deprecated and is no longer available.</p></td>
</tr>
<tr class="odd">
<td><p>Disabled</p></td>
<td><p>E_DISABLED</p></td>
<td><p>The operation cannot be performed while the device is disabled.</p></td>
</tr>
<tr class="even">
<td><p>Exists</p></td>
<td><p>E_EXISTS</p></td>
<td><p>The file name or other specified value already exists.</p></td>
</tr>
<tr class="odd">
<td><p>Extended</p></td>
<td><p>E_EXTENDED</p></td>
<td><p>A device-specific error condition occurred.</p></td>
</tr>
<tr class="even">
<td><p>Failure</p></td>
<td><p>E_FAILURE</p></td>
<td><p>The POS device cannot perform the requested procedure, even though the device is connected to the system and active.</p></td>
</tr>
<tr class="odd">
<td><p>Illegal</p></td>
<td><p>E_ILLEGAL</p></td>
<td><p>The POS application attempted an illegal or unsupported operation with the device, or used an invalid parameter value.</p></td>
</tr>
<tr class="even">
<td><p>NoExist</p></td>
<td><p>E_NOEXIST</p></td>
<td><p>The file name or other specified value does not exist.</p></td>
</tr>
<tr class="odd">
<td><p>NoHardware</p></td>
<td><p>E_NOHARDWARE</p></td>
<td><p>The POS device is not connected to the system or is not turned on.</p></td>
</tr>
<tr class="even">
<td><p>NoService</p></td>
<td><p>E_NOSERVICE</p></td>
<td><p>The Service Object cannot communicate with the device, normally because of a setup or configuration error.</p></td>
</tr>
<tr class="odd">
<td><p>NotClaimed</p></td>
<td><p>E_NOTCLAIMED</p></td>
<td><p>The POS application attempted to access an exclusive-use device that must be claimed before the method or property set action can be used.</p></td>
</tr>
<tr class="even">
<td><p>Offline</p></td>
<td><p>E_OFFLINE</p></td>
<td><p>The POS device is offline.</p></td>
</tr>
<tr class="odd">
<td><p>Timeout</p></td>
<td><p>E_TIMEOUT</p></td>
<td><p>The Service Object timed out waiting for a response from the POS device.</p></td>
</tr>
</tbody>
</table>

## Example

The following code example demonstrates how MSR handles POS exceptions and uses the **ErrorCodes** contained in those exceptions to gather information about them.

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

## See Also

#### Reference

[PosException](ms884839\(v=winembedded.11\).md)
[PosControlException](ms884827\(v=winembedded.11\).md)
[PosManagementException](ms884858\(v=winembedded.11\).md)
[PosLibraryException](ms884854\(v=winembedded.11\).md)

#### Concepts

[PosExplorer Class](posexplorer-class.md)
[POS Exception Handling](pos-exception-handling.md)

#### Other Resources

[POS for .NET API Support](pos-for-net-api-support.md)
