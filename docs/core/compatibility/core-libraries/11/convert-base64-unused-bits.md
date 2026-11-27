---
title: "Breaking change: Convert Base64 decoders reject nonzero pad bits"
description: "Learn about the breaking change in .NET 11 where System.Convert rejects padded Base64 input with nonzero unused bits."
ms.date: 11/18/2026
ai-usage: ai-assisted
---

# Convert Base64 decoders reject nonzero pad bits

In .NET 11, <xref:System.Convert?displayProperty=fullName> Base64 decoders reject padded input when the final Base64 character before padding contains nonzero unused bits (pad bits). After you upgrade from .NET 10, previously accepted values, such as externally generated authentication secrets or SSH host-key fingerprints, might fail to decode.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, in .NET 10 and earlier, `Convert` Base64 decoders ignored the unused bits in the last Base64 character before padding. For example, `QQ==` and `QR==` both decoded to `A`, and `QUI=` and `QUJ=` both decoded to `AB`. `QQ==` and `QUI=` are the canonical encodings.

## New behavior

Starting in .NET 11, `Convert` Base64 decoders require the unused bits in the final four-character group to be zero.

| Padding | Required unused bits |
| --- | --- |
| One `=` | The low two bits of the third Base64 character must be zero. |
| Two `=` characters | The low four bits of the second Base64 character must be zero. |

`Convert.FromBase64String` and `Convert.FromBase64CharArray` throw <xref:System.FormatException> for inputs such as `QR==` and `QUJ=`. `Convert.TryFromBase64String` and `Convert.TryFromBase64Chars` return `false` and set `bytesWritten` to `0`. A failed `Try` call can still modify part of the destination, so don't use the output on failure.

Canonical padded input and complete groups that don't need padding, such as `QUJD` (`ABC`), still decode. Input that's missing required padding, such as `QQ`, is still rejected. The handling of spaces, tabs, carriage returns, and line feeds is unchanged.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

[RFC 4648, section 3.5](https://datatracker.ietf.org/doc/html/rfc4648#section-3.5) requires conforming encoders to set unused bits to zero and permits, but doesn't require, decoders to reject nonzero unused bits. Canonical encoding avoids mismatches when one system validates decoded bytes but another compares the encoded text, such as a fingerprint. `Convert` encoders already set these bits to zero.

<xref:System.Buffers.Text.Base64> and <xref:System.Buffers.Text.Base64Url> have rejected nonzero unused bits since .NET 9, so switching to those APIs doesn't restore the previous behavior. For implementation details, see [dotnet/runtime#121044](https://github.com/dotnet/runtime/pull/121044).

## Recommended action

**Correct the producer first.** Use a conforming encoder, such as <xref:System.Convert.ToBase64String*>. For stored values, decode the legacy text and re-encode the bytes on .NET 10 before upgrading. For example, the following code converts `QUJ=` to `QUI=` without changing the decoded bytes:

```csharp
byte[] bytes = Convert.FromBase64String("QUJ=");
string canonical = Convert.ToBase64String(bytes);
```

Follow your protocol's rules before replacing encoded text. Re-encoding preserves the bytes, but a signature or identifier might depend on the exact text.

**Check input before upgrading.** On .NET 9 or .NET 10, call `System.Buffers.Text.Base64.IsValid(input.AsSpan())` to check for valid Base64, including zero unused bits, without allocating a destination buffer. A `false` result doesn't identify which validation rule failed.

**Diagnose decode failures and use a fallback only if necessary.** A `FormatException` or `false` return value doesn't prove that the unused bits caused the failure. Invalid characters, incorrect padding, or an incomplete group can also cause rejection. The `Try` methods also return `false` if the destination is too small.

To confirm the cause, first try the standard decoder with sufficient destination space. If it rejects the input, use the padding rules in [New behavior](#new-behavior) to clear only the unused low bits of the last Base64 character before padding, then retry the standard decoder. For otherwise valid input, this change preserves the bytes that .NET 10 would have decoded. A successful retry confirms that nonzero unused bits caused the rejection. If the retry fails, reject the input. Adding or removing `=` characters alone doesn't clear the unused bits.

If you can't update the producer and your protocol permits the legacy encoding, limit the fallback to the affected input source. See the [runtime team's guidance](https://github.com/dotnet/runtime/issues/133495#issuecomment-5780841916) and the [MIT-licensed `LenientBase64Convert` sample](https://gist.github.com/jozkee/77e543db3bddebe8e462f1ab5abf9f64) for application-side implementations of the four affected methods. The sample isn't a framework API. There's no built-in compatibility switch or lenient `Convert` overload.

Don't log secrets or key material when you trace rejected input to its source, and don't use normalization to bypass signature verification, fingerprint trust checks, or other protocol validation.

## Affected APIs

- <xref:System.Convert.FromBase64String(System.String)?displayProperty=nameWithType>
- <xref:System.Convert.FromBase64CharArray(System.Char[],System.Int32,System.Int32)?displayProperty=nameWithType>
- <xref:System.Convert.TryFromBase64String(System.String,System.Span{System.Byte},System.Int32@)?displayProperty=nameWithType>
- <xref:System.Convert.TryFromBase64Chars(System.ReadOnlySpan{System.Char},System.Span{System.Byte},System.Int32@)?displayProperty=nameWithType>
