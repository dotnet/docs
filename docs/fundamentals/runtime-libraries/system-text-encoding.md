---
title: System.Text.Encoding class
description: Learn about the System.Text.Encoding class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: concept-article
---
# System.Text.Encoding class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Text.Encoding> class represents a character encoding.

Encoding is the process of transforming a set of Unicode characters into a sequence of bytes. In contrast, decoding is the process of transforming a sequence of encoded bytes into a set of Unicode characters. For information about the Unicode Transformation Formats (UTFs) and other encodings supported by <xref:System.Text.Encoding>, see [Character Encoding in .NET](../../standard/base-types/character-encoding.md).

<xref:System.Text.Encoding> is intended to operate on Unicode characters instead of arbitrary binary data, such as byte arrays. If you must encode arbitrary binary data into text, you should use a protocol such as uuencode, which is implemented by methods such as <xref:System.Convert.ToBase64CharArray%2A?displayProperty=nameWithType>.

.NET provides the following implementations of the <xref:System.Text.Encoding> class to support current Unicode encodings and other encodings:

- <xref:System.Text.ASCIIEncoding> encodes Unicode characters as single 7-bit ASCII characters. This encoding only supports character values between U+0000 and U+007F. Code page 20127. Also available through the <xref:System.Text.Encoding.ASCII> property.

- <xref:System.Text.UTF7Encoding> encodes Unicode characters using the UTF-7 encoding. This encoding supports all Unicode character values. Code page 65000. Also available through the <xref:System.Text.Encoding.UTF7> property.

- <xref:System.Text.UTF8Encoding> encodes Unicode characters using the UTF-8 encoding. This encoding supports all Unicode character values. Code page 65001. Also available through the <xref:System.Text.Encoding.UTF8> property.

- <xref:System.Text.UnicodeEncoding> encodes Unicode characters using the UTF-16 encoding. Both little endian and big endian byte orders are supported. Also available through the <xref:System.Text.Encoding.Unicode> property and the <xref:System.Text.Encoding.BigEndianUnicode> property.

- <xref:System.Text.UTF32Encoding> encodes Unicode characters using the UTF-32 encoding. Both little endian (code page 12000) and big endian (code page 12001) byte orders are supported. Also available through the <xref:System.Text.Encoding.UTF32> property.

The <xref:System.Text.Encoding> class is primarily intended to convert between different encodings and Unicode. Often one of the derived Unicode classes is the correct choice for your app.

Use the <xref:System.Text.Encoding.GetEncoding%2A> method to obtain other encodings, and call the <xref:System.Text.Encoding.GetEncodings%2A> method to get a list of all encodings.

## List of encodings

The following table lists the encodings supported by .NET. It lists each encoding's code page number and the values of the encoding's <xref:System.Text.EncodingInfo.Name%2A?displayProperty=nameWithType> and <xref:System.Text.EncodingInfo.DisplayName%2A?displayProperty=nameWithType> properties. A check mark in the **.NET Framework support**, **.NET Core support**, or **.NET 5 and later support** column indicates that the code page is natively supported by that .NET implementation, regardless of the underlying platform. For .NET Framework, the availability of other encodings listed in the table depends on the operating system. For .NET Core and .NET 5 and later versions, other encodings are available by using the <xref:System.Text.CodePagesEncodingProvider?displayProperty=nameWithType> class or by deriving from the <xref:System.Text.EncodingProvider?displayProperty=nameWithType> class.

> [!NOTE]
> Code pages whose <xref:System.Text.EncodingInfo.Name?displayProperty=nameWithType> property corresponds to an international standard do not necessarily comply in full with that standard.

