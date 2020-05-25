// The following let expressions are not part of the Person class. Make sure
// they begin at the left margin.
let person1 = Person("John", 43)
let person2 = Person("Mary")

// Send a new value for Mary's mutable property, Age.
person2.Age <- 15
// Add a year to John's age.
person1.HasABirthday()

// Display results.
System.Console.WriteLine(person1.ToString())
System.Console.WriteLine(person2.ToString())
// Is Mary old enough to vote?
System.Console.WriteLine(person2.IsOfAge(18))