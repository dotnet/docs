// Define an empty interface (also known as a marker interface)
type IMarker = 
    interface end

// Implement the empty interface in a record type
type MyRecord = 
    { Name: string }
    interface IMarker

// Implement the empty interface in a class type
type MyClass(value: int) =
    member _.Value = value
    interface IMarker
