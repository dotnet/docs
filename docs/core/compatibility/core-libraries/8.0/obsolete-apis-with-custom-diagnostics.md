---
title: "Breaking change: .NET 8 obsoletions with custom IDs"
titleSuffix: ""
description: Learn about the .NET 8 breaking change in core .NET libraries where some APIs have been marked as obsolete with a custom diagnostic ID.
ms.date: 09/08/2023
---
# API obsoletions with non-default diagnostic IDs (.NET 8)

Some APIs have been marked as obsolete, starting in .NET 8. This breaking change is specific to APIs that have been marked as obsolete *with a custom diagnostic ID*. Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Change description

In previous .NET versions, these APIs can be used without any build warning. In .NET 8 and later versions, use of these APIs produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the obsoletion warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages for obsoleted APIs.

| Diagnostic ID | Description | Severity |
| - | - |
| [SYSLIB0011](../../../../fundamentals/syslib-diagnostics/syslib0011.md) | BinaryFormatter serialization is obsolete | Warning/error |
| [SYSLIB0048](../../../../fundamentals/syslib-diagnostics/syslib0048.md) | <xref:System.Security.Cryptography.RSA.EncryptValue(System.Byte[])?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSA.DecryptValue(System.Byte[])?displayProperty=nameWithType> are obsolete. Use <xref:System.Security.Cryptography.RSA.Encrypt%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSA.Decrypt%2A?displayProperty=nameWithType> instead. | Warning |
| [SYSLIB0050](../../../../fundamentals/syslib-diagnostics/syslib0050.md) | Formatter-based serialization is obsolete and should not be used. | Warning |
| [SYSLIB0051](../../../../fundamentals/syslib-diagnostics/syslib0051.md) | APIs that support obsolete formatter-based serialization are obsolete. They should not be called or extended by application code. | Warning |
| [SYSLIB0052](../../../../fundamentals/syslib-diagnostics/syslib0052.md) | APIs that support obsolete mechanisms for Regex extensibility are obsolete. | Warning |
| [SYSLIB0053](../../../../fundamentals/syslib-diagnostics/syslib0053.md) | <xref:System.Security.Cryptography.AesGcm> should indicate the required tag size for encryption and decryption. Use a constructor that accepts the tag size. | Warning |

## Version introduced

.NET 8

## Type of breaking change

These obsoletions can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.

- Warnings or errors for these obsoletions can't be suppressed using the standard diagnostic ID for obsolete types or members; use the custom `SYSLIBxxxx` diagnostic ID value instead.

## Affected APIs

### SYSLIB0011

- <xref:System.Resources.Extensions.PreserializedResourceWriter.AddBinaryFormattedResource(System.String,System.Byte[],System.String)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IFormatter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=fullName>

### SYSLIB0048

- <xref:System.Security.Cryptography.RSA.EncryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSA.DecryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSACryptoServiceProvider.EncryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSACryptoServiceProvider.DecryptValue(System.Byte[])?displayProperty=fullName>

### SYSLIB0050

- <xref:System.Runtime.Serialization.FormatterConverter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.FormatterServices?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IFormatterConverter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IObjectReference?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISafeSerializationData?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISerializationSurrogate?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISurrogateSelector?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ObjectIDGenerator?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ObjectManager?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SafeSerializationEventArgs?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SerializationObjectManager?displayProperty=fullName>
- <xref:System.Runtime.Serialization.StreamingContextStates?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SurrogateSelector?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.FormatterTypeStyle?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.IFieldInfo?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.TypeFilterLevel?displayProperty=fullName>
- <xref:System.Type.IsSerializable?displayProperty=fullName>
- <xref:System.Reflection.FieldAttributes.NotSerialized?displayProperty=fullName>
- <xref:System.Reflection.FieldInfo.IsNotSerialized?displayProperty=fullName>
- <xref:System.Reflection.TypeAttributes.Serializable?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SerializationInfo.%23ctor(System.Type,System.Runtime.Serialization.IFormatterConverter,System.Boolean)>
- <xref:System.Runtime.Serialization.SerializationInfo.%23ctor(System.Type,System.Runtime.Serialization.IFormatterConverter)>
- <xref:System.Runtime.Serialization.StreamingContext.%23ctor(System.Runtime.Serialization.StreamingContextStates,System.Object)>
- <xref:System.Runtime.Serialization.StreamingContext.%23ctor(System.Runtime.Serialization.StreamingContextStates)>

