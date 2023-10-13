---
title: Errors and warnings associated with reference parameter modifiers
description: The compiler issues these errors and warnings when you have used the reference parameter modifiers incorrectly. They indicate you've got some mismatch between the modifier on the parameter, the argument, or the use of the parameter in the method.
f1_keywords:
  - "CS9190"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9199"
  - "CS9200"
helpviewer_keywords:
  - "CS9190"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9199"
  - "CS9200"
ms.date: 10/16/2023
---
# Errors and warnings associated with reference parameters, variables, and returns

The following errors may be generated when source generators or interceptors are loaded during a compilation:

- **CS9190**: `readonly` modifier must be specified after `ref`.
- **CS9199**: A ref readonly parameter cannot have the Out attribute.

The following warnings may be generated when source generators or interceptors are loaded during a compilation:

- **CS9191**: The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.
- **CS9192**: Argument should be passed with `ref` or `in` keyword.
- **CS9193**: Argument should be a variable because it is passed to a `ref readonly` parameter
- **CS9195**: Argument should be passed with the `in` keyword
- **CS9196**: Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.
- **CS9197**: Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.
- **CS9198**: Reference kind modifier of parameter doesn't match the corresponding parameter in target.
- **CS9200**: A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.

These errors and warnings follow these themes:
