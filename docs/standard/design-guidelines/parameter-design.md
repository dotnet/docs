---
description: "Learn more about: Parameter Design"
title: "Parameter Design"
ms.date: "10/22/2008"
helpviewer_keywords:
  - "member design guidelines [.NET Framework], parameters"
  - "members [.NET Framework], parameters"
  - "names [.NET Framework], parameters"
  - "parameters, design guidelines"
  - "reserved parameters"
ms.assetid: 3f33bf46-4a7b-43b3-bb78-1ffebe0dcfa6
---
# Parameter Design

This section provides broad guidelines on parameter design, including sections with guidelines for checking arguments. In addition, you should refer to the guidelines described in [Naming Parameters](naming-parameters.md).

 ✔️ DO use the least derived parameter type that provides the functionality required by the member.

 For example, suppose you want to design a method that enumerates a collection and prints each item to the console. Such a method should take <xref:System.Collections.IEnumerable> as the parameter, not <xref:System.Collections.ArrayList> or <xref:System.Collections.IList>, for example.

 ❌ DO NOT use reserved parameters.

 If more input to a member is needed in some future version, a new overload can be added.

 ❌ DO NOT have publicly exposed methods that take pointers, arrays of pointers, or multidimensional arrays as parameters.

 Pointers and multidimensional arrays are relatively difficult to use properly. In almost all cases, APIs can be redesigned to avoid taking these types as parameters.

 ✔️ DO place all `out` parameters following all of the by-value and `ref` parameters (excluding parameter arrays), even if it results in an inconsistency in parameter ordering between overloads (see [Member Overloading](member-overloading.md)).

 The `out` parameters can be seen as extra return values, and grouping them together makes the method signature easier to understand.

 ✔️ DO be consistent in naming parameters when overriding members or implementing interface members.

 This better communicates the relationship between the methods.

### Choosing Between Enum and Boolean Parameters  

 ✔️ DO use enums if a member would otherwise have two or more Boolean parameters.

 ❌ DO NOT use Booleans unless you are absolutely sure there will never be a need for more than two values.

 Enums give you some room for future addition of values, but you should be aware of all the implications of adding values to enums, which are described in [Enum Design](enum.md).

 ✔️ CONSIDER using Booleans for constructor parameters that are truly two-state values and are simply used to initialize Boolean properties.

### Validating Arguments

 ✔️ DO validate arguments passed to public, protected, or explicitly implemented members. Throw <xref:System.ArgumentException?displayProperty=nameWithType>, or one of its subclasses, if the validation fails.

 Note that the actual validation does not necessarily have to happen in the public or protected member itself. It could happen at a lower level in some private or internal routine. The main point is that the entire surface area that is exposed to the end users checks the arguments.

 ✔️ DO throw <xref:System.ArgumentNullException> if a null argument is passed and the member does not support null arguments.

 ✔️ DO validate enum parameters.

 Do not assume enum arguments will be in the range defined by the enum. The CLR allows casting any integer value into an enum value even if the value is not defined in the enum.

 ❌ DO NOT use <xref:System.Enum.IsDefined%2A?displayProperty=nameWithType> for enum range checks.

 ✔️ DO be aware that mutable arguments might have changed after they were validated.

 If the member is security sensitive, you are encouraged to make a copy and then validate and process the argument.

