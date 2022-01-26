---
title: Pages, routing, and layouts
description: Learn how to create pages in Blazor, work with client-side routing, and manage page layouts.
author: danroth27
ms.author: daroth
no-loc: [Blazor]
ms.date: 12/2/2021
---
# Pages, routing, and layouts

ASP.NET Web Forms apps are composed of pages defined in *.aspx* files. Each page's address is based on its physical file path in the project. When a browser makes a request to the page, the contents of the page are dynamically rendered on the server. The rendering accounts for both the page's HTML markup and its server controls.

In Blazor, each page in the app is a component, typically defined in a *.razor* file, with one or more specified routes. Routing mostly happens client-side without involving a specific server request. The browser first makes a request to the root address of the app. A root `Router` component in the Blazor app then handles intercepting navigation requests and forwards them to the correct component.

Blazor also supports *deep linking*. Deep linking occurs when the browser makes a request to a specific route other than the root of the app. Requests for deep links sent to the server are routed to the Blazor app, which then routes the request client-side to the correct component.

A simple page in ASP.NET Web Forms might contain the following markup:

*Name.aspx*

```aspx-csharp
<%@ Page Title="Name" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Name.aspx.cs" Inherits="WebApplication1.Name" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        What is your name?<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    </div>
    <div>
        <asp:Literal ID="Literal1" runat="server" />
    </div>
</asp:Content>
```

*Name.aspx.cs*

```csharp
public partial class Name : System.Web.UI.Page
{
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Literal1.Text = "Hello " + TextBox1.Text;
    }
}
```

The equivalent page in a Blazor app would look like this:

*Name.razor*

```razor
@page "/Name"
@layout MainLayout

<div>
    What is your name?<br />
    <input @bind="text" />
    <button @onclick="OnClick">Submit</button>
</div>
<div>
    @if (name != null)
    {
        @:Hello @name
    }
</div>

@code {
    string text;
    string name;

    void OnClick() {
        name = text;
    }
}
```

## Create pages

To create a page in Blazor, create a component and add the `@page` Razor directive to specify the route for the component. The `@page` directive takes a single parameter, which is the route template to add to that component.

```razor
@page "/counter"
```

The route template parameter is required. Unlike ASP.NET Web Forms, the route to a Blazor component *isn't* inferred from its file location (although that may be a feature added in the future).

The route template syntax is the same basic syntax used for routing in ASP.NET Web Forms. Route parameters are specified in the template using braces. Blazor will bind route values to component parameters with the same name (case-insensitive).

```razor
@page "/product/{id}"

<h1>Product @Id</h1>

@code {
    [Parameter]
    public string Id { get; set; }
}
```

You can also specify constraints on the value of the route parameter. For example, to constrain the product ID to be an `int`:

```razor
@page "/product/{id:int}"

<h1>Product @Id</h1>

@code {
    [Parameter]
    public int Id { get; set; }
}
```

