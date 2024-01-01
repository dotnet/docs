module List_Sort2

// <Snippet13>
open System

type Person(firstName: string, lastName: string) =
    member val FirstName = firstName with get, set
    member val LastName = lastName with get, set
    
    interface IComparable<Person> with
        member this.CompareTo(other) =
            compare $"{this.LastName} {this.FirstName}" $"{other.LastName} {other.FirstName}"

let people = ResizeArray()

people.Add(new Person("John", "Doe"))
people.Add(new Person("Jane", "Doe"))
people.Sort()
for person in people do
    printfn $"{person.FirstName} {person.LastName}"
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet13>