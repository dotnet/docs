---
title: "Binary serialization"
ms.date: "01/02/2018"
ms.prod: ".net"
ms.topic: "article"
helpviewer_keywords: 
  - "binary serialization"
  - "serialization, about serialization"
  - "deserialization"
  - "binary serialization, about serialization"
  - "binary serialization, .net core serialization"
  - "serialization, cross-framework"
ms.assetid: 2b1ea3be-1152-4032-b2b3-07794054c405
caps.latest.revision: 5
author: "ViktorHofer"
ms.author: "mairaw"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Binary serialization

Serialization can be defined as the process of storing the state of an object to a storage medium. During this process, the public and private fields of the object and the name of the class, including the assembly containing the class, are converted to a stream of bytes, which is then written to a data stream. When the object is subsequently deserialized, an exact clone of the original object is created.

When implementing a serialization mechanism in an object-oriented environment, you have to make a number of tradeoffs between ease of use and flexibility. The process can be automated to a large extent, provided you are given sufficient control over the process. For example, situations may arise where simple binary serialization is not sufficient, or there might be a specific reason to decide which fields in a class need to be serialized. The following sections examine the robust serialization mechanism provided with .NET and highlight a number of important features that allow you to customize the process to meet your needs.

> [!NOTE]
> The state of a UTF-8 or UTF-7 encoded object is not preserved if the object is serialized and deserialized using different .NET Framework versions.

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]

As the nature of binary serialization allows the modification of private members inside an object and therefore changing the state of it, other serialization frameworks like JSON.NET which operate on the public API surface are recommended.

## Binary serialization in .NET Core

