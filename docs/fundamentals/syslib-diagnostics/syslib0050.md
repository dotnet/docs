---
title: SYSLIB0050 warning - Formatter-based serialization is obsolete
description: Learn about the obsoletion of formatter-based serialization APIs that generates compile-time warning SYSLIB0050.
ms.date: 05/05/2023
---
# SYSLIB0050: Formatter-based serialization is obsolete

The following APIs are obsolete, starting in .NET 8. Calling them in code generates warning `SYSLIB0050` at compile time.

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

## Workaround

- If you were using <xref:System.Runtime.Serialization.FormatterServices.GetUninitializedObject(System.Type)?displayProperty=nameWithType>, use <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetUninitializedObject(System.Type)?displayProperty=nameWithType> instead.

  If you cross-compile for .NET Framework and modern .NET, you can use an `#if` statement to selectively call the appropriate API, as shown in the following snippet.

  ```csharp
  Type typeToInstantiate;
  #if NET5_0_OR_GREATER
  object obj = System.Runtime.CompilerServices.RuntimeHelpers.GetUninitializedObject(typeToInstantiate);
  #else
  object obj = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeToInstantiate);
  #endif
  ```

<a name="custom-exception"></a>

- If you created a custom type derived from <xref:System.Exception?displayProperty=fullName>, consider whether you really need it to be serializable. It's likely that you don't need it to be serializable, as exception serialization is primarily intended to support remoting, and support for remoting was dropped in .NET Core 1.0.

  If your custom exception type is defined like the one shown in the following code snippet, simply remove the `[Serializable]` attribute, the serialization constructor, and the <xref:System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> method override.

  ```csharp
  [Serializable] // Remove this attribute.
  public class MyException : Exception
  {
      public MyException() { }
      public MyException(string message) : base(message) { }
      public MyException(string message, Exception inner) : base(message, inner) { }

      // Remove this constructor.
      protected MyException(SerializationInfo info, StreamingContext context)
          : base(info, context)
      {
          // ...
      }

      // Remove this method.
      public override void GetObjectData(SerializationInfo info, StreamingContext context)
      {
          // ...

          base.GetObjectData(info, context);
      }
  }
  ```

  There might be cases where you can't remove these APIs from your custom exception type, for example, if you produce a library constrained by API compatibility requirements. In this case, the recommendation is to obsolete your own serialization constructor and `GetObjectData` methods using the `SYSLIB0051` diagnostic code, as shown in the following code. Since ideally nobody outside the serialization infrastructure itself should be calling these APIs, obsoletion should only impact other types that subclass your custom exception type. It should not virally impact anybody catching, constructing, or otherwise using your custom exception type.

  ```csharp
  [Serializable]
  public class MyException : Exception
  {
      public MyException() { }
      public MyException(string message) : base(message) { }
      public MyException(string message, Exception inner) : base(message, inner) { }

      [Obsolete(DiagnosticId = "SYSLIB0051")] // Add this attribute to the serialization ctor.
      protected MyException(SerializationInfo info, StreamingContext context)
          : base(info, context)
      {
          // ...
      }

      [Obsolete(DiagnosticId = "SYSLIB0051")] // Add this attribute to GetObjectData.
      public override void GetObjectData(SerializationInfo info, StreamingContext context)
      {
          // ...

          base.GetObjectData(info, context);
      }
  }
  ```

  If you cross-target for .NET Framework and .NET 8+, you can use an `#if` statement to apply the obsoletion conditionally. This is the same strategy that the .NET team uses within the .NET libraries code base when cross-targeting runtimes.

  ```csharp
  [Serializable]
  public class MyException : Exception
  {
      // ...

  #if NET8_0_OR_GREATER
      [Obsolete(DiagnosticId = "SYSLIB0051")] // add this attribute to the serialization ctor
  #endif
      protected MyException(SerializationInfo info, StreamingContext context)
          : base(info, context)
      {
          // ...
      }

  #if NET8_0_OR_GREATER
      [Obsolete(DiagnosticId = "SYSLIB0051")] // add this attribute to GetObjectData
  #endif
      public override void GetObjectData(SerializationInfo info, StreamingContext context)
      {
          // ...

          base.GetObjectData(info, context);
      }
  }

- If you're writing a serialization library, we strongly recommend against serialization libraries that support the legacy serialization infrastructure (`[Serializable]` and `ISerializable`). Modern serialization libraries should have policy based on a type's public APIs rather than its private implementation details. If you base a serializer on these implementation details and strongly tie it to `ISerializable` and other mechanisms that encourage embedding type names within the serialized payload, it can lead to the problems described in [Deserialization risks in use of BinaryFormatter and related types](../../standard/serialization/binaryformatter-security-guide.md).

  If your serialization library must remain compatible with the legacy serialization infrastructure, you can easily [suppress](#suppress-a-warning) the legacy serialization API obsoletions.

<PropertyGroup>
  <NoWarn>$(NoWarn);SYSLIB0050</NoWarn>
</PropertyGroup>

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0050

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0050
```

To suppress all the `SYSLIB0050` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0050</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [SYSLIB0051: Legacy serialization support APIs are obsolete](syslib0051.md)
