---
title: POSDM Commands
description: POSDM Commands (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# POSDM Commands (POS for .NET v1.14 SDK Documentation)

POSDM uses the following commands.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
<col />
</colgroup>
<tbody>
<tr class="odd">
<td><p><strong>Command</strong></p></td>
<td><p><strong>Description</strong></p></td>
<td><p><strong>Syntax and Examples</strong></p></td>
</tr>
<tr class="even">
<td><p>adddevice</p></td>
<td><p>Adds a physical non-Plug and Play device.</p></td>
<td><p><strong>posdm [general switches] adddevice</strong><em>path filter</em><strong>[/info]</strong></p>
<p>where <em>path</em> is a hardware path of the physical device,</p>
<p><em>filter</em> is one or more of the following:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>and</p>
<p>/info is a switch that displays all device properties.</p>
<p><strong>Example:</strong></p>
<p><strong>posdm adddevice COM3 /soname:MsrSimulator</strong></p>
<p>This adds a device with the hardware path COM3 to the <strong>MsrSimulator</strong> Service Object.</p></td>
</tr>
<tr class="odd">
<td><p>addname</p></td>
<td><p>Adds a logical name to a device.</p></td>
<td><p><strong>posdm [general switches] addname</strong><em>devicename</em><strong>filter</strong></p>
<p>where <em>devicename</em> is the logical name to give to the device, and <em>filter</em> is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm addname MainMSR /type:MSR /path:COM3</strong></p>
<p>This adds the logical name <strong>MainMSR</strong> for the MSR device on the COM3 hardware path.</p>
<p><strong>posdm addname BackupMSR /name:MainMSR</strong></p>
<p>This adds the logical name <strong>BackupMSR</strong> for the device named <strong>MainMSR</strong>.</p></td>
</tr>
<tr class="even">
<td><p>addproperty</p></td>
<td><p>Adds a configuration property to a device.</p></td>
<td><p><strong>posdm [general switches] addproperty</strong><em>propertyname value filter</em><strong>[/info]</strong></p>
<p>where <em>propertyname</em> is the name of the property and <em>value</em> is the initial value for that property, and <em>filter</em> is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p>/info is a switch that displays all device properties.</p>
<p><strong>Example:</strong></p>
<p><strong>posdm addproperty PrintSpecialGreeting &quot;Happy New Year!&quot; /name:MainMSR</strong></p>
<p>This adds the <strong>PrintSpecialGreeting</strong> property with the value of &quot;Happy New Year!&quot; to the device named <em>MainMSR</em>.</p></td>
</tr>
<tr class="odd">
<td><p>deletedevice</p></td>
<td><p>Deletes a physical non-Plug and Play device.</p></td>
<td><p><strong>posdm [general switches] deletedevice</strong><em>[path] filter</em></p>
<p>where filter is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm deletedevice COM3 /type:Msr</strong></p>
<p>This deletes the MSR device on COM3.</p>
<p>Only devices previously added by the <strong>adddevice</strong> command can be deleted.</p></td>
</tr>
<tr class="even">
<td><p>deletename</p></td>
<td><p>Deletes a logical name from a device's list of names.</p></td>
<td><p><strong>posdm [general switches] deletename devicename</strong><em>filter</em> [/info]</p>
<p>where <em>filter</em> is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p>and</p>
<p>/info is a switch that displays all device properties.</p>
<p><strong>Example:</strong></p>
<p><strong>posdm deletename &quot;Main Scanner&quot; /type:Scanner /path:COM3</strong></p>
<p>This deletes the logical name Main Scanner for the scanner device on the COM3 path.</p>
<p>Only logical names previously added by the <strong>addname</strong> command can be deleted.</p></td>
</tr>
<tr class="odd">
<td><p>deleteproperty</p></td>
<td><p>Deletes a configuration property from a device.</p></td>
<td><p><strong>posdm [general switches] deleteproperty</strong><em>propertyname filter</em> [/info]</p>
<p>where filter is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p>and</p>
<p>/info is a switch that displays all device properties.</p>
<p><strong>posdm deleteproperty PrintSpecialGreeting /name:MainMSR</strong></p>
<p>This deletes the <strong>PrintSpecialGreeting</strong> property from the device named <strong>MainMSR</strong>.</p>
<p>Only configuration properties previously added by the <strong>addproperty</strong> command can be deleted.</p></td>
</tr>
<tr class="even">
<td><p>disable</p></td>
<td><p>Prevents a Service Object from running for a physical POS device.</p></td>
<td><p><strong>posdm [general switches] disable</strong><em>filter</em></p>
<p>where filter is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm disable /name:ReceiptPrn</strong></p>
<p>This prevents a Service Object from running for a device named <strong>ReceiptPrn</strong>. As a result, applications will not see the device in the list of available POS devices.</p></td>
</tr>
<tr class="odd">
<td><p>enable</p></td>
<td><p>Permits a Service Object to run for a physical POS device.</p></td>
<td><p><strong>posdm [general switches] enable</strong><em>filter</em></p>
<p>where <em>filter</em> is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm enable /type:MSR</strong></p>
<p>This permits a Service Object to run for all MSR devices.</p></td>
</tr>
<tr class="even">
<td><p>info</p></td>
<td><p>Displays information about the device, including its configuration properties.</p></td>
<td><p><strong>posdm [general switches] info</strong><em>filter</em></p>
<p>where filter is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm info /name:MSR1</strong></p>
<p>This command displays information about a device with the logical name &quot;MSR1.&quot;</p></td>
</tr>
<tr class="odd">
<td><p>listdevices</p></td>
<td><p>Lists the physical POS devices.</p></td>
<td><p><strong>posdm [general switches] listdevices [/type:</strong><em>devicetype</em><strong>]</strong></p>
<p>where the <strong>/type:</strong><em>devicetype</em> switch narrows the list to a particular type of device.</p>
<p><strong>Examples:</strong></p>
<p><strong>posdm listdevices</strong></p>
<p>This displays a list of all physical POS devices installed on the local computer.</p>
<p><strong>posdm listdevices /type:MSR</strong></p>
<p>This displays a list of all MSR devices installed on the local computer.</p>
<p><strong>posdm /machine:Center10 /username:JohnDoe3 /password:B$tg59ce listdevices</strong></p>
<p>This lists all physical POS devices installed on the computer named Center10, after logging on with username and password credentials.</p></td>
</tr>
<tr class="even">
<td><p>listnames</p></td>
<td><p>Lists the logical names associated with POS devices.</p></td>
<td><p><strong>posdm [general switches] listnames</strong> <em>filter</em></p>
<p>where <em>filter</em> is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm listnames /type:MSR /path:COM3</strong></p>
<p>This displays a list of names associated with the MSR device on COM3.</p></td>
</tr>
<tr class="odd">
<td><p>listprops</p></td>
<td><p>Lists the configuration properties associated with a POS device and their values.</p></td>
<td><p><strong>posdm [general switches] listprops</strong><em>filter</em></p>
<p>where filter is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm listprops /type:MSR /path:COM3</strong></p>
<p>This displays a list of property names and values associated with the MSR device on COM3.</p></td>
</tr>
<tr class="even">
<td><p>listsos</p></td>
<td><p>Lists the POS Service Objects on the target machine.</p></td>
<td><p><strong>posdm [general switches] listsos [/type:</strong><em>devicetype</em><strong>]</strong></p>
<p>where the <strong>/type:</strong><em>devicetype</em> switch narrows the list to a particular type of device.</p>
<p><strong>Examples:</strong></p>
<p><strong>posdm /output:a:\solist.txt listsos</strong></p>
<p>This writes a list of all Service Objects installed on the local computer to a file named solist.txt on drive A.</p>
<p><strong>posdm listsos /type:MSR</strong></p>
<p>This displays a list of all Service Objects associated with MSR devices on the local computer.</p>
<p><strong>posdm /machine:Center10 /username:JohnDoe3 /password:B$tg59ce listsos</strong></p>
<p>This lists all Service Objects on the computer named Center10, after logging on with username and password credentials.</p></td>
</tr>
<tr class="odd">
<td><p>setdefault</p></td>
<td><p>Sets one device as the default of its <em>type</em>.</p>
<p>The default flag directs the PosExplorer.GetDevice(<em>type</em>) method to return this device even if there is more than one device of the type available.</p></td>
<td><p><strong>posdm [general switches] setdefault</strong> <strong><em>ON|OFF filter</em></strong> <strong>[/info]</strong></p>
<p>where <em>filter</em> is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p>The /info switch causes all device properties to be displayed.</p>
<p><strong>Example:</strong></p>
<p><strong>posdm setdefault ON /name:FirstScanner</strong></p>
<p>This example designates <strong>FirstScanner</strong> as the one the CCL device enumeration will find.</p></td>
</tr>
<tr class="even">
<td><p>setpath</p></td>
<td><p>Sets the POS device path for non-Plug and Play devices.</p></td>
<td><p><strong>posdm [general switches] setpath</strong> <em>hardware_path filter</em></p>
<p>where <em>filter</em> is one or more of the following needed to uniquely identify a device:</p>
<p>/type:<em>devicetype</em></p>
<p>/soname:<em>soname</em></p>
<p>/path:<em>hardware_path</em></p>
<p>/name:<em>devicename</em></p>
<p><strong>Example:</strong></p>
<p><strong>posdm setpath COM2 /type:MSR</strong></p>
<p>This sets the hardware path for MSR devices to COM2.</p>
<p>The <strong>setpath</strong> command works only for non-Plug and Play devices previously added with the <strong>adddevice</strong> command.</p></td>
</tr>
</tbody>
</table>
<!-- markdownlint-enable MD033 -->

## See Also

#### Concepts

- [POSDM Command Arguments](posdm-command-arguments.md)
- [Command-Line Help for POSDM](command-line-help-for-posdm.md)

#### Other Resources

- [Using the POS Device Manager Command-Line Tool](using-the-pos-device-manager-command-line-tool.md)
