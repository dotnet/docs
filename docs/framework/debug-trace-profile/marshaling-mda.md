---
title: "marshaling MDA"
description: Review the marshaling managed debugging assistant (MDA), which is invoked if the CLR sets up marshalling information for a method parameter or a structure field.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "marshalling, run-time errors"
  - "marshaling MDA"
  - "managed debugging assistants (MDAs), marshaling"
  - "MDAs (managed debugging assistants), marshaling"
ms.assetid: 5433b1f8-b0e5-40c9-a49a-0e5bd213363d
---
# marshaling MDA

[!INCLUDE [net-framework-specific](../includes/net-framework-specific.md)]

The `marshaling` managed debugging assistant (MDA) is activated when the CLR sets up marshalling information for a method parameter or a field of a structure. This MDA does not work for JIT-compiled assemblies.

## Effect on the Runtime

This MDA has no effect on the CLR.

## Output

The MDA displays the type of the parameter or field in the managed and unmanaged contexts, and the structure or method containing the type. The following is an example of the output for a field:

```output
Marshaling from 'Char' to 'ANSI char'
name="assembly!Namespace.Class::myChar
```

## Configuration

The MDA configuration allows you to filter the reported marshalling information based on the involved field or method names. The following example shows the use of the `methodFilter`, `fieldFilter`, and `match` elements to specify filters. Setting the `name` attribute to an asterisk (\*) will match everything.

```xml
<mdaConfig>
  <assistants>
    <marshaling>
      <methodFilter>
        <match name="Method1"/>
        <match name="Method2"/>
      </methodFilter>
      <fieldFilter>
        <match name="Field1"/>
        <match name="Field2"/>
       </fieldFilter>
    </marshaling>
  </assistants>
</mdaConfig>
```

## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshalling](../interop/interop-marshalling.md)
