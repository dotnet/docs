### Handling corrupted state exceptions is not supported

Handling corrupted-process-state exceptions in .NET Core is not supported.

#### Change description

Previously, corrupted-process-state exceptions could be caught and handled by managed code exception handlers, for example, by using a [try-catch](../../../../docs/csharp/language-reference/statements/exception-handling-statements.md#the-try-catch-statement) statement in C#.

Starting in .NET Core 1.0, corrupted-process-state exceptions cannot be handled by managed code. The common language runtime doesn't deliver corrupted-process-state exceptions to managed code.

#### Version introduced

1.0

#### Recommended action

Avoid the need to handle corrupted-process-state exceptions by addressing the situations that lead to them instead. If it's absolutely necessary to handle corrupted-process-state exceptions, write the exception handler in C or C++ code.

#### Category

Core .NET libraries

#### Affected APIs

- <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute?displayProperty=fullName>
- [legacyCorruptedStateExceptionsPolicy element](~/docs/framework/configure-apps/file-schema/runtime/legacycorruptedstateexceptionspolicy-element.md)

<!--

#### Affected APIs

- `T:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute`

-->
