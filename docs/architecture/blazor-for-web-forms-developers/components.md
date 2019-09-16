---
title: Build reusable UI components with Blazor
description: Learn how to build reusable UI components with Blazor and how they compare to ASP.NET Web Forms controls.
author: danroth27
ms.author: daroth
ms.date: 09/16/2019
---

# Build reusable UI components with Blazor

One of the beautiful things about ASP.NET Web Forms is how it enables encapsulation of reusable pieces of user interface (UI) code into reusable UI controls. Custom user controls can be defined in markup using *.ascx* files. You can also build elaborate server controls in code with full designer support.

Blazor also supports UI encapsulation through *components*. A component is a self-contained chunk of UI. A component maintains its own state and rendering logic. It can define UI event handlers, bind to input data, and manage its own lifecycle. Blazor components are typically defined in a *.razor* file using Razor syntax.

## An introduction to Razor

Razor is a light-weight markup templating language based on HTML and C#. With Razor, you can seamlessly transition between markup and C# code to define your component rendering logic. When the *.razor* file is compiled, the rendering logic is captured in a structured way in a .NET class. The name of the compiled class is taken from the *.razor* file name. The namespace is taken from the default namespace for the project and the folder path, or you can explicitly specify the namespace using the `@namespace` directive (more on Razor directives below).

The rendering logic for a component is authored using normal HTML markup with dynamic logic added using C#. The `@` character is used to transition to C#. Razor is typically smart about figuring out when you've switched back to HTML. For example, the following component renders a `<p>` tag with the current time:

```razor
<p>@DateTime.Now</p>
```

To explicitly specify the beginning and ending of a C# expression, use parentheses:

```razor
<p>@(DateTime.Now)</p>
```

Razor also makes it easy to use C# control flow in your rendering logic. For example, you can conditionally render some HTML like this:

```razor
@if (value % 2 == 0)
{
    <p>The value was even.</p>
}
```

Or you can generate a list of items using a normal C# `foreach` loop like this:

```razor
<ul>
@foreach (var item in items)
{
    <li>item.Text</li>
}
</ul>
```

Razor directives, like directives in ASP.NET Web Forms, control many aspects of how a Razor component is compiled. Examples include the component's:

* Namespace
* Base class
* Implemented interfaces
* Generic parameters
* Imported namespaces
* Routes

Razor directives all start with the `@` character and are typically used at the start of a new line, often at the start of the file. For example, the `@namespace` directive can be used to control the namespace of the component:

```razor
@namespace MyComponentNamespace
```

The following table summarizes the various Razor directives used in Blazor and their ASP.NET Web Forms equivalents, if they exist:

Directive | Description | Example | ASP.NET Web Forms equivalent 
--- | --- | --- | ---
`@attribute` | Adds a class-level attribute to the component. | `@attribute [Authorize]` | None
`@code` | Add class members to the component. | `@code { ... }` | `<script runat=server>...</script>`
`@implements` | Implement the specified interface. | `@implements IDisposable` | Use code-behind
`@inherits` | Inherit from the specified base class. | `@inherits MyComponentBase` | `<%@ Control Inherits="MyUserControlBase" %>`
`@inject` | Inject a service into the component. | `@inject IJSRuntime JS` | None
`@layout` | Specify a layout component for the component. | `@layout MainLayout` | `<%@ Page MasterPageFile="~/Site.Master" %>`
`@namespace` | Sets the namespace for the component. | `@namespace MyNamespace` | None
`@page` | Specifies the route for the component. | `@page /product/{id}` | `<%@ Page %>`
`@typeparam` | Specifies a generic type parameter for the component. | `@typeparam TItem` | Use code-behind
`@using` | Adds a using statement for the specified namespace. | `@using MyComponentNamespace` | Add namespace in *web.config*

Razor components also make extensive use of *directive attributes* on elements to control various aspects of how components get compiled (event handling, data binding, component & element references, and so on). Directive attributes all follow a common generic syntax where the values in parenthesis are optional:

```razor
@directive(-suffix(:name))(="value")
```

