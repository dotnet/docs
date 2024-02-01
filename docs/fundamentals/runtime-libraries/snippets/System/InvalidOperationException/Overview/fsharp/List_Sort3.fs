module List_Sort3

// <Snippet14>
open System
open System.Collections.Generic

type Person(firstName, lastName) =
    member val FirstName = firstName with get, set
    member val LastName = lastName with get, set

type PersonComparer() =
    interface IComparer<Person> with
        member _.Compare(x: Person, y: Person) =
            $"{x.LastName} {x.FirstName}".CompareTo $"{y.LastName} {y.FirstName}"

let people = ResizeArray()

people.Add(Person("John", "Doe"))
people.Add(Person("Jane", "Doe"))
people.Sort(PersonComparer())
for person in people do
    printfn $"{person.FirstName} {person.LastName}"
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet14>