### SYSLIB0051

The `SYSLIB0051` API obsoletions are organized here by namespace.

#### Microsoft.CSharp.RuntimeBinder namespace

- <xref:Microsoft.CSharp.RuntimeBinder.RuntimeBinderException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### Microsoft.VisualBasic.FileIO namespace

- <xref:Microsoft.VisualBasic.FileIO.MalformedLineException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:Microsoft.VisualBasic.FileIO.MalformedLineException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System namespace

- <xref:System.AccessViolationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.AggregateException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.AggregateException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.AppDomainUnloadedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ApplicationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ArgumentException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ArgumentException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ArgumentNullException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ArgumentOutOfRangeException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ArgumentOutOfRangeException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ArithmeticException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ArrayTypeMismatchException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.BadImageFormatException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.BadImageFormatException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.CannotUnloadAppDomainException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ContextMarshalException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DBNull.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Delegate.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DivideByZeroException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DuplicateWaitObjectException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.EntryPointNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Exception.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Exception.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.FieldAccessException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.FormatException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.InvalidCastException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.InvalidOperationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.InvalidTimeZoneException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.MemberAccessException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.MethodAccessException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.MissingFieldException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.MissingMemberException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.MissingMemberException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.MissingMethodException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.MulticastDelegate.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.NotImplementedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.NotSupportedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.NullReferenceException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ObjectDisposedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ObjectDisposedException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.OperatingSystem.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.OperationCanceledException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.OutOfMemoryException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.OverflowException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.PlatformNotSupportedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.RankException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.RuntimeFieldHandle.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.RuntimeMethodHandle.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.RuntimeTypeHandle.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.SystemException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.TimeoutException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.TimeZoneNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.TypeAccessException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.TypeInitializationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.TypeLoadException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.TypeLoadException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.TypeUnloadedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.UnauthorizedAccessException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.WeakReference.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.WeakReference.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.UriFormatException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Collections namespace

- <xref:System.Collections.Comparer.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Collections.Generic namespace

- <xref:System.Collections.Generic.LinkedList%601.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Generic.LinkedList%601.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Generic.SortedSet%601.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Generic.Dictionary%602.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Generic.Dictionary%602.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Generic.HashSet%601.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Generic.HashSet%601.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Generic.KeyNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Collections.Specialized namespace

- <xref:System.Collections.Specialized.NameObjectCollectionBase.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Specialized.NameObjectCollectionBase.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Specialized.NameValueCollection.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Specialized.OrderedDictionary.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Collections.Specialized.OrderedDictionary.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.ComponentModel namespace

- <xref:System.ComponentModel.InvalidAsynchronousStateException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.InvalidEnumArgumentException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.LicenseException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.LicenseException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.WarningException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.WarningException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.Win32Exception.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.Win32Exception.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.ComponentModel.Composition namespace

- <xref:System.ComponentModel.Composition.CompositionContractMismatchException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.Composition.ImportCardinalityMismatchException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.ComponentModel.Composition.Primitives namespace

- <xref:System.ComponentModel.Composition.Primitives.ComposablePartException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.ComponentModel.Composition.Primitives.ComposablePartException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.ComponentModel.DataAnnotations namespace

- <xref:System.ComponentModel.DataAnnotations.ValidationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.ComponentModel.Design namespace

- <xref:System.ComponentModel.Design.CheckoutException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Configuration namespace

- <xref:System.Configuration.ConfigurationErrorsException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.ConfigurationErrorsException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.ConfigurationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.ConfigurationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.ConfigurationSectionCollection.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.ConfigurationSectionGroupCollection.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.PropertyInformationCollection.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.SettingsPropertyIsReadOnlyException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.SettingsPropertyNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.SettingsPropertyWrongTypeException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.Provider.ProviderException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.SettingsPropertyIsReadOnlyException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.SettingsPropertyNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Configuration.SettingsPropertyWrongTypeException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Data namespace

