---
title: LineDisplay Capabilities
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# LineDisplay Capabilities (POS for .NET v1.14 SDK Documentation)

A **LineDisplay** Service Object supports, at a minimum, the ability to display characters on the output device. In addition, the device may also support additional features, which the Service Object exposes to the application by setting capability properties and implementing their corresponding methods and properties.

For each additional feature, there is a capability property defined in the [LineDisplayBase](aa460464\(v=winembedded.11\).md) class. The capability properties may not be queried until the application has called **Open** on the Service Object. Thereafter, the capability properties will indicate which properties and methods may be set and called on the Service Object.

This section lists the features that a **LineDisplay** Service Object may support. For each feature, there is a capability attribute that must be set by the Service Object as well a set of properties or methods which will be used by the application to access these features. In some cases, the feature is fully supported in **LineDisplayBase** and requires no additional code in the Service Object class.

The capability properties are implemented as read-only in order to prevent the application from changing their values. This means, too, that they cannot be set directly by the Service Object. Instead, **LineDisplayBase** has a protected property, **Properties**, which returns a [LineDisplayProperties](aa460573\(v=winembedded.11\).md) object. This class provides public equivalents for all capability properties. For example, in order to advertise that it supports blinking, a Service Object would write:

    Properties.CapBlink = true;

And not:

    CapBlink = true;

## Marquee-like Scrolling of the Window

The Service Object may support either horizontal or vertical marquees. If horizontal scrolling is supported, the Service Object sets **Properties.CapHMarquee** to **true**. Likewise, if vertical scrolling is supported, **Properties.CapVMarquee** is set to **true**.

Thereafter, applications and Service Objects may use the following to set or get the marquee type:

    DisplayMarqueeType MaqueeType {get, set; }

## Inter-Character Wait

A line display device may have the ability to wait for a specified period of time before displaying each character to create a teletype effect. If this feature is supported, the **Properties.CapICharWait** property is set to **true**.

Thereafter, applications and Service Objects may use the following to set or get the inter-character wait time:

    int InterCharacterWait { get; set; }

## Blinking Text

A line display device may support character-level or device-level blinking at adjustable blink rates. If this feature is supported, the Service Object should set the **Properties.CapBlink** property to one of the following **Properties.DisplayBlink** enumeration values.

<table>
<colgroup>
<col style="width: 33%" />
<col style="width: 33%" />
<col style="width: 33%" />
</colgroup>
<thead>
<tr class="header">
<th>DisplayBlink Value</th>
<th>Corresponding UnifiedPOS Value</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>None</strong></p></td>
<td><p>DISP_CR_NOBLINK</p></td>
<td><p>The device does not support blinking.</p></td>
</tr>
<tr class="even">
<td><p><strong>All</strong></p></td>
<td><p>DISP_CR_BLINKALL</p></td>
<td><p>The device supports blinking for the entire display.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Each</strong></p></td>
<td><p>DISP_CR_BLINKEACH</p></td>
<td><p>The device supports blinking for each individual character.</p></td>
</tr>
</tbody>
</table>

Thereafter, applications and Service Objects may use the following to set or get the blink rate:

    int BlinkRate {get; set; }

## Reverse Video

A line display may support character-level or device-level reverse video. If this feature is supported, the Service Object should set the **Properties.CapReverse** to a value in the [DisplayReverse](ms884175\(v=winembedded.11\).md) enumeration.

<table>
<colgroup>
<col style="width: 33%" />
<col style="width: 33%" />
<col style="width: 33%" />
</colgroup>
<thead>
<tr class="header">
<th>DisplayReverse Value</th>
<th>Corresponding UnifiedPOS Value</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>None</strong></p></td>
<td><p>DISP-CR_NONE</p></td>
<td><p>Reverse video is not supported.</p></td>
</tr>
<tr class="even">
<td><p><strong>All</strong></p></td>
<td><p>DISP_CR_REVERSEALL</p></td>
<td><p>The entire contents of the display are either displayed in reserve video or displayed normally.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Each</strong></p></td>
<td><p>DIS_CR_REVERSEEACH</p></td>
<td><p>Each character may be individually set to reverse video or normal.</p></td>
</tr>
</tbody>
</table>

The **CapReverse** property is used by the **DisplayText** method.

## Device Descriptors

Descriptors are small indicators with a fixed label, and are typically used to indicate transaction states such as item, total, and change. The Service Object should set **Properties.CapDescriptors** to **true** if descriptors are supported.

Thereafter, applications and Service Objects may use the following to set, get, or clear the Descriptors:

- `int DeviceDescriptors {get; set; }`
- `void ClearDescriptors();`
- `void SetDescriptor(int descriptor, DisplaySetDescriptor attribute);`

## Brightness Control

All **LineDisplay** Service Objects support two brightness levels, normal and blank, even if not supported by the physical device. If the device supports additional brightness levels, then **Properties.CapBrightness** should be set to **true**.

Thereafter, applications and Service Objects may use the following to set or get the device brightness:

    int DeviceBrightness {get; set; }

## Cursor Attributes

A line display device may support a variety of different cursor types. The **Properties.CapCursorType** property defines which of these types are supported. The **CapCursorType** property is set using the [DisplayCursors](ms884158\(v=winembedded.11\).md) enumeration and holds a bitwise indication of the supported cursor types, which can be any of the following types shown in the table.

