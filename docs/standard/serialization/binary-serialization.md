---
title: "Binary serialization"
ms.date: "01/02/2018"
helpviewer_keywords: 
  - "binary serialization"
  - "serialization, about serialization"
  - "deserialization"
  - "binary serialization, about serialization"
  - "binary serialization, .net core serialization"
  - "serialization, cross-framework"
ms.assetid: 2b1ea3be-1152-4032-b2b3-07794054c405
author: "ViktorHofer"
---
# Binary serialization

Serialization can be defined as the process of storing the state of an object to a storage medium. During this process, the public and private fields of the object and the name of the class, including the assembly containing the class, are converted to a stream of bytes, which is then written to a data stream. When the object is subsequently deserialized, an exact clone of the original object is created.

When implementing a serialization mechanism in an object-oriented environment, you have to make a number of tradeoffs between ease of use and flexibility. The process can be automated to a large extent, provided you are given sufficient control over the process. For example, situations may arise where simple binary serialization is not sufficient, or there might be a specific reason to decide which fields in a class need to be serialized. The following sections examine the robust serialization mechanism provided with .NET and highlight a number of important features that allow you to customize the process to meet your needs.

> [!NOTE]
> The state of a UTF-8 or UTF-7 encoded object is not preserved if the object is serialized and deserialized using different .NET Framework versions.

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]

Binary serialization allows modifying private members inside an object and therefore changing the state of it. Because of this, other serialization frameworks, like JSON.NET, that operate on the public API surface are recommended.

## Binary serialization in .NET Core