- <xref:System.Data.ConstraintException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.DataException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.DataSet.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.DataTable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.DBConcurrencyException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.DeletedRowInaccessibleException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.DuplicateNameException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.EvaluateException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.InRowChangingEventException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.InvalidConstraintException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.InvalidExpressionException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.MissingPrimaryKeyException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.NoNullAllowedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.PropertyCollection.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.ReadOnlyException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.RowNotInTableException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.StrongTypingException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.SyntaxErrorException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.TypedTableBase%601.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Data.VersionNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Data.Common namespace

- <xref:System.Data.Common.DbException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Data.Odbc namespace

- <xref:System.Data.Odbc.OdbcException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Data.OleDb namespace

- <xref:System.Data.OleDb.OleDbException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Data.SqlTypes namespace

- <xref:System.Data.SqlTypes.SqlTypeException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Diagnostics.Eventing.Reader namespace

- <xref:System.Diagnostics.Eventing.Reader.EventLogException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Diagnostics.Eventing.Reader.EventLogException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Diagnostics.Eventing.Reader.EventLogInvalidDataException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Diagnostics.Eventing.Reader.EventLogNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Diagnostics.Eventing.Reader.EventLogProviderDisabledException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Diagnostics.Eventing.Reader.EventLogReadingException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Diagnostics.Tracing namespace

- <xref:System.Diagnostics.Tracing.EventSourceException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.DirectoryServices namespace

- <xref:System.DirectoryServices.DirectoryServicesCOMException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.DirectoryServicesCOMException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.DirectoryServices.AccountManagement namespace

- <xref:System.DirectoryServices.AccountManagement.MultipleMatchesException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.NoMatchingPrincipalException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.PasswordException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.PrincipalException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.PrincipalExistsException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.PrincipalOperationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.PrincipalOperationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.PrincipalServerDownException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.AccountManagement.PrincipalServerDownException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.DirectoryServices.ActiveDirectory namespace

- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectExistsException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectNotFoundException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryServerDownException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryServerDownException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ForestTrustCollisionException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.ForestTrustCollisionException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.DirectoryServices.Protocols namespace

- <xref:System.DirectoryServices.Protocols.BerConversionException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.DirectoryException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.DirectoryOperationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.DirectoryOperationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.LdapException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.LdapException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.TlsOperationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Formats.Asn1 namespace

- <xref:System.Formats.Asn1.AsnContentException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Formats.Cbor namespace

- <xref:System.Formats.Cbor.CborContentException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Globalization namespace

- <xref:System.Globalization.CultureNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Globalization.CultureNotFoundException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.IO namespace

- <xref:System.IO.DirectoryNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.DriveNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.EndOfStreamException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileFormatException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileFormatException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileLoadException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileLoadException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileNotFoundException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileNotFoundException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.InternalBufferOverflowException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.IOException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.IsolatedStorage.IsolatedStorageException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.IO.PathTooLongException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Management namespace

- <xref:System.Management.ManagementBaseObject.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Management.ManagementClass.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Management.ManagementException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Management.ManagementException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Management.ManagementNamedValueCollection.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Media namespace

- <xref:System.Media.SoundPlayer.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Net namespace

- <xref:System.Net.CookieException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.CookieException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.FileWebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.FileWebResponse.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.HttpListenerException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.HttpWebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.HttpWebResponse.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.ProtocolViolationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.ProtocolViolationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebHeaderCollection.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebHeaderCollection.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebResponse.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Net.Mail namespace

- <xref:System.Net.Mail.SmtpException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.Mail.SmtpException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.Mail.SmtpFailedRecipientException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.Mail.SmtpFailedRecipientException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.Mail.SmtpFailedRecipientsException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.Mail.SmtpFailedRecipientsException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Net.NetworkInformation namespace

- <xref:System.Net.NetworkInformation.NetworkInformationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.PingException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Net.Sockets namespace

- <xref:System.Net.Sockets.SocketException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Reflection namespace

