---
title: Transform data by composing streams
description: "Learn about how stream composition can transform data. Data passing through the stream is automatically altered."
#ms.topic: concept-article (for a future work item that rewrites this article in this format)
ms.date: 08/02/2024
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "streams, base streams"
  - "I/O [.NET], composing streams"
  - "Stream class, composing streams"
  - "base streams"
  - "streams, backing stores"

#customer intent: As a developer, I want to transform data through a stream so that I can read or write the data in a different way/

---
# Compose streams

A *backing store* is a storage medium, such as a disk or memory. Each different backing store implements its own stream as an implementation of the <xref:System.IO.Stream> class.

Each stream type reads and writes bytes from and to its given backing store. Streams that connect to backing stores are called *base streams*. Base streams have constructors with the parameters necessary to connect the stream to the backing store. For example, <xref:System.IO.FileStream> has constructors that specify an access mode parameter, which specifies how if the file is read from, written to, or both.

The design of the <xref:System.IO> classes provides simplified stream composition. You can attach base streams to one or more pass-through streams that provide the functionality you want. You can attach a reader or writer to the end of the chain, so the preferred types can be read or written easily.  

## Prerequisites

These examples use a plain-text file named _data.txt_. This file should contain some text.

## Example: Encrypt and decrypt stream data

The following example reads data from a file, encrypts it, and then writes the encrypted data to another file. Stream composition is used to transform the data using a basic shifting cipher. Each byte that passes through the stream has its value changed by **80**.

> [!WARNING]
> The encryption used in this example is a very basic and unsecure encryption. It's not meant to actually encrypt data for use, but is provided to demonstrate altering data through stream composition.

### Reading the source data for encryption

The following code reads the text from one file, transforms it, then writes it to another file.

> [!TIP]
> Before considering this code, know that the `CipherStream` is a user-defined type. The code for this class is provided at the end of this article in the [CipherStream class](#cipherstream-class) section.

:::code language="csharp" source="./snippets/composing-streams/csharp/Program.cs" id="WriteShiftedFile":::

The previous code starts with two <xref:System.IO.FileStream> objects. The first `FileStream`, assigned to the `inputBaseStream` variable, reads the contents of a text file. Next, another stream is created, a `CipherStream` assigned to the `encryptStream` variable, which wraps the `inputBaseStream`. Now, `inputBaseStream` is the base stream for `encryptStream`.

As each byte is read from `encryptStream`, it's pulled from the base stream (the file stream), transformed, and then returned. The returned byte is then written to the output text file (_shifted.txt_), represented by the `outputBaseStream` variable.

### Reading the transformed data for decryption

This code reverses the encryption performed by the previous code:

:::code language="csharp" source="./snippets/composing-streams/csharp/Program.cs" id="ReadShiftedFile":::

The previous code has two <xref:System.IO.FileStream>. The first is a stream to read the encrypted file contents of _shifted.txt_. This stream is assigned to the `inputBaseStream` variable. Next, the `outputBaseStream` variable points to the output stream, the _unshifted.txt_ file. Finally, the `CipherStream` object does the decryption and wraps the output stream. This stream is assigned to the `unencryptStream` variable.

As each byte is read from `inputBaseStream`, it's written to `encryptStream`. The `CipherStream` transforms the data, writing it to the base stream, which is the output text file (_unshifted.txt_).

### Validating the transformed data

The two previous examples performed two file operations. First, the contents of the _data.txt_ file was encrypted and saved to the _shifted.txt_ file. And second, the encrypted contents were read from the _shifted.txt_ file, decrypted, and saved to the _unshifted.txt_ file. Therefore, the _data.txt_ file and _unshifted.txt_ file should be exactly the same. The following code compares those files for equality:

:::code language="csharp" source="./snippets/composing-streams/csharp/Program.cs" id="ValidateFile":::

The following code runs this entire encrypt-decrypt process:

:::code language="csharp" source="./snippets/composing-streams/csharp/Program.cs" id="TestCode":::

### CipherStream class

The following snippet provides the `CipherStream` class, which uses a basic shifting cipher to encrypt and decrypt bytes. This class inherits from <xref:System.IO.Stream> and supports either reading or writing data.

> [!WARNING]
> The encryption used in this example is a very basic and unsecure encryption. It's not meant to actually encrypt data for use, but is provided to demonstrate altering data through stream composition.

:::code language="csharp" source="./snippets/composing-streams/csharp/CipherStream.cs":::

## See also

- <xref:System.IO.StreamReader>
- <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>
- <xref:System.IO.StreamReader.Peek%2A?displayProperty=nameWithType>
- <xref:System.IO.FileStream>
- <xref:System.IO.BinaryReader>
- <xref:System.IO.BinaryReader.ReadByte%2A?displayProperty=nameWithType>
- <xref:System.IO.BinaryReader.PeekChar%2A?displayProperty=nameWithType>
