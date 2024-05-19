---
title: System.InvalidOperationException class
description: Learn about the System.InvalidOperationException class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
  - FSharp
---
# System.InvalidOperationException class

[!INCLUDE [context](includes/context.md)]

<xref:System.InvalidOperationException> is used in cases when the failure to invoke a method is caused by reasons other than invalid arguments. Typically, it's thrown when the state of an object cannot support the method call. For example, an <xref:System.InvalidOperationException> exception is thrown by methods such as:

- <xref:System.Collections.IEnumerator.MoveNext%2A?displayProperty=nameWithType> if objects of a collection are modified after the enumerator is created. For more information, see [Changing a collection while iterating it](#changing-a-collection-while-iterating-it).
- <xref:System.Resources.ResourceSet.GetString%2A?displayProperty=nameWithType> if the resource set is closed before the method call is made.
- <xref:System.Xml.Linq.XContainer.Add%2A?displayProperty=nameWithType>, if the object or objects to be added would result in an incorrectly structured XML document.
- A method that attempts to manipulate the UI from a thread that is not the main or UI thread.

> [!IMPORTANT]
> Because the <xref:System.InvalidOperationException> exception can be thrown in a wide variety of circumstances, it is important to read the exception message returned by the <xref:System.Exception.Message> property.

<xref:System.InvalidOperationException> uses the HRESULT `COR_E_INVALIDOPERATION`, which has the value 0x80131509.

For a list of initial property values for an instance of <xref:System.InvalidOperationException>, see the <xref:System.InvalidOperationException.%23ctor%2A> constructors.

## Common causes of InvalidOperationException exceptions

The following sections show how some common cases in which in <xref:System.InvalidOperationException> exception is thrown in an app. How you handle the issue depends on the specific situation. Most commonly, however, the exception results from developer error, and the <xref:System.InvalidOperationException> exception can be anticipated and avoided.

### Updating a UI thread from a non-UI thread

Often, worker threads are used to perform some background work that involves gathering data to be displayed in an application's user interface. However. most GUI (graphical user interface) application frameworks for .NET, such as Windows Forms and Windows Presentation Foundation (WPF), let you access GUI objects only from the thread that creates and manages the UI (the Main or UI thread). An <xref:System.InvalidOperationException> is thrown when you try to access a UI element from a thread other than the UI thread. The text of the exception message is shown in the following table.

|Application Type|Message|
|----------------------|-------------|
|WPF app|**The calling thread cannot access this object because a different thread owns it.**|
|UWP app|**The application called an interface that was marshaled for a different thread.**|
|Windows Forms app|**Cross-thread operation not valid: Control 'TextBox1' accessed from a thread other than the thread it was created on.**|

UI frameworks for .NET implement a *dispatcher* pattern that includes a method to check whether a call to a member of a UI element is being executed on the UI thread, and other methods to schedule the call on the UI thread:

- In WPF apps, call the <xref:System.Windows.Threading.Dispatcher.CheckAccess%2A?displayProperty=nameWithType> method to determine if a method is running on a non-UI thread. It returns `true` if the method is running on the UI thread and `false` otherwise. Call one of the overloads of the <xref:System.Windows.Threading.Dispatcher.Invoke%2A?displayProperty=nameWithType> method to schedule the call on the UI thread.
- In UWP apps, check the <xref:Windows.UI.Core.CoreDispatcher.HasThreadAccess?displayProperty=nameWithType> property to determine if a method is running on a non-UI thread. Call the <xref:Windows.UI.Core.CoreDispatcher.RunAsync%2A?displayProperty=nameWithType> method to execute a delegate that updates the UI thread.
- In Windows Forms apps, use the <xref:System.Windows.Forms.Control.InvokeRequired?displayProperty=nameWithType> property to determine if a method is running on a non-UI thread. Call one of the overloads of the <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=nameWithType> method to execute a delegate that updates the UI thread.

The following examples illustrate the <xref:System.InvalidOperationException> exception that is thrown when you attempt to update a UI element from a thread other than the thread that created it. Each example requires that you create two controls:

- A text box control named `textBox1`. In a Windows Forms app, you should set its <xref:System.Windows.Forms.TextBox.Multiline> property to `true`.
- A button control named `threadExampleBtn`. The example provides a handler, `ThreadsExampleBtn_Click`, for the button's `Click` event.

In each case, the `threadExampleBtn_Click` event handler calls the `DoSomeWork` method twice. The first call runs synchronously and succeeds. But the second call, because it runs asynchronously on a thread pool thread, attempts to update the UI from a non-UI thread. This results in a <xref:System.InvalidOperationException> exception.

#### WPF apps

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/WPF1/MainWindow.xaml.cs" id="Snippet1":::

The following version of the `DoSomeWork` method eliminates the exception in a WPF app.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/WPF2/MainWindowDispatcher.xaml.cs" id="Snippet3":::

#### Windows Forms apps

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/WinForms/Form1.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/WinForms/Form1.vb" id="Snippet2":::

The following version of the `DoSomeWork` method eliminates the exception in a Windows Forms app.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/WinForms/Form11.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/WinForms/Form11.vb" id="Snippet5":::

### Changing a collection while iterating it

The `foreach` statement in C#, `for...in` in F#, or `For Each` statement in Visual Basic is used to iterate the members of a collection and to read or modify its individual elements. However, it can't be used to add or remove items from the collection. Doing this throws an  <xref:System.InvalidOperationException> exception with a message that is similar to, "**Collection was modified; enumeration operation may not execute.**"

The following example iterates a collection of integers attempts to add the square of each integer to the collection. The example throws an <xref:System.InvalidOperationException> with the first call to the <xref:System.Collections.Generic.List%601.Add%2A?displayProperty=nameWithType> method.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Iterating1.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Iterating1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Iterating1.vb" id="Snippet1":::

You can eliminate the exception in one of two ways, depending on your application logic:

- If elements must be added to the collection while iterating it, you can iterate it by index using the `for` (`for..to` in F#) statement instead of `foreach`, `for...in`, or `For Each`. The following example uses the for statement to add the square of numbers in the collection to the collection.

  :::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Iterating2.cs" interactive="try-dotnet" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Iterating2.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Iterating2.vb" id="Snippet2":::

  Note that you must establish the number of iterations before iterating the collection either by using a counter inside the loop that will exit the loop appropriately, by iterating backward, from `Count` - 1 to 0, or, as the example does, by assigning the number of elements in the array to a variable and using it to establish the upper bound of the loop. Otherwise, if an element is added to the collection on every iteration, an endless loop results.

- If it is not necessary to add elements to the collection while iterating it, you can store the elements to be added in a temporary collection that you add when iterating the collection has finished. The following example uses this approach to add the square of numbers in a collection to a temporary collection, and then to combine the collections into a single array object.

  :::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Iterating3.cs" interactive="try-dotnet" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Iterating3.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Iterating3.vb" id="Snippet3":::

### Sorting an array or collection whose objects cannot be compared

General-purpose sorting methods, such as the <xref:System.Array.Sort%28System.Array%29?displayProperty=nameWithType> method or the <xref:System.Collections.Generic.List%601.Sort?displayProperty=nameWithType> method, usually require that at least one of the objects to be sorted implement the <xref:System.IComparable%601> or the <xref:System.IComparable> interface. If not, the collection or array cannot be sorted, and the method throws an  <xref:System.InvalidOperationException> exception. The following example defines a `Person` class, stores two `Person` objects in a generic <xref:System.Collections.Generic.List%601> object, and attempts to sort them. As the output from the example shows, the call to the <xref:System.Collections.Generic.List%601.Sort?displayProperty=nameWithType> method throws an <xref:System.InvalidOperationException>.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/List_Sort1.cs" id="Snippet12":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/List_Sort1.fs" id="Snippet12":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/List_Sort1.vb" id="Snippet12":::

You can eliminate the exception in any of three ways:

- If you can own the type that you are trying to sort (that is, if you control its source code), you can modify it to implement the <xref:System.IComparable%601> or the <xref:System.IComparable> interface. This requires that you implement either the <xref:System.IComparable%601.CompareTo%2A?displayProperty=nameWithType> or the <xref:System.IComparable.CompareTo%2A> method. Adding an interface implementation to an existing type is not a breaking change.

  The following example uses this approach to provide an <xref:System.IComparable%601> implementation for the `Person` class. You can still call the collection or array's general sorting method and, as the output from the example shows, the collection sorts successfully.

  :::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/List_Sort2.cs" interactive="try-dotnet" id="Snippet13":::
  :::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/List_Sort2.fs" id="Snippet13":::
  :::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/List_Sort2.vb" id="Snippet13":::

- If you cannot modify the source code for the type you are trying to sort, you can define a special-purpose sorting class that implements the <xref:System.Collections.Generic.IComparer%601> interface. You can call an overload of the `Sort` method that includes an  <xref:System.Collections.Generic.IComparer%601> parameter. This approach is especially useful if you want to develop a specialized sorting class that can sort objects based on multiple criteria.

  The following example uses the approach by developing a custom `PersonComparer` class that is used to sort `Person` collections. It then passes an instance of this class to the <xref:System.Collections.Generic.List%601.Sort%28System.Collections.Generic.IComparer%7B%600%7D%29?displayProperty=nameWithType> method.

  :::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/List_Sort3.cs" interactive="try-dotnet" id="Snippet14":::
  :::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/List_Sort3.fs" id="Snippet14":::
  :::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/List_Sort3.vb" id="Snippet14":::

- If you cannot modify the source code for the type you are trying to sort, you can create a  <xref:System.Comparison%601> delegate to perform the sorting. The delegate signature is

    ```vb
    Function Comparison(Of T)(x As T, y As T) As Integer
    ```

    ```csharp
    int Comparison<T>(T x, T y)
    ```

  The following example uses the approach by defining a  `PersonComparison` method that matches the  <xref:System.Comparison%601> delegate signature. It then passes this delegate to the <xref:System.Collections.Generic.List%601.Sort%28System.Comparison%7B%600%7D%29?displayProperty=nameWithType> method.

  :::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/List_Sort4.cs" interactive="try-dotnet" id="Snippet15":::
  :::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/List_Sort4.fs" id="Snippet15":::
  :::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/List_Sort4.vb" id="Snippet15":::

### Casting a Nullable\<T> that's null to its underlying type

Attempting to cast a <xref:System.Nullable%601> value that is `null` to its underlying type throws an <xref:System.InvalidOperationException> exception and displays the error message, "**Nullable object must have a value.**

The following example throws an <xref:System.InvalidOperationException> exception when it attempts to iterate an array that includes a `Nullable(Of Integer)` value.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Nullable1.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Nullable1.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Nullable1.vb" id="Snippet4":::

To prevent the exception:

- Use the <xref:System.Nullable%601.HasValue?displayProperty=nameWithType> property to select only those elements that are not `null`.
- Call one of the <xref:System.Nullable%601.GetValueOrDefault%2A?displayProperty=nameWithType> overloads to provide a default value for a `null` value.

The following example does both to avoid the  <xref:System.InvalidOperationException> exception.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Nullable2.cs" interactive="try-dotnet" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Nullable2.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Nullable2.vb" id="Snippet5":::

### Call a System.Linq.Enumerable method on an empty collection

The <xref:System.Linq.Enumerable.Aggregate%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.Average%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.First%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.Last%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.Max%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.Min%2A?displayProperty=nameWithType>,  <xref:System.Linq.Enumerable.Single%2A?displayProperty=nameWithType>, and <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType> methods perform operations on a sequence and return a single result. Some overloads of these methods throw an <xref:System.InvalidOperationException> exception when the sequence is empty, while other overloads return `null`. The <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType> method also throws an <xref:System.InvalidOperationException> exception when the sequence contains more than one element.

> [!NOTE]
> Most of the methods that throw an <xref:System.InvalidOperationException> exception are overloads. Be sure that you understand the behavior of the overload that you choose.

The following table lists the exception messages from the <xref:System.InvalidOperationException> exception objects thrown by calls to some <xref:System.Linq.Enumerable?displayProperty=nameWithType> methods.

|Method|Message|
|------------|-------------|
|`Aggregate` <br />`Average` <br />`Last` <br />`Max` <br />`Min`|**Sequence contains no elements**|
|`First`|**Sequence contains no matching element**|
|`Single` <br />`SingleOrDefault`|**Sequence contains more than one matching element**|

How you eliminate or handle the exception depends on your application's assumptions and on the particular method you call.

- When you deliberately call one of these methods without checking for an empty sequence, you are assuming that the sequence is not empty, and that an empty sequence is an unexpected occurrence. In this case, catching or rethrowing the exception is appropriate.

- If your failure to check for an empty sequence was inadvertent, you can call one of the overloads of the <xref:System.Linq.Enumerable.Any%2A?displayProperty=nameWithType> overload to determine whether a sequence contains any elements.

    > [!TIP]
    > Calling the <xref:System.Linq.Enumerable.Any%60%601%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2CSystem.Boolean%7D%29?displayProperty=nameWithType> method before generating a sequence can improve performance if the data to be processed might contain a large number of elements or if operation that generates the sequence is expensive.

- If you've called a method such as <xref:System.Linq.Enumerable.First%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.Last%2A?displayProperty=nameWithType>, or <xref:System.Linq.Enumerable.Single%2A?displayProperty=nameWithType>, you can substitute an alternate method, such as <xref:System.Linq.Enumerable.FirstOrDefault%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.LastOrDefault%2A?displayProperty=nameWithType>, or  <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType>, that returns a default value instead of a member of the sequence.

The examples provide additional detail.

The following example uses the <xref:System.Linq.Enumerable.Average%2A?displayProperty=nameWithType> method to compute the average of a sequence whose values are greater than 4. Since no values from the original array exceed 4, no values are included in the sequence, and the method throws an <xref:System.InvalidOperationException> exception.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Enumerable1.cs" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Enumerable1.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Enumerable1.vb" id="Snippet6":::

The exception can be eliminated by calling the <xref:System.Linq.Enumerable.Any%2A> method to determine whether the sequence contains any elements before calling the method that processes the sequence, as the following example shows.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Enumerable2.cs" interactive="try-dotnet" id="Snippet7":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Enumerable2.fs" id="Snippet7":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Enumerable2.vb" id="Snippet7":::

The <xref:System.Linq.Enumerable.First%2A?displayProperty=nameWithType> method returns the first item in a sequence or the first element in a sequence that satisfies a specified condition. If the sequence is empty and therefore does not have a first element, it throws an <xref:System.InvalidOperationException> exception.

In the following example, the <xref:System.Linq.Enumerable.First%60%601%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2CSystem.Boolean%7D%29?displayProperty=nameWithType> method throws an <xref:System.InvalidOperationException> exception because the dbQueryResults array doesn't contain an element greater than 4.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Enumerable3.cs" id="Snippet8":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Enumerable3.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Enumerable3.vb" id="Snippet8":::

You can call the <xref:System.Linq.Enumerable.FirstOrDefault%2A?displayProperty=nameWithType> method instead of <xref:System.Linq.Enumerable.First%2A?displayProperty=nameWithType> to return a specified or default value. If the method does not find a first element in the sequence, it returns the default value for that data type. The default value is `null` for a reference type, zero for a numeric data type, and <xref:System.DateTime.MinValue?displayProperty=nameWithType> for the <xref:System.DateTime> type.

> [!NOTE]
> Interpreting the value returned by the <xref:System.Linq.Enumerable.FirstOrDefault%2A?displayProperty=nameWithType> method is often complicated by the fact that the default value of the type can be a valid value in the sequence. In this case, you an call the <xref:System.Linq.Enumerable.Any%2A?displayProperty=nameWithType> method to determine whether the sequence has valid members before calling the <xref:System.Linq.Enumerable.First%2A?displayProperty=nameWithType> method.

The following example calls the  <xref:System.Linq.Enumerable.FirstOrDefault%60%601%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2CSystem.Boolean%7D%29?displayProperty=nameWithType> method to prevent the <xref:System.InvalidOperationException> exception thrown in the previous example.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Enumerable4.cs" interactive="try-dotnet" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Enumerable4.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Enumerable4.vb" id="Snippet9":::

### Call Enumerable.Single or Enumerable.SingleOrDefault on a sequence without one element

The <xref:System.Linq.Enumerable.Single%2A?displayProperty=nameWithType> method returns the only element of a sequence, or the only element of a sequence that meets a specified condition.   If there are no elements in the sequence, or if there is more than one element , the method throws an <xref:System.InvalidOperationException> exception.

You can use the <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType> method to return a default value instead of throwing an exception when the sequence contains no elements. However, the <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType> method still throws an <xref:System.InvalidOperationException> exception when the sequence contains more than one element.

The following table lists the exception messages from the <xref:System.InvalidOperationException> exception objects thrown by calls to the <xref:System.Linq.Enumerable.Single%2A?displayProperty=nameWithType> and <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType> methods.

| Method                            | Message                                              |
|-----------------------------------|------------------------------------------------------|
| `Single`                          | **Sequence contains no matching element**            |
| `Single` <br />`SingleOrDefault` | **Sequence contains more than one matching element** |

In the following example, the call to the <xref:System.Linq.Enumerable.Single%2A?displayProperty=nameWithType> method throws an <xref:System.InvalidOperationException> exception because the sequence doesn't have an element greater than 4.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Enumerable5.cs" id="Snippet10":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Enumerable5.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Enumerable5.vb" id="Snippet10":::

The following example attempts to prevent the <xref:System.InvalidOperationException> exception thrown when a sequence is empty by instead calling the <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType> method. However, because this sequence returns multiple elements whose value is greater than 2, it also throws an <xref:System.InvalidOperationException> exception.

:::code language="csharp" source="./snippets/System/InvalidOperationException/Overview/csharp/Other/Enumerable6.cs" id="Snippet11":::
:::code language="fsharp" source="./snippets/System/InvalidOperationException/Overview/fsharp/Enumerable6.fs" id="Snippet11":::
:::code language="vb" source="./snippets/System/InvalidOperationException/Overview/vb/Other/Enumerable6.vb" id="Snippet11":::

Calling the <xref:System.Linq.Enumerable.Single%2A?displayProperty=nameWithType> method assumes that either a sequence or the sequence that meets specified criteria contains only one element. <xref:System.Linq.Enumerable.SingleOrDefault%2A?displayProperty=nameWithType> assumes a sequence with zero or one result, but no more. If this assumption is a deliberate one on your part and these conditions are not met, rethrowing or catching the resulting <xref:System.InvalidOperationException> is appropriate. Otherwise, or if you expect that invalid conditions will occur with some frequency, you should consider using some other <xref:System.Linq.Enumerable> method, such as <xref:System.Linq.Enumerable.FirstOrDefault%2A> or <xref:System.Linq.Enumerable.Where%2A>.

### Dynamic cross-application domain field access

The <xref:System.Reflection.Emit.OpCodes.Ldflda?displayProperty=nameWithType> common intermediate language (CIL) instruction throws an <xref:System.InvalidOperationException> exception if the object containing the field whose address you are trying to retrieve is not within the application domain in which your code is executing. The address of a field can only be accessed from the application domain in which it resides.

## Throw an InvalidOperationException exception

You should throw an <xref:System.InvalidOperationException> exception only when the state of your object for some reason does not support a particular method call. That is, the method call is valid in some circumstances or contexts, but is invalid in others.

If the method invocation failure is due to invalid arguments, then <xref:System.ArgumentException> or one of its derived classes, <xref:System.ArgumentNullException> or <xref:System.ArgumentOutOfRangeException>, should be thrown instead.
