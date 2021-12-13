---
title: Build reusable UI components with Blazor
description: Learn how to build reusable UI components with Blazor and how they compare to ASP.NET Web Forms controls.
author: danroth27
ms.author: daroth
no-loc: [Blazor]
ms.date: 12/2/2021
---
# Build reusable UI components with Blazor

One of the beautiful things about ASP.NET Web Forms is how it enables encapsulation of reusable pieces of user interface (UI) code into reusable UI controls. Custom user controls can be defined in markup using *.ascx* files. You can also build elaborate server controls in code with full designer support.

Blazor also supports UI encapsulation through *components*. A component:

- Is a self-contained chunk of UI.
- Maintains its own state and rendering logic.
- Can define UI event handlers, bind to input data, and manage its own lifecycle.
- Is typically defined in a *.razor* file using Razor syntax.

## An introduction to Razor

Razor is a light-weight markup templating language based on HTML and C#. With Razor, you can seamlessly transition between markup and C# code to define your component rendering logic. When the *.razor* file is compiled, the rendering logic is captured in a structured way in a .NET class. The name of the compiled class is taken from the *.razor* file name. The namespace is taken from the default namespace for the project and the folder path, or you can explicitly specify the namespace using the `@namespace` directive (more on Razor directives below).

A component's rendering logic is authored using normal HTML markup with dynamic logic added using C#. The `@` character is used to transition to C#. Razor is typically smart about figuring out when you've switched back to HTML. For example, the following component renders a `<p>` tag with the current time:

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
    <li>@item.Text</li>
}
</ul>
```

Razor directives, like directives in ASP.NET Web Forms, control many aspects of how a Razor component is compiled. Examples include the component's:

- Namespace
- Base class
- Implemented interfaces
- Generic parameters
- Imported namespaces
- Routes

Razor directives start with the `@` character and are typically used at the start of a new line at the start of the file. For example, the `@namespace` directive defines the component's namespace:

```razor
@namespace MyComponentNamespace
```

The following table summarizes the various Razor directives used in Blazor and their ASP.NET Web Forms equivalents, if they exist.

|Directive    |Description|Example|Web Forms equivalent|
|-------------|-----------|-------|--------------------|
|`@attribute` |Adds a class-level attribute to the component|`@attribute [Authorize]`|None|
|`@code`      |Adds class members to the component|`@code { ... }`|`<script runat="server">...</script>`|
|`@implements`|Implements the specified interface|`@implements IDisposable`|Use code-behind|
|`@inherits`  |Inherits from the specified base class|`@inherits MyComponentBase`|`<%@ Control Inherits="MyUserControlBase" %>`|
|`@inject`    |Injects a service into the component|`@inject IJSRuntime JS`|None|
|`@layout`    |Specifies a layout component for the component|`@layout MainLayout`|`<%@ Page MasterPageFile="~/Site.Master" %>`|
|`@namespace` |Sets the namespace for the component|`@namespace MyNamespace`|None|
|`@page`      |Specifies the route for the component|`@page "/product/{id}"`|`<%@ Page %>`|
|`@typeparam` |Specifies a generic type parameter for the component|`@typeparam TItem`|Use code-behind|
|`@using`     |Specifies a namespace to bring into scope|`@using MyComponentNamespace`|Add namespace in *web.config*|

Razor components also make extensive use of *directive attributes* on elements to control various aspects of how components get compiled (event handling, data binding, component & element references, and so on). Directive attributes all follow a common generic syntax where the values in parenthesis are optional:

```razor
@directive(-suffix(:name))(="value")
```

The following table summarizes the various attributes for Razor directives used in Blazor.

|Attribute    |Description|Example|
|-------------|-----------|-------|
|`@attributes`|Renders a dictionary of attributes|`<input @attributes="ExtraAttributes" />`|
|`@bind`      |Creates a two-way data binding    |`<input @bind="username" @bind:event="oninput" />`|
|`@on{event}` |Adds an event handler for the specified event|`<button @onclick="IncrementCount">Click me!</button>`|
|`@key`       |Specifies a key to be used by the diffing algorithm for preserving elements in a collection|`<DetailsEditor @key="person" Details="person.Details" />`|
|`@ref`       |Captures a reference to the component or HTML element|`<MyDialog @ref="myDialog" />`|

The various directive attributes used by Blazor (`@onclick`, `@bind`, `@ref`, and so on) are covered in the sections below and later chapters.

Many of the syntaxes used in *.aspx* and *.ascx* files have parallel syntaxes in Razor. Below is a simple comparison of the syntaxes for ASP.NET Web Forms and Razor.

|Feature                      |Web Forms           |Syntax               |Razor         |Syntax |
|-----------------------------|--------------------|---------------------|--------------|-------|
|Directives                   |`<%@ [directive] %>`|`<%@ Page %>`        |`@[directive]`|`@page`|
|Code blocks                  |`<% %>`             |`<% int x = 123; %>` |`@{ }`        |`@{ int x = 123; }`|
|Expressions<br>(HTML-encoded)|`<%: %>`            |`<%:DateTime.Now %>` |Implicit: `@`<br>Explicit: `@()`|`@DateTime.Now`<br>`@(DateTime.Now)`|
|Comments                     |`<%-- --%>`         |`<%-- Commented --%>`|`@* *@`       |`@* Commented *@`|
|Data binding                 |`<%# %>`            |`<%# Bind("Name") %>`|`@bind`       |`<input @bind="username" />`|

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