The following table summarizes the various Razor directive attributes used in Blazor.

Directive attribute | Description | Example
--- | --- | ---
`@attributes` | Render a dictionary of attributes. | `<input @attributes="ExtraAttributes" />`
`@bind` | Create a two-way data binding. | `<input @bind="username" @bind:event="oninput" />`
`@on{event}` | Add an event handler for the specified event | `<button @onclick="IncrementCount">Click me!</button>`
`@key` | Specify a key to be used by the diffing algorithm for preserving elements in a collection | `<DetailsEditor @key="person" Details="person.Details" />`
`@ref` | Capture a reference to the component or HTML element | `<MyDialog @ref="myDialog" />`

The various directive attributes used by Blazor (`@onclick`, `@bind`, `@ref`, and so on) are covered in the sections below and later chapters.

Many of the syntaxes used in *.aspx* and *.ascx* files have parallel syntaxes in Razor. Below is a simple comparison of the syntaxes for ASP.NET Web Forms and Razor.

Syntax | .aspx | Example | .razor | Example
--- | --- | --- | --- | ---
Directives | `<%@ [directive] %>` | `<%@ Page %>` | `@[directive]` | `@page`
Code blocks | `<% %>` | `<% int x = 123; %>`  | `@{ }` | `@{ int x = 123; }`
Expressions<br>(HTML encoded) | `<%: %>` | `<%:DateTime.Now %>` | Implicit: `@`<br>Explicit: `@()` | `@DateTime.Now`<br>`@(DateTime.Now)`
Comments | `<%-- --%>` | `<%-- Commented --%>` | `@* *@` | `@* Commented *@`
Data binding | `<%# %>` | `<%# Bind("Name") %>` | `@bind` | `<input @bind="username" />`

To add members to the Razor component class, use the `@code` directive. This technique is similar to using a `<script runat="server">...</script>` block in an ASP.NET Web Forms user control or page.

```razor
@code {
    int count = 0;

    void IncrementCount() 
    {
        count++;
    }
}
```

Because Razor is based on C#, it must be compiled from within a C# project (*.csproj*). You can't compile *.razor* files from a VB project (*.vbproj*). You can still reference VB projects from your Blazor project. The opposite is true too.

A full [Razor syntax reference](/aspnet/core/mvc/views/razor) is available in the ASP.NET Core documentation.

## Use components

Aside from normal HTML, components can also use other components as part of their rendering logic. The syntax for using a component in Razor is similar to using a user control in an ASP.NET Web Forms app. Components are specified using an element tag that matches the type name of the component. For example, you can add a `Counter` component like this:

```razor
<Counter />
```

Unlike ASP.NET Web Forms, components in Blazor don't have an element prefix (for example, `asp:`) and they don't need to be registered on the page or in *web.config*. You can think of Razor components like you would .NET types, because that's exactly what they are. If the assembly containing the component is referenced, then the component is available to be used. To bring the component's namespace into scope, you use the `@using` directive.

```razor
@using MyComponentLib

<Counter />
```

As seen in the default Blazor projects, it's common to put `@using` directives into a *_Imports.razor* file so that they get imported into all *.razor* files in the same directory and in child directories.

If the namespace for a component isn't in scope, you can specify a component using its full type name, just like you can in C#.

```razor
<MyComponentLib.Counter />
```

## Component parameters

In ASP.NET Web Forms, you can flow parameters and data to controls using public properties. These properties can be set in markup using attributes or set directly in code. Blazor components work in a similar fashion, although the component properties must also be marked with the `[Parameter]` attribute to be considered component parameters.

The following `Counter` component defines a component parameter called `IncrementAmount` that can be used to specify the amount that the `Counter` should be incremented each time the button is clicked.

```razor
<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    int currentCount = 0;

    [Parameter]
    public int IncrementAmount { get; set; } = 1;

    void IncrementCount()
    {
        currentCount+=IncrementAmount;
    }
}
```

To specify a component parameter in Blazor, use an attribute just like you would in ASP.NET Web Forms:

```razor
<Counter IncrementAmount="10" />
```

## Event handlers