.NET Core supports binary serialization with a subset of types. You can see the list of supported types in the [Serializable types section](#serializable-types). The defined set of types are guaranteed to be serializable between .NET Framework 4.5.1 and later versions and .NET Core 2.0 and later versions. Other .NET implementations, such as Mono, aren't officially supported but should also be working.

### Serializable types

- <xref:Microsoft.CSharp.RuntimeBinder.RuntimeBinderException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.AccessViolationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.AggregateException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.AppDomainUnloadedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ApplicationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ArgumentException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ArgumentNullException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ArgumentOutOfRangeException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ArithmeticException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Array?displayProperty=nameWithType>   
- <xref:System.ArraySegment%601?displayProperty=nameWithType>   
- <xref:System.ArrayTypeMismatchException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Attribute?displayProperty=nameWithType>
- <xref:System.BadImageFormatException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Boolean?displayProperty=nameWithType>   
- <xref:System.Byte?displayProperty=nameWithType>   
- <xref:System.CannotUnloadAppDomainException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Char?displayProperty=nameWithType>   
- <xref:System.Collections.ArrayList?displayProperty=nameWithType>   
- <xref:System.Collections.BitArray?displayProperty=nameWithType>   
- <xref:System.Collections.Comparer?displayProperty=nameWithType>   
- <xref:System.Collections.DictionaryEntry?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.Comparer%601?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.EqualityComparer%601?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.HashSet%601?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.KeyNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Collections.Generic.KeyValuePair%602?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.LinkedList%601?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.SortedList%602?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.SortedSet%601?displayProperty=nameWithType>   
- <xref:System.Collections.Generic.Stack%601?displayProperty=nameWithType>   
- <xref:System.Collections.Hashtable?displayProperty=nameWithType>   
- <xref:System.Collections.ObjectModel.Collection%601?displayProperty=nameWithType>   
- <xref:System.Collections.ObjectModel.KeyedCollection%602?displayProperty=nameWithType>   
- <xref:System.Collections.ObjectModel.ObservableCollection%601?displayProperty=nameWithType>   
- <xref:System.Collections.ObjectModel.ReadOnlyCollection%601?displayProperty=nameWithType>   
- <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602?displayProperty=nameWithType>   
- <xref:System.Collections.ObjectModel.ReadOnlyObservableCollection%601?displayProperty=nameWithType>   
- <xref:System.Collections.Queue?displayProperty=nameWithType>   
- <xref:System.Collections.SortedList?displayProperty=nameWithType>   
- <xref:System.Collections.Specialized.HybridDictionary?displayProperty=nameWithType>   
- <xref:System.Collections.Specialized.ListDictionary?displayProperty=nameWithType>   
- <xref:System.Collections.Specialized.OrderedDictionary?displayProperty=nameWithType>   
- <xref:System.Collections.Specialized.StringCollection?displayProperty=nameWithType>   
- <xref:System.Collections.Specialized.StringDictionary?displayProperty=nameWithType>   
- <xref:System.Collections.Stack?displayProperty=nameWithType>   
- `System.Collections.Generic.NonRandomizedStringEqualityComparer` <!--zz <xref:System.Collections.Generic.NonRandomizedStringEqualityComparer?displayProperty=nameWithType> --> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ComponentModel.BindingList%601?displayProperty=nameWithType>   
- <xref:System.ComponentModel.DataAnnotations.ValidationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ComponentModel.Design.CheckoutException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ComponentModel.InvalidAsynchronousStateException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ComponentModel.InvalidEnumArgumentException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ComponentModel.LicenseException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions, serialization from .NET Framework to .NET Core is not supported)
- <xref:System.ComponentModel.WarningException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ComponentModel.Win32Exception?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Configuration.ConfigurationErrorsException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Configuration.ConfigurationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Configuration.Provider.ProviderException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Configuration.SettingsPropertyIsReadOnlyException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Configuration.SettingsPropertyNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Configuration.SettingsPropertyWrongTypeException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ContextMarshalException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DBNull?displayProperty=nameWithType> (available in .NET Core 2.0.2 and later versions)   
- <xref:System.Data.Common.DbException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.ConstraintException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.DBConcurrencyException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.DataException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.DataSet?displayProperty=nameWithType>
- <xref:System.Data.DataTable?displayProperty=nameWithType> (unless you set RemotingFormat to SerializationFormat.Binary in which case it can only be exchanged with .NET Core 2.1 and later versions.)   
- <xref:System.Data.DeletedRowInaccessibleException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.DuplicateNameException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.EvaluateException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.InRowChangingEventException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.InvalidConstraintException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.InvalidExpressionException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.MissingPrimaryKeyException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.NoNullAllowedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.Odbc.OdbcException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.OperationAbortedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.PropertyCollection?displayProperty=nameWithType>   
- <xref:System.Data.ReadOnlyException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.RowNotInTableException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.SqlClient.SqlException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions, serialization from .NET Framework to .NET Core is not supported)
- <xref:System.Data.SqlTypes.SqlAlreadyFilledException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.SqlTypes.SqlBoolean?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlByte?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlDateTime?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlDouble?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlGuid?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlInt16?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlInt32?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlInt64?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlNotFilledException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.SqlTypes.SqlNullValueException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.SqlTypes.SqlString?displayProperty=nameWithType>   
- <xref:System.Data.SqlTypes.SqlTruncateException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.SqlTypes.SqlTypeException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.StrongTypingException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.SyntaxErrorException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Data.VersionNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DataMisalignedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DateTime?displayProperty=nameWithType>   
- <xref:System.DateTimeOffset?displayProperty=nameWithType>   
- <xref:System.Decimal?displayProperty=nameWithType>   
- `System.Diagnostics.Contracts.ContractException` <!--zz <xref:System.Diagnostics.Contracts.ContractException?displayProperty=nameWithType> --> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Diagnostics.Tracing.EventSourceException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.DirectoryNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.AccountManagement.MultipleMatchesException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.AccountManagement.NoMatchingPrincipalException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.AccountManagement.PasswordException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.AccountManagement.PrincipalException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.AccountManagement.PrincipalExistsException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.AccountManagement.PrincipalOperationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.AccountManagement.PrincipalServerDownException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectExistsException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.ActiveDirectory.ActiveDirectoryServerDownException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.ActiveDirectory.ForestTrustCollisionException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.DirectoryServicesCOMException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.Protocols.BerConversionException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.Protocols.DirectoryException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.Protocols.DirectoryOperationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.Protocols.LdapException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DirectoryServices.Protocols.TlsOperationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DivideByZeroException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.DllNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Double?displayProperty=nameWithType>   
- <xref:System.Drawing.Color?displayProperty=nameWithType>   
- <xref:System.Drawing.Point?displayProperty=nameWithType>   
- <xref:System.Drawing.PointF?displayProperty=nameWithType>   
- <xref:System.Drawing.Rectangle?displayProperty=nameWithType>   
- <xref:System.Drawing.RectangleF?displayProperty=nameWithType>   
- <xref:System.Drawing.Size?displayProperty=nameWithType>   
- <xref:System.Drawing.SizeF?displayProperty=nameWithType>   
- <xref:System.DuplicateWaitObjectException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.EntryPointNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Enum?displayProperty=nameWithType>   
- <xref:System.EventArgs?displayProperty=nameWithType> (available in .NET Core 2.0.6 and later versions)
- <xref:System.Exception?displayProperty=nameWithType>   
- <xref:System.ExecutionEngineException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.FieldAccessException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.FormatException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Globalization.CompareInfo?displayProperty=nameWithType>   
- <xref:System.Globalization.CultureNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Globalization.SortVersion?displayProperty=nameWithType>   
- <xref:System.Guid?displayProperty=nameWithType>   
- `System.IO.Compression.ZLibException` <!--zz <xref:System.IO.Compression.ZLibException?displayProperty=nameWithType --> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.DriveNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.EndOfStreamException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.FileFormatException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.FileLoadException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.FileNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.IOException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.InternalBufferOverflowException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.InvalidDataException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.IsolatedStorage.IsolatedStorageException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IO.PathTooLongException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.IndexOutOfRangeException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.InsufficientExecutionStackException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.InsufficientMemoryException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Int16?displayProperty=nameWithType>   
- <xref:System.Int32?displayProperty=nameWithType>   
- <xref:System.Int64?displayProperty=nameWithType>   
- <xref:System.IntPtr?displayProperty=nameWithType>   
- <xref:System.InvalidCastException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.InvalidOperationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.InvalidProgramException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.InvalidTimeZoneException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.MemberAccessException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.MethodAccessException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.MissingFieldException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.MissingMemberException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.MissingMethodException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.MulticastNotSupportedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.Cookie?displayProperty=nameWithType>   
- <xref:System.Net.CookieCollection?displayProperty=nameWithType>   
- <xref:System.Net.CookieContainer?displayProperty=nameWithType>   
- <xref:System.Net.CookieException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.HttpListenerException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.Mail.SmtpException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.Mail.SmtpFailedRecipientException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.Mail.SmtpFailedRecipientsException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.NetworkInformation.NetworkInformationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.NetworkInformation.PingException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.ProtocolViolationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.Sockets.SocketException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.WebException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Net.WebSockets.WebSocketException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.NotFiniteNumberException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.NotImplementedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.NotSupportedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.NullReferenceException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Nullable%601?displayProperty=nameWithType>   
- <xref:System.Numerics.BigInteger?displayProperty=nameWithType>   
- <xref:System.Numerics.Complex?displayProperty=nameWithType>   
- <xref:System.Object?displayProperty=nameWithType>   
- <xref:System.ObjectDisposedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.OperationCanceledException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.OutOfMemoryException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.OverflowException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.PlatformNotSupportedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.RankException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Reflection.AmbiguousMatchException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Reflection.CustomAttributeFormatException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Reflection.InvalidFilterCriteriaException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Reflection.ReflectionTypeLoadException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions, serialization from .NET Framework to .NET Core is not supported)
- <xref:System.Reflection.TargetException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Reflection.TargetInvocationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Reflection.TargetParameterCountException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Resources.MissingManifestResourceException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Resources.MissingSatelliteAssemblyException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.CompilerServices.RuntimeWrappedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.COMException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.ExternalException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.InvalidComObjectException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.InvalidOleVariantTypeException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.MarshalDirectiveException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.SEHException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.SafeArrayRankMismatchException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.InteropServices.SafeArrayTypeMismatchException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.Serialization.InvalidDataContractException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Runtime.Serialization.SerializationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.SByte?displayProperty=nameWithType>   
- <xref:System.Security.AccessControl.PrivilegeNotHeldException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.Authentication.AuthenticationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.Authentication.InvalidCredentialException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.Cryptography.CryptographicException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.Cryptography.CryptographicUnexpectedOperationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- `System.Security.Cryptography.Xml.CryptoSignedXmlRecursionException` <!--zz <xref:System.Security.Cryptography.Xml.CryptoSignedXmlRecursionException?displayProperty=nameWithType --> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.HostProtectionException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.Policy.PolicyException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.Principal.IdentityNotMappedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.SecurityException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions, limited serialization data)
- <xref:System.Security.VerificationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Security.XmlSyntaxException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ServiceProcess.TimeoutException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Single?displayProperty=nameWithType>   
- <xref:System.StackOverflowException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.String?displayProperty=nameWithType>   
- <xref:System.StringComparer?displayProperty=nameWithType>   
- <xref:System.SystemException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Text.DecoderFallbackException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Text.EncoderFallbackException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Text.RegularExpressions.RegexMatchTimeoutException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Text.StringBuilder?displayProperty=nameWithType>   
- <xref:System.Threading.AbandonedMutexException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.BarrierPostPhaseException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.LockRecursionException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.SemaphoreFullException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.SynchronizationLockException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.Tasks.TaskCanceledException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.Tasks.TaskSchedulerException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.ThreadAbortException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.ThreadInterruptedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.ThreadStartException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.ThreadStateException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Threading.WaitHandleCannotBeOpenedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.TimeSpan?displayProperty=nameWithType>   
- <xref:System.TimeZoneInfo.AdjustmentRule?displayProperty=nameWithType>   
- <xref:System.TimeZoneInfo?displayProperty=nameWithType>   
- <xref:System.TimeZoneNotFoundException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.TimeoutException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Transactions.TransactionAbortedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Transactions.TransactionException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Transactions.TransactionInDoubtException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Transactions.TransactionManagerCommunicationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Transactions.TransactionPromotionException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Tuple?displayProperty=nameWithType>   
- <xref:System.TypeAccessException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.TypeInitializationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.TypeLoadException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.TypeUnloadedException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.UInt16?displayProperty=nameWithType>   
- <xref:System.UInt32?displayProperty=nameWithType>   
- <xref:System.UInt64?displayProperty=nameWithType>   
- <xref:System.UIntPtr?displayProperty=nameWithType>   
- <xref:System.UnauthorizedAccessException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Uri?displayProperty=nameWithType>   
- <xref:System.UriFormatException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.ValueTuple?displayProperty=nameWithType> (not serializable in .NET Framework 4.7 and earlier versions)  
- <xref:System.ValueType?displayProperty=nameWithType>   
- <xref:System.Version?displayProperty=nameWithType>   
- <xref:System.WeakReference%601?displayProperty=nameWithType>   
- <xref:System.WeakReference?displayProperty=nameWithType>   
- <xref:System.Xml.Schema.XmlSchemaException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Xml.Schema.XmlSchemaInferenceException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Xml.Schema.XmlSchemaValidationException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Xml.XPath.XPathException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Xml.XmlException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Xml.Xsl.XsltCompileException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)
- <xref:System.Xml.Xsl.XsltException?displayProperty=nameWithType> (available in .NET Core 2.0.4 and later versions)

