---
description: "Accessibility Levels - C# Reference"
title: "Accessibility Levels - C# Reference"
ms.date: 12/06/2017
helpviewer_keywords: 
  - "access modifiers [C#], accessibility levels"
  - "accessibility levels"
ms.assetid: dc083921-0073-413e-8936-a613e8bb7df4
---
# Accessibility Levels (C# Reference)

Use the access modifiers, `public`, `protected`, `internal`, or `private`, to specify one of the following declared accessibility levels for members.  
  
|Declared accessibility|Meaning|  
|----------------------------|-------------|  
|[`public`](public.md)|Access is not restricted.|  
|[`protected`](protected.md)|Access is limited to the containing class or types derived from the containing class.|  
|[`internal`](internal.md)|Access is limited to the current assembly.|  
|[`protected internal`](protected-internal.md)|Access is limited to the current assembly or types derived from the containing class.|  
|[`private`](private.md)|Access is limited to the containing type.|  
|[`private protected`](private-protected.md)|Access is limited to the containing class or types derived from the containing class within the current assembly. Available since C# 7.2. |  
  
 Only one access modifier is allowed for a member or type, except when you use the `protected internal` or `private protected` combinations.  
  
 Access modifiers are not allowed on namespaces. Namespaces have no access restrictions.  
  
 Depending on the context in which a member declaration occurs, only certain declared accessibilities are permitted. If no access modifier is specified in a member declaration, a default accessibility is used.  
  
 Top-level types, which are not nested in other types, can only have `internal` or `public` accessibility. The default accessibility for these types is `internal`.  
  
 Nested types, which are members of other types, can have declared accessibilities as indicated in the following table.  
  
|Members of|Default member accessibility|Allowed declared accessibility of the member|  
|----------------|----------------------------------|--------------------------------------------------|  
|`enum`|`public`|None|  
|`class`|`private`|`public`<br /><br /> `protected`<br /><br /> `internal`<br /><br /> `private`<br /><br /> `protected internal` <br /><br />`private protected`|  
|`interface`|`public`|`public`<br /><br /> `protected`<br /><br /> `internal`<br /><br /> `private`\*<br /><br /> `protected internal` <br /><br />`private protected`|  
|`struct`|`private`|`public`<br /><br /> `internal`<br /><br /> `private`|  

\* An `interface` member with `private` accessibility must have a default implementation.

The accessibility of a nested type depends on its [accessibility domain](./accessibility-domain.md), which is determined by both the declared accessibility of the member and the accessibility domain of the immediately containing type. However, the accessibility domain of a nested type cannot exceed that of the containing type.  
  
## C# Language Specification  

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [Access Modifiers](./access-modifiers.md)
- [Accessibility Domain](./accessibility-domain.md)
- [Restrictions on Using Accessibility Levels](./restrictions-on-using-accessibility-levels.md)
- [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md)
- [public](./public.md)
- [private](./private.md)
- [protected](./protected.md)
- [internal](./internal.md)
