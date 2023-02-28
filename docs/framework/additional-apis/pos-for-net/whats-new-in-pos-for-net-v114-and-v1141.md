---
title: What's New in POS for .NET v1.14 and v1.14.1
description: What's New in POS for .NET v1.14 and v1.14.1 (POS for .NET v1.14 SDK Documentation)
ms.date: 04/12/2017
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# What's New in POS for .NET v1.14 and v1.14.1 (Microsoft Point of Service for .NET)

Microsoft Point of Service for .NET (POS for .NET) v1.14.1 has been updated to reflect that latest Unified Point of Service (UnifiedPOS) v1.14.1 international standard. In addition, POS for .NET v1.14 (and later) has been updated to work with .NET 4.0. POS for .NET v1.14.1 inherits all changes from v1.14.

## Support for OLE for Retail POS (OPOS)

POS for .NET v1.14 (and later) provides support for the following additional OPOS service objects:

| POS peripheral           | Enumeration value  |
|--------------------------|--------------------|
| Fiscal printer           | FISCALPRINTER      |
| Smart card reader/writer | SMARTCARDRW        |
| Bump bar                 | BUMPBAR            |
| Point card reader/writer | POINTCARDRW        |
| Remote order display     | REMOTEORDERDISPLAY |
| Cash changer             | CASHCHANGER        |
| Hard totals              | HARDTOTALS         |
| Motion sensor            | MOTIONSENSOR       |

## Changes in the POS for .NET 1.14.1 Release

 POS for .NET 1.14.1 adds new methods and properties to the ElectronicValue Reader/Writer class, as well as updating some old members.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
</colgroup>
<thead>
<tr class="header">
<th><strong>Updated Class</strong></th>
<th><strong>Added/Updated Members</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>ElectronicValueRW</p></td>
<td><p>Methods:</p>
<ul>
<li>AccessData (new)<br />
</li>
<li>AccessLog (updated)<br />
</li>
<li>ActivateEVService (new)<br />
</li>
<li>CheckServiceRegistrationToMedium (new)<br />
</li>
<li>CloseDailyEVService (new)<br />
</li>
<li>DeactivateEVService (new)<br />
</li>
<li>LockTerminal (updated)<br />
</li>
<li>OpenDailyEVService (new)<br />
</li>
<li>RegisterServiceToMedium (new)<br />
</li>
<li>UnlockTerminal (updated)<br />
</li>
<li>UnregisterServiceToMedium (new)<br />
</li>
<li>UpdateData (new)<br />
</li>
<li>UpdateKey (updated)<br />
</li>
</ul>
<p>Properties:</p>
<ul>
<li>CapMembershipCertificate (new)<br />
</li>
<li>CardServiceList (updated)<br />
</li>
<li>CurrentService (updated)<br />
</li>
<li>ReaderWriterServiceList (updated)<br />
</li>
<li>ServiceType (new)<br />
</li>
</ul>
<p>Enumerations:</p>
<ul>
<li>AccessDataType (new)<br />
</li>
<li>ServiceType (new)<br />
</li>
</ul>
<p>Transition events:</p>
<ul>
<li>TransitionNotifyProgress1To100 (new)<br />
</li>
<li>TransitionConfirmDeviceData (new)<br />
</li>
</ul></td>
</tr>
</tbody>
</table>
<!-- markdownlint-enable MD033 -->

## Changes in the POS for .NET 1.14 Release

 POS for .NET 1.14 updates the following device classes with new and updated members.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
