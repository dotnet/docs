---
title: What's New in POS for .NET v1.14 and v1.14.1
ms.date: 04/12/2017
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# What's New in POS for .NET v1.14 and v1.14.1 (Microsoft Point of Service for .NET)

Microsoft Point of Service for .NET (POS for .NET) v1.14.1 has been updated to reflect that latest Unified Point of Service (UnifiedPOS) v1.14.1 international standard. In addition, POS for .NET v1.14 (and later) has been updated to work with .NET 4.0. POS for .NET v1.14.1 inherits all changes from v1.14.

## Support for OLE for Retail POS (OPOS)

POS for .NET v1.14 (and later) provides support for the following additional OPOS service objects:

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th>POS peripheral</th>
<th>Enumeration value</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>Fiscal printer</p></td>
<td><p>FISCALPRINTER</p></td>
</tr>
<tr class="even">
<td><p>Smart card reader/writer</p></td>
<td><p>SMARTCARDRW</p></td>
</tr>
<tr class="odd">
<td><p>Bump bar</p></td>
<td><p>BUMPBAR</p></td>
</tr>
<tr class="even">
<td><p>Point card reader/writer</p></td>
<td><p>POINTCARDRW</p></td>
</tr>
<tr class="odd">
<td><p>Remote order display</p></td>
<td><p>REMOTEORDERDISPLAY</p></td>
</tr>
<tr class="even">
<td><p>Cash changer</p></td>
<td><p>CASHCHANGER</p></td>
</tr>
<tr class="odd">
<td><p>Hard totals</p></td>
<td><p>HARDTOTALS</p></td>
</tr>
<tr class="even">
<td><p>Motion sensor</p></td>
<td><p>MOTIONSENSOR</p></td>
</tr>
</tbody>
</table>

## Changes in the POS for .NET 1.14.1 Release

 POS for .NET 1.14.1 adds new methods and properties to the ElectronicValue Reader/Writer class, as well as updating some old members.

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th><strong>Updated Class</strong></th>
<th><strong>Added/Updated Members</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><a href="cc297622(v=winembedded.11).md">ElectronicValueRW</a></p></td>
<td><p>Methods:</p>
<ul>
<li><a href="mt800781(v=winembedded.4).md">AccessData (new)</a><br />
</li>
<li><a href="cc297397(v=winembedded.11).md">AccessLog (updated)</a><br />
</li>
<li><a href="mt783012(v=winembedded.4).md">ActivateEVService (new)</a><br />
</li>
<li><a href="mt783014(v=winembedded.4).md">CheckServiceRegistrationToMedium (new)</a><br />
</li>
<li><a href="mt783015(v=winembedded.4).md">CloseDailyEVService (new)</a><br />
</li>
<li><a href="mt783016(v=winembedded.4).md">DeactivateEVService (new)</a><br />
</li>
<li><a href="ms842177(v=winembedded.11).md">LockTerminal (updated)</a><br />
</li>
<li><a href="mt783017(v=winembedded.4).md">OpenDailyEVService (new)</a><br />
</li>
<li><a href="mt783018(v=winembedded.4).md">RegisterServiceToMedium (new)</a><br />
</li>
<li><a href="cc297450(v=winembedded.11).md">UnlockTerminal (updated)</a><br />
</li>
<li><a href="mt783023(v=winembedded.4).md">UnregisterServiceToMedium (new)</a><br />
</li>
<li><a href="mt783024(v=winembedded.4).md">UpdateData (new)</a><br />
</li>
<li><a href="cc297823(v=winembedded.11).md">UpdateKey (updated)</a><br />
</li>
</ul>
<p>Properties:</p>
<ul>
<li><a href="mt783013(v=winembedded.4).md">CapMembershipCertificate (new)</a><br />
</li>
<li><a href="cc297375(v=winembedded.11).md">CardServiceList (updated)</a><br />
</li>
<li><a href="cc297418(v=winembedded.11).md">CurrentService (updated)</a><br />
</li>
<li><a href="cc297441(v=winembedded.11).md">ReaderWriterServiceList (updated)</a><br />
</li>
<li><a href="mt783020(v=winembedded.4).md">ServiceType (new)</a><br />
</li>
</ul>
<p>Enumerations:</p>
<ul>
<li><a href="mt783011(v=winembedded.4).md">AccessDataType (new)</a><br />
</li>
<li><a href="mt783019(v=winembedded.4).md">ServiceType (new)</a><br />
</li>
</ul>
<p>Transition events:</p>
<ul>
<li><a href="mt783022(v=winembedded.4).md">TransitionNotifyProgress1To100 (new)</a><br />
</li>
<li><a href="mt783021(v=winembedded.4).md">TransitionConfirmDeviceData (new)</a><br />
</li>
</ul></td>
</tr>
</tbody>
</table>