For a full list of the route constraints supported by Blazor, see [Route constraints](/aspnet/core/blazor/routing#route-constraints).

## Router component

Routing in Blazor is handled by the `Router` component. The `Router` component is typically used in the app's root component (*App.razor*).

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

The `Router` component discovers the routable components in the specified `AppAssembly` and in the optionally specified `AdditionalAssemblies`. When the browser navigates, the `Router` intercepts the navigation and renders the contents of its `Found` parameter with the extracted `RouteData` if a route matches the address, otherwise the `Router` renders its `NotFound` parameter.

The `RouteView` component handles rendering the matched component specified by the `RouteData` with its layout if it has one. If the matched component doesn't have a layout, then the optionally specified `DefaultLayout` is used.

The `LayoutView` component renders its child content within the specified layout. We'll look at layouts more in detail later in this chapter.

## Navigation

In ASP.NET Web Forms, you trigger navigation to a different page by returning a redirect response to the browser. For example:

```csharp
protected void NavigateButton_Click(object sender, EventArgs e)
{
    Response.Redirect("Counter");
}
```

Returning a redirect response isn't typically possible in Blazor. Blazor doesn't use a request-reply model. You can, however, trigger browser navigations directly, as you can with JavaScript.

Blazor provides a `NavigationManager` service that can be used to:

- Get the current browser address
- Get the base address
- Trigger navigations
- Get notified when the address changes

To navigate to a different address, use the `NavigateTo` method:

```razor
@page "/"
@inject NavigationManager NavigationManager

<button @onclick="Navigate">Navigate</button>

@code {
    void Navigate() {
        NavigationManager.NavigateTo("counter");
    }
}
```

For a description of all `NavigationManager` members, see [URI and navigation state helpers](/aspnet/core/blazor/routing#uri-and-navigation-state-helpers).

## Base URLs

If your Blazor app is deployed under a base path, then you need to specify the base URL in the page metadata using the `<base>` tag for routing to work property. If the host page for the app is server-rendered using Razor, then you can use the `~/` syntax to specify the app's base address. If the host page is static HTML, then you need to specify the base URL explicitly.

```html
<base href="~/" />
```

## Page layout

Page layout in ASP.NET Web Forms is handled by Master Pages. Master Pages define a template with one or more content placeholders that can then be supplied by individual pages. Master Pages are defined in *.master* files and start with the `<%@ Master %>` directive. The content of the *.master* files is coded as you would an *.aspx* page, but with the addition of `<asp:ContentPlaceHolder>` controls to mark where pages can supply content.

*Site.master*

```aspx-csharp
<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Site.master.cs" Inherits="WebApplication1.SiteMaster" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form runat="server">
        <div class="container body-content">
            <asp:ContentPlaceHolder ID="MainContent" runat="server">
            </asp:ContentPlaceHolder>
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>
            </footer>
        </div>
    </form>
</body>
</html>
```

In Blazor, you handle page layout using layout components. Layout components inherit from `LayoutComponentBase`, which defines a single `Body` property of type `RenderFragment`, which can be used to render the contents of the page.

*MainLayout.razor*

```razor
@inherits LayoutComponentBase
<h1>Main layout</h1>
<div>
    @Body
</div>
```

When the page with a layout is rendered, the page is rendered within the contents of the specified layout at the location where the layout renders its `Body` property.

To apply a layout to a page, use the `@layout` directive:

```razor
@layout MainLayout
```

You can specify the layout for all components in a folder and subfolders using an *_Imports.razor* file. You can also specify a default layout for all your pages using the [Router component](#router-component).

Master Pages can define multiple content placeholders, but layouts in Blazor only have a single `Body` property. This limitation of Blazor layout components will hopefully be addressed in a future release.

Master Pages in ASP.NET Web Forms can be nested. That is, a Master Page may also use a Master Page. Layout components in Blazor may be nested too. You can apply a layout component to a layout component. The contents of the inner layout will be rendered within the outer layout.

*ChildLayout.razor*

```razor
@layout MainLayout
<h2>Child layout</h2>
<div>
    @Body
</div>
```

*Index.razor*

```razor
@page "/"
@layout ChildLayout
<p>I'm in a nested layout!</p>
```

The rendered output for the page would then be:

```html
<h1>Main layout</h1>
<div>
    <h2>Child layout</h2>
    <div>
        <p>I'm in a nested layout!</p>
    </div>
</div>
```

Layouts in Blazor don't typically define the root HTML elements for a page (`<html>`, `<body>`, `<head>`, and so on). The root HTML elements are instead defined in a Blazor app's host page, which is used to render the initial HTML content for the app (see [Bootstrap Blazor](project-structure.md#bootstrap-blazor)). The host page can render multiple root components for the app with surrounding markup.

Components in Blazor, including pages, can't render `<script>` tags. This rendering restriction exists because `<script>` tags get loaded once and then can't be changed. Unexpected behavior may occur if you try to render the tags dynamically using Razor syntax. Instead, all `<script>` tags should be added to the app's host page.

>[!div class="step-by-step"]
>[Previous](components.md)
>[Next](state-management.md)