|Code page|Name|Display name|.NET Framework support| .NET Core support | .NET 5 and later support |
|---------|----|------------|----------------------|-------------------|----------------------------|
|37|IBM037|IBM EBCDIC (US-Canada)||||
|437|IBM437|OEM United States||||
|500|IBM500|IBM EBCDIC (International)||||
|708|ASMO-708|Arabic (ASMO 708)||||
|720|DOS-720|Arabic (DOS)||||
|737|ibm737|Greek (DOS)||||
|775|ibm775|Baltic (DOS)||||
|850|ibm850|Western European (DOS)||||
|852|ibm852|Central European (DOS)||||
|855|IBM855|OEM Cyrillic||||
|857|ibm857|Turkish (DOS)||||
|858|IBM00858|OEM Multilingual Latin I||||
|860|IBM860|Portuguese (DOS)||||
|861|ibm861|Icelandic (DOS)||||
|862|DOS-862|Hebrew (DOS)||||
|863|IBM863|French Canadian (DOS)||||
|864|IBM864|Arabic (864)||||
|865|IBM865|Nordic (DOS)||||
|866|cp866|Cyrillic (DOS)||||
|869|ibm869|Greek, Modern (DOS)||||
|870|IBM870|IBM EBCDIC (Multilingual Latin-2)||||
|874|windows-874|Thai (Windows)||||
|875|cp875|IBM EBCDIC (Greek Modern)||||
|932|shift_jis|Japanese (Shift-JIS)||||
|936|gb2312|Chinese Simplified (GB2312)|✓|||
|949|ks_c_5601-1987|Korean||||
|950|big5|Chinese Traditional (Big5)||||
|1026|IBM1026|IBM EBCDIC (Turkish Latin-5)||||
|1047|IBM01047|IBM Latin-1||||
|1140|IBM01140|IBM EBCDIC (US-Canada-Euro)||||
|1141|IBM01141|IBM EBCDIC (Germany-Euro)||||
|1142|IBM01142|IBM EBCDIC (Denmark-Norway-Euro)||||
|1143|IBM01143|IBM EBCDIC (Finland-Sweden-Euro)||||
|1144|IBM01144|IBM EBCDIC (Italy-Euro)||||
|1145|IBM01145|IBM EBCDIC (Spain-Euro)||||
|1146|IBM01146|IBM EBCDIC (UK-Euro)||||
|1147|IBM01147|IBM EBCDIC (France-Euro)||||
|1148|IBM01148|IBM EBCDIC (International-Euro)||||
|1149|IBM01149|IBM EBCDIC (Icelandic-Euro)||||
|1200|utf-16|Unicode|✓|✓|✓|
|1201|unicodeFFFE|Unicode (Big endian)|✓|✓|✓|
|1250|windows-1250|Central European (Windows)||||
|1251|windows-1251|Cyrillic (Windows)||||
|1252|Windows-1252|Western European (Windows)|✓|||
|1253|windows-1253|Greek (Windows)||||
|1254|windows-1254|Turkish (Windows)||||
|1255|windows-1255|Hebrew (Windows)||||
|1256|windows-1256|Arabic (Windows)||||
|1257|windows-1257|Baltic (Windows)||||
|1258|windows-1258|Vietnamese (Windows)||||
|1361|Johab|Korean (Johab)||||
|10000|macintosh|Western European (Mac)||||
|10001|x-mac-japanese|Japanese (Mac)||||
|10002|x-mac-chinesetrad|Chinese Traditional (Mac)||||
|10003|x-mac-korean|Korean (Mac)|✓|||
|10004|x-mac-arabic|Arabic (Mac)||||
|10005|x-mac-hebrew|Hebrew (Mac)||||
|10006|x-mac-greek|Greek (Mac)||||
|10007|x-mac-cyrillic|Cyrillic (Mac)||||
|10008|x-mac-chinesesimp|Chinese Simplified (Mac)|✓|||
|10010|x-mac-romanian|Romanian (Mac)||||
|10017|x-mac-ukrainian|Ukrainian (Mac)||||
|10021|x-mac-thai|Thai (Mac)||||
|10029|x-mac-ce|Central European (Mac)||||
|10079|x-mac-icelandic|Icelandic (Mac)||||
|10081|x-mac-turkish|Turkish (Mac)||||
|10082|x-mac-croatian|Croatian (Mac)||||
|12000|utf-32|Unicode (UTF-32)|✓|✓|✓|
|12001|utf-32BE|Unicode (UTF-32 Big endian)|✓|✓|✓|
|20000|x-Chinese-CNS|Chinese Traditional (CNS)||||
|20001|x-cp20001|TCA Taiwan||||
|20002|x-Chinese-Eten|Chinese Traditional (Eten)||||
|20003|x-cp20003|IBM5550 Taiwan||||
|20004|x-cp20004|TeleText Taiwan||||
|20005|x-cp20005|Wang Taiwan||||
|20105|x-IA5|Western European (IA5)||||
|20106|x-IA5-German|German (IA5)||||
|20107|x-IA5-Swedish|Swedish (IA5)||||
|20108|x-IA5-Norwegian|Norwegian (IA5)||||
|20127|us-ascii|US-ASCII|✓|✓|✓|
|20261|x-cp20261|T.61||||
|20269|x-cp20269|ISO-6937||||
|20273|IBM273|IBM EBCDIC (Germany)||||
|20277|IBM277|IBM EBCDIC (Denmark-Norway)||||
|20278|IBM278|IBM EBCDIC (Finland-Sweden)||||
|20280|IBM280|IBM EBCDIC (Italy)||||
|20284|IBM284|IBM EBCDIC (Spain)||||
|20285|IBM285|IBM EBCDIC (UK)||||
|20290|IBM290|IBM EBCDIC (Japanese katakana)||||
|20297|IBM297|IBM EBCDIC (France)||||
|20420|IBM420|IBM EBCDIC (Arabic)||||
|20423|IBM423|IBM EBCDIC (Greek)||||
|20424|IBM424|IBM EBCDIC (Hebrew)||||
|20833|x-EBCDIC-KoreanExtended|IBM EBCDIC (Korean Extended)||||
|20838|IBM-Thai|IBM EBCDIC (Thai)||||
|20866|koi8-r|Cyrillic (KOI8-R)||||
|20871|IBM871|IBM EBCDIC (Icelandic)||||
|20880|IBM880|IBM EBCDIC (Cyrillic Russian)||||
|20905|IBM905|IBM EBCDIC (Turkish)||||
|20924|IBM00924|IBM Latin-1||||
|20932|EUC-JP|Japanese (JIS 0208-1990 and 0212-1990)||||
|20936|x-cp20936|Chinese Simplified (GB2312-80)|✓|||
|20949|x-cp20949|Korean Wansung|✓|||
|21025|cp1025|IBM EBCDIC (Cyrillic Serbian-Bulgarian)||||
|21866|koi8-u|Cyrillic (KOI8-U)||||
|28591|iso-8859-1|Western European (ISO)|✓|✓|✓|
|28592|iso-8859-2|Central European (ISO)||||
|28593|iso-8859-3|Latin 3 (ISO)||||
|28594|iso-8859-4|Baltic (ISO)||||
|28595|iso-8859-5|Cyrillic (ISO)||||
|28596|iso-8859-6|Arabic (ISO)||||
|28597|iso-8859-7|Greek (ISO)||||
|28598|iso-8859-8|Hebrew (ISO-Visual)|✓|||
|28599|iso-8859-9|Turkish (ISO)||||
|28603|iso-8859-13|Estonian (ISO)||||
|28605|iso-8859-15|Latin 9 (ISO)||||
|29001|x-Europa|Europa||||
|38598|iso-8859-8-i|Hebrew (ISO-Logical)|✓|||
|50220|iso-2022-jp|Japanese (JIS)|✓|||
|50221|csISO2022JP|Japanese (JIS-Allow 1 byte Kana)|✓|||
|50222|iso-2022-jp|Japanese (JIS-Allow 1 byte Kana - SO/SI)|✓|||
|50225|iso-2022-kr|Korean (ISO)|✓|||
|50227|x-cp50227|Chinese Simplified (ISO-2022)|✓|||
|51932|euc-jp|Japanese (EUC)|✓|||
|51936|EUC-CN|Chinese Simplified (EUC)|✓|||
|51949|euc-kr|Korean (EUC)|✓|||
|52936|hz-gb-2312|Chinese Simplified (HZ)|✓|||
|54936|GB18030|Chinese Simplified (GB18030)|✓|||
|57002|x-iscii-de|ISCII Devanagari|✓|||
|57003|x-iscii-be|ISCII Bengali|✓|||
|57004|x-iscii-ta|ISCII Tamil|✓|||
|57005|x-iscii-te|ISCII Telugu|✓|||
|57006|x-iscii-as|ISCII Assamese|✓|||
|57007|x-iscii-or|ISCII Oriya|✓|||
|57008|x-iscii-ka|ISCII Kannada|✓|||
|57009|x-iscii-ma|ISCII Malayalam|✓|||
|57010|x-iscii-gu|ISCII Gujarati|✓|||
|57011|x-iscii-pa|ISCII Punjabi|✓|||
|65000|utf-7|Unicode (UTF-7)|✓|✓||
|65001|utf-8|Unicode (UTF-8)|✓|✓|✓|

