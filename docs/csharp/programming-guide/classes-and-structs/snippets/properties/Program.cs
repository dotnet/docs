// See https://aka.ms/new-console-template for more information

using properties;
using VersionSeven;

//<GetAccessor>
var employee = new Employee();
//...

System.Console.Write(employee.Name); // the get accessor is invoked here
//</GetAccessor>

//<SetAccessor>
var student = new Student();
student.Name = "Joe"; // the set accessor is invoked here

System.Console.Write(student.Name); // the get accessor is invoked here
//</SetAccessor>

HidingExample.TestHiding.Test();

// <SnippetInitialize>
var aPerson = new Person("John");
aPerson = new Person { FirstName = "John"};
// Error CS9035: Required member `Person.FirstName` must be set:
//aPerson2 = new Person();
// </SnippetInitialize>