</colgroup>
<thead>
<tr class="header">
<th><strong>Updated Class</strong></th>
<th><strong>Added Members</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>Biometrics</p></td>
<td><p>Added the following events:</p>
<ul>
<li>StatusSensorFailedRead<br />
</li>
<li>StatusSensorReady<br />
</li>
<li>StatusSensorComplete<br />
</li>
</ul></td>
</tr>
<tr class="even">
<td><p>ElectronicValueRW</p></td>
<td><p>Added the following methods:</p>
<ul>
<li>ClearParameterInformation<br />
</li>
<li>QueryLastSuccessfulTransactionResult<br />
</li>
<li>RetrieveResultInformation<br />
</li>
<li>SetParameterInformation<br />
</li>
</ul>
<p>Added the following properties:</p>
<ul>
<li>CapPINDevice<br />
</li>
<li>CapTrainingMode<br />
</li>
<li>PINEntry<br />
</li>
<li>TrainingModeState<br />
</li>
</ul>
<p>Added the following enumerations:</p>
<ul>
<li>PinEntryType<br />
</li>
<li>TrainingModeState<br />
</li>
</ul>
<p>Added the following transition events:</p>
<ul>
<li>TransitionTouchRetry<br />
</li>
<li>TransitionTouchRetryCancelable<br />
</li>
<li>TransitionConfirmTouchRetry<br />
</li>
<li>TransitionConfirmCancel<br />
</li>
<li>TransitionNotifyInvalidOperation<br />
</li>
<li>TransitionConfirmInvalidOperation<br />
</li>
<li>TransitionConfirmRemainderSubtraction<br />
</li>
<li>TransitionConfirmCenterCheck<br />
</li>
<li>TransitionConfirmTouchTimeout<br />
</li>
<li>TransitionConfirmAutoCharge<br />
</li>
<li>TransitionNotifyCaptureCard<br />
</li>
<li>TransitionNotifyPin<br />
</li>
<li>TransitionCenterCheck<br />
</li>
<li>TransitionNotifyComplete<br />
</li>
<li>TransitionNotifyTouch<br />
</li>
<li>TransitionNotifyBusy<br />
</li>
<li>TransitionConfirmCenterCheckComplete<br />
</li>
<li>TransitionConfirmSelect<br />
</li>
<li>TransitionNotifyLock<br />
</li>
<li>TransitionNotifyCenterCheckComplete<br />
</li>
<li>TransitionConfirmPinEntryByOuterPinpad<br />
</li>
</ul></td>
</tr>
<tr class="odd">
<td><p>Micr (Magnetic ink character recognition)</p></td>
<td><p>Added support for the following country codes:</p>
<ul>
<li>CheckCountryCode.CMC7<br />
</li>
<li><strong>CheckCountryCode</strong>.OTHER<br />
</li>
</ul></td>
</tr>
<tr class="even">
<td><p>PosPrinter</p></td>
<td><p>Added the following methods:</p>
<ul>
<li>CapRecRuledLine<br />
</li>
<li>CapSlpRuledLine<br />
</li>
<li>DrawRuledLine<br />
</li>
</ul>
<p>Added the following enumerations:</p>
<ul>
<li>LineDirection<br />
</li>
<li>LineStyle<br />
</li>
</ul></td>
</tr>
<tr class="odd">
<td><p>Scale</p></td>
<td><p>Added the following methods:</p>
<ul>
<li>DoPriceCalculating<br />
</li>
<li>FreezeValue<br />
</li>
<li>ReadLiveWeightWithTare<br />
</li>
<li>SetPriceCalculationMode<br />
</li>
<li>SetSpecialTare<br />
</li>
<li>SetTarePriority<br />
</li>
<li>SetUnitPriceWithWeightUnit<br />
</li>
</ul>
<p>Added the following properties:</p>
<ul>
<li>CapFreezeValue<br />
</li>
<li>CapReadLiveWeightWithTare<br />
</li>
<li>CapSetPriceCalculationMode<br />
</li>
<li>CapSetUnitPriceWithWeightUnit<br />
</li>
<li>CapSpecialTare<br />
</li>
<li>CapTarePriority<br />
</li>
<li>MinimumWeight<br />
</li>
<li>ZeroValid<br />
</li>
</ul>
<p>Added the following enumerations:</p>
<ul>
<li>FreezeValueType<br />
</li>
<li>PriceCalculationMode<br />
</li>
<li>SpecialTare<br />
</li>
<li>TarePriority<br />
</li>
</ul></td>
</tr>
<tr class="even">
<td><p>ToneIndicator</p></td>
<td><p>Added the following properties:</p>
<ul>
<li>CapMelody<br />
</li>
<li>MelodyType<br />
</li>
<li>MelodyVolume<br />
</li>
</ul>
<p>Added the following enumeration:</p>
<ul>
<li>MelodyType<br />
</li>
</ul></td>
</tr>
<tr class="odd">
<td><p>BarCodeSymbology</p></td>
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
<!-- markdownlint-enable MD033 -->

## See Also

#### Concepts

- [POS for .NET v1.14.1 SDK Documentation](index.md)
