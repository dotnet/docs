---
title: "Breaking change: Partial and zero-byte reads in DeflateStream, GZipStream, and CryptoStream"
description: Learn about the .NET 6 breaking change in core .NET libraries where DeflateStream, GZipStream, and CryptoStream handle partial and zero-byte reads differently.
ms.date: 06/23/2021
---
# Partial and zero-byte reads in DeflateStream, GZipStream, and CryptoStream

<xref:System.IO.Compression.DeflateStream>, <xref:System.IO.Compression.GZipStream>, and <xref:System.Security.Cryptography.CryptoStream> diverged from typical <xref:System.IO.Stream.Read%2A?displayProperty=nameWithType> and <xref:System.IO.Stream.ReadAsync%2A?displayProperty=nameWithType> behavior in two ways:

- They didn't complete the read operation until either the buffer passed to the read operation was completely filled or the end of the stream was reached.
- As wrapper streams, they didn't delegate zero-length buffer functionality to the stream they wrap.

This change addresses both of these issues.

## Old behavior

When `Stream.Read` or `Stream.ReadAsync` was called on one of the affected stream types with a buffer of length `N`, the operation would not complete until:

- `N` bytes had been read from the stream, or
- The underlying stream they wrap returned 0 from a call to its read, indicating no more data is available.

Also, when `Stream.Read` or `Stream.ReadAsync` was called with a buffer of length 0, the operation would succeed immediately, sometimes without doing a zero-length read on the stream it wraps.

## New behavior

Starting in .NET 6, when `Stream.Read` or `Stream.ReadAsync` is called on one of the affected stream types with a buffer of length `N`, the operation completes when:

- At least one byte has been read from the stream, or
- The underlying stream they wrap returns 0 from a call to its read, indicating no more data is available.

Also, when `Stream.Read` or `Stream.ReadAsync` is called with a buffer of length 0, the operation succeeds once a call with a non-zero buffer would succeed.

## Version introduced

6.0

## Reason for change

The streams might not have returned from a read operation even if data had been successfully read. This meant they couldn't readily be used in any bidirectional communication situation where messages smaller than the buffer size were being used. This could lead to deadlocks: the application is unable to read the data from the stream that's necessary to continue the operation. It could also lead to arbitrary slowdowns, with the consumer unable to process available data while waiting for additional data to arrive.

Also, in highly scalable applications, it's common to use zero-byte reads as a way of delaying buffer allocation until a buffer is needed. An application can issue a read with an empty buffer, and when that read completes, data should soon be available to consume. The application can then issue the read again, this time with a buffer to receive the data. By delegating to the wrapped stream if no already decompressed or transformed data is available, these streams now inherit any such behavior of the streams they wrap.

## Recommended action

In general, code should:

- Not make any assumptions about a stream `Read` or `ReadAsync` operation reading as much as was requested. The call returns the number of bytes read, which may be less than what was requested. If an application depends on the buffer being completely filled before progressing, it can perform the read in a loop to regain the behavior.

  ```csharp
  int totalRead = 0;
  while (totalRead < buffer.Length)
  {
      int bytesRead = stream.Read(buffer.Slice(totalRead));
      if (bytesRead == 0) break;
      totalRead += bytesRead;
  }
  ```

- Expect that a stream `Read` or `ReadAsync` call may not complete until at least a byte of data is available for consumption (or the stream reaches its end), regardless of how many bytes were requested. If an application depends on a zero-byte read completing immediately without waiting, it can check the buffer length itself and skip the call entirely:

  ```csharp
  int bytesRead = 0;
  if (!buffer.IsEmpty)
  {
      bytesRead = stream.Read(buffer);
  }
  ```

## Affected APIs

- <xref:System.IO.Compression.DeflateStream.Read%2A?displayProperty=fullName>
- <xref:System.IO.Compression.DeflateStream.ReadAsync%2A?displayProperty=fullName>
- <xref:System.IO.Compression.DeflateStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.Read%2A?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.ReadAsync%2A?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.Security.Cryptography.CryptoStream.Read%2A?displayProperty=fullName>
- <xref:System.Security.Cryptography.CryptoStream.ReadAsync%2A?displayProperty=fullName>
- <xref:System.Security.Cryptography.CryptoStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>

<!--

### Category

Core .NET libraries

-->
