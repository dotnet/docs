---
title: "Character Encoding in .NET"
ms.custom: ""
ms.date: "12/22/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "encoding, understanding"
  - "encoding, choosing"
  - "encoding, fallback strategy"
ms.assetid: bf6d9823-4c2d-48af-b280-919c5af66ae9
caps.latest.revision: 33
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Character Encoding in .NET
Characters are abstract entities that can be represented in many different ways. A character encoding is a system that pairs each character in a supported character set with some value that represents that character. For example, Morse code is a character encoding that pairs each character in the Roman alphabet with a pattern of dots and dashes that are suitable for transmission over telegraph lines. A character encoding for computers pairs each character in a supported character set with a numeric value that represents that character. A character encoding has two distinct components:  
  
-   An encoder, which translates a sequence of characters into a sequence of numeric values (bytes).  
  
-   A decoder, which translates a sequence of bytes into a sequence of characters.  
  
 Character encoding describes the rules by which an encoder and a decoder operate. For example, the <xref:System.Text.UTF8Encoding> class describes the rules for encoding to, and decoding from, 8-bit Unicode Transformation Format (UTF-8), which uses one to four bytes to represent a single Unicode character. Encoding and decoding can also include validation. For example, the <xref:System.Text.UnicodeEncoding> class checks all surrogates  to make sure they constitute valid surrogate pairs. (A surrogate pair consists of a character with a code point that ranges from U+D800 to U+DBFF followed by a character with a code point that ranges from U+DC00 to U+DFFF.)  A fallback strategy determines how an encoder handles invalid characters or how a decoder handles invalid bytes.  
  
> [!WARNING]
>  .NET encoding classes provide a way to store and convert character data. They should not be used to store binary data in string form. Depending on the encoding used, converting binary data to string format with the encoding classes can introduce unexpected behavior and produce inaccurate or corrupted data. To convert binary data to a string form, use the <xref:System.Convert.ToBase64String%2A?displayProperty=nameWithType> method.  
  
 .NET uses the UTF-16 encoding (represented by the <xref:System.Text.UnicodeEncoding> class) to represent characters and strings. Applications that target the common language runtime use encoders to map Unicode character representations supported by the common language runtime to other encoding schemes. They use decoders to map characters from non-Unicode encodings to Unicode.  
  
 This topic consists of the following sections:  
  