## In this section

 [Serialization Concepts](../../../docs/standard/serialization/serialization-concepts.md)  
 Discusses two scenarios where serialization is useful: when persisting data to storage and when passing objects across application domains.  
  
 [Basic Serialization](../../../docs/standard/serialization/basic-serialization.md)  
 Describes how to use the binary and SOAP formatters to serialize objects.  
  
 [Selective Serialization](../../../docs/standard/serialization/selective-serialization.md)  
 Describes how to prevent some members of a class from being serialized.  
  
 [Custom Serialization](../../../docs/standard/serialization/custom-serialization.md)  
 Describes how to customize serialization for a class by using the <xref:System.Runtime.Serialization.ISerializable> interface.  
  
 [Steps in the Serialization Process](../../../docs/standard/serialization/steps-in-the-serialization-process.md)  
 Describes the course of action serialization takes when the <xref:System.Runtime.Serialization.Formatter.Serialize%2A> method is called on a formatter.  
  
 [Version Tolerant Serialization](../../../docs/standard/serialization/version-tolerant-serialization.md)  
 Explains how to create serializable types that can be modified over time without causing applications to throw exceptions.  
  
 [Serialization Guidelines](../../../docs/standard/serialization/serialization-guidelines.md)  
 Provides some general guidelines for deciding when to serialize an object.  
  
## Reference  
 <xref:System.Runtime.Serialization>  
 Contains classes that can be used for serializing and deserializing objects.  
  
## Related sections  
 [XML and SOAP Serialization](../../../docs/standard/serialization/xml-and-soap-serialization.md)  
 Describes the XML serialization mechanism that is included with the common language runtime.  
  
 [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md)  
 Describes the secure coding guidelines to follow when writing code that performs serialization.  
  
 [Remote Objects](https://msdn.microsoft.com/library/515686e6-0a8d-42f7-8188-73abede57c58)  
 Describes the various communications methods available in the .NET Framework for remote communications.  
  
 [XML Web Services Created Using ASP.NET and XML Web Service Clients](https://msdn.microsoft.com/library/1e64af78-d705-4384-b08d-591a45f4379c)  
 Provides topics that describe and explain how to program XML Web services created using ASP.NET.
