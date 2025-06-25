---
title: Manually manage your POS for .NET devices (POS for .NET v1.14 SDK Documentation)
description: Manually manage your POS for .NET devices (POS for .NET v1.14 SDK Documentation) (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Manually manage your POS for .NET devices (POS for .NET v1.14 SDK Documentation)

You can manually perform most Microsoft Point of Service for .NET (POS for .NET) device management tasks without using the POS device manager (posdm.exe).

## Manually managing POS for .NET devices

You can manually edit the POS for .NET configuration XML file to replicate most of the functionality available with posdm.exe.

You can find the location of the POS for .NET configuration XML file in the **Configuration** value under the registry key **HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Wow6432Node\\POSfor.NET**.

The default location for the configuration file is *%ProgramData%\\*Microsoft\\Point Of Service\\Configuration\\Configuration.xml

The following table lists posdm.exe commands and the equivalent XML that you must add to the configuration xml file.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
<col />
<col />
</colgroup>
<tbody>
<tr class="odd">
<td><p><strong>Posdm.exe command</strong></p></td>
<td><p><strong>Description</strong></p></td>
<td><p><strong>Configuration.xml</strong></p></td>
<td><p><strong>Example</strong></p></td>
</tr>
<tr class="even">
<td><p>ADDDEVICE</p></td>
<td><p>Add a physical non-Plug and Play device.</p></td>
<td><pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;[Service Object Name]&quot; Type=&quot;[Device Type]&quot;&gt;
    &lt;Device HardwarePath=&quot;[Hardware Path]&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
<td><p>Posdm.exe command:</p>
<p><code>Posdm ADDDEVICE COM1 /SONAME:&quot;Microsoft Msr Simulator&quot; /Type:msr</code></p>
<p>Configuration.xml:</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;Microsoft Msr Simulator&quot; Type=&quot;Msr&quot;&gt;
    &lt;Device HardwarePath=&quot;COM1&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
</tr>
<tr class="odd">
<td><p>ADDNAME</p></td>
<td><p>Add a name to a device's list of names.</p></td>
<td><pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;[Service Object Name]&quot; Type=&quot;[Device Type]&quot;&gt;
    &lt;Device HardwarePath=&quot;[Hardware Path]&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
      &lt;LogicalName Name=&quot;[Device Name]&quot; /&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
<td><p>Posdm.exe command:</p>
<p><code>Posdm ADDNAME MyName /SONAME:&quot;Microsoft Msr Simulator&quot; /Path:COM1</code></p>
<p>Configuration.xml:</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;Microsoft Msr Simulator&quot; Type=&quot;Msr&quot;&gt;
    &lt;Device HardwarePath=&quot;COM1&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
     &lt;LogicalName Name=&quot;MyName&quot; /&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
</tr>
<tr class="even">
<td><p>ADDPROPERTY</p></td>
<td><p>Add a property to a device.</p></td>
<td><pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;[Service Object Name]&quot; Type=&quot;[Device Type]&quot;&gt;
    &lt;Device HardwarePath=&quot;[Hardware Path]&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
      &lt;Property Name=&quot;[Property Name]&quot; Value=&quot;[Property Value]&quot; /&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
<td><p>Posdm.exe command:</p>
<p><code>Posdm addproperty MyProperty MyValue /Name:MyName</code></p>
<p>Configuration.xml:</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;Microsoft Msr Simulator&quot; Type=&quot;Msr&quot;&gt;
    &lt;Device HardwarePath=&quot;COM1&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
     &lt;LogicalName Name=&quot;MyName&quot; /&gt;
     &lt;Property Name=&quot;MyProperty&quot; Value=&quot;MyValue&quot; /&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
</tr>
<tr class="odd">
<td><p>DELETEDEVICE</p></td>
<td><p>Delete a physical non-Plug and Play device.</p></td>
<td><p>Remove the &lt;Device&gt; node.</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>DELETENAME</p></td>
<td><p>Delete a name from a device's list of names</p></td>
<td><p>Remove the &lt;LogicalName&gt; node.</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>DELETEPROPERTY</p></td>
<td><p>Delete a property from a device.</p></td>
<td><p>Remove the &lt;Property&gt; node.</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>DISABLE</p></td>
<td><p>Disable an SO on a POS device.</p></td>
<td><p>Set <code>Enabled=&quot;no&quot;</code> and <code>Default=&quot;no&quot;</code> on the &lt;Device&gt; node.</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;[Service Object Name]&quot; Type=&quot;[Device Type]&quot;&gt;
    &lt;Device HardwarePath=&quot;[Hardware Path]&quot; Enabled=&quot;no&quot; PnP=&quot;no&quot; Default=&quot;no&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
<td><p>Posdm.exe command:</p>
<p><code>Posdm disable /Path:COM1</code></p>
<p>Configuration.xml:</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;Microsoft Msr Simulator&quot; Type=&quot;Msr&quot;&gt;
    &lt;Device HardwarePath=&quot;COM1&quot; Enabled=&quot;no&quot; PnP=&quot;no&quot; Default=&quot;no&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
</tr>
<tr class="odd">
<td><p>ENABLE</p></td>
<td><p>Enable an SO on a POS device.</p></td>
<td><p>Set <code>Enabled=&quot;yes&quot;</code> on the &lt;Device&gt; node.</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>INFO</p></td>
<td><p>Displays the device properties.</p></td>
<td><p>N/A</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>LISTDEVICES</p></td>
<td><p>List the POS devices on the target &lt;host&gt;.</p></td>
<td><p>N/A</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>LISTNAMES</p></td>
<td><p>List the names associated with POS devices.</p></td>
<td><p>N/A</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>LISTPROPS</p></td>
<td><p>List the properties associated with a device.</p></td>
<td><p>N/A</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>LISTSOS</p></td>
<td><p>List the POS service objects on the target &lt;host&gt;.</p></td>
<td><p>The service object search paths are all of the values under the registry key:</p>
<p><strong>HKLM\Software\Wow6432Node\Posfor.NET\ControlAssemblies</strong></p>
<p>The default search path is:</p>
<p><em>%CommonProgramFiles(x86)%</em>\Microsoft Shared\Point Of Service\Control Assemblies\</p>
<p>POS for .NET will attempt to load all service object DLL's found in these paths.</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>SETDEFAULT</p></td>
<td><p>Set one device as the default of its &lt;type&gt;.</p></td>
<td><p>Set <code>Default=&quot;yes&quot;</code> on the &lt;Device&gt; node.</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;[Service Object Name]&quot; Type=&quot;[Device Type]&quot;&gt;
    &lt;Device HardwarePath=&quot;[Hardware Path]&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot; Default=&quot;yes&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
<td><p>Posdm.exe command:</p>
<p><code>Posdm SETDEFAULT ON /Path:COM1</code></p>
<p>Configuration.xml:</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;Microsoft Msr Simulator&quot; Type=&quot;Msr&quot;&gt;
    &lt;Device HardwarePath=&quot;COM1&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;  Default=&quot;yes&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
</tr>
<tr class="even">
<td><p>SETPATH</p></td>
<td><p>Sets the non-Plug and Play POS device &lt;path&gt;.</p></td>
<td><pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;[Service Object Name]&quot; Type=&quot;[Device Type]&quot;&gt;
    &lt;Device HardwarePath=&quot;[Hardware Path]&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
<td><p>Posdm.exe command:</p>
<p><code>Posdm SETPATH COM2 /SONAME:&quot;Microsoft Msr Simulator&quot; /Type:msr</code></p>
<p>Configuration.xml:</p>
<pre><code>&lt;PointOfServiceConfig Version=&quot;1.0&quot;&gt;
  &lt;ServiceObject Name=&quot;Microsoft Msr Simulator&quot; Type=&quot;Msr&quot;&gt;
    &lt;Device HardwarePath=&quot;COM2&quot; Enabled=&quot;yes&quot; PnP=&quot;no&quot;&gt;
    &lt;/Device&gt;
  &lt;/ServiceObject&gt;
&lt;/PointOfServiceConfig&gt;</code></pre></td>
</tr>
</tbody>
</table>
<!-- markdownlint-enable MD033 -->
