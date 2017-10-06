---
title: JavaScript | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | JavaScript
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# JavaScript

JavaScript is a dynamic, interpreted programming language that has been standardized in the ECMAScript language specification. It is the programming language of the web. Like CSS, JavaScript can be defined as attributes within HTML elements, as blocks of script within a page, or in separate files. Just like CSS, it's generally recommended to organize JavaScript into separate files, keeping it separated as much as possible from the HTML found on individual web pages or application views.

When working with JavaScript in your web application, there are a few tasks that you'll commonly need to perform:

-   Selecting an HTML element and retrieving and/or updating its value

-   Querying a Web API for data

-   Sending a command to a Web API (and responding to a callback with its result)

-   Performing validation

You can perform all of these tasks with JavaScript alone, but many libraries exist to make these tasks easier. One of the first and most successful of these libraries is jQuery, which continues to be a popular choice for simplifying these tasks on web pages. For Single Page Applications (SPAs), jQuery doesn't provide many of the desired features that Angular and React offer.

## Legacy Web Apps with jQuery

Although ancient by JavaScript framework standards, jQuery continues to be a very commonly used library for working with HTML/CSS and building applications that make AJAX calls to web APIs. However, jQuery operates at the level of the browser document object model (DOM), and by default offers only an imperative, rather than declarative, model.

For example, imagine that if a textbox's value exceeds 10, an element on the page should be made visible. In jQuery, this would typically be implemented by writing an event handler with code that would inspect the textbox's value and set the visibility of the target element based on that value. This is an imperative, code-based approach. Another framework might instead use databinding to bind the visibility of the element to the value of the textbox declaratively. This would not require writing any code, but instead only requires decorating the elements involved with data binding attributes. As client side behaviors grow more complex, data binding approaches frequently result in simpler solutions with less code and conditional complexity.

## jQuery vs a SPA Framework

| **Factor** | **jQuery** | **Angular**|
|--------------------------|------------|-------------|
| Abstracts the DOM | **Yes** | **Yes** |
| AJAX Support | **Yes** | **Yes** |
| Declarative Data Binding | **No** | **Yes** |
| MVC-style Routing | **No** | **Yes** |
| Templating | **No** | **Yes** |
| Deep-Link Routing | **No** | **Yes** |

Most of the features jQuery lacks intrinsically can be added with the addition of other libraries. However, a SPA framework like Angular provides these features in a more integrated fashion, since it's been designed with all of them in mind from the start. Also, jQuery is a very imperative library, meaning that you need to call jQuery functions in order to do anything with jQuery. Much of the work and functionality that SPA frameworks provide can be done declaratively, requiring no actual code to be written.

Data binding is a great example of this. In jQuery, it usually only takes one line of code to get the value of a DOM element, or to set an element's value. However, you have to write this code any time you need to change the value of the element, and sometimes this will occur in multiple functions on a page. Another common example is element visibility. In jQuery, there might be many different places where you would write code to control whether certain elements were visible. In each of these cases, when using data binding, no code would need to be written. You would simply bind the value or visibility of the element(s) in question to a *viewmodel* on the page, and changes to that viewmodel would automatically be reflected in the bound elements.

## Angular SPAs

AngularJS quickly became one of the world's most popular JavaScript frameworks. With Angular 2, the team rebuilt the framework from the ground up (using [TypeScript](https://www.typescriptlang.org/)) and rebranded from AngularJS to simply Angular. Currently on version 4, Angular continues to be a robust framework for building Single Page Applications.

Angular applications are built from components. Components combine HTML templates with special objects and control a portion of the page. A simple component from Angular's docs is shown here:

```js
import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `<h1>Hello {{name}}</h1>`
})

export class AppComponent { name = 'Angular'; }
```

Components are defined using the @Component decorator function, which takes in metadata about the component. The selector property identifies the id of the element on the page where this component will be displayed. The template property is a simple HTML template that includes a placeholder that corresponds to the component's name property, defined on the last line.

By working with components and templates, instead of DOM elements, Angular apps can operate at a higher level of abstraction and with less overall code than apps written using just JavaScript (also called "vanilla JS") or with jQuery. Angular also imposes some order on how you organize your client-side script files. By convention, Angular apps use a common folder structure, with module and component script files located in an app folder. Angular scripts concerned with building, deploying, and testing the app are typically located in a higher-level folder.