-   [Encodings in .NET](../../../docs/standard/base-types/character-encoding.md#Encodings)  
  
-   [Selecting an Encoding Class](../../../docs/standard/base-types/character-encoding.md#Selecting)  
  
-   [Using an Encoding Object](../../../docs/standard/base-types/character-encoding.md#Using)  
  
-   [Choosing a Fallback Strategy](../../../docs/standard/base-types/character-encoding.md#FallbackStrategy)  
  
-   [Implementing a Custom Fallback Strategy](../../../docs/standard/base-types/character-encoding.md#Custom)  
  
<a name="Encodings"></a>   
## Encodings in .NET  
 All character encoding classes in .NET inherit from the <xref:System.Text.Encoding?displayProperty=nameWithType> class, which is an abstract class that defines the functionality common to all character encodings. To access the individual encoding objects implemented in .NET, do the following:  
  
-   Use the static properties of the <xref:System.Text.Encoding> class, which return objects that represent the standard character encodings available in .NET (ASCII, UTF-7, UTF-8, UTF-16, and UTF-32). For example, the <xref:System.Text.Encoding.Unicode%2A?displayProperty=nameWithType> property returns a <xref:System.Text.UnicodeEncoding> object. Each object uses replacement fallback to handle strings that it cannot encode and bytes that it cannot decode. (For more information, see the [Replacement Fallback](../../../docs/standard/base-types/character-encoding.md#Replacement) section.)  
  
-   Call the encoding's class constructor. Objects for the ASCII, UTF-7, UTF-8, UTF-16, and UTF-32 encodings can be instantiated in this way. By default, each object uses replacement fallback to handle strings that it cannot encode and bytes that it cannot decode, but you can specify that an exception should be thrown instead. (For more information, see the [Replacement Fallback](../../../docs/standard/base-types/character-encoding.md#Replacement) and [Exception Fallback](../../../docs/standard/base-types/character-encoding.md#Exception) sections.)  
  
-   Call the <xref:System.Text.Encoding.%23ctor%28System.Int32%29?displayProperty=nameWithType> constructor and pass it an integer that represents the encoding. Standard encoding objects use replacement fallback, and code page and double-byte character set (DBCS) encoding objects use best-fit fallback to handle strings that they cannot encode and bytes that they cannot decode. (For more information, see the [Best-Fit Fallback](../../../docs/standard/base-types/character-encoding.md#BestFit) section.)  
  
-   Call the <xref:System.Text.Encoding.GetEncoding%2A?displayProperty=nameWithType> method, which returns any standard, code page, or DBCS encoding available in .NET. Overloads let you specify a fallback object for both the encoder and the decoder.  
  
> [!NOTE]
>  The Unicode Standard assigns a code point (a number) and a name to each character in every supported script. For example, the character "A" is represented by the code point U+0041 and the name "LATIN CAPITAL LETTER A". The Unicode Transformation Format (UTF) encodings define ways to encode that code point into a sequence of one or more bytes. A Unicode encoding scheme simplifies world-ready application development because it allows characters from any character set to be represented in a single encoding. Application developers no longer have to keep track of the encoding scheme that was used to produce characters for a specific language or writing system, and data can be shared among systems internationally without being corrupted.  
>   
>  .NET supports three encodings defined by the Unicode standard: UTF-8, UTF-16, and UTF-32. For more information, see The Unicode Standard at the [Unicode home page](https://www.unicode.org/).  
  
 You can retrieve information about all the encodings available in .NET by calling the <xref:System.Text.Encoding.GetEncodings%2A?displayProperty=nameWithType> method. .NET supports the character encoding systems listed in the following table.  
  
|Encoding|Class|Description|Advantages/disadvantages|  
|--------------|-----------|-----------------|-------------------------------|  
|ASCII|<xref:System.Text.ASCIIEncoding>|Encodes a limited range of characters by using the lower seven bits of a byte.|Because this encoding only supports character values from U+0000 through U+007F, in most cases it is inadequate for internationalized applications.|  
|UTF-7|<xref:System.Text.UTF7Encoding>|Represents characters as sequences of 7-bit ASCII characters. Non-ASCII Unicode characters are represented by an escape sequence of ASCII characters.|UTF-7 supports protocols such as email and newsgroup protocols. However, UTF-7 is not particularly secure or robust. In some cases, changing one bit can radically alter the interpretation of an entire UTF-7 string. In other cases, different UTF-7 strings can encode the same text. For sequences that include non-ASCII characters, UTF-7 requires more space than UTF-8, and encoding/decoding is slower. Consequently, you should use UTF-8 instead of UTF-7 if possible.|  
|UTF-8|<xref:System.Text.UTF8Encoding>|Represents each Unicode code point as a sequence of one to four bytes.|UTF-8 supports 8-bit data sizes and works well with many existing operating systems. For the ASCII range of characters, UTF-8 is identical to ASCII encoding and allows a broader set of characters. However, for Chinese-Japanese-Korean (CJK) scripts, UTF-8 can require three bytes for each character, and can potentially cause larger data sizes than UTF-16. Note that sometimes the amount of ASCII data, such as HTML tags, justifies the increased size for the CJK range.|  
|UTF-16|<xref:System.Text.UnicodeEncoding>|Represents each Unicode code point as a sequence of one or two 16-bit integers. Most common Unicode characters require only one UTF-16 code point, although Unicode supplementary characters (U+10000 and greater) require two UTF-16 surrogate code points. Both little-endian and big-endian byte orders are supported.|UTF-16 encoding is used by the common language runtime to represent <xref:System.Char> and <xref:System.String> values, and it is used by the Windows operating system to represent `WCHAR` values.|  
|UTF-32|<xref:System.Text.UTF32Encoding>|Represents each Unicode code point as a 32-bit integer. Both little-endian and big-endian byte orders are supported.|UTF-32 encoding is used when applications want to avoid the surrogate code point behavior of UTF-16 encoding on operating systems for which encoded space is too important. Single glyphs rendered on a display can still be encoded with more than one UTF-32 character.|  
|ANSI/ISO encodings||Provides support for a variety of code pages. On Windows operating systems, code pages are used to support a specific language or group of languages. For a table that lists the code pages supported by .NET, see the <xref:System.Text.Encoding> class. You can retrieve an encoding object for a particular code page by calling the <xref:System.Text.Encoding.GetEncoding%28System.Int32%29?displayProperty=nameWithType> method.|A code page contains 256 code points and is zero-based. In most code pages, code points 0 through 127 represent the ASCII character set, and code points 128 through 255 differ significantly between code pages. For example, code page 1252 provides the characters for Latin writing systems, including English, German, and French. The last 128 code points in code page 1252 contain the accent characters. Code page 1253 provides character codes that are required in the Greek writing system. The last 128 code points in code page 1253 contain the Greek characters. As a result, an application that relies on ANSI code pages cannot store Greek and German in the same text stream unless it includes an identifier that indicates the referenced code page.|  
|Double-byte character set (DBCS) encodings||Supports languages, such as Chinese, Japanese, and Korean, that contain more than 256 characters. In a DBCS, a pair of code points (a double byte) represents each character. The <xref:System.Text.Encoding.IsSingleByte%2A?displayProperty=nameWithType> property returns `false` for DBCS encodings. You can retrieve an encoding object for a particular DBCS by calling the <xref:System.Text.Encoding.GetEncoding%28System.Int32%29?displayProperty=nameWithType> method.|In a DBCS, a pair of code points (a double byte) represents each character. When an application handles DBCS data, the first byte of a DBCS character (the lead byte) is processed in combination with the trail byte that immediately follows it. Because a single pair of double-byte code points can represent different characters depending on the code page, this scheme still does not allow for the combination of two languages, such as Japanese and Chinese, in the same data stream.|  
  
 These encodings enable you to work with Unicode characters as well as with encodings that are most commonly used in legacy applications. In addition, you can create a custom encoding by defining a class that derives from <xref:System.Text.Encoding> and overriding its members.  
  
### Platform Notes: [!INCLUDE[net_core](../../../includes/net-core-md.md)]  
 By default, [!INCLUDE[net_core](../../../includes/net-core-md.md)] does not make available any code page encodings other than code page 28591 and the Unicode encodings, such as UTF-8 and UTF-16. However, you can add the code page encodings found in standard Windows apps that target .NET to your app. For complete information, see the <xref:System.Text.CodePagesEncodingProvider> topic.  
  
<a name="Selecting"></a>   
## Selecting an Encoding Class  
 If you have the opportunity to choose the encoding to be used by your application, you should use a Unicode encoding, preferably either <xref:System.Text.UTF8Encoding> or <xref:System.Text.UnicodeEncoding>. (.NET also supports a third Unicode encoding, <xref:System.Text.UTF32Encoding>.)  
  
 If you are planning to use an ASCII encoding (<xref:System.Text.ASCIIEncoding>), choose <xref:System.Text.UTF8Encoding> instead. The two encodings are identical for the ASCII character set, but <xref:System.Text.UTF8Encoding> has the following advantages:  
  
-   It can represent every Unicode character, whereas <xref:System.Text.ASCIIEncoding> supports only the Unicode character values between U+0000 and U+007F.  
  
-   It provides error detection and better security.  
  
-   It has been tuned to be as fast as possible and should be faster than any other encoding. Even for content that is entirely ASCII, operations performed with <xref:System.Text.UTF8Encoding> are faster than operations performed with <xref:System.Text.ASCIIEncoding>.  
  
 You should consider using <xref:System.Text.ASCIIEncoding> only for legacy applications. However, even for legacy applications, <xref:System.Text.UTF8Encoding> might be a better choice for the following reasons (assuming default settings):  
  
-   If your application has content that is not strictly ASCII and encodes it with <xref:System.Text.ASCIIEncoding>, each non-ASCII character encodes as a question mark (?). If the application then decodes this data, the information is lost.  
  
-   If your application has content that is not strictly ASCII and encodes it with <xref:System.Text.UTF8Encoding>, the result seems unintelligible if interpreted as ASCII. However, if the application then uses a UTF-8 decoder to decode this data, the data performs a round trip successfully.  
  
 In a web application, characters sent to the client in response to a web request should reflect the encoding used on the client. In most cases, you should set the <xref:System.Web.HttpResponse.ContentEncoding%2A?displayProperty=nameWithType> property to the value returned by the <xref:System.Web.HttpRequest.ContentEncoding%2A?displayProperty=nameWithType> property to display text in the encoding that the user expects.  
  
<a name="Using"></a>   
## Using an Encoding Object  
 An encoder converts a string of characters (most commonly, Unicode characters) to its numeric (byte) equivalent. For example, you might use an ASCII encoder to convert Unicode characters to ASCII so that they can be displayed at the console. To perform the conversion, you call the <xref:System.Text.Encoding.GetBytes%2A?displayProperty=nameWithType> method. If you want to determine how many bytes are needed to store the encoded characters before performing the encoding, you can call the <xref:System.Text.Encoding.GetByteCount%2A> method.  
  
 The following example uses a single byte array to encode strings in two separate operations. It maintains an index that indicates the starting position in the byte array for the next set of ASCII-encoded bytes. It calls the <xref:System.Text.ASCIIEncoding.GetByteCount%28System.String%29?displayProperty=nameWithType> method to ensure that the byte array is large enough to accommodate the encoded string. It then calls the <xref:System.Text.ASCIIEncoding.GetBytes%28System.String%2CSystem.Int32%2CSystem.Int32%2CSystem.Byte%5B%5D%2CSystem.Int32%29?displayProperty=nameWithType> method to encode the characters in the string.  
  
 [!code-csharp[Conceptual.Encoding#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/getbytes1.cs#8)]
 [!code-vb[Conceptual.Encoding#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/getbytes1.vb#8)]  
  
 A decoder converts a byte array that reflects a particular character encoding into a set of characters, either in a character array or in a string. To decode a byte array into a character array, you call the <xref:System.Text.Encoding.GetChars%2A?displayProperty=nameWithType> method. To decode a byte array into a string, you call the <xref:System.Text.Encoding.GetString%2A> method. If you want to determine how many characters are needed to store the decoded bytes before performing the decoding, you can call the <xref:System.Text.Encoding.GetCharCount%2A> method.  
  
 The following example encodes three strings and then decodes them into a single array of characters. It maintains an index that indicates the starting position in the character array for the next set of decoded characters. It calls the <xref:System.Text.ASCIIEncoding.GetCharCount%2A> method to ensure that the character array is large enough to accommodate all the decoded characters. It then calls the <xref:System.Text.ASCIIEncoding.GetChars%28System.Byte%5B%5D%2CSystem.Int32%2CSystem.Int32%2CSystem.Char%5B%5D%2CSystem.Int32%29?displayProperty=nameWithType> method to decode the byte array.  
  
 [!code-csharp[Conceptual.Encoding#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/getchars1.cs#9)]
 [!code-vb[Conceptual.Encoding#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/getchars1.vb#9)]  
  
 The encoding and decoding methods of a class derived from <xref:System.Text.Encoding> are designed to work on a complete set of data; that is, all the data to be encoded or decoded is supplied in a single method call. However, in some cases, data is available in a stream, and the data to be encoded or decoded may be available only from separate read operations. This requires the encoding or decoding operation to remember any saved state from its previous invocation. Methods of classes derived from <xref:System.Text.Encoder> and <xref:System.Text.Decoder> are able to handle encoding and decoding operations that span multiple method calls.  
  
 An <xref:System.Text.Encoder> object for a particular encoding is available from that encoding's <xref:System.Text.Encoding.GetEncoder%2A?displayProperty=nameWithType> property. A <xref:System.Text.Decoder> object for a particular encoding is available from that encoding's <xref:System.Text.Encoding.GetDecoder%2A?displayProperty=nameWithType> property. For decoding operations, note that classes derived from <xref:System.Text.Decoder> include a <xref:System.Text.Decoder.GetChars%2A?displayProperty=nameWithType> method, but they do not have a method that corresponds to <xref:System.Text.Encoding.GetString%2A?displayProperty=nameWithType>.  
  
 The following example illustrates the difference between using the <xref:System.Text.Encoding.GetChars%2A?displayProperty=nameWithType> and <xref:System.Text.Decoder.GetChars%2A?displayProperty=nameWithType> methods for decoding a Unicode byte array. The example encodes a string that contains some Unicode characters to a file, and then uses the two decoding methods to decode them ten bytes at a time. Because a surrogate pair occurs in the tenth and eleventh bytes, it is decoded in separate method calls. As the output shows, the <xref:System.Text.Encoding.GetChars%2A?displayProperty=nameWithType> method is not able to correctly decode the bytes and instead replaces them with U+FFFD (REPLACEMENT CHARACTER). On the other hand, the <xref:System.Text.Decoder.GetChars%2A?displayProperty=nameWithType> method is able to successfully decode the byte array to get the original string.  
  
 [!code-csharp[Conceptual.Encoding#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/stream1.cs#10)]
 [!code-vb[Conceptual.Encoding#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/stream1.vb#10)]  
  
<a name="FallbackStrategy"></a>   
## Choosing a Fallback Strategy  
 When a method tries to encode or decode a character but no mapping exists, it must implement a fallback strategy that determines how the failed mapping should be handled. There are three types of fallback strategies:  
  
-   Best-fit fallback  
  
-   Replacement fallback  
  
-   Exception fallback  
  
> [!IMPORTANT]
>  The most common problems in encoding operations occur when a Unicode character cannot be mapped to a particular code page encoding. The most common problems in decoding operations occur when invalid byte sequences cannot be translated into valid Unicode characters. For these reasons, you should know which fallback strategy a particular encoding object uses. Whenever possible, you should specify the fallback strategy used by an encoding object when you instantiate the object.  
  
<a name="BestFit"></a>   
### Best-Fit Fallback  
 When a character does not have an exact match in the target encoding, the encoder can try to map it to a similar character. (Best-fit fallback is mostly an encoding rather than a decoding issue. There are very few code pages that contain characters that cannot be successfully mapped to Unicode.) Best-fit fallback is the default for code page and double-byte character set encodings that are retrieved by the <xref:System.Text.Encoding.GetEncoding%28System.Int32%29?displayProperty=nameWithType> and <xref:System.Text.Encoding.GetEncoding%28System.String%29?displayProperty=nameWithType> overloads.  
  
> [!NOTE]
>  In theory, the Unicode encoding classes provided in .NET (<xref:System.Text.UTF8Encoding>, <xref:System.Text.UnicodeEncoding>, and <xref:System.Text.UTF32Encoding>) support every character in every character set, so they can be used to eliminate best-fit fallback issues.  
  
 Best-fit strategies vary for different code pages. For example, for some code pages, full-width Latin characters map to the more common half-width Latin characters. For other code pages, this mapping is not made. Even under an aggressive best-fit strategy, there is no imaginable fit for some characters in some encodings. For example, a Chinese ideograph has no reasonable mapping to code page 1252. In this case, a replacement string is used. By default, this string is just a single QUESTION MARK (U+003F).  
  
> [!NOTE]
>  Best-fit strategies are not documented in detail. However, several code pages are documented at the [Unicode Consortium's](https://www.unicode.org/Public/MAPPINGS/VENDORS/MICSFT/WindowsBestFit/) website. Please review the **readme.txt** file in that folder for a description of how to interpret the mapping files.
  
 The following example uses code page 1252 (the Windows code page for Western European languages) to illustrate best-fit mapping and its drawbacks. The <xref:System.Text.Encoding.GetEncoding%28System.Int32%29?displayProperty=nameWithType> method is used to retrieve an encoding object for code page 1252. By default, it uses a best-fit mapping for Unicode characters that it does not support. The example instantiates a string that contains three non-ASCII characters - CIRCLED LATIN CAPITAL LETTER S (U+24C8), SUPERSCRIPT FIVE (U+2075), and INFINITY (U+221E) - separated by spaces. As the output from the example shows, when the string is encoded, the three original non-space characters are replaced by QUESTION MARK (U+003F), DIGIT FIVE (U+0035), and DIGIT EIGHT (U+0038). DIGIT EIGHT is a particularly poor replacement for the unsupported INFINITY character, and QUESTION MARK indicates that no mapping was available for the original character.  
  
 [!code-csharp[Conceptual.Encoding#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/bestfit1.cs#1)]
 [!code-vb[Conceptual.Encoding#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/bestfit1.vb#1)]  
  
 Best-fit mapping is the default behavior for an <xref:System.Text.Encoding> object that encodes Unicode data into code page data, and there are legacy applications that rely on this behavior. However, most new applications should avoid best-fit behavior for security reasons. For example, applications should not put a domain name through a best-fit encoding.  
  
> [!NOTE]
>  You can also implement a custom best-fit fallback mapping for an encoding. For more information, see the [Implementing a Custom Fallback Strategy](../../../docs/standard/base-types/character-encoding.md#Custom) section.  
  
 If best-fit fallback is the default for an encoding object, you can choose another fallback strategy when you retrieve an <xref:System.Text.Encoding> object by calling the <xref:System.Text.Encoding.GetEncoding%28System.Int32%2CSystem.Text.EncoderFallback%2CSystem.Text.DecoderFallback%29?displayProperty=nameWithType> or <xref:System.Text.Encoding.GetEncoding%28System.String%2CSystem.Text.EncoderFallback%2CSystem.Text.DecoderFallback%29?displayProperty=nameWithType> overload. The following section includes an example that replaces each character that cannot be mapped to code page 1252 with an asterisk (*).  
  
 [!code-csharp[Conceptual.Encoding#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/bestfit1a.cs#3)]
 [!code-vb[Conceptual.Encoding#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/bestfit1a.vb#3)]  
  
<a name="Replacement"></a>   
### Replacement Fallback  
 When a character does not have an exact match in the target scheme, but there is no appropriate character that it can be mapped to, the application can specify a replacement character or string. This is the default behavior for the Unicode decoder, which replaces any two-byte sequence that it cannot decode with REPLACEMENT_CHARACTER (U+FFFD). It is also the default behavior of the <xref:System.Text.ASCIIEncoding> class, which replaces each character that it cannot encode or decode with a question mark. The following example illustrates character replacement for the Unicode string from the previous example. As the output shows, each character that cannot be decoded into an ASCII byte value is replaced by 0x3F, which is the ASCII code for a question mark.  
  
 [!code-csharp[Conceptual.Encoding#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/replacementascii.cs#2)]
 [!code-vb[Conceptual.Encoding#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/replacementascii.vb#2)]  
  
 .NET includes the <xref:System.Text.EncoderReplacementFallback> and <xref:System.Text.DecoderReplacementFallback> classes, which substitute a replacement string if a character does not map exactly in an encoding or decoding operation. By default, this replacement string is a question mark, but you can call a class constructor overload to choose a different string. Typically, the replacement string is a single character, although this is not a requirement. The following example changes the behavior of the code page 1252 encoder by instantiating an <xref:System.Text.EncoderReplacementFallback> object that uses an asterisk (*) as a replacement string.  
  
 [!code-csharp[Conceptual.Encoding#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/bestfit1a.cs#3)]
 [!code-vb[Conceptual.Encoding#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/bestfit1a.vb#3)]  
  
> [!NOTE]
>  You can also implement a replacement class for an encoding. For more information, see the [Implementing a Custom Fallback Strategy](../../../docs/standard/base-types/character-encoding.md#Custom) section.  
  
 In addition to QUESTION MARK (U+003F), the Unicode REPLACEMENT CHARACTER (U+FFFD) is commonly used as a replacement string, particularly when decoding byte sequences that cannot be successfully translated into Unicode characters. However, you are free to choose any replacement string, and it can contain multiple characters.  
  
<a name="Exception"></a>   
### Exception Fallback  
 Instead of providing a best-fit fallback or a replacement string, an encoder can throw an <xref:System.Text.EncoderFallbackException> if it is unable to encode a set of characters, and a decoder can throw a <xref:System.Text.DecoderFallbackException> if it is unable to decode a byte array. To throw an exception in encoding and decoding operations, you supply an <xref:System.Text.EncoderExceptionFallback> object and a <xref:System.Text.DecoderExceptionFallback> object, respectively, to the <xref:System.Text.Encoding.GetEncoding%28System.String%2CSystem.Text.EncoderFallback%2CSystem.Text.DecoderFallback%29?displayProperty=nameWithType> method. The following example illustrates exception fallback with the <xref:System.Text.ASCIIEncoding> class.  
  
 [!code-csharp[Conceptual.Encoding#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/exceptionascii.cs#4)]
 [!code-vb[Conceptual.Encoding#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/exceptionascii.vb#4)]  
  
> [!NOTE]
>  You can also implement a custom exception handler for an encoding operation. For more information, see the [Implementing a Custom Fallback Strategy](../../../docs/standard/base-types/character-encoding.md#Custom) section.  
  
 The <xref:System.Text.EncoderFallbackException> and <xref:System.Text.DecoderFallbackException> objects provide the following information about the condition that caused the exception:  
  
-   The <xref:System.Text.EncoderFallbackException> object includes an <xref:System.Text.EncoderFallbackException.IsUnknownSurrogate%2A> method, which indicates whether the character or characters that cannot be encoded represent an unknown surrogate pair (in which case, the method returns `true`) or an unknown single character (in which case, the method returns `false`). The characters in the surrogate pair are available from the <xref:System.Text.EncoderFallbackException.CharUnknownHigh%2A?displayProperty=nameWithType> and <xref:System.Text.EncoderFallbackException.CharUnknownLow%2A?displayProperty=nameWithType> properties. The unknown single character is available from the <xref:System.Text.EncoderFallbackException.CharUnknown%2A?displayProperty=nameWithType> property. The <xref:System.Text.EncoderFallbackException.Index%2A?displayProperty=nameWithType> property indicates the position in the string at which the first character that could not be encoded was found.  
  
-   The <xref:System.Text.DecoderFallbackException> object includes a <xref:System.Text.DecoderFallbackException.BytesUnknown%2A> property that returns an array of bytes that cannot be decoded. The <xref:System.Text.DecoderFallbackException.Index%2A?displayProperty=nameWithType> property indicates the starting position of the unknown bytes.  
  
 Although the <xref:System.Text.EncoderFallbackException> and <xref:System.Text.DecoderFallbackException> objects provide adequate diagnostic information about the exception, they do not provide access to the encoding or decoding buffer. Therefore, they do not allow invalid data to be replaced or corrected within the encoding or decoding method.  
  
<a name="Custom"></a>   
## Implementing a Custom Fallback Strategy  
 In addition to the best-fit mapping that is implemented internally by code pages, .NET includes the following classes for implementing a fallback strategy:  
  
-   Use <xref:System.Text.EncoderReplacementFallback> and <xref:System.Text.EncoderReplacementFallbackBuffer> to replace characters in encoding operations.  
  
-   Use <xref:System.Text.DecoderReplacementFallback> and <xref:System.Text.DecoderReplacementFallbackBuffer> to replace characters in decoding operations.  
  
-   Use <xref:System.Text.EncoderExceptionFallback> and <xref:System.Text.EncoderExceptionFallbackBuffer> to throw an <xref:System.Text.EncoderFallbackException> when a character cannot be encoded.  
  
-   Use <xref:System.Text.DecoderExceptionFallback> and <xref:System.Text.DecoderExceptionFallbackBuffer> to throw a <xref:System.Text.DecoderFallbackException> when a character cannot be decoded.  
  
 In addition, you can implement a custom solution that uses best-fit fallback, replacement fallback, or exception fallback, by following these steps:  
  
1.  Derive a class from <xref:System.Text.EncoderFallback> for encoding operations, and from <xref:System.Text.DecoderFallback> for decoding operations.  
  
2.  Derive a class from <xref:System.Text.EncoderFallbackBuffer> for encoding operations, and from <xref:System.Text.DecoderFallbackBuffer> for decoding operations.  
  
3.  For exception fallback, if the predefined <xref:System.Text.EncoderFallbackException> and <xref:System.Text.DecoderFallbackException> classes do not meet your needs, derive a class from an exception object such as <xref:System.Exception> or <xref:System.ArgumentException>.  
  
### Deriving from EncoderFallback or DecoderFallback  
 To implement a custom fallback solution, you must create a class that inherits from <xref:System.Text.EncoderFallback> for encoding operations, and from <xref:System.Text.DecoderFallback> for decoding operations. Instances of these classes are passed to the <xref:System.Text.Encoding.GetEncoding%28System.String%2CSystem.Text.EncoderFallback%2CSystem.Text.DecoderFallback%29?displayProperty=nameWithType> method and serve as the intermediary between the encoding class and the fallback implementation.  
  
 When you create a custom fallback solution for an encoder or decoder, you must implement the following members:  
  
-   The <xref:System.Text.EncoderFallback.MaxCharCount%2A?displayProperty=nameWithType> or <xref:System.Text.DecoderFallback.MaxCharCount%2A?displayProperty=nameWithType> property, which returns the maximum possible number of characters that the best-fit, replacement, or exception fallback can return to replace a single character. For a custom exception fallback, its value is zero.  
  
-   The <xref:System.Text.EncoderFallback.CreateFallbackBuffer%2A?displayProperty=nameWithType> or <xref:System.Text.DecoderFallback.CreateFallbackBuffer%2A?displayProperty=nameWithType> method, which returns your custom <xref:System.Text.EncoderFallbackBuffer> or <xref:System.Text.DecoderFallbackBuffer> implementation. The method is called by the encoder when it encounters the first character that it is unable to successfully encode, or by the decoder when it encounters the first byte that it is unable to successfully decode.  
  
### Deriving from EncoderFallbackBuffer or DecoderFallbackBuffer  
 To implement a custom fallback solution, you must also create a class that inherits from <xref:System.Text.EncoderFallbackBuffer> for encoding operations, and from <xref:System.Text.DecoderFallbackBuffer> for decoding operations. Instances of these classes are returned by the <xref:System.Text.EncoderFallback.CreateFallbackBuffer%2A> method  of the <xref:System.Text.EncoderFallback> and <xref:System.Text.DecoderFallback> classes. The <xref:System.Text.EncoderFallback.CreateFallbackBuffer%2A?displayProperty=nameWithType> method is called by the encoder when it encounters the first character that it is not able to encode, and the <xref:System.Text.DecoderFallback.CreateFallbackBuffer%2A?displayProperty=nameWithType> method is called by the decoder when it encounters one or more bytes that it is not able to decode. The <xref:System.Text.EncoderFallbackBuffer> and <xref:System.Text.DecoderFallbackBuffer> classes provide the fallback implementation. Each instance represents a buffer that contains the fallback characters that will replace the character that cannot be encoded or the byte sequence that cannot be decoded.  
  
 When you create a custom fallback solution for an encoder or decoder, you must implement the following members:  
  
-   The <xref:System.Text.EncoderFallbackBuffer.Fallback%2A?displayProperty=nameWithType> or <xref:System.Text.DecoderFallbackBuffer.Fallback%2A?displayProperty=nameWithType> method. <xref:System.Text.EncoderFallbackBuffer.Fallback%2A?displayProperty=nameWithType> is called by the encoder to provide the fallback buffer with information about the character that it cannot encode. Because the character to be encoded may be a surrogate pair, this method is overloaded. One overload is passed the character to be encoded and its index in the string. The second overload is passed the high and low surrogate along with its index in the string. The <xref:System.Text.DecoderFallbackBuffer.Fallback%2A?displayProperty=nameWithType> method is called by the decoder to provide the fallback buffer with information about the bytes that it cannot decode. This method is passed an array of bytes that it cannot decode, along with the index of the first byte. The fallback method should return `true` if the fallback buffer can supply a best-fit or replacement character or characters; otherwise, it should return `false`. For an exception fallback, the fallback method should throw an exception.  
  
-   The <xref:System.Text.EncoderFallbackBuffer.GetNextChar%2A?displayProperty=nameWithType> or <xref:System.Text.DecoderFallbackBuffer.GetNextChar%2A?displayProperty=nameWithType> method, which is called repeatedly by the encoder or decoder to get the next character from the fallback buffer. When all fallback characters have been returned, the method should return U+0000.  
  
-   The <xref:System.Text.EncoderFallbackBuffer.Remaining%2A?displayProperty=nameWithType> or <xref:System.Text.DecoderFallbackBuffer.Remaining%2A?displayProperty=nameWithType> property, which returns the number of characters remaining in the fallback buffer.  
  
-   The <xref:System.Text.EncoderFallbackBuffer.MovePrevious%2A?displayProperty=nameWithType> or <xref:System.Text.DecoderFallbackBuffer.MovePrevious%2A?displayProperty=nameWithType> method, which moves the current position in the fallback buffer to the previous character.  
  
-   The <xref:System.Text.EncoderFallbackBuffer.Reset%2A?displayProperty=nameWithType> or <xref:System.Text.DecoderFallbackBuffer.Reset%2A?displayProperty=nameWithType> method, which reinitializes the fallback buffer.  
  
 If the fallback implementation is a best-fit fallback or a replacement fallback, the classes derived from <xref:System.Text.EncoderFallbackBuffer> and <xref:System.Text.DecoderFallbackBuffer> also maintain two private instance fields: the exact number of characters in the buffer; and the index of the next character in the buffer to return.  
  
### An EncoderFallback Example  
 An earlier example used replacement fallback to replace Unicode characters that did not correspond to ASCII characters with an asterisk (*). The following example uses a custom best-fit fallback implementation instead to provide a better mapping of non-ASCII characters.  
  
 The following code defines a class named `CustomMapper` that is derived from <xref:System.Text.EncoderFallback> to handle the best-fit mapping of non-ASCII characters. Its `CreateFallbackBuffer` method returns a `CustomMapperFallbackBuffer` object, which provides the <xref:System.Text.EncoderFallbackBuffer> implementation. The `CustomMapper` class uses a <xref:System.Collections.Generic.Dictionary%602> object to store the mappings of unsupported Unicode characters (the key value) and their corresponding 8-bit characters (which are stored in two consecutive bytes in a 64-bit integer). To make this mapping available to the fallback buffer, the `CustomMapper` instance is passed as a parameter to the `CustomMapperFallbackBuffer` class constructor. Because the longest mapping is the string "INF" for the Unicode character U+221E, the `MaxCharCount` property returns 3.  
  
 [!code-csharp[Conceptual.Encoding#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/custom1.cs#5)]
 [!code-vb[Conceptual.Encoding#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/custom1.vb#5)]  
  
 The following code defines the `CustomMapperFallbackBuffer` class, which is derived from <xref:System.Text.EncoderFallbackBuffer>. The dictionary that contains best-fit mappings and that is defined in the `CustomMapper` instance is available from its class constructor. Its `Fallback` method returns `true` if any of the Unicode characters that the ASCII encoder cannot encode are defined in the mapping dictionary; otherwise, it returns `false`. For each fallback, the private `count` variable indicates the number of characters that remain to be returned, and the private `index` variable indicates the position in the string buffer, `charsToReturn`, of the next character to return.  
  
 [!code-csharp[Conceptual.Encoding#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/custom1.cs#6)]
 [!code-vb[Conceptual.Encoding#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/custom1.vb#6)]  
  
 The following code then instantiates the `CustomMapper` object and passes an instance of it to the <xref:System.Text.Encoding.GetEncoding%28System.String%2CSystem.Text.EncoderFallback%2CSystem.Text.DecoderFallback%29?displayProperty=nameWithType> method. The output indicates that the best-fit fallback implementation successfully handles the three non-ASCII characters in the original string.  
  
 [!code-csharp[Conceptual.Encoding#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.encoding/cs/custom1.cs#7)]
 [!code-vb[Conceptual.Encoding#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.encoding/vb/custom1.vb#7)]  
  
## See Also  
 <xref:System.Text.Encoder>  
 <xref:System.Text.Decoder>  
 <xref:System.Text.DecoderFallback>  
 <xref:System.Text.Encoding>  
 <xref:System.Text.EncoderFallback>  
 [Globalization and Localization](../../../docs/standard/globalization-localization/index.md)
