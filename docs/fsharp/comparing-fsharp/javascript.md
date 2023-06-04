---
title: Comparing F# with JavaScript - Syntax Comparison
description: Learn about the similarities and differences between F# and JavaScript in terms of syntax and coding examples.
ms.date: 31/05/2023
---

# Comparing F# with Javascript

For the main cli commands comparison, i will place them in this order:

```
npm command
dotnet command
```

# Getting Started

```
npm init
dotnet new -lang f#
```

**JS** (or ECMAScript) being born as a **Browser**(Client-side) **language (Mozilla/Netscape)**, works natively in your browser, or else it needs a backend **runtime** to be able to execute on your computer by its own. That’s why **Node.js** exists.

npm init creates the package.json file and allows you to start adding packages and scripts to your node environment.

JS is an **interpreted** language, doesn’t need to be compiled, can be directly executed, paying this with performance and extra security vulnerabilities which needs to be constantly addressed.

JS is a **dynamic** (being fully interpreted, like Python), **weakly typed** language (like C).

What about F# instead? F# is a **statically (strongly) typed** language.

[Here is a great F# getting started microsoft guide.](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/)

**F#** was born instead as a general purpose programming language, it evolved as an **OCaml** (Object Oriented Categorical Abstract **M**eta **L**anguage) for **.NET** so mostly for server side programming (Backend).

F stands for Functional, Fun, but most likely also for **System-F** a family of type systems. [Hindley-Milner](https://stackoverflow.com/questions/399312/what-is-hindley-milner) is a restriction of [System F](http://en.wikipedia.org/wiki/System_F), which allows more types but which **requires annotations by the programmer**.

With a very active community, F# also evolved to support FE/**Browser** programming originally via babel.js (**Fable.js**), so that it actually turns F# code into JS a bit like typescript, with a little extra caveat of not being a JS superset, so it needs a bit of extra work for direct **JS interop**.

If you want to [run it in the FE](https://fable.io/docs/2-steps/your-first-fable-project.html) you will need also **npm** and **Fable.js**, this needs a bit of extra setup as it combines 2 separate worlds.

![](https://miro.medium.com/v2/resize:fit:1400/0*J9_o9xgdIGGJaNxo.png)

F# is a .net language but also a javascript/npm language thanks to Fable.js, image cred. [Onur Gumus](https://onurgumus.github.io/2021/01/31/What-the-F.html)

# Launch the interactive prompt (REPL)

```
dotnet fsi
node
```

Similarly to Js and Python, F# also has an i**nteractive environment**, where you can execute code line by line, verify it test it and play around with it. Allowing for a REPL development experience which matches dynamic languages but **keeping all the advantages** of a being a statically typed lang.

# Run a script from command line

```
dotnet fsi script.fsx
node script.js
```

You can also execute your programs by loading your script files directly in the interactive environment, similarly to python, ruby or js.

# Build and run

```
dotnet runn
pm run start
```

As a side note, **when compiling a .NET language you get several benefits** over the dynamic counterpart, both in terms of **performance** and **robustness** (type-checking).

**F# is compiled** (like C#) so it type checks your program before running it, allowing for a much better modelling and robustness of your solution, and for early detection of error and failures.

# Installing a package

```
dotnet add package <PKG_NAME> 
npm install <PKG_NAME>
```

.NET has almost a unique way of installing packages, this makes it easy and reliable, with nuget being nowadays baked inside the dotnet toolchain, and one of the best with dependency resolution. Many other langs have quite some issues in dependency versioning and resolution with packages, Java Maven or npm being a few examples, or even go.

In this respect, dotnet it’s clearly a superior choice for package management without doubt.

# Running tests

```
dotnet test
npm test
```

in the dotnet world, the most used libraries for testing work by default with a simple command, not having to configure custom scripts to run you tests.

In npm world, this is slightly different, but still quite easy to setup your test scripts depending on your library of choice.

# Functions

Here is a function in JS

```js
function myFunc(x) {   return x + 1;};
```

Never forget the ending semicolon in Js as you might have scope resolution madness :) in quite some corner cases.

Another approach is the Js lambda way, which resembles more the F# syntax

```js
//modern js also uses let (and const)
const myFunc = x => x + 1; 
```

In F# everything is an expression (both functions and values), so only 2 keywords are essential to know: let, to bind an expression to a symbol in scope, and type, to create and define your types (as F# is statically typed, a bit like typescript).

```fsharp
// last value in scope is always the return value
let myFunc x = x + 1  
```

A few extra things to note in the F# code:

- **scoping is done with spacing like python**, allowing for a more succint and expressive code (less character noise), the compiler will actually complain if the spacing is wrong, as getting the scope right is obviously needed. Usually this is automatically taken care by IDEs or extensions.
- **drop the ending semicolons**: `;` has an historical usage from OCaml in F#, but you can totally avoid it all the way, except for collection elements separation, e.g. `[1;2;3]` or member declaration inside records `{ Name = ""; Surname = "" }`
- **drop curly braces for scoping { … }**, they are used for something else in F#, called computation expressions (e.g. async, task, query, or custom defined ones…), a very powerful language feature
- **drop return keyword**. The last value returned in a block (at the right bottom of a scope) is always the return value, the return keyword is also reserved to be used only within computation expressions, so in normal function you should never use return (which makes the code extra short).
- in F# all bindings are **immutable by default**, so equivalent to **const** in modern day JS. In fact if you want a mutable binding (which is a “variable”) you should append the keyword **mutable** in the definition, and use the assignment arrow operation to “change” its stored memory value.

```fsharp
let mutable x = 5 //this binding is now a "variable"
x <- 6 // we are "dangerously" changing it's value in memory (side effect)
// we loose referential transparency (and purity)
// in a multi-threaded and parallel scenario, this is also not desired
```

F# **has lambdas as well** obviously, but since everything is an expression/function, there is not so much difference with a normal binding, except when using them as anonymous functions when passed as arguments (that is still handy).

```fsharp
let myFunc = fun x -> x + 1 // same... but with lambda
```

# Objects

![](https://miro.medium.com/v2/resize:fit:1400/1*8nqfhXmTkQHFpCMwnZIFdw.png)

[https://neetishop.medium.com/immutable-objects-with-property-descriptors-in-javascript-31693faaf03](https://neetishop.medium.com/immutable-objects-with-property-descriptors-in-javascript-31693faaf03)

Here is how you would create dnyamic objects in js old-school

```js
var x = {}; //or let x.name = "John";x.age = 5;
```

and here is how you would create it in modern (_immutable-ish\* lol_), as it is actually still mutable js, thanks to Janne Siera for the tip.

```js
const person = {name:"John", age:50};
```

Turns out doing immutable in js is kind of hard, trying out any const object in dev tools reveals the ever-lasting mutable js nature! Point for F#.

Well, the **good news is that F# looks exactly like JS**, and you can even create anonymous records if you are not interested in specifying a custom type explicitly (it will still be type-checked as anonymous).

```fsharp
let person = {| Name="John"; Age=50|} // anonymous record
```

or with the longer typed version, **but typing in the end can give you many advantages**, as you might now yourself from working with typescript or flow:

```fsharp
type Person = { Name:string; Age:int } // record type

let person = { Name="John"; Age=50 } // Person 
```

When **compared to typescript** (or modern ES with **class** support), here is how they look like showing that even in typescript **the typing is way more verbose** (similar to C#).

```ts
// same length, but mutable :(
class Person { name: string; age: number; }

// the longer immutable version which corresponds to 1 F# line :) 
class Person {   
    name: string;   
    age: number;   

    constructor(name: string, age: number) {      
        this.name = name;      
        this.age = age;   
    }
}
//usage
const john = new Person("John", 34);
```

# Web APIs

In js for example using [expressjs](https://expressjs.com/) library

```js
// npm install express --saveconst express = require('express')
const app = express();
const port = 3000;
app.get('/', (req, res) => {  
    res.send('Hello World!')});

app.listen(port, () => {  
    console.log(`listening at http://localhost:${port}`)});
```

The minimal F# webapi with [Saturn](https://saturnframework.org/) (on top of aspnetcore)

```fsharp
// dotnet add package Saturn
open Saturn 
open Giraffe  

let app = application {     
        use_router (text "Hello World from Saturn")    
    }  

run app
```

Note, the application { … } code block uses curly braces, and indeed is a custom computation expression (c.e.), so again, curly braces are not used for scoping, but for “smart magic objects” in F# (c.e.). Other examples are async, task, and query.

# F# to JS via Fable

![](https://miro.medium.com/v2/resize:fit:1400/1*Jbq785CEjBDd-MT1l43NTg.png)

[Fable](https://fable.io/) is a F# to JS transpiler (similar to typescript in some ways) born as F# to Babel.js project, allows great F# interoperability with JS and node ecosystem, making F# a great tool for full stack dev (see SAFE stack), without the need of wasm. If you are interested in web assembly, there is also an F# wasm project relying on Blazor though called Bolero.  
Here we are running F# on nodejs using expressjs for serving http requests. Isn’t that awesome?

```fsharp
// dotnet add package Glutinum.Express --version 0.1.0-alpha-002
// npm install express
open Glutinum.Express 

let application = Express() 

application.get "/" (fun _req res -> 
    res.send "Hello World!") 

application.listen 3000 (fun () -> 
    printf "listening at http://localhost:3000")
```

A note, [Glutinum.Express](https://github.com/AngelMunoz/expressive) is still under development, but works as a Fable binding for expressjs.

# Accessing the DOM via Fable browser

Let’s say we have some HTML dom containing a div with an id “intro”.

```js
// <div id="intro">...</div>
const element = document.getElementById("intro");
```

To do the same in F# we just need to import some utility library, and voila’

```fsharp
//dotnet add package Fable.Browser.Dom
open Browser
let element = document.getElementById("intro")
```

# Rendering an HTML view in React

```js
import ReactDOM from 'react-dom'; 
import React, { useState } from 'react';  
function Counter() {   
   // Declare a new state variable, which we'll call "count"   
   const [count, setCount] = useState(0);    
   return (<div>       
      <h1>{count}</h1>       
      <button onClick={() => setCount(count + 1)}>         
      Increment       
      </button>     
   </div>); 
}  
ReactDOM.render(<Counter />, document.getElementById("root"))
```

Thanks to [Feliz](https://zaid-ajaj.github.io/Feliz/#/Feliz/ReactApiSupport) library, the exact same API is available in F# too

```fsharp
module App  
open Feliz  
[<ReactComponent>] 
let Counter() =     
   let (count, setCount) = React.useState(0)     
   Html.div [         
     Html.h1 count         
     Html.button [             
         prop.text "Increment"             
         prop.onClick (fun _ -> setCount(count + 1))         
     ]     
   ]  
open Browser.Dom  
ReactDOM.render(Counter(), document.getElementById "root")
```

As an extra feature, the HTML view libraries (for example Feliz views or Giraffe views) can be used also in server side projects, so also from pure .NET codebase, allowing nicely integrated F#-HTML both in FE and BE (instead of external files).

Plus CSS type providers as well allow for typed F#-CSS to be used within the code. Will not write more on that here as it’s quite a lot of info already, but you can easily find more information on the topics mentioned.