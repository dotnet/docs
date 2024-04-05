---
title: System.Reflection.Emit.DynamicMethod class
description: Learn about the System.Reflection.Emit.DynamicMethod class.
ms.date: 12/31/2023
---
# System.Reflection.Emit.DynamicMethod class

[!INCLUDE [context](includes/context.md)]

You can use the <xref:System.Reflection.Emit.DynamicMethod> class to generate and execute a method at run time, without having to generate a dynamic assembly and a dynamic type to contain the method. The executable code created by the just-in-time (JIT) compiler is reclaimed when the <xref:System.Reflection.Emit.DynamicMethod> object is reclaimed. Dynamic methods are the most efficient way to generate and execute small amounts of code.

A dynamic method can be anonymously hosted, or it can be logically associated with a module or with a type.

- If the dynamic method is anonymously hosted, it is located in a system-provided assembly, and therefore is isolated from other code. By default, it does not have access to any non-public data. An anonymously hosted dynamic method can have restricted ability to skip the JIT compiler's visibility checks, if it has been granted <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag. The trust level of the assembly whose non-public members are accessed by the dynamic method must be equal to, or a subset of, the trust level of the call stack that emitted the dynamic method. For more information about anonymously hosted dynamic methods, see [Walkthrough: Emitting Code in Partial Trust Scenarios](../../framework/reflection-and-codedom/walkthrough-emitting-code-in-partial-trust-scenarios.md).

- If the dynamic method is associated with a module that you specify, the dynamic method is effectively global to that module. It can access all types in the module and all `internal` (`Friend` in Visual Basic) members of the types. You can associate a dynamic method with any module, regardless of whether you created the module, provided that a demand for <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess> flag can be satisfied by the call stack that includes your code. If the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag is included in the grant, the dynamic method can skip the JIT compiler's visibility checks and access the private data of all types declared in the module or in any other module in any assembly.

  > [!NOTE]
  > When you specify the module with which a dynamic method is associated, that module must not be in the system-provided assembly that is used for anonymous hosting.

- If the dynamic method is associated with a type that you specify, it has access to all members of the type, regardless of access level. In addition, JIT visibility checks can be skipped. This gives the dynamic method access to the private data of other types declared in the same module or in any other module in any assembly. You can associate a dynamic method with any type, but your code must be granted <xref:System.Security.Permissions.ReflectionPermission> with both the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess> and <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess> flags.

The following table shows which types and members are accessible to an anonymously hosted dynamic method, with and without JIT visibility checks, depending on whether <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess> flag is granted.

| Visibility checks | Without `RestrictedMemberAccess` | With `RestrictedMemberAccess` |
|-------------------|----------------------------------|-------------------------------|
|Without skipping JIT visibility checks|Public members of public types in any assembly.|Public members of public types in any assembly.|
|Skipping JIT visibility checks, with restrictions|Public members of public types in any assembly.|All members of all types, only in assemblies whose trust levels are equal to or less than the trust level of the assembly that emitted the dynamic method.|

The following table shows which types and members are accessible to a dynamic method that's associated with a module or with a type in a module.

| Skip JIT visibility checks | Associated with module | Associated with type |
|----------------------------|------------------------|----------------------|
| No |Public and internal members of public, internal, and private types in the module.<br /><br />Public members of public types in any assembly.|All members of the associated type. Public and internal members of all the other types in the module.<br /><br />Public members of public types in any assembly.|
| Yes |All members of all types in any assembly.|All members of all types in any assembly.|

A dynamic method that is associated with a module has the permissions of that module. A dynamic method that is associated with a type has the permissions of the module containing that type.

Dynamic methods and their parameters do not have to be named, but you can specify names to assist in debugging. Custom attributes are not supported on dynamic methods or their parameters.

Although dynamic methods are `static` methods (`Shared` methods in Visual Basic), the relaxed rules for delegate binding allow a dynamic method to be bound to an object, so that it acts like an instance method when called using that delegate instance. An example that demonstrates this is provided for the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%28System.Type%2CSystem.Object%29> method overload.

## Verification

The following list summarizes the conditions under which dynamic methods can contain unverifiable code. (For example, a dynamic method is unverifiable if its <xref:System.Reflection.Emit.DynamicMethod.InitLocals> property is set to `false`.)

- A dynamic method that's associated with a security-critical assembly is also security-critical, and can skip verification. For example, an assembly without security attributes that is run as a desktop application is treated as security-critical by the runtime. If you associate a dynamic method with the assembly, the dynamic method can contain unverifiable code.
- If a dynamic method that contains unverifiable code is associated with an assembly that has level 1 transparency, the just-in-time (JIT) compiler injects a security demand. The demand succeeds only if the dynamic method is executed by fully trusted code. See [Security-Transparent Code, Level 1](/dotnet/framework/misc/security-transparent-code-level-1).
- If a dynamic method that contains unverifiable code is associated with an assembly that has level 2 transparency (such as mscorlib.dll), it throws an exception (injected by the JIT compiler) instead of making a security demand. See [Security-Transparent Code, Level 2](/dotnet/framework/misc/security-transparent-code-level-2).
- An anonymously hosted dynamic method that contains unverifiable code always throws an exception. It can never skip verification, even if it is created and executed by fully trusted code.

The exception that's thrown for unverifiable code varies depending on the way the dynamic method is invoked. If you invoke a dynamic method by using a delegate returned from the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> method, a <xref:System.Security.VerificationException> is thrown. If you invoke the dynamic method by using the <xref:System.Reflection.Emit.DynamicMethod.Invoke%2A> method, a <xref:System.Reflection.TargetInvocationException> is thrown with an inner <xref:System.Security.VerificationException>.
