---
title: Comparing F# with Python - Syntax Comparison
description: Learn about the similarities and differences between F# and Python in terms of syntax and coding examples.
ms.date: [Date]
---
# Comparing F\# with Python

In this section, we will compare the syntax and coding style of the F# programming language with Python. We will highlight the key language features, discuss syntax differences, and provide code examples to illustrate the variations.

## Getting Started

* install [latest **dotnet SDK**](https://dotnet.microsoft.com/download)

* install [VScode](https://code.visualstudio.com/) and add [Ionide](http://ionide.io/) extension

```console
mkdir fsx && cd fsx
touch new.fsx
code .
```

Let's now compare code in our code in `F#` with `python`.

## A function in Python

```python
    def sum(a,b): 
       return a + b
```

## The same function in F\#

```fsharp
    let sum a b = a + b // or quicker, let sum = (+)
```

## A class in Python

```python
class Dog:
    species = "Canis familiaris"

    def __init__(self, name, age):
        self.name = name
        self.age = age

    def description(self):
        return f"{self.name} is {self.age} years old"

    def speak(self, sound):
        return f"{self.name} says {sound}"
```

## A class in F\#

```fsharp
type Dog(name,age) =
  member val Description = 
     $"{name} is {age} years old"
  member this.Speak(sound) =      
     $"{name} says {sound}"
  member val Species = "canis familiaris"
```

## Manipulating Sequences (*)

**F#:** with the **pipe operator** **|>** and **List** module functions:

```fsharp

    let sumOfEvenNumbersFromOneTo100Adding1 =
       [1..100]
       |> List.filter (fun x -> x % 2 = 0)
       |> List.map(fun x -> x + 1)
       |> List.sum //2600
```

**Python:** using the list module (there is no pipe operator, more verbose)

```python
    sample2 = range(1,101) # 1..100

    filteredList = list(filter(lambda x : x % 2 == 0, sample2))

    addOneList = list(map(lambda x : x + 1 , filteredList))

    total = sum(addOneList) # 2600
```

## List Comprehensions (*)

**F#:** list comprehensions are a powerful construct enabled by computation expressions, so **regular F# code is valid within a list comprehension!**

```fsharp
    let listComprehension =
       [
         for x in [1..100] do
             let z = "hello" // just to show you can!
             if x % 2 = 0 then
                  yield x + 1 // value is returned whenever we want
       ]
```

**Python**: also has list comprehensions, **but** **not all python code is valid** within a list comprehension but just a subset, kind of like a “**query subset**” of python?

```python
    list_comprehension = 
       [   
           x + 1 # value is always returned at the top
           for x in range(1,101) # 1..100
           if x % 2 == 0
       ]
```

As we see both languages allow for working with data and sequences, but in my view **F# beats python both in succintness, typing and capabilities here**.

## Reading a JSON file

As an example task, we want to read some fields in a json file, so parse it and display the captured value on the console.

## In Python

```python
    import json

    with open('test.json', 'r') as myfile:

    data = myfile.read()

    obj = json.loads(data)

    print(obj["hello"])
```

## In F# with JsonParser

```fsharp
    #r "**nuget**: FSharp.Data"

    open FSharp.Data

    open FSharp.Data.JsonExtensions // ? op

    let result = 
       (__SOURCE_DIRECTORY__ + "/test.json")
       |> System.IO.File.ReadAllText
       |> JsonValue.Parse

    printfn $"{result?Hello}"
```

## In F# with Type Providers

```fsharp
    #r "**nuget**: FSharp.Data"

    open FSharp.Data

    [<Literal>]

    let jsonFilePath = __SOURCE_DIRECTORY__ + @"/test.json"

    type MyJson = JsonProvider<jsonFilePath>

    let result = MyJson.Load(__SOURCE_DIRECTORY__ + "/prod.json")

    printfn $"{result.Hello}" //strongly typed!
```

## Reading a CSV file

```csv
    Name,Surname,Age
    John,Red,33
    Mike,Bianchi,55
    ...
```

## Python

```python
    import csv

    with open('test.csv') as csv_file:
        csv_reader = csv.reader(csv_file, delimiter=',')
        
        for row in csv_reader:
             print(row[0]) //Name
```

## F\#

```fsharp
    #r "nuget: FSharp.Data"
    open FSharp.Data

    [<Literal>]
    let csvPath = __SOURCE_DIRECTORY__ + "/test.csv"

    type MyCsv = CsvProvider<csvPath, ",">

    for row in MyCsv.GetSample().Rows do

       printfn $"{row.Name}" // first column header = Name
```

## Plotting some lines with Plotly

## Python

```python
    import plotly.express as px
    
    df = list(range(1, 11)) //1...10
    fig = px.line(df)
    fig.show()
```

## F\#

```fsharp
    #r "nuget: XPlot.Plotly"
    
    open XPlot.Plotly
    
    [ 1 .. 10 ] |> Chart.Line |> Chart.Show
```

## Starting a local web server

## Python

```python
    from flask import Flask
    
    app = Flask(__name__)
    
    @app.route('/')
    def index():
        return 'Hello World!'
    
    app.run(host='0.0.0.0', port=81)
```

## F\#

```fsharp
    #r "nuget: Suave"

    open Suave  

    startWebServer defaultConfig (Successful.OK "Hello World!")
```