Both ASP.NET Web Forms and Blazor provide an event-based programming model for handling UI events, like button clicks, text input, and the like. In ASP.NET Web Forms, you use HTML server controls to handle UI events exposed by the DOM, or you can handle events exposed by web server controls. These events are surfaced on the server through form post back requests.

In Blazor, you can register handlers for DOM UI events directly using directive attributes of the form `@on{event}`, where `{event}` is the name of the event. For example, you can listen for button clicks like this:

```razor
<button @onclick="OnClick">Click me!</button>

@code {
    void OnClick() 
    {
        Console.WriteLine("The button was clicked!);
    }
}
```

Event handlers can take an optional event-specific argument to provide more information about the event. For example, mouse events can take a `MouseEventArgs` argument, but it isn't required.

```razor
<button @onclick="OnClick">Click me!</button>

@code {
    void OnClick(MouseEventArgs e) 
    {
        Console.WriteLine($"Mouse clicked at {e.ScreenX}, {e.ScreenY}.");
    }
}
```

Instead of referring to a method group for an event handler, you can use a lambda expression. A lambda expression allows you to close over other in-scope values.

```razor
@foreach (var buttonLabel in buttonLabels)
{
    <button @onclick="() => Console.WriteLine($"The {buttonLabel} button was clicked!")">@buttonLabel</button>
}
```

Event handlers can execute synchronously or asynchronously.

```razor
<button @onclick="OnClick">Click me!</button>

@code {
    async Task OnClick() 
    {
        var result = await Http.GetAsync("api/values");
    }
}
```

After an event is handled, the component is rendered to account for any component state changes. With asynchronous event handlers, the component is rendered immediately after the handler execution completes. The component is rendered *again* after the asynchronous `Task` completes. This asynchronous execution mode provides an opportunity to render some appropriate UI while the asynchronous `Task` is still in progress.

```razor
<button @onclick="Get message">Get message</button>

@if (showMessage)
{
    @if (message == null)
    {
        <p><em>Loading...</em></p>
    }
    else
    {
        <p>The message is: @message</p>
    }
}

@code 
{
    bool showMessage = false;
    string message;

    public async Task ShowMessage()
    {
        showMessage = true;
        message = await MessageService.GetMessageAsync();
    }
}
```

Components can also define their own events by defining a component parameter of type `EventCallback<TValue>`. Event callbacks support all the variations of DOM UI event handlers: optional args, sync or async, method groups or lambda expressions.

```razor
<button class="btn btn-primary" @onclick="OnClick">Click me!</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
}
```

## Data binding

Blazor provides a simple mechanism to bind data from a UI component to the component's state. This approach differs from the features in ASP.NET Web Forms for binding data from data sources to UI controls. We'll cover handling data from different data sources in the [Dealing with data](data.md) section.

To create a two-way data binding from a UI component to the component's state, use the `@bind` directive attribute. In the example below, the value of the check box is bound to the `isChecked` field.

```razor
<input type="checkbox" @bind="isChecked" />

@code {
    bool isChecked;
}
```

When the component is rendered, the value of the checkbox will be set to the value of the `isChecked` field. When the user toggles the checkbox, the `onchange` event is fired and the `isChecked` field is set to the new value. The `@bind` syntax in this case is equivalent to the following markup:

```razor
<input value="@isChecked" @onchange="(UIChangeEventArgs e) => isChecked = e.Value" />
```

To change the event used for the bind, use the `@bind:event` attribute.

```razor
<input @bind="text" @bind:event="oninput" />
<p>@text</p>

@code {
    string text;
}
```

Components can also support data binding to their parameters. To data bind, define an event callback parameter with the same name as the bindable parameter. The "Changed" suffix is added to the name.

*PasswordBox.razor*

```razor
Password: <input 
    value="@Password" 
    @oninput="OnPasswordChanged" 
    type="@(showPassword ? "text" : "password")" />

<label><input type="checkbox" @bind="showPassword" />Show password</label>

@code {
    private bool showPassword;

    [Parameter]
    public string Password { get; set; }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private Task OnPasswordChanged(ChangeEventArgs e)
    {
        Password = e.Value.ToString();
        return PasswordChanged.InvokeAsync(Password);
    }
}
```