### Parameter Passing

 From the perspective of a framework designer, there are three main groups of parameters: by-value parameters, `ref` parameters, and `out` parameters.

 When an argument is passed through a by-value parameter, the member receives a copy of the actual argument passed in. If the argument is a value type, a copy of the argument is put on the stack. If the argument is a reference type, a copy of the reference is put on the stack. Most popular CLR languages, such as C#, VB.NET, and C++, default to passing parameters by value.

 When an argument is passed through a `ref` parameter, the member receives a reference to the actual argument passed in. If the argument is a value type, a reference to the argument is put on the stack. If the argument is a reference type, a reference to the reference is put on the stack. `Ref` parameters can be used to allow the member to modify arguments passed by the caller.

 `Out` parameters are similar to `ref` parameters, with some small differences. The parameter is initially considered unassigned and cannot be read in the member body before it is assigned some value. Also, the parameter has to be assigned some value before the member returns.

 ❌ AVOID using `out` or `ref` parameters.

 Using `out` or `ref` parameters requires experience with pointers, understanding how value types and reference types differ, and handling methods with multiple return values. Also, the difference between `out` and `ref` parameters is not widely understood. Framework architects designing for a general audience should not expect users to become proficient in working with `out` or `ref` parameters.

 ❌ DO NOT pass reference types by reference.

 There are some limited exceptions to the rule, such as a method that can be used to swap references.

### Members with Variable Number of Parameters

 Members that can take a variable number of arguments are expressed by providing an array parameter. For example, <xref:System.String> provides the following method:

```csharp
public class String {
    public static string Format(string format, object[] parameters);
}
```

 A user can then call the <xref:System.String.Format%2A?displayProperty=nameWithType> method, as follows:

 `String.Format("File {0} not found in {1}",new object[]{filename,directory});`

 Adding the C# params keyword to an array parameter changes the parameter to a so-called params array parameter and provides a shortcut to creating a temporary array.

```csharp
public class String {
    public static string Format(string format, params object[] parameters);
}
```

 Doing this allows the user to call the method by passing the array elements directly in the argument list.

 `String.Format("File {0} not found in {1}",filename,directory);`

 Note that the params keyword can be added only to the last parameter in the parameter list.

 ✔️ CONSIDER adding the params keyword to array parameters if you expect the end users to pass arrays with a small number of elements. If it's expected that lots of elements will be passed in common scenarios, users will probably not pass these elements inline anyway, and so the params keyword is not necessary.

 ❌ AVOID using params arrays if the caller would almost always have the input already in an array.

 For example, members with byte array parameters would almost never be called by passing individual bytes. For this reason, byte array parameters in the .NET Framework do not use the params keyword.

 ❌ DO NOT use params arrays if the array is modified by the member taking the params array parameter.

 Because of the fact that many compilers turn the arguments to the member into a temporary array at the call site, the array might be a temporary object, and therefore any modifications to the array will be lost.

 ✔️ CONSIDER using the params keyword in a simple overload, even if a more complex overload could not use it.

 Ask yourself if users would value having the params array in one overload even if it wasn't in all overloads.

 ✔️ DO try to order parameters to make it possible to use the params keyword.

 ✔️ CONSIDER providing special overloads and code paths for calls with a small number of arguments in extremely performance-sensitive APIs.

 This makes it possible to avoid creating array objects when the API is called with a small number of arguments. Form the names of the parameters by taking a singular form of the array parameter and adding a numeric suffix.

 You should only do this if you are going to special-case the entire code path, not just create an array and call the more general method.

 ✔️ DO be aware that null could be passed as a params array argument.

 You should validate that the array is not null before processing.

 ❌ DO NOT use the `varargs` methods, otherwise known as the ellipsis.

 Some CLR languages, such as C++, support an alternative convention for passing variable parameter lists called `varargs` methods. The convention should not be used in frameworks, because it is not CLS compliant.

### Pointer Parameters

 In general, pointers should not appear in the public surface area of a well-designed managed code framework. Most of the time, pointers should be encapsulated. However, in some cases pointers are required for interoperability reasons, and using pointers in such cases is appropriate.

 ✔️ DO provide an alternative for any member that takes a pointer argument, because pointers are not CLS-compliant.

 ❌ AVOID doing expensive argument checking of pointer arguments.

 ✔️ DO follow common pointer-related conventions when designing members with pointers.

 For example, there is no need to pass the start index, because simple pointer arithmetic can be used to accomplish the same result.

 *Portions &copy; 2005, 2009 Microsoft Corporation. All rights reserved.*

 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*

## See also

- [Member Design Guidelines](member.md)
- [Framework Design Guidelines](index.md)
