# Interface Greeting Example

This project demonstrates a simple and clean use of **interfaces in C#** by implementing a greeting system based on the hour of the day.

The goal of this example is educational — to show how interfaces help separate **abstraction from implementation** while keeping the code easy to read, test, and extend.

---

## 📌 Overview

The application asks the user to enter an hour (0–23) and prints an appropriate greeting in English:

* **Good morning**
* **Good afternoon**
* **Good evening**
* **Good night**

The greeting logic is defined through an interface and implemented using a concrete class.

---

## 🧠 Key Concepts Demonstrated

* Interface-based design
* Separation of concerns
* Polymorphism
* Switch expressions with pattern matching
* Clean and readable C# code

---

## 🔌 Interface

The interface defines a contract for greeting behavior:

```csharp
public interface IGreet
{
    string GetGreeting(int hour);
}
```

This allows different implementations to be created without changing the code that uses them.

---

## ⚙️ Implementation

The greeting logic is implemented using a modern C# switch expression:

```csharp
public class Greeter : IGreet
{
    public string GetGreeting(int hour)
    {
        return hour switch
        {
            >= 5 and <= 11 => "Good morning!",
            >= 12 and <= 17 => "Good afternoon!",
            >= 18 and <= 22 => "Good evening!",
            _ => "Good night!"
        };
    }
}
```

---

## ▶️ How It Works

1. The user enters an hour between **0 and 23**
2. The program calls the greeting service through the interface
3. The appropriate greeting is returned and displayed

```csharp
IGreetingService greetingService = new GreetingService();
Console.WriteLine(greetingService.GetGreeting(hour));
```

The program depends on the **interface**, not the concrete implementation.

---

## ✅ Why Use an Interface Here?

Using an interface provides several benefits:

* The program is loosely coupled
* The greeting logic can be replaced or extended
* The code is easier to test
* The design follows the **Dependency Inversion Principle**

For example, new implementations could be added later:

* `GermanGreetingService`
* `FrenchGreetingService`
* `TimeBasedGreetingService`

Without changing the main program logic.

---

## 🧪 Testing Friendly Design

Because the hour is passed as a parameter, the logic can be easily tested:

```csharp
GetGreeting(9);   // Good morning
GetGreeting(15);  // Good afternoon
GetGreeting(21);  // Good evening
```

No system time dependencies are required.

---

## 🎯 Purpose

This project is intended as a **learning example** for developers who are beginning with:

* Interfaces in C#
* Clean architecture principles
* Writing maintainable and readable code

It is suitable for documentation, tutorials, and beginner-friendly demonstrations.

---

## 📄 License

This project is provided for educational purposes and can be freely used in learning materials or documentation examples.
