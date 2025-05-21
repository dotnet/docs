---
title: Write tests with MSTest
description: Learn how to write tests using MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 07/18/2024
ms.topic: article
---

# Write tests with MSTest

In this article, you will learn about the APIs and conventions used by MSTest to help you write and shape your tests.

## Attributes

MSTest uses custom attributes to identify and customize tests.

To help provide a clearer overview of the testing framework, this section organizes the members of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace into groups of related functionality.

> [!NOTE]
> Attribute elements, whose names end with "Attribute", can be used with or without "Attribute" at the end. Attributes that have parameterless constructor, can be written with or without parenthesis.
> The following code examples work identically:
>
> `[TestClass()]`
>
> `[TestClassAttribute()]`
>
> `[TestClass]`
>
> `[TestClassAttribute]`

MSTest attributes are divided into the following categories:

- [Attributes used to identify test classes and methods](./unit-testing-mstest-writing-tests-attributes.md#attributes-used-to-identify-test-classes-and-methods)
- [Attributes used for data-driven testing](./unit-testing-mstest-writing-tests-attributes.md#attributes-used-for-data-driven-testing)
- [Attributes used to provide initialization and cleanups](./unit-testing-mstest-writing-tests-attributes.md#attributes-used-to-provide-initialization-and-cleanups)
- [Attributes used to control test execution](./unit-testing-mstest-writing-tests-attributes.md#attributes-used-to-control-test-execution)
- [Utilities attributes](./unit-testing-mstest-writing-tests-attributes.md#utilities-attributes)
- [Metadata attributes](./unit-testing-mstest-writing-tests-attributes.md#metadata-attributes)

## Assertions

Use the Assert classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises the code of a method in your application's code, but it reports the correctness of the code's behavior only if you include Assert statements.

MSTest assertions are divided into the following classes:

- [The `Assert` class](./unit-testing-mstest-writing-tests-assertions.md#the-assert-class)
- [The `StringAssert` class](./unit-testing-mstest-writing-tests-assertions.md#the-stringassert-class)
- [The `CollectionAssert` class](./unit-testing-mstest-writing-tests-assertions.md#the-collectionassert-class)

## The `TestContext` class

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> class provides contextual information and support for test execution, making it easier to retrieve information about the test run and manipulate aspects of the environment. It's defined in the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace and is available when using the MSTest Framework.

For more information, see [Accessing the `TestContext` object](./unit-testing-mstest-writing-tests-testcontext.md#accessing-the-testcontext-object) or [The `TestContext` members](./unit-testing-mstest-writing-tests-testcontext.md#the-testcontext-members).

## Testing private members

You can generate a test for a private method. This generation creates a private accessor class, which instantiates an object of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject> class. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject> class is a wrapper class that uses reflection as part of the private accessor process. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType> class is similar, but is used for calling private static methods instead of calling private instance methods.

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType>
