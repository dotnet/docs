---
title: Versioning
description: Understand how versioning works in C# and .NET
ms.date: 09/17/2024
ms.subservice: advanced-concepts
---

# Versioning in C\#

In this tutorial you'll learn what versioning means in .NET. You'll also learn the factors to consider when versioning your library as well as upgrading to a new version of a library.

## Language version

The C# compiler is part of the .NET SDK. By default, the compiler chooses the C# language version that matches the chosen [TFM](../standard/frameworks.md) for your project. If the SDK version is greater than your chosen framework, the compiler could use a greater language version. You can change the default by setting the `LangVersion` element in your project. You can learn how in our article on [compiler options](language-reference/compiler-options/language.md#langversion).

> [!WARNING]
>
> Setting the `LangVersion` element to `latest` is discouraged. The `latest` setting means the installed compiler uses its latest version. That can change from machine to machine, making builds unreliable. In addition, it enables language features that may require runtime or library features not included in the current SDK.

## Authoring Libraries

As a developer who has created .NET libraries for public use, you've most likely been in situations where you have to roll out new updates. How you go about this process matters a lot as you need to ensure that there's a seamless transition of existing code to the new version of your library. Here are several things to consider when creating a new release:

### Semantic Versioning

[Semantic versioning](https://semver.org/) (SemVer for short) is a naming convention applied to versions of your library to signify specific milestone events.
Ideally, the version information you give your library should help developers determine the compatibility with their projects that make use of older versions of that same library.

The most basic approach to SemVer is the 3 component format `MAJOR.MINOR.PATCH`, where:

- `MAJOR` is incremented when you make incompatible API changes
- `MINOR` is incremented when you add functionality in a backwards-compatible manner
- `PATCH` is incremented when you make backwards-compatible bug fixes

#### Understand version increments with examples

To help clarify when to increment each version number, here are concrete examples:

### MAJOR version increments (incompatible API changes)

These changes require users to modify their code to work with the new version:

- Removing a public method or property:

  ```csharp
  // Version 1.0.0
  public class Calculator
  {
      public int Add(int a, int b) => a + b;
      public int Subtract(int a, int b) => a - b; // This method exists
  }

  // Version 2.0.0 - MAJOR increment required
  public class Calculator
  {
      public int Add(int a, int b) => a + b;
      // Subtract method removed - breaking change!
  }
  ```

- Changing method signatures:

  ```csharp
  // Version 1.0.0
  public void SaveFile(string filename) { }

  // Version 2.0.0 - MAJOR increment required
  public void SaveFile(string filename, bool overwrite) { } // Added required parameter
  ```

- Changing the behavior of existing methods in ways that break expectations:

  ```csharp
  // Version 1.0.0 - returns null when file not found
  public string ReadFile(string path) => File.Exists(path) ? File.ReadAllText(path) : null;

  // Version 2.0.0 - MAJOR increment required
  public string ReadFile(string path) => File.ReadAllText(path); // Now throws exception when file not found
  ```

### MINOR version increments (backwards-compatible functionality)

These changes add new features without breaking existing code:

- Adding new public methods or properties:

  ```csharp
  // Version 1.0.0
  public class Calculator
  {
      public int Add(int a, int b) => a + b;
  }

  // Version 1.1.0 - MINOR increment
  public class Calculator
  {
      public int Add(int a, int b) => a + b;
      public int Multiply(int a, int b) => a * b; // New method added
  }
  ```

- Adding new overloads:

  ```csharp
  // Version 1.0.0
  public void Log(string message) { }

  // Version 1.1.0 - MINOR increment
  public void Log(string message) { } // Original method unchanged
  public void Log(string message, LogLevel level) { } // New overload added
  ```

- Adding optional parameters to existing methods:

  ```csharp
  // Version 1.0.0
  public void SaveFile(string filename) { }

  // Version 1.1.0 - MINOR increment
  public void SaveFile(string filename, bool overwrite = false) { } // Optional parameter
  ```

  > [!NOTE]
  > This is a *source compatible change*, but a *binary breaking change*. Users of this library must recompile for it to work correctly. Many libraries would consider this only in *major* version changes, not *minor* version changes.

### PATCH version increments (backwards-compatible bug fixes)

These changes fix issues without adding new features or breaking existing functionality:

- Fixing a bug in an existing method's implementation:

  ```csharp
  // Version 1.0.0 - has a bug
  public int Divide(int a, int b)
  {
      return a / b; // Bug: doesn't handle division by zero
  }

  // Version 1.0.1 - PATCH increment
  public int Divide(int a, int b)
  {
      if (b == 0) throw new ArgumentException("Cannot divide by zero");
      return a / b; // Bug fixed, behavior improved but API unchanged
  }
  ```

- Performance improvements that don't change the API:

  ```csharp
  // Version 1.0.0
  public List<int> SortNumbers(List<int> numbers)
  {
      return numbers.OrderBy(x => x).ToList(); // Slower implementation
  }

  // Version 1.0.1 - PATCH increment
  public List<int> SortNumbers(List<int> numbers)
  {
      var result = new List<int>(numbers);
      result.Sort(); // Faster implementation, same API
      return result;
  }
  ```

The key principle is: if existing code can use your new version without any changes, it's a MINOR or PATCH update. If existing code needs to be modified to work with your new version, it's a MAJOR update.

There are also ways to specify other scenarios, for example, pre-release versions, when applying version information to your .NET library.

### Backwards Compatibility

As you release new versions of your library, backwards compatibility with previous versions will most likely be one of your major concerns.
A new version of your library is source compatible with a previous version if code that depends on the previous version can, when recompiled, work with the new version.
A new version of your library is binary compatible if an application that depended on the old version can, without recompilation, work with the new version.

Here are some things to consider when trying to maintain backwards compatibility with older versions of your library:

- Virtual methods: When you make a virtual method non-virtual in your new version it means that projects that override that method
will have to be updated. This is a huge breaking change and is strongly discouraged.
- Method signatures: When updating a method behavior requires you to change its signature as well, you should instead create an overload so that code calling into that method will still work.
You can always manipulate the old method signature to call into the new method signature so that implementation remains consistent.
- [Obsolete attribute](language-reference/attributes/general.md#obsolete-and-deprecated-attribute): You can use this attribute in your code to specify classes or class members that are deprecated and likely to be removed in future versions. This ensures developers utilizing your library are better prepared for breaking changes.
- Optional Method Arguments: When you make previously optional method arguments compulsory or change their default value then all code that does not supply those arguments will need to be updated.

> [!NOTE]
> Making compulsory arguments optional should have very little effect especially if it doesn't change the method's behavior.

The easier you make it for your users to upgrade to the new version of your library, the more likely that they will upgrade sooner.

### Application Configuration File

As a .NET developer there's a very high chance you've encountered [the `app.config` file](../framework/configure-apps/file-schema/index.md) present in most project types.
This simple configuration file can go a long way into improving the rollout of new updates. You should generally design your libraries in such a way that information that is likely to change regularly is stored in the `app.config` file, this way when such information is updated, the config file of older versions just needs to be replaced with the new one without the need for recompilation of the library.

## Consuming Libraries

As a developer that consumes .NET libraries built by other developers you're most likely aware that a new version of a library might not be fully compatible with your project and you might often find yourself having to update your code to work with those changes.

Lucky for you, C# and the .NET ecosystem comes with features and techniques that allow us to easily update our app to work with new versions of libraries that might introduce breaking changes.

### Assembly Binding Redirection

You can use the *app.config* file to update the version of a library your app uses. By adding what is called a [*binding redirect*](../framework/configure-apps/redirect-assembly-versions.md), you can use the new library version without having to recompile your app. The following example shows how you would update your app's *app.config* file to use the `1.0.1` patch version of `ReferencedLibrary` instead of the `1.0.0` version it was originally compiled with.

```xml
<dependentAssembly>
    <assemblyIdentity name="ReferencedLibrary" publicKeyToken="32ab4ba45e0a69a1" culture="en-us" />
    <bindingRedirect oldVersion="1.0.0" newVersion="1.0.1" />
</dependentAssembly>
```

> [!NOTE]
> This approach will only work if the new version of `ReferencedLibrary` is binary compatible with your app.
> See the [Backwards Compatibility](#backwards-compatibility) section above for changes to look out for when determining compatibility.

### new

You use the `new` modifier to hide inherited members of a base class. This is one way derived classes can respond to updates in base classes.

Take the following example:

[!code-csharp[Sample usage of the 'new' modifier](~/samples/snippets/csharp/versioning/new/Program.cs#sample)]

**Output**

```console
A base method
A derived method
```

From the example above you can see how `DerivedClass` hides the `MyMethod` method present in `BaseClass`.
This means that when a base class in the new version of a library adds a member that already exists in your derived class, you can simply use the `new` modifier on your derived class member to hide the base class member.

When no `new` modifier is specified, a derived class will by default hide conflicting members in a base class, although a compiler warning will be generated the code will still compile. This means that simply adding new members to an existing class makes that new version of your library both source and binary compatible with code that depends on it.

### override

The `override` modifier means a derived implementation extends the implementation of a base class member rather than
hides it. The base class member needs to have the `virtual` modifier applied to it.

[!code-csharp[Sample usage of the 'override' modifier](../../samples/snippets/csharp/versioning/override/Program.cs#sample)]

**Output**

```console
Base Method One: Method One
Derived Method One: Derived Method One
```

The `override` modifier is evaluated at compile time and the compiler will throw an error if it doesn't find a virtual member to override.

Your knowledge of the discussed techniques and your understanding of the situations in which to use them, will go a long way towards easing the transition between versions of a library.