Because Razor is based on C#, it must be compiled from within a C# project (*.csproj*). You can't compile *.razor* files from a Visual Basic project (*.vbproj*). You can still reference Visual Basic projects from your Blazor project. The opposite is true too.

For a full Razor syntax reference, see [Razor syntax reference for ASP.NET Core](/aspnet/core/mvc/views/razor).

## Use components

Aside from normal HTML, components can also use other components as part of their rendering logic. The syntax for using a component in Razor is similar to using a user control in an ASP.NET Web Forms app. Components are specified using an element tag that matches the type name of the component. For example, you can add a `Counter` component like this:

```razor
<Counter />
```

Unlike ASP.NET Web Forms, components in Blazor:

- Don't use an element prefix (for example, `asp:`).
- Don't require registration on the page or in the *web.config*.

Think of Razor components like you would .NET types, because that's exactly what they are. If the assembly containing the component is referenced, then the component is available for use. To bring the component's namespace into scope, apply the `@using` directive:

```razor
@using MyComponentLib

<Counter />
```

As seen in the default Blazor projects, it's common to put `@using` directives into a *_Imports.razor* file so that they're imported into all *.razor* files in the same directory and in child directories.

If the namespace for a component isn't in scope, you can specify a component using its full type name, as you can in C#:

```razor
<MyComponentLib.Counter />
```

## Modify page title from components

When building SPA-style apps, it's common for parts of a page to reload without reloading the entire page. Even so, it can be useful to have the title of the page change based on which component is currently loaded. This can be accomplished by including the `<PageTitle>` tag in the component's Razor page:

```razor
@page "/"
<PageTitle>Home</PageTitle>
```

The contents of this element can be dynamic, for instance showing the current count of messages:

```razor
<PageTitle>@MessageCount messages</PageTitle>
```

Note that if several components on a particular page include `<PageTitle>` tags, only the last one will be displayed (since each one will overwrite the previous one).

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

To specify a component parameter in Blazor, use an attribute as you would in ASP.NET Web Forms:

```razor
<Counter IncrementAmount="10" />
```

### Query string parameters

Blazor components can also leverage values from the query string of the page they're rendered on as a parameter source. To enable this, add the `[SupplyParameterFromQuery]` attribute to the parameter. For example, the following parameter definition would get its value from the request in the form `?IncBy=2`:

```csharp
[Parameter]
[SupplyParameterFromQuery(Name = "IncBy")]
public int IncrementAmount { get; set; } = 1;
```

If you don't supply a custom `Name` in the `[SupplyParameterFromQuery]` attribute, by default it will match the property name (`IncrementAmount` in this case).

## Components and error boundaries

