
// <InstantiateClass>
Customer object1 = new Customer();
// </InstantiateClass>

// <DeclareVariable>
Customer object2;
// </DeclareVariable>


// <AssignReference>
Customer object3 = new Customer();
Customer object4 = object3;
// </AssignReference>

/* 
var p1 = new Person(); // Error! Required properties not set
*/
var p2 = new Person() {FirstName = "Grace", LastName = "Hopper" };

// <ClassDeclaration>
//[access modifier] - [class] - [identifier]
public class Customer
{
   // Fields, properties, methods and events go here...
}
// </ClassDeclaration>

// <RequiredProperties>
public class Person
{
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
}
// </RequiredProperties>

public class Employee {}

// <DerivedClass>
public class Manager : Employee
{
    // Employee fields, properties, methods and events are inherited
    // New Manager fields, properties, methods and events go here...
}
// </DerivedClass>