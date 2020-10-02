---
title: Code style language rules
description: Learn about the different code style rules for using C# and Visual Basic language constructs.
ms.date: 09/25/2020
ms.topic: reference
author: gewarren
ms.author: gewarren
dev_langs:
- CSharp
- VB
helpviewer_keywords:
- language code style rules [EditorConfig]
- language rules
- EditorConfig language conventions
---
# Language rules

Code style language rules affect how various constructs of .NET programming languages, for example, modifiers and parentheses, are used. The rules fall into the following categories:

- [.NET style rules](#net-style-rules): Rules that apply to both C# and Visual Basic. The EditorConfig option names for these rules start with `dotnet_style_` prefix.
- [C# style rules](#c-style-rules): Rules that are specific to C# language only. The EditorConfig option names for these rules start with `csharp_style_` prefix.

## Option format

Options for language rules can be specified in an EditorConfig file with the following format:

`option_name = value:severity`

- **Value**: For each language rule, you specify a value that defines if or when to prefer the style. Many rules accept a value of `true` (prefer this style) or `false` (do not prefer this style). Other rules accept values such as `when_on_single_line` or `never`.
- **Severity**: The second part of the rule specifies the [severity level](../configuration-options.md#severity-level) for the rule. Severity specification as part of the above option syntax is only respected inside development IDEs, such as Visual Studio. This setting is not understood by the C# or VB compilers, hence not respected during build. Instead, to enforce code style rules on build, you should set the severity by using the rule ID based severity configuration syntax for analyzers. The syntax takes the form `dotnet_diagnostic.<rule ID>.severity = <severity>`, for example, `dotnet_diagnostic.IDE0040.severity = silent`. For more details, see this [github issue](https://github.com/dotnet/roslyn/issues/44201).

> [!TIP]
>
> Starting in Visual Studio 2019 version 16.3, you can configure code style rules from the [Quick Actions](/visualstudio/ide/quick-actions) light bulb menu after a style violation occurs. For more information, see [Automatically configure code styles in Visual Studio](/visualstudio/ide/editorconfig-language-conventions#automatically-configure-code-styles-in-visual-studio).

## .NET style rules

The style rules in this section are applicable to both C# and Visual Basic.

- ['this.' and 'Me.' qualifiers](ide0003-ide0009.md)
  - [dotnet\_style\_qualification\_for_field](ide0003-ide0009.md#dotnet\_style\_qualification\_for_field)
  - [dotnet\_style\_qualification\_for_property](ide0003-ide0009.md#dotnet\_style\_qualification\_for_property)
  - [dotnet\_style\_qualification\_for_method](ide0003-ide0009.md#dotnet\_style\_qualification\_for_method)
  - [dotnet\_style\_qualification\_for_event](ide0003-ide0009.md#dotnet\_style\_qualification\_for_event)
- [Language keywords instead of framework type names for type references](ide0049.md)
  - [dotnet\_style\_predefined\_type\_for\_locals\_parameters_members](ide0049.md#dotnet\_style\_predefined\_type\_for\_locals\_parameters_members)
  - [dotnet\_style\_predefined\_type\_for\_member_access](ide0049.md#dotnet\_style\_predefined\_type\_for\_member_access)
- [Modifier preferences](modifier-preferences.md)
  - [dotnet\_style\_require\_accessibility_modifiers](ide0040.md#dotnet\_style\_require\_accessibility_modifiers)
  - [csharp\_preferred\_modifier_order](ide0036.md#csharp\_preferred\_modifier_order)
  - [visual\_basic\_preferred\_modifier_order](ide0036.md#visual\_basic\_preferred\_modifier_order)
  - [dotnet\_style\_readonly\_field](ide0044.md#dotnet\_style\_readonly\_field)
- [Parentheses preferences](ide0047-ide0048.md)
  - [dotnet\_style\_parentheses\_in\_arithmetic\_binary\_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_arithmetic\_binary_operators)
  - [dotnet\_style\_parentheses\_in\_relational\_binary\_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_relational\_binary_operators)
  - [dotnet\_style\_parentheses\_in\_other\_binary\_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_other\_binary_operators)
  - [dotnet\_style\_parentheses\_in\_other\_operators](ide0047-ide0048.md#dotnet\_style\_parentheses\_in\_other_operators)
- [Expression-level preferences](expression-level-preferences.md)
  - [dotnet\_style\_object_initializer](ide0017.md#dotnet\_style\_object_initializer)
  - [dotnet\_style\_collection_initializer](ide0028.md#dotnet\_style\_collection_initializer)
  - [dotnet\_style\_explicit\_tuple_names](ide0033.md#dotnet\_style\_explicit\_tuple_names)
  - [dotnet\_style\_prefer\_inferred\_tuple_names](ide0037.md#dotnet\_style\_prefer\_inferred\_tuple_names)
  - [dotnet\_style\_prefer\_inferred\_anonymous\_type\_member_names](ide0037.md#dotnet\_style\_prefer\_inferred\_anonymous\_type\_member_names)
  - [dotnet\_style\_prefer\_auto\_properties](ide0032.md#dotnet\_style\_prefer\_auto\_properties)
  - [dotnet\_style\_prefer\_conditional\_expression\_over\_assignment](ide0045.md#dotnet\_style\_prefer\_conditional\_expression\_over\_assignment)
  - [dotnet\_style\_prefer\_conditional\_expression\_over\_return](ide0046.md#dotnet\_style\_prefer\_conditional\_expression\_over\_return)
  - [dotnet\_style\_prefer\_compound\_assignment](ide0054.md#dotnet\_style\_prefer\_compound\_assignment)
  - [csharp\_style\_unused\_value\_assignment_preference](ide0059.md#csharp\_style\_unused\_value\_assignment_preference)
  - [visual\_basic\_style\_unused\_value\_assignment\_preference](ide0059.md#visual\_basic\_style\_unused\_value\_assignment\_preference)
  - [csharp\_style\_unused\_value\_expression\_statement_preference](ide0058.md#csharp\_style\_unused\_value\_expression\_statement_preference)
  - [visual\_basic\_style\_unused\_value\_expression\_statement_preference](ide0058.md#visual\_basic\_style\_unused\_value\_expression\_statement_preference)
- [Null-checking preferences](#null-checking-preferences)
  - [dotnet\_style\_coalesce\_expression](ide0029.md#dotnet\_style\_coalesce\_expression)
  - [dotnet\_style\_null_propagation](ide0031.md#dotnet\_style\_null\_propagation)
  - [dotnet\_style\_prefer\_is\_null\_check\_over\_reference\_equality\_method](ide0041.md#dotnet_style_prefer_is_null_check_over_reference_equality_method)
- [Parameter preferences](parameter-preferences.md)
  - [dotnet\_code\_quality\_unused\_parameters](ide0060.md#dotnet\_code\_quality\_unused\_parameters)

## C# style rules

The style rules in this section are applicable to C# language only.

- [Implicit and explicit types](#implicit-and-explicit-types)
  - csharp\_style\_var\_for\_built\_in_types
  - csharp\_style\_var\_when\_type\_is_apparent
  - csharp\_style\_var_elsewhere
- [Expression-bodied members](#expression-bodied-members)
  - csharp\_style\_expression\_bodied_methods
  - csharp\_style\_expression\_bodied_constructors
  - csharp\_style\_expression\_bodied_operators
  - csharp\_style\_expression\_bodied_properties
  - csharp\_style\_expression\_bodied_indexers
  - csharp\_style\_expression\_bodied_accessors
  - csharp\_style\_expression\_bodied_lambdas
  - csharp\_style\_expression\_bodied\_local_functions
- [Pattern matching](#pattern-matching)
  - csharp\_style\_pattern\_matching\_over\_is\_with\_cast_check
  - csharp\_style\_pattern\_matching\_over\_as\_with\_null_check
- [Inlined variable declarations](#inlined-variable-declarations)
  - csharp\_style\_inlined\_variable_declaration
- [Expression-level preferences](#c-expression-level-preferences)
  - csharp\_prefer\_simple\_default_expression
- ["Null" checking preferences](#c-null-checking-preferences)
  - csharp\_style\_throw_expression
  - csharp\_style\_conditional\_delegate_call
- [Code block preferences](#code-block-preferences)
  - csharp\_prefer_braces
- [Index and range preferences](#index-and-range-preferences)
  - csharp\_style\_prefer\_index_operator
  - csharp\_style\_prefer\_range_operator
- [Miscellaneous preferences](#miscellaneous-preferences)
  - csharp\_style\_deconstructed\_variable_declaration
  - csharp\_style\_pattern\_local\_over\_anonymous_function
  - csharp\_using\_directive\_placement
  - csharp\_prefer\_static\_local_function
  - csharp\_prefer\_simple\_using_statement
  - csharp\_style\_prefer\_switch_expression

### Implicit and explicit types

The style rules in this section concern the use of the [var](/dotnet/csharp/language-reference/keywords/var) keyword versus an explicit type in a variable declaration. This rule can be applied separately to built-in types, when the type is apparent, and elsewhere.

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_style_var_for_built_in_types = true:suggestion
csharp_style_var_when_type_is_apparent = true:suggestion
csharp_style_var_elsewhere = true:suggestion
```

#### csharp\_style\_var\_for\_built\_in_types

|Property|Value|
|-|-|
| **Option name** | csharp_style_var_for_built_in_types |
| **Rule ID** | IDE0007 and IDE0008 |
| **Applicable languages** | C#  |
| **Option values** | `true` - Prefer `var` is used to declare variables with built-in system types such as `int`<br /><br />`false` - Prefer explicit type over `var` to declare variables with built-in system types such as `int` |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_style_var_for_built_in_types = true
var x = 5;

// csharp_style_var_for_built_in_types = false
int x = 5;
```

#### csharp\_style\_var\_when\_type\_is_apparent

|Property|Value|
|-|-|
| **Option name** | csharp_style_var_when_type_is_apparent |
| **Rule ID** | IDE0007 and IDE0008 |
| **Applicable languages** | C#  |
| **Option values** | `true` - Prefer `var` when the type is already mentioned on the right-hand side of a declaration expression<br /><br />`false` - Prefer explicit type over `var` when the type is already mentioned on the right-hand side of a declaration expression |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_style_var_when_type_is_apparent = true
var obj = new Customer();

// csharp_style_var_when_type_is_apparent = false
Customer obj = new Customer();
```

#### csharp\_style\_var_elsewhere

|Property|Value|
|-|-|
| **Option name** | csharp_style_var_elsewhere |
| **Rule ID** | IDE0007 and IDE0008 |
| **Applicable languages** | C#  |
| **Option values** | `true` - Prefer `var` over explicit type in all cases, unless overridden by another code style rule<br /><br />`false` - Prefer explicit type over `var` in all cases, unless overridden by another code style rule |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_style_var_elsewhere = true
var f = this.Init();

// csharp_style_var_elsewhere = false
bool f = this.Init();
```

### Expression-bodied members

The style rules in this section concern the use of [expression-bodied members](/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members) when the logic consists of a single expression. This rule can be applied to methods, constructors, operators, properties, indexers, and accessors.

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_style_expression_bodied_methods = false:silent
csharp_style_expression_bodied_constructors = false:silent
csharp_style_expression_bodied_operators = false:silent
csharp_style_expression_bodied_properties = true:suggestion
csharp_style_expression_bodied_indexers = true:suggestion
csharp_style_expression_bodied_accessors = true:suggestion
csharp_style_expression_bodied_lambdas = true:silent
csharp_style_expression_bodied_local_functions = false:silent
```

#### csharp\_style\_expression\_bodied_methods

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_methods |
| **Rule ID** | IDE0022 |
| **Applicable languages** | C# 6.0+  |
| **Option values** | `true` - Prefer expression bodies for methods<br /><br />`when_on_single_line` - Prefer expression bodies for methods when they will be a single line<br /><br />`false` - Prefer block bodies for methods |
| **Default option value** | `false:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_methods = true
public int GetAge() => this.Age;

// csharp_style_expression_bodied_methods = false
public int GetAge() { return this.Age; }
```

#### csharp\_style\_expression\_bodied_constructors

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_constructors |
| **Rule ID** | IDE0021 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer expression bodies for constructors<br /><br />`when_on_single_line` - Prefer expression bodies for constructors when they will be a single line<br /><br />`false` - Prefer block bodies for constructors |
| **Default option value** | `false:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_constructors = true
public Customer(int age) => Age = age;

// csharp_style_expression_bodied_constructors = false
public Customer(int age) { Age = age; }
```

#### csharp\_style\_expression\_bodied_operators

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_operators |
| **Rule ID** | IDE0023 and IDE0024 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer expression bodies for operators<br /><br />`when_on_single_line` - Prefer expression bodies for operators when they will be a single line<br /><br />`false` - Prefer block bodies for operators |
| **Default option value** | `false:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_operators = true
public static ComplexNumber operator + (ComplexNumber c1, ComplexNumber c2)
    => new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);

// csharp_style_expression_bodied_operators = false
public static ComplexNumber operator + (ComplexNumber c1, ComplexNumber c2)
{ return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary); }
```

#### csharp\_style\_expression\_bodied_properties

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_properties |
| **Rule ID** | IDE0025 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer expression bodies for properties<br /><br />`when_on_single_line` - Prefer expression bodies for properties when they will be a single line<br /><br />`false` - Prefer block bodies for properties |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_properties = true
public int Age => _age;

// csharp_style_expression_bodied_properties = false
public int Age { get { return _age; }}
```

#### csharp\_style\_expression\_bodied_indexers

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_indexers |
| **Rule ID** | IDE0026 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer expression bodies for indexers<br /><br />`when_on_single_line` - Prefer expression bodies for indexers when they will be a single line<br /><br />`false` - Prefer block bodies for indexers |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_indexers = true
public T this[int i] => _values[i];

// csharp_style_expression_bodied_indexers = false
public T this[int i] { get { return _values[i]; } }
```

#### csharp\_style\_expression\_bodied_accessors

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_accessors |
| **Rule ID** | IDE0027 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer expression bodies for accessors<br /><br />`when_on_single_line` - Prefer expression bodies for accessors when they will be a single line<br /><br />`false` - Prefer block bodies for accessors |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_accessors = true
public int Age { get => _age; set => _age = value; }

// csharp_style_expression_bodied_accessors = false
public int Age { get { return _age; } set { _age = value; } }
```

#### csharp\_style\_expression\_bodied_lambdas

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_lambdas |
| **Rule ID** | IDE0053 |
| **Option values** | `true` - Prefer expression bodies for lambdas<br /><br />`when_on_single_line` - Prefer expression bodies for lambdas when they will be a single line<br /><br />`false` - Prefer block bodies for lambdas |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_lambdas = true
Func<int, int> square = x => x * x;

// csharp_style_expression_bodied_lambdas = false
Func<int, int> square = x => { return x * x; };
```

#### csharp\_style\_expression\_bodied\_local_functions

Starting with C# 7.0, C# supports [local functions](/dotnet/csharp/programming-guide/classes-and-structs/local-functions). Local functions are private methods of a type that are nested in another member.

|Property|Value|
|-|-|
| **Option name** | csharp_style_expression_bodied_local_functions |
| **Rule ID** | IDE0061 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer expression bodies for local functions<br /><br />`when_on_single_line` - Prefer expression bodies for local functions when they will be a single line<br /><br />`false` - Prefer block bodies for local functions |
| **Default option value** | `false:silent` |

Code examples:

```csharp
// csharp_style_expression_bodied_local_functions = true
void M()
{
    Hello();
    void Hello() => Console.WriteLine("Hello");
}

// csharp_style_expression_bodied_local_functions = false
void M()
{
    Hello();
    void Hello()
    {
        Console.WriteLine("Hello");
    }
}
```

### Pattern matching

The style rules in this section concern the use of [pattern matching](/dotnet/csharp/pattern-matching) in C#.

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_style_pattern_matching_over_is_with_cast_check = true:suggestion
csharp_style_pattern_matching_over_as_with_null_check = true:suggestion
```

#### csharp\_style\_pattern\_matching\_over\_is\_with\_cast_check

|Property|Value|
|-|-|
| **Option name** | csharp_style_pattern_matching_over_is_with_cast_check |
| **Rule ID** | IDE0020 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer pattern matching instead of `is` expressions with type casts<br /><br />`false` - Prefer `is` expressions with type casts instead of pattern matching |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_pattern_matching_over_is_with_cast_check = true
if (o is int i) {...}

// csharp_style_pattern_matching_over_is_with_cast_check = false
if (o is int) {var i = (int)o; ... }
```

#### csharp\_style\_pattern\_matching\_over\_as\_with\_null_check

|Property|Value|
|-|-|
| **Option name** | csharp_style_pattern_matching_over_as_with_null_check |
| **Rule ID** | IDE0019 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer pattern matching instead of `as` expressions with null checks to determine if something is of a particular type<br /><br />`false` - Prefer `as` expressions with null checks instead of pattern matching to determine if something is of a particular type |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_pattern_matching_over_as_with_null_check = true
if (o is string s) {...}

// csharp_style_pattern_matching_over_as_with_null_check = false
var s = o as string;
if (s != null) {...}
```

### Inlined variable declarations

This style rule concerns whether `out` variables are declared inline or not. Starting in C# 7, you can [declare an out variable in the argument list of a method call](/dotnet/csharp/language-reference/keywords/out-parameter-modifier#calling-a-method-with-an-out-argument), rather than in a separate variable declaration.

#### csharp\_style\_inlined\_variable_declaration

|Property|Value|
|-|-|
| **Option name** | csharp_style_inlined_variable_declaration |
| **Rule ID** | IDE0018 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer `out` variables to be declared inline in the argument list of a method call when possible<br /><br />`false` - Prefer `out` variables to be declared before the method call |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_inlined_variable_declaration = true
if (int.TryParse(value, out int i) {...}

// csharp_style_inlined_variable_declaration = false
int i;
if (int.TryParse(value, out i) {...}
```

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_style_inlined_variable_declaration = true:suggestion
```

### C# expression-level preferences

The style rules in this section concern expression-level preferences.

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_prefer_simple_default_expression = true:suggestion
```

#### csharp\_prefer\_simple\_default_expression

This style rule concerns using the [`default` literal for default value expressions](/dotnet/csharp/language-reference/operators/default#default-literal) when the compiler can infer the type of the expression.

|Property|Value|
|-|-|
| **Option name** | csharp_prefer_simple_default_expression |
| **Rule ID** | IDE0034 |
| **Applicable languages** | C# 7.1+  |
| **Option values** | `true` - Prefer `default` over `default(T)`<br /><br />`false` - Prefer `default(T)` over `default` |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_prefer_simple_default_expression = true
void DoWork(CancellationToken cancellationToken = default) { ... }

// csharp_prefer_simple_default_expression = false
void DoWork(CancellationToken cancellationToken = default(CancellationToken)) { ... }
```

### C# null-checking preferences

These style rules concern the syntax around `null` checking, including using `throw` expressions or `throw` statements, and whether to perform a null check or use the conditional coalescing operator (`?.`) when invoking a [lambda expression](/dotnet/csharp/lambda-expressions).

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_style_throw_expression = true:suggestion
csharp_style_conditional_delegate_call = false:suggestion
```

#### csharp\_style\_throw_expression

|Property|Value|
|-|-|
| **Option name** | csharp_style_throw_expression |
| **Rule ID** | IDE0016 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer to use `throw` expressions instead of `throw` statements<br /><br />`false` - Prefer to use `throw` statements instead of `throw` expressions |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_throw_expression = true
this.s = s ?? throw new ArgumentNullException(nameof(s));

// csharp_style_throw_expression = false
if (s == null) { throw new ArgumentNullException(nameof(s)); }
this.s = s;
```

#### csharp\_style\_conditional\_delegate_call

|Property|Value|
|-|-|
| **Option name** | csharp_style_conditional_delegate_call |
| **Rule ID** | IDE0041 |
| **Applicable languages** | C# 6.0+  |
| **Option values** | `true` - refer to use the conditional coalescing operator (`?.`) when invoking a lambda expression, instead of performing a null check<br /><br />`false` - Prefer to perform a null check before invoking a lambda expression, instead of using the conditional coalescing operator (`?.`) |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_conditional_delegate_call = true
func?.Invoke(args);

// csharp_style_conditional_delegate_call = false
if (func != null) { func(args); }
```

### Code block preferences

This style rule concerns the use of curly braces `{ }` to surround code blocks.

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_prefer_braces = true:silent
```

#### csharp\_prefer\_braces

|Property|Value|
|-|-|
| **Option name** | csharp_prefer_braces |
| **Rule ID** | IDE0011 |
| **Applicable languages** | C# |
| **Option values** | `true` - Prefer curly braces even for one line of code<br /><br />`false` - Prefer no curly braces if allowed<br /><br />`when_multiline` - Prefer curly braces on multiple lines |
| **Default option value** | `true:silent` |

Code examples:

```csharp
// csharp_prefer_braces = true
if (test) { this.Display(); }

// csharp_prefer_braces = false
if (test) this.Display();
```

### Index and range preferences

These style rules concern the use of index and range operators, which are available in C# 8.0 and later.

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_style_prefer_index_operator = true:suggestion
csharp_style_prefer_range_operator = true:suggestion
```

#### csharp\_style\_prefer\_index_operator

|Property|Value|
|-|-|
| **Option name** | csharp_style_prefer_index_operator |
| **Rule ID** | IDE0056 |
| **Applicable languages** | C# 8.0+ |
| **Option values** | `true` - Prefer to use the `^` operator when calculating an index from the end of a collection<br /><br />`false` - Don't prefer to use the `^` operator when calculating an index from the end of a collection |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_prefer_index_operator = true
string[] names = { "Archimedes", "Pythagoras", "Euclid" };
var index = names[^1];

// csharp_style_prefer_index_operator = false
string[] names = { "Archimedes", "Pythagoras", "Euclid" };
var index = names[names.Length - 1];
```

#### csharp\_style\_prefer\_range_operator

|Property|Value|
|-|-|
| **Option name** | csharp_style_prefer_range_operator |
| **Rule ID** | IDE0057 |
| **Applicable languages** | C# 8.0+ |
| **Option values** | `true` - Prefer to use the range operator `..` when extracting a "slice" of a collection<br /><br />`false` - Don't prefer to use the range operator `..` when extracting a "slice" of a collection |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_prefer_range_operator = true
string sentence = "the quick brown fox";
var sub = sentence[0..^4];

// csharp_style_prefer_range_operator = false
string sentence = "the quick brown fox";
var sub = sentence.Substring(0, sentence.Length - 4);
```

### Miscellaneous preferences

This section contains miscellaneous style rules.

Example *.editorconfig* file:

```ini
# CSharp code style settings:
[*.cs]
csharp_style_deconstructed_variable_declaration = true:suggestion
csharp_style_pattern_local_over_anonymous_function = true:suggestion
csharp_using_directive_placement = outside_namespace:silent
csharp_prefer_static_local_function = true:suggestion
csharp_prefer_simple_using_statement = true:suggestion
csharp_style_prefer_switch_expression = true:suggestion
```

#### csharp\_style\_deconstructed\_variable_declaration

|Property|Value|
|-|-|
| **Option name** | csharp_style_deconstructed_variable_declaration |
| **Rule ID** | IDE0042 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer deconstructed variable declaration<br /><br />`false` - Do not prefer deconstruction in variable declarations |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_deconstructed_variable_declaration = true
var (name, age) = GetPersonTuple();
Console.WriteLine($"{name} {age}");

(int x, int y) = GetPointTuple();
Console.WriteLine($"{x} {y}");

// csharp_style_deconstructed_variable_declaration = false
var person = GetPersonTuple();
Console.WriteLine($"{person.name} {person.age}");

(int x, int y) point = GetPointTuple();
Console.WriteLine($"{point.x} {point.y}");
```

#### csharp\_style\_pattern\_local\_over\_anonymous_function

Starting with C# 7.0, C# supports [local functions](/dotnet/csharp/programming-guide/classes-and-structs/local-functions). Local functions are private methods of a type that are nested in another member.

|Property|Value|
|-|-|
| **Option name** | csharp_style_pattern_local_over_anonymous_function |
| **Rule ID** | IDE0039 |
| **Applicable languages** | C# 7.0+ |
| **Option values** | `true` - Prefer local functions over anonymous functions<br /><br />`false` - Prefer anonymous functions over local functions |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_style_pattern_local_over_anonymous_function = true
int fibonacci(int n)
{
    return n <= 1 ? 1 : fibonacci(n-1) + fibonacci(n-2);
}

// csharp_style_pattern_local_over_anonymous_function = false
Func<int, int> fibonacci = null;
fibonacci = (int n) =>
{
    return n <= 1 ? 1 : fibonacci(n - 1) + fibonacci(n - 2);
};
```

#### csharp\_using\_directive_placement

|Property|Value|
|-|-|
| **Option name** | csharp_using_directive_placement |
| **Rule ID** | IDE0065 |
| **Applicable languages** | C# |
| **Option values** | `outside_namespace` - Prefer `using` directives to be placed outside the namespace<br /><br />`inside_namespace` - Prefer `using` directives to be placed inside the namespace |
| **Default option value** | `outside_namespace:silent` |

Code examples:

```csharp
// csharp_using_directive_placement = outside_namespace
using System;

namespace Conventions
{
    ...
}

// csharp_using_directive_placement = inside_namespace
namespace Conventions
{
    using System;
    ...
}
```

#### csharp\_prefer\_static\_local_function

|Property|Value|
|-|-|
| **Option name** | csharp_prefer_static_local_function |
| **Rule ID** | IDE0062 |
| **Applicable languages** | C# 8.0+ |
| **Option values** | `true` - Prefer local functions to be marked `static`<br /><br />`false` - Don't prefer local functions to be marked `static` |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_prefer_static_local_function = true
void M()
{
    Hello();
    static void Hello()
    {
        Console.WriteLine("Hello");
    }
}

// csharp_prefer_static_local_function = false
void M()
{
    Hello();
    void Hello()
    {
        Console.WriteLine("Hello");
    }
}
```

#### csharp\_prefer\_simple\_using_statement

|Property|Value|
|-|-|
| **Option name** | csharp_prefer_simple_using_statement |
| **Rule ID** | IDE0063 |
| **Applicable languages** | C# 8.0+ |
| **Option values** | `true` - Prefer to use a *simple* `using` statement<br /><br />`false` - Don't prefer to use a *simple* `using` statement |
| **Default option value** | `true:suggestion` |

Code examples:

```csharp
// csharp_prefer_simple_using_statement = true
using var a = b;

// csharp_prefer_simple_using_statement = false
using (var a = b) { }
```

#### csharp\_style\_prefer\_switch_expression

|Property|Value|
|-|-|
| **Option name** | csharp_style_prefer_switch_expression |
| **Rule ID** | IDE0066 |
| **Applicable languages** | C# 8.0+ |
| **Option values** | `true` - Prefer to use a `switch` expression (introduced with C# 8.0)<br /><br />`false` - Prefer to use a [switch statement](/dotnet/csharp/language-reference/keywords/switch) |
| **Default option value** | `true:suggestion` |
| **Introduced version** | Visual Studio 2019 version 16.2 |

Code examples:

```csharp
// csharp_style_prefer_switch_expression = true
return x switch
{
    1 => 1 * 1,
    2 => 2 * 2,
    _ => 0,
};

// csharp_style_prefer_switch_expression = false
switch (x)
{
    case 1:
        return 1 * 1;
    case 2:
        return 2 * 2;
    default:
        return 0;
}
```

## See also

- [Formatting rules](formatting-rules.md)
- [Naming rules](naming-rules.md)
- [.NET code style rules reference](index.md)