Angular also makes great use of command line interface (CLI) tooling. Getting started with Angular development locally (assuming you already have git and npm installed) consists of simply cloning a repo from GitHub and running \`npm install\` and \`npm start\`. Beyond this, Angular ships its own CLI tool which can create projects, add files, and assist with testing, bundling, and deployment tasks. This CLI tooling friendliness makes Angular especially compatible with ASP&period;NET Core, which also features great CLI support.

Microsoft has developed a reference application, [eShopOnContainers](http://aka.ms/MicroservicesArchitecture), which includes an Angular SPA implementation. This app includes Angular modules to manage the online store's shopping basket, load and display items from its catalog, and handling order creation. You can view and download the sample application from [GitHub](https://github.com/dotnet-architecture/eShopOnContainers/tree/master/src/Web/WebSPA).

## React

Unlike Angular, which offers a full Model-View-Controller pattern implementation, React is only concerned with views. It's not a framework, just a library, so to build a SPA you'll need to leverage additional libraries.

One of React's most important features is its use of a virtual DOM. The virtual DOM provides React with several advantages, including performance (the virtual DOM can optimize which parts of the actual DOM need to be updated) and testability (no need to have a browser to test React and its interactions with its virtual DOM).

React is also unusual in how it works with HTML. Rather than having a strict separation between code and markup (with references to JavaScript appearing in HTML attributes perhaps), React adds HTML directly within its JavaScript code as JSX. JSX is HTML-like syntax that can compile down to pure JavaScript. For example:

```js
<ul>
{ authors.map(author =>
    <li key={author.id}>{author.name}</li>
)}
</ul>
```

If you already know JavaScript, learning React should be easy. There isn't nearly as much learning curve or special syntax involved as with Angular or other popular libraries.

Because React isn't a full framework, you'll typically want other libraries to handle things like routing, web API calls, and dependency management. The nice thing is, you can pick the best library for each of these, but the disadvantage is that you need to make all of these decisions and verify all of your chosen libraries work well together when you're done. If you want a good starting point, you can use a starter kit like React Slingshot, which prepackages a set of compatible libraries together with React.

## Choosing a SPA Framework

When considering which JavaScript framework will work best to support your SPA, keep in mind the following considerations:

-   Is your team familiar with the framework and its dependencies (including TypeScript in some cases)?

-   How opinionated is the framework, and do you agree with its default way of doing things?

-   Does it (or a companion library) include all of the features your app requires?

-   Is it well-documented?

-   How active is its community? Are new projects building built with it?

-   How active is its core team? Are issues being resolved and new versions shipped regularly?

JavaScript frameworks continue to evolve with breakneck speed. Use the considerations listed above to help mitigate the risk of choosing a framework you'll later regret being dependent upon. If you're particularly risk-averse, consider a framework that offers commercial support and/or is being developed by a large enterprise.

> ### References – Client Web Technologies
> - **HTML and CSS**  
> <https://www.w3.org/standards/webdesign/htmlcss>
> - **Sass vs. LESS**  
> <https://www.keycdn.com/blog/sass-vs-less/>
> - **Styling ASP.NET Core Apps with LESS, Sass, and Font Awesome**  
> <https://docs.microsoft.com/en-us/aspnet/core/client-side/less-sass-fa>
> - **Client-Side Development in ASP.NET Core**  
> <https://docs.microsoft.com/en-us/aspnet/core/client-side/>
> - **jQuery**  
> <https://jquery.com/>
> - **jQuery vs AngularJS**  
> <https://www.airpair.com/angularjs/posts/jquery-angularjs-comparison-migration-walkthrough>
> - **Angular**  
> <https://angular.io/>
> - **React**  
> <https://facebook.github.io/react/>
> - **React Slingshot**  
> <https://github.com/coryhouse/react-slingshot>
> - **React vs Angular 2 Comparison**  
> <https://www.codementor.io/codementorteam/react-vs-angular-2-comparison-beginners-guide-lvz5710ha>
> - **5 Best JavaScript Frameworks of 2017**  
> <https://hackernoon.com/5-best-javascript-frameworks-in-2017-7a63b3870282>

>[!div class="step-by-step"]
[Previous] (css.md)
[Next] (../developing-asp/index.md)
