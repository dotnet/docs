---
title: System.Reflection.Emit.DynamicMethod constructors
description: Learn about the System.Reflection.Emit.DynamicMethod constructors.
ms.date: 02/10/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicMethod constructors

[!INCLUDE [context](includes/context.md)]

## <xref:System.Reflection.Emit.DynamicMethod.%23ctor(System.String,System.Type,System.Type[],System.Boolean)> constructor

The dynamic method that is created by this constructor is associated with an anonymous assembly instead of an existing type or module. The anonymous assembly exists only to provide a sandbox environment for dynamic methods, that is, to isolate them from other code. This environment makes it safe for the dynamic method to be emitted and executed by partially trusted code.

Anonymously hosted dynamic methods don't have automatic access to any types or members that are `private`, `protected`, or `internal` (`Friend` in Visual Basic). This is different from dynamic methods that are associated with an existing type or module, which have access to hidden members in their associated scope.

Specify `true` for `restrictedSkipVisibility` if your dynamic method has to access types or members that are `private`, `protected`, or `internal`. This gives the dynamic method restricted access to these members. That is, the members can be accessed only if the following conditions are met:

- The target members belong to an assembly that has a level of trust equal to or lower than the call stack that emits the dynamic method.

- The call stack that emits the dynamic method is granted <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag. This is always true when the code is executed with full trust. For partially trusted code, it's true only if the host explicitly grants the permission.

    > [!IMPORTANT]
    > If the permission hasn't been granted, a security exception is thrown when <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate*> is called or when the dynamic method is invoked, not when this constructor is called. No special permissions are required to emit the dynamic method.

For example, a dynamic method that's created with `restrictedSkipVisibility` set to `true` can access a private member of any assembly on the call stack if the call stack has been granted restricted member access. If the dynamic method is created with partially trusted code on the call stack, it can't access a private member of a type in a .NET Framework assembly, because such assemblies are fully trusted.

If `restrictedSkipVisibility` is `false`, JIT visibility checks are enforced. The code in the dynamic method has access to public methods of public classes, and exceptions are thrown if it tries to access types or members that are `private`, `protected`, or `internal`.

When an anonymously hosted dynamic method is constructed, the call stack of the emitting assembly is included. When the method is invoked, the permissions of the emitting call stack are used instead of the permissions of the actual caller. Thus, the dynamic method can't execute at a higher level of privilege than that of the assembly that emitted it, even if it's passed to and executed by an assembly that has a higher trust level.

This constructor specifies the method attributes <xref:System.Reflection.MethodAttributes.Public?displayProperty=nameWithType> and <xref:System.Reflection.MethodAttributes.Static?displayProperty=nameWithType>, and the calling convention <xref:System.Reflection.CallingConventions.Standard?displayProperty=nameWithType>.

> [!NOTE]
> This constructor was introduced in .NET Framework 3.5 or later.

## <xref:System.Reflection.Emit.DynamicMethod.%23ctor(System.String,System.Type,System.Type[],System.Reflection.Module)> constructor

This constructor specifies method attributes <xref:System.Reflection.MethodAttributes.Public?displayProperty=nameWithType> and <xref:System.Reflection.MethodAttributes.Static?displayProperty=nameWithType>, calling convention <xref:System.Reflection.CallingConventions.Standard?displayProperty=nameWithType>, and doesn't skip just-in-time (JIT) visibility checks.

The dynamic method created with this constructor has access to public and `internal` (`Friend` in Visual Basic) members of all the types contained in module `m`.

> [!NOTE]
> For backward compatibility, this constructor demands <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.ControlEvidence?displayProperty=nameWithType> flag if the following conditions are both true: `m` is a module other than the calling module, and the demand for <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag has failed. If the demand for <xref:System.Security.Permissions.SecurityPermission> succeeds, the operation is allowed.

### Examples

The following code example creates a dynamic method that takes two parameters. The example emits a simple function body that prints the first parameter to the console, and the example uses the second parameter as the return value of the method. The example completes the method by creating a delegate, invokes the delegate with different parameters, and finally invokes the dynamic method using the <xref:System.Reflection.Emit.DynamicMethod.Invoke(System.Object,System.Reflection.BindingFlags%2CSystem.Reflection.Binder%2CSystem.Object%5B%5D,System.Globalization.CultureInfo)> method.

:::code language="csharp" source="./snippets/System.Reflection.Emit/DynamicMethod/.ctor/csharp/source1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Reflection.Emit/DynamicMethod/.ctor/vb/source1.vb" id="Snippet1":::

## <xref:System.Reflection.Emit.DynamicMethod.%23ctor(System.String,System.Type,System.Type[],System.Type)> constructor

The dynamic method created with this constructor has access to all members of the type `owner`, and to public and `internal` (`Friend` in Visual Basic) members of all the other types in the module that contains `owner`.

This constructor specifies method attributes <xref:System.Reflection.MethodAttributes.Public?displayProperty=nameWithType> and <xref:System.Reflection.MethodAttributes.Static?displayProperty=nameWithType>, calling convention <xref:System.Reflection.CallingConventions.Standard?displayProperty=nameWithType>, and doesn't skip just-in-time (JIT) visibility checks.

> [!NOTE]
> For backward compatibility, this constructor demands <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.ControlEvidence?displayProperty=nameWithType> flag if the following conditions are both true: `owner` is in a module other than the calling module, and the demand for <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag has failed. If the demand for <xref:System.Security.Permissions.SecurityPermission> succeeds, the operation is allowed.

### Examples

The following code example creates a <xref:System.Reflection.Emit.DynamicMethod> that's logically associated with a type. This association gives it access to the private members of that type.

The code example defines a class named `Example` with a private field, a class named `DerivedFromExample` that derives from the first class, a delegate type named `UseLikeStatic` that returns <xref:System.Int32> and has parameters of type `Example` and <xref:System.Int32>, and a delegate type named `UseLikeInstance` that returns <xref:System.Int32> and has one parameter of type <xref:System.Int32>.

The example code then creates a <xref:System.Reflection.Emit.DynamicMethod> that changes the private field of an instance of `Example` and returns the previous value.

> [!NOTE]
> In general, changing the internal fields of classes isn't good object-oriented coding practice.

The example code creates an instance of `Example` and then creates two delegates. The first is of type `UseLikeStatic`, which has the same parameters as the dynamic method. The second is of type `UseLikeInstance`, which lacks the first parameter (of type `Example`). This delegate is created using the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate(System.Type,System.Object)> method overload; the second parameter of that method overload is an instance of `Example`, in this case the instance just created, which is bound to the newly created delegate. Whenever that delegate is invoked, the dynamic method acts on the bound instance of `Example`.

> [!NOTE]
> This is an example of the relaxed rules for delegate binding introduced in .NET Framework 2.0, along with new overloads of the <xref:System.Delegate.CreateDelegate*?displayProperty=nameWithType> method. For more information, see the <xref:System.Delegate> class.

The `UseLikeStatic` delegate is invoked, passing in the instance of `Example` that's bound to the `UseLikeInstance` delegate. Then the `UseLikeInstance` delegate is invoked, so that both delegates act on the same instance of `Example`. The changes in the values of the internal field are displayed after each call. Finally, a `UseLikeInstance` delegate is bound to an instance of `DerivedFromExample`, and the delegate calls are repeated.

:::code language="csharp" source="./snippets/System.Reflection.Emit/DynamicMethod/.ctor/csharp/source.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Reflection.Emit/DynamicMethod/.ctor/vb/source.vb" id="Snippet1":::