## Changes in the POS for .NET 1.14 Release

 POS for .NET 1.14 updates the following device classes with new and updated members.

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th><strong>Updated Class</strong></th>
<th><strong>Added Members</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><a href="bb411893(v=winembedded.11).md">Biometrics</a></p></td>
<td><p>Added the following events:</p>
<ul>
<li><a href="dn638804(v=winembedded.4).md">StatusSensorFailedRead</a><br />
</li>
<li><a href="bb412009(v=winembedded.11).md">StatusSensorReady</a><br />
</li>
<li><a href="bb404512(v=winembedded.11).md">StatusSensorComplete</a><br />
</li>
</ul></td>
</tr>
<tr class="even">
<td><p><a href="cc297622(v=winembedded.11).md">ElectronicValueRW</a></p></td>
<td><p>Added the following methods:</p>
<ul>
<li><a href="dn638770(v=winembedded.4).md">ClearParameterInformation</a><br />
</li>
<li><a href="dn628421(v=winembedded.4).md">QueryLastSuccessfulTransactionResult</a><br />
</li>
<li><a href="dn628388(v=winembedded.4).md">RetrieveResultInformation</a><br />
</li>
<li><a href="dn638299(v=winembedded.4).md">SetParameterInformation</a><br />
</li>
</ul>
<p>Added the following properties:</p>
<ul>
<li><a href="dn628500(v=winembedded.4).md">CapPINDevice</a><br />
</li>
<li><a href="dn611955(v=winembedded.4).md">CapTrainingMode</a><br />
</li>
<li><a href="dn611900(v=winembedded.4).md">PINEntry</a><br />
</li>
<li><a href="dn638687(v=winembedded.4).md">TrainingModeState</a><br />
</li>
</ul>
<p>Added the following enumerations:</p>
<ul>
<li><a href="dn638789(v=winembedded.4).md">PinEntryType</a><br />
</li>
<li><a href="dn628480(v=winembedded.4).md">TrainingModeState</a><br />
</li>
</ul>
<p>Added the following transition events:</p>
<ul>
<li><a href="dn628577(v=winembedded.4).md">TransitionTouchRetry</a><br />
</li>
<li><a href="dn628457(v=winembedded.4).md">TransitionTouchRetryCancelable</a><br />
</li>
<li><a href="dn638388(v=winembedded.4).md">TransitionConfirmTouchRetry</a><br />
</li>
<li><a href="dn611928(v=winembedded.4).md">TransitionConfirmCancel</a><br />
</li>
<li><a href="dn628525(v=winembedded.4).md">TransitionNotifyInvalidOperation</a><br />
</li>
<li><a href="dn611922(v=winembedded.4).md">TransitionConfirmInvalidOperation</a><br />
</li>
<li><a href="dn638458(v=winembedded.4).md">TransitionConfirmRemainderSubtraction</a><br />
</li>
<li><a href="dn638568(v=winembedded.4).md">TransitionConfirmCenterCheck</a><br />
</li>
<li><a href="dn628518(v=winembedded.4).md">TransitionConfirmTouchTimeout</a><br />
</li>
<li><a href="dn638372(v=winembedded.4).md">TransitionConfirmAutoCharge</a><br />
</li>
<li><a href="dn612057(v=winembedded.4).md">TransitionNotifyCaptureCard</a><br />
</li>
<li><a href="dn611929(v=winembedded.4).md">TransitionNotifyPin</a><br />
</li>
<li><a href="dn638815(v=winembedded.4).md">TransitionCenterCheck</a><br />
</li>
<li><a href="dn612036(v=winembedded.4).md">TransitionNotifyComplete</a><br />
</li>
<li><a href="dn611963(v=winembedded.4).md">TransitionNotifyTouch</a><br />
</li>
<li><a href="dn628439(v=winembedded.4).md">TransitionNotifyBusy</a><br />
</li>
<li><a href="dn638400(v=winembedded.4).md">TransitionConfirmCenterCheckComplete</a><br />
</li>
<li><a href="dn638673(v=winembedded.4).md">TransitionConfirmSelect</a><br />
</li>
<li><a href="dn638824(v=winembedded.4).md">TransitionNotifyLock</a><br />
</li>
<li><a href="dn628413(v=winembedded.4).md">TransitionNotifyCenterCheckComplete</a><br />
</li>
<li><a href="dn611940(v=winembedded.4).md">TransitionConfirmPinEntryByOuterPinpad</a><br />
</li>
</ul></td>
</tr>
<tr class="odd">
<td><p><a href="ms884551(v=winembedded.11).md">Micr</a> (Magnetic ink character recognition)</p></td>
<td><p>Added support for the following country codes:</p>
<ul>
<li><a href="ms883995(v=winembedded.11).md">CheckCountryCode</a>.CMC7<br />
</li>
<li><strong>CheckCountryCode</strong>.OTHER<br />
</li>
</ul></td>
</tr>
<tr class="even">
<td><p><a href="ms884868(v=winembedded.11).md">PosPrinter</a></p></td>
<td><p>Added the following methods:</p>
<ul>
<li><a href="dn611910(v=winembedded.4).md">CapRecRuledLine</a><br />
</li>
<li><a href="dn612116(v=winembedded.4).md">CapSlpRuledLine</a><br />
</li>
<li><a href="dn612009(v=winembedded.4).md">DrawRuledLine</a><br />
</li>
</ul>
<p>Added the following enumerations:</p>
<ul>
<li><a href="dn612096(v=winembedded.4).md">LineDirection</a><br />
</li>
<li><a href="dn628545(v=winembedded.4).md">LineStyle</a><br />
</li>
</ul></td>
</tr>
<tr class="odd">
<td><p><a href="aa460872(v=winembedded.11).md">Scale</a></p></td>
<td><p>Added the following methods:</p>
<ul>
<li><a href="dn638810(v=winembedded.4).md">DoPriceCalculating</a><br />
</li>
<li><a href="dn628532(v=winembedded.4).md">FreezeValue</a><br />
</li>
<li><a href="dn628434(v=winembedded.4).md">ReadLiveWeightWithTare</a><br />
</li>
<li><a href="dn628341(v=winembedded.4).md">SetPriceCalculationMode</a><br />
</li>
<li><a href="dn628580(v=winembedded.4).md">SetSpecialTare</a><br />
</li>
<li><a href="dn638522(v=winembedded.4).md">SetTarePriority</a><br />
</li>
<li><a href="dn611917(v=winembedded.4).md">SetUnitPriceWithWeightUnit</a><br />
</li>
</ul>
<p>Added the following properties:</p>
<ul>
<li><a href="dn628422(v=winembedded.4).md">CapFreezeValue</a><br />
</li>
<li><a href="dn638679(v=winembedded.4).md">CapReadLiveWeightWithTare</a><br />
</li>
<li><a href="dn628449(v=winembedded.4).md">CapSetPriceCalculationMode</a><br />
</li>
<li><a href="dn628504(v=winembedded.4).md">CapSetUnitPriceWithWeightUnit</a><br />
</li>
<li><a href="dn628546(v=winembedded.4).md">CapSpecialTare</a><br />
</li>
<li><a href="dn638376(v=winembedded.4).md">CapTarePriority</a><br />
</li>
<li><a href="dn638665(v=winembedded.4).md">MinimumWeight</a><br />
</li>
<li><a href="dn628527(v=winembedded.4).md">ZeroValid</a><br />
</li>
</ul>
<p>Added the following enumerations:</p>
<ul>
<li><a href="dn612088(v=winembedded.4).md">FreezeValueType</a><br />
</li>
<li><a href="dn638486(v=winembedded.4).md">PriceCalculationMode</a><br />
</li>
<li><a href="dn638646(v=winembedded.4).md">SpecialTare</a><br />
</li>
<li><a href="dn638657(v=winembedded.4).md">TarePriority</a><br />
</li>
</ul></td>
</tr>
<tr class="even">
<td><p><a href="aa460918(v=winembedded.11).md">ToneIndicator</a></p></td>
<td><p>Added the following properties:</p>
<ul>
<li><a href="dn638405(v=winembedded.4).md">CapMelody</a><br />
</li>
<li><a href="dn628376(v=winembedded.4).md">MelodyType</a><br />
</li>
<li><a href="dn612084(v=winembedded.4).md">MelodyVolume</a><br />
</li>
</ul>
<p>Added the following enumeration:</p>
<ul>
<li><a href="dn612020(v=winembedded.4).md">MelodyType</a><br />
</li>
</ul></td>
</tr>
<tr class="odd">
<td><p><a href="aa460340(v=winembedded.11).md">BarCodeSymbology</a></p></td>
<td><p>Added the following one dimensional symbologies:</p>
<ul>
<li><strong>BarCodeSymbology</strong>.ItfCK<br />
</li>
<li><strong>BarCodeSymbology</strong>.Gs1DataBar_Type2<br />
</li>
<li><strong>BarCodeSymbology</strong>.Ames<br />
</li>
<li><strong>BarCodeSymbology</strong>.TFMAT<br />
</li>
<li><strong>BarCodeSymbology</strong>.Code39Ck<br />
</li>
<li><strong>BarCodeSymbology</strong>.Code32<br />
</li>
<li><strong>BarCodeSymbology</strong>.CodeCIP<br />
</li>
<li><strong>BarCodeSymbology</strong>.TriOptic39<br />
</li>
<li><strong>BarCodeSymbology</strong>.ISBT128<br />
</li>
<li><strong>BarCodeSymbology</strong>.Code11<br />
</li>
<li><strong>BarCodeSymbology</strong>.MSI<br />
</li>
<li><strong>BarCodeSymbology</strong>.Plessey<br />
</li>
<li><strong>BarCodeSymbology</strong>.Telepen<br />
</li>
</ul>
<p>Added the following composite symbology:</p>
<ul>
<li><strong>BarCodeSymbology</strong>.Tlc39<br />
</li>
</ul>
<p>Added the following two dimensional symbologies:</p>
<ul>
<li><strong>BarCodeSymbology</strong>.Gs1DataMatrix<br />
</li>
<li><strong>BarCodeSymbology</strong>.Gs1QRCode<br />
</li>
<li><strong>BarCodeSymbology</strong>.Code49<br />
</li>
<li><strong>BarCodeSymbology</strong>.Code16k<br />
</li>
<li><strong>BarCodeSymbology</strong>.CodablockA<br />
</li>
<li><strong>BarCodeSymbology</strong>.CodablockF<br />
</li>
<li><strong>BarCodeSymbology</strong>.Codablock256<br />
</li>
<li><strong>BarCodeSymbology</strong>.HANXIN<br />
</li>
</ul>
<p>Added the following postal code symbologies:</p>
<ul>
<li><strong>BarCodeSymbology</strong>.AusPost<br />
</li>
<li><strong>BarCodeSymbology</strong>.CanPost<br />
</li>
<li><strong>BarCodeSymbology</strong>.ChinaPost<br />
</li>
<li><strong>BarCodeSymbology</strong>.DutchKix<br />
</li>
<li><strong>BarCodeSymbology</strong>.InfoMail<br />
</li>
<li><strong>BarCodeSymbology</strong>.JapanPost<br />
</li>
<li><strong>BarCodeSymbology</strong>.KoreanPost<br />
</li>
<li><strong>BarCodeSymbology</strong>.SwedenPost<br />
</li>
<li><strong>BarCodeSymbology</strong>.UkPost<br />
</li>
<li><strong>BarCodeSymbology</strong>.UsIntelligent<br />
</li>
<li><strong>BarCodeSymbology</strong>.UsPlanet<br />
</li>
<li><strong>BarCodeSymbology</strong>.PostNet<br />
</li>
</ul></td>
</tr>
</tbody>
</table>

## See Also

#### Concepts

[POS for .NET v1.14.1 SDK Documentation](index.md)
