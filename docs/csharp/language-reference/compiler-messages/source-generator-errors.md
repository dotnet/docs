---
title: Errors and warnings associated with source generators and interceptors
description: You might see these errors and warnings when code is compiled with source generators and interceptors. They indicate some condition where the compiler can't run the source generator, or the generate code isn't compilable.
f1_keywords:
  - "CS9137"
  - "CS9138"
  - "CS9139"
  - "CS9140"
  - "CS9141"
  - "CS9142"
  - "CS9143"
  - "CS9144"
  - "CS9145"
  - "CS9146"
  - "CS9147"
  - "CS9148"
  - "CS9149"
  - "CS9150"
  - "CS9151"
  - "CS9152"
  - "CS9153"
  - "CS9154"
  - "CS9155"
  - "CS9156"
  - "CS9157"
  - "CS9158"
  - "CS9159"
  - "CS9160"
  - "CS9161"
  - "CS9177"
  - "CS9178"
  - "CS9206"
  - "CS9207"
  - "CS9270"
helpviewer_keywords:
  - "CS9137"
  - "CS9138"
  - "CS9139"
  - "CS9140"
  - "CS9141"
  - "CS9142"
  - "CS9143"
  - "CS9144"
  - "CS9145"
  - "CS9146"
  - "CS9147"
  - "CS9148"
  - "CS9149"
  - "CS9150"
  - "CS9151"
  - "CS9152"
  - "CS9153"
  - "CS9154"
  - "CS9155"
  - "CS9156"
  - "CS9157"
  - "CS9158"
  - "CS9159"
  - "CS9160"
  - "CS9161"
  - "CS9177"
  - "CS9178"
  - "CS9206"
  - "CS9207"
  - "CS9270"
ms.date: 05/23/2025
---
# Errors and warnings associated with source generators and interceptors

The following errors are generated when source generators or interceptors are loaded during a compilation:

