---
title: System.Security.SecureString class
description: Learn about the System.Security.SecureString class.
ms.date: 12/31/2023
---
# System.Security.SecureString class

> [!IMPORTANT]
> We recommend that you don't use the `SecureString` class for new development on .NET (Core) or when you migrate existing code to .NET (Core). For more information, see [SecureString shouldn't be used](https://github.com/dotnet/platform-compat/blob/master/docs/DE0001.md).

[!INCLUDE [context](includes/context.md)]

<xref:System.Security.SecureString> is a string type that provides a measure of security. It tries to avoid storing potentially sensitive strings in process memory as plain text. (For limitations, however, see the [How secure is SecureString?](#how-secure-is-securestring) section.) The value of an instance of <xref:System.Security.SecureString> is automatically protected using a mechanism supported by the underlying platform when the instance is initialized or when the value is modified. Your application can render the instance immutable and prevent further modification by invoking the <xref:System.Security.SecureString.MakeReadOnly%2A> method.

The maximum length of a <xref:System.Security.SecureString> instance is 65,536 characters.

> [!IMPORTANT]
> This type implements the <xref:System.IDisposable> interface. When you have finished using an instance of the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its <xref:System.IDisposable.Dispose%2A> method in a `try`/`catch` block. To dispose of it indirectly, use a language construct such as `using` (in C#) or `Using` (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the <xref:System.IDisposable> interface topic.

The <xref:System.Security.SecureString> class and its members are not visible to COM. For more information, see <xref:System.Runtime.InteropServices.ComVisibleAttribute>.

## String versus SecureString

An instance of the <xref:System.String?displayProperty=nameWithType> class is both immutable and, when no longer needed, cannot be programmatically scheduled for garbage collection; that is, the instance is read-only after it is created, and it is not possible to predict when the instance will be deleted from computer memory. Because <xref:System.String?displayProperty=nameWithType> instances are immutable, operations that appear to modify an existing instance actually create a copy of it to manipulate. Consequently, if a <xref:System.String> object contains sensitive information such as a password, credit card number, or personal data, there is a risk the information could be revealed after it is used because your application cannot delete the data from computer memory.

A <xref:System.Security.SecureString> object is similar to a <xref:System.String> object in that it has a text value. However, the value of a <xref:System.Security.SecureString> object is pinned in memory, may use a protection mechanism, such as encryption, provided by the underlying operating system, can be modified until your application marks it as read-only, and can be deleted from computer memory either by your application calling the <xref:System.Security.SecureString.Dispose%2A> method or by the .NET garbage collector.

For a discussion of the limitations of the <xref:System.Security.SecureString> class, see the [How secure is SecureString?](#how-secure-is-securestring) section.

## SecureString operations

The <xref:System.Security.SecureString> class includes members that allow you to do the following:

Instantiate a <xref:System.Security.SecureString> object
You instantiate a <xref:System.Security.SecureString> object by calling its parameterless constructor.

Add characters to a <xref:System.Security.SecureString> object
You can add a single character at a time to a <xref:System.Security.SecureString> object by calling its <xref:System.Security.SecureString.AppendChar%2A> or <xref:System.Security.SecureString.InsertAt%2A> method.

> [!IMPORTANT]
> A <xref:System.Security.SecureString> object should never be constructed from a <xref:System.String>, because the sensitive data is already subject to the memory persistence consequences of the immutable <xref:System.String> class. The best way to construct a <xref:System.Security.SecureString> object is from a character-at-a-time unmanaged source, such as the <xref:System.Console.ReadKey%2A?displayProperty=nameWithType> method.

Remove characters from a <xref:System.Security.SecureString> object
You can replace an individual character by calling the <xref:System.Security.SecureString.SetAt%2A> method, remove an individual character by calling the <xref:System.Security.SecureString.RemoveAt%2A> method, or remove all characters from the <xref:System.Security.SecureString> instance by calling the  <xref:System.Security.SecureString.Clear%2A> method.

Make the <xref:System.Security.SecureString> object read-only
Once you have defined the string that the <xref:System.Security.SecureString> object represents, you call its <xref:System.Security.SecureString.MakeReadOnly%2A> method to make the string read-only.

Get information about the <xref:System.Security.SecureString> object
The <xref:System.Security.SecureString> class has only two members that provide information about the string: its <xref:System.Security.SecureString.Length> property, which indicates the number of UTF16-encoded code units in the string; and the <xref:System.Security.SecureString.IsReadOnly%2A>, method, which indicates whether the instance is read-only.

Release the memory allocated to the <xref:System.Security.SecureString> instance
Because <xref:System.Security.SecureString> implements the <xref:System.IDisposable> interface, you release its memory by calling the <xref:System.Security.SecureString.Dispose%2A> method.

The <xref:System.Security.SecureString> class has no members that inspect, compare, or convert the value of a <xref:System.Security.SecureString>. The absence of such members helps protect the value of the instance from accidental or malicious exposure. Use appropriate members of the <xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType> class, such as the <xref:System.Runtime.InteropServices.Marshal.SecureStringToBSTR%2A> method, to manipulate the value of a <xref:System.Security.SecureString> object.

The .NET Class Library commonly uses <xref:System.Security.SecureString> instances in the following ways:

- To provide password information to a process by using the <xref:System.Diagnostics.ProcessStartInfo> structure or by calling an overload of the <xref:System.Diagnostics.Process.Start%2A?displayProperty=nameWithType> method that has a parameter of type <xref:System.Security.SecureString>.

- To provide network password information by calling a <xref:System.Net.NetworkCredential> class constructor that has a parameter of type <xref:System.Security.SecureString> or by using the <xref:System.Net.NetworkCredential.SecurePassword?displayProperty=nameWithType> property.

- To provide password information for SQL Server Authentication by calling the <xref:System.Data.SqlClient.SqlCredential.%23ctor%2A?displayProperty=nameWithType> constructor or retrieving the value of the <xref:System.Data.SqlClient.SqlCredential.Password?displayProperty=nameWithType> property.

- To pass a string to unmanaged code. For more information, see the [SecureString and interop](#securestring-and-interop) section.

## SecureString and interop

Because the operating system does not directly support <xref:System.Security.SecureString>, you must convert the value of the <xref:System.Security.SecureString> object to the required string type before passing the string to a native method. The <xref:System.Runtime.InteropServices.Marshal> class has five methods that do this:

- <xref:System.Runtime.InteropServices.Marshal.SecureStringToBSTR%2A?displayProperty=nameWithType>, which converts the <xref:System.Security.SecureString> string value to a binary string (BSTR) recognized by COM.

- <xref:System.Runtime.InteropServices.Marshal.SecureStringToCoTaskMemAnsi%2A?displayProperty=nameWithType> and <xref:System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocAnsi%2A?displayProperty=nameWithType>, which copy the <xref:System.Security.SecureString> string value to an ANSI string in unmanaged memory.

- <xref:System.Runtime.InteropServices.Marshal.SecureStringToCoTaskMemUnicode%2A?displayProperty=nameWithType> and <xref:System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode%2A?displayProperty=nameWithType>, which copy the <xref:System.Security.SecureString> string value to a Unicode string in unmanaged memory.

Each of these methods creates a clear-text string in unmanaged memory. It is the responsibility of the developer to zero out and free that memory as soon as it is no longer needed. Each of the string conversion and memory allocation methods has a corresponding method to zero out and free the allocated memory:

|Allocation and conversion method|Zero and free method|
|--------------------------------------|--------------------------|
|<xref:System.Runtime.InteropServices.Marshal.SecureStringToBSTR%2A?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ZeroFreeBSTR%2A?displayProperty=nameWithType>|
|<xref:System.Runtime.InteropServices.Marshal.SecureStringToCoTaskMemAnsi%2A?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ZeroFreeCoTaskMemAnsi%2A?displayProperty=nameWithType>|
|<xref:System.Runtime.InteropServices.Marshal.SecureStringToCoTaskMemUnicode%2A?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ZeroFreeCoTaskMemUnicode%2A?displayProperty=nameWithType>|
|<xref:System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocAnsi%2A?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocAnsi%2A?displayProperty=nameWithType>|
|<xref:System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode%2A?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode%2A?displayProperty=nameWithType>|

## How secure is SecureString?

When created properly, a <xref:System.Security.SecureString> instance provides more data protection than a <xref:System.String>. When creating a string from a character-at-a-time source, <xref:System.String> creates multiple intermediate in memory, whereas  <xref:System.Security.SecureString> creates just a single instance. Garbage collection of <xref:System.String> objects is non-deterministic. In addition, because its memory is not pinned, the garbage collector will make additional copies of <xref:System.String> values when moving and compacting memory. In contrast, the memory allocated to a <xref:System.Security.SecureString> object is pinned,  and that memory can be freed by calling the <xref:System.Security.SecureString.Dispose%2A> method.

Although data stored in a <xref:System.Security.SecureString> instance is more secure than data stored in a <xref:System.String> instance, there are significant limitations on how secure a <xref:System.Security.SecureString> instance is. These include:

Platform

On the Windows operating system, the contents of a <xref:System.Security.SecureString> instance's internal character array are encrypted. However, whether because of missing APIs or key management issues,  encryption is not available on all platforms. Because of this platform dependency, <xref:System.Security.SecureString> does not encrypt the internal storage on non-Windows platform. Other techniques are used on those platforms to provide additional protection.

Duration

Even if the <xref:System.Security.SecureString> implementation is able to take advantage of encryption, the plain text assigned to the <xref:System.Security.SecureString> instance may be exposed at various times:

- Because Windows doesn't offer a secure string implementation at the operating system level, .NET still has to convert the secure string value to its plain text representation in order to use it.

- Whenever the value of the secure string is modified by methods such as <xref:System.Security.SecureString.AppendChar%2A> or <xref:System.Security.SecureString.RemoveAt%2A>, it must be decrypted (that is, converted back to plain text), modified, and then encrypted again.

- If the secure string is used in an interop call, it must be converted to an ANSI string, a Unicode string, or a binary string (BSTR). For more information, see the [SecureString and interop](#securestring-and-interop) section.

The time interval for which the <xref:System.Security.SecureString> instance's value is exposed is merely shortened in comparison to the <xref:System.String> class.

Storage versus usage
More generally, the <xref:System.Security.SecureString> class defines a storage mechanism for string values that should be protected or kept confidential. However, outside of .NET itself, no usage mechanism supports <xref:System.Security.SecureString>. This means that the secure string must be converted to a usable form (typically a clear text form) that can be recognized by its target, and     that decryption and conversion must occur in user space.

Overall, <xref:System.Security.SecureString> is more secure than <xref:System.String> because it limits the exposure of sensitive string data. However, those strings may still be exposed to any process or operation that has access to raw memory, such as a malicious process running on the host computer, a process dump, or a user-viewable swap file. Instead of using <xref:System.Security.SecureString> to protect passwords, the recommended alternative is to use an opaque handle to credentials that are stored outside of the process.
