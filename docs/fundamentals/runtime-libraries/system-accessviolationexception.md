---
title: System.AccessViolationException class
description: Learn about the System.AccessViolationException class.
ms.date: 05/28/2025
---
# System.AccessViolationException class

[!INCLUDE [context](includes/context.md)]

An access violation occurs in unmanaged or unsafe code when the code attempts to read or write to memory that has not been allocated, or to which it does not have access. This usually occurs because a pointer has a bad value. Not all reads or writes through bad pointers lead to access violations, so an access violation usually indicates that several reads or writes have occurred through bad pointers, and that memory might be corrupted. Thus, access violations almost always indicate serious programming errors. An <xref:System.AccessViolationException> clearly identifies these serious errors.

In programs that consist entirely of verifiable managed code, all references are either valid or null, and access violations are impossible. Any operation that attempts to reference a null reference in verifiable code throws a <xref:System.NullReferenceException> exception. An <xref:System.AccessViolationException> occurs only when verifiable managed code interacts with unmanaged code or with unsafe managed code.

## Troubleshoot AccessViolationException exceptions

An <xref:System.AccessViolationException> exception can occur only in unsafe managed code or when verifiable managed code interacts with unmanaged code:

- An access violation that occurs in unsafe managed code can be expressed as either a <xref:System.NullReferenceException> exception or an <xref:System.AccessViolationException> exception, depending on the platform.
- An access violation in unmanaged code that bubbles up to managed code is always wrapped in an <xref:System.AccessViolationException> exception.

In either case, you can identify and correct the cause of the <xref:System.AccessViolationException> exception as follows:

- Make sure that the memory that you're attempting to access has been allocated. An <xref:System.AccessViolationException> exception is always thrown by an attempt to access protected memory&mdash;that is, to access memory that's not allocated or that's not owned by a process.

  Automatic memory management is one of the services that the .NET runtime provides. If managed code provides the same functionality as your unmanaged code, consider moving to managed code to take advantage of this functionality. For more information, see [Automatic memory management](../../standard/automatic-memory-management.md).

- Make sure that the memory that you're attempting to access hasn't been corrupted. If several read or write operations have occurred through bad pointers, memory might be corrupted. This typically occurs when reading or writing to addresses outside of a predefined buffer.

## AccessViolationException and try/catch blocks

<xref:System.AccessViolationException> exceptions thrown by the .NET runtime aren't handled by the `catch` statement in a structured exception handler if the exception occurs outside of the memory reserved by the runtime.

**.NET Framework only**

To handle such an <xref:System.AccessViolationException> exception, apply the <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute> attribute to the method in which the exception is thrown. This change does not affect <xref:System.AccessViolationException> exceptions thrown by user code, which can continue to be caught by a `catch` statement.

> [!CAUTION]
> The [HandleProcessCorruptedStateExceptions attribute](xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute) is obsolete in current .NET versions, and the attribute, if present, is ignored.