To chain a data binding to an underlying UI element, you'll need to set the value and handle the event directly on the UI element instead of using the `@bind` attribute.

To bind to a component parameter, use a `@bind-{Parameter}` attribute to specify which parameter you want to bind to.

```razor
<PasswordBox @bind-Password="password" />

@code {
    string password;
}
```

## State changes

If the component's state has changed outside of a normal UI event or event callback, then the component must manually signal that it needs to be rendered again. To signal that a component's state has changed, call the `StateHasChanged` method on the component.

In the example below, a component displays a message from an `AppState` service that can be updated by other parts of the app. The component registers its `StateHasChanged` method with the `AppState.OnChange` event so that the component is rendered whenever the message gets updated.

```csharp
public class AppState 
{
    public string Message { get; }

    // Lets components receive change notifications
    public event Action OnChange;

    public void UpdateMessage(string message)
    {
        shortlist.Add(itinerary);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
```

```razor
@inject AppState AppState

<p>App message: @AppState.Message</p>

@code {
    protected override void OnInitialized()
    {
        AppState.OnChange += StateHasChanged
    }
}
```

## Component lifecycle

The ASP.NET Web Forms framework has well-defined lifecycle methods for modules, pages, and controls. Blazor components also have a well-defined lifecycle. A component's lifecycle can be used to initialize component state and implement advanced component behaviors. 

All of Blazor's component lifecycle methods have both synchronous and asynchronous versions. This is important because component rendering is synchronous. You can't run asynchronous logic as part of the component rendering. All asynchronous logic must execute as part of an `async` lifecycle method.

### OnInitialized

The `OnInitialized` and `OnInitializedAsync` methods are used to initialize the component. A component is typically initialized after it's first rendered. After a component is initialized, it may be rendered multiple times before it's eventually disposed. The `OnInitialized` method is similar to the `Page_Load` event in ASP.NET Web Forms pages and controls.

```csharp
protected override void OnInitialized() { ... }
protected override Task OnInitializedAsync() { ... }
```

### OnParametersSet

The `OnParametersSet` and `OnParametersSetAsync` methods are called when a component has received parameters from its parent and the value are assigned to properties. These methods are executed after component initialization and *each time the component is rendered*.

```csharp
protected override void OnParametersSet() { ... }
protected override async Task OnParametersSetAsync() { ...}
```

### OnAfterRender

The `OnAfterRender` and `OnAfterRenderAsync` methods are called after a component has finished rendering. Element and component references are populated at this point (more on these concepts below). Interactivity with the browser is enabled at this point including interacting with the DOM and support for executing JavaScript. 

`OnAfterRender` and `OnAfterRenderAsync` *aren't called when prerendering on the server*.

The `firstRender` parameter is `true` the first time the component is rendered; otherwise, it's `false`.

### IDisposable

Blazor components can implement `IDisposable` to dispose of resources when the component is removed from the UI. A Razor component can implement `IDispose` using the `@implements` directive.

```razor
@using System
@implements IDisposable

...

@code {
    public void Dispose()
    {
        ...
    }
}
```

## Capture component references

In ASP.NET Web Forms, it's common to manipulate a control instance directly in code by referring to its ID. In Blazor, it's also possible to capture and manipulate a reference to a component, although it's much less common. 

To capture a component reference in Blazor, use the `@ref` directive attribute. The value of the attribute should match the name of a settable field with the same type as the referenced component.

```razor
<MyLoginDialog @ref="loginDialog" ... />

@code {
    MyLoginDialog loginDialog;

    void OnSomething()
    {
        loginDialog.Show();
    }
}
```

When the parent component is rendered, the field is populated with the child component instance. You can then call methods on, or otherwise manipulate, the component instance.

Manipulating component state directly using component references isn't recommended. Doing so prevents the component from being rendered automatically at the correct times.

## Capture element references

