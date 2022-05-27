---
title: "Breaking change: Parameter names changed in .NET 6"
description: Learn about the .NET 6 breaking change in core .NET libraries where some parameter names have changed to be consistent between reference and implementation assemblies.
ms.date: 10/15/2021
---
# Parameter names changed in .NET 6

Some parameter names have changed to be consistent between [reference](../../../../standard/assembly/reference-assemblies.md) and implementation assemblies. Most of the changes are in the reference assemblies, but a handful are in the implementation assemblies.

## Previous behavior

Some [reference assembly](../../../../standard/assembly/reference-assemblies.md) parameter names were different to their corresponding parameters in the implementation assembly. This can cause problems while using named arguments and reflection.

## New behavior

In .NET 6, these mismatched parameter names were updated to be consistent across the reference and implementation assemblies.

The following table shows the APIs and parameter names that changed.

| API | Old parameter name | New parameter name | Where changed |
| - | - | - |
| <xref:System.Attribute.GetCustomAttributes(System.Reflection.MemberInfo,System.Type)?displayProperty=nameWithType> | `type` | `attributeType` | Reference and implementation assembly |
| <xref:System.Attribute.GetCustomAttributes(System.Reflection.MemberInfo,System.Type,System.Boolean)?displayProperty=nameWithType> | `type` | `attributeType` | Reference and implementation assembly |
| <xref:Microsoft.VisualBasic.Strings.InStr(System.Int32,System.String,System.String,Microsoft.VisualBasic.CompareMethod)?displayProperty=nameWithType> | `StartPos` | `Start` | Reference assembly |
| <xref:System.Collections.Generic.SortedList%602.System%23Collections%23ICollection%23CopyTo(System.Array,System.Int32)?displayProperty=nameWithType> | `arrayIndex` | `index` | Reference assembly |
| <xref:System.Numerics.Vector.Narrow%2A?displayProperty=nameWithType> | `source1`, `source2` | `low`, `high` | Reference assembly |
| <xref:System.Numerics.Vector.Widen%2A?displayProperty=nameWithType> | `dest1`, `dest2` | `low`, `high` | Reference assembly |
| <xref:System.IO.StreamWriter.WriteLine(System.ReadOnlySpan{System.Char})?displayProperty=nameWithType> | `value` | `buffer` | Implementation assembly |
| <xref:System.IO.FileStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=nameWithType> | `array`, `numBytes` | `buffer`, `count` | Implementation assembly |
| <xref:System.IO.FileStream.BeginWrite(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=nameWithType> | `array`, `numBytes` | `buffer`, `count` | Implementation assembly |
| <xref:System.IO.MemoryStream.Read(System.Span{System.Byte})?displayProperty=nameWithType> | `destination` | `buffer` | Reference assembly |
| <xref:System.IO.MemoryStream.ReadAsync(System.Memory{System.Byte},System.Threading.CancellationToken)?displayProperty=nameWithType> | `destination` | `buffer` | Reference assembly |
| <xref:System.IO.MemoryStream.Write(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> | `source` | `buffer` | Reference assembly |
| <xref:System.IO.MemoryStream.WriteAsync(System.ReadOnlyMemory{System.Byte},System.Threading.CancellationToken)?displayProperty=nameWithType> | `source` | `buffer` | Reference assembly |
| <xref:System.IO.UnmanagedMemoryStream.Read(System.Span{System.Byte})?displayProperty=nameWithType> | `destination` | `buffer` | Reference assembly |
| <xref:System.IO.UnmanagedMemoryStream.Write(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> | `source` | `buffer` | Reference assembly |
| <xref:System.Security.Cryptography.Pkcs.SignerInfo.AddUnsignedAttribute(System.Security.Cryptography.AsnEncodedData)?displayProperty=nameWithType> | `asnEncodedData` | `unsignedAttribute` | Reference assembly |
| <xref:System.Security.Cryptography.Pkcs.SignerInfo.RemoveUnsignedAttribute(System.Security.Cryptography.AsnEncodedData)?displayProperty=nameWithType> | `asnEncodedData` | `unsignedAttribute` | Reference assembly |
| <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampRequest.ProcessResponse(System.ReadOnlyMemory{System.Byte},System.Int32@)?displayProperty=nameWithType> | `source` | `responseBytes` | Implementation assembly |
| <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampToken.TryDecode(System.ReadOnlyMemory{System.Byte},System.Security.Cryptography.Pkcs.Rfc3161TimestampToken@,System.Int32@)?displayProperty=nameWithType> | `source` | `encodedBytes` | Implementation assembly |
| <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampTokenInfo.%23ctor(System.Security.Cryptography.Oid,System.Security.Cryptography.Oid,System.ReadOnlyMemory{System.Byte},System.ReadOnlyMemory{System.Byte},System.DateTimeOffset,System.Nullable{System.Int64},System.Boolean,System.Nullable{System.ReadOnlyMemory{System.Byte}},System.Nullable{System.ReadOnlyMemory{System.Byte}},System.Security.Cryptography.X509Certificates.X509ExtensionCollection)?displayProperty=nameWithType> | `tsaName` | `timestampAuthorityName` | Implementation assembly |
| <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampTokenInfo.TryDecode(System.ReadOnlyMemory{System.Byte},System.Security.Cryptography.Pkcs.Rfc3161TimestampTokenInfo@,System.Int32@)?displayProperty=nameWithType> | `` | `` |
| <xref:System.Security.Permissions.PrincipalPermission.Equals(System.Object)?displayProperty=nameWithType> | `o` | `obj` | Reference assembly |
| <xref:System.Security.Policy.UrlMembershipCondition.Equals(System.Object)?displayProperty=nameWithType> | `o` | `obj` | Reference assembly |
| <xref:System.Data.Common.DBDataPermission.%23ctor(System.Data.Common.DBDataPermission)> | `dataPermission` | `permission` | Implementation assembly |
| <xref:System.Data.Common.DBDataPermission.%23ctor(System.Data.Common.DBDataPermissionAttribute)> | `attribute` | `permissionAttribute` | Implementation assembly |
| <xref:System.Data.Common.DBDataPermission.%23ctor(System.Security.Permissions.PermissionState,System.Boolean)> | `blankPassword` | `allowBlankPassword` | Implementation assembly |
| <xref:System.Data.Common.DBDataPermission.FromXml(System.Security.SecurityElement)?displayProperty=nameWithType> | `elem` | `securityElement` | Implementation assembly |
| <xref:System.Data.Common.DBDataPermission.Union(System.Security.IPermission)?displayProperty=nameWithType> | `other` | `target` | Implementation assembly |

## Reason for change

- In cases where the reference assembly parameter names were changed, the new names were deemed more appropriate or readable and minimally breaking.
- In cases where the names of runtime parameters were changed to gain consistency across platforms or with reference assemblies, the runtime implementation now matches the public API and documentation for the method.

## Version introduced

.NET 6

## Recommended action

If you encounter a compiler error due to a parameter name change, update the parameter name accordingly.

If you use run-time reflection to inspect methods and took a dependency on the parameter names, update the code to use the new parameter names.

## Affected APIs

- <xref:Microsoft.VisualBasic.Strings.InStr(System.Int32,System.String,System.String,Microsoft.VisualBasic.CompareMethod)?displayProperty=fullName>
- <xref:System.Attribute.GetCustomAttributes(System.Reflection.MemberInfo,System.Type)?displayProperty=fullName>
- <xref:System.Attribute.GetCustomAttributes(System.Reflection.MemberInfo,System.Type,System.Boolean)?displayProperty=fullName>
- <xref:System.Collections.Generic.SortedList%602.System%23Collections%23ICollection%23CopyTo(System.Array,System.Int32)?displayProperty=fullName>
- <xref:System.IO.StreamWriter.WriteLine(System.ReadOnlySpan{System.Char})?displayProperty=fullName>
- <xref:System.IO.FileStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.FileStream.BeginWrite(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.MemoryStream.Read(System.Span{System.Byte})?displayProperty=fullName>
- <xref:System.IO.MemoryStream.ReadAsync(System.Memory{System.Byte},System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.IO.MemoryStream.Write(System.ReadOnlySpan{System.Byte})?displayProperty=fullName>
- <xref:System.IO.MemoryStream.WriteAsync(System.ReadOnlyMemory{System.Byte},System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.IO.UnmanagedMemoryStream.Read(System.Span{System.Byte})?displayProperty=fullName>
- <xref:System.IO.UnmanagedMemoryStream.Write(System.ReadOnlySpan{System.Byte})?displayProperty=fullName>
- <xref:System.Numerics.Vector.Narrow%2A?displayProperty=fullName>
- <xref:System.Numerics.Vector.Widen%2A?displayProperty=fullName>
- <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampRequest.ProcessResponse(System.ReadOnlyMemory{System.Byte},System.Int32@)?displayProperty=fullName>
- <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampToken.TryDecode(System.ReadOnlyMemory{System.Byte},System.Security.Cryptography.Pkcs.Rfc3161TimestampToken@,System.Int32@)?displayProperty=fullName>
- <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampTokenInfo.%23ctor(System.Security.Cryptography.Oid,System.Security.Cryptography.Oid,System.ReadOnlyMemory{System.Byte},System.ReadOnlyMemory{System.Byte},System.DateTimeOffset,System.Nullable{System.Int64},System.Boolean,System.Nullable{System.ReadOnlyMemory{System.Byte}},System.Nullable{System.ReadOnlyMemory{System.Byte}},System.Security.Cryptography.X509Certificates.X509ExtensionCollection)?displayProperty=fullName>
- <xref:System.Security.Cryptography.Pkcs.Rfc3161TimestampTokenInfo.TryDecode(System.ReadOnlyMemory{System.Byte},System.Security.Cryptography.Pkcs.Rfc3161TimestampTokenInfo@,System.Int32@)?displayProperty=fullName>
- <xref:System.Security.Cryptography.Pkcs.SignerInfo.AddUnsignedAttribute(System.Security.Cryptography.AsnEncodedData)?displayProperty=fullName>
- <xref:System.Security.Cryptography.Pkcs.SignerInfo.RemoveUnsignedAttribute(System.Security.Cryptography.AsnEncodedData)?displayProperty=fullName>
- <xref:System.Security.Permissions.PrincipalPermission.Equals(System.Object)?displayProperty=fullName>
- <xref:System.Security.Policy.UrlMembershipCondition.Equals(System.Object)?displayProperty=fullName>
- <xref:System.Data.Common.DBDataPermission.%23ctor(System.Data.Common.DBDataPermission)>
- <xref:System.Data.Common.DBDataPermission.%23ctor(System.Data.Common.DBDataPermissionAttribute)>
- <xref:System.Data.Common.DBDataPermission.%23ctor(System.Security.Permissions.PermissionState,System.Boolean)>
- <xref:System.Data.Common.DBDataPermission.FromXml(System.Security.SecurityElement)?displayProperty=fullName>
- <xref:System.Data.Common.DBDataPermission.Union(System.Security.IPermission)?displayProperty=fullName>

## See also

- [Some parameters in Stream-derived types are renamed](parameters-renamed-on-stream-derived-types.md)