By default, Blazor apps will detect unhandled exceptions and show an error message at the bottom of the page with no additional detail. To constrain the parts of the app that are impacted by an unhandled error, for instance to limit the impact to a single component, the `<ErrorBoundary>` tag can be wrapped around component declarations.

For example, to protect against possible exceptions thrown from the `Counter` component, declare it within an `<ErrorBoundary>` and optionally specify a message to display if there is an exception:

```razor
<ErrorBoundary>
    <ChildContent>
        <Counter />
    </ChildContent>
    <ErrorContent>
        Oops! The counter isn't working right now; please try again later.
    </ErrorContent>
</ErrorBoundary>
```

If you don't need to specify custom error content, you can just wrap the component directly:

```razor
<ErrorBoundary>
  <Counter />
</ErrorBoundary>
```

A default message stating "An error as occurred." will be displayed if an unhandled exception occurs in the wrapped component.

## Event handlers

Both ASP.NET Web Forms and Blazor provide an event-based programming model for handling UI events. Examples of such events include button clicks and text input. In ASP.NET Web Forms, you use HTML server controls to handle UI events exposed by the DOM, or you can handle events exposed by web server controls. The events are surfaced on the server through form post-back requests. Consider the following Web Forms button click example:

*Counter.ascx*

```aspx-csharp
<asp:Button ID="ClickMeButton" runat="server" Text="Click me!" OnClick="ClickMeButton_Click" />
```

*Counter.ascx.cs*

```csharp
public partial class Counter : System.Web.UI.UserControl
{
    protected void ClickMeButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("The button was clicked!");
    }
}
```

In Blazor, you can register handlers for DOM UI events directly using directive attributes of the form `@on{event}`. The `{event}` placeholder represents the name of the event. For example, you can listen for button clicks like this:

```razor
<button @onclick="OnClick">Click me!</button>

@code {
    void OnClick()
    {
        Console.WriteLine("The button was clicked!");
    }
}
```

Event handlers can accept an optional, event-specific argument to provide more information about the event. For example, mouse events can take a `MouseEventArgs` argument, but it isn't required.

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

Event handlers can execute synchronously or asynchronously. For example, the following `OnClick` event handler executes asynchronously:

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
<button @onclick="ShowMessage">Get message</button>

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

Components can also define their own events by defining a component parameter of type `EventCallback<TValue>`. Event callbacks support all the variations of DOM UI event handlers: optional arguments, synchronous or asynchronous, method groups, or lambda expressions.

```razor
<button class="btn btn-primary" @onclick="OnClick">Click me!</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
}
```

## Data binding

Blazor provides a simple mechanism to bind data from a UI component to the component's state. This approach differs from the features in ASP.NET Web Forms for binding data from data sources to UI controls. We'll cover handling data from different data sources in the [Dealing with data](data.md) section.

To create a two-way data binding from a UI component to the component's state, use the `@bind` directive attribute. In the following example, the value of the check box is bound to the `isChecked` field.

```razor
<input type="checkbox" @bind="isChecked" />

@code {
    bool isChecked;
}
```

When the component is rendered, the value of the checkbox is set to the value of the `isChecked` field. When the user toggles the checkbox, the `onchange` event is fired and the `isChecked` field is set to the new value. The `@bind` syntax in this case is equivalent to the following markup:

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

To chain a data binding to an underlying UI element, set the value and handle the event directly on the UI element instead of using the `@bind` attribute.

To bind to a component parameter, use a `@bind-{Parameter}` attribute to specify the parameter to which you want to bind.

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
        Message = message;
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

The ASP.NET Web Forms framework has well-defined lifecycle methods for modules, pages, and controls. For example, the following control implements event handlers for the `Init`, `Load`, and `UnLoad` lifecycle events:

*Counter.ascx.cs*

```csharp
public partial class Counter : System.Web.UI.UserControl
{
    protected void Page_Init(object sender, EventArgs e) { ... }
    protected void Page_Load(object sender, EventArgs e) { ... }
    protected void Page_UnLoad(object sender, EventArgs e) { ... }
}
```

Blazor components also have a well-defined lifecycle. A component's lifecycle can be used to initialize component state and implement advanced component behaviors.