- [**CS9137**](#interceptors-are-experimental): *The 'interceptors' experimental feature is not enabled. Add `<Features>InterceptorsPreview<Features>` to your project.*
- [**CS9138**](#other-failures): *Method cannot be used as an interceptor because it or its containing type has type parameters.*
- [**CS9139**](#incorrect-mapping): *Cannot intercept: compilation does not contain a file with path.*
- [**CS9140**](#incorrect-mapping): *Cannot intercept: compilation does not contain a file with path. Did you mean to use a different path?*
- [**CS9141**](#incorrect-mapping): *The provided line and character number does not refer to an interceptable method name, but rather to a token.*
- [**CS9142**](#incorrect-mapping): *The given file has `n` lines, which is fewer than the provided line number `m`.*
- [**CS9143**](#incorrect-mapping): *The given line is `c` characters long, which is fewer than the provided character number `n`.*
- [**CS9144**](#signature-mismatch): *Cannot intercept method `M` with interceptor `V` because the signatures do not match.*
- [**CS9145**](#incorrect-mapping): *Cannot intercept: Path is unmapped. Expected mapped path.*
- [**CS9146**](#other-failures): *An interceptor method must be an ordinary member method.*
- [**CS9147**](#incorrect-mapping): *The provided line and character number does not refer to the start of a token. Did you mean to use line `n` and character `c`?*
- [**CS9148**](#signature-mismatch): *Interceptor must have a `this` parameter matching parameter.*
- [**CS9149**](#signature-mismatch): *Interceptor must not have a `this` parameter because method does not have a `this` parameter.*
- [**CS9150**](#incorrect-mapping): *Interceptor cannot have a `null` file path.*
- [**CS9151**](#other-failures): *Possible method name `M` cannot be intercepted because it is not being invoked.*
- [**CS9152**](#other-failures): *Cannot intercept a call in file with this path because multiple files in the compilation have this path.*
- [**CS9153**](#other-failures): *The indicated call is intercepted multiple times.*
- [**CS9155**](#signature-mismatch): *Cannot intercept call with `M` because it is not accessible within `V`.*
- [**CS9156**](#signature-mismatch): *Cannot intercept call to `M` with `V` because of a difference in 'scoped' modifiers or `[UnscopedRef]` attributes.*
- [**CS9157**](#incorrect-mapping): *Line and character numbers provided to `InterceptsLocationAttribute` must be positive.*
- [**CS9160**](#other-failures): *A nameof operator cannot be intercepted.*
- [**CS9161**](#other-failures): *An interceptor cannot be marked with `UnmanagedCallersOnlyAttribute`.*
- [**CS9177**](#signature-mismatch): *Interceptor must be non-generic or have matching arity.*
- [**CS9178**](#signature-mismatch): *Method must be non-generic to match*
- [**CS9206**](#other-failures): *An interceptor cannot be declared in the global namespace.*
- [**CS9207**](#other-failures): *Cannot intercept because method is not an invocation of an ordinary member method.*

The following warnings are  generated when source generators or interceptors are loaded during a compilation:

- [**CS9154**](#signature-mismatch): *Intercepting a call to `M` with interceptor `V`, but the signatures do not match.*
- [**CS9158**](#signature-mismatch): *Nullability of reference types in return type doesn't match interceptable method.*
- [**CS9159**](#signature-mismatch): *Nullability of reference types in type of parameter doesn't match interceptable method.*
- [**CS9270**](#signature-mismatch): *'`InterceptsLocationAttribute(string, int, int)`' is not supported. Move to 'InterceptableLocation'-based generation of these attributes instead. [(https://github.com/dotnet/roslyn/issues/72133)](https://github.com/dotnet/roslyn/issues/72133)*

These errors and warnings follow these themes:

## Interceptors are experimental

This error indicates you must enable the experimental feature.

- **CS9137**: *The 'interceptors' experimental feature is not enabled. Add `<Features>InterceptorsPreview<Features>` to your project.*

In C# 12, interceptors are experimental. Interceptors are subject to breaking changes or removal in a future release. Therefore, it is not recommended for production or released applications.

In order to use interceptors, you must set the `<Features>InterceptorsPreview<Features>` element in your project file. Without this flag, interceptors are disabled, even when other C# 12 features are enabled.

## Signature mismatch

The following errors indicate a mismatch between the interceptor method and the interceptable method, or a violation of the rules regarding interceptor method declarations:

- **CS9144**: *Cannot intercept method `M` with interceptor `V` because the signatures do not match.*
- **CS9148**: *Interceptor must have a `this` parameter matching parameter.*
- **CS9149**: *Interceptor must not have a `this` parameter because method does not have a `this` parameter.*
- **CS9155**: *Cannot intercept call with `M` because it is not accessible within `V`.*
- **CS9156**: *Cannot intercept call to `M` with `V` because of a difference in 'scoped' modifiers or `[UnscopedRef]` attributes.*
- **CS9177**]: *Interceptor must be non-generic or have matching arity.*
- **CS9178**: *Method must be non-generic to match*

In addition, the following warnings indicate a mismatch in the signatures of the interceptor and the interceptable method:

- **CS9154**: *Intercepting a call to `M` with interceptor `V`, but the signatures do not match.*
- **CS9158**: *Nullability of reference types in return type doesn't match interceptable method.*
- **CS9159**: *Nullability of reference types in type of parameter doesn't match interceptable method.*
- **CS9270**: *'`InterceptsLocationAttribute(string, int, int)`' is not supported. Move to 'InterceptableLocation'-based generation of these attributes instead. [(https://github.com/dotnet/roslyn/issues/72133)](https://github.com/dotnet/roslyn/issues/72133)*

The interceptor method must be compatible with the interceptable method. You must follow these rules:

- Instance methods can intercept instance methods, not static methods. Similarly, static methods can only intercept static methods, not instance methods.
- The method signatures for the interceptor and the interceptable method must match: They must have the same parameters with the same modifiers in the same order. The return types must also match.
- The ref safe contexts must match. In other words, corresponding `ref` parameters must be either `scoped` or not `scoped`.
- They methods must both be non-generic, or both must have the same number of type parameters.
- An updated `InterceptorLocationAttribute` constructor signature is preferred.

## Incorrect mapping

Interceptors require a source mapping that maps the interceptable method and the interceptor method. The following errors indicate an issue with the mapping:

- **CS9139**: *Cannot intercept: compilation does not contain a file with path.*
- **CS9140**: *Cannot intercept: compilation does not contain a file with path. Did you mean to use a different path?*
- **CS9141**: *The provided line and character number does not refer to an interceptable method name, but rather to a token.*
- **CS9142**: *The given file has `n` lines, which is fewer than the provided line number `m`.*
- **CS9143**: *The given line is `c` characters long, which is fewer than the provided character number `n`.*
- **CS9145**: *Cannot intercept: Path is unmapped. Expected mapped path.*
- **CS9147**: *The provided line and character number does not refer to the start of a token. Did you mean to use line `n` and character `c`?*
- **CS9150**: *Interceptor cannot have a `null` file path.*
- **CS9157**: *Line and character numbers provided to `InterceptsLocationAttribute` must be positive.*

An interceptor specifies the location in the source code of the interceptable method. You specify the location by applying an `[InterceptsLocation]` attribute. You specify the line and column numbers in a remapped source file where the interceptor should be injected.  These errors indicate that something in the attribute or the location doesn't match a location for a valid interceptable method. For details on the format and values for this attribute, see the [feature specification](https://github.com/dotnet/roslyn/blob/main/docs/features/interceptors.md#interceptslocationattribute).

## Other failures

These errors indicate other limitations for interceptors:

- **CS9138**: *Method cannot be used as an interceptor because it or its containing type has type parameters.*
- **CS9146**: *An interceptor method must be an ordinary member method.*
- **CS9151**: *Possible method name `M` cannot be intercepted because it is not being invoked.*
- **CS9152**: *Cannot intercept a call in file with this path because multiple files in the compilation have this path.*
- **CS9153**: *The indicated call is intercepted multiple times.*
- **CS9160**: *A nameof operator cannot be intercepted.*
- **CS9161**: *An interceptor cannot be marked with `UnmanagedCallersOnlyAttribute`.*
- **CS9206**: *An interceptor cannot be declared in the global namespace.*
- **CS9207**: *Cannot intercept because method is not an invocation of an ordinary member method.*

These errors indicate that your interceptor method violates one of the rules for interceptors:

- Interceptors can't be generic methods, or members of generic classes.
- Interceptors must be ordinary members. They can't be operators, instance or static constructors, or finalizers.
- Interceptable methods must be ordinary members. They can't be operators, instance or static constructors, or finalizers, nor delegate invocations.
- Interceptable methods that are never invoked can't be intercepted.
- Interceptable methods can be intercepted at most once.
- Interceptors can't be methods limited to unmanaged callers.
- Interceptors must be contained in a namespace.
