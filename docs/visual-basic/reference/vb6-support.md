---
title: "Support Statement for Visual Basic 6.0 | Microsoft Docs"
ms.date: "2017-03-23"
ms.prod: VB
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "VB6 support"
  - "Visual Basic 6.0 support"
ms.assetid: ffc5ba4d-44d7-4ef7-a3f6-38a8738bf127
author: "paulyuk"
ms.author: "paulyuk"
---
# Support Statement for Visual Basic 6.0 on Windows Vista, Windows Server 2008, Windows 7, Windows 8 and Windows 8.1, Windows Server 2012, Windows 10, and Windows Server 2016

Update: March 2016

## Executive summary

The Visual Basic team is committed to "It Just Works" compatibility for Visual Basic 6.0 applications on the following supported Windows operating systems: 
- Windows Vista
- Windows Server 2008 including R2
- Windows 7
- Windows 8 and Windows 8.1
- Windows Server 2012 including R2
- Windows 10
- Windows Server 2016
 
The Visual Basic team’s goal is that Visual Basic 6.0 applications continue to run on supported Windows versions. As detailed in this document, the core Visual Basic 6.0 runtime will be supported for the full lifetime of supported Windows versions, which is five years of mainstream support followed by five years of extended support (http://support.microsoft.com/gp/lifepolicy). The support bar will be limited to serious regressions and critical security issues for existing applications.

## Technical summary

Visual Basic 6.0 is made up of these key deliverables:
- Visual Basic 6.0 IDE (Integrated Development Environment).
- Visual Basic 6.0 Runtime: the base libraries and execution engine used to run VB 6.0 applications.
- Visual Basic 6.0 Runtime Extended Files: selected ActiveX control OCX files, libraries, and tools shipping with the IDE media and as an online release.

## The Visual Basic 6.0 IDE

The Visual Basic 6.0 IDE is no longer supported as of April 8, 2008. However, Custom Support Agreements may be available from Microsoft. Additionally, both the Windows and Visual Basic teams have tested Visual Basic 6.0 IDE on Windows Vista, Windows 7, Windows Server 2008, Windows 8, and Windows 8.1 to understand and mitigate (if appropriate) compatibility issues on 32-bit versions of Windows (see the [64-Bit Windows](#62-bit-windows) section below for further information about 64-bit systems). This announcement does not change the support policy for the IDE.

## The Visual Basic 6.0 runtime

The Visual Basic 6.0 runtime is defined as the compiled binary files originally included in the redistribution list for Visual Basic 6.0. These files were marked as distributable in the original Visual Basic 6.0 license. Examples of these files include the Visual Basic 6.0 runtime library (`msvbvm60.dll`), controls (i.e., `msflxgrd.ocx`) along with runtime support files for other major functional areas (i.e. MDAC).

The runtime is divided into the three groups:

- Supported runtime files -- Shipping in the OS

   Key Visual Basic 6.0 runtime files, used in the majority of application scenarios, are shipping in and supported for the lifetime of supported Windows versions. This lifetime is five years of mainstream support and five years of extended support from the time that a given version of Windows ships. These files have been tested for compatibility as part of our testing of Visual Basic 6.0 applications running on supported Windows versions. 

   > [!NOTE]
   > All supported Windows versions contain a nearly identical list of files, and the redist requirements for applications containing these files should be nearly identical. One key difference is that `TriEdit.dll` was removed from Windows Vista and later versions.

- Supported runtime files –- Extended files to distribute with your application

   This extended list consists of key controls, libraries, and tools that are installed from the IDE media or from Microsoft.com to the developer machine. Typically, the VB6 IDE installed these controls to the developer machine by default. The developer still needs to redistribute these files with the application. The supported version of the files is available online on the Microsoft Download Center (http://go.microsoft.com/fwlink/?LinkID=142927).

- Unsupported runtime files

   Some files either have fallen out of mainstream support or were never included as a part of the runtime redist (e.g., they were included in the `\Tools` folder on the IDE media to support legacy VB4/VB5 applications, or they were third-party controls). These files are not supported on Windows; instead they are subject to whatever support agreement applies to the media they were shipped with. This implies no warranties around support and servicing. In some instances, later versions of these libraries are supported. Details on backward compatibility or migration to supported versions are provided below.

For specific details on the files included in each support group see the [Runtime Definition](#runtime-definition) section below.

## The Visual Basic 6.0 support lifetime

Supporting and/or shipping Visual Basic 6.0 runtime binaries on supported Windows versions does not change the support policy for the Visual Basic 6.0 IDE or Visual Studio 6.0 IDE as a whole. Those products moved out of extended support on April 8, 2008.

Details on the support lifecycle of Microsoft products can be found at http://support.microsoft.com/gp/lifepolicy. As a part of this support lifecycle, Microsoft will continue to support the Visual Basic 6.0 runtime on supported Windows versions for the support lifetime of those operating systems. This means, for example, that the Visual Basic 6.0 runtime will be supported on Windows Server 2003 until June, 2008 for Mainstream Support and June, 2013 for Extended Support.
For more details on the support lifecycle or to find out about additional support options, please visit our support page at 
http://www.microsoft.com/support.

## 64-Bit Windows

Visual Basic 6.0 runtime files are 32-bit. These files ship in 64-bit Windows Operating Systems referenced in the table below. 32-bit VB6 applications and components are supported in the WOW emulation environment only. 32-bit components must also be hosted in 32-bit application processes.

The Visual Basic 6.0 IDE has never been offered in a native 64-bit version, nor has the 32-bit IDE been supported on 64-bit Windows. VB6 development on 64-bit Windows or any native architecture other than 32-bit is not and will not be supported.

## Windows 7

Since the initial release of this support statement, the Windows 7 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows 7.

The VB6 runtime will ship and will be supported in Windows 7 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows 7 as being the same as it is for Windows Vista.

## Windows 8

Since the initial release of this support statement, the Windows 8 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows 8.

The VB6 runtime will ship and will be supported in Windows 8 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows 8 as being the same as it is for Windows 7.

## Windows 8.1

Since the initial release of this support statement, the Windows 8.1 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows 8.1.

The VB6 runtime will ship and will be supported in Windows 8.1 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows 8.1 as being the same as it is for Windows 8.

## Windows 10

Since the initial release of this support statement, the Windows 10 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows 10.

The VB6 runtime will ship and will be supported in Windows 10 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows 10 as being the same as it is for Windows 8.1.

## Windows Server 2008

Since the initial release of this support statement, the Windows Server 2008 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows Server 2008.

The VB6 runtime will ship and will be supported in Windows Server 2008 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows Server 2008 as being the same as it is for Windows Vista.

## Windows Server 2008 R2

Since the initial release of this support statement, the Windows Server 2008 R2 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows Server 2008 R2.

The VB6 runtime will ship and will be supported in Windows Server 2008 R2 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows Server 2008 R2 as being the same as it is for Windows Server 2008.

## Windows Server 2012

Since the initial release of this support statement, the Windows Server 2012 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows Server 2012.

The VB6 runtime will ship and will be supported in Windows Server 2012 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows Server 2012 as being the same as it is for Windows Server 2008 R2.

## Windows Server 2012 R2

Since the initial release of this support statement, the Windows Server 2012 R2 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows Server 2012 R2.

The VB6 runtime will ship and will be supported in Windows Server 2012 R2 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows Server 2012 R2 as being the same as it is for Windows Server 2012.

## Windows Server 2016

Since the initial release of this support statement, the Windows Server 2016 operating system has been released. This document has been updated to clarify Microsoft’s support for VB6 on Windows Server 2016.

The VB6 runtime will ship and will be supported in Windows Server 2016 for the lifetime of the OS. Visual Basic 6.0 runtime files continue to be 32-bit only, and all components must be hosted in 32-bit application processes. Developers can think of the support story for Windows Server 2016 as being the same as it is for Windows Server 2012.

## Supported Windows operating system versions

This section provides additional information regarding the operating systems that offer some level of support for VB6. 

|Windows operating system|VB6 Supported Runtime</br>Files Shipping in Windows have support?|VB6 Supported Rutime</br>Extended Files</br>to distribute with your application have support?| VB6 IDE has support?|
|---|---|---|---|
|Windows 10, all 32-bit editions|Yes *|Yes *|No, but Custom Support Agreements may be available.|
|Windows 10, all 64-bit editions (WOW only)|Yes * </br> 32-bit apps running in WOW only|Yes* </br> 32-bit apps running in WOW only|No|
|Windows 8.1, all 32-bit editions|Yes *|Yes *|No, but Custom Support Agreements may be available.|
| Windows 8.1, all 64-bit editions (WOW only)|Yes * </br> 32-bit apps running in WOW only|Yes* </br> 32-bit apps running in WOW only|No|
|Windows Server 2012 R2, all 64-bit editions (WOW only)<br>Windows Server 2012, all 64-bit editions (WOW only)|Yes* </br> 32-bit apps running in WOW only|Yes* </br> 32-bit apps running in WOW only|No|
|Windows 8, all 32-bit editions|Yes *|Yes *|No, but Custom Support Agreements may be available.|
|Windows 8, all 64-bit editions (WOW only)|Yes * </br> 32-bit apps running in WOW only|Yes * </br> 32-bit apps running in WOW only|No|
|Windows 7, all 32-bit editions|Yes *|Yes *|No, but Custom Support Agreements may be available.|
|Windows 7, all 64-bit editions (WOW only)|Yes * </br> 32-bit apps running in WOW only|Yes * </br> 32-bit apps running in WOW only|No|
| Windows Vista, all  32-bit editions|Yes *|Yes *|No, but Custom Support Agreements may be available.|
|Windows Vista, all x64 editions (WOW only)|Yes * </br> 32-bit apps running in WOW only|Yes * </br> 32-bit apps running in WOW only|No|
|Windows Server 2008 R2, all x64 editions (WOW only)</br>Windows Server 2008, all x64 editions (WOW only)|Yes * </br> 32-bit apps running in WOW only|Yes * </br> 32-bit apps running in WOW only|No|
|Windows Server 2008, all 32-bit editions|Yes *|Yes *|No, but Custom Support Agreements may be available.|
|Windows 2003 server, all 32-bit editions including R2|Yes *|Yes *|No, but Custom Support Agreements may be available.|
|Windows 2003 server. all x64 editions including R2|Yes * </br> 32-bit apps running in WOW only|Yes * </br> 32-bit apps running in WOW only|No|

> [!NOTE]
> &#42;  VB6 runtime support is limited by the OS support lifecycle.  For example, if the target OS is in Extended support, VB6 cannot have a higher level of support than Extended support.

## Visual Basic 6.0 runtime usage inside VBA and Office

Visual Basic for Applications, or VBA, is a distinct technology commonly used for application automation and macros inside of other applications, most commonly inside Microsoft Office applications. VBA ships as a part of Office and therefore the support for VBA is governed by the support policy of Office. However, there are situations where VBA is used to call or host Visual Basic 6.0 runtime binaries and controls. In these situations, Visual Basic 6.0 supported runtime files in the OS and the extended file list are also supported when used inside of a supported VBA environment.

For VB6 runtime scenarios to be supported inside VBA, all of the following must be true:

- The host OS version for VB runtime is still supported.
- The host version of Office for VBA is still supported.
- The runtime files in question are still supported.

## Visual Basic Script (VBScript)

VBScript is unrelated to Visual Basic 6.0 and this support statement. However, VBScript is currently shipping as part of Windows Vista, Windows Server 2008 including R2, Windows 7, Windows 8, Windows 8.1, Windows Server 2012 including R2, Windows 10, and Windows Server 2016 and is governed by the OS support lifecycle.

## Third-party components

Microsoft is unable to provide support for third party components, such as OCX/ActiveX controls. Customers are encouraged to contact the original control vendor for details on support for those components.

## Reporting issues with VB 6.0 applications running on Windows Vista, Windows 7, Windows Server 2008, Windows 8, Windows 8.1, Windows Server 2012, Windows 10, and Windows Server 2016

Developers planning to use Visual Basic 6.0 with one of the listed Windows operating system should install that operating system and begin application compatibility testing using original application acceptance testing.

If you find an issue with your Visual Basic 6.0 application running on Windows Vista, Windows 7, Windows Server 2008, Windows 8, Windows 8.1, Windows Server 2012, Windows 10, or Windows Server 2016, please follow your normal support channels to report the issue.

## Supported and shipping in Windows Vista, Windows 7, Windows Server 2008, Windows 8, Windows 8.1, Windows Server 2012, Windows 10, and Windows Server 2016

| | | | |
|---|---|---|---|
|atl.dll|         msadcor.dll|     msorcl32.dll|   ole2.dll|
|asycfilt.dll|    msadcs.dll|      msvbvm60.dll|   ole32.dll|
|comcat.dll|      msadds.dll|      msvcirt.dll|    oleaut32.dll|
|compobj.dll|     msaddsr.dll|     msvcrt.dll|     oleaut32.dll|
|dbnmpntw.dll|    msader15.dll|    msvcrt40.dll|   oledb32.dll|
|dcomcnfg.exe|    msado15.dll|     mtxdm.dll|      oledb32r.dll|
|dllhost.exe|     msador15.dll|    mtxoci.dll|     oledlg.dll|
|ds16gt.dll|      msadrh15.dll|    odbc16gt.dll|   olepro32.dll|
|ds32gt.dll|      mscpxl32.dll|    odbc32.dll|     olethk32.dll|
|expsrv.dll|      msdadc.dll|      odbc32gt.dll|   regsvr32.exe|
|hh.exe|          msdaenum.dll|    odbcad32.exe|   rpcns4.dll|
|hhctrl.ocx|      msdaer.dll|      odbccp32.cpl|   rpcrt4.dll|
|imagehlp.dll|    msdaora.dll|     odbccp32.dll|   scrrun.dll|
|iprop.dll|       msdaosp.dll|     odbccr32.dll|   secur32.dll|
|itircl.dll|      msdaprst.dll|    odbccu32.dll|   simpdata.tlb|
|itss.dll|        msdaps.dll|      odbcint.dll|    sqloledb.dll|
|mfc40.dll|       msdasc.dll|      odbcji32.dll|   sqlsrv32.dll|
|mfc42.dll|       msdasql.dll|     odbcjt32.dll|   stdole2.tlb|
|mfc42enu.dll|    msdasqlr.dll|    odbctrac.dll|   stdole32.tlb|
|msadce.dll|      msdatsrc.tlb|    oddbse32.dll|   storage.dll|
|msadcer.dll|     msdatt.dll|      odexl32.dll|    vbajet32.dll|
|msadcf.dll|      msdfmap.dll|     odfox32.dll|    vfpodbc.dll|
|msadcfr.dll|     msdfmap.ini|     odpdx32.dll|                |
|msadco.dll|      msjtes40.dll|    odtext32.dll|               |

## Supported runtime files to distribute with your application

| | | | |
|---|---|---|---|
|comct232.ocx |msbind.dll   |msdbrptr.dll  |msstdfmt.dll| 
|comct332.ocx |mscdrun.dll  |msflxgrd.ocx  |msstkprp.dll| 
|comctl32.ocx |mschrt20.ocx |mshflxgd.ocx  |mswcrun.dll|  
|comdlg32.ocx |mscomct2.ocx |mshtmpgr.dll  |mswinsck.ocx| 
|dbadapt.dll  |mscomctl.ocx |msinet.ocx    |picclp32.ocx| 
|dbgrid32.ocx |mscomm32.ocx |msmapi32.ocx  |richtx32.ocx| 
|dblist32.ocx |msdatgrd.ocx |msmask32.ocx  |sysinfo.ocx|  
|mci32.ocx    |msdatlst.ocx |msrdc20.ocx   |tabctl32.ocx| 
|msadodc.ocx  |msdatrep.ocx |msrdo20.dll

## Unsupported, but supported and compatible updates or upgrades are available

| | | | |
|---|---|---|---|
|dao350.dll|   msexch35.dll| msjter35.dll| msrepl35.dll|
|mdac_typ.exe| msexcl35.dll| msjtor35.dll| mstext35.dll|
|mschart.ocx|  msjet35.dll|  msltus35.dll| msxbse35.dll|
|msdaerr.dll|  msjint35.dll| mspdox35.dll| odbctl32.dll|
|msdatl2.dll|  msjt4jlt.dll| msrd2x35.dll| oledb32x.dll|

## Unsupported runtime files

| | | | |
|---|---|---|---|
|anibtn32.ocx| spin32.ocx|   rpcltscm.dll|  rdocurs.dll|
|graph32.ocx|  gauge32.ocx|  rpcmqcl.dll|   vbar332.dll|
|keysta32.ocx| gswdll32.dll| rpcmqsvr.dll|  visdata.exe|
|autmgr32.exe| ciscnfg.exe|  rpcss.exe|     vsdbflex.srg|
|autprx32.dll| olecnv32.dll| dbmsshrn.dll|  threed32.ocx|
|racmgr32.exe| rpcltc1.dll|  dbmssocn.dll|  MSWLess.ocx|
|racreg32.dll| rpcltc5.dll|  windbver.exe|  tlbinf32.dll|
|grid32.ocx|   rpcltccm.dll| msderun.dll|   triedit.dll|
|msoutl32.ocx| rpclts5.dll|  odkob32.dll|

## Localization support binaries

The following binaries are necessary for supporting Visual Basic 6.0 applications running on localized versions of the Windows operating system. They are supported but are not shipped in Windows. These files are required to be shipped with your application setup.

### Supported runtime files to distribute with your application

|JPN|KOR|CHT|CHS|
|---|---|---|---|
|mfc42jpn.dll|  mfc42kor.dll|  mfc42cht.dll|  mfc42chs.dll|
|scrrnjp.dll|   scrrnko.dll|   scrrncht.dll|  scrrnchs.dll|
|vb6jp.dll|     vb6ko.dll|     vb6cht.dll|    vb6chs.dll|
|cmct2jp.dll|   cmct2ko.dll|   cmct2cht.dll|  cmct2chs.dll|
|cmct3jp.dll|   cmct3ko.dll|   cmct3cht.dll|  mscc2chs.dll|
|mscc2jp.dll|   mscc2ko.dll|   mscc2cht.dll|  cmct3chs.dll|
|cmctljp.dll|   cmctlko.dll|   cmctlcht.dll|  cmctlchs.dll|
|cmdlgjp.dll|   cmdlgko.dll|   mscmccht.dll|  mscmcchs.dll|
|mscmcjp.dll|   mscmcko.dll|   cmdlgcht.dll|  cmdlgchs.dll|
|dbgrdjp.dll|   dbgrdko.dll|   dbgrdcht.dll|  dbgrdchs.dll|
|dblstjp.dll|   dblstko.dll|   dblstcht.dll|  dblstchs.dll|
|mcijp.dll|     mciko.dll|     mcicht.dll|    mcichs.dll|
|msadnjp.dll|   msadnko.dll|   msadncht.dll|  msadnchs.dll|
|adodcjp.dll|   adodcko.dll|   adodccht.dll|  adodcchs.dll|
|mschtjp.dll|   mschtko.dll|   mschtcht.dll|  mschtchs.dll|
|msch2jp.dll|   msch2ko.dll|   msch2cht.dll|  msch2chs.dll|
|mscomjp.dll|   mscomko.dll|   mscomcht.dll|  mscomchs.dll|
|datgdjp.dll|   datgdko.dll|   datgdcht.dll|  datgdchs.dll|
|datlsjp.dll|   datlsko.dll|   datlscht.dll|  datlschs.dll|
|datrpjp.dll|   datrpko.dll|   datrpcht.dll|  datrpchs.dll|
|dbrprjp.dll|   dbrprko.dll|   dbrprcht.dll|  dbrprchs.dll|
|flxgdjp.dll|   flxgdko.dll|   flxgdcht.dll|  flxgdchs.dll|
|mshfgjpn.dll|  mshfgkor.dll|  mshfgcht.dll|  mshfgchs.dll|
|htmprjp.dll|   htmprko.dll|   htmprcht.dll|  htmprchs.dll|
|inetjp.dll|    inetko.dll|    inetcht.dll|   inetchs.dll|
|msmpijp.dll|   msmpiko.dll|   msmpicht.dll|  msmpichs.dll|
|msmskjp.dll|   msmskko.dll|   msmskcht.dll|  msmskchs.dll|
|rdc20jp.dll|   rdc20ko.dll|   rdc20cht.dll|  rdc20chs.dll|
|rdo20jp.dll|   rdo20ko.dll|   rdo20cht.dll|  rdo20chs.dll|
|stdftjp.dll|   stdftko.dll|   stdftcht.dll|  stdftchs.dll|
|mswcrjp.dll|   mswcrko.dll|   mswcrcht.dll|  mswcrchs.dll|
|winskjp.dll|   winskko.dll|   winskcht.dll|  winskchs.dll|
|pcclpjp.dll|   pcclpko.dll|   pcclpcht.dll|  pcclpchs.dll|
|rchtxjp.dll|   rchtxko.dll|   rchtxcht.dll|  rchtxchs.dll|
|sysinjp.dll|   sysinko.dll|   sysincht.dll|  sysinchs.dll|
|tabctjp.dll|   tabctko.dll|   tabctcht.dll|  tabctchs.dll|

|ITA|FRA|ESP|DEU|
|---|---|---|---|
|mfc42ita.dll|  mfc42fra.dll|  mfc42esp.dll|  mfc42deu.dll|
|scrrnit.dll|   scrrnfr.dll|   scrrnes.dll|   scrrnde.dll|
|vb6it.dll|     vb6fr.dll|     vb6es.dll|     vb6de.dll|
|cmct2it.dll|   cmct2fr.dll|   cmct2es.dll|   cmct2de.dll|
|mscc2it.dll|   mscc2fr.dll|   mscc2es.dll|   mscc2de.dll|
|cmct3it.dll|   cmct3fr.dll|   cmct3es.dll|   cmct3de.dll|
|cmctlit.dll|   cmctlfr.dll|   cmctles.dll|   cmctlde.dll|
|mscmcit.dll|   mscmcfr.dll|   mscmces.dll|   mscmcde.dll|
|cmdlgit.dll|   cmdlgfr.dll|   cmdlges.dll|   cmdlgde.dll|
|dbgrdit.dll|   dbgrdfr.dll|   dbgrdes.dll|   dbgrdde.dll|
|dblstit.dll|   dblstfr.dll|   dblstes.dll|   dblstde.dll|
|mciit.dll|     mcifr.dll|     mcies.dll|     mcide.dll|
|msadnit.dll|   msadnfr.dll|   msadnes.dll|   msadnde.dll|
|adodcit.dll|   adodcfr.dll|   adodces.dll|   adodcde.dll|
|mschtit.dll|   mschtfr.dll|   mschtes.dll|   mschtde.dll|
|msch2it.dll|   msch2fr.dll|   msch2es.dll|   msch2de.dll|
|mscomit.dll|   mscomfr.dll|   mscomes.dll|   mscomde.dll|
|atgdit.dll|    datgdfr.dll|   datgdes.dll|   datgdde.dll|
|datlsit.dll|   datlsfr.dll|   datlses.dll|   datlsde.dll|
|datrpit.dll|   datrpfr.dll|   datrpes.dll|   datrpde.dll|
|dbrprit.dll|   dbrprfr.dll|   dbrpres.dll|   dbrprde.dll|
|flxgdit.dll|   flxgdfr.dll|   flxgdes.dll|   flxgdde.dll|
|mshfgit.dll|   mshfgfr.dll|   mshfges.dll|   mshfgde.dll|
|htmprit.dll|   htmprfr.dll|   htmpres.dll|   htmprde.dll|
|inetit.dll|    inetfr.dll|    inetes.dll|    inetde.dll|
|msmpiit.dll|   msmpifr.dll|   msmpies.dll|   msmpide.dll|
|msmskit.dll|   msmskfr.dll|   msmskes.dll|   msmskde.dll|
|rdc20it.dll|   rdc20fr.dll|   rdc20es.dll|   rdc20de.dll|
|rdo20it.dll|   rdo20fr.dll|   rdo20es.dll|   rdo20de.dll|
|stdftit.dll|   stdftfr.dll|   stdftes.dll|   stdftde.dll|
|mswcrit.dll|   mswcrfr.dll|   mswcres.dll|   mswcrde.dll|
|winskit.dll|   winskfr.dll|   winskes.dll|   winskde.dll|
|pcclpit.dll|   pcclpfr.dll|   pcclpes.dll|   pcclpde.dll|
|rchtxit.dll|   rchtxfr.dll|   rchtxes.dll|   rchtxde.dll|
|sysinit.dll|   sysinfr.dll|   sysines.dll|   sysinde.dll|
|tabctit.dll|   tabctfr.dll|   tabctes.dll|   tabctde.dll|

