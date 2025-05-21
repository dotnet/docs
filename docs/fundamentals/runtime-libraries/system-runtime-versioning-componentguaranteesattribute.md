---
title: System.Runtime.Versioning.ComponentGuaranteesAttribute class
description: Learn about the System.Runtime.Versioning.ComponentGuaranteesAttribute class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Runtime.Versioning.ComponentGuaranteesAttribute class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute> is used by developers of components and class libraries to indicate the level of compatibility that consumers of their libraries can expect across multiple versions. It indicates the level of guarantee that a future version of the library or component will not break an existing client. Clients can then use the <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute> as an aid in designing their own interfaces to ensure stability across versions.

> [!NOTE]
> The common language runtime (CLR) does not use this attribute in any way. Its value lies in formally documenting the intent of the component author. Compile-time tools can also use these declarations to detect compile-time errors that would otherwise break the declared guarantee.

## Levels of compatibility

The <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute> supports the following levels of compatibility, which are represented by members of the <xref:System.Runtime.Versioning.ComponentGuaranteesOptions> enumeration:

- No version-to-version compatibility (<xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None?displayProperty=nameWithType>). The client can expect that future versions will break the existing client. For more information, see the [No compatibility](#no-compatibility) section later in this article.

- Side-by-side version-to-version compatibility (<xref:System.Runtime.Versioning.ComponentGuaranteesOptions.SideBySide?displayProperty=nameWithType>). The component has been tested to work when more than one version of the assembly is loaded in the same application domain. In general, future versions can break compatibility. However, when breaking changes are made, the old version is not modified but exists alongside the new version. Side-by-side execution is the expected way to make existing clients work when breaking changes are made. For more information, see the [Side-by-side compatibility](#side-by-side-compatibility) section later in this article.

- Stable version-to-version compatibility (<xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable?displayProperty=nameWithType>). Future versions should not break the client, and side-by-side execution should not be needed. However, if the client is inadvertently broken, it may be possible to use side-by-side execution to fix the problem. For more information, see the [Stable compatibility](#stable-compatibility) section.

- Exchange version-to-version compatibility (<xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Exchange?displayProperty=nameWithType>). Extraordinary care is taken to ensure that future versions will not break the client. The client should use only these types in the signature of interfaces that are used for communication with other assemblies that are deployed independently of one another. Only one version of these types is expected to be in a given application domain, which means that if a client breaks, side-by-side execution cannot fix the compatibility problem. For more information, see the [Exchange type compatibility](#exchange-type-compatibility) section.

The following sections discuss each level of guarantee in greater detail.

### No compatibility

Marking a component as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None?displayProperty=nameWithType> indicates that the provider makes no guarantees about compatibility. Clients should avoid taking any dependencies on the exposed interfaces. This level of compatibility is useful for types that are experimental or that are publicly exposed but are intended only for components that are always updated at the same time. <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None> explicitly indicates that this component should not be used by external components.

### Side-by-side compatibility

Marking a component as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.SideBySide?displayProperty=nameWithType> indicates that the component has been tested to work when more than one version of the assembly is loaded into the same application domain. Breaking changes are allowed as long as they are made to the assembly that has the greater version number. Components that are bound to an old version of the assembly are expected to continue to bind to the old version, and other components can bind to the new version. It is also possible to update a component that is declared to be <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.SideBySide> by destructively modifying the old version.

### Stable compatibility

Marking a type as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable?displayProperty=nameWithType> indicates that the type should remain stable across versions. However, it may also be possible for side-by-side versions of a stable type to exist in the same application domain.

Stable types maintain a high binary compatibility bar. Because of this, providers should avoid making breaking changes to stable types. The following kinds of changes are acceptable:

- Adding private instance fields to, or removing fields from, a type, as long as this does not break the serialization format.
- Changing a non-serializable type to a serializable type. (However, a serializable type cannot be changed to a non-serializable type.)
- Throwing new, more derived exceptions from a method.
- Improving the performance of a method.
- Changing the range of return values, as long as the change does not adversely affect the majority of clients.
- Fixing serious bugs, if the business justification is high and the number of adversely affected clients is low.

Because new versions of stable components are not expected to break existing clients, generally only one version of a stable component is needed in an application domain. However, this is not a requirement, because stable types are not used as well-known exchange types that all components agree upon. Therefore, if a new version of a stable component does inadvertently break some component, and if other components need the new version, it may be possible to fix the problem by loading both the old and new component.

<xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable> provides a stronger version compatibility guarantee than <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None>. It is a common default for multi-version components.

<xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable> can be combined with <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.SideBySide>, which states that the component will not break compatibility but is tested to work when more than one version is loaded in a given application domain.

After a type or method is marked as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable>, it can be upgraded to <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Exchange>. However, it cannot be downgraded to <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None>.

### Exchange type compatibility

Marking a type as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Exchange?displayProperty=nameWithType> provides a stronger version compatibility guarantee than <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable>, and should be applied to the most stable of all types. These types are intended to be used for interchange between independently built components across all component boundaries in both time (any version of the CLR or any version of a component or application) and space (cross-process, cross-CLR in one process, cross-application domain in one CLR). If a breaking change is made to an exchange type, it is impossible to fix the issue by loading multiple versions of the type.

Exchange types should be changed only when a problem is very serious (such as a severe security issue) or the probability of breakage is very low (that is, if the behavior was already broken in a random way that code could not have conceivably taken a dependency on). You can make the following kinds of changes to an exchange type:

- Add inheritance of new interface definitions.

- Add new private methods that implement the methods of newly inherited interface definitions.

- Add new static fields.

- Add new static methods.

- Add new non-virtual instance methods.

The following are considered breaking changes and are not allowed for primitive types:

- Changing serialization formats. Version-tolerant serialization is required.

- Adding or removing private instance fields. This risks changing the serialization format of the type and breaking client code that uses reflection.

- Changing the serializability of a type. A non-serializable type may not be made serializable, and vice versa.

- Throwing different exceptions from a method.

- Changing the range of a method's return values, unless the member definition raises this possibility and clearly indicates how clients should handle unknown values.

- Fixing most bugs. Consumers of the type will rely on the existing behavior.

After a component, type, or member is marked with the <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Exchange> guarantee, it cannot be changed to either <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable> or <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None>.

Typically, exchange types are the basic types (such as <xref:System.Int32> and <xref:System.String> in .NET) and interfaces (such as <xref:System.Collections.Generic.IList%601>, <xref:System.Collections.Generic.IEnumerable%601>, and <xref:System.IComparable%601>) that are commonly used in public interfaces.

Exchange types may publicly expose only other types that are also marked with <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Exchange> compatibility. In addition, exchange types cannot depend on the behavior of Windows APIs that are prone to change.

## Component guarantees

The following table indicates how a component's characteristics and usage affect its compatibility guarantee.

|Component characteristics|Exchange|Stable|Side-by-Side|None|
|-------------------------------|--------------|------------|--------------------|----------|
|Can be used in interfaces between components that version independently.|Y|N|N|N|
|Can be used (privately) by an assembly that versions independently.|Y|Y|Y|N|
|Can have multiple versions in a single application domain.|N|Y|Y|Y|
|Can make breaking changes|N|N|Y|Y|
|Tested to make certain multiple versions of the assembly can be loaded together.|N|N|Y|N|
|Can make breaking changes in place.|N|N|N|Y|
|Can make very safe non-breaking servicing changes in place.|Y|Y|Y|Y|

## Apply the attribute

You can apply the <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute> to an assembly, a type, or a type member. Its application is hierarchical. That is, by default, the guarantee defined by the <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute.Guarantees> property of the attribute at the assembly level defines the guarantee of all types in the assembly and all members in those types. Similarly, if the guarantee is applied to the type, by default it also applies to each member of the type.

This inherited guarantee can be overridden by applying the <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute> to individual types and type members. However, guarantees that override the default can only weaken the guarantee; they cannot strengthen it. For example, if an assembly is marked with the <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None> guarantee, its types and members have no compatibility guarantee, and any other guarantee that is applied to types or members in the assembly is ignored.

## Test the guarantee

The <xref:System.Runtime.Versioning.ComponentGuaranteesAttribute.Guarantees> property returns a member of the <xref:System.Runtime.Versioning.ComponentGuaranteesOptions> enumeration, which is marked with the <xref:System.FlagsAttribute> attribute. This means that you should test for the flag that you are interested in by masking away potentially unknown flags. For example, the following example tests whether a type is marked as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable>.

:::code language="csharp" source="./snippets/System.Runtime.Versioning/ComponentGuaranteesAttribute/Overview/csharp/apply1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Runtime.Versioning/ComponentGuaranteesAttribute/Overview/vb/apply1.vb" id="Snippet1":::

The following example tests whether a type is marked as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable> or <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Exchange>.

:::code language="csharp" source="./snippets/System.Runtime.Versioning/ComponentGuaranteesAttribute/Overview/csharp/apply1.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Runtime.Versioning/ComponentGuaranteesAttribute/Overview/vb/apply1.vb" id="Snippet2":::

The following example tests whether a type is marked as <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.None> (that is, neither <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Stable> nor <xref:System.Runtime.Versioning.ComponentGuaranteesOptions.Exchange>).

:::code language="csharp" source="./snippets/System.Runtime.Versioning/ComponentGuaranteesAttribute/Overview/csharp/apply1.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Runtime.Versioning/ComponentGuaranteesAttribute/Overview/vb/apply1.vb" id="Snippet3":::