All of Blazor's component lifecycle methods have both synchronous and asynchronous versions. Component rendering is synchronous. You can't run asynchronous logic as part of the component rendering. All asynchronous logic must execute as part of an `async` lifecycle method.

### OnInitialized

The `OnInitialized` and `OnInitializedAsync` methods are used to initialize the component. A component is typically initialized after it's first rendered. After a component is initialized, it may be rendered multiple times before it's eventually disposed. The `OnInitialized` method is similar to the `Page_Load` event in ASP.NET Web Forms pages and controls.

```csharp
protected override void OnInitialized() { ... }
protected override async Task OnInitializedAsync() { await ... }
```

### OnParametersSet

The `OnParametersSet` and `OnParametersSetAsync` methods are called when a component has received parameters from its parent and the value are assigned to properties. These methods are executed after component initialization and *each time the component is rendered*.

```csharp
protected override void OnParametersSet() { ... }
protected override async Task OnParametersSetAsync() { await ... }
```

### OnAfterRender

The `OnAfterRender` and `OnAfterRenderAsync` methods are called after a component has finished rendering. Element and component references are populated at this point (more on these concepts below). Interactivity with the browser is enabled at this point. Interactions with the DOM and JavaScript execution can safely take place.

```csharp
protected override void OnAfterRender(bool firstRender)
{
    if (firstRender)
    {
        ...
    }
}
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await ...
    }
}
```

`OnAfterRender` and `OnAfterRenderAsync` *aren't called when prerendering on the server*.

The `firstRender` parameter is `true` the first time the component is rendered; otherwise, its value is `false`.

### IDisposable

Blazor components can implement `IDisposable` to dispose of resources when the component is removed from the UI. A Razor component can implement `IDispose` by using the `@implements` directive:

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

Blazor components can capture references to an element. Unlike HTML server controls in ASP.NET Web Forms, you can't manipulate the DOM directly using an element reference in Blazor. Blazor handles most DOM interactions for you using its DOM diffing algorithm. Captured element references in Blazor are opaque. However, they're used to pass a specific element reference in a JavaScript interop call. For more information about JavaScript interop, see [ASP.NET Core Blazor JavaScript interop](/aspnet/core/blazor/javascript-interop).

## Templated components

In ASP.NET Web Forms, you can create *templated controls*. Templated controls enable the developer to specify a portion of the HTML used to render a container control. The mechanics of building templated server controls are complex, but they enable powerful scenarios for rendering data in a user customizable way. Examples of templated controls include `Repeater` and `DataList`.

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
    <ChildContent>
        <p>The time is @DateTime.Now</p>
    </ChildContent>
</ChildContentComponent>
```

### Template parameters

A templated Blazor component can also define multiple component parameters of type `RenderFragment` or `RenderFragment<T>`. The parameter for a `RenderFragment<T>` can be specified when it's invoked. To specify a generic type parameter for a component, use the `@typeparam` Razor directive.

*SimpleListView.razor*

```razor
@typeparam TItem

@Heading

<ul>
@foreach (var item in Items)
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
    <ItemTemplate Context="message">
        <p>The message is: @message</p>
    </ItemTemplate>
</SimpleListView>
```

The output of this component looks like this:

```html
<h1>My list</h1>
<ul>
    <li><p>The message is: message1</p></li>
    <li><p>The message is: message2</p></li>
<ul>
```

## Code-behind

A Blazor component is typically authored in a single *.razor* file. However, it's also possible to separate the code and markup using a code-behind file. To use a component file, add a C# file that matches the file name of the component file but with a *.cs* extension added (*Counter.razor.cs*). Use the C# file to define a base class for the component. You can name the base class anything you'd like, but it's common to name the class the same as the component class, but with a `Base` extension added (`CounterBase`). The component-based class must also derive from `ComponentBase`. Then, in the Razor component file, add the `@inherits` directive to specify the base class for the component (`@inherits CounterBase`).

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

>[!div class="step-by-step"]
>[Previous](app-startup.md)
>[Next](pages-routing-layouts.md)
