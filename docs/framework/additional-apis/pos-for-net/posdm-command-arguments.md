---
title: POSDM Command Arguments
description: POSDM Command Arguments (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# POSDM Command Arguments (POS for .NET v1.14 SDK Documentation)

The following switches can be used as arguments for POSDM commands.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
</colgroup>
<tbody>
<tr class="odd">
<td><p><strong>Command Switch</strong></p></td>
<td><p><strong>Description</strong></p></td>
</tr>
<tr class="even">
<td><p>/type:<em>devicetype</em></p></td>
<td><p>The device type as determined by the Service Object supplier.</p>
<p>Example: <strong>/type:msr</strong> specifies a magnetic strip reader.</p></td>
</tr>
<tr class="odd">
<td><p>/soname:<em>soname</em></p></td>
<td><p>The Service Object name from the Service Object supplier. Names containing spaces must be enclosed in double quotation marks (&quot;).</p>
<p>Example: <strong>/soname:&quot;Super MSR&quot;</strong> specifies a Service Object named Super MSR.</p></td>
</tr>
<tr class="even">
<td><p>/path:<em>hardware_path</em></p></td>
<td><p>The hardware path for the device.</p>
<p>Example: <strong>/path:COM2</strong> specifies a location of COM2.</p></td>
</tr>
<tr class="odd">
<td><p>/name:<em>devicename</em></p></td>
<td><p>The logical name for the device. This is useful when there are multiple instances of the Service Object, and also provides a way for an application to refer to a Service Object without hard coding. This name must be unique within <strong>devicetype</strong>. If a name contains a space, it must be contained within double quotation marks (&quot; &quot;).</p>
<p>Examples: <strong>/name:msr4</strong> refers to a device with the logical name msr4, <strong>/name:&quot;Main MSR&quot;</strong> refers to a device with the logical name of Main MSR.</p></td>
</tr>
</tbody>
</table>
<!-- markdownlint-enable MD033 -->

## See Also

#### Concepts

- [POSDM Commands](posdm-commands.md)

#### Other Resources

- [Using the POS Device Manager Command-Line Tool](using-the-pos-device-manager-command-line-tool.md)
