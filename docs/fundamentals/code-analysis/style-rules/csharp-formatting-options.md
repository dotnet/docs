---
title: C# formatting options
description: Learn about the code style options for formatting C# code files.
ms.date: 12/13/2022
ms.topic: reference
dev_langs:
- CSharp
---
# C# formatting options

The formatting options in this article apply only to C# code. These are options for code-style rule [IDE0055](ide0055.md).

## New-line options

The new-line options concern the use of new lines to format code.

- [csharp_new_line_before_open_brace](#csharp_new_line_before_open_brace)
- [csharp_new_line_before_else](#csharp_new_line_before_else)
- [csharp_new_line_before_catch](#csharp_new_line_before_catch)
- [csharp_new_line_before_finally](#csharp_new_line_before_finally)
- [csharp_new_line_before_members_in_object_initializers](#csharp_new_line_before_members_in_object_initializers)
- [csharp_new_line_before_members_in_anonymous_types](#csharp_new_line_before_members_in_anonymous_types)
- [csharp_new_line_between_query_expression_clauses](#csharp_new_line_between_query_expression_clauses)

Example *.editorconfig* file:

```ini
#  CSharp formatting rules:
[*.cs]
csharp_new_line_before_open_brace = methods, properties, control_blocks, types
csharp_new_line_before_else = true
csharp_new_line_before_catch = true
csharp_new_line_before_finally = true
csharp_new_line_before_members_in_object_initializers = true
csharp_new_line_before_members_in_anonymous_types = true
csharp_new_line_between_query_expression_clauses = true
```

### csharp_new_line_before_open_brace

This option concerns whether an open brace `{` should be placed on the same line as the preceding code, or on a new line. For this rule, you specify **all**, **none**, or one or more code elements such as **methods** or **properties**, to define when this rule should be applied. To specify multiple code elements, separate them with a comma (,).

| Property                 | Value                             | Description                                                              |
|--------------------------|-----------------------------------|--------------------------------------------------------------------------|
| **Option name**          | csharp_new_line_before_open_brace |                                                                          |
| **Applicable languages** | C#                                |                                                                          |
| **Introduced version**   | Visual Studio 2017                |                                                                          |
| **Option values**        | `all`                             | Require braces to be on a new line for all expressions ("Allman" style). |
|                          | `none`                            | Require braces to be on the same line for all expressions ("K&R").       |
|                          | `accessors`, `anonymous_methods`, `anonymous_types`, `control_blocks`, `events`, `indexers`,</br>`lambdas`, `local_functions`, `methods`, `object_collection_array_initializers`, `properties`, `types` | Require braces to be on a new line for the specified code element ("Allman" style). |
| **Default option value** | `all`                             |                                                                          |

Code examples:

```csharp
// csharp_new_line_before_open_brace = all
void MyMethod()
{
    if (...)
    {
        ...
    }
}

// csharp_new_line_before_open_brace = none
void MyMethod() {
    if (...) {
        ...
    }
}
```

### csharp_new_line_before_else

| Property                 | Value                           | Description                               |
| ------------------------ | ------------------------------- | ----------------------------------------- |
| **Option name**          | csharp_new_line_before_else     |                                           |
| **Applicable languages** | C#                              |                                           |
| **Introduced version**   | Visual Studio 2017              |                                           |
| **Option values**        | `true`                          | Place `else` statements on a new line.    |
|                          | `false`                         | Place `else` statements on the same line. |
| **Default option value** | `true`                          |                                           |

Code examples:

```csharp
// csharp_new_line_before_else = true
if (...) {
    ...
}
else {
    ...
}

// csharp_new_line_before_else = false
if (...) {
    ...
} else {
    ...
}
```

### csharp_new_line_before_catch

| Property                 | Value                           | Description                                |
| ------------------------ | ------------------------------- | ------------------------------------------ |
| **Option name**          | csharp_new_line_before_catch    |                                            |
| **Applicable languages** | C#                              |                                            |
| **Introduced version**   | Visual Studio 2017 |                                            |
| **Option values**        | `true`                          | Place `catch` statements on a new line.    |
|                          | `false`                         | Place `catch` statements on the same line. |
| **Default option value** | `true`                          |                                            |

Code examples:

```csharp
// csharp_new_line_before_catch = true
try {
    ...
}
catch (Exception e) {
    ...
}

// csharp_new_line_before_catch = false
try {
    ...
} catch (Exception e) {
    ...
}
```

### csharp_new_line_before_finally

| Property                 | Value                           | Description                                                               |
| ------------------------ | ------------------------------- | ------------------------------------------------------------------------- |
| **Option name**          | csharp_new_line_before_finally  |                                                                           |
| **Applicable languages** | C#                              |                                                                           |
| **Introduced version**   | Visual Studio 2017 |                                                                           |
| **Option values**        | `true`                          | Require `finally` statements to be on a new line after the closing brace. |
|                          | `false`                         | Require `finally` statements to be on the same line as the closing brace. |
| **Default option value** | `true`                          |                                                                           |

Code examples:

```csharp
// csharp_new_line_before_finally = true
try {
    ...
}
catch (Exception e) {
    ...
}
finally {
    ...
}

// csharp_new_line_before_finally = false
try {
    ...
} catch (Exception e) {
    ...
} finally {
    ...
}
```

### csharp_new_line_before_members_in_object_initializers

| Property                 | Value                                                 | Description                                                    |
| ------------------------ | ----------------------------------------------------- | -------------------------------------------------------------- |
| **Option name**          | csharp_new_line_before_members_in_object_initializers |                                                                |
| **Applicable languages** | C#                                                    |                                                                |
| **Introduced version**   | Visual Studio 2017                                    |                                                                |
| **Option values**        | `true`                                                | Require members of object initializers to be on separate lines |
|                          | `false`                                               | Require members of object initializers to be on the same line  |
| **Default option value** | `true`                                                |                                                                |

Code examples:

```csharp
// csharp_new_line_before_members_in_object_initializers = true
var z = new B()
{
    A = 3,
    B = 4
}

// csharp_new_line_before_members_in_object_initializers = false
var z = new B()
{
    A = 3, B = 4
}
```

### csharp_new_line_before_members_in_anonymous_types

| Property                 | Value                                             | Description                                                |
| ------------------------ | ------------------------------------------------- | ---------------------------------------------------------- |
| **Option name**          | csharp_new_line_before_members_in_anonymous_types |                                                            |
| **Applicable languages** | C#                                                |                                                            |
| **Introduced version**   | Visual Studio 2017                                |                                                            |
| **Option values**        | `true`                                            | Require members of anonymous types to be on separate lines |
|                          | `false`                                           | Require members of anonymous types to be on the same line  |
| **Default option value** | `true`                                            |                                                            |

Code examples:

```csharp
// csharp_new_line_before_members_in_anonymous_types = true
var z = new
{
    A = 3,
    B = 4
}

// csharp_new_line_before_members_in_anonymous_types = false
var z = new
{
    A = 3, B = 4
}
```

### csharp_new_line_between_query_expression_clauses

| Property                 | Value                                            | Description                                                          |
| ------------------------ | ------------------------------------------------ | -------------------------------------------------------------------- |
| **Option name**          | csharp_new_line_between_query_expression_clauses |                                                                      |
| **Applicable languages** | C#                                               |                                                                      |
| **Introduced version**   | Visual Studio 2017                               |                                                                      |
| **Option values**        | `true`                                           | Require elements of query expression clauses to be on separate lines |
|                          | `false`                                          | Require elements of query expression clauses to be on the same line  |
| **Default option value** | `true`                                           |                                                                      |

Code examples:

```csharp
// csharp_new_line_between_query_expression_clauses = true
var q = from a in e
        from b in e
        select a * b;

// csharp_new_line_between_query_expression_clauses = false
var q = from a in e from b in e
        select a * b;
```

## Indentation options

The indentation options concern the use of indentation to format code.

- [csharp_indent_case_contents](#csharp_indent_case_contents)
- [csharp_indent_switch_labels](#csharp_indent_switch_labels)
- [csharp_indent_labels](#csharp_indent_labels)
- [csharp_indent_block_contents](#csharp_indent_block_contents)
- [csharp_indent_braces](#csharp_indent_braces)
- [csharp_indent_case_contents_when_block](#csharp_indent_case_contents_when_block)

Example *.editorconfig* file:

```ini
#  CSharp formatting rules:
[*.cs]
csharp_indent_case_contents = true
csharp_indent_switch_labels = true
csharp_indent_labels = flush_left
csharp_indent_block_contents = true
csharp_indent_braces = false
csharp_indent_case_contents_when_block = true
```

### csharp_indent_case_contents

| Property                 | Value                           | Description                          |
| ------------------------ | ------------------------------- | ------------------------------------ |
| **Option name**          | csharp_indent_case_contents     |                                      |
| **Applicable languages** | C#                              |                                      |
| **Introduced version**   | Visual Studio 2017              |                                      |
| **Option values**        | `true`                          | Indent `switch` case contents        |
|                          | `false`                         | Do not indent `switch` case contents |
| **Default option value** | `true`                          |                                      |

Code examples:

```csharp
// csharp_indent_case_contents = true
switch(c) {
    case Color.Red:
        Console.WriteLine("The color is red");
        break;
    case Color.Blue:
        Console.WriteLine("The color is blue");
        break;
    default:
        Console.WriteLine("The color is unknown.");
        break;
}

// csharp_indent_case_contents = false
switch(c) {
    case Color.Red:
    Console.WriteLine("The color is red");
    break;
    case Color.Blue:
    Console.WriteLine("The color is blue");
    break;
    default:
    Console.WriteLine("The color is unknown.");
    break;
}
```

### csharp_indent_switch_labels

| Property                 | Value                           | Description                   |
| ------------------------ | ------------------------------- | ----------------------------- |
| **Option name**          | csharp_indent_switch_labels     |                               |
| **Applicable languages** | C#                              |                               |
| **Introduced version**   | Visual Studio 2017              |                               |
| **Option values**        | `true`                          | Indent `switch` labels        |
|                          | `false`                         | Do not indent `switch` labels |
| **Default option value** | `true`                          |                               |

Code examples:

```csharp
// csharp_indent_switch_labels = true
switch(c) {
    case Color.Red:
        Console.WriteLine("The color is red");
        break;
    case Color.Blue:
        Console.WriteLine("The color is blue");
        break;
    default:
        Console.WriteLine("The color is unknown.");
        break;
}

// csharp_indent_switch_labels = false
switch(c) {
case Color.Red:
    Console.WriteLine("The color is red");
    break;
case Color.Blue:
    Console.WriteLine("The color is blue");
    break;
default:
    Console.WriteLine("The color is unknown.");
    break;
}
```

### csharp_indent_labels

| Property                 | Value                           | Description                                                 |
| ------------------------ | ------------------------------- | ----------------------------------------------------------- |
| **Option name**          | csharp_indent_labels            |                                                             |
| **Applicable languages** | C#                              |                                                             |
| **Introduced version**   | Visual Studio 2017              |                                                             |
| **Option values**        | `flush_left`                    | Labels are placed at the leftmost column                    |
|                          | `one_less_than_current`         | Labels are placed at one less indent to the current context |
|                          | `no_change`                     | Labels are placed at the same indent as the current context |
| **Default option value** | `one_less_than_current`         |                                                             |

Code examples:

```csharp
// csharp_indent_labels= flush_left
class C
{
    private string MyMethod(...)
    {
        if (...) {
            goto error;
        }
error:
        throw new Exception(...);
    }
}

// csharp_indent_labels = one_less_than_current
class C
{
    private string MyMethod(...)
    {
        if (...) {
            goto error;
        }
    error:
        throw new Exception(...);
    }
}

// csharp_indent_labels= no_change
class C
{
    private string MyMethod(...)
    {
        if (...) {
            goto error;
        }
        error:
        throw new Exception(...);
    }
}
```

### csharp_indent_block_contents

| Property                 | Value                        | Description                  |
| ------------------------ | ---------------------------- | ---------------------------- |
| **Option name**          | csharp_indent_block_contents |                              |
| **Applicable languages** | C#                           |                              |
| **Option values**        | `true`                       | Indent block contents.       |
|                          | `false`                      | Don't indent block contents. |
| **Default option value** | `true`                       |                              |

Code examples:

```csharp
// csharp_indent_block_contents = true
static void Hello()
{
    Console.WriteLine("Hello");
}

// csharp_indent_block_contents = false
static void Hello()
{
Console.WriteLine("Hello");
}
```

### csharp_indent_braces

| Property                 | Value                | Description                |
| ------------------------ | -------------------- | -------------------------- |
| **Option name**          | csharp_indent_braces |                            |
| **Applicable languages** | C#                   |                            |
| **Option values**        | `true`               | Indent curly braces.       |
|                          | `false`              | Don't indent curly braces. |
| **Default option value** | `false`              |                            |

Code examples:

```csharp
// csharp_indent_braces = true
static void Hello()
    {
    Console.WriteLine("Hello");
    }

// csharp_indent_braces = false
static void Hello()
{
    Console.WriteLine("Hello");
}
```

### csharp_indent_case_contents_when_block

| Property                 | Value                                  | Description                                                                                           |
| ------------------------ | -------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| **Option name**          | csharp_indent_case_contents_when_block |                                                                                                       |
| **Applicable languages** | C#                                     |                                                                                                       |
| **Option values**        | `true`                                 | When it's a block, indent the statement list and curly braces for a case in a switch statement.       |
|                          | `false`                                | When it's a block, don't indent the statement list and curly braces for a case in a switch statement. |
| **Default option value** | `true`                                 |                                                                                                       |

Code examples:

```csharp
// csharp_indent_case_contents_when_block = true
case 0:
    {
        Console.WriteLine("Hello");
        break;
    }

// csharp_indent_case_contents_when_block = false
case 0:
{
    Console.WriteLine("Hello");
    break;
}
```

## Spacing options

The spacing options concern the use of space characters to format code.

- [csharp_space_after_cast](#csharp_space_after_cast)
- [csharp_space_after_keywords_in_control_flow_statements](#csharp_space_after_keywords_in_control_flow_statements)
- [csharp_space_between_parentheses](#csharp_space_between_parentheses)
- [csharp_space_before_colon_in_inheritance_clause](#csharp_space_before_colon_in_inheritance_clause)
- [csharp_space_after_colon_in_inheritance_clause](#csharp_space_after_colon_in_inheritance_clause)
- [csharp_space_around_binary_operators](#csharp_space_around_binary_operators)
- [csharp_space_between_method_declaration_parameter_list_parentheses](#csharp_space_between_method_declaration_parameter_list_parentheses)
- [csharp_space_between_method_declaration_empty_parameter_list_parentheses](#csharp_space_between_method_declaration_empty_parameter_list_parentheses)
- [csharp_space_between_method_declaration_name_and_open_parenthesis](#csharp_space_between_method_declaration_name_and_open_parenthesis)
- [csharp_space_between_method_call_parameter_list_parentheses](#csharp_space_between_method_call_parameter_list_parentheses)
- [csharp_space_between_method_call_empty_parameter_list_parentheses](#csharp_space_between_method_call_empty_parameter_list_parentheses)
- [csharp_space_between_method_call_name_and_opening_parenthesis](#csharp_space_between_method_call_name_and_opening_parenthesis)
- [csharp_space_after_comma](#csharp_space_after_comma)
- [csharp_space_before_comma](#csharp_space_before_comma)
- [csharp_space_after_dot](#csharp_space_after_dot)
- [csharp_space_before_dot](#csharp_space_before_dot)
- [csharp_space_after_semicolon_in_for_statement](#csharp_space_after_semicolon_in_for_statement)
- [csharp_space_before_semicolon_in_for_statement](#csharp_space_before_semicolon_in_for_statement)
- [csharp_space_around_declaration_statements](#csharp_space_around_declaration_statements)
- [csharp_space_before_open_square_brackets](#csharp_space_before_open_square_brackets)
- [csharp_space_between_empty_square_brackets](#csharp_space_between_empty_square_brackets)
- [csharp_space_between_square_brackets](#csharp_space_between_square_brackets)

Example *.editorconfig* file:

```ini
#  CSharp formatting rules:
[*.cs]
csharp_space_after_cast = true
csharp_space_after_keywords_in_control_flow_statements = true
csharp_space_between_parentheses = control_flow_statements, type_casts
csharp_space_before_colon_in_inheritance_clause = true
csharp_space_after_colon_in_inheritance_clause = true
csharp_space_around_binary_operators = before_and_after
csharp_space_between_method_declaration_parameter_list_parentheses = true
csharp_space_between_method_declaration_empty_parameter_list_parentheses = false
csharp_space_between_method_declaration_name_and_open_parenthesis = false
csharp_space_between_method_call_parameter_list_parentheses = true
csharp_space_between_method_call_empty_parameter_list_parentheses = false
csharp_space_between_method_call_name_and_opening_parenthesis = false
csharp_space_after_comma = true
csharp_space_before_comma = false
csharp_space_after_dot = false
csharp_space_before_dot = false
csharp_space_after_semicolon_in_for_statement = true
csharp_space_before_semicolon_in_for_statement = false
csharp_space_around_declaration_statements = false
csharp_space_before_open_square_brackets = false
csharp_space_between_empty_square_brackets = false
csharp_space_between_square_brackets = false
```

### csharp_space_after_cast

| Property                 | Value                           | Description                                          |
| ------------------------ | ------------------------------- | ---------------------------------------------------- |
| **Option name**          | csharp_space_after_cast         |                                                      |
| **Applicable languages** | C#                              |                                                      |
| **Introduced version**   | Visual Studio 2017              |                                                      |
| **Option values**        | `true`                          | Place a space character between a cast and the value |
|                          | `false`                         | Remove space between the cast and the value          |
| **Default option value** | `false`                         |                                                      |

Code examples:

```csharp
// csharp_space_after_cast = true
int y = (int) x;

// csharp_space_after_cast = false
int y = (int)x;
```

### csharp_space_after_keywords_in_control_flow_statements

| Property                 | Value                                                  | Description                                                                              |
| ------------------------ | ------------------------------------------------------ | ---------------------------------------------------------------------------------------- |
| **Option name**          | csharp_space_after_keywords_in_control_flow_statements |                                                                                          |
| **Applicable languages** | C#                                                     |                                                                                          |
| **Introduced version**   | Visual Studio 2017                                     |                                                                                          |
| **Option values**        | `true`                                                 | Place a space character after a keyword in a control flow statement such as a `for` loop |
|                          | `false`                                                | Remove space after a keyword in a control flow statement such as a `for` loop            |
| **Default option value** | `true`                                                 |                                                                                          |

Code examples:

```csharp
// csharp_space_after_keywords_in_control_flow_statements = true
for (int i;i<x;i++) { ... }

// csharp_space_after_keywords_in_control_flow_statements = false
for(int i;i<x;i++) { ... }
```

### csharp_space_between_parentheses

| Property                 | Value                            | Description                                                |
| ------------------------ | -------------------------------- | ---------------------------------------------------------- |
| **Option name**          | csharp_space_between_parentheses |                                                            |
| **Applicable languages** | C#                               |                                                            |
| **Introduced version**   | Visual Studio 2017               |                                                            |
| **Option values**        | `control_flow_statements`        | Place space between parentheses of control flow statements |
|                          | `expressions`                    | Place space between parentheses of expressions             |
|                          | `type_casts`                     | Place space between parentheses in type casts              |

If you omit this rule or use a value other than `control_flow_statements`, `expressions`, or `type_casts`, the setting is not applied.

Code examples:

```csharp
// csharp_space_between_parentheses = control_flow_statements
for ( int i = 0; i < 10; i++ ) { }

// csharp_space_between_parentheses = expressions
var z = ( x * y ) - ( ( y - x ) * 3 );

// csharp_space_between_parentheses = type_casts
int y = ( int )x;
```

### csharp_space_before_colon_in_inheritance_clause

| Property                 | Value                                           | Description                                                                            |
| ------------------------ | ----------------------------------------------- | -------------------------------------------------------------------------------------- |
| **Option name**          | csharp_space_before_colon_in_inheritance_clause |                                                                                        |
| **Applicable languages** | C#                                              |                                                                                        |
| **Introduced version**   | Visual Studio 2017                              |                                                                                        |
| **Option values**        | `true`                                          | Place a space character before the colon for bases or interfaces in a type declaration |
|                          | `false`                                         | Remove space before the colon for bases or interfaces in a type declaration            |
| **Default option value** | `true`                                          |                                                                                        |

Code examples:

```csharp
// csharp_space_before_colon_in_inheritance_clause = true
interface I
{

}

class C : I
{

}

// csharp_space_before_colon_in_inheritance_clause = false
interface I
{

}

class C: I
{

}
```

### csharp_space_after_colon_in_inheritance_clause

| Property                 | Value                                          | Description                                                                           |
| ------------------------ | ---------------------------------------------- | ------------------------------------------------------------------------------------- |
| **Option name**          | csharp_space_after_colon_in_inheritance_clause |                                                                                       |
| **Applicable languages** | C#                                             |                                                                                       |
| **Introduced version**   | Visual Studio 2017                             |                                                                                       |
| **Option values**        | `true`                                         | Place a space character after the colon for bases or interfaces in a type declaration |
|                          | `false`                                        | Remove space after the colon for bases or interfaces in a type declaration            |
| **Default option value** | `true`                                         |                                                                                       |

Code examples:

```csharp
// csharp_space_after_colon_in_inheritance_clause = true
interface I
{

}

class C : I
{

}

// csharp_space_after_colon_in_inheritance_clause = false
interface I
{

}

class C :I
{

}
```

### csharp_space_around_binary_operators

| Property                 | Value                                | Description                                        |
| ------------------------ | ------------------------------------ | -------------------------------------------------- |
| **Option name**          | csharp_space_around_binary_operators |                                                    |
| **Applicable languages** | C#                                   |                                                    |
| **Introduced version**   | Visual Studio 2017                   |                                                    |
| **Option values**        | `before_and_after`                   | Insert space before and after the binary operator  |
|                          | `none`                               | Remove spaces before and after the binary operator |
|                          | `ignore`                             | Ignore spaces around binary operators              |
| **Default option value** | `before_and_after`                   |                                                    |

Code examples:

```csharp
// csharp_space_around_binary_operators = before_and_after
return x * (x - y);

// csharp_space_around_binary_operators = none
return x*(x-y);

// csharp_space_around_binary_operators = ignore
return x  *  (x-y);
```

### csharp_space_between_method_declaration_parameter_list_parentheses

| Property                 | Value                                                              | Description |
|--------------------------|--------------------------------------------------------------------|-------------|
| **Option name**          | csharp_space_between_method_declaration_parameter_list_parentheses |             |
| **Applicable languages** | C#                                                                 |             |
| **Introduced version**   | Visual Studio 2017                                                 |             |
| **Option values**        | `true` | Place a space character after the opening parenthesis and before the closing parenthesis of a method declaration parameter list |
|                          | `false` | Remove space characters after the opening parenthesis and before the closing parenthesis of a method declaration parameter list |
| **Default option value** | `false`                                                            |             |

Code examples:

```csharp
// csharp_space_between_method_declaration_parameter_list_parentheses = true
void Bark( int x ) { ... }

// csharp_space_between_method_declaration_parameter_list_parentheses = false
void Bark(int x) { ... }
```

### csharp_space_between_method_declaration_empty_parameter_list_parentheses

| Property                 | Value                                                                    | Description  |
|--------------------------|--------------------------------------------------------------------------|--------------|
| **Option name**          | csharp_space_between_method_declaration_empty_parameter_list_parentheses |              |
| **Applicable languages** | C#                                                                       |              |
| **Introduced version**   | Visual Studio 2017                                                       |              |
| **Option values**        | `true` | Insert space within empty parameter list parentheses for a method declaration  |
|                          | `false` | Remove space within empty parameter list parentheses for a method declaration |
| **Default option value** | `false`                                                                  |              |

Code examples:

```csharp
// csharp_space_between_method_declaration_empty_parameter_list_parentheses = true
void Goo( )
{
    Goo(1);
}

void Goo(int x)
{
    Goo();
}

// csharp_space_between_method_declaration_empty_parameter_list_parentheses = false
void Goo()
{
    Goo(1);
}

void Goo(int x)
{
    Goo();
}
```

### csharp_space_between_method_declaration_name_and_open_parenthesis

| Property                 | Value                                                             | Description |
|--------------------------|-------------------------------------------------------------------|-------------|
| **Option name**          | csharp_space_between_method_declaration_name_and_open_parenthesis |             |
| **Applicable languages** | C#                                                                |             |
| **Option values**        | `true` | Place a space character between the method name and opening parenthesis in the method declaration |
|                          | `false` | Remove space characters between the method name and opening parenthesis in the method declaration |
| **Default option value** | `false` |                                                                                                   |

Code examples:

```csharp
// csharp_space_between_method_declaration_name_and_open_parenthesis = true
void M () { }

// csharp_space_between_method_declaration_name_and_open_parenthesis = false
void M() { }
```

### csharp_space_between_method_call_parameter_list_parentheses

| Property                 | Value                                                       | Description |
|--------------------------|-------------------------------------------------------------|-------------|
| **Option name**          | csharp_space_between_method_call_parameter_list_parentheses |             |
| **Applicable languages** | C#                                                          |             |
| **Introduced version**   | Visual Studio 2017                                          |             |
| **Option values**        | `true` | Place a space character after the opening parenthesis and before the closing parenthesis of a method call |
|                          | `false` | Remove space characters after the opening parenthesis and before the closing parenthesis of a method call |
| **Default option value** | `false` |                                                                                                           |

Code examples:

```csharp
// csharp_space_between_method_call_parameter_list_parentheses = true
MyMethod( argument );

// csharp_space_between_method_call_parameter_list_parentheses = false
MyMethod(argument);
```

### csharp_space_between_method_call_empty_parameter_list_parentheses

| Property                 | Value                                                             | Description                                         |
| ------------------------ | ----------------------------------------------------------------- | --------------------------------------------------- |
| **Option name**          | csharp_space_between_method_call_empty_parameter_list_parentheses |                                                     |
| **Applicable languages** | C#                                                                |                                                     |
| **Introduced version**   | Visual Studio 2017                                                |                                                     |
| **Option values**        | `true`                                                            | Insert space within empty argument list parentheses |
|                          | `false`                                                           | Remove space within empty argument list parentheses |
| **Default option value** | `false`                                                           |                                                     |

Code examples:

```csharp
// csharp_space_between_method_call_empty_parameter_list_parentheses = true
void Goo()
{
    Goo(1);
}

void Goo(int x)
{
    Goo( );
}

// csharp_space_between_method_call_empty_parameter_list_parentheses = false
void Goo()
{
    Goo(1);
}

void Goo(int x)
{
    Goo();
}
```

### csharp_space_between_method_call_name_and_opening_parenthesis

| Property                 | Value                                                         | Description                                                   |
| ------------------------ | ------------------------------------------------------------- | ------------------------------------------------------------- |
| **Option name**          | csharp_space_between_method_call_name_and_opening_parenthesis |                                                               |
| **Applicable languages** | C#                                                            |                                                               |
| **Introduced version**   | Visual Studio 2017                                            |                                                               |
| **Option values**        | `true`                                                        | Insert space between method call name and opening parenthesis |
|                          | `false`                                                       | Remove space between method call name and opening parenthesis |
| **Default option value** | `false`                                                       |                                                               |

Code examples:

```csharp
// csharp_space_between_method_call_name_and_opening_parenthesis = true
void Goo()
{
    Goo (1);
}

void Goo(int x)
{
    Goo ();
}

// csharp_space_between_method_call_name_and_opening_parenthesis = false
void Goo()
{
    Goo(1);
}

void Goo(int x)
{
    Goo();
}
```

### csharp_space_after_comma

| Property                 | Value                    | Description                |
| ------------------------ | ------------------------ | -------------------------- |
| **Option name**          | csharp_space_after_comma |                            |
| **Applicable languages** | C#                       |                            |
| **Option values**        | `true`                   | Insert space after a comma |
|                          | `false`                  | Remove space after a comma |
| **Default option value** | `true`                   |                            |

Code examples:

```csharp
// csharp_space_after_comma = true
int[] x = new int[] { 1, 2, 3, 4, 5 };

// csharp_space_after_comma = false
int[] x = new int[] { 1,2,3,4,5 };
```

### csharp_space_before_comma

| Property                 | Value                     | Description                 |
| ------------------------ | ------------------------- | --------------------------- |
| **Option name**          | csharp_space_before_comma |                             |
| **Applicable languages** | C#                        |                             |
| **Option values**        | `true`                    | Insert space before a comma |
|                          | `false`                   | Remove space before a comma |
| **Default option value** | `false`                   |                             |

Code examples:

```csharp
// csharp_space_before_comma = true
int[] x = new int[] { 1 , 2 , 3 , 4 , 5 };

// csharp_space_before_comma = false
int[] x = new int[] { 1, 2, 3, 4, 5 };
```

### csharp_space_after_dot

| Property                 | Value                  | Description              |
| ------------------------ | ---------------------- | ------------------------ |
| **Option name**          | csharp_space_after_dot |                          |
| **Applicable languages** | C#                     |                          |
| **Option values**        | `true`                 | Insert space after a dot |
|                          | `false`                | Remove space after a dot |
| **Default option value** | `false`                |                          |

Code examples:

```csharp
// csharp_space_after_dot = true
this. Goo();

// csharp_space_after_dot = false
this.Goo();
```

### csharp_space_before_dot

| Property                 | Value                   | Description               |
| ------------------------ | ----------------------- | ------------------------- |
| **Option name**          | csharp_space_before_dot |                           |
| **Applicable languages** | C#                      |                           |
| **Option values**        | `true`                  | Insert space before a dot |
|                          | `false`                 | Remove space before a dot |
| **Default option value** | `false`                 |                           |

Code examples:

```csharp
// csharp_space_before_dot = true
this .Goo();

// csharp_space_before_dot = false
this.Goo();
```

### csharp_space_after_semicolon_in_for_statement

| Property                 | Value                                         | Description                                            |
| ------------------------ | --------------------------------------------- | ------------------------------------------------------ |
| **Option name**          | csharp_space_after_semicolon_in_for_statement |                                                        |
| **Applicable languages** | C#                                            |                                                        |
| **Option values**        | `true`                                        | Insert space after each semicolon in a `for` statement |
|                          | `false`                                       | Remove space after each semicolon in a `for` statement |
| **Default option value** | `true`                                        |                                                        |

Code examples:

```csharp
// csharp_space_after_semicolon_in_for_statement = true
for (int i = 0; i < x.Length; i++)

// csharp_space_after_semicolon_in_for_statement = false
for (int i = 0;i < x.Length;i++)
```

### csharp_space_before_semicolon_in_for_statement

| Property                 | Value                                          | Description                                             |
| ------------------------ | ---------------------------------------------- | ------------------------------------------------------- |
| **Option name**          | csharp_space_before_semicolon_in_for_statement |                                                         |
| **Applicable languages** | C#                                             |                                                         |
| **Option values**        | `true`                                         | Insert space before each semicolon in a `for` statement |
|                          | `false`                                        | Remove space before each semicolon in a `for` statement |
| **Default option value** | `false`                                        |                                                         |

Code examples:

```csharp
// csharp_space_before_semicolon_in_for_statement = true
for (int i = 0 ; i < x.Length ; i++)

// csharp_space_before_semicolon_in_for_statement = false
for (int i = 0; i < x.Length; i++)
```

### csharp_space_around_declaration_statements

| Property                 | Value                                      | Description                                                   |
| ------------------------ | ------------------------------------------ | ------------------------------------------------------------- |
| **Option name**          | csharp_space_around_declaration_statements |                                                               |
| **Applicable languages** | C#                                         |                                                               |
| **Option values**        | `ignore`                                   | Don't remove extra space characters in declaration statements |
|                          | `false`                                    | Remove extra space characters in declaration statements       |
| **Default option value** | `false`                                    |                                                               |

Code examples:

```csharp
// csharp_space_around_declaration_statements = ignore
int    x    =    0   ;

// csharp_space_around_declaration_statements = false
int x = 0;
```

### csharp_space_before_open_square_brackets

| Property                 | Value                                    | Description                                     |
| ------------------------ | ---------------------------------------- | ----------------------------------------------- |
| **Option name**          | csharp_space_before_open_square_brackets |                                                 |
| **Applicable languages** | C#                                       |                                                 |
| **Option values**        | `true`                                   | Insert space before opening square brackets `[` |
|                          | `false`                                  | Remove space before opening square brackets `[` |
| **Default option value** | `false`                                  |                                                 |

Code examples:

```csharp
// csharp_space_before_open_square_brackets = true
int [] numbers = new int [] { 1, 2, 3, 4, 5 };

// csharp_space_before_open_square_brackets = false
int[] numbers = new int[] { 1, 2, 3, 4, 5 };
```

### csharp_space_between_empty_square_brackets

| Property                 | Value                                      | Description                                      |
| ------------------------ | ------------------------------------------ | ------------------------------------------------ |
| **Option name**          | csharp_space_between_empty_square_brackets |                                                  |
| **Applicable languages** | C#                                         |                                                  |
| **Option values**        | `true`                                     | Insert space between empty square brackets `[ ]` |
|                          | `false`                                    | Remove space between empty square brackets `[]`  |
| **Default option value** | `false`                                    |                                                  |

Code examples:

```csharp
// csharp_space_between_empty_square_brackets = true
int[ ] numbers = new int[ ] { 1, 2, 3, 4, 5 };

// csharp_space_between_empty_square_brackets = false
int[] numbers = new int[] { 1, 2, 3, 4, 5 };
```

### csharp_space_between_square_brackets

| Property                 | Value                                | Description                                                  |
| ------------------------ | ------------------------------------ | ------------------------------------------------------------ |
| **Option name**          | csharp_space_between_square_brackets |                                                              |
| **Applicable languages** | C#                                   |                                                              |
| **Option values**        | `true`                               | Insert space characters in non-empty square brackets `[ 0 ]` |
|                          | `false`                              | Remove space characters in non-empty square brackets `[0]`   |
| **Default option value** | `false`                              |                                                              |

Code examples:

```csharp
// csharp_space_between_square_brackets = true
int index = numbers[ 0 ];

// csharp_space_between_square_brackets = false
int index = numbers[0];
```

## Wrap options

The wrap formatting options concern the use of single lines versus separate lines for statements and code blocks.

- [csharp_preserve_single_line_statements](#csharp_preserve_single_line_statements)
- [csharp_preserve_single_line_blocks](#csharp_preserve_single_line_blocks)

Example *.editorconfig* file:

```ini
#  CSharp formatting rules:
[*.cs]
csharp_preserve_single_line_statements = true
csharp_preserve_single_line_blocks = true
```

### csharp_preserve_single_line_statements

| Property                 | Value                                  | Description                                                 |
| ------------------------ | -------------------------------------- | ----------------------------------------------------------- |
| **Option name**          | csharp_preserve_single_line_statements |                                                             |
| **Applicable languages** | C#                                     |                                                             |
| **Introduced version**   | Visual Studio 2017                     |                                                             |
| **Option values**        | `true`                                 | Leave statements and member declarations on the same line   |
|                          | `false`                                | Leave statements and member declarations on different lines |
| **Default option value** | `true`                                 |                                                             |

Code examples:

```csharp
//csharp_preserve_single_line_statements = true
int i = 0; string name = "John";

//csharp_preserve_single_line_statements = false
int i = 0;
string name = "John";
```

### csharp_preserve_single_line_blocks

| Property                 | Value                              | Description                        |
| ------------------------ | ---------------------------------- | ---------------------------------- |
| **Option name**          | csharp_preserve_single_line_blocks |                                    |
| **Applicable languages** | C#                                 |                                    |
| **Introduced version**   | Visual Studio 2017                 |                                    |
| **Option values**        | `true`                             | Leave code block on single line    |
|                          | `false`                            | Leave code block on separate lines |
| **Default option value** | `true`                             |                                    |

Code examples:

```csharp
//csharp_preserve_single_line_blocks = true
public int Foo { get; set; }

//csharp_preserve_single_line_blocks = false
public int MyProperty
{
    get; set;
}
```

## See also

- [Formatting rule (IDE0055)](ide0055.md)