The following example calls the <xref:System.Text.Encoding.GetEncoding%28System.Int32%29> and <xref:System.Text.Encoding.GetEncoding%28System.String%29> methods to get the Greek (Windows) code page encoding. It compares the <xref:System.Text.Encoding> objects returned by the method calls to show that they are equal, and then maps displays the Unicode code point and the corresponding code page value for each character in the Greek alphabet.

:::code language="csharp" source="./snippets/System.Text/Encoding/Overview/csharp/getencoding1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Text/Encoding/Overview/vb/getencoding1.vb" id="Snippet1":::

If the data to be converted is available only in sequential blocks (such as data read from a stream) or if the amount of data is so large that it needs to be divided into smaller blocks, you should use the <xref:System.Text.Decoder> or the <xref:System.Text.Encoder> provided by the <xref:System.Text.Encoding.GetDecoder%2A> method or the <xref:System.Text.Encoding.GetEncoder%2A> method, respectively, of a derived class.

The UTF-16 and the UTF-32 encoders can use the big endian byte order (most significant byte first) or the little endian byte order (least significant byte first). For example, the Latin Capital Letter A (U+0041) is serialized as follows (in hexadecimal):

- UTF-16 big endian byte order: 00 41
- UTF-16 little endian byte order: 41 00
- UTF-32 big endian byte order: 00 00 00 41
- UTF-32 little endian byte order: 41 00 00 00

It is generally more efficient to store Unicode characters using the native byte order. For example, it is better to use the little endian byte order on little endian platforms, such as Intel computers.

The <xref:System.Text.Encoding.GetPreamble%2A> method retrieves an array of bytes that includes the byte order mark (BOM). If this byte array is prefixed to an encoded stream, it helps the decoder to identify the encoding format used.

For more information on byte order and the byte order mark, see The Unicode Standard at the [Unicode home page](https://home.unicode.org/).

Note that the encoding classes allow errors to:

- Silently change to a "?" character.
- Use a "best fit" character.
- Change to an application-specific behavior through use of the <xref:System.Text.EncoderFallback> and <xref:System.Text.DecoderFallback> classes with the U+FFFD Unicode replacement character.

You should throw an exception on any data stream error. An app either uses a "throwonerror" flag when applicable or uses the <xref:System.Text.EncoderExceptionFallback> and <xref:System.Text.DecoderExceptionFallback> classes. Best fit fallback is often not recommended because it can cause data loss or confusion and is slower than simple character replacements. For ANSI encodings, the best fit behavior is the default.