Blazor components can capture references to an element. Unlike HTML server controls in ASP.NET Web Forms, you can't manipulate the DOM directly using an element reference in Blazor. Blazor handles most DOM interactions for you using its DOM diffing algorithm. Captured element references in Blazor are opaque. However, they can be used to pass a specific element reference in a JavaScript interop call. Learn more about [JavaScript interop](/aspnet/core/blazor/javascript-interop) in the Blazor documentation.

## Templated components

In ASP.NET Web Forms, you can create *templated controls*. Templated controls enable the developer to specify a portion of the HTML used to render a container control. The mechanics of building templated server controls are somewhat involved, but they enable powerful scenarios for rendering data in a user customizable way. Examples of templated controls include `Repeater` and `DataList`. 

Blazor components can also be templated by defining component parameters of type `RenderFragment` or `RenderFragment<T>`. A `RenderFragment` represents a chunk of Razor markup that can then be rendered by the component. A `RenderFragment<T>` is a chunk of Razor markup that takes a parameter that can be specified when the render fragment is rendered.

### Child content

Blazor components can capture their child content as a `RenderFragment` and render that content as part of the component rendering. To capture child content, define a component parameter of type `RenderFragment` and name it `ChildContent`.

*ChildContentComponent.razor*

```razor
<h1>Component with child content</h1>

<div>@ChildContent</div>

@code {
    [Parameter]
    public RenderFragment ChildContent { get; set; }
}
```

A parent component can then supply child content using normal Razor syntax.

```razor
<ChildContentComponent>
    <p>The time is @DateTime.Now</p>
</ChildContentComponent>
```

### Template parameters

A templated Blazor component can also define multiple component parameters of type `RenderFragment` or `RenderFragment<T>`. The parameter for a `RenderFragment<T>` can be specified when it's invoked. To specify a generic type parameter for a component, use the `@typeparam` Razor directive.

*SimpleListView.razor*

```razor
@typeparam TItem

@Heading

<ul>
@foreach (var item in items)
{
    <li>@ItemTemplate(item)</li>
}
</ul>

@code {
    [Parameter]
    public RenderFragment Heading { get; set; }

    [Parameter]
    public RenderFragment<TItem> ItemTemplate { get; set; }

    [Parameter]
    public IEnumerable<TItem> Items { get; set; }
}
```

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters. Component arguments of type `RenderFragment<T>` passed as elements have an implicit parameter named `context`. You can change the name of this implement parameter using the `Context` attribute on the child element. Any generic type parameters can be specified using an attribute that matches the name of the type parameter. The type parameter will be inferred if possible:

```razor
<SimpleListView Items="messages" TItem="string">
    <Heading>
        <h1>My list</h1>
    </Heading>
    <ItemTemplate Content="message">
        <p>The message is: @message</p>
    </ItemTemplate>
</SimpleListView>
```

The output of this component looks like this:

```html
<h1>My list</h1>
<ul>
    <li>The message is: message1</li>
    <li>The message is: message2</li>
<ul>
```

## Code-behind

Blazor components are typically authored in a single *.razor* file. However, it's also possible to separate the code and markup using a code-behind file. To use a component file, add a C# file that matches the file name of the component file but with a *.cs* extension added (*Counter.razor.cs*). Use the C# file to define a base class for the component. You can name the base class anything you'd like, but it's common to name the class the same as the component class, but with a `Base` extension added (`CounterBase`). The component-based class need to also derive from `ComponentBase`. Then, in the Razor component file, add the `@inherits` directive to specify the base class for the component (`@inherits CounterBase`).

*Counter.razor*

```razor
@inherits CounterBase

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button @onclick="IncrementCount">Click me</button>
```

*Counter.razor.cs*

```csharp
public class CounterBase : ComponentBase 
{
    protected int currentCount = 0;

    protected void IncrementCount()
    {
        currentCount++;
    }
}
```

The visibility of the component's members in the base class must be `protected` or `public` to be visible to the component class.

## Additional resources

The preceding isn't an exhaustive treatment of all aspects of Blazor components. For more information on how to [Create and use ASP.NET Core Razor components](/aspnet/core/blazor/components), see the Blazor documentation.