<table>
<colgroup>
<col style="width: 33%" />
<col style="width: 33%" />
<col style="width: 33%" />
</colgroup>
<thead>
<tr class="header">
<th>CapCursorType enum</th>
<th>UnifiedPOS Value</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>Blink</strong></p></td>
<td><p>DISP_CCT_BLINK</p></td>
<td><p>A blinking cursor is supported.</p></td>
</tr>
<tr class="even">
<td><p><strong>Block</strong></p></td>
<td><p>DISP_CCT_BLOCK</p></td>
<td><p>Cursor is displayable as a block.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Fixed</strong></p></td>
<td><p>DISP_CCT_FIXED</p></td>
<td><p>Cursor is always displayed.</p></td>
</tr>
<tr class="even">
<td><p><strong>HalfBlock</strong></p></td>
<td><p>DISP_CCT_HALFBLOCK</p></td>
<td><p>Cursor is displayable as a half block.</p></td>
</tr>
<tr class="odd">
<td><p><strong>None</strong></p></td>
<td><p>DISP_CCT_NONE</p></td>
<td><p>Cursor is not displayable.</p></td>
</tr>
<tr class="even">
<td><p><strong>Other</strong></p></td>
<td><p>DISP_CCT_OTHER</p></td>
<td><p>Cursor is displayable, but the form is unknown.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Reverse</strong></p></td>
<td><p>DISP_CCT_REVERSE</p></td>
<td><p>Cursor is displayable in reverse video.</p></td>
</tr>
<tr class="even">
<td><p><strong>Underline</strong></p></td>
<td><p>DISP_CCT_UNDERLINE</p></td>
<td><p>Cursor is displayable as an underline.</p></td>
</tr>
</tbody>
</table>

Thereafter, applications and Service Objects may use the following to set or get the cursor type:

**DisplayCursors**`CursorType { get; set; }`

## Glyphs

Glyphs are a pixel-level user definition of character cells. If glyphs are supported by the device, then **Properties.CapCustomGlyph** should be set to **true**.

Thereafter, applications and Service Objects may use the following to set or get the glyph list and settings:

- [RangeOfCharacters](aa460859\(v=winembedded.11\).md)`[] CustomGlyphList { get; set; }`
- `int GlyphHeight { get; }`
- `int GlyphWidth { get; }`
- `void DefineGlyph(int glyphCode, byte[] glyph);`

## Screen Modes

A device may support changing the screen mode; that is, the number of rows and columns displayed. If this feature is supported by the device, the Service Object should set **Properties.CapScreenMode** to **true**.

Thereafter, the application and Service Object may use the following to set or get the screen mode:

- `int ScreenMode { get; set; }`
- [DisplayScreenMode](ms884183\(v=winembedded.11\).md)`[] ScreenModeList { get; }`

## Bitmaps

The Service Object should set the **Properties.CapBitmap** property to **true** if the device supports displaying bitmaps.

The Service Object may want to override the following methods if this capability is supported:

- `void DisplayBitmap(string fileName, int alignmentX, int alignmentY);`
- `void DisplayBitmap(string fileName, int width, int alignmentX, int alignmentY);`

## Character Sets

A Service Object should set the **Properties.CapCharacterSet** property with the default character set capability of the line display device. This property can be set to a member of the [CharacterSetCapability](ms883993\(v=winembedded.11\).md) enumeration as shown in the following table.

<table>
<colgroup>
<col style="width: 33%" />
<col style="width: 33%" />
<col style="width: 33%" />
</colgroup>
<thead>
<tr class="header">
<th>CharacterSetCapability Value</th>
<th>UnifiedPOS Value</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>Alpha</strong></p></td>
<td><p>PTR_CCS_ALPHA</p></td>
<td><p>The default character set supports uppercase alphabetic plus numeric, space, minus, and period.</p></td>
</tr>
<tr class="even">
<td><p><strong>ANSI</strong></p></td>
<td><p>N/A</p></td>
<td><p>This value is not used for <strong>LineDisplay</strong> devices.</p></td>
</tr>
<tr class="odd">
<td><p><strong>ASCII</strong></p></td>
<td><p>PTR_CCS_ASCII</p></td>
<td><p>The default character set supports 0x20 through 0x75.</p></td>
</tr>
<tr class="even">
<td><p><strong>Kana</strong></p></td>
<td><p>PTR_CCS_KANA</p></td>
<td><p>The default character set supports partial code page 932, including ASCII characters 0x20 through 0x7F and the Japanese Kana characters 0xA1 through 0xDF, but excluding the Japanese Kanji characters.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Kanji</strong></p></td>
<td><p>DISP_CCS_KANJI</p></td>
<td><p>The default character set supports code page 932 including the Shift-JIS Kanji characters, Levels 1 and 2.</p></td>
</tr>
<tr class="even">
<td><p><strong>Numeric</strong></p></td>
<td><p>N/A</p></td>
<td><p>This value is not used for <strong>LineDisplay</strong> devices.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Unicode</strong></p></td>
<td><p>DISP_CCS_UNICODE</p></td>
<td><p>The default character set supports UNICODE.</p></td>
</tr>
<tr class="even">
<td><p><strong>Windows</strong></p></td>
<td><p>N/A</p></td>
<td><p>This value is not used for <strong>LineDisplay</strong> devices.</p></td>
</tr>
</tbody>
</table>

Thereafter, applications and Service Objects may use the following to set or get the character set:

    int CharacterSet { get; set; }

## See Also

#### Tasks

[LineDisplay Sample](linedisplay-sample.md)

#### Other Resources

[LineDisplay Implementation](linedisplay-implementation.md)
