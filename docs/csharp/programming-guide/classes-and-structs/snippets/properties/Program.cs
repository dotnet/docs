// See https://aka.ms/new-console-template for more information

using properties;

// <UseTimePeriod>
TimePeriod t = new TimePeriod();
// The property assignment causes the 'set' accessor to be called.
t.Hours = 24;

// Retrieving the property causes the 'get' accessor to be called.
Console.WriteLine($"Time in hours: {t.Hours}");
// The example displays the following output:
//    Time in hours: 24
// </UseTimePeriod>

var person = new Person("Magnus", "Hedlund");
Console.WriteLine(person.Name);
// The example displays the following output:
//      Magnus Hedlund

// <RequiredExample>
var item = new SaleItem { Name = "Shoes", Price = 19.95m };
Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
// </RequiredExample>