.NET Core supports binary serialization for a subset of types. You can see the list of supported types in the [Serializable types](#serializable-types) section that follows. The listed types are guaranteed to be serializable between .NET Framework 4.5.1 and later versions and between .NET Core 2.0 and later versions. Other .NET implementations, such as Mono, aren't officially supported but should also work.

### Serializable types

| Type | Notes |
| - | - |
| <xref:Microsoft.CSharp.RuntimeBinder.RuntimeBinderException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.AccessViolationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.AggregateException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.AppDomainUnloadedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ApplicationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ArgumentException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ArgumentNullException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ArgumentOutOfRangeException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ArithmeticException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Array?displayProperty=nameWithType> | |
| <xref:System.ArraySegment%601?displayProperty=nameWithType> | |
| <xref:System.ArrayTypeMismatchException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Attribute?displayProperty=nameWithType> | |
| <xref:System.BadImageFormatException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Boolean?displayProperty=nameWithType> | |
| <xref:System.Byte?displayProperty=nameWithType> | |
| <xref:System.CannotUnloadAppDomainException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Char?displayProperty=nameWithType> | |
| <xref:System.Collections.ArrayList?displayProperty=nameWithType> | |
| <xref:System.Collections.BitArray?displayProperty=nameWithType> | |
| <xref:System.Collections.Comparer?displayProperty=nameWithType> | |
| <xref:System.Collections.DictionaryEntry?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.Comparer%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.EqualityComparer%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.HashSet%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.KeyNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Collections.Generic.KeyValuePair%602?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.LinkedList%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.SortedList%602?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.SortedSet%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Generic.Stack%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Hashtable?displayProperty=nameWithType> | |
| <xref:System.Collections.ObjectModel.Collection%601?displayProperty=nameWithType> | |
| <xref:System.Collections.ObjectModel.KeyedCollection%602?displayProperty=nameWithType> | |
| <xref:System.Collections.ObjectModel.ObservableCollection%601?displayProperty=nameWithType> | |
| <xref:System.Collections.ObjectModel.ReadOnlyCollection%601?displayProperty=nameWithType> | |
| <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602?displayProperty=nameWithType> | |
| <xref:System.Collections.ObjectModel.ReadOnlyObservableCollection%601?displayProperty=nameWithType> | |
| <xref:System.Collections.Queue?displayProperty=nameWithType> | |
| <xref:System.Collections.SortedList?displayProperty=nameWithType> | |
| <xref:System.Collections.Specialized.HybridDictionary?displayProperty=nameWithType> | |
| <xref:System.Collections.Specialized.ListDictionary?displayProperty=nameWithType> | |
| <xref:System.Collections.Specialized.OrderedDictionary?displayProperty=nameWithType> | |
| <xref:System.Collections.Specialized.StringCollection?displayProperty=nameWithType> | |
| <xref:System.Collections.Specialized.StringDictionary?displayProperty=nameWithType> | |
| <xref:System.Collections.Stack?displayProperty=nameWithType> | |
| `System.Collections.Generic.NonRandomizedStringEqualityComparer` | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ComponentModel.BindingList%601?displayProperty=nameWithType> | |
| <xref:System.ComponentModel.DataAnnotations.ValidationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ComponentModel.Design.CheckoutException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ComponentModel.InvalidAsynchronousStateException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ComponentModel.InvalidEnumArgumentException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ComponentModel.LicenseException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions, serialization from .NET Framework to .NET Core is not supported |
| <xref:System.ComponentModel.WarningException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ComponentModel.Win32Exception?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Configuration.ConfigurationErrorsException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Configuration.ConfigurationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Configuration.Provider.ProviderException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Configuration.SettingsPropertyIsReadOnlyException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Configuration.SettingsPropertyNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Configuration.SettingsPropertyWrongTypeException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ContextMarshalException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DBNull?displayProperty=nameWithType> | Available in .NET Core 2.0.2 and later versions. |
| <xref:System.Data.Common.DbException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.ConstraintException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.DBConcurrencyException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.DataException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.DataSet?displayProperty=nameWithType> | |
| <xref:System.Data.DataTable?displayProperty=nameWithType> | Unless you set `RemotingFormat` to `SerializationFormat.Binary`, in which case it can only be exchanged with .NET Core 2.1 and later versions. |
| <xref:System.Data.DeletedRowInaccessibleException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.DuplicateNameException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.EvaluateException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.InRowChangingEventException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.InvalidConstraintException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.InvalidExpressionException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.MissingPrimaryKeyException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.NoNullAllowedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.Odbc.OdbcException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.OperationAbortedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.PropertyCollection?displayProperty=nameWithType> | |
| <xref:System.Data.ReadOnlyException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.RowNotInTableException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.SqlClient.SqlException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions.<br/>Serialization from .NET Framework to .NET Core is not supported |
| <xref:System.Data.SqlTypes.SqlAlreadyFilledException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.SqlTypes.SqlBoolean?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlByte?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlDateTime?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlDouble?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlGuid?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlInt16?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlInt32?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlInt64?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlNotFilledException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.SqlTypes.SqlNullValueException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.SqlTypes.SqlString?displayProperty=nameWithType> | |
| <xref:System.Data.SqlTypes.SqlTruncateException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.SqlTypes.SqlTypeException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.StrongTypingException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.SyntaxErrorException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Data.VersionNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DataMisalignedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DateTime?displayProperty=nameWithType> | |
| <xref:System.DateTimeOffset?displayProperty=nameWithType> | |
| <xref:System.Decimal?displayProperty=nameWithType> | |
| `System.Diagnostics.Contracts.ContractException` | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Diagnostics.Tracing.EventSourceException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.DirectoryNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.AccountManagement.MultipleMatchesException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.AccountManagement.NoMatchingPrincipalException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.AccountManagement.PasswordException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.AccountManagement.PrincipalException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.AccountManagement.PrincipalExistsException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.AccountManagement.PrincipalOperationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.AccountManagement.PrincipalServerDownException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectExistsException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryServerDownException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.ActiveDirectory.ForestTrustCollisionException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.DirectoryServicesCOMException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.Protocols.BerConversionException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.Protocols.DirectoryException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.Protocols.DirectoryOperationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.Protocols.LdapException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DirectoryServices.Protocols.TlsOperationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DivideByZeroException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.DllNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Double?displayProperty=nameWithType> | |
| <xref:System.Drawing.Color?displayProperty=nameWithType> | |
| <xref:System.Drawing.Point?displayProperty=nameWithType> | |
| <xref:System.Drawing.PointF?displayProperty=nameWithType> | |
| <xref:System.Drawing.Rectangle?displayProperty=nameWithType> | |
| <xref:System.Drawing.RectangleF?displayProperty=nameWithType> | |
| <xref:System.Drawing.Size?displayProperty=nameWithType> | |
| <xref:System.Drawing.SizeF?displayProperty=nameWithType> | |
| <xref:System.DuplicateWaitObjectException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.EntryPointNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Enum?displayProperty=nameWithType> | |
| <xref:System.EventArgs?displayProperty=nameWithType> | Available in .NET Core 2.0.6 and later versions. |
| <xref:System.Exception?displayProperty=nameWithType> | |
| <xref:System.ExecutionEngineException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.FieldAccessException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.FormatException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Globalization.CompareInfo?displayProperty=nameWithType> | |
| <xref:System.Globalization.CultureNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Globalization.SortVersion?displayProperty=nameWithType> | |
| <xref:System.Guid?displayProperty=nameWithType> | |
| `System.IO.Compression.ZLibException` | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.DriveNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.EndOfStreamException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.FileFormatException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.FileLoadException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.FileNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.IOException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.InternalBufferOverflowException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.InvalidDataException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.IsolatedStorage.IsolatedStorageException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IO.PathTooLongException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.IndexOutOfRangeException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.InsufficientExecutionStackException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.InsufficientMemoryException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Int16?displayProperty=nameWithType> | |
| <xref:System.Int32?displayProperty=nameWithType> | |
| <xref:System.Int64?displayProperty=nameWithType> | |
| <xref:System.IntPtr?displayProperty=nameWithType> | |
| <xref:System.InvalidCastException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.InvalidOperationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.InvalidProgramException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.InvalidTimeZoneException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.MemberAccessException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.MethodAccessException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.MissingFieldException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.MissingMemberException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.MissingMethodException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.MulticastNotSupportedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.Cookie?displayProperty=nameWithType> | |
| <xref:System.Net.CookieCollection?displayProperty=nameWithType> | |
| <xref:System.Net.CookieContainer?displayProperty=nameWithType> | |
| <xref:System.Net.CookieException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.HttpListenerException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.Mail.SmtpException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.Mail.SmtpFailedRecipientException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.Mail.SmtpFailedRecipientsException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.NetworkInformation.NetworkInformationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.NetworkInformation.PingException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.ProtocolViolationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.Sockets.SocketException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.WebException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Net.WebSockets.WebSocketException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.NotFiniteNumberException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.NotImplementedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.NotSupportedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.NullReferenceException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Nullable%601?displayProperty=nameWithType> | |
| <xref:System.Numerics.BigInteger?displayProperty=nameWithType> | |
| <xref:System.Numerics.Complex?displayProperty=nameWithType> | |
| <xref:System.Object?displayProperty=nameWithType> | |
| <xref:System.ObjectDisposedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.OperationCanceledException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.OutOfMemoryException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.OverflowException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.PlatformNotSupportedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.RankException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Reflection.AmbiguousMatchException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Reflection.CustomAttributeFormatException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Reflection.InvalidFilterCriteriaException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Reflection.ReflectionTypeLoadException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions.<br/>Serialization from .NET Framework to .NET Core is not supported. |
| <xref:System.Reflection.TargetException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Reflection.TargetInvocationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Reflection.TargetParameterCountException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Resources.MissingManifestResourceException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Resources.MissingSatelliteAssemblyException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.CompilerServices.RuntimeWrappedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.COMException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.ExternalException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.InvalidComObjectException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.InvalidOleVariantTypeException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.MarshalDirectiveException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.SEHException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.SafeArrayRankMismatchException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.InteropServices.SafeArrayTypeMismatchException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.Serialization.InvalidDataContractException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Runtime.Serialization.SerializationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.SByte?displayProperty=nameWithType> | |
| <xref:System.Security.AccessControl.PrivilegeNotHeldException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.Authentication.AuthenticationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.Authentication.InvalidCredentialException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.Cryptography.CryptographicException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.Cryptography.CryptographicUnexpectedOperationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| `System.Security.Cryptography.Xml.CryptoSignedXmlRecursionException` | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.HostProtectionException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.Policy.PolicyException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.Principal.IdentityNotMappedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.SecurityException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions, limited serialization data |
| <xref:System.Security.VerificationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Security.XmlSyntaxException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ServiceProcess.TimeoutException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Single?displayProperty=nameWithType> | |
| <xref:System.StackOverflowException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.String?displayProperty=nameWithType> | |
| <xref:System.StringComparer?displayProperty=nameWithType> | |
| <xref:System.SystemException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Text.DecoderFallbackException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Text.EncoderFallbackException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Text.RegularExpressions.RegexMatchTimeoutException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Text.StringBuilder?displayProperty=nameWithType> | |
| <xref:System.Threading.AbandonedMutexException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.BarrierPostPhaseException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.LockRecursionException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.SemaphoreFullException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.SynchronizationLockException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.Tasks.TaskCanceledException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.Tasks.TaskSchedulerException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.ThreadAbortException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.ThreadInterruptedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.ThreadStartException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.ThreadStateException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Threading.WaitHandleCannotBeOpenedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.TimeSpan?displayProperty=nameWithType> | |
| <xref:System.TimeZoneInfo.AdjustmentRule?displayProperty=nameWithType> | |
| <xref:System.TimeZoneInfo?displayProperty=nameWithType> | |
| <xref:System.TimeZoneNotFoundException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.TimeoutException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Transactions.TransactionAbortedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Transactions.TransactionException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Transactions.TransactionInDoubtException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Transactions.TransactionManagerCommunicationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Transactions.TransactionPromotionException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Tuple?displayProperty=nameWithType> | |
| <xref:System.TypeAccessException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.TypeInitializationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.TypeLoadException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.TypeUnloadedException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.UInt16?displayProperty=nameWithType> | |
| <xref:System.UInt32?displayProperty=nameWithType> | |
| <xref:System.UInt64?displayProperty=nameWithType> | |
| <xref:System.UIntPtr?displayProperty=nameWithType> | |
| <xref:System.UnauthorizedAccessException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Uri?displayProperty=nameWithType> | |
| <xref:System.UriFormatException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.ValueTuple?displayProperty=nameWithType> | Not serializable in .NET Framework 4.7 and earlier versions. |
| <xref:System.ValueType?displayProperty=nameWithType> | |
| <xref:System.Version?displayProperty=nameWithType> | |
| <xref:System.WeakReference%601?displayProperty=nameWithType> | |
| <xref:System.WeakReference?displayProperty=nameWithType> | |
| <xref:System.Xml.Schema.XmlSchemaException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Xml.Schema.XmlSchemaInferenceException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Xml.Schema.XmlSchemaValidationException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Xml.XPath.XPathException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Xml.XmlException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Xml.Xsl.XsltCompileException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |
| <xref:System.Xml.Xsl.XsltException?displayProperty=nameWithType> | Available in .NET Core 2.0.4 and later versions. |

## See also

- <xref:System.Runtime.Serialization>\
Contains classes that can be used for serializing and deserializing objects.

- [XML and SOAP Serialization](../../../docs/standard/serialization/xml-and-soap-serialization.md)\
Describes the XML serialization mechanism that is included with the common language runtime.

- [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md)\
Describes the secure coding guidelines to follow when writing code that performs serialization.

- [.NET Remoting](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/72x4h507(v=vs.100))\
Describes the various methods available in .NET Framework for remote communications.

- [XML Web Services Created Using ASP.NET and XML Web Service Clients](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/7bkzywba(v=vs.100))\
Articles that describe and explain how to program XML Web services created using ASP.NET.