- <xref:System.Reflection.Assembly.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.AssemblyName.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.CustomAttributeFormatException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.InvalidFilterCriteriaException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.Module.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.ParameterInfo.GetRealObject(System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.ReflectionTypeLoadException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.StrongNameKeyPair.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Reflection.TargetException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Reflection.Metadata namespace

- <xref:System.Reflection.Metadata.ImageFormatLimitationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Resources namespace

- <xref:System.Resources.MissingManifestResourceException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Resources.MissingSatelliteAssemblyException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Runtime.CompilerServices namespace

- <xref:System.Runtime.CompilerServices.RuntimeWrappedException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.SwitchExpressionException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Runtime.InteropServices namespace

- <xref:System.Runtime.InteropServices.ExternalException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SerializationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Runtime.Serialization namespace

- <xref:System.Runtime.Serialization.InvalidDataContractException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Security namespace

- <xref:System.Security.HostProtectionException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.SecurityException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.SecurityException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.VerificationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Security.AccessControl namespace

- <xref:System.Security.AccessControl.PrivilegeNotHeldException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Security.Authentication namespace

- <xref:System.Security.Authentication.InvalidCredentialException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Security.Claims namespace

- <xref:System.Security.Claims.ClaimsIdentity.%23ctor(System.Runtime.Serialization.SerializationInfo)?displayProperty=fullName>
- <xref:System.Security.Claims.ClaimsIdentity.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Claims.ClaimsPrincipal.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Security.Cryptography namespace

- <xref:System.Security.Cryptography.CryptographicException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Cryptography.CryptographicUnexpectedOperationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Security.Policy namespace

- <xref:System.Security.Policy.Hash.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Policy.PolicyException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Security.Principal namespace

- <xref:System.Security.Principal.IdentityNotMappedException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Principal.WindowsIdentity.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Text.Json namespace

- <xref:System.Text.Json.JsonException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Text.Json.JsonException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Text.RegularExpressions namespace

- <xref:System.Text.RegularExpressions.RegexMatchTimeoutException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.RegexParseException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Threading namespace

- <xref:System.Threading.CompressedStack.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.ThreadInterruptedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.ThreadStateException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.BarrierPostPhaseException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.AbandonedMutexException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.ExecutionContext.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.LockRecursionException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.SemaphoreFullException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.SynchronizationLockException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.WaitHandleCannotBeOpenedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Threading.Channels namespace

- <xref:System.Threading.Channels.ChannelClosedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Threading.Tasks namespace

- <xref:System.Threading.Tasks.TaskCanceledException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Threading.Tasks.TaskSchedulerException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Transactions namespace

- <xref:System.Transactions.TransactionAbortedException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Transactions.TransactionException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Transactions.TransactionInDoubtException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Transactions.TransactionManagerCommunicationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Transactions.TransactionPromotionException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Xml namespace

- <xref:System.Xml.XmlException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.XmlException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Xml.Schema namespace

- <xref:System.Xml.Schema.XmlSchemaException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Schema.XmlSchemaException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Schema.XmlSchemaInferenceException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Schema.XmlSchemaInferenceException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Schema.XmlSchemaValidationException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Schema.XmlSchemaValidationException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Xml.XPath namespace

- <xref:System.Xml.XPath.XPathException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.XPath.XPathException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>

#### System.Xml.Xsl namespace

- <xref:System.Xml.Xsl.XsltCompileException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Xsl.XsltCompileException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Xsl.XsltException.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Xml.Xsl.XsltException.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>



### SYSLIB0052

- <xref:System.Text.RegularExpressions.Regex.InitializeReferences?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.UseOptionC?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.UseOptionR?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.RegexRunner.CharInSet(System.Char,System.String,System.String)?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.RegexRunner.Scan(System.Text.RegularExpressions.Regex,System.String,System.Int32,System.Int32,System.Int32,System.Int32,System.Boolean)?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.RegexRunner.Scan(System.Text.RegularExpressions.Regex,System.String,System.Int32,System.Int32,System.Int32,System.Int32,System.Boolean,System.TimeSpan)?displayProperty=fullName>

### SYSLIB0053

- <xref:System.Security.Cryptography.AesGcm.%23ctor(System.Byte[])>
- <xref:System.Security.Cryptography.AesGcm.%23ctor(System.ReadOnlySpan{System.Byte})>

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 7)](../7.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 6)](../6.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 5)](../5.0/obsolete-apis-with-custom-diagnostics.md)
- [Obsolete features in .NET 5+](../../../../fundamentals/syslib-diagnostics/obsoletions-overview.md)
